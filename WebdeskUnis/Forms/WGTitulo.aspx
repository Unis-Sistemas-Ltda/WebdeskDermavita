<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTitulo.aspx.vb" Inherits="WebdeskUnis.WGTitulo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Titulo">&nbsp;Boletos</div>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Label ID="LblInstrucoesBoleto" runat="server" 
            
            
            
            Text="Prezado cliente, nesta área você pode acompanhar seu histórico financeiro e visualizar seus boletos em aberto.&lt;br /&gt;&lt;br /&gt;Para emitir a segunda via de um boleto, selecione abaixo a opção &lt;b&gt;Em Aberto&lt;/b&gt; e em seguida clique em &lt;b&gt;Imprimir Boleto&lt;/b&gt;.&lt;br /&gt;"></asp:Label>
        <asp:Label ID="LblInstrucoesLogin" runat="server" 
            
            
            
            
            Text="&lt;br/&gt;Para ter acesso aos boletos em aberto, informe abaixo seu CNPJ e senha e em seguida clique em OK.&lt;br /&gt;&lt;br /&gt;"></asp:Label>
        <asp:Label ID="LblCNPJ_CPF" runat="server" Text="CNPJ:&nbsp;" Width="70px" 
            style="text-align:right" Height="16px"></asp:Label>
        <asp:TextBox ID="TxtCNPJ" runat="server" CssClass="TextoCadastro" Width="118px"></asp:TextBox>
        <asp:Label ID="LblCodEmitente" runat="server" Text="0" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="LblSenha" runat="server" Text="Senha:&nbsp;" Width="70px" 
            style="text-align:right" Height="16px"></asp:Label>
        <asp:TextBox ID="TxtSenha" runat="server" CssClass="TextoCadastro" 
            TextMode="Password" Width="118px"></asp:TextBox>
        &nbsp;<asp:Button ID="Btn_OK_Login" runat="server" Text="OK" />
        <br />
        <asp:Menu ID="Menu1" runat="server" CssClass="SubTitulo" 
            Orientation="Horizontal" RenderingMode="List" Font-Size="10pt">
            <Items>
                <asp:MenuItem Text="Em Aberto" Value="1" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Histórico" Value="2"></asp:MenuItem>
            </Items>
            <StaticMenuStyle CssClass="ajustedZIndex" />
                                <StaticHoverStyle ForeColor="White" BackColor="#4080BF" />
                                <StaticSelectedStyle BackColor="#D7E7EA"/>
                                <StaticMenuItemStyle ForeColor="#333333" VerticalPadding="8px" 
                                    HorizontalPadding="25px" />
                                <DynamicMenuStyle CssClass="adjustedZIndex"/>
                                <DynamicHoverStyle ForeColor="Black" BackColor="#D7E7EA"/>
                                <DynamicSelectedStyle ForeColor="#333333" BackColor="#D7E7EA" />
                                <DynamicMenuItemStyle ForeColor="#333333" VerticalPadding="7px" HorizontalPadding="28px" BackColor="White" />
        </asp:Menu>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br/&gt;&lt;br/&gt;Nenhum boleto encontrado.&lt;br/&gt;" 
            ForeColor="Black" GridLines="Horizontal" Width="100%">
            <Columns>
                <asp:BoundField DataField="serie" HeaderText="Série" ReadOnly="True" 
                    SortExpression="serie" />
                <asp:TemplateField HeaderText="Título" SortExpression="cod_tit_cr">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_tit_cr") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("cod_tit_cr", "{0:F0}") %>'></asp:Label>
                        /
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("parcela") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Emissão" SortExpression="data_emissao" />
                <asp:BoundField DataField="data_vencimento" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Vencimento" SortExpression="data_vencimento" />
                <asp:BoundField DataField="valor_saldo" DataFormatString="{0:F2}" 
                    HeaderText="Valor R$" SortExpression="valor_saldo">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="obs" SortExpression="obs">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="situacao" SortExpression="situacao">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnImprimirBoleto" runat="server" CommandArgument='<%# Eval("chave") %>' CommandName="IMPRIMIR" Visible='<%# Eval("visible_imprimir") %>'>Imprimir Boleto</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                Mode="NumericFirstLast" PageButtonCount="13" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select t.empresa, t.cod_especie, t.serie, t.cod_tit_cr, t.parcela, t.cod_cenario_ctbl, if t.sit_saldo = 2 then t.valor_recebido else t.valor_saldo endif valor_saldo, t.data_vencimento data_vencimento, :sit_saldo stsl,
       isnull((select dias_termino_aviso_titulos_vencidos from parametros_email where empresa = t.empresa),999999) dias_max,
       isnull((select dias_inicio_aviso_titulos_retorno_cartorio from parametros_email where empresa = t.empresa),999999) dias_reinicio,
       dateadd(day,dias_max,t.data_vencimento) data_max,
       dateadd(day,dias_reinicio,t.data_vencimento) data_reinicio,
       isnull(( select if max('|' || bi.cod_bordero_cr ) is null then null else t.empresa || max('|' || bi.cod_bordero_cr ) || '|' || t.cod_especie ||'|' || t.serie ||'|' || t.cod_tit_cr || '|' || t.parcela || '|' || t.cod_cenario_ctbl endif
                   from bordero_cr_item bi left outer join bordero_cr b on b.empresa        = bi.empresa
                                                                       and b.cod_bordero_cr = bi.cod_bordero_cr
                  where t.empresa          = bi.empresa
                    and t.estabelecimento  = bi.estabelecimento
                    and t.cod_especie      = bi.cod_especie
                    and t.serie            = bi.serie
                    and t.cod_tit_cr       = bi.cod_tit_cr
                    and t.parcela          = bi.parcela
                    and t.cod_cenario_ctbl = bi.cod_cenario_ctbl
                    and b.tp_bordero       = 5
                    and b.atualizado       = 'S'
                    and isnull(b.enviado,'N') = 'S'),'') chave,
        if t.sit_saldo = 2 then 'Recebido em ' || convert(varchar(10), t.data_ultimo_recebimento, 103) else if visible_imprimir = 'False' then 'Boleto não disponível. Por favor contate nosso Depto Financeiro.' else '' endif endif situacao,
        if t.sit_saldo = 1 then if t.data_vencimento &lt; today() then 'Vencido' else if t.data_vencimento = today() then 'Vencimento hoje' else 'A vencer' endif endif else '' endif obs,
        if stsl = '1' and t.cod_tit_cr_banco is not null and (today() &lt;= data_max or today() &gt;= data_reinicio) and t.situacao &lt;&gt; 10 and ((t.sit_saldo = 1 and chave &lt;&gt; '') or t.sit_saldo = 2) then 'True' else 'False' endif visible_imprimir,
        t.data_emissao
   from titulo_cr t
  where t.cod_emitente = :cod_emitente
    and t.sit_saldo = stsl
  group by t.empresa,  t.cod_especie, t.serie, t.cod_tit_cr, t.parcela, t.cod_cenario_ctbl, t.data_vencimento, t.valor_saldo, t.data_ultimo_recebimento, t.sit_saldo, valor_saldo, t.data_emissao, t.situacao, t.cod_tit_cr_banco, chave
  order by t.data_vencimento desc">
            <SelectParameters>
                <asp:ControlParameter ControlID="Menu1" Name=":sit_saldo" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="LblCodEmitente" Name=":cod_emitente" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
