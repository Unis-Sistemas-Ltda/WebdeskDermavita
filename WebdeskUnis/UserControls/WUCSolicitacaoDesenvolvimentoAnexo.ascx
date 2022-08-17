<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSolicitacaoDesenvolvimentoAnexo.ascx.vb" Inherits="WebdeskUnis.WUCSolicitacaoDesenvolvimentoAnexo" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<table width="100%">
<tr>
<td class="TituloMovimento" colspan="2">
    Anexos</td>
</tr>
<tr>
<td class="Erro" colspan="2">
    <asp:Label ID="LblErro" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td style="text-align: right">
    Seq. Anexo:</td>
<td>
    <asp:Label ID="LblSeqAnexo" runat="server" Font-Bold="True"></asp:Label>
</td>
</tr>
<tr>
<td style="text-align: right">
    Arquivo:</td>
<td>
    <asp:FileUpload ID="FU_Anexo" runat="server" CssClass="CampoCadastro" 
        Width="200px" />
</td>
</tr>
<tr>
<td style="text-align: right">
    Descrição:</td>
<td>
    <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
        Width="200px"></asp:TextBox>
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