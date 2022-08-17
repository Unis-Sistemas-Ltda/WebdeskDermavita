Public Class WGNegociacaoDespesa
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        'Dim objNegociacaoDespesa As New UCLNegociacaoClienteDespesas
        'If e.CommandName = "ALTERAR" Then
        '    Session("SNegCodTipoDespAcess") = e.CommandArgument
        '    Session("SAcaoDespesa") = "ALTERAR"
        '    Response.Redirect("WFNegociacaoDespesa.aspx")
        'ElseIf e.CommandName = "EXCLUIR" Then
        '    objNegociacaoDespesa.Excluir(Session("GlEmpresa"), Session("SEstabelecimentoNegociacao"), Session("SCodNegociacao"), e.CommandArgument)

        '    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        '    SqlDataSource1.DataBind()
        '    GridView1.DataBind()
        'End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SNegCodTipoDespAcess") = -1
            Session("SAcaoDespesa") = "INCLUIR"
            Response.Redirect("WFNegociacaoDespesa.aspx")
        Else
            LblErro.Text = "Não é permitido incluir uma despesa antes de salvar o cabeçalho da negociação."
        End If

    End Sub

End Class