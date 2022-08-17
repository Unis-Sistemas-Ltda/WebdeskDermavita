Public Class WGSolicitacaoDesenvolvimentoAnexo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SSeqAnexo") = e.CommandArgument
                Session("SAcaoAnexo") = e.CommandName
                Response.Redirect("WFSolicitacaoDesenvolvimentoAnexo.aspx")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objSolicitacaoDesenvolvimentoAnexo As New UCLSolicitacaoDesenvolvimentoAnexo(StrConexaoUsuario(Session("GlUsuario")))
                objSolicitacaoDesenvolvimentoAnexo.Empresa = Session("GlEmpresa")
                objSolicitacaoDesenvolvimentoAnexo.CodSolicitacao = Session("SCodSolicitacao")
                objSolicitacaoDesenvolvimentoAnexo.SeqAnexo = e.CommandArgument
                objSolicitacaoDesenvolvimentoAnexo.Excluir()
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
            LblErro.Text = "Antes de inserir um anexo, é necessário Salvar a solicitação."
            Return
        End If
        Session("SSeqAnexo") = -1
        Session("SAcaoAnexo") = "INCLUIR"
        Response.Redirect("WFSolicitacaoDesenvolvimentoAnexo.aspx?")
    End Sub

End Class