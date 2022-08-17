Public Class UCLSolicitacaoDesenvolvimento

    Public Property Empresa As String
    Public Property CodSolicitacao As String
    Public Property DataSolicitacao As String
    Public Property DataPrevisaoEntrega As String
    Public Property Origem As String
    Public Property CodAnalista As String
    Public Property CodEmitente As String
    Public Property CodSistema As String
    Public Property Descricao As String
    Public Property RegraNegocio As String
    Public Property Urgencia As String
    Public Property PrazoObrigatorio As String
    Public Property DataObrigatoria As String
    Public Property EmailClienteAprovar As String
    Public Property Assunto As String
    Public Property ProximaVisita As String
    Public Property Status As String
    Public Property SeqPrioridadeCliente As String

    Private objAcessoDados As UCLAcessoDados

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select * "
        StrSql += "   from solicitacao_desenvolvimento "
        StrSql += "  where empresa         = " + Empresa
        StrSql += "    and cod_solicitacao = " + CodSolicitacao
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows.Item(0).Item("data_solicitacao")) Then
                DataSolicitacao = CDate(dt.Rows.Item(0).Item("data_solicitacao")).ToString("dd/MM/yyyy")
            Else
                DataSolicitacao = ""
            End If

            Origem = dt.Rows.Item(0).Item("origem").ToString
            CodAnalista = dt.Rows.Item(0).Item("cod_analista").ToString
            CodEmitente = dt.Rows.Item(0).Item("cod_emitente").ToString
            CodSistema = dt.Rows.Item(0).Item("cod_sistema").ToString
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            RegraNegocio = dt.Rows.Item(0).Item("regra_negocio").ToString
            Urgencia = dt.Rows.Item(0).Item("urgencia").ToString
            Status = dt.Rows.Item(0).Item("status").ToString
            If String.IsNullOrWhiteSpace(Status) Then
                Status = "0"
            End If
            PrazoObrigatorio = dt.Rows.Item(0).Item("prazo_obrigatorio").ToString

            If Not IsDBNull(dt.Rows.Item(0).Item("data_obrigatoria")) Then
                DataObrigatoria = CDate(dt.Rows.Item(0).Item("data_obrigatoria")).ToString("dd/MM/yyyy")
            Else
                DataObrigatoria = ""
            End If

            If Not IsDBNull(dt.Rows.Item(0).Item("previsao_entrega")) Then
                DataPrevisaoEntrega = CDate(dt.Rows.Item(0).Item("previsao_entrega")).ToString("dd/MM/yyyy")
            Else
                DataPrevisaoEntrega = ""
            End If

            If Not IsDBNull(dt.Rows.Item(0).Item("seq_prioridade_cliente")) Then
                SeqPrioridadeCliente = dt.Rows.Item(0).Item("seq_prioridade_cliente")
            Else
                SeqPrioridadeCliente = ""
            End If

            EmailClienteAprovar = dt.Rows.Item(0).Item("email_cliente_aprovar").ToString
            Assunto = dt.Rows.Item(0).Item("assunto").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("data_proxima_visita")) Then
                ProximaVisita = CDate(dt.Rows.Item(0).Item("data_proxima_visita")).ToString("dd/MM/yyyy")
            Else
                ProximaVisita = ""
            End If

            Return True
        Else
            Return False
        End If

    End Function

    'Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal SomenteAtivos As Boolean, ByVal CodAnalista As String)
    '    Dim strSql As String = ""
    '    Dim dt As DataTable

    '    strSql += " select a.cod_analista, u.nome_usuario nome"
    '    strSql += "   from analista a inner join sysusuario u on a.cod_analista = u.cod_usuario"
    '    If SomenteAtivos Then
    '        strSql += "  where ( isnull(a.inativo,'N') = 'N' or cod_analista = " + CodAnalista + ")"
    '    End If
    '    strSql += "  order by nome "
    '    dt = objAcessoDados.BuscarDados(strSql)

    '    If AdicionarRegistroEmBranco Then
    '        Dim NovaLinha As DataRow = dt.NewRow
    '        NovaLinha("cod_analista") = CodRegistroEmBranco
    '        If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
    '            DescricaoRegistroEmBranco = " "
    '        End If
    '        NovaLinha("nome") = DescricaoRegistroEmBranco
    '        dt.Rows.InsertAt(NovaLinha, 0)
    '    End If

    '    DDL.DataSource = dt
    '    DDL.DataTextField = "nome"
    '    DDL.DataValueField = "cod_analista"
    '    DDL.DataBind()
    'End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_solicitacao),0) + 1 max from solicitacao_desenvolvimento where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try

            If String.IsNullOrEmpty(PrazoObrigatorio) Then
                PrazoObrigatorio = "N"
            End If

            strSql += " insert into solicitacao_desenvolvimento( empresa, cod_solicitacao, data_solicitacao, status, origem, cod_analista, cod_emitente, cod_sistema, descricao, regra_negocio, urgencia, prazo_obrigatorio, data_obrigatoria, email_cliente_aprovar, assunto, previsao_entrega, seq_prioridade_cliente, data_proxima_visita)"
            strSql += " values (" + Empresa + ", " + CodSolicitacao + ", " + CDate(DataSolicitacao).ToString("yyyyMMdd") + ", " + Status + ", " + Origem + ", " + CodAnalista + ", " + CodEmitente + ", " + CodSistema + ", '" + Descricao + "', '" + RegraNegocio + "', " + Urgencia + ",'" + PrazoObrigatorio + "', "

            If String.IsNullOrEmpty(DataObrigatoria) Then
                strSql += "null, "
            Else
                strSql += CDate(DataObrigatoria).ToString("yyyyMMdd") + ", "
            End If

            If String.IsNullOrEmpty(EmailClienteAprovar) Then
                EmailClienteAprovar = "N"
            End If

            strSql += "'" + EmailClienteAprovar + "', '" + Assunto + "', "

            If String.IsNullOrEmpty(DataPrevisaoEntrega) Then
                strSql += "null, "
            Else
                strSql += CDate(DataPrevisaoEntrega).ToString("yyyyMMdd") + ", "
            End If

            If String.IsNullOrEmpty(SeqPrioridadeCliente) Then
                strSql += "null, "
            Else
                strSql += SeqPrioridadeCliente + ", "
            End If

            If String.IsNullOrEmpty(ProximaVisita) Then
                strSql += "null) "
            Else
                strSql += CDate(ProximaVisita).ToString("yyyyMMdd") + ") "
            End If

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try

            If String.IsNullOrEmpty(PrazoObrigatorio) Then
                PrazoObrigatorio = "N"
            End If

            strSql += " update solicitacao_desenvolvimento "
            strSql += "    set data_solicitacao  = " + CDate(DataSolicitacao).ToString("yyyyMMdd") + ", "
            strSql += "        origem            = " + Origem + ", "
            strSql += "        cod_analista      = " + CodAnalista + ", "
            strSql += "        cod_emitente      = " + CodEmitente + ", "
            strSql += "        cod_sistema       = " + CodSistema + ", "
            strSql += "        assunto           = '" + Assunto + "', "
            strSql += "        status            = " + Status + ", "
            strSql += "        descricao         = '" + Descricao + "', "
            strSql += "        regra_negocio     = '" + RegraNegocio + "', "
            strSql += "        urgencia          = " + Urgencia + ", "

            If Not String.IsNullOrWhiteSpace(SeqPrioridadeCliente) Then
                strSql += "    seq_prioridade_cliente = " + SeqPrioridadeCliente + ", "
            Else
                strSql += "    seq_prioridade_cliente = null, "
            End If

            strSql += "        prazo_obrigatorio = '" + PrazoObrigatorio + "', "

            If String.IsNullOrEmpty(DataPrevisaoEntrega) Then
                strSql += "previsao_entrega = null, "
            Else
                strSql += "previsao_entrega = " + CDate(DataPrevisaoEntrega).ToString("yyyyMMdd") + ", "
            End If

            If String.IsNullOrEmpty(DataObrigatoria) Then
                strSql += "data_obrigatoria = null, "
            Else
                strSql += "data_obrigatoria = " + CDate(DataObrigatoria).ToString("yyyyMMdd") + ", "
            End If

            If String.IsNullOrEmpty(ProximaVisita) Then
                strSql += "data_proxima_visita = null, "
            Else
                strSql += "data_proxima_visita = " + CDate(ProximaVisita).ToString("yyyyMMdd") + ", "
            End If

            If String.IsNullOrEmpty(EmailClienteAprovar) Then
                EmailClienteAprovar = "N"
            End If

            strSql += "        email_cliente_aprovar = '" + EmailClienteAprovar + "' "
            strSql += "  where empresa         = " + Empresa
            strSql += "    and cod_solicitacao = " + CodSolicitacao
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
