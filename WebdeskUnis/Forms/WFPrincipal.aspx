<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPrincipal.aspx.vb" Inherits="WebdeskUnis.WFPrincipal" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="width: 100%; height: 100%">
<head runat="server">
    <title>WebDesk Grupo Dermavita & Planters</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <style>
       .adjustedZIndex
       {
        z-index: 1;
        }
    </style>

</head>
<body id="body1" runat="server" style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 530px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="width: 100%; height: 100%">
    
    <table style="margin: 0px; width: 100%; height:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;">
        <tr>
            <td>
                <table style="width:100%; border-collapse: collapse;">
                    <tr>
                        <td rowspan="2" style="width: 70px; background-color: #F9FBFB;">
                            <img alt="Grupo Dermavita & Planters" src="../Imagens/logo-cliente.png" 
                                style="height: 57px" /></td>
                        <td style="text-align: left; background-color: #F9FBFB;">
                            <asp:Label ID="LblRazaoSocial" runat="server" CssClass="CampoCadastro"></asp:Label>
                        </td>
                        <td style="text-align: left; background-color: #F9FBFB;" class="CampoCadastro" >
                            <asp:Label ID="LblBoasVindas" runat="server"></asp:Label>
                        </td>
                        <td rowspan="2" style="width: 70px; background-color: #F9FBFB;">
                            <img alt="Grupo Dermavita & Planters" src="../Imagens/logo-cliente-2.png" 
                                style="height: 57px" /></td>
                        <td style="text-align: center; background-color: #F4FFFF; width: 230px;" 
                            rowspan="2">
                            <asp:Label ID="LblNomeUsuario" runat="server" CssClass="CampoCadastro"></asp:Label>
                            <br />
                            <asp:Label ID="LblTpPessoa" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="LblCNPJ" runat="server"></asp:Label>
                            <br />
                            E-mail:
                            <asp:Label ID="LblEmail" runat="server"></asp:Label>
&nbsp;<br />
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/WFDesconectar.aspx">Desconectar-se</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: bottom; background-color: #F9FBFB; padding-left: 10px;" class="CampoCadastro" 
                            colspan="2">
                            <asp:Menu ID="MnuPrincipal" runat="server" Orientation="Horizontal" 
                                Font-Size="10pt" ForeColor="#7C6F57" 
                                CssClass="adjustedZIndex" BackColor="#F9FBFB" DynamicHorizontalOffset="2" 
                                StaticSubMenuIndent="10px" RenderingMode="List">
                                <StaticMenuStyle CssClass="ajustedZIndex" />
                                <StaticHoverStyle ForeColor="White" BackColor="#4080BF" />
                                <StaticSelectedStyle BackColor="#D7E7EA"/>
                                <StaticMenuItemStyle ForeColor="#333333" VerticalPadding="11px" HorizontalPadding="30px" />
                                <DynamicMenuStyle CssClass="adjustedZIndex"/>
                                <DynamicHoverStyle ForeColor="Black" BackColor="#D7E7EA"/>
                                <DynamicSelectedStyle ForeColor="#333333" BackColor="#D7E7EA" />
                                <DynamicMenuItemStyle ForeColor="#333333" VerticalPadding="7px" HorizontalPadding="28px" BackColor="White" />
                                
                                <Items>
                                    <asp:MenuItem Text="Chamados" Value="WGAtendimento.aspx">
                                    </asp:MenuItem>
                                    <asp:MenuItem Text="Desenvolvimentos" Value="WGSolicitacaoDesenvolvimento.aspx">
                                    </asp:MenuItem>
                                    <asp:MenuItem Text="Propostas" Value="WGPropostas.aspx"></asp:MenuItem>
                                    <asp:MenuItem Text="Financeiro" Value="WGTitulo.aspx"></asp:MenuItem>
                                    <asp:MenuItem Text="Agendamento" Value="WFAgendamentoAcademia.aspx">
                                    </asp:MenuItem>
                                    <asp:MenuItem Selectable="False" Text="Configurações&nbsp;&nbsp;&nbsp;&nbsp;" Value="Configurações">
                                        <asp:MenuItem Text="Login" Value="WFConfiguracaoLogin.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Dados Cadastrais" Value="WGDadosCadastrais.aspx"></asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text="Ajuda&nbsp;&nbsp;&nbsp;&nbsp;" Value="Ajuda" 
                                        Selectable="False">
                                        <asp:MenuItem Text="Dúvidas Frequentes" Value="WGFAQ.aspx">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="Manuais e Vídeos" 
                                            Value="WGManual.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="Repositório de Arquivos" 
                                            Value="WGDownloads.aspx"></asp:MenuItem>
                                    </asp:MenuItem>
                                    <asp:MenuItem Text="Admin&nbsp;&nbsp;&nbsp;&nbsp;" Value="Admin" Selectable="False">
                                        <asp:MenuItem Text="Cadastro de Turma" Value="WGTurma.aspx"></asp:MenuItem>
                                    </asp:MenuItem>
                                </Items>
                            </asp:Menu>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 100%">
            <td style="border-style: solid none none none; border-width: 1px; border-color: #F7F7F7; margin: 0px; width: 100%; height: 86%">
                <uc1:WUCFrame ID="FrameConteudo" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="border-style: solid none none none; border-width: 1px; border-color: #CCCCCC; text-align: center;">
                Desenvolvido por&nbsp; 
                <b>
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="http://www.unisnet.com.br" Target="_blank">UNIS SISTEMAS</asp:HyperLink>
                &nbsp;www.unissistemas.com -
                </b>Rua Santa Luzia, 100 - Ed. The Place Office, Salas 706, 707 
                e 713 - Trindade - 
                Florianópolis - SC</td>
	    </tr>
        </table>
    
    </form>
</body>
</html>
