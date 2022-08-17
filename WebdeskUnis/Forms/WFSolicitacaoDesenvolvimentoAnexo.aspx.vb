Public Class WFSolicitacaoDesenvolvimentoAnexo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCSolicitacaoDesenvolvimentoAnexo1.Acao = Session("SAcaoAnexo")
        WUCSolicitacaoDesenvolvimentoAnexo1.SeqAnexo = Session("SSeqAnexo")
    End Sub

End Class