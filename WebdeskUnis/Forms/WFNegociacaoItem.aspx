<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoItem.aspx.vb" Inherits="WebdeskUnis.WFNegociacaoItem" %>
<%@ Register src="../UserControls/WUCNegociacaoItem.ascx" tagname="WUCNegociacaoItem" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCNegociacaoItem ID="WUCNegociacaoItem1" 
            runat="server" />
        
    </div>
    </form>
</body>
</html>
