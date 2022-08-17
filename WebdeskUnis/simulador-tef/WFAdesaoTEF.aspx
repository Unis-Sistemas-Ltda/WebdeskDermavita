<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAdesaoTEF.aspx.vb" Inherits="WebdeskUnis.WFAdesaoTEF" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 126px;
            height: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="Cadastro" 
        style="width:100%; font-size: 9pt; color: #333333; border-collapse: collapse;">
        <tr>
            <td class="Titulo" colspan="2" style="text-align: center">
                <img alt="Unis Sistemas" class="style1" src="../Imagens/unis.jpg" /><br />
                Convênio TEF - Adesão <asp:ScriptManager 
                    ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="Erro" colspan="2" style="font-size: 8pt">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="SubTitulo" 
                style="width: 100%; font-size: 10pt; background-color: #F2FFFF;">
                1ª Etapa - 
                Informe os dados do responsável pela empresa e do contato principal</td>
            <td style="width: 100%; background-color: #F2FFFF;">
                <asp:Label ID="LblSitEtapa1" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Razão Social:" 
                    Style="text-align: right" Width="115px"></asp:Label>
                <asp:Label ID="LblNomeFarmacia" runat="server" CssClass="TextoCadastro" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label10" runat="server" Text="Responsável:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtNomeResponsavel" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label11" runat="server" Text="Data Nascimento:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtDataNascimento" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <cc1:MaskedEditExtender ID="TxtDataNascimento_MaskedEditExtender" 
                    runat="server" BehaviorID="TxtDataNascimento_MaskedEditExtender" Century="2000" 
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="TxtDataNascimento" 
                    UserDateFormat="DayMonthYear">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label12" runat="server" Text="CPF:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtCPF" runat="server" CssClass="TextoCadastro" 
                    MaxLength="14" Width="95px"></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Text="&nbsp;RG:&nbsp;" 
                    Style="text-align: right" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtRG" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="91px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Pessoa Contato:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtNomeContato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Telefone(s):" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtFone1Contato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="&nbsp;&nbsp;e&nbsp;&nbsp;" 
                    Style="text-align: right" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtFone2Contato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text=" Ex: (11) 1234-5678" 
                    Height="17px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="E-mail de contato:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtEmailContato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:Button ID="BtnConfirmarDadosContato" runat="server" 
                    Text="Confirmar dados acima" Width="200px" CssClass="Botao" 
                    Font-Size="9pt" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%"><tr><td class="SubTitulo" 
                style="width: 100%; font-size: 10pt; background-color: #F2FFFF;">
                2ª Etapa - 
                Escolha as lojas/unidades</td>
            <td style="width: 100%; background-color: #F2FFFF;">
                <asp:Label ID="LblSitEtapa2" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Bold="False"></asp:Label>
            </td></tr></table>
                        <br />
                        Selecione abaixo as lojas para as quais deseja realizar a contratação, clicando 
                        no link Contratar junto a cada loja.<br />
                        <br />
                        Se desejar incluir uma loja que não esteja listada abaixo,
                        <asp:LinkButton ID="BtnIncluir" runat="server">clique aqui.</asp:LinkButton>
                        <br />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="5" DataSourceID="SqlDataSource1" ForeColor="Black" 
                            GridLines="Horizontal" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="CNPJ" SortExpression="cnpj">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cnpj") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LblCNPJ" runat="server" Text='<%# Bind("cnpj") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("endereco") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("endereco") %>'></asp:Label>
                                        -
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("cidade_nome") %>'></asp:Label>
                                        /
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("estado_sigla") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="LnkContratar" runat="server" 
                                            CssClass='<%# Eval("css_class") %>' Font-Underline="True" Target="_blank" 
                                            Text='<%# Eval("texto_link") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cnpj,
       e.endereco,
       e.cidade_nome,
       e.estado_sigla,
       isnull((select confirmado from adesao_tef_loja where cod_emitente = e.cod_emitente and cnpj = e.cnpj),'N') confirmado,
       if confirmado = 'S' then 'Contratado' else 'Contratar' endif texto_link,
       if confirmado = 'S' then 'LinkFundoVerde' else 'LinkFundoAmarelo' endif css_class
  from v_emitente_endereco e
 where e.ativo        = 'S'
   and e.cod_emitente = :cod_emitente">
                            <SelectParameters>
                                <asp:QueryStringParameter Name=":cod_emitente" QueryStringField="e" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="SubTitulo" 
                style="width: 100%; font-size: 10pt; background-color: #F2FFFF;">
                3ª Etapa - 
                Concluir adesão</td>
            <td style="width: 100%; background-color: #F2FFFF;">
                <asp:Label ID="LblSitEtapa3" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" 
                colspan="2">
                <br />
                Clique no botão abaixo para concluir sua adesão.</td>
        </tr>
        <tr>
            <td width="100%" 
                colspan="2">
                <br />
                <asp:Button ID="BtnAdesao" runat="server" Text="Concluir adesão" Width="200px" 
                    Font-Bold="False" Font-Size="10pt" Height="25px" BackColor="#009933" 
                    ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td width="100%" style="border-bottom-style: solid; border-width: 1px; border-color: #C0C0C0; line-height: 24px;" colspan="2">
                <asp:Label ID="LblMensagemValidacaoAdesao" runat="server" Font-Bold="False" 
                    ForeColor="#006600"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server">Reenviar e-mail de validação</asp:LinkButton>
                <br />
            </td>
        </tr>
    </table>

        <br />
        <asp:LinkButton ID="BtnAtualizar" runat="server" ClientIDMode="Static">Atualizar a página</asp:LinkButton>

    </form>
</body>
</html>
