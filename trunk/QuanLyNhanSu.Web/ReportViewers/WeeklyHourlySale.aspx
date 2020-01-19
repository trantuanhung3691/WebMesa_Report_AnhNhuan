<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportViewers/ReportViewer.Master"  CodeBehind="WeeklyHourlySale.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.WeeklyHourlySale" %>
<%@ Register Assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="rpViewer" runat="server">
            <SettingsReportViewer PrintUsingAdobePlugIn="False" />
        </dx:ASPxDocumentViewer>
    </div>
</asp:Content>
