<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFDesconectar.aspx.vb" Inherits="WebdeskUnis.WFDesconectar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td class="TextoCadastro_BGBranco">
    
        Você foi desconectado. Para voltar a se conectar, clique
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Forms/WFPrincipal.aspx">aqui</asp:HyperLink>
        .</td>
        </tr>
    </table>
    </form>
</body>
</html>
