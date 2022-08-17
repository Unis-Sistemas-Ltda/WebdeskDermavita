<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRedirect.aspx.vb" Inherits="WebdeskUnis.WFRedirect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unis - Redirecionamento</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Erro" style="padding: 20px">
        <br />
        <br />
        <asp:Label ID="LblErro" runat="server" 
            Text="Processando solicitação e redirecionando...&lt;br&gt;&lt;br&gt;Aguarde..."></asp:Label>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
