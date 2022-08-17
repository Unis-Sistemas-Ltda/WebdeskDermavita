<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFCadastroEmitente.aspx.vb" Inherits="WebdeskUnis.WFCadastroEmitente" %>
<%@ Register src="../UserControls/WUCCadastroEmitente.ascx" tagname="WUCCadastroEmitente" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <uc1:WUCCadastroEmitente ID="WUCCadastroEmitente1" runat="server" />
    </div>
    </form>
</body>
</html>
