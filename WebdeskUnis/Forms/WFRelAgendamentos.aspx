<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAgendamentos.aspx.vb" Inherits="WebdeskUnis.WFRelAgendamentos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="Titulo">Relação de Agendamentos</div>
    <div>
        <br />
        
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <br />
        <b>Filtros</b><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Local:&nbsp;" Width="70px" 
            style="text-align:right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlLocal" runat="server" CssClass="TextoCadastro" 
            Width="400px" DataSourceID="SqlDataSource2" DataTextField="nome_abreviado" 
            DataValueField="estabelecimento" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Turma:&nbsp;" Width="70px" 
            style="text-align:right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlTurma" runat="server" CssClass="TextoCadastro" 
            Width="400px" AutoPostBack="True" DataSourceID="SqlDataSource3" 
            DataTextField="descricao" DataValueField="cod_turma">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Data:&nbsp;" Width="70px" 
            style="text-align:right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlData" runat="server" CssClass="TextoCadastro" 
            Width="400px" AutoPostBack="True" DataSourceID="SqlDataSource4" 
            DataTextField="descricao" DataValueField="data_aula">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Horário:&nbsp;" Width="70px" 
            style="text-align:right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlHorario" runat="server" CssClass="TextoCadastro" 
            Width="400px" DataSourceID="SqlDataSource5" DataTextField="descricao" 
            DataValueField="seq_horario">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Width="70px" style="text-align:right" 
            Height="17px"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Aplicar Filtro" />
        &nbsp;
        <asp:Button ID="Button2" runat="server" Text="Imprimir" 
            onclientclick="self.print(); return false;" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select e.estabelecimento estabelecimento, e.nome_abreviado
   from estabelecimento e
  where e.empresa      = :empresa
  union all
   select 0, '(selecione)'
     from dummy
  order by estabelecimento">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select t.cod_turma, t.descricao || ' (Prof: ' || p.nome || ')' descricao
  from turma t left outer join emitente p on t.cod_professor = p.cod_emitente
 where t.empresa         = :empresa
   and t.estabelecimento = :estabelecimento
union all
select 0, '(selecione)' descricao
from dummy
order by descricao">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="DdlLocal" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":estabelecimento" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select convert(varchar(10), data_aula, 115) data_aula,
       dia_semana,
       descricao
  from (select date(a.data_agendamento) data_aula,
               case dayname(data_aula) when 'Sunday' then 1 when 'Monday' then 2 when 'Tuesday' then 3 when 'Wednesday' then 4 when 'Thursday' then 5 when 'Friday' then 6 when 'Saturday' then 7 end dia_semana,
               convert(varchar(10), data_aula, 103) || ' (' || f_data_extenso(data_aula, 'ddd') || ')' descricao
          from agenda_aluno a
         where a.empresa   = :empresa
           and a.cod_turma = :cod_turma
         group by a.data_agendamento
        union all
        select '1900-01-01' data_aula,
                   1,
                   '(selecione)' descricao
        from dummy) tb
 order by if data_aula = '1900-01-01' then '2999-12-31' else data_aula endif desc">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="DdlTurma" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_turma" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select date(today() + row_num - 1) data_aula,
       case dayname(data_aula) when 'Sunday' then 1 when 'Monday' then 2 when 'Tuesday' then 3 when 'Wednesday' then 4 when 'Thursday' then 5 when 'Friday' then 6 when 'Saturday' then 7 end dia_semana,
       t.hora descricao,
       t.seq_horario seq_horario
  from rowgenerator r, 
       turma_horario t inner join turma tu on t.empresa   = tu.empresa
                                          and t.cod_turma = tu.cod_turma
 where t.empresa   = :empresa
   and t.cod_turma = :cod_turma
   and dia_semana  = t.dia_semana
   and convert(varchar(10),data_aula,115) = :data_aula
 group by data_aula, t.hora, t.seq_horario
 union all
 select '1900-01-01' data_aula,
        0,
        '(selecione)' descricao,
        0 seq_horario
 order by data_aula, descricao, seq_horario">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="DdlTurma" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_turma" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlData" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_aula" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" 
                runat="server" AllowPaging="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhum agendamento a exibir.&lt;br&gt;" 
            ForeColor="Black" GridLines="Horizontal" PageSize="5" Width="95%">
            <Columns>
                <asp:TemplateField HeaderText="Aluno" SortExpression="nome1">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome1") %>'></asp:Label>
                        (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
       a.data_agendamento,
       a.seq_horario,
       a.cod_turma,
       t.descricao,
       t.cod_professor,
       p.nome,
       case th.dia_semana when 1 then 'Domingo' when 2 then 'Segunda-feira' when 3 then 'Terça-feira' when 4 then 'Quarta-feira' when 5 then 'Quinta-feira' when 6 then 'Sexta-feira' when 7 then 'Sábado' end nome_dia_semana,
       th.hora,
       ea.cod_emitente,
       ea.nome
  from agenda_aluno a inner join turma t on a.cod_turma = t.cod_turma
                      inner join emitente p on p.cod_emitente = t.cod_professor
                      inner join estabelecimento es on es.empresa         = a.empresa
                                                   and es.estabelecimento = a.estabelecimento
                      inner join turma_horario th on th.cod_turma   = a.cod_turma
                                                 and th.seq_horario = a.seq_horario
                      inner join emitente ea on ea.cod_emitente = a.cod_emitente
 where a.empresa          = :empresa
   and a.estabelecimento  = :estabelecimento
   and a.cod_turma        = :cod_turma
   and a.data_agendamento = :data_agendamento
   and a.seq_horario      = :seq_horario
order by a.data_agendamento desc, th.hora desc, ea.nome">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="DdlLocal" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":estabelecimento" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlTurma" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_turma" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlData" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_agendamento" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlHorario" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":seq_horario" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>