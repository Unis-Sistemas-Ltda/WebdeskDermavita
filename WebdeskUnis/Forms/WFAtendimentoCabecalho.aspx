<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimentoCabecalho.aspx.vb" Inherits="WebdeskUnis.WFAtendimentoCabecalho" %>

<%@ Register src="../UserControls/WUCAtendimentoCabecalho_Suporte.ascx" tagname="WUCAtendimentoCabecalho_Suporte" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:WUCAtendimentoCabecalho_Suporte ID="WUCAtendimentoCabecalho_Suporte1" 
        runat="server" />
    </form>
</body>
</html>