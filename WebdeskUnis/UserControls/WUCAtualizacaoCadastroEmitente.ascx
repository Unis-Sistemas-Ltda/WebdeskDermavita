<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtualizacaoCadastroEmitente.ascx.vb" Inherits="WebdeskUnis.WUCAtualizacaoCadastroEmitente" %>
<style type="text/css">
    #TABLE1
    {
        width: 550px;
        color: #666666;
        font-family: Verdana;
        font-size: 9pt;
    }
    </style>
<script language="javascript" type="text/javascript">

</script>

<script language="jscript" src="../JScript2.js" type="text/jscript"> </script>

<link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />

<table cellpadding="1" cellspacing="1" id="TABLE1" 
     class="TextoCadastro" style="font-size: 8pt; border-collapse: collapse;">
    <tr>
        <td align="left" colspan="2">
            <asp:Label ID="LblErro" runat="server" ForeColor="#CC0000"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:Label ID="Label2" runat="server" 
                Text="Dados Gerais" CssClass="SubTitulo"></asp:Label>
            <asp:DropDownList ID="DdlTpPessoa" runat="server" Font-Names="Arial" Font-Size="8pt"
                Width="100px" Enabled="False" style="font-size: x-small" Visible="False">
                <asp:ListItem Selected="True" Value="PJ">Jur&#237;dica</asp:ListItem>
                <asp:ListItem Value="PF">F&#237;sica</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlClassificacao" runat="server" Width="300px" 
                CssClass="Cadastro" Font-Size="8pt" Visible="False">
                <asp:ListItem Value=" "> (selecione)</asp:ListItem>
                <asp:ListItem Value="1">Somente Alopatia</asp:ListItem>
                <asp:ListItem Value="2">Somente Homeopatia</asp:ListItem>
                <asp:ListItem Value="0">Ambas</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TxtCodEmitente" runat="server" Visible="False"></asp:TextBox>
            <asp:RadioButtonList ID="rblSocioABFH" runat="server" RepeatColumns="2" 
                style="font-size: 9pt" Visible="False">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Nao</asp:ListItem>
            </asp:RadioButtonList>
                </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblNome" runat="server"
                Text="Raz&atilde;o Social:"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtNome" runat="server" Font-Size="8pt" 
                Width="300px" Enabled="False" style="font-size: x-small"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Label1" runat="server"
                Text="Nome Fantasia:"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtNomefantasia" runat="server" 
                Font-Size="8pt" Width="300px" Enabled="False" style="font-size: x-small"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblEmail" runat="server"
                Text="Email Principal:"></asp:Label></td>
        <td valign="bottom">
            <asp:TextBox ID="TxtEmail" runat="server" Width="300px" 
                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" 
                Font-Size="8pt"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" style="text-align: right">
            <asp:Label ID="LblEmail0" runat="server"
                Text="Qtde. de Funcion&aacute;rios:"></asp:Label>
            <br />
        </td>
        <td valign="bottom">
            <asp:TextBox ID="TxtQtdFuncionarios" runat="server" Font-Names="Arial" Font-Size="8pt"
                Width="60px" style="font-size: x-small"></asp:TextBox>
            <br />
                </td>
    </tr>
    <tr>
        <td align="left" style="text-align: right">
            <asp:Label ID="Label5" runat="server" 
                Text="Regional:"></asp:Label>
        </td>
        <td valign="bottom">
            <asp:DropDownList ID="DdlRegional" runat="server" Width="300px" 
                Height="16px" CssClass="Cadastro" Font-Size="8pt">
            </asp:DropDownList>
                </td>
    </tr>
    <tr>
        <td align="right" colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" Text="Incluir" 
                Width="105px" />
            </td>
    </tr>
    </table>