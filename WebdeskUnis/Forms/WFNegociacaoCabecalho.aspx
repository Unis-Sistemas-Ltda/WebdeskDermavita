<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoCabecalho.aspx.vb" Inherits="WebdeskUnis.WFNegociacaoCabecalho" %>

<%@ Register src="../UserControls/WUCNegociacaoCabecalho.ascx" tagname="WUCNegociacaoCabecalho" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <uc1:WUCNegociacaoCabecalho ID="WUCNegociacao1" runat="server" />
    </div>
    </form>
</body>
</html>
