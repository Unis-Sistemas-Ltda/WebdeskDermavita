<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTurma.aspx.vb" Inherits="WebdeskUnis.WGTurma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Titulo">&nbsp;Turmas</div>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnIncluir" runat="server" Text="Incluir" 
            ToolTip="Novo registro" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br/&gt;&lt;br/&gt;Nenhuma turma cadastrada até o momento.&lt;br/&gt;" 
            ForeColor="Black" GridLines="Horizontal" Width="100%">
            <Columns>
                <asp:BoundField DataField="cod_turma" HeaderText="Código" 
                    SortExpression="cod_turma" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" 
                    HeaderText="Descrição" SortExpression="descricao" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_turma" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_turma" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="capacidade" 
                    HeaderText="Capacidade" SortExpression="capacidade">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_abreviado" SortExpression="nome_abreviado" 
                    HeaderText="Local">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnAlterar" runat="server" 
                            CommandArgument='<%# Eval("cod_turma") %>' CommandName="ALTERAR" 
                            ToolTip="Editar os dados do registro">Editar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("cod_turma") %>' CommandName="EXCLUIR" 
                            onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                            ToolTip="Excluir o registro">Excluir</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                Mode="NumericFirstLast" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select t.cod_turma, t.descricao, t.data_turma, t.capacidade, e.nome_abreviado
  from turma t inner join estabelecimento e on t.empresa = e.empresa and t.estabelecimento = e.estabelecimento
 where t.empresa         = 1
   and t.cod_professor = :cod_emitente
order by t.data_turma desc, t.cod_turma desc">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_emitente" SessionField="GlEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
