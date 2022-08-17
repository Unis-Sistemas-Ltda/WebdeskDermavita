<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGDadosCadastrais.aspx.vb" Inherits="WebdeskUnis.WGDadosCadastrais" %>
<%@ Register src="../UserControls/WUCDadosCadastrais.ascx" tagname="WUCDadosCadastrais" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Titulo">&nbsp;Dados Cadastrais</div>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Label ID="LblInstrucoesBoleto" runat="server" 
            Text="Prezado cliente, nesta área você pode conferir e atualizar seus dados cadastrais&lt;/b&gt;.&lt;br /&gt;"></asp:Label>
       </div>
     <div style="padding:0px; margin:0px; border: 0px; width: 800px; height: 450px">
        <uc1:WUCDadosCadastrais ID="WUCDadosCadastrais1" runat="server" />
    </div>
    
    </form>
</body>
</html>
