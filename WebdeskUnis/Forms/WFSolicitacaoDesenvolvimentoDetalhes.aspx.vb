Public Class WFSolicitacaoDesenvolvimentoDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhe, "WFSolicitacaoDesenvolvimento.aspx")
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        If Not String.IsNullOrWhiteSpace(e.Item.Value) Then
            Call CarregaFrame(FrameDetalhe, pagina)
        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancelar.Click
        Server.Transfer("WGSolicitacaoDesenvolvimento.aspx", False)
    End Sub

End Class