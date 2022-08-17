<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNotasFiscais.aspx.vb" Inherits="WebdeskUnis.WGNotasFiscais" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">
            Notas Fiscais</div>
            <div>
                <br />
                <table style="width: 100%; font-size: 7pt;">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                DataKeyNames="empresa,estabelecimento,serie,cod_nfs" 
                                DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" 
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="serie" HeaderText="Série" ReadOnly="True" 
                                        SortExpression="serie">
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cod_nfs" HeaderText="Nº Nota" ReadOnly="True" 
                                        SortExpression="cod_nfs">
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yy}" 
                                        HeaderText="Emissão" SortExpression="data_emissao">
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select empresa, estabelecimento, serie, cod_nfs, data_emissao
  from nfs
 where situacao_nf_eletronica in (2, 3)
    and empresa = :empresa
    and cod_emitente = :cod_emitente
order by data_emissao desc">
                                <SelectParameters>
                                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                                    <asp:SessionParameter Name=":cod_emitente" SessionField="GlEmitente" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                <br />
    </div>
    </form>
</body>
</html>
