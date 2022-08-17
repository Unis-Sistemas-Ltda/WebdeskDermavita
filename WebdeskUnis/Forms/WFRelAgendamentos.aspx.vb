Public Class WFRelAgendamentos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If DdlLocal.SelectedValue = "" OrElse DdlLocal.SelectedValue = "0" Then
                Throw New Exception("Selecione o local.")
            End If

            If DdlTurma.SelectedValue = "" OrElse DdlTurma.SelectedValue = "0" Then
                Throw New Exception("Selecione a turma.")
            End If

            If DdlData.SelectedValue = "" OrElse DdlData.SelectedValue = "1900-01-01" Then
                Throw New Exception("Selecione a data.")
            End If

            If DdlHorario.SelectedValue = "" OrElse DdlHorario.SelectedValue = "0" Then
                Throw New Exception("Selecione o horário.")
            End If

            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class