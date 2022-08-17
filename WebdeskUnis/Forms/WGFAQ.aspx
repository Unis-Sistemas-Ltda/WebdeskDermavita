<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGFAQ.aspx.vb" Inherits="WebdeskUnis.WGFAQ" %>

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
    <div tyle="padding: 15px;" class="Titulo">Dúvidas Frequentes
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <div style="padding: 15px;">
        <br />
        Faça sua pesquisa, informando os filtros abaixo.<br />
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" ID="Lbl1" style="text-align:right; padding-right: 3px"
            Text="Sistema:" Height="19px" Width="65px"></asp:Label>
        <asp:DropDownList ID="DdlSistema" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Label runat="server" ID="Lbl3" style="text-align:right; padding-right: 3px"
            Text="Módulo:" Height="19px" Width="100px"></asp:Label>
        <asp:DropDownList ID="DdlModulo" runat="server" CssClass="CampoCadastro" 
            Width="270px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="Lbl4" style="text-align:right; padding-right: 3px"
            Text="Rotina:" Height="19px" Width="65px"></asp:Label>
        <asp:DropDownList ID="DdlRotina" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Label runat="server" ID="Lbl2" style="text-align:right; padding-right: 3px"
            Text="Palavras-chave:" Height="19px" Width="100px"></asp:Label>
        <asp:TextBox ID="TxtPesquisa" runat="server" CssClass="CampoCadastro" 
            Width="170px"></asp:TextBox>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Pesquisar" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select :sistema sist,
       :modulo mod,
       :rotina rot,
       replace(replace(replace(:palavras,' ','%'),'+','%'),',','%') chave,
       :cod_faq faq_id,
       cod_faq,
       cod_faq || ' - ' || pergunta as pergunta,
       replace(replace(replace(replace(resposta,'\&quot;','&quot;'),'\'||char(39),char(39)),'#anexo#','&lt;a href=&quot;http://matriz.unissistemas.com.br/crm/FAQ/Arquivos/' + f_nome_arquivo(anexo) +'&quot;&gt;Visualizar arquivo&lt;/a&gt;'),'&lt;a href=','&lt;a target=&quot;_blank&quot; href=') resposta
  from faq f
 where ( sist = 0 or exists(select 1 from faq_sistema where cod_faq = f.cod_faq and cod_sistema = sist) )
   and ( mod  = 0 or exists(select 1 from faq_modulo  where cod_faq = f.cod_faq and cod_modulo  = mod ) )
   and ( rot  = 0 or exists(select 1 from faq_rotina  where cod_faq = f.cod_faq and cod_rotina  = rot ) )
   and ( trim(chave) = '' or pergunta like '%' ||chave||'%' or resposta like '%'||chave||'%' )
   and ( trim(isnull(faq_id,'0')) in ('0','') or f.cod_faq =faq_id )
 order by pergunta">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlSistema" Name=":sistema" 
                    PropertyName="SelectedValue" ConvertEmptyStringToNull="False" 
                    DbType="String" />
                <asp:ControlParameter ControlID="DdlModulo" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":modulo" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlRotina" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":rotina" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtPesquisa" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":palavras" PropertyName="Text" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    DefaultValue="0" Name=":cod_faq" SessionField="SCodFAQ" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="padding:15px">
        <asp:Accordion ID="Accordion1" runat="server" Height="175px" Width="100%" 
            DataSourceID="SqlDataSource1" ContentCssClass="Resposta" 
            HeaderCssClass="LinkFAQ">
            <HeaderTemplate><i><b style="font-size: 8pt"><%#DataBinder.Eval(Container.DataItem, "pergunta")%></b></i><br /><br />
            </HeaderTemplate> 
            <ContentTemplate>
                <asp:Label runat="server" id="LblConteudoResposta" Text='<%# Eval("resposta") %>'></asp:Label> <br /><br /></ContentTemplate> 
        </asp:Accordion>
    </div>
    </div>
    </form>
</body>
</html>