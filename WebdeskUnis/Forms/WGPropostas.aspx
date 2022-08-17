<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPropostas.aspx.vb" Inherits="WebdeskUnis.WGPropostas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Titulo">&nbsp;Propostas</div>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Label ID="LblInstrucoesBoleto" runat="server" 
            
            
            
            Text="Prezado cliente, nesta área você pode acompanhar suas propostas.&lt;br /&gt;&lt;br /&gt;"></asp:Label>
      
        <asp:Label ID="LblCodEmitente" runat="server" Text="0" Visible="False"></asp:Label>
        <br />
     
       
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br/&gt;&lt;br/&gt;Nenhuma porposta encontrada.&lt;br/&gt;" 
            ForeColor="Black" GridLines="Horizontal" Width="100%">
            <Columns>
               
                <asp:TemplateField HeaderText="Cód. Proposta" SortExpression="cod_tit_cr">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_negociacao_cliente") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("cod_negociacao_cliente", "{0:F0}") %>'></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="data_cadastramento" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data da Proposta" SortExpression="data_cadastramento" />
                <asp:BoundField DataField="etapa"  HeaderText="Etapa" SortExpression="etapa">
               
                </asp:BoundField>
                 <asp:BoundField DataField="representante"  HeaderText="Representante" SortExpression="representante">
               
                </asp:BoundField>
                <asp:BoundField DataField="total_pedido" DataFormatString="{0:F2}" 
                    HeaderText="Valor R$" SortExpression="total_pedido">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>              
               
              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument=' <%# Eval("cod_negociacao_cliente") %> '
                                        CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select n.cod_negociacao_cliente, e.descricao as etapa, a.nome as representante, n.data_cadastramento, total_mercadoria, total_despesas, total_pedido from negociacao_cliente n join
                        emitente a on a.cod_emitente = n.cod_representante join
                        etapa_negociacao e on e.cod_etapa = n.cod_etapa
                          where n.cod_emitente = :cod_emitente
                             order by n.data_cadastramento desc">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblCodEmitente" Name=":cod_emitente" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
