Partial Public Class WGSolicitacaoDesenvolvimentoFollowUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SSeqFollowUp") = e.CommandArgument
                Session("SAcaoFollowUp") = e.CommandName
                Response.Redirect("WFSolicitacaoDesenvolvimentoFollowUp.aspx")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objSolicitacaoDesenvolvimentoFollowUp As New UCLSolicitacaoDesenvolvimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
                objSolicitacaoDesenvolvimentoFollowUp.Empresa = Session("GlEmpresa")
                objSolicitacaoDesenvolvimentoFollowUp.CodSolicitacao = Session("SCodSolicitacao")
                objSolicitacaoDesenvolvimentoFollowUp.SeqFollowUp = e.CommandArgument
                objSolicitacaoDesenvolvimentoFollowUp.Excluir()
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodSolicitacao") = -1 Then
            LblErro.Text = "Antes de inserir um follow-up, é necessário Salvar a solicitação."
            Return
        End If
        Session("SSeqFollowUp") = -1
        Session("SAcaoFollowUp") = "INCLUIR"
        Response.Redirect("WFSolicitacaoDesenvolvimentoFollowUp.aspx?")
    End Sub
End Class