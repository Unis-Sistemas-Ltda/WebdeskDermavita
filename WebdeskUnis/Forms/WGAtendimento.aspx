<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimento.aspx.vb" Inherits="WebdeskUnis.WGAtendimento" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
    
    </head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="Titulo">Painel de Chamados</div>
    <div>
    
        <table style="border-style: none; margin: 0px; border-collapse: collapse; width: 100%;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td class="Erro">
                    <br />
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                    <asp:Label ID="LblFiltroChamado" 
            runat="server" Text="1" Visible="False"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="background-color: #F3F8F8;">
                    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
                                Font-Size="9pt" ForeColor="#7C6F57" 
                                CssClass="adjustedZIndex" BackColor="#F3F8F8" DynamicHorizontalOffset="2" 
                                StaticSubMenuIndent="10px" RenderingMode="List">
                                <StaticMenuStyle CssClass="ajustedZIndex" />
                                <StaticHoverStyle ForeColor="White" BackColor="#4080BF" />
                                <StaticSelectedStyle BackColor="#D7E7EA"/>
                                <StaticMenuItemStyle ForeColor="#333333" VerticalPadding="8px" 
                                    HorizontalPadding="25px" />
                                <DynamicMenuStyle CssClass="adjustedZIndex"/>
                                <DynamicHoverStyle ForeColor="Black" BackColor="#D7E7EA"/>
                                <DynamicSelectedStyle ForeColor="#333333" BackColor="#D7E7EA" />
                                <DynamicMenuItemStyle ForeColor="#333333" VerticalPadding="7px" HorizontalPadding="28px" BackColor="White" />
                        <Items>
                            <asp:MenuItem Target="0" Text="Novo chamado" 
                                ToolTip="Clique para abrir um chamado" Value="Abrir um chamado">
                            </asp:MenuItem>
                            <asp:MenuItem Target="1" Text="Chamados pendentes" Value="Chamados pendentes"
                                ToolTip="Clique para visualizar os chamados que ainda não foram respondidos" Selected="True"></asp:MenuItem>
                            <asp:MenuItem Target="2" Text="Aguardando aceite do cliente" 
                                ToolTip="Clique para visualizar os chamados respondidos pela Unis, que estão aguardando aceite do cliente." >
                            </asp:MenuItem>
                        </Items>
                        <StaticMenuItemStyle CssClass="MenuItemDin" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" ForeColor="#383838" />
                    </asp:Menu>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Height="17px" 
                        Text="&lt;b&gt;Filtros&lt;/b&gt;&nbsp;&nbsp;&nbsp;&nbsp;Tipo de chamado:"></asp:Label>
                    <asp:DropDownList ID="DdlTipoChamado" runat="server" CssClass="Cadastro" 
                        Width="200px">
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Height="17px" 
                        Text="&nbsp;&nbsp;&nbsp;&nbsp;Contato Responsável:"></asp:Label>
                    <asp:DropDownList ID="DdlContatoResponsavel" runat="server" CssClass="Cadastro" 
                        Width="200px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Pesquisar" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                        GridLines="Horizontal" Width="100%" AllowSorting="True" 
                        EmptyDataText="&lt;br&gt;&lt;br&gt;Não há chamados pendentes (conforme filtros acima).&lt;br/&gt;Se desejar abrir um chamado, clique na opção &lt;b&gt;Novo chamado&lt;/b&gt; acima." 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px" AllowPaging="True">
                        <PagerStyle Font-Names="Tahoma" Font-Size="8pt" HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Left" CssClass="LinhaDoGrid" />
                        <Columns>
                            <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                SortExpression="seq" Visible="False" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Nº Chamado" SortExpression="cod_chamado">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton10" runat="server" CssClass="LinkGrid" Width="100%" CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" Text='<%# Eval("cod_chamado") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Seq. Prioridade" SortExpression="seq_prioridade">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton101" runat="server" 
                                        CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" 
                                        CssClass="LinkGrid" Text='<%# Eval("seq_prioridade") %>' Width="100%"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("seq_prioridade") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo Chamado" SortExpression="nome_tipo_chamado">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton102" runat="server" 
                                        CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" 
                                        CssClass="LinkGrid" Text='<%# Eval("nome_tipo_chamado") %>' Width="100%"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" 
                                        Text='<%# Bind("nome_tipo_chamado") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assunto" SortExpression="assunto">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="LinkGrid" Width="100%" CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" Text='<%# Eval("assunto") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="descricao_status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton12" runat="server" CssClass="LinkGrid" Width="100%" CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" Text='<%# Eval("descricao_status") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="cf_situacao" HeaderText="Situação" 
                                SortExpression="cf_situacao" Visible="False">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Abertura" SortExpression="data_chamado">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton15" runat="server" CssClass="LinkGrid" Width="100%" CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" Text='<%# Bind("data_chamado", "{0:dd/MM/yy HH:mm}") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Previsão" 
                                SortExpression="data_encerramento_prevista">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" 
                                        Text='<%# Bind("data_encerramento_prevista", "{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" 
                                        Text='<%# Bind("data_encerramento_prevista") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="E-mail para contato" 
                                SortExpression="email_contato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton16" runat="server" CssClass="LinkGrid" Width="100%" CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" Text='<%# Bind("email_contato") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="tipo_status" SortExpression="tipo_status" 
                                Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tipo_status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblTipoStatus" runat="server" Text='<%# Bind("tipo_status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="cf_dias" SortExpression="cf_dias" 
                                Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cf_dias") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblDias" runat="server" Text='<%# Bind("cf_dias") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                            Mode="NumericFirstLast" PageButtonCount="12" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        SelectCommand="call sp_atendimento_webdesk_unis(:empresa, :cod_chamado, :assunto, :cod_emitente, :tp_status, 0, :cnpj, :tipo_chamado, :contato_responsavel)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name=":empresa" />
                            <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue="" 
                                Name=":codchamado" Type="String" />
                            <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue="" Name=":assunto" 
                                Type="String" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DefaultValue="" 
                                Name=":cod_emitente" SessionField="GlEmitente" Type="String" />
                            <asp:ControlParameter ControlID="LblFiltroChamado" DefaultValue="" 
                                Name=":tp_status" PropertyName="Text" />
                            <asp:SessionParameter DefaultValue="" Name=":cnpj" SessionField="GlCNPJ" />
                            <asp:ControlParameter ControlID="DdlTipoChamado" 
                                ConvertEmptyStringToNull="False" DbType="String" DefaultValue="" 
                                Name=":tipo_chamado" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="DdlContatoResponsavel" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":contato_responsavel" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
