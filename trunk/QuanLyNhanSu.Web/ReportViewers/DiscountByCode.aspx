<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/ReportViewers/ReportViewer.Master"  CodeBehind="DiscountByCode.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.DiscountByCode" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="rpViewer" runat="server">
                        <SettingsReportViewer PrintUsingAdobePlugIn="False" />
                    </dx:ASPxDocumentViewer>
           
        </div>
</asp:Content>
