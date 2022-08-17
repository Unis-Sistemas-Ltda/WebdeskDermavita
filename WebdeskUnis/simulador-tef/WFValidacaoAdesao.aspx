<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFValidacaoAdesao.aspx.vb" Inherits="WebdeskUnis.WFValidacaoAdesao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 126px;
            height: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: 9pt">
    
        <br />
        <br />
        <br />
        <img alt="Unis Sistemas" class="style1" src="../Imagens/unis.jpg" /><br />
        <br />
        <br />
        <br />
        <asp:Label ID="LblErro" runat="server" 
            Text="Prezado cliente,&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;Sua adesão ao Convênio TEF foi confirmada com sucesso.&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;Em breve você receberá nosso contato para concluirmos os procedimentos necessários." 
            Font-Bold="False" Width="60%"></asp:Label>
        <br />
        </div>
    </form>
</body>
</html>
