<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTurma.aspx.vb" Inherits="WebdeskUnis.WFTurma" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
    <link href="../Ajax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Titulo">&nbsp;Turma<asp:ScriptManager ID="ScriptManager1" 
            runat="server">
        </asp:ScriptManager>
    </div>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br /><br />
        <asp:Label ID="Label5" runat="server" Text="Local:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlEstabelecimento" runat="server" 
            CssClass="CampoCadastro" Width="250px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Código:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CampoCadastro" 
            Width="45px" Enabled="False"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Situação:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
            Width="78px">
            <asp:ListItem Selected="True" Value="1">Ativa</asp:ListItem>
            <asp:ListItem Value="2">Inativa</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Descrição:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
            Width="245px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Capacidade:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:TextBox ID="TxtCapacidade" runat="server" CssClass="CampoCadastro" 
            Width="45px" MaxLength="3"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Data:" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" style="text-align:center" Width="70px"></asp:TextBox>
        <cc1:MaskedEditExtender ID="TxtData_MaskedEditExtender" runat="server" 
            BehaviorID="TxtData_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
            MaskType="Date" TargetControlID="TxtData" UserDateFormat="DayMonthYear">
        </cc1:MaskedEditExtender>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Narrativa:" Width="120px" 
            Style="text-align: right; vertical-align: top" Height="95px"></asp:Label>
        <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
            Height="95px" TextMode="MultiLine" Width="245px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Width="120px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
&nbsp;
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Width="120px" 
            Style="text-align: right" Height="17px" Font-Bold="True">Horários</asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Width="155px" 
            Style="text-align: right" Height="17px"><b>Incluir Horário </b> - Início:&nbsp;</asp:Label>
        <asp:TextBox ID="TxtHoraInicio" runat="server" CssClass="CampoCadastro" 
            Width="45px"></asp:TextBox>
        <cc1:MaskedEditExtender ID="TxtHoraInicio_MaskedEditExtender" runat="server" 
            BehaviorID="TxtHoraInicio_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99:99" 
            MaskType="Time" TargetControlID="TxtHoraInicio" UserTimeFormat="TwentyFourHour">
        </cc1:MaskedEditExtender>
        <asp:Label ID="Label11" runat="server" Text="Término:&nbsp;" Width="65px" 
            Style="text-align: right" Height="17px"></asp:Label>
        <asp:TextBox ID="TxtHoraTermino" runat="server" CssClass="CampoCadastro" 
            Width="45px"></asp:TextBox>
        <cc1:MaskedEditExtender ID="TxtHoraTermino_MaskedEditExtender" runat="server" 
            BehaviorID="TextBox1_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99:99" 
            MaskType="Time" TargetControlID="TxtHoraTermino" 
            UserTimeFormat="TwentyFourHour">
        </cc1:MaskedEditExtender>
&nbsp;<asp:Button ID="Button1" runat="server" Text="Incluir" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select seq_horario, hora_inicio, hora_termino
  from turma_horario
 where empresa = :empresa
   and cod_turma = :cod_turma
order by seq_horario">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtCodigo" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_turma" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
            GridLines="Horizontal" Width="100%">
            <Columns>
                <asp:BoundField DataField="seq_horario" HeaderText="Seq." 
                    SortExpression="seq_horario">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_inicio" HeaderText="Início" 
                    SortExpression="hora_inicio">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_termino" HeaderText="Término" 
                    SortExpression="hora_termino">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Excluir">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_horario") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
        <br />
    </div>
    </form>
</body>
</html>
