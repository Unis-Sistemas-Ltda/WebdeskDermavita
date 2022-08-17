Public Class WFLogin388
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim auto As Boolean
            Call SetaDsnAplicacao()

            If Session("SConectaAuto") = "True" Or Session("SConectaAuto") = "False" Then
                auto = Session("SConectaAuto")
            Else
                auto = False
            End If

            If auto Then
                TxtLogin.Text = Session("SCNPJConexao")
                Conectar(auto)
            End If
        End If
    End Sub

    Private Enum TipoLogin As Short
        CNPJ = 1
        Email = 2
    End Enum

    Private Sub Conectar(ByVal auto As Boolean)
        Dim Login As String
        Dim Senha As String
        Dim Erro As Boolean = False
        Dim objEnderecoEmitente As New UCLEnderecoEmitente
        Dim CodEmitente As String
        Dim tipo As TipoLogin

        Login = TxtLogin.Text
        Senha = TxtSenha.Text

        LblErro.Text = ""

        tipo = TipoLogin.CNPJ

        If Login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "") = "" Then
            LblErro.Text += "Preencha o campo Login.<br/>"
            Erro = True
        Else
            If Not IsNumeric(Login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "")) Then
                If Login.IsValidEmail Then
                    tipo = TipoLogin.Email
                Else
                    LblErro.Text += "CNPJ/Email inválido.<br/>"
                    Erro = True
                End If
            ElseIf IsNumeric(Login) AndAlso CDbl(Login) = 0 Then
                LblErro.Text += "CNPJ/Email inválido.<br/>"
                Erro = True
            Else
                Login = Login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "")
            End If
        End If

        If Not auto AndAlso Senha = "" Then
            LblErro.Text += "Preencha o campo Senha.<br/>"
            Erro = True
        End If

        If Not Erro Then

            CodEmitente = objEnderecoEmitente.GetCodEmitente(Login, IIf(tipo = TipoLogin.Email, UCLEnderecoEmitente.TipoBusca.Email, UCLEnderecoEmitente.TipoBusca.CNPJ))
            objEnderecoEmitente.CodEmitente = CodEmitente

            If tipo = TipoLogin.Email Then
                objEnderecoEmitente.EmailLogin = Login
            Else
                objEnderecoEmitente.CNPJ = Login
            End If

            If Not objEnderecoEmitente.Buscar() Then 'Não encontrou
                CodEmitente = objEnderecoEmitente.GetCodEmitente(Right(Login, 11), IIf(tipo = TipoLogin.Email, UCLEnderecoEmitente.TipoBusca.Email, UCLEnderecoEmitente.TipoBusca.CNPJ))
                objEnderecoEmitente.CodEmitente = CodEmitente
                If tipo = TipoLogin.Email Then
                    objEnderecoEmitente.EmailLogin = Login
                Else
                    objEnderecoEmitente.CNPJ = Right(Login, 11)
                End If

                If Not objEnderecoEmitente.Buscar() Then 'Não encontrou
                    LblErro.Text += "CNPJ/Email não encontrado.<br/>"
                    Erro = True
                Else
                    If Not auto AndAlso Senha <> objEnderecoEmitente.Senha Then
                        LblErro.Text += "Senha não confere.<br/>"
                        Erro = True
                    End If

                    If Not Erro Then
                        Senha = objEnderecoEmitente.Senha
                        Call CarregaVariaveisGlobais(objEnderecoEmitente.CNPJ, objEnderecoEmitente.EmailLogin, Senha, CodEmitente, objEnderecoEmitente.RazaoSocial, 1, 1, objEnderecoEmitente.CodPais, objEnderecoEmitente.CodEstado, objEnderecoEmitente.CodCidade)
                        FormsAuthentication.RedirectFromLoginPage(Right(Login, 11), False)
                    End If
                End If
            Else
                If Not auto AndAlso Senha <> objEnderecoEmitente.Senha Then
                    LblErro.Text += "Senha não confere.<br/>"
                    Erro = True
                End If

                If Not Erro Then
                    Senha = objEnderecoEmitente.Senha
                    Call CarregaVariaveisGlobais(objEnderecoEmitente.CNPJ, objEnderecoEmitente.EmailLogin, Senha, CodEmitente, objEnderecoEmitente.RazaoSocial, 1, 1, objEnderecoEmitente.CodPais, objEnderecoEmitente.CodEstado, objEnderecoEmitente.CodCidade)
                    FormsAuthentication.RedirectFromLoginPage(Login, False)
                End If
            End If
        End If
    End Sub

    Protected Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click
        Call Conectar(False)
    End Sub

    Private Sub CarregaVariaveisGlobais(ByVal CNPJ As String, ByVal email As String, ByVal senha As String, ByVal CodEmitente As String, ByVal NomeCliente As String, ByVal Empresa As String, ByVal Estabelecimento As String, codPais As String, codEstado As String, codCidade As String)
        Dim objEmpresa As New UCLEmpresa()

        objEmpresa.CodEmpresa = Empresa
        objEmpresa.Buscar()

        Session("GlCNPJ") = CNPJ
        Session("GlSenhaAcesso") = senha
        Session("GlEmpresa") = Empresa
        Session("GlRazaoSocial") = objEmpresa.RazaoSocial
        Session("GlEstabelecimento") = Estabelecimento
        Session("GlNomeCliente") = NomeCliente
        Session("GlEmitente") = CodEmitente
        Session("GlEmailAcesso") = email
        Session("GlCodPais") = codPais
        Session("GlCodEstado") = codEstado
        Session("GlCodCidade") = codCidade
        Call CarregaInfoEnvioEmail(objEmpresa.CodEmpresa)
    End Sub

    Private Sub CarregaInfoEnvioEmail(ByVal empresa As String)
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim strSql As String = "select smtp, utiliza_ssl ssl, porta_envio from parametros_email where empresa = " + empresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("ssl")) Then
                    Session("GlUtilizaSSL") = dt.Rows.Item(0).Item("ssl").ToString
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("porta_envio")) Then
                    Session("GlPortaEnvioEmail") = dt.Rows.Item(0).Item("porta_envio").ToString
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("smtp")) Then
                    Session("GlSTMP") = dt.Rows.Item(0).Item("smtp").ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnEsqueciMinhaSenha_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEsqueciMinhaSenha.Click
        If IsNumeric(TxtLogin.Text.Replace("/", "").Replace("\", "").Replace(".", "").Replace("-", "").Replace(" ", "")) Then
            Session("GlCNPJ") = TxtLogin.Text.Replace("/", "").Replace("\", "").Replace(".", "").Replace("-", "").Replace(" ", "")
        End If
        Response.Redirect("Forms/WFNovaSenha.aspx")
    End Sub
End Class