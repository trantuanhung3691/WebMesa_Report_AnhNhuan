
<%@ Page Title="" Language="C#" MasterPageFile="~/ReportViewers/ReportViewer.Master" AutoEventWireup="true" CodeBehind="Tender.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.Tender" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server">
                        <SettingsReportViewer PrintUsingAdobePlugIn="False" />
                    </dx:ASPxDocumentViewer>
            <asp:UpdatePanel ID="upInfor" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>