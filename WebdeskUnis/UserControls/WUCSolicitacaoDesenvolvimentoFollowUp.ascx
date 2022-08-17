<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSolicitacaoDesenvolvimentoFollowUp.ascx.vb" Inherits="WebdeskUnis.WUCSolicitacaoDesenvolvimentoFollowUp" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<table width="100%">
<tr>
<td class="TituloMovimento" colspan="2">
    Follow Up</td>
</tr>
<tr>
<td class="Erro" colspan="2">
    <asp:Label ID="LblErro" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td style="text-align: right; width: 85px;">
    Seq.:</td>
<td>
    <asp:Label ID="LblSeqFollowUp" runat="server" Font-Bold="True"></asp:Label>
</td>
</tr>
<tr>
<td style="text-align: right; vertical-align: top;">
    Descrição:</td>
<td>
    <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
        Width="90%" Height="100px" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr>
<td style="text-align: right">
    &nbsp;</td>
<td>
    <asp:CheckBox ID="CbxVisivelCliente" runat="server" Text="Visível ao cliente" 
        Checked="True" Visible="False" />
</td>
</tr>
<tr>
<td style="text-align: right">
    &nbsp;</td>
<td>
    <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
</td>
</tr>
</table>