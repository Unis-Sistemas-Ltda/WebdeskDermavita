<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGSolicitacaoDesenvolvimentoFollowUP.aspx.vb" Inherits="WebdeskUnis.WGSolicitacaoDesenvolvimentoFollowUP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: left; font-weight: bold; font-size: 10pt;">
                    Follow-ups</td>
                <td style="text-align: right; width: 120px;">
                    <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" style="height: 18px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" AllowSorting="True" 
            EmptyDataText="Nenhum follow-up inserido até o momento.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                VerticalAlign="Top" />
            <Columns>
                <asp:TemplateField HeaderText="Data" SortExpression="data_follow_up">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("data_follow_up") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        Em
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                            Text='<%# Bind("data_follow_up", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        ,
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                            Text='<%# Bind("nome_usuario") %>'></asp:Label>
                        &nbsp;escreveu:<br />
                        <asp:Label ID="Label1" runat="server" Font-Italic="False" 
                            Text='<%# Bind("descricao") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                    <ItemStyle Font-Italic="True" HorizontalAlign="Justify" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este follow-up?');" 
                            ToolTip="Excluir registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" 
                        Font-Italic="True" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select f.seq_follow_up, f.data_follow_up, u.nome_usuario, replace(f.descricao,char(13),'&lt;br&gt;') descricao
  from solicitacao_desenvolvimento_follow_up f inner join sysusuario u on f.cod_usuario_inclusao = u.cod_usuario
 where f.empresa = :empresa
    and f.cod_solicitacao = :cod_solicitacao
    and isnull(f.visivel_cliente,'N') = 'S'
order by f.seq_follow_up desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":negociacao" 
                    SessionField="SCodSolicitacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
