<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFSimulador.aspx.vb" Inherits="WebdeskUnis.WFSimulador" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 10px; margin: 7px; color: #EEEEEE; background-color: #4E739C;">
    
        <table style="width:100%; font-size: 9pt; text-align: right; border-collapse: collapse;">
            <tr>
                <td style="text-align: left; font-weight: normal; font-size: 15px; font-family: Arial; color: #EEEEEE; line-height: 17px; background-color: #4E739C;">
                    <asp:Label ID="Label12" runat="server" 
                        Text="SIMULE QUANTO VOCÊ GANHA AO ADERIR AO CONVÊNIO TEF" 
                        Height="25px" BackColor="#4E739C" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="LblNomeConvenio" runat="server" Font-Bold="True" 
                        Height="25px"></asp:Label>
                    </td>
                    
                <td style="text-align: right; vertical-align: top; padding-right: 15px;" 
                    rowspan="3">
                    <asp:Image ID="ImgLogo" runat="server" Height="65px" Width="180px" />
                    </td>
                    
            </tr>
            <tr>
                <td style="padding: 2px; text-align: left; font-size: 9pt; color: #EEEEEE; line-height: 25px;">
                    Negociamos taxas especiais para você.<br />
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%; border-collapse: collapse; height: 369px;">
                        <tr>
                            <td style="background-image: url('../Imagens/Barra-Lateral-Esquerda.png'); background-repeat: no-repeat; width: 26px;">
                                &nbsp;</td>
                            <td style="background-image: url('../Imagens/Barra-Central-Fundo.png'); background-repeat: repeat-x;">
                                <table style="width: 100%; border-collapse: collapse; font-family: 'Trebuchet MS';">
                                    <tr>
                                        <td class="Erro" colspan="2" style="text-align: left; padding: 0px">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                                        </td>
                                        <td rowspan="9" style="text-align: center; width: 278px">
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="~/Imagens/Relogio-Economia.png" 
                                                onclientclick="return false;" />
                                            <br />
                                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                                ImageUrl="~/Imagens/Calcular-Economia.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left; color: #999999;">
                    Preencha os campos abaixo 
                                            ou os altere de acordo com a sua realidade:</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: #333333">
                    Vendas - Cartão de Crédito (R$/mês):</td>
                                        <td style="color: #333333; text-align: left;">
                    <asp:TextBox ID="TxtFaturamentoMensalCartaoCredito" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px">12.000,00</asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Height="25px" 
                        Text="&nbsp;&nbsp;Sua taxa atual (%):"></asp:Label>
                    <asp:TextBox ID="TxtTaxaAtualCartaoCredito" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px">3,60</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: #333333">
                    Vendas - Cartão de Débito (R$/mês):</td>
                                        <td style="color: #333333; text-align: left;">
                    <asp:TextBox ID="TxtFaturamentoMensalCartaoDebito" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px">3.000,00</asp:TextBox>
                    <asp:Label ID="Label11" runat="server" Height="25px" 
                        Text="&nbsp;&nbsp;Sua taxa atual (%):"></asp:Label>
                    <asp:TextBox ID="TxtTaxaAtualCartaoDebito" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px">2,50</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td style="background-image: url('../Imagens/Barra-Lateral-Direita.png'); background-repeat: no-repeat; width: 26px;">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; font-size: 7pt" colspan="2">
                    <asp:TextBox ID="TxtTaxaAdesaoMaquininhaAtual" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <asp:TextBox ID="TxtValorAluguelMensalMaquininhaAtual" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <asp:TextBox ID="TxtValorPacoteContaCorrenteAtual" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <asp:TextBox ID="TxtValorLinhaDiscadaAtual" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <asp:TextBox ID="TxtAntecipacaoMensalRecebiveis" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <asp:TextBox ID="TxtTaxaAtualAntecipacaoRecebiveis" runat="server" 
                        CssClass="TextoCadastro" Style="text-align:right" Width="90px" 
                        Visible="False">0,00</asp:TextBox>
                    <br />
                    </td>
                <td colspan="1" style="vertical-align: top">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
