Public Class WFAtualizacaoCadastralUnidade1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtualizacaoCadastroEmitenteFiliais21.pCNPJ = Request.QueryString.Item("cnpj").ToString
        WUCAtualizacaoCadastroEmitenteFiliais21.pEmitente = Request.QueryString.Item("emitente").ToString
        WUCAtualizacaoCadastroEmitenteFiliais21.TipoExibicao = "S"

        Select Case WUCAtualizacaoCadastroEmitenteFiliais21.pCNPJ
            Case "-1"
                WUCAtualizacaoCadastroEmitenteFiliais21.Modo = ModoFormulario.Inclusao
            Case Else
                WUCAtualizacaoCadastroEmitenteFiliais21.Modo = ModoFormulario.ConsultaAlteracao
        End Select
    End Sub

End Class