<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSolicitacaoDesenvolvimento.ascx.vb" Inherits="WebdeskUnis.WUCSolicitacaoDesenvolvimento" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../JSUnis.js"></script>

<body  class="TextoCadastro_BGBranco">

<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td class="TituloMovimento" colspan="4">
            Cadastro de Solicitações</td>
    </tr>
    <tr>
        <td class="Erro" colspan="3">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
        <td height="400" style="border: 1px solid #CCCCCC" width="35%" rowspan="14">
            <uc2:WUCFrame ID="WUCFrame1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodSolicitacao" runat="server" Font-Bold="True" Height="16px"></asp:Label>
        &nbsp;
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Origem:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlOrigem" runat="server" CssClass="CampoCadastro" 
                Width="150px" Enabled="False">
                <asp:ListItem Value="1">Analista</asp:ListItem>
                <asp:ListItem Value="2">Cliente</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Height="17px" style="text-align: right"
                Text="Solicitação:" Width="75px"></asp:Label>
            <asp:TextBox ID="txtDataSolicitacao" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Height="17px" style="text-align: right"
                Text="Entrega Prevista:" Width="105px"></asp:Label>
            <asp:TextBox ID="txtDataEntregaPrevista" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Analista:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="500px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cliente:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" 
                Width="50px" Enabled="False"></asp:TextBox>
            &nbsp;<asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True" Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Sistema:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlSistema" runat="server" CssClass="CampoCadastro" 
                Width="500px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Assunto:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Descrição da Solicitação:</td>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="110px" TextMode="MultiLine" Width="500px" Font-Names="Courier New" 
                Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Regras de Negócio (opcional):</td>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtRegraNegocio" runat="server" CssClass="CampoCadastro" 
                Height="35px" TextMode="MultiLine" Width="500px" Font-Names="Courier New" 
                Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Urgência:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlUrgencia" runat="server" CssClass="CampoCadastro" 
                Width="100px">
                <asp:ListItem Selected="True" Value="0">Baixa</asp:ListItem>
                <asp:ListItem Value="1">Média</asp:ListItem>
                <asp:ListItem Value="2">Alta</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="Label2" runat="server" Height="17px" style="text-align: right"
                Text="Próxima visita do consultor:&nbsp;" Width="167px"></asp:Label>
            
            <asp:TextBox ID="TxtProximaVisita" runat="server" CssClass="CampoCadastro" 
                Enabled="False" MaxLength="10" Width="75px"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Situação:</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;<asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="200px" Enabled="False" EnableTheming="True">
                <asp:ListItem Selected="True" Value="0">Solicitado</asp:ListItem>
                <asp:ListItem Value="1">Em desenvolvimento</asp:ListItem>
                <asp:ListItem Value="2">Desenvolvimento Finalizado</asp:ListItem>
                <asp:ListItem Value="3">Entregue/Atualizado</asp:ListItem>
                <asp:ListItem Value="4">Analisado [Aguardando Agendamento]</asp:ListItem>
                <asp:ListItem Value="5">Aguardando aprovação do cliente [Desenvolvimento com custo]</asp:ListItem>
                <asp:ListItem Value="6">Desenvolvimento agendado</asp:ListItem>
                <asp:ListItem Value="7">Desenvolvimento cancelado</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Height="17px" style="text-align: right"
                Text="Seq. Prioridade:&nbsp;" Width="167px"></asp:Label>
            
            <asp:TextBox ID="TxtSeqPrioridade" runat="server" CssClass="CampoCadastro" 
                Width="75px"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkPrazoObrigatorio" runat="server" Text=" " 
                Visible="False" />
            <asp:TextBox ID="txtPrazoObrigatorio" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px" Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" rowspan="1">
            <asp:CheckBox ID="ChkClienteAprovar" runat="server" Visible="False" />
            <br />
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar solicitação" 
                Visible="False" />
        </td>
    </tr>
    </table>
</body>