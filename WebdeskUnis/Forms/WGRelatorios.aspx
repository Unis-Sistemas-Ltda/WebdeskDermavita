<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGRelatorios.aspx.vb" Inherits="WebdeskUnis.WGRelatorios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
    
    </head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="Titulo">Relatórios</div>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select 'Relação de agendamentos' nome_relatorio,
       'WFRelAgendamentos.aspx' pagina
  from dummy"></asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                        GridLines="Horizontal" Width="100%" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px">
                        <PagerStyle Font-Names="Tahoma" Font-Size="8pt" HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Left" CssClass="LinhaDoGrid" />
                        <Columns>
                            <asp:TemplateField HeaderText="Selecione" SortExpression="nome_relatorio">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" 
                                        PostBackUrl='<%# Eval("pagina") %>' Text='<%# Eval("nome_relatorio") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_relatorio") %>'></asp:TextBox>
                                </EditItemTemplate>
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
    </div>
    </form>
</body>
</html>
