<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNovaSenha.aspx.vb" Inherits="WebdeskUnis.WFNovaSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nova Senha</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 434px; text-align: center" class="TextoCadastro">
            <tr>
                <td rowspan="5">
                    <img src="../imagem/lista_vert.jpg" style="width: 1px; height: 300px" /></td>
                <td class="TextoCadastro_BGBranco" 
                    style="text-align: center; font-family: 'trebuchet MS'; font-size: 12pt; font-weight: bold;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagens/unis.jpg" />
                    <br />
                    </td>
                <td style="width: 29576580px; " rowspan="5">
                    <img src="../imagem/lista_vert.jpg" 
                        style="width: 1px; height: 300px;" /></td>
            </tr>
            <tr>
                <td class="TextoCadastro_BGBranco" 
                    style="text-align: center; font-family: 'trebuchet MS'; font-size: 12pt; font-weight: bold;">
                    WEBDESK</td>
            </tr>
            <tr>
                <td>
                    Geração de senha</td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Style="text-align: left" 
                        Text="Informe seu CNPJ:" Height="17px"></asp:Label>
                    &nbsp;<asp:TextBox ID="TxtCnpj" runat="server" Style="text-align: left" 
                        CssClass="CampoCadastro"></asp:TextBox>
                    &nbsp;<asp:Button ID="BtnGerarSenha" runat="server" Text="Gerar senha" 
                        CssClass="Botao" />
                    &nbsp;
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
                    </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="LblMensagem" runat="server" Width="542px" ForeColor="#CC0000"></asp:Label></td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
