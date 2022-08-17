<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGDownloads.aspx.vb" Inherits="WebdeskUnis.WGDownloads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Titulo">
            Repositório de Arquivos</div>
            <div>
                <br />
                <span class="Titulo2">Arquivos Gerais</span><br />
                <br />
                Para fazer o download do aplicativo para suporte remoto, clique
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    onclientclick="window.open('../Downloads/SuporteUnis.exe'); return false;">aqui.</asp:LinkButton>
                <br />
                <br />
                <br />
                <span class="Titulo2">Seus Arquivos<br />
                </span>
                <br />
                <asp:Button ID="BtnIncluir" runat="server" Text="Incluir arquivo" />
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
                    GridLines="Horizontal" Width="600px" 
                    EmptyDataText="&lt;br/&gt;Nenhum arquivo incluído até o momento.">
                    <Columns>
                        <asp:TemplateField HeaderText="Seq." SortExpression="cod_arquivo">
                            <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkGrid" Width="100%" Text='<%# Eval("cod_arquivo") %>'></asp:LinkButton>
                                </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Arquivo" SortExpression="nome">
                            <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton10" runat="server" CssClass="LinkGrid" Width="100%" Text='<%# Eval("nome") %>'></asp:LinkButton>
                                </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    AlternateText='<%# Eval("cod_arquivo") %>' CommandName="ALTERAR" 
                                    ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                    CommandArgument='<%# Eval("cod_arquivo") %>' 
                                    ImageUrl="~/Imagens/BtnExcluir.png" 
                                    onclientclick="return confirm('Deseja realmente excluir este arquivo?')" 
                                    ToolTip="Excluir" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Left" CssClass="LinhaDoGrid" />
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
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_arquivo, nome
from arquivo_cliente
where cod_emitente = :cod_emitente">
                    <SelectParameters>
                        <asp:SessionParameter Name=":cod_emitente" SessionField="GlEmitente" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
    </div>
    </form>
</body>
</html>
