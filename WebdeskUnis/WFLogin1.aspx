<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFLogin1.aspx.vb" Inherits="WebdeskUnis.WFLogin1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Acesso Restrito</title>
    <link href="CSSUnis.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">

    <table style="width: 100%;" class="TextoCadastro">
        <tr>
            <td align="center" style="background-color: #FFFFFF">
                <br />
                <br />
                <img 
                    alt="" src="Imagens/logo-cliente.png" /><br /><br /></td>
        </tr>
        <tr>
            <td align="center" 
                
                style="background-color: #FFFFFF; font-family: 'trebuchet MS'; font-size: 12pt; font-weight: bold;">
                <br />
                <br />
                WEBDESK<br />
                Área do Cliente<br />
            </td>
        </tr>
        <tr>
            <td align="center" 
                
                
                style="background-image: url('Imagens/listelo.png'); background-repeat: repeat-x">
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
                <b>ACESSO RESTRITO</b></td>
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
            <td style="text-align: center">
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
            <td style="text-align: center">
                &nbsp;<asp:Label 
                    ID="Label2" runat="server" Height="17px" style="text-align: right" 
                    Text="Login:&nbsp;" Width="45px"></asp:Label>
                <asp:TextBox ID="TxtLogin" runat="server" Width="150px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label1" runat="server" Font-Italic="False" ForeColor="#4D8C80" style="text-align:left"
                    Height="17px" Text="Informe seu CNPJ" Width="261px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label3" runat="server" style="text-align: right" Height="17px" 
                    Text="Senha:&nbsp;" Width="45px"></asp:Label>
                <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" 
                    Width="150px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label5" runat="server" Font-Italic="False" ForeColor="#4D8C80" style="text-align:left"
                    Height="17px" Width="257px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label4" runat="server" Height="17px" Width="45px"></asp:Label>
                <asp:Button ID="BtnConectar" runat="server" Text="Conectar" CssClass="Botao" />
                &nbsp;<asp:LinkButton ID="BtnEsqueciMinhaSenha" runat="server" Width="200px" 
                    style="text-align: left" Font-Size="7pt" Visible="False">Esqueci minha senha<br>
                Estou acessando pela primeira vez
                </asp:LinkButton>
                <asp:Label ID="Label6" runat="server" Font-Italic="False" ForeColor="#4D8C80" style="text-align:left"
                    Height="17px" Width="135px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
	<tr>
	<td style="text-align: center;">
<br><br><br><b>AUTOMATISA LASER SOLUTIONS</b><br>Rua Paulino Pedro Hermes, 2628<br>Nossa Senhora do Rosário - São José - SC - CEP 88110-694<br><br><b>(48) 3034 9500</b></td>
	</tr>
        </table>

    </form>
    </body>
</html>
