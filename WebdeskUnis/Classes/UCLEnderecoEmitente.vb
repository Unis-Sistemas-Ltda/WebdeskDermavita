Public Class UCLEnderecoEmitente

    Private _CodEmitente As String = ""
    Private _RazaoSocial As String = ""
    Private _NomeAbreviado As String = ""
    Private _CNPJNovo As String = ""
    Private _CNPJ As String = ""
    Private _CNPJOriginal As String = ""
    Private _Ativo As String = ""
    Private _Cobranca As String = ""
    Private _Preferencial As String = ""
    Private _Logradouro As String = ""
    Private _Numero As String = ""
    Private _CEP As String = ""
    Private _Email As String = ""
    Private _EmailLogin As String = ""
    Private _Fone1 As String = ""
    Private _Fone2 As String = ""
    Private _Fax As String = ""
    Private _CodPais As String = ""
    Private _CodEstado As String = ""
    Private _CodCidade As String = ""
    Private _Bairro As String = ""
    Private _IE As String = ""
    Private _IM As String = ""
    Private _PontoAtendimento As String = ""
    Private _CodTipoPontoAtendimento As String = ""
    Private _NumeroPontoAtendimento As String = ""
    Private _NumeroUniorg As String = ""
    Private _Senha As String = ""
    Private objAcessoDados As UCLAcessoDados

    Public Enum TipoBusca As Short
        CNPJ = 1
        Email = 2
    End Enum

    Public Function GetCodEmitente(ByVal CNPJ_Email As String, Optional ByVal tipo As TipoBusca = TipoBusca.CNPJ) As Long
        Dim strSql As String
        Dim dt As DataTable
        Dim campo As String

        Try

            If String.IsNullOrEmpty(CNPJ_Email) Then
                Return -1
            End If

            If tipo = TipoBusca.Email Then
                campo = "email"
            Else
                campo = "cnpj"
            End If

            strSql = " select cod_emitente from endereco_emitente where " + campo + " = '" + CNPJ_Email + "' order by isnull(ativo,'N') desc"

            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("cod_emitente").ToString
            Else
                Return 0
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Property Senha()
        Get
            Return _Senha
        End Get
        Set(ByVal value)
            _Senha = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property RazaoSocial() As String
        Get
            Return _RazaoSocial
        End Get
        Set(ByVal value As String)
            _RazaoSocial = value
        End Set
    End Property

    Public Property NomeAbreviado() As String
        Get
            Return _NomeAbreviado
        End Get
        Set(ByVal value As String)
            _NomeAbreviado = value
        End Set
    End Property


    Public Property CNPJOriginal() As String
        Get
            Return _CNPJOriginal
        End Get
        Set(ByVal value As String)
            _CNPJOriginal = value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property

    Public Property CNPJNovo() As String
        Get
            Return _CNPJNovo
        End Get
        Set(ByVal value As String)
            _CNPJNovo = value
        End Set
    End Property

    Public Property Ativo() As String
        Get
            If String.IsNullOrEmpty(_Ativo) Then
                _Ativo = "S"
            End If
            Return _Ativo
        End Get
        Set(ByVal value As String)
            _Ativo = value
        End Set
    End Property

    Public Property Cobranca() As String
        Get
            Return _Cobranca
        End Get
        Set(ByVal value As String)
            _Cobranca = value
        End Set
    End Property

    Public Property Preferencial() As String
        Get
            If String.IsNullOrEmpty(_Preferencial) Then
                _Preferencial = "N"
            End If
            Return _Preferencial
        End Get
        Set(ByVal value As String)
            _Preferencial = value
        End Set
    End Property

    Public Property Logradouro() As String
        Get
            Return _Logradouro
        End Get
        Set(ByVal value As String)
            _Logradouro = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property CEP() As String
        Get
            Return _CEP
        End Get
        Set(ByVal value As String)
            _CEP = value
        End Set
    End Property

    Public Property EmailXmlNfe As String

    Public Property EmailBoleto As String

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property EmailLogin() As String
        Get
            Return _EmailLogin
        End Get
        Set(ByVal value As String)
            _EmailLogin = value
        End Set
    End Property

    Public Property Fone1() As String
        Get
            Return _Fone1
        End Get
        Set(ByVal value As String)
            _Fone1 = value
        End Set
    End Property

    Public Property Fone2() As String
        Get
            Return _Fone2
        End Get
        Set(ByVal value As String)
            _Fone2 = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Public Property CodPais() As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodEstado() As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property

    Public Property CodCidade() As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property

    Public Property Bairro() As String
        Get
            Return _Bairro
        End Get
        Set(ByVal value As String)
            _Bairro = value
        End Set
    End Property

    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property

    Public Property IM() As String
        Get
            Return _IM
        End Get
        Set(ByVal value As String)
            _IM = value
        End Set
    End Property

    Public Property PontoAtendimento() As String
        Get
            If String.IsNullOrEmpty(_PontoAtendimento) Then
                _PontoAtendimento = "N"
            End If
            Return _PontoAtendimento
        End Get
        Set(ByVal value As String)
            _PontoAtendimento = value
        End Set
    End Property

    Public Property CodTipoPontoAtendimento() As String
        Get
            Return _CodTipoPontoAtendimento
        End Get
        Set(ByVal value As String)
            _CodTipoPontoAtendimento = value
        End Set
    End Property

    Public Property NumeroPontoAtendimento() As String
        Get
            Return _NumeroPontoAtendimento
        End Get
        Set(ByVal value As String)
            _NumeroPontoAtendimento = value
        End Set
    End Property

    Public Property NumeroUniorg() As String
        Get
            Return _NumeroUniorg
        End Get
        Set(ByVal value As String)
            _NumeroUniorg = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""

        If String.IsNullOrEmpty(CodEmitente) Then
            Return False
        End If

        If String.IsNullOrEmpty(CNPJ) AndAlso String.IsNullOrEmpty(EmailLogin) Then
            Return False
        End If

        If CNPJ = CNPJOriginal Then
            StrSql += "  select isnull(email_xml_nfe,'') email_xml_nfe, isnull(email_boleto,'') email_boleto, isnull(nome,'') nome, isnull(nome_abreviado,'') nome_abreviado, isnull(ativo,'S') ativo, isnull(cobranca,'N') cobranca, isnull(preferencial,'N') preferencial, isnull(endereco,'') endereco, isnull(senha,'') senha, isnull(email_login,'') email_login, cnpj, "
            StrSql += "         isnull(numero,0) numero, isnull(cep,'') cep, isnull(telefone,'') telefone, isnull(telefone2,'') telefone2, isnull(fax,'') fax, cod_pais, cod_estado, cod_cidade, isnull(bairro,'') bairro, isnull(insc_estadual,'') insc_estadual, isnull(insc_municipal,'') insc_municipal, isnull(email,'') email, "
            StrSql += "         isnull(ponto_atendimento,'N') ponto_atendimento, isnull(cod_tipo_ponto_atendimento,0) cod_tipo_ponto_atendimento, isnull(numero_ponto_atendimento,'') numero_ponto_atendimento, isnull(numero_uniorg,'') numero_uniorg"
            StrSql += "    from endereco_emitente "
            StrSql += "   where cod_emitente = " + CodEmitente
            If Not String.IsNullOrEmpty(CNPJ) Then
                StrSql += " and cnpj = '" + CNPJ + "'"
            Else
                StrSql += " and email = '" + EmailLogin + "'"
            End If
        Else
            StrSql += "  select isnull(email_xml_nfe,'') email_xml_nfe, isnull(email_boleto,'') email_boleto, isnull(nome,'') nome, isnull(nome_abreviado,'') nome_abreviado, isnull(ativo,'S') ativo, isnull(cobranca,'N') cobranca, isnull(preferencial,'N') preferencial, isnull(endereco,'') endereco, isnull(senha,'') senha, isnull(email_login,'') email_login, cnpj, "
            StrSql += "         isnull(numero,0) numero, isnull(cep,'') cep, isnull(telefone,'') telefone, isnull(telefone2,'') telefone2, isnull(fax,'') fax, cod_pais, cod_estado, cod_cidade, isnull(bairro,'') bairro, isnull(insc_estadual,'') insc_estadual, isnull(insc_municipal,'') insc_municipal, isnull(email,'') email, "
            StrSql += "         isnull(ponto_atendimento,'N') ponto_atendimento, isnull(cod_tipo_ponto_atendimento,0) cod_tipo_ponto_atendimento, isnull(numero_ponto_atendimento,'') numero_ponto_atendimento, isnull(numero_uniorg,'') numero_uniorg"
            StrSql += "    from endereco_emitente "
            StrSql += "   where cod_emitente = " + CodEmitente
            If Not String.IsNullOrEmpty(CNPJ) Then
                StrSql += " and cnpj = '" + CNPJOriginal + "'"
            Else
                StrSql += " and email = '" + EmailLogin + "'"
            End If

        End If

        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            EmailXmlNfe = dt.Rows.Item(0).Item("email_xml_nfe").ToString.Trim
            EmailBoleto = dt.Rows.Item(0).Item("email_boleto").ToString.Trim
            RazaoSocial = dt.Rows.Item(0).Item("nome").ToString
            If CNPJ = CNPJOriginal Then
                CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
            Else
                CNPJ = CNPJ
            End If

            EmailLogin = dt.Rows.Item(0).Item("email_login").ToString
            NomeAbreviado = dt.Rows.Item(0).Item("nome_abreviado").ToString
            Ativo = dt.Rows.Item(0).Item("ativo").ToString
            Cobranca = dt.Rows.Item(0).Item("cobranca").ToString
            Preferencial = dt.Rows.Item(0).Item("preferencial").ToString
            Logradouro = dt.Rows.Item(0).Item("endereco").ToString
            Senha = dt.Rows.Item(0).Item("senha").ToString
            Numero = CDbl(dt.Rows.Item(0).Item("numero")).ToString("F0")
            CEP = dt.Rows.Item(0).Item("cep").ToString
            Fone1 = dt.Rows.Item(0).Item("telefone").ToString
            Fone2 = dt.Rows.Item(0).Item("telefone2").ToString
            Fax = dt.Rows.Item(0).Item("fax").ToString
            CodPais = dt.Rows.Item(0).Item("cod_pais").ToString
            CodEstado = dt.Rows.Item(0).Item("cod_estado").ToString
            CodCidade = dt.Rows.Item(0).Item("cod_cidade").ToString
            Bairro = dt.Rows.Item(0).Item("bairro").ToString
            IE = dt.Rows.Item(0).Item("insc_estadual").ToString
            IM = dt.Rows.Item(0).Item("insc_municipal").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            PontoAtendimento = dt.Rows.Item(0).Item("ponto_atendimento").ToString
            CodTipoPontoAtendimento = dt.Rows.Item(0).Item("cod_tipo_ponto_atendimento").ToString
            NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
            NumeroUniorg = dt.Rows.Item(0).Item("numero_uniorg").ToString

            If String.IsNullOrEmpty(PontoAtendimento) Then PontoAtendimento = "N"
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into endereco_emitente ("
            strSql += "    cod_emitente, cnpj, nome, nome_abreviado, ativo, cobranca, senha, "
            strSql += "    preferencial, endereco, numero, cep, telefone, telefone2, fax, "
            strSql += "    cod_pais, cod_estado, cod_cidade, bairro, insc_estadual, insc_municipal, email, email_xml_nfe, email_boleto, email_login, situacao)"
            strSql += " values(" + CodEmitente + ", '" + CNPJ + "', '" + RazaoSocial + "', '" + NomeAbreviado + "', '" + Ativo + "', '" + Cobranca + "', '" + Senha + "', "
            strSql += "    '" + Preferencial + "', '" + Logradouro + "', '" + Numero + "', '" + CEP + "', '" + Fone1 + "', '" + Fone2 + "', '" + Fax + "', "
            strSql += "    " + CodPais + ", " + CodEstado + ", " + CodCidade + ", '" + Bairro + "', '" + IE + "', '" + IM + "','" + Email + "','" + EmailXmlNfe + "','" + EmailBoleto + "'," + IIf(String.IsNullOrWhiteSpace(EmailLogin), "null", "'" + EmailLogin + "'") + ",2);"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            If ex.Message.ToString.Contains("ASA Error -196") Then
                Throw New Exception("E-mail [" + EmailLogin + "] já está vinculado a outro cadastro. Por favor informe outro endereço de e-mail.")
            Else
                Throw ex
            End If
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            If CNPJ = CNPJOriginal Then
                strSql += " update endereco_emitente "
                strSql += "    set nome           = '" + RazaoSocial + "', "
                strSql += "        nome_abreviado = '" + NomeAbreviado + "', "
                strSql += "        ativo          = '" + Ativo + "', "
                strSql += "        cobranca       = '" + Cobranca + "', "
                strSql += "        preferencial   = '" + Preferencial + "', "
                strSql += "        endereco       = '" + Logradouro + "', "
                strSql += "        numero         = '" + Numero + "', "
                strSql += "        cep            = '" + CEP + "', "
                strSql += "        email          = '" + Email + "', "
                strSql += "        email_xml_nfe  = '" + EmailXmlNfe + "', "
                strSql += "        email_boleto   = '" + EmailBoleto + "', "
                strSql += "        email_login    = " + IIf(String.IsNullOrWhiteSpace(EmailLogin), "null", "'" + EmailLogin + "'") + ", "
                strSql += "        situacao       = 2, "
                strSql += "        telefone       = '" + Fone1 + "', "
                strSql += "        telefone2      = '" + Fone2 + "', "
                strSql += "        fax            = '" + Fax + "', "
                strSql += "        cod_pais       = " + CodPais + ", "
                strSql += "        cod_estado     = " + CodEstado + ", "
                strSql += "        cod_cidade     = " + CodCidade + ", "
                strSql += "        bairro         = '" + Bairro + "', "
                strSql += "        insc_estadual  = '" + IE + "', "
                strSql += "        insc_municipal = '" + IM + "', "
                strSql += "        senha          = " + IIf(String.IsNullOrWhiteSpace(Senha), "null ", "'" + Senha + "' ")
                strSql += "  where cod_emitente   = " + CodEmitente
                strSql += "    and cnpj           = '" + CNPJ + "'; "
            Else
                strSql += " update endereco_emitente "
                strSql += "    set nome           = '" + RazaoSocial + "', "
                strSql += "        nome_abreviado = '" + NomeAbreviado + "', "
                strSql += "        ativo          = '" + Ativo + "', "
                strSql += "        cobranca       = '" + Cobranca + "', "
                strSql += "        preferencial   = '" + Preferencial + "', "
                strSql += "        endereco       = '" + Logradouro + "', "
                strSql += "        numero         = '" + Numero + "', "
                strSql += "        cep            = '" + CEP + "', "
                strSql += "        email          = '" + Email + "', "
                strSql += "        email_xml_nfe  = '" + EmailXmlNfe + "', "
                strSql += "        email_boleto   = '" + EmailBoleto + "', "
                strSql += "        email_login    = " + IIf(String.IsNullOrWhiteSpace(EmailLogin), "null", "'" + EmailLogin + "'") + ", "
                strSql += "        situacao       = 2, "
                strSql += "        telefone       = '" + Fone1 + "', "
                strSql += "        telefone2      = '" + Fone2 + "', "
                strSql += "        fax            = '" + Fax + "', "
                strSql += "        cod_pais       = " + CodPais + ", "
                strSql += "        cod_estado     = " + CodEstado + ", "
                strSql += "        cod_cidade     = " + CodCidade + ", "
                strSql += "        bairro         = '" + Bairro + "', "
                strSql += "        insc_estadual  = '" + IE + "', "
                strSql += "        insc_municipal = '" + IM + "', "
                strSql += "        senha          = " + IIf(String.IsNullOrWhiteSpace(Senha), "null, ", "'" + Senha + "', ")
                strSql += "        cnpj = '" + CNPJ + "' "
                strSql += "  where cod_emitente   = " + CodEmitente
                strSql += "    and cnpj           = '" + CNPJOriginal + "'; "

            End If


            objAcessoDados.ExecutarSql(strSql)


        Catch ex As Exception
            If ex.Message.ToString.Contains("ASA Error -196") Then
                Throw New Exception("E-mail [" + EmailLogin + "] já está vinculado a outro cadastro. Por favor informe outro endereço de e-mail.")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Public Sub FillDropDownCNPJ(ByRef DDL As DropDownList, Optional ByVal MostraNomeAbreviado As Boolean = False)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cnpj, cnpj cnpj_com_mascara, nome_abreviado "
        strSql += "   from endereco_emitente "
        strSql += "  where cod_emitente = " + CodEmitente
        strSql += "  order by preferencial desc, cnpj asc "
        dt = objAcessoDados.BuscarDados(strSql)

        For Each row As DataRow In dt.Rows
            If row.Item("cnpj_com_mascara").ToString.Trim.Length = 11 Then
                row.Item("cnpj_com_mascara") = row.Item("cnpj_com_mascara").ToString.MascaraCPF
                If MostraNomeAbreviado Then
                    row.Item("cnpj_com_mascara") += " - " + row.Item("nome_abreviado").ToString
                End If
            Else
                row.Item("cnpj_com_mascara") = row.Item("cnpj_com_mascara").ToString.MascaraCNPJ
                If MostraNomeAbreviado Then
                    row.Item("cnpj_com_mascara") += " - " + row.Item("nome_abreviado").ToString
                End If
            End If
        Next

        DDL.DataSource = dt
        DDL.DataTextField = "cnpj_com_mascara"
        DDL.DataValueField = "cnpj"
        DDL.DataBind()
    End Sub

    Public Function GerarSenha() As String

        Try
            Dim objEmail As UCLEmail
            Dim objContato As New UCLContato
            Dim DbEmail As String
            Dim DbNome As String
            Dim AsSenha As String

            Me.CodEmitente = Me.GetCodEmitente(CNPJ)

            If Not Me.Buscar() Then
                Return "CNPJ não cadastrado"
            End If

            DbEmail = Me.EmailLogin

            If String.IsNullOrEmpty(DbEmail) Then
                objContato.CodEmitente = Me.CodEmitente
                objContato.Codigo = objContato.GetCodContatoPreferencial()
                objContato.Buscar()
                DbEmail = objContato.Email
            End If

            If String.IsNullOrEmpty(DbEmail) Then
                DbEmail = Me.Email
            End If

            DbNome = RazaoSocial

            If String.IsNullOrEmpty(DbEmail) Then
                Return "E-mail não cadastrado"
            Else
                Randomize()
                Dim value As Integer = CInt(Int((33342 * Rnd()) + 1))
                AsSenha = value.ToString

                Senha = AsSenha
                Me.Alterar()

                Try
                    objEmail = New UCLEmail
                    Call objEmail.envia_email("mail.unisnet.com.br", EmailPadraoContato, DbEmail, "Webdesk Unis - Nova Senha", "Prezado(a) " & DbNome & ". <br><br> Sua nova senha é: " & AsSenha & "<BR><BR>Atenciosamente,<BR><BR>Equipe Unis Sistemas<BR>www.unisnet.com.br", SenhaPadraoContato, "", "N")
                Catch ex As Exception
                    Return "Erro ao enviar e-mail"
                End Try
                Return "Sua senha foi enviada com sucesso para o e-mail " + DbEmail + " em " + Now.ToString("dd/MM/yyyy") + " às " + Now.ToString("HH:mm") + "."

            End If

            Return ""

        Catch ex As Exception
            If ex.Message.ToString.Contains("ASA Error -196") Then
                Throw New Exception("E-mail [" + EmailLogin + "] já está vinculado a outro cadastro. Por favor informe outro endereço de e-mail.")
            Else
                Throw ex
            End If
        End Try
        
    End Function

    Public Function EmailEstaDisponivel() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable
            Dim qtd As Long

            StrSql = " select count(1) qtd "
            StrSql += "  from endereco_emitente "
            StrSql += " where cod_emitente <> " + CodEmitente
            StrSql += "   and cnpj <> '" + CNPJ + "'"
            StrSql += "   and email_login = '" + EmailLogin + "'"

            dt = objAcessoDados.BuscarDados(StrSql)
            qtd = dt.Rows.Item(0).Item("qtd")

            Return (qtd = 0)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
