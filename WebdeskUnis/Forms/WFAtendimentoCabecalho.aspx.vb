Public Class WFAtendimentoCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoCabecalho_Suporte1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoCabecalho_Suporte1.Acao = Session("SAcao")
    End Sub

End Class