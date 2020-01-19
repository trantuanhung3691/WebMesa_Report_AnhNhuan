<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportViewers/ReportViewer.Master"  CodeBehind="ItemSale.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.ItemSale" %>
<%@ Register assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
            <dx:aspxdocumentviewer ID="rpViewer" runat="server" ReportTypeName="(none)">
                        <SettingsReportViewer PrintUsingAdobePlugIn="False" />
                    </dx:aspxdocumentviewer>
        </div>
</asp:Content>