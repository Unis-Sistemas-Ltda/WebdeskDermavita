Public Class WFSolicitacaoDesenvolvimentoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCSolicitacaoDesenvolvimentoFollowUp1.Acao = Session("SAcaoFollowUp")
        WUCSolicitacaoDesenvolvimentoFollowUp1.SeqFollowUp = Session("SSeqFollowUp")
    End Sub

End Class