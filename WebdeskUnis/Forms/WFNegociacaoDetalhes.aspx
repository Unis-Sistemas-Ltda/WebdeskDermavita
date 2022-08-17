<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoDetalhes.aspx.vb" Inherits="WebdeskUnis.WFNegociacaoDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td class="TituloMovimento" id="tdTitulo" runat="server">
                        Detalhe da Proposta</td>
            </tr>
            <tr>
                <td style="padding: 0px; margin: 0px; border-style: solid none solid none; border-width: 1px; border-color: #CCCCCC; width: 100%; ">
                    <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                            Font-Size="8pt" Font-Underline="False" RenderingMode="List">
                        <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                        <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                            Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                        <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                            HorizontalPadding="5px" VerticalPadding="5px" />
                        <Items>

                            <asp:MenuItem Selected="True" Text="Proposta" Value="WFNegociacaoCabecalho.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Itens" Value="WGNegociacaoItem.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Outras Informações" Value="WFNegociacaoOutrasInformacoes.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Histórico" Value="WGNegociacaoHistorico.aspx"></asp:MenuItem>                            
                            <asp:MenuItem Text="Despesas Acessórias" Value="WGNegociacaoDespesa.aspx"></asp:MenuItem> 
                        </Items>
                    </asp:Menu>
                </td>
            </tr>            
            <tr>
                <td style="width: 50%; height: calc(100vh - 85px)">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" /></td>
            </tr>           
            </table>
    </div>
    </form>
</body>
</html>
