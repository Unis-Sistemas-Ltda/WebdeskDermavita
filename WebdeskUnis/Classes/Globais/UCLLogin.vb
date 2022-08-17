Public Class UCLLogin
    Inherits System.Web.UI.Page

    Public Enum TipoLogin As Short
        CNPJ = 1
        Email = 2
    End Enum

    Public Function Conectar(ByVal login As String, senha As String, ByVal auto As Boolean, ByRef LblErro As Label) As Boolean
        Dim Erro As Boolean = False
        Dim objEnderecoEmitente As New UCLEnderecoEmitente
        Dim CodEmitente As String
        Dim tipo As TipoLogin

        LblErro.Text = ""

        tipo = TipoLogin.CNPJ

        If login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "") = "" Then
            LblErro.Text += "Preencha o campo Login.<br/>"
            Erro = True
        Else
            If Not IsNumeric(login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "")) Then
                If login.IsValidEmail Then
                    tipo = TipoLogin.Email
                Else
                    LblErro.Text += "CNPJ/Email inválido.<br/>"
                    Erro = True
                End If
            ElseIf IsNumeric(login) AndAlso CDbl(login) = 0 Then
                LblErro.Text += "CNPJ/Email inválido.<br/>"
                Erro = True
            Else
                login = login.Replace("/", "").Replace("-", "").Replace(".", "").Replace("\", "").Replace(" ", "")
            End If
        End If

        If Not auto AndAlso senha = "" Then
            LblErro.Text += "Preencha o campo Senha.<br/>"
            Erro = True
        End If

        If Not Erro Then

            CodEmitente = objEnderecoEmitente.GetCodEmitente(login, IIf(tipo = TipoLogin.Email, UCLEnderecoEmitente.TipoBusca.Email, UCLEnderecoEmitente.TipoBusca.CNPJ))
            objEnderecoEmitente.CodEmitente = CodEmitente

            If tipo = TipoLogin.Email Then
                objEnderecoEmitente.EmailLogin = login
            Else
                objEnderecoEmitente.CNPJ = login
            End If

            If Not objEnderecoEmitente.Buscar() Then 'Não encontrou
                CodEmitente = objEnderecoEmitente.GetCodEmitente(Right(login, 11), IIf(tipo = TipoLogin.Email, UCLEnderecoEmitente.TipoBusca.Email, UCLEnderecoEmitente.TipoBusca.CNPJ))
                objEnderecoEmitente.CodEmitente = CodEmitente
                If tipo = TipoLogin.Email Then
                    objEnderecoEmitente.EmailLogin = login
                Else
                    objEnderecoEmitente.CNPJ = Right(login, 11)
                End If

                If Not objEnderecoEmitente.Buscar() Then 'Não encontrou
                    LblErro.Text += "CNPJ/Email não encontrado.<br/>"
                    Erro = True
                Else
                    If Not auto AndAlso senha <> objEnderecoEmitente.Senha Then
                        LblErro.Text += "Senha não confere.<br/>"
                        Erro = True
                    End If

                    If Not Erro Then
                        senha = objEnderecoEmitente.Senha
                        Call CarregaVariaveisGlobais(objEnderecoEmitente.CNPJ, objEnderecoEmitente.EmailLogin, senha, CodEmitente, objEnderecoEmitente.RazaoSocial, 1, 1, objEnderecoEmitente.CodPais, objEnderecoEmitente.CodEstado, objEnderecoEmitente.CodCidade)
                        Return True
                    End If
                End If
            Else
                If Not auto AndAlso senha <> objEnderecoEmitente.Senha Then
                    LblErro.Text += "Senha não confere.<br/>"
                    Erro = True
                End If

                If Not Erro Then
                    senha = objEnderecoEmitente.Senha
                    Call CarregaVariaveisGlobais(objEnderecoEmitente.CNPJ, objEnderecoEmitente.EmailLogin, senha, CodEmitente, objEnderecoEmitente.RazaoSocial, 1, 1, objEnderecoEmitente.CodPais, objEnderecoEmitente.CodEstado, objEnderecoEmitente.CodCidade)
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Public Sub CarregaVariaveisGlobais(ByVal CNPJ As String, ByVal email As String, ByVal senha As String, ByVal CodEmitente As String, ByVal NomeCliente As String, ByVal Empresa As String, ByVal Estabelecimento As String, codPais As String, codEstado As String, codCidade As String)
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
End Class
