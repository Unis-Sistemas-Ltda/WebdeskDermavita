<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCContato.ascx.vb" Inherits="WebdeskUnis.WUCContato" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<link href="../Ajax.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    function getbacktostepone() {
        window.location = "WFContato.aspx";
    }
    function onSuccess() {
        window.parent.document.getElementById('ButtonEditDone').click();
        window.parent.document.forms.item(0).submit();
    }
    function onError() {
        getbacktostepone();
    }
    function cancel() {
        window.parent.document.getElementById('ButtonEditCancel').click();
    }
    </script>

<body>
<table style="width:500px; background-color:White;">
    <tr>
        <td colspan="2">
            <asp:RadioButtonList ID="RblPreferencial" runat="server" 
                CssClass="CampoCadastro" RepeatColumns="2" Visible="False">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">N&atilde;o</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="LblAcao" runat="server" Visible="False"></asp:Label>
            <asp:RadioButtonList ID="RblAtivo" runat="server" CssClass="CampoCadastro" 
                RepeatColumns="2" Visible="False">
                <asp:ListItem Selected="True" Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">N&atilde;o</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TituloCadastro" colspan="2">
    <asp:Label ID="LblTitulo" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="Instrucao" colspan="2" style="font-size: 8pt">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            C&oacute;digo:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodContato" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <span style="color: #990000;">*</span>Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="230px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Fun&ccedil;&atilde;o:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTitulo" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telefones:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefone1" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="17px" Text="/"></asp:Label>
&nbsp;<asp:TextBox ID="TxtTelefone2" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Celulares:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCelular1" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="17px" Text="/"></asp:Label>
&nbsp;<asp:TextBox ID="TxtCelular2" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Fax:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtFax" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <span style="color: #990000;">*</span>E-mail:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="230px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" 
                Visible="False" />
            &nbsp;<asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Visible="False" 
                CssClass="Botao" />
        </td>
    </tr>
    </table>
</body>