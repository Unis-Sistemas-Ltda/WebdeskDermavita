Public Class WGManual02
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ObjRotina As New UCLRotina
            ObjRotina.Buscar(Session("SM_CodRotina"))
            LblNomeRotina.Text = ObjRotina.GetConteudo("nome")
            LblDescricaoRotina.Text = ObjRotina.GetConteudo("descricao")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGManual01.aspx")
    End Sub
End Class