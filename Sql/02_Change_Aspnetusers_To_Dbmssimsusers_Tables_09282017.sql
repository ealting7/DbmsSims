﻿EXECUTE sp_rename @objname = N'dbo.AspNetUsers', @newname = N'DbmsSimsUser', @objtype = N'OBJECT'
IF object_id('[PK_dbo.AspNetUsers]') IS NOT NULL BEGIN
    EXECUTE sp_rename @objname = N'[PK_dbo.AspNetUsers]', @newname = N'PK_dbo.DbmsSimsUser', @objtype = N'OBJECT'
END
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201709282005312_ChangedAspnetuserTableToDbmssimsuser', N'DbmsSims.Migrations.Configuration',  0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CD919CC1ADD099CB69D35767CC1B427C8DB802DB1DBC2489422528E8D45BE2C0FF9A4FCC216752745AAA96EF5C5C100034B244F158B45B2583CEA3F7FFF63FCFD4B1858CF38A17E4426F6C9E8D8B6307123CF27CB899DB2C5B71FECEFBFFBFBDFC6575EF862FD54D63BE3F5A025A113FB89B1F8DC71A8FB84434447A1EF26118D166CE446A183BCC8393D3EFEB77372E26080B001CBB2C69F52C2FC10670FF0388D888B6396A2E036F270408BF75032CB50AD3B14621A23174FECCB7948677E48477955DBBA087C046ACC70B0B02D4448C4100325CF3F533C63494496B3185EA0E0F135C6506F81028A0BE5CFEBEAA6FD383EE5FD70EA8625949B5216853D014FCE0AC33872F3B5CC6B578603D35D8189D92BEF7566BE897DE3E1ECD5A7280003C802CFA741C22B4FECDB4AC4058DEF301B950D4739E4750270BF46C9D75113F1C8326E775439D2E9E898FF3BB2A669C0D2044F084E59828223EB219D07BEFB5FFCFA187DC5647276325F9C7D78F71E7967EFFF85CFDE357B0A7D857AC20B78F59044314E4037BCA8FA6F5B8ED8CE911B56CD1A6D72AB802FC19CB0AD5BF4F21193257B82D972FAC1B6AEFD17EC956F0AE7FA4C7C9842D08825293CDEA54180E601AECA9D4E99FCFF0EA9A7EFDE0F22F50E3DFBCB6CE825F930711298579F709095D2273FCEA79730DE5F8A6AD74914F267D1BFF2D22FB3284D5CDE99485BE511254BCC44EDC64EEDBC462ECDA18677EB12F5F05D9B6BDA766F6555DEA17566422962D7B3A1D477BB728D3DAEDC7EB839BABC4DDAA646CD764756F954BBCB89A9BB10E8C65F79F5BB0A911F0CB0FC194881B063E12721AE7AF94304CE86486F9D1F10A530FBBDFF20FAD4A13AFC3980EA33ECA60938E58CA130DEBAB487A788E0BB349C7377DF9DACC186E6F1D7E81AB92C4AAE086FB531DEC7C8FD1AA5EC8A789788E1CFCC2D01F9E3A31F9A030CA2CE85EB624AAFC199B1378D20AA2E016F083B3BED0DC757A77D871FD300C1CAA88C3F9A8BE897B25E1D80288A5B1188AA8E2A04E9D2F063B4F4898186653D8D867971B786459DBE1A722403058B6A1AFDB2D26EF5F22A838570D9780C1FC365B0871FC46DB643EB267CC38C335806F18F98E004D62AEF01318613528F80C9E2B08F88201B3E2E74EB1B5026E92714A4438B5A6B3664737FF8D990C11EFE6CC8D484D7CFBEC7430F83934D5919E08DEAAB0F4DABE79CA4D9AEA783D0CD5D0BDFCD1AA09B2E179446AE9FCD02454EABC84888FA43A066AD4E4FE4BD91531CD03170743F06D78637D0375B76AA7B728903CCB075E1E639BF29A22EF2DA66840E793D142B7754856275AA4354EE9F2D99E0E938E18D103FE95098A93E61ED69E113D78F51B0D24A524BC32D8CF7BD9221975CE218132E70A5254C84AB331B5C814A8E3428AB2C34761A1ED7ED88AAD05437E09D716A3DE262AA6127AED8151D6B7CB188D9B6E28C1D86DA81377618C344BA3627B773772CCE2146832E1F4A0EC71DA5A390C61D8BA069FBEE281A6AD7EE281AE36DB9637EEA341A73E9087A38CE281E7C77BF4DEBADB46B4F142C71608E984791D086410B9C9439B3988F4656F972CE0BF10B531CB340CFE2A4458BA055F60C0E3EC34CCCB9D491AB32A274BA4164F7E902AC5D6C05687153D7021227510FCDCAD45BA76A4560D003B6CC9775C2160BBC04DB70803676F3BAB251517FA9297BA6D121A2EA59E50A2D0F378AF91B380A6F90172CB1E3064651E650DB565919CF1A47B48DFE1463D06197AE00546398B20FC35AA6F4C51596518556C6C1D5FA969162218D65CA3E0C6B99C211571846B1C99B6EF3EB9B45DC95079A486532A2DA46AAB2B193D3938A176347C3631ADFA238F6C9B2C16B2ADE58B39CD434FD76D69FF013E6188E4B15BC9F4ADB4A128B12B4C4522988064DAFFD84B24BC4D01CF154CCD40B5BD5949BA666692F4536F7C5F608966B7C599BFF2DBA5B79772EECA0ED10A300B886EE853C48C9D2DC8AC15737B738C90C05285164D6A7519086441F33E95BE79768CDF6F99B36C2D891F46F85452D53B56256D1EE46A3D29E11438C501592AC3F4A7A089DADCB80B2696D5D90A94729B3474D145D46696FA3A60B4FCC474A88F9FA8F5277F3EDCCA58211D204285EF5C468900A5A608D32735491F7D1C4144BCC1125724713522AEAA16593C22128D92C580B4F6351750D73096DD24613BD5D6A8EACA06F34A115C56B602B7496CBCC51150C8F26B0A2D81CBBA67BC86BE701EF56DAC3C87ADB557E4CDD6CBFD2606C67391C66BB6B5CAA37811AAF7B6215D7E62DB0E2FD41BA92F6F4B69E2BE5A989CD5C4983A15F7384BB6871C9E9BC40D7630A17CCC2B2DE75C1AEC7EBE7B05B758BD6594EAE5249AFCE74D2D96D5C9CA3567FA8D23A58E5556CAB34236CE9AF94E170C42B8C66BF04D3C0C77C012F2BDC22E22F306539A9C23E3D3E39953E77399C4F4F1C4ABD40710ED57D7F228ED90EF851E41925EE134ADA6C850D3ECFA8415BE9E31BE2E19789FDBFACD57996ADE07F65AF8FAC1BFA99F8BFA450F098A4D8FAAD4DB11C86AEDE7DAA3AD08F0BCCAD7AF3F397BCE991759FC08C39B78E255BAE33C2E22707BDB4C99B6EA0CD7A1F22BCDDD924D0FD95A8D26C589FDD3FF7D920CCFE52CB6F42F4F28FBEAA29D9FB1B212A18FA43E10D62421D037F1D2C2DFBDE834796B1EFFB7556CDC65F47352D13DF27FDC1641EBEF91A54B6DCE33EA3380DED6249CAECBC92E2BC11DF71DF1B538B09BDD1446FB39D7BC06DC0685EC333DE181978B0DD51C1F51D0C7B9FAEBD7582EFA1707A6B8EC67EA9BCBB64EF765C02FD4548BBFBA6A22968367B66E7EEDABF7459DB43E63DF6A0E11E92831584AB3DF36D77ED60BA5CEE213B9839B1F690FC6B5FDBE33EBDCB787BDC3B59B64D0FD2DCB2A892BCABC8B079461C4EEFF3083C208F16F3AF11D524AD2EF2E80A817515BD503D3B4C162C4E999650B158257033EAAD19F3B6BBA31ADA6497EC62ADEF945DD4E996AD2126EE83C4ABA409AA58D52BD6AF2E26D31B20ED0A1DE872CE557168E70DF91BE0E86E6E08619668EE770F9E92BBB919869C163D28B8EDEB59D8121BBF3608DB32F5973504FFED41825D6133ACEADC904554EEC99246651529A9728B19F260A7BC4898BF402E83629E16CEBE92CE526DFC72628EBD1B729FB23865D0651CCE032147C5F7F62EF919CF58D4797C1F67BFF3314417404D9FA7D3EFC90FA91F7895DED78A348E0682070D4512968F25E3C9D8E56B8574171143A0C27C55ACF388C33800307A4F66E819AFA31BB8DF47BC44EE6B9DB4D381AC1E08D1ECE34B1F2D1314D202A36E0F8FE0C35EF8F2DDFF0161E77B4574530000 , N'6.1.3-40302')

