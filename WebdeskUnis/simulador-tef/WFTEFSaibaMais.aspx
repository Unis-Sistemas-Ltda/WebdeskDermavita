<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTEFSaibaMais.aspx.vb" Inherits="WebdeskUnis.WFTEFSaibaMais" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    </head>
<body style="font-family: Verdana; font-size: 9pt;">
    <form id="form1" runat="server">
    <div class="TituloAnf">Convênio 
        <asp:Label ID="LblNomeConvenio2" runat="server" Text="Stone"></asp:Label>
        : Reduza seus custos com cartão de crédito/débito!</div>
    <div style="font-family: 'Trebuchet MS'; font-size: 10pt; padding-left: 10px; color: #333333;" >
        <table style="width: 700px">
        <tr>
        <td>
            <asp:Image ID="ImgLogoUnis" runat="server" ImageUrl="~/Imagens/unis.jpg" />
            </td>
        <td style="text-align: center">
            <asp:Image ID="ImgLogoStone" runat="server" 
            ImageUrl="~/Imagens/logo-stone.png" />
            </td>
        <td style="text-align: right">
            <asp:Image ID="ImgLogoCappta" runat="server" 
                ImageUrl="~/Imagens/logo-cappta.png" />
            </td>
        </tr>
        </table>
        Prezado associado
        <asp:Label ID="LblNome" runat="server"></asp:Label>
        ,<br>
<br>
Seguem&nbsp;abaixo as condições comerciais do Convênio 
        <asp:Label ID="LblNomeConvenio1" runat="server" Text="STONE"></asp:Label>
        , exclusivas para você que é associado
        <asp:Label ID="LblNomeGrupo" runat="server" Font-Bold="True"></asp:Label>
        .<br>
<p style="border: 1px solid #EEEEEE; padding: 10px; width: 320px; background-color: #F4F4FF; margin-left: 15px;"><b>Taxas 
    do convênio para cartão de crédito/débito*:</b>
<br>
Débito - 
        <asp:Label ID="LblTaxaDebito" runat="server" Font-Bold="True" Text="0,00" 
            Font-Size="11pt" ForeColor="Black"></asp:Label>
        %<br>
Crédito à vista - <b>
        <asp:Label ID="LblTaxaCreditoAVista" runat="server" Font-Bold="True" 
            Text="0,00" Font-Size="11pt" ForeColor="Black"></asp:Label>
        %</b><br>
Parcelado de 2 a 6 vezes -
        <asp:Label ID="LblTaxaParcelado2a6" runat="server" Font-Bold="True" Text="0,00" 
            Font-Size="11pt" ForeColor="Black"></asp:Label>
        %<br />
Parcelado de 7 a 12 vezes -
        <asp:Label ID="LblTaxaParcelado7a12" runat="server" Font-Bold="True" 
            Text="0,00" Font-Size="11pt" ForeColor="Black"></asp:Label>
        %<br />
    <asp:Label ID="LblAntAuto" runat="server" 
        Text="Antecipação de Parcelas Automática - "></asp:Label>
        <asp:Label ID="LblTaxaAntecipacaoAutomatica" runat="server" Font-Bold="True" 
            Text="0,00%" Font-Size="11pt" ForeColor="Black"></asp:Label>
        <br />
    <asp:Label ID="LblAntPontual" runat="server" 
        Text="Antecipação de Parcelas Pontual - "></asp:Label>
        <asp:Label ID="LblTaxaAntecipacaoPontual" runat="server" Font-Bold="True" 
            Text="0,00%" Font-Size="11pt" ForeColor="Black"></asp:Label>
        <br />
    <br />
    *Taxas válidas para bandeiras
    <asp:Label ID="LblBandeirasTaxa" runat="server" Text="Visa e Mastercard."></asp:Label>
    <br /></p>
<p style="border: 1px solid #EEEEEE; padding: 10px; width: 320px; background-color: #F4F4FF; margin-left: 15px; ">
Simule sua economia, clicando no link abaixo:<br />
        <asp:LinkButton ID="BtnSimulador" runat="server" Font-Bold="True">Simulador</asp:LinkButton>
        </p>
Serviço de Transação Eletrônica de Fundos, TEF/PBM - Solução TEF:
<br>
Mensalidade do equipamento (até 2 PDV): 
        <b>R$ 
        <asp:Label ID="LblMensalidadeEquipamento" runat="server" Text="0,00"></asp:Label>
        .</b><br>
        <br />
        Clique
        <asp:HyperLink ID="BtnAnexo3" runat="server" Font-Bold="True" 
            Font-Underline="True" Target="_blank">aqui</asp:HyperLink>
        &nbsp;e conheça os benefícios do TEF.<br />
        <p style="border: 1px solid #EEEEEE; padding: 10px; width: 320px; background-color: #F4F4FF; margin-left: 15px; ">
Conheça nosso portal de Gerenciamento de Vendas, clicando no link abaixo:
            <br />
        <asp:LinkButton ID="BtnPortal" runat="server" Font-Bold="True">Portal</asp:LinkButton>
        </p>
        <p style="border: 1px solid #EEEEEE; padding: 10px; width: 320px; background-color: #F4F4FF; margin-left: 15px; ">
Faça sua adesão ao Convênio 
            <asp:Label ID="LblNomeConvenio3" runat="server" Text="STONE"></asp:Label>
            , clicando no link abaixo:<br />
        <asp:LinkButton ID="BtnAderir" runat="server" Font-Bold="True">Aderir</asp:LinkButton>
        </p>
        Saiba mais sobre a Unis Sistemas, clicando
        <asp:HyperLink ID="BtnAnexo1" runat="server" Font-Bold="True" 
            Font-Underline="True" Target="_blank">aqui.</asp:HyperLink>
        <br />
        <br />
        Para saber mais sobre o TEF, clique
        <asp:HyperLink ID="BtnAnexo2" runat="server" Font-Bold="True" 
            Font-Underline="True" Target="_blank">aqui.</asp:HyperLink>
        <br />
        <br />
        Confira mais detalhes das condições comerciais do Convênio 
        <asp:Label ID="LblNomeConvenio4" runat="server" Text="STONE"></asp:Label>
        , clicando
        <asp:HyperLink ID="BtnAnexo4" runat="server" Font-Bold="True" 
            Font-Underline="True" Target="_blank">aqui.</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="LblRodapePagina" runat="server" 
            Text="Caso tenha alguma dúvida, entre em contato conosco pelo e-mail comercial@unisnet.com.br ou pelo telefone (48) 3664-3000. Estamos à sua disposição.<br><br>Atenciosamente,<br><br>Departamento Comercial<br><b>UNIS SISTEMAS</b><br>Rua Santa Luzia, 100<br>Ed. The Place Office - Salas 706, 707 e 713<br>Trindade - Florianópolis - SC - CEP 88036-540<br><br><b>Fone: (48) 3664-3000<br>E-mail: comercial@unisnet.com.br</b><br>"></asp:Label>
        <a target="_blank" href="http://www.unisnet.com.br"</a>www.unisnet.com.br</a><br />
        <a target="_blank" href="http://www.unisnet.com.br"</a><br/>
</div>
</form>
</body>
</html>
