<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayReport.aspx.cs" Inherits="DbmsSims.Reports.DisplayReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src='<%=ResolveUrl("~/crystalreportviewers13/js/crviewer/crv.js")%>' type="text/javascript"></script>
    <link rel="StyleSheet" href="<%=ResolveUrl("~/Content/bootstrap_override.css")%>" type="text/css" />
    <link rel="StyleSheet" href="<%=ResolveUrl("~/Content/bootstrap.css")%>" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <div>
            
            <asp:Button ID="btnSaveLetters" runat="server" CssClass="btn btn-primary" Text="Save" Visible="false" OnClick="btnSaveLetters_Click" />
            <asp:Button ID="btnCloseWindow" runat="server" CssClass="btn btn-primary" Text="Close Window" Visible="true" OnClick="btnCloseWindow_Click" />
            

            <br />

            <div class="lblDarkBlue">Member Letter:</div>
            <CR:CrystalReportViewer ID="cryrptvwMember" 
                                    runat="server" 
                                    AutoDataBind="True"
                                    HasDrilldownTabs="False" 
                                    HasToggleGroupTreeButton="False" 
                                    HasToggleParameterPanelButton="False" 
                                    ToolPanelView="None" 
                                    Height="50px" 
                                    ToolPanelWidth="200px" 
                                    Width="350px"/>




            <asp:Panel ID="pnlTpaLetter" runat="server" Visible="false">

                <div class="lblDarkBlue">TPA Letter:</div>  

                <CR:CrystalReportViewer ID="cryrptvwTpa" 
                                    runat="server" 
                                    AutoDataBind="True"
                                    HasDrilldownTabs="False" 
                                    HasToggleGroupTreeButton="False" 
                                    HasToggleParameterPanelButton="False" 
                                    ToolPanelView="None" 
                                    Height="50px" 
                                    ToolPanelWidth="200px" 
                                    Width="350px"/>


            </asp:Panel>

            

                      
            <asp:Panel ID="pnlFacilityLetter" runat="server" Visible="false">

                <div class="lblDarkBlue">Facility Letter:</div>  

                <CR:CrystalReportViewer ID="cryrptvwFacility" 
                                    runat="server" 
                                    AutoDataBind="True"
                                    HasDrilldownTabs="False" 
                                    HasToggleGroupTreeButton="False" 
                                    HasToggleParameterPanelButton="False" 
                                    ToolPanelView="None" 
                                    Height="50px" 
                                    ToolPanelWidth="200px" 
                                    Width="350px"/>


            </asp:Panel>




            <asp:Panel ID="pnlReferringProvider" runat="server" Visible="false">

                <div class="lblDarkBlue">Referring Provider Letter:</div>  

                <CR:CrystalReportViewer ID="cryrptvwReferringProvider" 
                                    runat="server" 
                                    AutoDataBind="True"
                                    HasDrilldownTabs="False" 
                                    HasToggleGroupTreeButton="False" 
                                    HasToggleParameterPanelButton="False" 
                                    ToolPanelView="None" 
                                    Height="50px" 
                                    ToolPanelWidth="200px" 
                                    Width="350px"/>


            </asp:Panel>




            <asp:Panel ID="pnlReferredToProvider" runat="server" Visible="false">

                <div class="lblDarkBlue">Referred To Provider Letter:</div>  

                <CR:CrystalReportViewer ID="cryrptvwReferredToProvider" 
                                    runat="server" 
                                    AutoDataBind="True"
                                    HasDrilldownTabs="False" 
                                    HasToggleGroupTreeButton="False" 
                                    HasToggleParameterPanelButton="False" 
                                    ToolPanelView="None" 
                                    Height="50px" 
                                    ToolPanelWidth="200px" 
                                    Width="350px"/>


            </asp:Panel>


            <br />

            <asp:Button ID="btnSaveLetters2" runat="server" CssClass="btn btn-primary" Text="Save" Visible="false" OnClick="btnSaveLetters_Click" />
            <asp:Button ID="btnCloseWindow2" runat="server" CssClass="btn btn-primary" Text="Close Window" Visible="true" OnClick="btnCloseWindow_Click" />



            <asp:HiddenField ID="hideLetterType" runat="server" />
            <asp:HiddenField ID="hideReferralNumber" runat="server" />
            <asp:HiddenField ID="hideMemberId" runat="server" />


        </div>
    </form>
</body>
</html>
