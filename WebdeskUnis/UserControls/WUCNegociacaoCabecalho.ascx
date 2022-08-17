<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoCabecalho.ascx.vb" Inherits="WebdeskUnis.WUCNegociacaoCabecalho" %>
<link href="../CSSUnis.css" rel="stylesheet" type="text/css" />
<table style="width: 100%; border-collapse: collapse;" 
        class="TextoCadastro_BGBranco">
    <tr>
        <td class="auto-style1" colspan="4">           
              <asp:Label ID="LblErro" runat="server" 
                Font-Bold="False" ForeColor="Red" Visible="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 195px;">
            Nº Negociação:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" width="300px;">
            <asp:Label ID="LblNrNegociacao" runat="server" Font-Bold="False" 
                Font-Size="8pt" Width="75px"></asp:Label>
        &nbsp;
        </td>       
    </tr>
    <tr>
        <td style="text-align: right">
            Data Cadastramento:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:Label ID="LblDataCadastramento" runat="server" Font-Bold="False" 
                Font-Size="8pt"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td style="text-align: right" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>        
    </tr>  
     <tr>
        <td style="text-align: right; background-color: #FBFBF9;">
            <asp:Label ID="Label5" runat="server" Text="Cliente:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px" Enabled="false"></asp:TextBox>
          
        </td>
      
    </tr> 
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;" valign="top">
            Nome:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;" valign="top">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False"></asp:Label>
        </td>
       
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;" valign="top" >
            Endereço:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;">
            <asp:Label ID="LblEndereco" runat="server"></asp:Label>
        </td>       
    </tr>   
     <tr>
        <td class="style1" style="text-align: right; background-color: #FBFBF9;" >
            <span style="text-align: right">Contato:</span></td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="240px" AutoPostBack="True" Enabled="false">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style1" style="text-align: right; background-color: #FBFBF9;" >
            <asp:Label ID="Label12" runat="server" Text="Telefone(s):"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:Label ID="LblTelefone" runat="server"></asp:Label> - 
            <asp:Label ID="LblCelular" runat="server"></asp:Label>
        </td>       
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;">
            E-mail:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;">
            <asp:Label ID="LblEmail" runat="server"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;" >
            Manter informado (e-mail):</td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:TextBox ID="TxtManterInformado" runat="server" CssClass="CampoCadastro" 
                Width="240px" MaxLength="200"
                
                
                ToolTip="Informe aqui o(s) emails(s). Existindo mais de um endereço de email, utilize ponto-e-vírgula como separador."></asp:TextBox>
        </td>        
    </tr>
    <tr>
        <td style="text-align: right" >
            <asp:Label ID="LBlEtapa" runat="server" Text="Etapa:" Visible="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
             <asp:DropDownList ID="DdlEtapa" runat="server" CssClass="CampoCadastro" 
                Width="240px" AutoPostBack="True" Enabled="false">
            </asp:DropDownList>
        </td>       
    </tr>   
    <tr>
        <td style="text-align: right" >
             <asp:Label ID="LblRepresentante" runat="server" Height="16px" style="text-align: right"
                Text="Vendedor/Representante:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlRepresentante" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>     
    </tr>
    <tr>
        <td style="text-align: right" >
            Agente de Vendas:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAgente" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>       
    </tr>
    <tr>
        <td style="text-align: right" >
             <asp:Label ID="LblCanalVenda" runat="server" Height="16px" style="text-align: right"
                Text="Canal de Venda:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCanalVenda" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>       
    </tr>    
    
    <tr>
        <td style="text-align: right" >
            <asp:Label ID="LblMoeda" runat="server" Text="Moeda:" Height="16px" style="text-align:right"
                Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlMoeda" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>       
    </tr>
    <tr>
        <td style="text-align: right" >
            <asp:Label ID="LblFormaPagto" runat="server" Text="Forma de Pagamento:" 
                style="text-align:right"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFormaPagto" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>      
    </tr>
    <tr>
        <td style="text-align: right" >
             <asp:Label ID="LblCondicaoPagto" runat="server" Text="Condição de Pagamento:" Height="16px" style="text-align:right"
                ></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCondicaoPagto" runat="server" CssClass="CampoCadastro" 
                Width="240px" Enabled="false">
            </asp:DropDownList>
        </td>       
    </tr>
    <tr>
        <td style="text-align: right" >              
            </td>
        <td class="CelulaCampoCadastro">
                    </td>        
    </tr>
    <tr>
        <td style="text-align: right" >
            <asp:Label ID="LblFrete" runat="server" Height="16px" Text="Frete:" 
                style="text-align: right"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFrete" runat="server" CssClass="CampoCadastro" 
                Width="80px" Enabled="false">
                <asp:ListItem Value="1">CIF</asp:ListItem>
                <asp:ListItem Value="2">FOB</asp:ListItem>
            </asp:DropDownList>
        </td>       
    </tr>
    <tr>
        <td style="text-align: right" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        </td>
        
    </tr>
    </table>