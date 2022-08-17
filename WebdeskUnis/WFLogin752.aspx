<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFLogin752.aspx.vb" Inherits="WebdeskUnis.WFLogin752" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Acesso Restrito</title>
    <link href="CSSUnis.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
    </head>
<body style="background-color: #000000;">
    <form id="form1" runat="server">

    <table style="width: 100%; border-collapse: collapse;" 
        class="TextoCadastro">
        <tr>
            <td align="center" style="background-color: #000000">
                <br />
                <br />
                <br />
                <br />
                <img 
                    alt="" src="Imagens/logo-cliente.png"  /></td>
        </tr>
        <tr>
            <td align="center" 
                
                
                style="background-color: #000000; font-family: 'trebuchet MS'; font-size: 12pt; font-weight: bold; color: #E2E2E2;">
                <br />
                <br />
                <br />
                ÁREA DO CLIENTE<br /></td>
        </tr>
        <tr>
            <td align="center" 
                
                
                
                style="background-image: url('Imagens/listelo.png'); background-repeat: repeat-x; background-color: #000000;">
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="TextoCadastro">
                <hr />
            </td>
        </tr>
        <tr class="Titulo2">
            <td>
                <b style="color: #E2E2E2; font-family: 'Trebuchet MS'; font-size: 12pt;">ACESSO RESTRITO</b></td>
        </tr>
        <tr>
            <td class="TextoCadastro">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; color: #E2E2E2; font-family: 'Trebuchet MS'; font-size: 10pt;">
                Preencha os campos abaixo para ter acesso ao sistema<br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="Erro" style="text-align: center">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; color: #E2E2E2; font-family: 'Trebuchet MS'; font-size: 10pt;">
                &nbsp;<asp:Label 
                    ID="Label2" runat="server" Height="19px" style="text-align: right" 
                    Text="Login:&nbsp;" Width="45px"></asp:Label>
                <asp:TextBox ID="TxtLogin" runat="server" Width="150px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label1" runat="server" Font-Italic="False" ForeColor="#85BCB1" style="text-align:left"
                    Height="17px" Text="Informe seu CPF" Width="261px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; color: #E2E2E2; font-family: 'Trebuchet MS'; font-size: 10pt;">
                <asp:Label ID="Label3" runat="server" style="text-align: right" Height="19px" 
                    Text="Senha:&nbsp;" Width="45px"></asp:Label>
                <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" 
                    Width="150px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label5" runat="server" Font-Italic="False" ForeColor="#85BCB1" style="text-align:left"
                    Height="17px" Width="257px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label4" runat="server" Height="17px" Width="45px"></asp:Label>
                <asp:Button ID="BtnConectar" runat="server" Text="Conectar" CssClass="Botao" />
                &nbsp;<asp:LinkButton ID="BtnEsqueciMinhaSenha" runat="server" Width="205px" 
                    style="text-align: left" Font-Size="8pt" ForeColor="Black" Enabled="False" 
                    EnableTheming="True">Esqueci minha senha ou<br>
                Estou acessando pela primeira vez
                </asp:LinkButton>
                <asp:Label ID="Label6" runat="server" Font-Italic="False" ForeColor="#85BCB1" style="text-align:left"
                    Height="17px" Width="135px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" class="style1">
                </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        </table>

    </form>
    </body>
</html>
