<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGManual01.aspx.vb" Inherits="WebdeskUnis.WGManual01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Manual</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
    <div style="padding: 25px;">
        Para ter acesso aos manuais e vídeos, selecione, na lista abaixo, a rotina 
        desejada:<br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                        GridLines="Horizontal" Width="700px" 
                        EmptyDataText="&lt;br&gt;&lt;br&gt;Não há rotinas vinculadas ao sistema/módulo selecionado." 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px">
        <PagerStyle Font-Names="Tahoma" Font-Size="8pt" HorizontalAlign="Right" />
        <RowStyle HorizontalAlign="Justify" CssClass="LinhaDoGrid" 
            VerticalAlign="Top" />
        <Columns>
            <asp:TemplateField HeaderText="Selecione a rotina" 
                SortExpression="nome">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="LinkGrid" 
                        Width="100%"  Height="100%" CommandArgument='<%# Eval("cod_rotina") %>' CommandName="ALTERAR" 
                        Text='<%# Eval("nome") %>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50%" Height="100%"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" SortExpression="descricao">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton12" runat="server" CssClass="LinkGrid" 
                        Width="100%" Height="100%" CommandArgument='<%# Eval("cod_rotina") %>' CommandName="ALTERAR" 
                        Text='<%# Eval("descricao") %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="50%" Height="100%" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="select cod_rotina, nome, descricao, :cod_modulo mod, convert(varchar(200),:desc_rotina) rot
  from rotina r
 where (isnull(mod,-1) = -1 or exists(select 1 from rotina_modulo where cod_rotina = r.cod_rotina and cod_modulo = mod))
     and (trim(isnull(rot,'')) = '' or nome like '%' || rot || '%' or descricao like '%' || rot || '%')
order by nome">
        <SelectParameters>
            <asp:SessionParameter Name=":cod_modulo" SessionField="SM_CodModulo" ConvertEmptyStringToNull="False" DbType="String" DefaultValue="-1" />
            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" DefaultValue="" Name=":desc_rotina" SessionField="SM_NomeRotina" />
        </SelectParameters>
    </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
    