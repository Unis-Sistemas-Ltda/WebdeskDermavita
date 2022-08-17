<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFollowUPAtendimento.ascx.vb" Inherits="WebdeskUnis.WUCFollowUpAtendimento" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<link href="../Ajax.css" rel="stylesheet" type="text/css" />

<table style="width:100%; border-collapse: collapse;">
    <tr>
        <td colspan="2" style="font-weight: bold;">
            Incluir Comentário<asp:Label ID="LblErro" runat="server" CssClass="Erro" 
                Font-Bold="False"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodAtendimento" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="False" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 360px;">
            <asp:TextBox ID="TxtDescricao" runat="server" Height="95px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
        <td style="padding-left: 10px; text-align: left">
                                <asp:Label ID="LblAnex" runat="server" 
                Text="Se desejar, você pode anexar até 3 arquivos a este comentário:"></asp:Label>
                            <br />
                                <asp:FileUpload ID="FUAnexo1" runat="server" 
                                    Width="320px" CssClass="CampoCadastro" />
                                <br />
                                <asp:FileUpload ID="FUAnexo2" runat="server" CssClass="CampoCadastro" 
                                    Width="320px" />
                                <br />
                                <asp:FileUpload ID="FUAnexo3" runat="server" CssClass="CampoCadastro" 
                                    Width="320px" />
                                <br />
                                <asp:Label ID="LblMensagem" runat="server" Font-Size="7pt" ForeColor="#006600" 
                                    Height="23px" 
                                    
                                    
                                    Text="Formatos suportados:&lt;br/&gt;Imagens (PDF, PNG, JPG, GIF), Word (DOC, DOCX), PowerPoint (PPT, PPTX), Excel (XLS, XLSX)."></asp:Label>
        </td>
    </tr>
    </table>