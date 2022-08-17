<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFConfiguracaoLogin.aspx.vb" Inherits="WebdeskUnis.WFConfiguracaoLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;" class="TextoCadastro">
            <tr>
                <td class="Titulo" colspan="2">
                    Configurações - Login</td>
            </tr>
            <tr>
                <td class="Erro" colspan="2">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Informe o e-mail a ser utilizado como login de acesso à Webdesk Unis:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                        MaxLength="100" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="Botao" Text="Salvar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
