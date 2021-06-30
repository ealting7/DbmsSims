using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using DbmsSims.Models;

namespace DbmsSims
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class DbmsSimsUserManager : UserManager<DbmsSimsUser>
    {
        public DbmsSimsUserManager(IUserStore<DbmsSimsUser> store)
            : base(store)
        {
        }

        public static DbmsSimsUserManager Create(IdentityFactoryOptions<DbmsSimsUserManager> options, IOwinContext context) 
        {

            var manager = new DbmsSimsUserManager(new UserStore<DbmsSimsUser>(context.Get<DbmsSimsIdentityDbContext>()));


            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<DbmsSimsUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };


            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };


            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;


            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<DbmsSimsUser>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<DbmsSimsUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });


            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<DbmsSimsUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }


            return manager;

        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class OwinSignInManager : SignInManager<DbmsSimsUser, string>
    {
        public OwinSignInManager(DbmsSimsUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(DbmsSimsUser user)
        {
            return user.GenerateUserIdentityAsync((DbmsSimsUserManager)UserManager);
        }

        public static OwinSignInManager Create(IdentityFactoryOptions<OwinSignInManager> options, IOwinContext context)
        {
            return new OwinSignInManager(context.GetUserManager<DbmsSimsUserManager>(), context.Authentication);
        }
    }
}
