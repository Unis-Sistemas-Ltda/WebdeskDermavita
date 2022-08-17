<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoOutrasInformacoes.ascx.vb" Inherits="WebdeskUnis.WUCNegociacaoOutrasInformacoes" %>

<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="SubTituloMovimento" colspan="2">
            Outras Informações<br />
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 160px;">
            Cód.
            Transportadora:</td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtCodTransportadora" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" MaxLength="6" Width="50px" Enabled="false"></asp:TextBox>
           <%-- <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPTransportadora.aspx?textbox=TxtCodTransportadora','EditModalPopupClientes','IframeEdit');" Width="16px" />--%>
                </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome da Transportadora:</td>
        <td style="text-align: left">
                <asp:Label ID="LblNomeTransportadora" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label2" runat="server" Text="Detalhes Formulação:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesFormulacao" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label3" runat="server" Text="Detalhes Embalagem:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesEmbalagem" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label4" runat="server" Text="Detalhes Rótulos:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesRotulos" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label5" runat="server" Text="Detalhes Prazo Entrega:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesPrazoEntrega" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label6" runat="server" Text="Detalhes Pagamento:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesPagamento" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
   
    <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label1" runat="server" Text="Observação:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtObservacao" runat="server" Height="70px" 
                TextMode="MultiLine" Width="400px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    
   
  
    
    <tr>
        <td style="border-color: #CCCCCC; border-width: 1px; text-align: right; vertical-align: top; olor: #CCCCCC; border-top-style: solid;">
            &nbsp;</td>
        <td style="text-align: left; border-width: 1px; border-color: #CCCCCC; text-align: right; vertical-align: top; border-top-style: solid;">
            &nbsp;</td>
    </tr>
    <%--<tr>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" Text="Salvar" CssClass="Botao" 
                Height="23px" />
        </td>
    </tr>--%>
    </table>