Public Class WGFAQ
    Inherits System.Web.UI.Page

    Private Enum TipoCarregamentoDDL
        Sistema = 1
        Modulo = 2
        Rotina = 3
        Todos = 0
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaDDL(TipoCarregamentoDDL.Todos)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub AplicarFiltro()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            Accordion1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlSistema_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSistema.SelectedIndexChanged
        Try
            Session("SCodFAQ") = 0
            Call CarregaDDL(TipoCarregamentoDDL.Modulo)
            Call AplicarFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Session("SCodFAQ") = 0
            Call AplicarFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaDDL(ByVal tipo As TipoCarregamentoDDL)
        Try
            Dim ObjSistema As New UCLSistema
            Dim ObjRotina As New UCLRotina
            Dim ObjModulo As New UCLModulo

            If tipo = TipoCarregamentoDDL.Todos OrElse tipo = TipoCarregamentoDDL.Sistema Then
                ObjSistema.FillDropDown(DdlSistema, True, " (selecionar) ")
            End If

            If tipo = TipoCarregamentoDDL.Todos OrElse tipo = TipoCarregamentoDDL.Modulo Then
                ObjModulo.FillDropDown(DdlModulo, True, " (selecionar) ", DdlSistema.SelectedValue)
            End If

            If tipo = TipoCarregamentoDDL.Todos OrElse tipo = TipoCarregamentoDDL.Rotina Then
                ObjRotina.FillDropDown(DdlRotina, True, " (selecionar) ")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlModulo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlModulo.SelectedIndexChanged
        Try
            Session("SCodFAQ") = 0
            Call AplicarFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlRotina_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlRotina.SelectedIndexChanged
        Try
            Session("SCodFAQ") = 0
            Call AplicarFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class