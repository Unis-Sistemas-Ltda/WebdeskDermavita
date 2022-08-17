<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoHistorico.aspx.vb" Inherits="WebdeskUnis.WGNegociacaoHistorico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%">
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    
        <br />
        <div class="SubTituloMovimento">Ações/Follow-ups</div>
            <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagens/BtnNovoRegistro.png" /><br />--%>
    
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataKeyNames="empresa,cod_emitente,seq_follow_up,cod_contato,cod_usuario" 
            DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
            Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Seq" SortExpression="seq_follow_up" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_follow_up") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodFollowUp" runat="server" 
                            Text='<%# Bind("seq_follow_up") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_follow_up" HeaderText="Data" 
                    SortExpression="data_follow_up" DataFormatString="{0:dd/MM/yyyy}" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_follow_up" HeaderText="Hora" 
                    SortExpression="hora_follow_up" DataFormatString="{0:HH:mm}" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="assunto" HeaderText="Assunto" 
                    SortExpression="assunto" Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Contato" SortExpression="nome" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario" Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkExpansao" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXPANDIR" 
                            Font-Underline="False" style="font-weight: 700">+</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ação">
                    <ItemTemplate>
                        em
                        <asp:Label ID="Label7" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("data_follow_up", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("hora_follow_up", "{0:t}") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("descricao") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("assunto") %>'></asp:Label>
                        &nbsp;- Pessoa contactada:
                        <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("nome") %>'></asp:Label>
                        &nbsp;- por
                        <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("nome_usuario") %>'></asp:Label>
                        <asp:Label ID="LblDetalhes" runat="server" 
                            Text='<%# "<br>" & Eval("fup_descricao") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Font-Bold="False" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%#Eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select f.empresa, f.estabelecimento, f.cod_emitente, f.seq_follow_up, f.cod_negociacao_cliente, f.data_follow_up, f.hora_follow_up, f.assunto, f.cod_contato, f.cod_usuario, c.nome, s.nome_usuario, ac.descricao, f.descricao fup_descricao
  from follow_up_emitente f left outer join contatos c on c.cod_contato = f.cod_contato
                                                       and c.cod_emitente = f.cod_emitente
                            left outer join sysusuario s on s.cod_usuario = f.cod_usuario
                            left outer join acao_follow_up ac on ac.cod_acao = f.cod_acao
 where  f.empresa = :empresa
  and f.cod_negociacao_cliente = :cod_negociacao
  and f.tipo = 2
order by f.data_follow_up desc, f.hora_follow_up desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":cod_negociacao" SessionField="CodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
          <div style="width: 100%">
    
        <asp:Label ID="Label14" runat="server" CssClass="Erro"></asp:Label>
    
        <br />
        <div class="SubTituloMovimento">Ações/Follow-ups Chamados</div>
           
     <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataKeyNames="empresa,cod_chamado,seq_follow_up" 
            DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" 
            Width="100%" 
            
            EmptyDataText="&lt;br&gt;&lt;br&gt;Não há follow-ups cadastrados para o chamado em questão" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Seq" SortExpression="seq_follow_up" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_follow_up") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodFollowUp2" runat="server" 
                            Text='<%# Bind("seq_follow_up") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Chamado" SortExpression="cod_chamado" 
                   >
                    <EditItemTemplate>
                        <asp:Label ID="LabelCodChamdo" runat="server" Text='<%# Eval("cod_chamado") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodChamado" runat="server" 
                            Text='<%# Bind("cod_chamado") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkExpansao2" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXPANDIR" 
                            Font-Underline="False" style="font-weight: 700">+</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comentário" SortExpression="fup_descricao">
                    <ItemTemplate>
                        Em
                        <asp:Label ID="LblData" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Eval("data_follow_up", "{0:dd/MM/yy HH:mm}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="LblUsuario" runat="server" Text='<%# Eval("nome_usuario") %>' 
                            Font-Bold="True" Font-Italic="False"></asp:Label>
                        escreveu:<br />
                        <br />
                        <asp:Label ID="LblComentario" runat="server" 
                            Text='<%# Bind("fup_descricao") %>' Font-Italic="False" 
                            ForeColor="#0033CC" Visible="False"></asp:Label>
                        <br />   
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fup_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Font-Italic="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="@" SortExpression="email">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("email") %>' 
                            Enabled="False" ToolTip='<%# Eval("email_tooltip") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_email" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="E-mail Env." SortExpression="data_email" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select f.empresa, f.seq_follow_up, f.cod_chamado, f.data_follow_up, f.data_email, f.cod_usuario, s.nome_usuario, replace(f.descricao,char(13),'&lt;br/&gt;') fup_descricao, if f.email = 'S' then 'True' else 'False' endif email, if f.email = 'True' then 'Este comentário gera envio de e-mail.' else 'Este comentário não gera envio de e-mail.' endif email_tooltip, case f.tipo  when 1 then 'Comentário' when 2 then 'Pergunta' else 'Resposta' end tipo
     

  from follow_up_chamado f left outer join sysusuario s on s.cod_usuario = f.cod_usuario
inner join negociacao_cliente nc on nc.cod_chamado = f.cod_chamado
 where f.empresa = :empresa
   and nc.cod_negociacao_cliente = :cod_negociacao
 order by seq_follow_up desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name=":empresa" SessionField="GlEmpresa" />               
                <asp:SessionParameter Name=":cod_negociacao" SessionField="CodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>

          <div style="width: 100%">
    
        <asp:Label ID="Label15" runat="server" CssClass="Erro"></asp:Label>
    
        <br />
        <div class="SubTituloMovimento">Ações/Follow-ups Cliente</div>
           
        
                    <asp:GridView ID="GridViewFUCli" runat="server" 
                        AllowSorting="True" AutoGenerateColumns="False" 
                        DataKeyNames="seq_follow_up" DataSourceID="SqlDataSourceFUCli" 
                        EmptyDataText="&lt;br&gt;&lt;br&gt;Não há follow-ups cadastrados para o cliente em questão" 
                        ForeColor="#333333" GridLines="None" Width="100%" CssClass="TextoCadastro" PageSize="7" >
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="seq_follow_up" HeaderText="Seq." SortExpression="seq_follow_up" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_follow_up" HeaderText="Data" 
                                SortExpression="data_follow_up" DataFormatString="{0:dd/MM/yy}" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="hora_follow_up" HeaderText="Hora" SortExpression="hora_follow_up" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                                SortExpression="descricao" >
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                                SortExpression="nome_usuario" >
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                           
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#336699" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceFUCli" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                        SelectCommand="
                        
                        select u.nome_usuario, f.seq_follow_up, f.data_follow_up, data_follow_up as hora_follow_up, f.descricao, f.cod_usuario, u.nome_usuario, f.empresa || ';' || f.seq_follow_up chave
  from follow_up_chamado f inner join chamado c on c.cod_chamado = f.cod_chamado
                           left outer join sysusuario u on f.cod_usuario = u.cod_usuario
 where c.cod_emitente = :cod_emitente
UNION  all
select u.nome_usuario, f.seq_follow_up, f.data_follow_up, f.hora_follow_up, f.descricao, f.cod_usuario, u.nome_usuario, f.empresa || ';' || f.seq_follow_up chave
  from follow_up_emitente f left outer join sysusuario u on f.cod_usuario = u.cod_usuario
 where f.cod_emitente = :cod_emitente
   and ISNULL(f.cod_negociacao_cliente,0) <> :cod_negociacao
order by data_follow_up desc                  
                        ">
                        <SelectParameters>
                            <asp:SessionParameter Name="cod_emitente" SessionField="SCodEmitente" />
                            <asp:SessionParameter Name=":cod_negociacao" SessionField="CodNegociacao" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    
    
    </div>

    <div>
        <br />
        <div class="SubTituloMovimento">Tarefas</div>
             <asp:Label ID="Label13" runat="server" CssClass="TextoCadastro_BGBranco" 
                 Height="17px" Text="Exibir:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                Width="210px" AutoPostBack="True">
                <asp:ListItem Value="1">Aguardando retorno do cliente</asp:ListItem>
                <asp:ListItem Value="2">Aguardar</asp:ListItem>
                <asp:ListItem Value="3">Cancelada</asp:ListItem>
                <asp:ListItem Value="4">Concluída</asp:ListItem>
                <asp:ListItem Value="5">Em Andamento</asp:ListItem>
                <asp:ListItem Value="6">Não Iniciada</asp:ListItem>
                 <asp:ListItem Value="-1">(Todas)</asp:ListItem>
                 <asp:ListItem Selected="True" Value="-2">(Não concluídas)</asp:ListItem>
            </asp:DropDownList>
    
             <br />
           <%-- <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagens/BtnNovoRegistro.png" />--%>
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource4" 
            ForeColor="#333333" GridLines="None" Width="100%">
            <PagerSettings FirstPageText="1" LastPageText="Última" Mode="NumericFirstLast" 
                PageButtonCount="8" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="seq_tarefa" HeaderText="Seq." 
                    SortExpression="seq_tarefa" Visible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="descricao_resumida" HeaderText="Tarefa" 
                    SortExpression="descricao_resumida" Visible="False">
                </asp:BoundField>
                <asp:TemplateField HeaderText="Prioridade" SortExpression="prioridade">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("prioridade") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        Seq:<asp:Label ID="Label8" runat="server" Text='<%# Eval("seq_tarefa") %>'></asp:Label>
                        &nbsp;- Prioridade:<asp:Label ID="LblPrioridade" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("prioridade") %>'></asp:Label>
                        &nbsp;- Situação:<asp:Label ID="LblSituacao" runat="server" 
                            Text='<%# Eval("situacao") %>'></asp:Label>
                        <br />
                        Descrição:
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("descricao_resumida") %>' 
                            style="font-weight: 700"></asp:Label>
                        <br />
                        Responsável:
                        <asp:Label ID="Label10" runat="server" 
                            Text='<%# Eval("nome_usuario") %>'></asp:Label>
                        <br />
                        Previsão:
                        <asp:Label ID="Label11" runat="server" 
                            Text='<%# Eval("previsao_finalizacao", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;- Finalização:&nbsp;<asp:Label ID="Label12" runat="server" 
                            Text='<%# Eval("data_conclusao", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;<br />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="nome_usuario" 
                    HeaderText="Responsável" SortExpression="nome_usuario" Visible="False" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Situação" SortExpression="situacao" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("situacao") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="previsao_finalizacao" 
                    HeaderText="Previsão" SortExpression="previsao_finalizacao" 
                    DataFormatString="{0:dd/MM/yyyy}" Visible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="data_conclusao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Conclusão" SortExpression="data_conclusao" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            CommandArgument='<%# Eval("seq_tarefa") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" VerticalAlign="Bottom" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select seq_tarefa, e.descricao || ' (' || e.cod_etapa || ')' funil, tp.descricao_resumida, case nt.prioridade when 'A' then 'ALTA' when 'B' then 'BAIXA' when 'M' then 'MÉDIA' end prioridade, su.nome_usuario, case nt.situacao when 1 then 'Aguardando retorno do cliente' when 2 then 'Aguardar' when 3 then 'Cancelada' when 4 then 'Concluída' when 5 then 'Em andamento' when 6 then 'Não iniciada' end situacao, nt.previsao_finalizacao, nt.data_conclusao, case nt.prioridade when 'A' then 1 when 'M' then 2 else 3 end nprioridade, :situacao sit
  from negociacao_tarefa nt left outer join etapa_negociacao e on nt.empresa = e.empresa and nt.cod_etapa = e.cod_etapa
                            inner join tarefa_padrao tp on tp.cod_tarefa_padrao = nt.cod_tarefa_padrao
                            inner join sysusuario su on su.cod_usuario = nt.cod_responsavel
 where nt.cod_negociacao_cliente = :codNegociacao
   and nt.empresa = :empresa
   and nt.situacao = if sit = '-1' then    nt.situacao else    if sit = '-2' then       if nt.situacao in (1,2,5,6) then          nt.situacao       else          sit       endif   else       sit    endif endif
 order by seq_tarefa">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlSituacao" Name=":situacao" 
                    PropertyName="SelectedValue" />
                <asp:SessionParameter Name=":codNegociacao" SessionField="CodNegociacao" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
    </div>
    <div class="TextoCadastro_BGBranco">
            <div class="SubTituloMovimento">Visitações</div>

                       <%-- <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" 
                            BorderColor="#000099" BorderStyle="Outset" Height="18px" 
                            ImageAlign="Bottom" />--%>

                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SqlDataSource5" ForeColor="#333333" 
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14" 
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum registro a exibir.">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="seq_visita" HeaderText="Seq. Visita" ReadOnly="True" 
                                    SortExpression="seq_visita" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="data_visita" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Data" SortExpression="data_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora_visita" HeaderText="Hora" 
                                    SortExpression="hora_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vendedor/Representante" 
                                    SortExpression="nome_representante">
                                    <ItemTemplate>
                                        <asp:Label ID="Label21" runat="server" 
                                            Text='<%# Bind("nome_representante") %>'></asp:Label>
                                        (<asp:Label ID="Label20" runat="server" Text='<%# Eval("cod_representante") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cliente" 
                                    SortExpression="nome_cliente" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("nome_cliente") %>'></asp:Label>
                                        (<asp:Label ID="Label24" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>)
                                        &nbsp;CNPJ/CPF:
                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="situacao_nome" HeaderText="Situação" 
                                    SortExpression="situacao_nome">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="titulo" HeaderText="Assunto" SortExpression="titulo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField SortExpression="nome_cliente">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton5" runat="server" 
                                            CommandArgument='<%# Eval("seq_visita") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" 
                                            ToolTip="Clique para alterar ou consultar o registro" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                                Mode="NumericFirstLast" PageButtonCount="15" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                            
                            
                            
                            SelectCommand="  select v.empresa,
          v.estabelecimento,
          v.seq_visita,
          v.cod_representante,
          r.nome nome_representante,
          if isnull(v.id_cliente_generico,'N') = 'S' then 0 else v.cod_emitente endif cod_emitente,
          if trim(isnull(v.cnpj,'')) = '' then '(não informado)' else v.cnpj endif cnpj,
          if isnull(v.id_cliente_generico,'N') = 'S' then v.cliente_generico else c.nome endif nome_cliente,
          v.data_visita,
          v.hora_visita,
          v.situacao,
          case v.situacao when 1 then 'Agendada' when 2 then 'Concluída' when 3 then 'Cancelada' end situacao_nome,
          v.titulo,
          v.narrativa
     from  visitacao v left outer join emitente c on c.cod_emitente = v.cod_emitente
                      inner join emitente r on r.cod_emitente = v.cod_representante
    where v.empresa         = :empresa
      and v.cod_negociacao_cliente = :negociacao
    order by data_visita, nome_cliente, seq_visita;">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":negociacao" SessionField="CodNegociacao" />
                            </SelectParameters>
                        </asp:SqlDataSource>
    
    </div>
    <div class="TextoCadastro_BGBranco">
    
        <br />
    
        <div class="SubTituloMovimento">Alterações de Etapas</div><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%" EmptyDataText="Não há registros a exibir.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="seq_etapa" HeaderText="Seq." 
                    SortExpression="seq_etapa" />
                <asp:BoundField DataField="descricao" HeaderText="Etapa" 
                    SortExpression="descricao" />
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario" />
                <asp:BoundField DataField="data_etapa" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="Data" SortExpression="data_etapa" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select n.seq_etapa, e.descricao, u.nome_usuario, n.data_etapa
   from negociacao_cliente_etapas n inner join sysusuario u on n.cod_usuario = u.cod_usuario
                                    inner join etapa_negociacao e on e.empresa = n.empresa
                                                                 and e.cod_etapa = n.cod_etapa
 where n.empresa = :empresa
  and n.estabelecimento = :estabelecimento
  and n.cod_negociacao_cliente = :cod_negociacao
order by n.data_etapa desc">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="SEstabelecimentoNegociacao" />
                <asp:SessionParameter Name=":cod_negociacao" SessionField="CodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
    
        <br />
       <div class="SubTituloMovimento">Demais Alterações</div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
            GridLines="None" Width="100%" EmptyDataText="Não há registros a exibir.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="seq_historico" HeaderText="Seq." 
                    SortExpression="seq_historico" />
                <asp:BoundField DataField="historico" HeaderText="Histórico" 
                    SortExpression="historico" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario" />
                <asp:BoundField DataField="data" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="Data" SortExpression="data" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select n.seq_historico, n.historico, u.nome_usuario, n.data
   from negociacao_cliente_historico n inner join sysusuario u on n.cod_usuario = u.cod_usuario
 where n.empresa = :empresa
  and n.cod_negociacao_cliente = :cod_negociacao
order by n.data desc">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                 <asp:SessionParameter Name=":cod_negociacao" SessionField="CodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
