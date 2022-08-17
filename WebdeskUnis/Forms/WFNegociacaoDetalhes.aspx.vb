Public Class WFNegociacaoDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Call CarregaFrame(FrameDetalhe, "WFNegociacaoCabecalho.aspx")
            Session("CodNegociacao") = CodNegociacao
        End If
    End Sub

    Public ReadOnly Property CodNegociacao() As String
        Get
            Return Request.QueryString.Item("nid")
        End Get
    End Property

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        Call CarregaFrame(FrameDetalhe, pagina)
    End Sub
End Class