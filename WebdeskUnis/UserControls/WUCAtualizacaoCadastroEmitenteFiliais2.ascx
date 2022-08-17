<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtualizacaoCadastroEmitenteFiliais2.ascx.vb" Inherits="WebdeskUnis.WUCAtualizacaoCadastroEmitenteFiliais2" %>

<script language="jscript" src="../JSUnis.js" type="text/jscript"> </script>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />

<table cellpadding="1" cellspacing="1" class="TextoCadastro" 
    
    
    style="padding: 0px; margin: 0px; left: 0px; top: 0px; width: 100%; border-collapse: collapse; font-size: 9pt;">
    <tr>
        <td colspan="3" class="Titulo">
            Confirme os Dados da Loja</td>
    </tr>
    <tr>
        <td align="left" colspan="3" class="Erro" style="font-size: 8pt">
            <asp:Label ID="LblErro" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="3" style="font-size: 8pt">
            Campos marcados com 
            <asp:Label ID="Label27" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt"></asp:Label>
        &nbsp;n&atilde;o podem ficar em branco.</td>
    </tr>
    <tr>
        <td align="left" colspan="3" class="SubTitulo" style="font-size: 10pt">
            <asp:Label ID="Label3" runat="server" 
                Text="Dados gerais"></asp:Label>
            <asp:Label ID="LblOrgaoExp" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblCnpj" runat="server" Text="CNPJ:"></asp:Label></td>
        <td colspan="2">
            <asp:TextBox ID="TxtCnpj" runat="server" Width="140px" Enabled="False" 
                CssClass="TextoCadastro"></asp:TextBox>
            <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        &nbsp;&nbsp; <asp:Label ID="LblInscEstadual" runat="server" 
                 Text="Insc. Est.:" 
                Height="18px" ToolTip="Insc. Estadual"></asp:Label>
            <asp:TextBox ID="TxtInscEstadual" runat="server" 
                Width="120px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="-  somente n&uacute;meros" style="font-size: 7pt" 
                Height="17px"></asp:Label></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblEndereco" runat="server"  
                 
                Text="Endere&ccedil;o:"></asp:Label></td>
        <td colspan="2">
            <asp:TextBox ID="TxtEndereco" runat="server" 
                Width="275px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label21" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
            <asp:Label ID="lblCidade0" runat="server"  
                Text="Nº:" Height="18px"></asp:Label>
            <asp:TextBox ID="TxtNumero" runat="server" CssClass="TextoCadastro" 
                Width="40px"></asp:TextBox>
            <asp:Label ID="Label36" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            Complemento:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtComplemento" runat="server" 
                Width="275px" CssClass="TextoCadastro" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblEstado" runat="server"  
                Text="Estado:"></asp:Label></td>
        <td colspan="2">
            <asp:DropDownList ID="DdlEstado" runat="server" 
                Width="55px" AutoPostBack="True" CssClass="TextoCadastro" >
            </asp:DropDownList>
            <asp:Label ID="Label23" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
            <asp:Label ID="lblCidade" runat="server"  
                Text="Cidade:" Height="18px"></asp:Label>
            <asp:DropDownList ID="DdlCidade" runat="server" 
                Width="250px" AutoPostBack="True" CssClass="TextoCadastro" >
            </asp:DropDownList>
            <asp:Label ID="Label24" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblCep" runat="server"  
                Text="CEP:"></asp:Label></td>
        <td colspan="2">
            <asp:TextBox ID="TxtCep" runat="server"  
                Width="100px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label25" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblTelefone" runat="server"  
                Text="Telefone Principal:"></asp:Label></td>
        <td colspan="2">
            <asp:TextBox ID="TxtTelefone" runat="server" 
                Width="100px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label26" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        &nbsp;
            <asp:Label ID="LblTelefone2" runat="server" 
                 Text="Telefone alternativo:" Height="18px"></asp:Label>
            <asp:TextBox ID="TxtTelefone2" runat="server" 
                Width="100px" CssClass="TextoCadastro" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            E-mail para contato:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtEmail" runat="server" 
                Width="350px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label29" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
            </td>
    </tr>
    <tr>
        <td align="right">
            E-mail financeiro:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtEmailFinanceiro" runat="server" 
                Width="350px" CssClass="TextoCadastro" ></asp:TextBox>
            <asp:Label ID="Label35" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
            </td>
    </tr>
    <tr>
        <td align="right">
            Quantidade de PDVs (caixas):</td>
        <td colspan="2">
            <asp:TextBox ID="TxtQtdPDV" runat="server" CssClass="TextoCadastro" 
                Width="40px"></asp:TextBox>
            <asp:Label ID="Label33" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="SubTitulo" colspan="3" style="font-size: 10pt">
            Dados da 
            empresa fornecedora do sistema utilizado no caixa da sua loja</td>
    </tr>
    <tr>
        <td align="right">
            Nome da empresa fornecedora do sistema:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtNomeEmpresaSoftware" runat="server" 
                CssClass="TextoCadastro" Width="350px"></asp:TextBox>
            <asp:Label ID="Label37" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            Nome da pessoa para contato na empresa fornecedora do sistema:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtPessoaContatoSoftware" runat="server" 
                CssClass="TextoCadastro" Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            Telefone(s) da empresa fornecedora do sistema:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtTelefoneSoftware" runat="server" CssClass="TextoCadastro" 
                Width="200px"></asp:TextBox>
            <asp:Label ID="Label38" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            E-mail da empresa fornecedora do sistema:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtEmailSoftware" runat="server" CssClass="TextoCadastro" 
                Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
     <tr>
        <td colspan="3" class="SubTitulo" style="font-size: 10pt">
            Dados bancários para crédito dos recebíveis</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Banco:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtBanco" runat="server" CssClass="TextoCadastro" 
                Width="200px"></asp:TextBox>
            <asp:Label ID="Label30" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nº Agência:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtAgencia" runat="server" CssClass="TextoCadastro"></asp:TextBox>
            <asp:Label ID="Label32" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        &nbsp;<asp:Label ID="LblInscEstadual0" runat="server" 
                 Text="Ex: 1234-5" 
                Height="18px" ToolTip="Insc. Estadual"></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nº da Conta Corrente:</td>
        <td colspan="2">
            <asp:TextBox ID="TxtContaCorrente" runat="server" CssClass="TextoCadastro"></asp:TextBox>
            <asp:Label ID="Label31" runat="server" Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="18px"></asp:Label>
        &nbsp;<asp:Label ID="LblInscEstadual1" runat="server" 
                 Text="Ex: 12345-6" 
                Height="18px" ToolTip="Insc. Estadual"></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="SubTitulo" colspan="3" style="font-size: 10pt">
            Marque abaixo os cartões aceitos na loja<asp:Label ID="Label34" runat="server" 
                Font-Bold="False"  Font-Size="XX-Small"
                ForeColor="Red" Text="*" 
                style="font-size: 7pt" Height="22px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataKeyNames="cod_bandeira" DataSourceID="SqlDataSource1" 
                ForeColor="Black" GridLines="Horizontal" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Marcar">
                        <ItemTemplate>
                            <asp:CheckBox ID="CbxSelecionado" runat="server" 
                                Checked='<%# Bind("is_checked") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cartão/Bandeira" SortExpression="descricao">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblDescricaoBandeira" runat="server" 
                                Text='<%# Bind("descricao") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="LblCodBandeira" runat="server" 
                                Text='<%# Eval("cod_bandeira") %>' Visible="False"></asp:Label>
                            <asp:Label ID="LblCodAdquirente" runat="server" 
                                Text='<%# Eval("cod_adquirente") %>' Visible="False"></asp:Label>
                            <asp:Label ID="Label28" runat="server" Height="17px" 
                                Text="Selecione a adquirente:&nbsp;" 
                                Visible='<%# Eval("selecionar_adquirente") %>'></asp:Label>
                            <asp:DropDownList ID="DdlAdquirente" runat="server" CssClass="TextoCadastro" 
                                DataSourceID="SqlDataSource2" Visible='<%# Eval("selecionar_adquirente") %>' 
                                Width="180px" DataTextField="nome_autorizadora" 
                                DataValueField="cod_adquirente" 
                                SelectedValue='<%# Bind("cod_adquirente") %>'>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                                SelectCommand=" select 0 cod_adquirente, '(Selecione)' nome_autorizadora
                                                  from dummy
                                                 union all
                                                select tab.cod_adquirente, ta.nome_autorizadora
                                                  from tef_adquirente_bandeira tab inner join tef_adquirente ta on tab.cod_adquirente = ta.cod_adquirente
                                                 where tab.cod_bandeira = :cod_bandeira
                                                 order by cod_adquirente">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="LblCodBandeira" Name=":cod_bandeira" 
                                        PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Label ID="Label29" runat="server" Height="17px" Text="Descrever:&nbsp;" 
                                Visible='<%# Eval("is_outros") %>'></asp:Label>
                            <asp:TextBox ID="TxtOutros" runat="server" CssClass="TextoCadastro" 
                                Width="180px" Text='<%# Bind("texto_outros") %>' 
                                Visible='<%# Eval("is_outros") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select t.cod_bandeira,
        t.descricao,

        (select count(1) from tef_adquirente_bandeira tab where tab.cod_bandeira = t.cod_bandeira) qtd_adquirente_por_bandeira,

        if t.cod_adquirente_padrao is null then
           if qtd_adquirente_por_bandeira &gt; 1 then 'True' else 'False' endif
        else
           'False'
        endif selecionar_adquirente,

        if t.cod_bandeira in (1,2) or exists(select 1 from adesao_tef_bandeira where empresa = :empresa and cod_emitente = :cod_emitente and cnpj = :cnpj and cod_bandeira = t.cod_bandeira) then
           'True'
        else
           'False'
        endif is_checked,

        isnull((select cod_adquirente from adesao_tef_bandeira where empresa = :empresa and cod_emitente = :cod_emitente and cnpj = :cnpj and cod_bandeira = t.cod_bandeira),isnull(t.cod_adquirente_padrao,case qtd_adquirente_por_bandeira when 0 then 0 when 1 then (select cod_adquirente from tef_adquirente_bandeira tab where tab.cod_bandeira = t.cod_bandeira) else 0 end)) cod_adquirente,

        if isnull(t.outros, 'N') = 'S' then 'True' else 'False' endif is_outros,

        (select list(distinct outros) from adesao_tef_bandeira where empresa = :empresa and cod_emitente = :cod_emitente and cnpj = :cnpj and cod_bandeira = t.cod_bandeira) texto_outros
   from tef_bandeira t
  order by t.sequencia">
                <SelectParameters>
                    <asp:Parameter ConvertEmptyStringToNull="False" DbType="String" 
                        DefaultValue="1" Name=":empresa" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cod_emitente" QueryStringField="emitente" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cnpj" QueryStringField="cnpj" />
                    <asp:Parameter ConvertEmptyStringToNull="False" DbType="String" 
                        DefaultValue="1" Name=":empresa" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cod_emitente" QueryStringField="emitente" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cnpj" QueryStringField="cnpj" />
                    <asp:Parameter ConvertEmptyStringToNull="False" DbType="String" 
                        DefaultValue="1" Name=":empresa" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cod_emitente" QueryStringField="emitente" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cnpj" QueryStringField="cnpj" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </td>
    </tr>
    <tr>
        <td class="SubTitulo" colspan="3" style="font-size: 10pt">
            Clique abaixo em Confirmar Dados para prosseguir com a contratação</td>
    </tr>
    <tr>
        <td align="right">
            <asp:TextBox ID="TxtInscMunicipal" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="TxtFuncionamento" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="TxtNomeRespTec" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="TxtCpfRespTec" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="TxtCrf" runat="server"  
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox>
            <asp:DropDownList ID="DdlEstadoCrf" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" >
            </asp:DropDownList>
            <asp:TextBox ID="TxtEspecial" runat="server" 
                Width="20px" CssClass="TextoCadastro" Visible="False" ></asp:TextBox></td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" Text="Confirmar Dados" 
                BackColor="#009933" Font-Size="10pt" ForeColor="White" Height="30px" />
            </td>
        <td style="text-align: right">
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Font-Size="9pt" />
            </td>
    </tr>
    <tr>
        <td align="right" colspan="3">
            <br />
            <br />
        </td>
    </tr>
    </table>

