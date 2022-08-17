<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGManual02.aspx.vb" Inherits="WebdeskUnis.WGManual02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Manual</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">

    <div style="padding: 25px;">
        <asp:Button ID="Button1" runat="server" Text="Voltar" />
        <br />
        <br />
        <asp:Label ID="LblNomeRotina" runat="server" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="LblDescricaoRotina" runat="server"></asp:Label>
        <br />
        <br />
        Encontram-se disponíveis os manuais 
        e vídeos abaixo para a rotina selecionada.<br />
        Clique sobre o nome do respectivo manual ou vídeo para visualizar o conteúdo.<br />
        <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                        GridLines="Horizontal" Width="700px" 
                        EmptyDataText="&lt;br&gt;&lt;br&gt;Não há manuais cadastrados para a rotina selecionada." 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px">
        <PagerStyle Font-Names="Tahoma" Font-Size="8pt" HorizontalAlign="Right" />
        <RowStyle HorizontalAlign="Justify" CssClass="LinhaDoGrid" 
            VerticalAlign="Top" />
        <Columns>
            <asp:TemplateField HeaderText="Manual" 
                SortExpression="nome">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="LinkGrid" 
                        Width="100%"  Height="100%" CommandName="ALTERAR" 
                        Text='<%# Eval("nome_manual") %>' 
                        
                                                onclientclick='<%# "window.open(" & chr(39) & "http://matriz.unissistemas.com.br/crm/Manual/" & Eval("arquivo") & chr(39) & "); return false;" %>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
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
        SelectCommand="select cod_manual, nome_manual, arquivo, :cod_sistema sist, :cod_modulo mod, :cod_rotina rot
  from manual m
 where exists(select 1
                from manual_rotina r
               where r.cod_manual  = m.cod_manual
                 and (sist = -1 or r.cod_sistema = sist)
                 and (mod = -1 or r.cod_modulo  = mod)
                 and r.cod_rotina  = rot)">
        <SelectParameters>
            <asp:SessionParameter Name=":cod_sistema" SessionField="SM_CodSistema" 
                DbType="String" DefaultValue="-1" />
            <asp:SessionParameter Name=":cod_modulo" SessionField="SM_CodModulo" 
                DbType="String" DefaultValue="-1" />
            <asp:SessionParameter Name=":cod_rotina" SessionField="SM_CodRotina" 
                DbType="String" DefaultValue="-1" />
        </SelectParameters>
    </asp:SqlDataSource>

        <br />
        <br />
        <br />
        Não há vídeos cadastrados para a rotina selecionada.</div>
    </form>
</body>
</html>

