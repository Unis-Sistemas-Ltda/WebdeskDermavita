Public Class WGNegociacaoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        If e.CommandName = "ALTERAR" Then
            Session("SSeqItemNegociacao") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoItem.aspx")
        End If
    End Sub


End Class