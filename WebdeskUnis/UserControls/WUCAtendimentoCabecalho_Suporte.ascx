<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoCabecalho_Suporte.ascx.vb" Inherits="WebdeskUnis.WUCAtendimentoCabecalho_Suporte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="WUCContato.ascx" tagname="WUCContato" tagprefix="uc1" %>
<%@ Register src="WUCFollowUPAtendimento.ascx" tagname="WUCFollowUPAtendimento" tagprefix="uc2" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<link href="../Ajax.css" rel="stylesheet" type="text/css" />

<div class="Titulo">Detalhes do Chamado</div>
<table style="width: 100%; ">
    <tr>
        <td class="Erro">
            <asp:Label ID="LblErro" runat="server" CssClass="Instrucao"></asp:Label>
            <asp:Label ID="LblCodAnalista" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodStatus" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width:100%; border-collapse: collapse;">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" Height="16px" Text="Nº Chamado:"></asp:Label>
                            </td>
                            <td class="CelulaCampoCadastro" colspan="2">
                                <asp:Label ID="LblNrAtendimento" runat="server" Font-Bold="True" Height="17px" 
                                    Width="70px"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Height="17px" Text="Abertura:"></asp:Label>
                                <asp:Label ID="LblData" runat="server" Font-Bold="True" Height="17px"></asp:Label>
                                <asp:Label ID="LblHora" runat="server" Font-Bold="True" Height="17px"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="Label13" runat="server" Height="17px" Text="Status:" 
                                    Visible="False"></asp:Label>
                                <asp:DropDownList ID="DdlStatus" runat="server" CssClass="Cadastro" 
                                    Height="17px" Width="160px" Visible="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;">Previsão:</td>
                            <td class="CelulaCampoCadastro" colspan="2">
                                <asp:Label ID="LblDataPrevisaoFim" runat="server" Width="70px"></asp:Label>
                                <asp:Label ID="LblHoraPrevisaoFim" runat="server" Width="45px"></asp:Label>
&nbsp;
                                <asp:Label ID="LblEncerramento" runat="server" Text="Encerrado em:"></asp:Label>
                                <asp:Label ID="LblDataEncerramento" runat="server" Font-Bold="True" 
                                    Font-Italic="False"></asp:Label>
                                <asp:Label ID="LblHoraEncerramento" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="2">
                                <asp:Label ID="LblAssuntoLbl" runat="server" Text="Assunto:"></asp:Label>
                            </td>
                            <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
                                <asp:TextBox ID="TxtAssunto" runat="server" CssClass="Cadastro" MaxLength="80" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">Tipo de Chamado:</td>
                            <td class="CelulaCampoCadastro" colspan="2" style="vertical-align: middle">
                                <asp:DropDownList  ID="DdlTipoChamado" runat="server" CssClass="Cadastro" Width="350px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">Equipamento:</td>
                            <td class="CelulaCampoCadastro" colspan="2" style="vertical-align: middle">
                                <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="Cadastro" Width="350px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">Seq. Prioridade:</td>
                            <td class="CelulaCampoCadastro" colspan="2" style="vertical-align: middle">
                                <asp:TextBox ID="TxtSeqPrioridade" runat="server" CssClass="Cadastro" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" colspan="2">
                                <asp:Label ID="LblResponsavelLbl" runat="server" Text="Contato Respons&aacute;vel:"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="DdlContatos" runat="server" AutoPostBack="True" CssClass="Cadastro" Width="290px"></asp:DropDownList>
                                &nbsp;<asp:ImageButton ID="BtnIncluir" runat="server" Height="17px" ImageUrl="~/imagens/BtnIncluir.png" ToolTip="Novo contato" Width="14px" />
                                &nbsp;<asp:ImageButton ID="BtnAlterar" runat="server" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar os dados do contato selecionado" Height="17px" Width="14px" />
                                <asp:Label ID="LblEmail" runat="server" Height="17px"></asp:Label>
                            </td>
                        </tr>
                        <tr style="font-size: 1pt">
                            <td colspan="2" style="text-align: right; vertical-align: top;">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="LblMensagemAceite" runat="server" Text="A resposta dada pelo analista foi:" Visible="False" Font-Size="8pt"></asp:Label>
                                <asp:RadioButtonList ID="RblAceito" runat="server" AutoPostBack="True" CellPadding="0" CellSpacing="10" CssClass="Cadastro" RepeatColumns="3" Visible="False" Font-Size="8pt">
                                    <asp:ListItem Value="S" Selected="True">Satisfatória.</asp:ListItem>
                                    <asp:ListItem Value="I">Indiferente.</asp:ListItem>
                                    <asp:ListItem Value="N">Não Satisfatória.</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="LblMensagemNovaPergunta" runat="server" Text="&lt;br&gt;O chamado foi encerrado. Deseja reabri-lo?" Visible="False" Font-Size="8pt"></asp:Label>
                                <asp:RadioButtonList ID="RblNovaPergunta" runat="server" AutoPostBack="True" CellPadding="0" CellSpacing="10" CssClass="Cadastro" RepeatColumns="1" Visible="False" Font-Size="8pt">
                                    <asp:ListItem Value="S">Sim, gostaria de realizar outra pergunta sobre o assunto respondido.</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="N">N&atilde;o, desejo encerrar o chamado.</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr style="font-size: 1pt">
                            <td style="text-align: right; vertical-align: top;" colspan="2">
                                <asp:Label ID="LblSolic" runat="server" Text="Descreva aqui a solicitação ou problema:" Font-Size="8pt"
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="vertical-align: top" colspan="2">
                                <asp:TextBox ID="TxtDescricaoFollowUP" runat="server" CssClass="Cadastro" 
                                    Height="56px" TextMode="MultiLine" Visible="False" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="font-size: 1pt">
                            <td style="text-align: right; vertical-align: top;" colspan="2">
                                <asp:Label ID="LblAnex" runat="server" Font-Size="8pt"
                                    Text="Se desejar, você pode anexar até 3 arquivos:" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="CelulaCampoCadastro" colspan="2">
                                <asp:FileUpload ID="FUAnexo1" runat="server" 
                                    Width="350px" CssClass="CampoCadastro" Visible="False" />
                                <br />
                                <asp:FileUpload ID="FUAnexo2" runat="server" CssClass="CampoCadastro" 
                                    Width="350px" Visible="False" />
                                <br />
                                <asp:FileUpload ID="FUAnexo3" runat="server" CssClass="CampoCadastro" 
                                    Width="350px" Visible="False" />
                                <br />
                                <asp:Label ID="LblMensagem" runat="server" Font-Size="7pt" ForeColor="#006600" Height="23px" 
                                    Text="Formatos suportados:&lt;br/&gt;Imagens (PDF, PNG, JPG, GIF), Word (DOC, DOCX), PowerPoint (PPT, PPTX), Excel (XLS, XLSX)." 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr style="font-size: 1pt">
                            <td style="font-weight: bold; vertical-align: bottom" colspan="2">
                                &nbsp;</td>
                            <td class="CelulaCampoCadastro" colspan="2">
                                <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="width: 100%; ">
                                    <asp:Label ID="LblTipoEdicaoFollowUp" runat="server" Text="1" Visible="False"></asp:Label>
                                    <uc2:WUCFollowUPAtendimento ID="WUCFollowUPAtendimento1" runat="server" 
                                        Visible="False" />
                                    <asp:Button ID="BtnGravarFollowUP" runat="server" CssClass="Botao" 
                                        Text="Enviar" Visible="False" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; vertical-align: bottom" colspan="2"><br />
                                <asp:Label ID="LblHistorico" runat="server" Text="Histórico"></asp:Label>
                            </td>
                            <td class="CelulaCampoCadastro">&nbsp;</td>
                            <td class="CelulaCampoCadastro" style="text-align: right">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" CellPadding="4" CssClass="GridTexto" 
                                    DataSourceID="SqlDataSource1"
                                    ForeColor="Black" GridLines="Horizontal" Width="100%" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    EmptyDataText="Nenhum comentário adicionado até o momento.">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Descri&ccedil;&atilde;o" SortExpression="descricao">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                &nbsp;Em
                                                <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                                                    Text='<%# Eval("data_follow_up", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                ,
                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" 
                                                    Text='<%# Eval("nome_usuario") %>'></asp:Label>
                                                &nbsp;escreveu
                                                <asp:Label ID="Label17" runat="server" Font-Bold="False" 
                                                    Text='<%# Eval("tp") %>'></asp:Label>
                                                :<br />
                                                <br />
                                                <asp:Label ID="Label1" runat="server" ForeColor="#003300" 
                                                    Text='<%# Bind("descricao") %>'></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Label ID="Label18" runat="server" Text="Anexo(s):" 
                                                    Visible='<%# Eval("contem_anexo") %>'></asp:Label>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/AnexoFollowUp/" & Eval("anexo1") %>' Text='<%# Eval("anexo1") %>' Visible='<%# Eval("contem_anexo1") %>'></asp:HyperLink>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/AnexoFollowUp/" & Eval("anexo2") %>' Text='<%# Eval("anexo2") %>' Visible='<%# Eval("contem_anexo2") %>'></asp:HyperLink>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/AnexoFollowUp/" & Eval("anexo3") %>' Text='<%# Eval("anexo3") %>' Visible='<%# Eval("contem_anexo3") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
                                        HorizontalAlign="Left" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle HorizontalAlign="Left" 
                                        VerticalAlign="Top" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select case f.tipo when 1 then 'o seguinte comentário' when 2 then 'o seguinte comentário' when 3 then 'a seguinte resposta' when 4 then 'Comentário' end tp, 
f.seq_follow_up, 
u.cod_usuario, 
u.nome_usuario, 
f.data_follow_up, 
replace(replace(f.descricao, char(13),'&lt;br/&gt;'),char(10),'') descricao, 

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 1) anexo1,

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 2) anexo2,

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 3) anexo3,

if anexo1 is not null or anexo2 is not null or anexo3 is not null then 'True' else 'False' endif contem_anexo,

if anexo1 is not null then 'True' else 'False' endif contem_anexo1,

if anexo2 is not null then 'True' else 'False' endif contem_anexo2,

if anexo3 is not null then 'True' else 'False' endif contem_anexo3

  from follow_up_chamado f left outer join sysusuario u on u.cod_usuario = f.cod_usuario
 where f.empresa = 1
   and f.tipo in (2,3,4)
   and f.cod_chamado = :codChamado
order by f.seq_follow_up desc">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="LblNrAtendimento" Name=":codChamado" 
                                            PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="font-weight: bold; vertical-align: bottom">
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div style="width: 100%; background-color: #F8FBFC;">
                        <br />
                        <uc1:WUCContato ID="WUCContato1" runat="server" />
                        <asp:Button ID="BtnGravarContato" runat="server" Text="Salvar Contato" 
                            CssClass="Botao" />
                        &nbsp;
                        <asp:Button ID="BtnVoltarContato" runat="server" Text="Voltar" 
                            CssClass="Botao" />
                        <br />
                    </div>
                </asp:View>
            </asp:MultiView>
            </td>
    </tr>
    </table>