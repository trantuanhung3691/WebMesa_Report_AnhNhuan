﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportViewers/ReportViewer.Master" CodeBehind="ItemSaleByTender.aspx.cs" Inherits="QuanLyNhanSu.Web.ReportViewers.ItemSaleByTender" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="rpViewer" runat="server">
            <SettingsReportViewer PrintUsingAdobePlugIn="False" />
        </dx:ASPxDocumentViewer>
    </div>
    <%--<div>
            <asp:UpdatePanel ID="upInfor" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="rpViewer" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" ShowParameterPrompts="true" AsyncRendering="false"
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="400px" SizeToReportContent="True"
                    Width="800px">
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>--%>
</asp:Content>