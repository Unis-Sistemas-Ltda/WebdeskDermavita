<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/MPManual.Master" CodeBehind="WGManual.aspx.vb" Inherits="WebdeskUnis.WGManual" %>
<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding:0px; margin:0px; border: 0px; width: 800px; height: 450px">
        <uc1:WUCFrame ID="WUCFrame1" runat="server" />
    </div>
</asp:Content>