Public Class WGTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SAcaoTurma") = "INCLUIR"
        Session("SCodTurma") = 0
        Response.Redirect("WFTurma.aspx")
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoTurma") = e.CommandName
            Session("SCodTurma") = e.CommandArgument
            Response.Redirect("WFTurma.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim turma As New UCLTurma
            turma.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

End Class