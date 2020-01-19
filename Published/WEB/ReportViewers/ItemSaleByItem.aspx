<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportViewers/ReportViewer.Master"  CodeBehind="ItemSaleByItem.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.ItemSaleByItem" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="DevExpress.XtraReports.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
        <dx:aspxdocumentviewer ID="rpViewer" runat="server" ReportTypeName="(none)">
                        <SettingsReportViewer PrintUsingAdobePlugIn="False" />
                    </dx:aspxdocumentviewer>
        </div>
</asp:Content>