<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFSimulador02.aspx.vb" Inherits="WebdeskUnis.WFSimulador02" %>

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
                <td colspan="3" 
                    
                    
                    
                    
                    
                    style="text-align: left; font-weight: normal; font-size: 15px; font-family: Arial; color: #EEEEEE; line-height: 17px;">
                    <asp:Label ID="Label12" runat="server" 
                        
                        Text="SIMULE QUANTO VOCÊ GANHA AO ADERIR AO CONVÊNIO TEF" 
                        Height="25px" BackColor="#4E739C" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="LblNomeConveino" runat="server" Font-Bold="True" 
                        Height="25px"></asp:Label>
                    </td>
                <td colspan="3" 
                    
                    
                    
                    
                    style="text-align: right; vertical-align: top; padding-right: 15px;" 
                    rowspan="3">
                    <asp:Image ID="ImgLogo" runat="server" Height="65px" Width="180px" />
                    </td>
            </tr>
            <tr>
                <td colspan="3" 
                    
                    
                    
                    style="padding: 2px; text-align: left; font-size: 9pt; color: #EEEEEE; line-height: 25px;">
                    Negociamos taxas especiais para você.</td>
            </tr>
            <tr>
                <td colspan="3" 
                    class="Erro">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" 
                    
                    
                    
                    style="padding: 2px; text-align: left; font-size: 9pt; color: #EEEEEE; line-height: 25px;">
                    <table style="width: 100%; border-collapse: collapse; height: 396px;">
                        <tr>
                            <td style="background-image: url('../Imagens/Barra-Lateral-Esquerda-2.png'); background-repeat: no-repeat; width: 26px;">
                                &nbsp;</td>
                            <td style="background-image: url('../Imagens/Barra-Central-Fundo-2.png'); background-repeat: repeat-x;">
                                <table style="width: 100%; text-align: right; line-height: 15px; font-size: 9pt; font-family: 'Trebuchet MS';">
                                    <tr>
                                        <td colspan="8" style="line-height: 9px">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    Situação Atual</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    Valor</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    Taxa Atual</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    Custos Mensais Atuais</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    &nbsp;</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    &nbsp;</td>
                <td style="border-width: 1px; border-color: #C0C0C0; font-weight: bold; border-bottom-style: solid; color: #000099;">
                    &nbsp;</td>
                                        <td rowspan="10" 
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            style="text-align: right; width: 235px; background-image: url('../Imagens/Relogio-Economia.png'); background-repeat: no-repeat; font-size: 10pt; font-family: Arial, Helvetica, sans-serif;">
                                            <br />
                                            <asp:Label ID="LblEconomiaFinal" runat="server" Font-Bold="True" 
                                                Font-Names="Tahoma" Font-Size="17pt" ForeColor="#333333" Text="2.592" 
                                                Font-Underline="False"></asp:Label>
                                            <asp:Label ID="Label14" runat="server" Text="&nbsp;" Width="96px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                <td style="color: #333333">
                    Vendas - Cartão de Crédito:</td>
                <td style="color: #333333;">
                    R$
                    <asp:Label ID="LblFaturamentoMensalCartaoCredito01" runat="server" 
                        Text="12.000,00"></asp:Label>
                </td>
                <td style="color: #333333;">
                    <asp:Label ID="TxtTaxaAtualCartaoCredito" runat="server" Text="3,60"></asp:Label>
                    %</td>
                <td style="color: #333333;">
                    R$
                    
                    <asp:Label ID="LblCustoAtualCartaoCredito" runat="server"  Text="432,00" 
                        Font-Bold="False"></asp:Label>
                </td>
                <td style="color: #333333;">
                    &nbsp;</td>
                <td style="color: #333333;">
                    &nbsp;</td>
                <td style="color: #333333;">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="color: #333333">
                    Vendas - Cartão de Débito:</td>
                <td style="color: #333333;">
                    R$
                    <asp:Label ID="LblFaturamentoMensalCartaoDebito01" runat="server" 
                        Text="3.000,00"></asp:Label>
                </td>
                <td style="color: #333333;">
                    <asp:Label ID="TxtTaxaAtualCartaoDebito" runat="server" Text="2,50"></asp:Label>
                    %</td>
                <td style="color: #333333;">
                    R$
                    <asp:Label ID="LblCustoAtualCartaoDebito" runat="server"  Text="75,00" 
                        Font-Bold="False"></asp:Label>
                </td>
                <td style="color: #333333;">
                    &nbsp;</td>
                <td style="color: #333333;">
                    &nbsp;</td>
                <td style="color: #333333;">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="color: #333333">
                    Venda Total - Cartões:</td>
                <td style="color: #333333;">
                    R$
                    <asp:Label ID="LblFaturamentoTotalCartoes01" runat="server"  Text="15.000,00"></asp:Label>
                </td>
                <td style="color: #333333;">
                    Total:&nbsp;&nbsp;</td>
                <td style="color: #333333; ">
                    R$
                    <asp:Label ID="LblCustoTotalSituacaoAtual" runat="server"  Text="507,00" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="border-style: none; border-width: 0px; padding: 0px; margin: 0px; font-size: 6px; line-height: 4px;" 
                                            colspan="6">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                                        </td>
                <td style="border-style: none; border-width: 0px; padding: 0px; margin: 0px; font-size: 6px; line-height: 4px;">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="border-style: none; font-weight: bold; color: #000099; ">
                    &nbsp;</td>
                <td style="border-style: none; border-width: 1px; border-color: #C0C0C0; font-weight: bold; color: #000099; ">
                    Valor</td>
                <td style="border-style: none; border-width: 1px; border-color: #C0C0C0; font-weight: bold; color: #000099; ">
                    Taxa Convênio</td>
                <td style="border: 1px none #C0C0C0; font-weight: bold; color: #000099; ">
                    Custos Mensais</td>
                <td style="border: 1px none #C0C0C0; font-weight: bold; color: #000099; ">
                    Economia Mensal</td>
                <td style="border: 1px none #C0C0C0; font-weight: bold; color: #000099; ">
                    Economia Anual</td>
                <td style="border: 1px none #C0C0C0; font-weight: bold; color: #000099; ">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="color: #000099; ">Vendas - Cartão de Crédito:</td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblFaturamentoMensalCartaoCredito02" runat="server"  
                        Text="12.000,00"></asp:Label>
                </td>
                <td style="color: #000099; ">
                    <asp:Label ID="LblTaxaCartaoCreditoConvenio" runat="server"  Text="2,10"></asp:Label>
                    %</td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblCustoConvenioCartaoCredito" runat="server"  Text="252,00" 
                        Font-Bold="False"></asp:Label>
                </td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalConvenioCredito" runat="server"  Text="180,00" 
                        Font-Bold="False"></asp:Label>
                                        </td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualConvenioCredito" runat="server"  Text="2.160,00" 
                        Font-Bold="False"></asp:Label>
                                        </td>
                <td style="color: #000099; ">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="color: #000099; ">
                    Vendas - Cartão de Débito:</td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblFaturamentoMensalCartaoDebito02" runat="server"  
                        Text="3.000,00"></asp:Label>
                </td>
                <td style="color: #000099; ">
                    <asp:Label ID="LblTaxaCartaoDebitoConvenio" runat="server"  Text="1,30"></asp:Label>
                    %</td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblCustoConvenioCartaoDebito" runat="server"  Text="39,00" 
                        Font-Bold="False"></asp:Label>
                </td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalConvenioDebito" runat="server"  Text="36,00" 
                        Font-Bold="False"></asp:Label>
                                        </td>
                <td style="color: #000099; ">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualConvenioDebito" runat="server"  Text="432,00" 
                        Font-Bold="False"></asp:Label>
                                        </td>
                <td style="color: #000099; ">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="color: #333333; border: 1px none #C0C0C0; color: #000099; ">
                    Venda Total - Cartões:</td>
                <td style="color: #333333; border: 1px none #C0C0C0; color: #000099; ">
                    R$
                    <asp:Label ID="LblFaturamentoTotalCartoes02" runat="server"  Text="15.000,00"></asp:Label>
                </td>
                <td style="border: 1px none #C0C0C0; color: #000099; ">
                    Total:&nbsp;&nbsp;</td>
                <td style="border: 1px none #CCCCCC; color: #000099; font-size: 10pt;">
                    R$
                    <asp:Label ID="LblCustoTotalParceriaConvenio" runat="server"  Text="291,00" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px none #CCCCCC; color: #000099; font-size: 10pt;">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalConvenioFinal" runat="server"  Text="216,00" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px none #CCCCCC; color: #000099; font-size: 10pt;">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualConvenioFinal" runat="server"  
                        Text="2.592,00" Font-Bold="True"></asp:Label>
                </td>
                <td style="border: 1px none #CCCCCC; color: #000099; font-size: 10pt;">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td style="border-style: none; border-width: 0px; padding: 0px; margin: 0px; font-size: 6px; line-height: 4px;" 
                                            colspan="6">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                                        </td>
                <td style="border-style: none; border-width: 0px; padding: 0px; margin: 0px; font-size: 6px; line-height: 4px;">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td colspan="8" style="line-height: 6px">
                    &nbsp;</td>
                                    </tr>
                                    <tr>
                <td colspan="6" style="text-align: left; color: #666666;">
                    <asp:Label ID="LblMensagemConvenio" runat="server"></asp:Label>
                                        </td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td colspan="1">
                    <asp:ImageButton ID="ImageButton3" runat="server" 
                        ImageUrl="~/Imagens/Nova-Simulacao.png" />
                                        </td>
                                    </tr>
                                    <tr>
                <td colspan="8" style="text-align: center; " class="Erro">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                    <br />
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td style="background-image: url('../Imagens/Barra-Lateral-Direita-2.png'); background-repeat: no-repeat; width: 26px;">
                                &nbsp;</td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr>
                <td style="color: #333333; visibility: hidden;">
                    Adesão Maquininha:</td>
                <td style="color: #333333; visibility: hidden;">
                    R$
                    <asp:Label ID="TxtTaxaAdesaoMaquininhaAtual" runat="server"  
                        Text="150,00"></asp:Label>
                </td>
                <td style="color: #333333; visibility: hidden;" colspan="2">
                    R$
                    <asp:Label ID="LblValorDespesaAdesaoMaquininhaConvenio" runat="server"  
                        Text="0,00"></asp:Label>
                </td>
                <td style="background-color: #F6F6FE; visibility: hidden;" colspan="1">
                    &nbsp;</td>
                <td style="background-color: #FFF5F5; color: #000099; visibility: hidden;">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualAdesaoMaquininha" runat="server"  
                        Text="150,00" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="color: #333333; visibility: hidden;">
                    Aluguel Mensal Maquininha:</td>
                <td style="color: #333333; visibility: hidden;">
                    R$
                    <asp:Label ID="TxtValorAluguelMensalMaquininhaAtual" runat="server"  
                        Text="95,00"></asp:Label>
                </td>
                <td style="color: #333333; visibility: hidden;" colspan="2">
                    R$
                    <asp:Label ID="LblValorDespesaAluguelMensalMaquininhaConvenio" runat="server"  
                        Text="60,00"></asp:Label>
                    *</td>
                <td style="background-color: #F6F6FE; color: #000099; visibility: hidden;">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalAluguelMaquininha" runat="server"  
                        Text="35,00" Font-Bold="False"></asp:Label>
                </td>
                <td style="background-color: #FFF5F5; color: #000099; visibility: hidden;">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualAluguelMaquininha" runat="server"  
                        Text="420,00" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="color: #333333; visibility: hidden;">
                    Pacote Serviços de C/C:</td>
                <td style="color: #333333; visibility: hidden;">
                    R$
                    <asp:Label ID="TxtValorPacoteContaCorrenteAtual" runat="server"  
                        Text="65,00"></asp:Label>
                </td>
                <td style="color: #333333; visibility: hidden;" colspan="2">
                    R$
                    <asp:Label ID="LblValorDespesaPacoteContaCorrenteConvenio" runat="server"  
                        Text="0,00"></asp:Label>
                </td>
                <td style="background-color: #F6F6FE; color: #000099; visibility: hidden;" 
                    colspan="1">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalPacoteContaCorrente" runat="server"  
                        Text="65,00" Font-Bold="False"></asp:Label>
                </td>
                <td style="background-color: #FFF5F5; color: #000099; visibility: hidden;">
                    R$ 
                    <asp:Label ID="LblValorEconomiaAnualPacoteContaCorrente" runat="server"  
                        Text="780,00" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="color: #333333; visibility: hidden;">
                    Linha Discada:</td>
                <td style="color: #333333; visibility: hidden;">
                    R$
                    <asp:Label ID="TxtValorLinhaDiscadaAtual" runat="server"  
                        Text="200,00"></asp:Label>
                </td>
                <td style="color: #333333; visibility: hidden;" colspan="2">
                    R$
                    <asp:Label ID="LblValorDespesaLinhaDiscadaConvenio" runat="server"  
                        Text="0,00"></asp:Label>
                </td>
                <td style="background-color: #F6F6FE; color: #000099; visibility: hidden;" 
                    colspan="1">
                    R$
                    <asp:Label ID="LblValorEconomiaMensalLinhaDiscada" runat="server"  
                        Text="200,00" Font-Bold="False"></asp:Label>
                </td>
                <td style="background-color: #FFF5F5; color: #000099; visibility: hidden;">
                    R$
                    <asp:Label ID="LblValorEconomiaAnualLinhaDiscada" runat="server"  
                        Text="2.400,00" Font-Bold="False"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>

    </form>
</body>
</html>
