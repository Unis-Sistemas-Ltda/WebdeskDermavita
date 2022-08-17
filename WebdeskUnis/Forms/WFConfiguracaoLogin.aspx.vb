Public Partial Class WFConfiguracaoLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaFormulario()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CarregaFormulario()
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente

            objEnderecoEmitente.CodEmitente = Session("GlCodEmitente")
            objEnderecoEmitente.CNPJ = Session("GlCNPJ")
            If objEnderecoEmitente.Buscar() Then
                TxtEmail.Text = objEnderecoEmitente.EmailLogin
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Function isDigitacaoOk() As Boolean
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente
            objEnderecoEmitente.CodEmitente = Session("GlEmitente")
            objEnderecoEmitente.CNPJ = Session("GlCNPJ")

            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtEmail.Text) Then
                LblErro.Text += "Informe seu endereço de e-mail. <br/>"
            ElseIf Not TxtEmail.Text.IsValidEmail Then
                LblErro.Text += "O endereço de e-mail informado não é valido. <br/>"
            Else
                objEnderecoEmitente.EmailLogin = TxtEmail.Text
                If Not objEnderecoEmitente.EmailEstaDisponivel Then
                    LblErro.Text += "O endereço de e-mail informado já consta em outro cadastro. Por favor informe outro e-mail. <br/>"
                End If
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub GravaDados()
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente

            objEnderecoEmitente.CodEmitente = Session("GlEmitente")
            objEnderecoEmitente.CNPJ = Session("GlCNPJ")
            If objEnderecoEmitente.Buscar() Then
                objEnderecoEmitente.EmailLogin = TxtEmail.Text
                objEnderecoEmitente.Alterar()
                LblErro.Text = "Configurações de Login salvas com sucesso."
                Return
            End If

            LblErro.Text = "Ocorreu um problema. Por favor entre em contato com o suporte."

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalvar.Click
        Try
            If isDigitacaoOk() Then
                Call GravaDados()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class