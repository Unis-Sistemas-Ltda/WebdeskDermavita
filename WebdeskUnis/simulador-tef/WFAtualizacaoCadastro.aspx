<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtualizacaoCadastro.aspx.vb" Inherits="WebdeskUnis.WFAtualizacaoCadastro" Title="Atualizacao Cadastral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="../UserControls/WUCAtualizacaoCadastroEmitente.ascx" TagName="WUCAtualizacaoCadastroEmitente"
    TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server" style="width: 100%">
    <table class="Cadastro" style="border-collapse: collapse">
        <tr>
            <td colspan="2" class="Titulo">
                Atualiza&ccedil;&atilde;o Cadastral</td>
        </tr>
        <tr>
            <td class="Instrucao" style="text-align: right;" colspan="2">
                
                <asp:Button ID="Button4" runat="server" 
                    Text="Finalizar atualiza&ccedil;&atilde;o cadastral" Width="195px" />
                
            </td>
        </tr>
        <tr>
            <td class="Erro" style="font-size: 8pt" colspan="2">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
                                            -
                
                                            Seus dados ser&atilde;o utilizados na formaliza&ccedil;&atilde;o do contrato e atualizar&atilde;o o 
                        seu cadastro junto à Unis Sistemas.<br />
                    
                                            - Caso seja 
                        necess&aacute;rio alterar alguma informa&ccedil;&atilde;o, selecione o campo desejado e proceda ao 
                                            ajuste.</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
    <uc1:WUCAtualizacaoCadastroEmitente ID="CadastroEmitente1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                -
                Clique no bot&atilde;o acima para 
                        gravar os dados gerais.<br />
                - No link 
                        &quot;Conferir e atualizar&quot;, ao lado da identifica&ccedil;&atilde;o do estabelecimento, 
                voc&ecirc; pode conferir os dados cadastrados 
                        e, se for o caso, atualizar.<br />
                - Se a sua empresa possuir 
                        outras filiais al&eacute;m das relacionadas abaixo, clique no bot&atilde;o &quot;Incluir unidade&quot;, embaixo da 
                lista, para cadastr&aacute;-las.<br />
                - Voc&ecirc; dever&aacute; ainda informar qual a unidade principal da sua empresa 
                (caso possua mais que uma unidade). Para isso 
                                                assinale a caixa &quot;Principal&quot; ao lado do nome do estabelecimento.<br />
                - Caso alguma de suas filiais dentre as listadas abaixo tenha encerrado suas 
                                                atividades, entre em contato conosco para 
                procedermos à inativação.<br />
                <br />
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="1" 
                    DataKeyNames="cod_estado,cod_cidade,cod_pais" DataSourceID="SqlDataSource1" 
                    ForeColor="Black" GridLines="Horizontal" Width="100%" Font-Size="8pt" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="CNPJ" SortExpression="cnpj">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cnpj") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCNPJ" runat="server" Text='<%# Bind("cnpj") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nome" HeaderText="Estabelecimento" 
                            SortExpression="nome" Visible="False">
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nome_cidade" HeaderText="Cidade" 
                            SortExpression="nome_cidade">
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nome_estado" HeaderText="UF" 
                            SortExpression="nome_estado" />
                        <asp:TemplateField HeaderText="Principal">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPrincipal" runat="server" 
                                Checked='<%# Bind("preferencial") %>'/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                    </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkAtualizar" runat="server" BackColor="#ECFBFF">Conferir e atualizar</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Font-Bold="True" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/imagem/bloconotas.ico" />
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" 
                    Text="Confirmo os dados cadastrais acima informados." />
            </td>
            <td style="text-align: right;">
                <asp:Button ID="BtnIncluirEstabelecimento" runat="server" 
                    Text="Incluir unidade" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT endereco_emitente.nome, 
       cidade.cod_cidade,
       cidade.cod_estado,
       cidade.cod_pais,
       cidade.nome_cidade, 
       estado.sigla as nome_estado, 
       if if exists(select 1
                      from aceite_sinamm_cnpj
                     where empresa = 1
                       and cod_planejamento = 7
                       and cod_farmacia = endereco_emitente.cod_emitente)
          then ( isnull((select preferencial
                          from aceite_sinamm_cnpj
                         where empresa = 1
                           and cod_planejamento = 7
                           and cod_farmacia = endereco_emitente.cod_emitente
                           and cnpj = endereco_emitente.cnpj),'N'))
          else isnull(endereco_emitente.preferencial_sinamm,'N') endif = 'S'
       then 'true'
       else 'false' endif as preferencial,
       endereco_emitente.cnpj
  FROM endereco_emitente, 
       cidade, 
       estado
 WHERE endereco_emitente.cod_cidade = cidade.cod_cidade 
   AND endereco_emitente.ativo = 'S'
   AND cidade.cod_estado = estado.cod_estado
   AND endereco_emitente.cod_emitente = :pCodEmitente">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="pCodEmitente" QueryStringField="e" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="vertical-align: bottom; text-align: right">
                <br />
                <asp:Button ID="Button1" runat="server" 
                    Text="Finalizar atualiza&ccedil;&atilde;o cadastral" Width="195px" />
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
