<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAgendamentoAcademia.aspx.vb" Inherits="WebdeskUnis.WFAgendamentoAcademia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Resposta
        {
            padding-left: 40px;
        }
    </style>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div tyle="padding: 15px;" class="Titulo">Agendamento<asp:ScriptManager 
            ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </div>
    <div style="padding: 15px;">
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <div class="Titulo2">
            Aulas disponíveis para agendamento</div>
        <br />
        Para registrar o agendamento de sua aula, clique em <b>Agendar:</b><br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource2" 
            EmptyDataText="&lt;br&gt;Prezado aluno, não há aulas disponíveis para agendamento.&lt;br&gt;" 
            ForeColor="Black" GridLines="Horizontal" Width="95%">
            <Columns>
                <asp:BoundField DataField="nome_local" HeaderText="Local" 
                    SortExpression="nome_local">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Aula" SortExpression="descricao">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text='<%# Bind("descricao") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("narrativa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="nome_professor" HeaderText="Professor" 
                    SortExpression="nome_professor">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_turma" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_turma">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora Início" 
                    SortExpression="hora_inicio">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_termino" HeaderText="Hora Término" 
                    SortExpression="hora_termino">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnAgendar" runat="server" 
                            CommandArgument='<%# Eval("chave_horario") %>' CommandName="AGENDAR" 
                            Text="Agendar" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select t.estabelecimento,
        l.nome_abreviado nome_local,
        t.cod_turma,
        t.descricao,
        t.narrativa,
        t.data_turma,
        p.nome nome_professor,
        t.capacidade,
        isnull((select 1 from agenda_aluno aa where aa.empresa = t.empresa and aa.cod_turma = t.cod_turma),0) qtd_inscritos,
        isnull(t.capacidade,0) - isnull(qtd_inscritos,0) qtd_vagas_restantes,
        th.hora_inicio,
        th.hora_termino,
        t.empresa || ';' || t.estabelecimento || ';' || t.cod_turma || ';' || th.seq_horario chave_horario,
        :cod_emitente emit
   from turma t inner join turma_horario th on t.empresa = th.empresa and t.cod_turma = th.cod_turma
                inner join emitente p on p.cod_emitente = t.cod_professor
                inner join estabelecimento l on l.empresa = t.empresa and l.estabelecimento = t.estabelecimento
  where qtd_vagas_restantes &gt; 0
    and datediff( minute, now(), t.data_turma || ' ' || th.hora_inicio || ':00' ) between 0 and isnull((select tempo_liberacao_agendamento_aula from parametros_manutencao where empresa = t.empresa and estabelecimento = t.estabelecimento),120)
    and not exists(select 1 from agenda_aluno aa where aa.empresa = t.empresa and aa.cod_turma = t.cod_turma and aa.cod_emitente = emit)
    and exists(select 1
                 from contrato_manutencao cm inner join plano pl on cm.empresa = pl.empresa and cm.cod_plano = pl.cod_plano
                                             inner join plano_estabelecimento pe on pe.empresa = pl.empresa and pe.cod_plano = pl.cod_plano
                where cm.empresa         = t.empresa
                  and cm.cod_emitente    = emit
                  and pe.estabelecimento = t.estabelecimento)">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_emitente" SessionField="GlEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <div class="Titulo2">Seus agendamentos registrados</div>
        <br />
        <asp:GridView ID="GridView1" 
                runat="server" AllowPaging="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhum agendamento cadastrado até o momento.&lt;br&gt;" 
            ForeColor="Black" GridLines="Horizontal" PageSize="5" Width="95%">
            <Columns>
                <asp:BoundField DataField="estabelecimento_nome" HeaderText="Local" 
                    SortExpression="estabelecimento_nome">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_agendamento" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_agendamento">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora Início" 
                    SortExpression="hora_inicio">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_termino" HeaderText="Hora Término" 
                    SortExpression="hora_termino">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Aula" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Professor" SortExpression="nome">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_agendamento") & ";" & Eval("estabelecimento") %>' CommandName="EXCLUIR" 
                            onclientclick="return confirm('Deseja realmente cancelar o agendamento?');" 
                            Visible='<%# Eval("visible_cancelar") %>'>Cancelar agendamento</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="&nbsp;1&nbsp;" LastPageText="Últ." 
                Mode="NumericFirstLast" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.empresa,
       a.estabelecimento,
       es.nome_abreviado estabelecimento_nome,
       a.seq_agendamento,
       t.data_turma data_agendamento,
       a.seq_horario,
       a.cod_turma,
       t.descricao,
       t.cod_professor,
       p.nome,
       f_data_extenso(t.data_turma, 'DDDD') nome_dia_semana,
       th.hora_inicio,
       th.hora_termino,
if date(data_agendamento) &gt; today() or date(data_agendamento) = today() and convert(varchar(5),now(),8) &lt;= th.hora_inicio then 'true' else 'false' endif visible_cancelar
  from agenda_aluno a inner join turma t on a.cod_turma = t.cod_turma
                      inner join emitente p on p.cod_emitente = t.cod_professor
                      inner join estabelecimento es on es.empresa         = a.empresa
                                                   and es.estabelecimento = a.estabelecimento
                      inner join turma_horario th on th.cod_turma   = a.cod_turma
                                                 and th.seq_horario = a.seq_horario
 where a.empresa      = :empresa
   and a.cod_emitente = :emitente
order by data_agendamento desc, th.hora_inicio desc">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":emitente" SessionField="GlEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </div>
    </form>
</body>
</html>