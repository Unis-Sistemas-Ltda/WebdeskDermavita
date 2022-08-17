<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem.ascx.vb" Inherits="WebdeskUnis.WUCNegociacaoItem" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .auto-style1 {
        width: 696px;
    }
    .auto-style2 {
        font-size: 10pt;
        font-weight: bold;
        text-align: left;
        color: #CC0000;
        width: 34px;
    }
    .auto-style3 {
        text-align: left;
        width: 34px;
    }
    .auto-style4 {
        width: 34px;
    }
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--<cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    
<table class="TextoCadastro_BGBranco" style="border-collapse: collapse" 
    width="100%">
    <tr>
        <td colspan="6" align="left" class="SubTituloMovimento">
            Item</td>
        <td align="left" class="auto-style4" style="padding: 5px">
            &nbsp;</td>
        <td align="left" class="SubTituloMovimento" 
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
            </td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblBaseIcmsSubstituicao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCNPJ" runat="server" Visible="False"></asp:Label>

        </td>
        <td class="auto-style2">
            &nbsp;</td>
        <td style="border-width: 1px; border-color: #DBDBDB; text-align: right; border-left-style: solid;">
            

        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblErro" runat="server"></asp:Label>

        </td>
        <td class="auto-style2">
            &nbsp;</td>
        <td align="left" rowspan="15" valign="top" 
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
           <table>
               <tr>
                   <td></td>
                   <td></td>
               </tr>
               <tr>
                   <td></td>
                   <td></td>
               </tr>
               <tr>
                   <td class="CelulaCampoCadastro" style="text-align: right"><asp:Label ID="Label4" runat="server" Text="Coloração:"></asp:Label></td>
                   <td><asp:DropDownList ID="DdlFdColoracao" runat="server" 
                CssClass="CampoCadastro" Width="383px">
                        <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                        <asp:ListItem Value="1">Incolor</asp:ListItem>
                        <asp:ListItem Value="2">Com Pigmento</asp:ListItem>
            </asp:DropDownList></td>
               </tr>
                <tr>
                   <td class="CelulaCampoCadastro" style="text-align: right"><asp:Label ID="Label6" runat="server" Text="Odor:"></asp:Label></td>
                   <td><asp:DropDownList ID="DdlFdOdor" runat="server" 
                CssClass="CampoCadastro" Width="383px">
                        <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                        <asp:ListItem Value="1">Inodoro</asp:ListItem>
                        <asp:ListItem Value="2">Sem adição de Fragrância</asp:ListItem>
                        <asp:ListItem Value="3">Com adição de Fragrância</asp:ListItem>
            </asp:DropDownList></td>
               </tr>
                <tr>
                   <td class="CelulaCampoCadastro" style="text-align: right"><asp:Label ID="Label10" runat="server" Text="Odor Direcionamento:"></asp:Label></td>
                   <td><asp:DropDownList ID="DdlFdOdorDirecionamento" runat="server" 
                CssClass="CampoCadastro" Width="383px">
                        <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                        <asp:ListItem Value="1">Doce</asp:ListItem>
                        <asp:ListItem Value="2">Floral</asp:ListItem>
                        <asp:ListItem Value="3">Frutal</asp:ListItem>
                        <asp:ListItem Value="4">Amadeirado</asp:ListItem>
                        <asp:ListItem Value="5">Suave</asp:ListItem>
            </asp:DropDownList></td>
               </tr>
               <tr>
                   <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label19" runat="server" Text="Nome do Produto:"></asp:Label>
        </td>
                  
                   <td> <asp:TextBox ID="TxtFdNomeProduto" runat="server" CssClass="CampoCadastro" 
                 Width="379px"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label18" runat="server" Text="Ação Desejada da Função:"></asp:Label>
        </td>
                  
                   <td> <asp:TextBox ID="TxtFdAcaoDesejadaProduto" runat="server" CssClass="CampoCadastro" 
                Height="40px" TextMode="MultiLine" Width="379px"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label20" runat="server" Text="Cor de referência:"></asp:Label>
        </td>
                  
                   <td> <asp:TextBox ID="TxtFdCorReferencia" runat="server" CssClass="CampoCadastro" 
                 Width="379px"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label21" runat="server" Text="Odor de referência:"></asp:Label>
        </td>
                  
                   <td> <asp:TextBox ID="TxtFdOdorReferencia" runat="server" CssClass="CampoCadastro" 
                 Width="379px"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label22" runat="server" Text="Descrição do Produto:"></asp:Label>
        </td>
                  
                   <td> <asp:TextBox ID="TxtFdDescricaoProduto" runat="server" CssClass="CampoCadastro" 
                Height="40px" TextMode="MultiLine" Width="379px"></asp:TextBox></td>
               </tr>
           </table>
        </td>
    </tr>
      <tr>
        <td colspan="6" align="left">
            <img alt="Detalhe do Item da Negociação" 
                src="../Imagens/DetalheItemNegociacao.png" style="width: 420px; height: 18px" /></td>

    </tr>
    <tr>
        <td style="width: 95px; text-align: right;">
            Seq. Item:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Item:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="90px" AutoPostBack="True" Enabled="false"></asp:TextBox>
                       

            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" 
                Height="17px"></asp:Label>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Referência:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlReferencia" runat="server" 
                CssClass="CampoCadastro" Width="383px" Enabled="false">
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="Narrativa:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                Height="40px" TextMode="MultiLine" Width="379px" Enabled="false"></asp:TextBox>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Natur. Oper:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" 
                Width="385px" AutoPostBack="True" Enabled="false">
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblEquipamento" runat="server" Text="Equipamento:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="auto-style1" 
                Width="300px" Height="16px" Enabled="false">
            </asp:DropDownList>
            <span>&nbsp;<asp:ImageButton ID="BtnIncluirEquipamento" runat="server" 
                AlternateText="Novo Equipamento" Height="16px" ToolTip="Incluir Equipamento" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=I','EditModalPopupClientes','IframeEdit');" 
                Enabled="True" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarEquipamento" runat="server" 
                AlternateText="Alterar equipamento" Height="16px" 
                ToolTip="Alterar informações do Equipamento" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=A','EditModalPopupClientes','IframeEdit');" 
                Enabled="True" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnPesquisarEquipamento" runat="server" 
                AlternateText="Pesquisar equipamento" Height="16px" 
                ToolTip="Pesquisar Equipamento" 
                ImageUrl="~/Imagens/search.png" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPEquipamento.aspx','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnPesquisarEquipamento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPesquisarEquipamento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: bottom">
            <asp:Label ID="Label15" runat="server" Height="16px" Text="Quantidade:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="77px">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px" Enabled="false"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" 
            style="vertical-align: bottom; text-align: right" width="70">
            <asp:Label ID="Label2" runat="server" Height="16px" 
                Text="Preço Unit.:" ToolTip="Preço unitário" Width="89px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="70">
            <asp:TextBox ID="TxtPrecoUnitario" runat="server" Width="75" 
                QtdCasas="4" AutoPostBack="True" Enabled="false" />
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right; vertical-align: bottom" width="55">
            <asp:Label ID="Label11" runat="server" Height="16px" Text="UD:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom">
          
        </td>
        <td class="auto-style3" style="vertical-align: bottom">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Qtde. UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQuantidadeUD" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"  Enabled="false"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Preço UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblValorUD" runat="server" Font-Bold="False" Text="0,0000" style="text-align:right"
                Width="77px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Desc.(R$):</td>
        <td class="CelulaCampoCadastro" width="77">
            <asp:TextBox ID="TxtValorDesconto2" runat="server" Width="75" 
                QtdCasas="2" AutoPostBack="True"  Enabled="false" />
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Entrega:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:TextBox ID="TxtPrazoEntrega" runat="server" CssClass="CampoCadastro" 
                style="margin-bottom: 0px" Width="30px"  Enabled="false"></asp:TextBox>
            <asp:DropDownList ID="DdlTpPrazoEntrega" runat="server"  Enabled="false"
                CssClass="CampoCadastro">
                <asp:ListItem Value="1">Dia(s)</asp:ListItem>
                <asp:ListItem Value="2">Mês(es)</asp:ListItem>
                <asp:ListItem Value="3">Ano(s)</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Vlr.&nbsp;Merc.:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:Label ID="Label12" runat="server" Text="R$" BorderStyle="None" 
                BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="False" style="text-align:right"
                BorderStyle="None" BorderWidth="1px" Width="90px">0,00</asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold; font-size: 7pt;">
            ICMS: 
            </td>
        <td class="CelulaCampoCadastro" colspan="5" style="font-size: 7pt">
            <asp:Label ID="Label16" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMS" runat="server" Font-Bold="False">0,0000</asp:Label>
            &nbsp;(<asp:Label ID="LblAliquotaICMS" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label8" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
            )<asp:Label ID="Label3" runat="server" Text="&nbsp;&nbsp;&nbsp;ST:" 
                Font-Bold="True"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="&nbsp;R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMSST" runat="server" Font-Bold="False">0,0000</asp:Label>
            <asp:Label ID="Label5" runat="server" Text="&nbsp;&nbsp;&nbsp;IPI:" 
                Font-Bold="True"></asp:Label>
            <asp:Label ID="Label17" runat="server" Text="&nbsp;R$"></asp:Label>
&nbsp;<asp:Label ID="LblIPI" runat="server" Font-Bold="False">0,0000</asp:Label>
            &nbsp;(<asp:Label ID="LblAliquotaIPI" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label9" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
            )</td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label13" runat="server" Text="Vlr. Total:" Font-Bold="True"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Label ID="Label14" runat="server" BackColor="#ECFFEC" 
                BorderColor="#CCFFFF" Text="R$" BorderStyle="Solid" BorderWidth="1px" 
                Font-Bold="True" Height="16px"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" Font-Size="8pt" 
                style="text-align:right; background-color: #ECFFEC;" Width="90px" 
                BorderColor="#CCFFFF" BorderStyle="Solid" BorderWidth="1px" 
                ForeColor="#535353" Height="16px">0,00</asp:Label>
        </td>
        <td class="auto-style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="5">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" 
                Width="60px" />
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    </table>