<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimentoCabecalho_Suporte.aspx.vb" Inherits="ResultsCRM.WFAtendimentoCabecalho_Suporte" %>

<%@ Register src="../UserControls/WUCAtendimentoCabecalho.ascx" tagname="WUCAtendimentoCabecalho" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCAtendimentoCabecalho_Suporte.ascx" tagname="WUCAtendimentoCabecalho_Suporte" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
}
.Titulo
{
    font-size: 9pt;
    font-weight:bold;
    font-family: verdana;
    text-align: center;
}
.Erro
{
    font-size: 7pt;
    text-align: left;
    color: #CC0000;
    font-family: verdana;
}
.CelulaCampoCadastro
{
    text-align: left;
}
.CampoCadastro
{
    font-size: 7pt;
    height: 18px;
    font-family: verdana;
}
.Botao
{
    font-size: 7pt;
    font-weight: bold;
    text-align: center;
    background-color: #3366CC;
    color: #FFFFFF;
    font-family: verdana;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc2:WUCAtendimentoCabecalho_Suporte ID="WUCAtendimentoCabecalho_Suporte1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
