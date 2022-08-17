Public Class WFSolicitacaoDesenvolvimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCSolicitacaoDesenvolvimento1.Acao = Session("SAcao")
        WUCSolicitacaoDesenvolvimento1.CodSolicitacao = Session("SCodSolicitacao")
    End Sub

End Class