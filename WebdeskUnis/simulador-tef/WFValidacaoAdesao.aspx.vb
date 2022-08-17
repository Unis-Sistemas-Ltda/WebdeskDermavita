Public Class WFValidacaoAdesao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            If objAdesaoTEFEmitente.Buscar(1, Request.QueryString.Item("e")) Then
                If objAdesaoTEFEmitente.GetConteudo("cod_emitente") = Request.QueryString.Item("e") Then
                    objAdesaoTEFEmitente.SetConteudo("ip_validacao", Request.UserHostAddress)
                    objAdesaoTEFEmitente.SetConteudo("validado", "S")
                    objAdesaoTEFEmitente.SetConteudo("data_validacao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
                    objAdesaoTEFEmitente.Alterar()
                Else
                    LblErro.Text = "Erro: código de emitente do link validado (" + Request.QueryString.Item("e") + ") diverge do código de emitente da adesão encontrada (adesão " + Request.QueryString.Item("s") + "). Por gentileza entre em contato conosco pelo e-mail comercial.tef@unisnet.com.br ou pelo telefone (48) 3664-3000."
                    LblErro.ForeColor = Drawing.Color.Red
                End If
            Else
                LblErro.Text = "Erro: adesão não encontrada (" + Request.QueryString.Item("s") + "). Por gentileza entre em contato conosco pelo e-mail comercial.tef@unisnet.com.br ou pelo telefone (48) 3664-3000."
                LblErro.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
            LblErro.ForeColor = Drawing.Color.Red
        End Try
        
    End Sub

End Class