Public Class UCLAtendimento
    Private objAcessoDados As UCLAcessoDados

    Private _Empresa As String
    Private _CodChamado As String
    Private _CodEmitente As String
    Private _CodEmitenteAtendimento As String
    Private _CodContato As String
    Private _CodContatoAtendimento As String
    Private _CodAnalista As String
    Private _TipoChamado As String
    Private _NumeroSerie As String
    Private _CodUsuario As String
    Private _CodStatus As String
    Private _DataChamado As String
    Private _DDataChamado As Date
    Private _HoraChamado As String
    Private _DataEncerramentoPrevista As String
    Private _DDataEncerramentoPrevista As Date
    Private _HoraEncerramentoPrevista As String
    Private _DataEncerramentoPrevistaInicio As String
    Private _DDataEncerramentoPrevistaInicio As Date
    Private _HoraEncerramentoPrevistaInicio As String
    Private _DataEncerramento As String
    Private _DDataEncerramento As Date
    Private _HoraEncerramento As String
    Private _Assunto As String
    Private _OSCliente As String
    Private _Observacao As String
    Private _Cnpj As String
    Private _CnpjAtendimento As String
    Private _NumeroPontoAtendimento As String
    Private _CodVeiculo As String
    Private _ChecaEnvioEmail As Boolean
    Private _EncerramentoAceito As String
    Private _Encerrado As String
    Private _DataAceiteEncerramento As String
    Private _DDataAceiteEncerramento As Date
    Private _HHoraAceiteEncerramento As String
    Private _IPAceiteEncerramento As String
    Private _CodSLA As String
    Private _CodSistema As String
    Private _CodModulo As String
    Private _CaminhoMenu As String
    Private _Programa As String
    Private _SeqPrioridade As String

    Public Property SeqPrioridade As String
        Get
            Return _SeqPrioridade
        End Get
        Set(value As String)
            _SeqPrioridade = value
        End Set
    End Property

    Public Property CodSla As String
        Get
            Return _CodSLA
        End Get
        Set(value As String)
            _CodSLA = value
        End Set
    End Property

    Public Property CodSistema As String
        Get
            Return _CodSistema
        End Get
        Set(value As String)
            _CodSistema = value
        End Set
    End Property

    Public Property CodModulo As String
        Get
            Return _CodModulo
        End Get
        Set(value As String)
            _CodModulo = value
        End Set
    End Property

    Public Property CaminhoMenu As String
        Get
            Return _CaminhoMenu
        End Get
        Set(value As String)
            _CaminhoMenu = value
        End Set
    End Property

    Public Property Programa As String
        Get
            Return _Programa
        End Get
        Set(value As String)
            _Programa = value
        End Set
    End Property

    Public Property Encerrado As String
        Get
            Return _Encerrado
        End Get
        Set(value As String)
            _Encerrado = value
        End Set
    End Property

    Public Property EncerramentoAceito As String
        Get
            Return _EncerramentoAceito
        End Get
        Set(value As String)
            _EncerramentoAceito = value
        End Set
    End Property

    Public Property DataAceiteEncerramento As String
        Get
            Return _DataAceiteEncerramento
        End Get
        Set(value As String)
            _DataAceiteEncerramento = value
            If isValidDate(value) Then
                DDataEncerramento = CDate(value)
            End If
        End Set
    End Property

    Public Property DDataAceiteEncerramento() As Date
        Get
            Return _DDataAceiteEncerramento
        End Get
        Set(ByVal value As Date)
            _DDataAceiteEncerramento = value
        End Set
    End Property

    Public Property HHoraAceiteEncerramento() As String
        Get
            Return _HHoraAceiteEncerramento
        End Get
        Set(ByVal value As String)
            _HHoraAceiteEncerramento = value
        End Set
    End Property

    Public Property IPAceiteEncerramento As String
        Get
            Return _IPAceiteEncerramento
        End Get
        Set(value As String)
            _IPAceiteEncerramento = value
        End Set
    End Property

    Public Property ChecaEnvioEmailStatus() As Boolean
        Get
            Return _ChecaEnvioEmail
        End Get
        Set(ByVal value As Boolean)
            _ChecaEnvioEmail = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodChamado() As String
        Get
            Return _CodChamado
        End Get
        Set(ByVal value As String)
            _CodChamado = value
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

    Public Property CodEmitenteAtendimento() As String
        Get
            Return _CodEmitenteAtendimento
        End Get
        Set(ByVal value As String)
            _CodEmitenteAtendimento = value
        End Set
    End Property

    Public Property CodContato() As String
        Get
            Return _CodContato
        End Get
        Set(ByVal value As String)
            _CodContato = value
        End Set
    End Property

    Public Property CodContatoAtendimento() As String
        Get
            Return _CodContatoAtendimento
        End Get
        Set(ByVal value As String)
            _CodContatoAtendimento = value
        End Set
    End Property

    Public Property CodAnalista() As String
        Get
            Return _CodAnalista
        End Get
        Set(ByVal value As String)
            _CodAnalista = value
        End Set
    End Property

    Public Property TipoChamado() As String
        Get
            Return _TipoChamado
        End Get
        Set(ByVal value As String)
            _TipoChamado = value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return _NumeroSerie
        End Get
        Set(ByVal value As String)
            _NumeroSerie = value
        End Set
    End Property

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property CodStatus() As String
        Get
            Return _CodStatus
        End Get
        Set(ByVal value As String)
            _CodStatus = value
        End Set
    End Property

    Public Property DataChamado() As String
        Get
            Return _DataChamado
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataChamado = CDate(value)
            End If
            _DataChamado = value
        End Set
    End Property

    Public Property DDataChamado() As Date
        Get
            Return _DDataChamado
        End Get
        Set(ByVal value As Date)
            _DDataChamado = value
        End Set
    End Property

    Public Property HoraChamado() As String
        Get
            Return _HoraChamado
        End Get
        Set(ByVal value As String)
            _HoraChamado = value
        End Set
    End Property

    Public Property DataEncerramentoPrevista() As String
        Get
            Return _DataEncerramentoPrevista
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramentoPrevista = CDate(value)
            End If
            _DataEncerramentoPrevista = value
        End Set
    End Property

    Public Property DDataEncerramentoPrevista() As Date
        Get
            Return _DDataEncerramentoPrevista
        End Get
        Set(ByVal value As Date)
            _DDataEncerramentoPrevista = value
        End Set
    End Property

    Public Property HoraEncerramentoPrevista() As String
        Get
            Return _HoraEncerramentoPrevista
        End Get
        Set(ByVal value As String)
            _HoraEncerramentoPrevista = value
        End Set
    End Property

    Public Property DataEncerramentoPrevistaInicio() As String
        Get
            Return _DataEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramentoPrevistaInicio = CDate(value)
            End If
            _DataEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property DDataEncerramentoPrevistaInicio() As Date
        Get
            Return _DDataEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As Date)
            _DDataEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property HoraEncerramentoPrevistaInicio() As String
        Get
            Return _HoraEncerramentoPrevistaInicio
        End Get
        Set(ByVal value As String)
            _HoraEncerramentoPrevistaInicio = value
        End Set
    End Property

    Public Property DataEncerramento() As String
        Get
            Return _DataEncerramento
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEncerramento = CDate(value)
            End If
            _DataEncerramento = value
        End Set
    End Property

    Public Property DDataEncerramento() As Date
        Get
            Return _DDataEncerramento
        End Get
        Set(ByVal value As Date)
            _DDataEncerramento = value
        End Set
    End Property

    Public Property HoraEncerramento() As String
        Get
            Return _HoraEncerramento
        End Get
        Set(ByVal value As String)
            _HoraEncerramento = value
        End Set
    End Property

    Public Property Assunto() As String
        Get
            Return _Assunto
        End Get
        Set(ByVal value As String)
            _Assunto = value
        End Set
    End Property

    Public Property OSCliente() As String
        Get
            Return _OSCliente
        End Get
        Set(ByVal value As String)
            _OSCliente = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
        End Set
    End Property

    Public Property Cnpj() As String
        Get
            Return _Cnpj
        End Get
        Set(ByVal value As String)
            _Cnpj = value
        End Set
    End Property

    Public Property CnpjAtendimento() As String
        Get
            Return _CnpjAtendimento
        End Get
        Set(ByVal value As String)
            _CnpjAtendimento = value
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

    Public Property CodVeiculo() As String
        Get
            Return _CodVeiculo
        End Get
        Set(ByVal value As String)
            _CodVeiculo = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub New(ByVal strConn)
        objAcessoDados = New UCLAcessoDados(strConn)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = ""
            strSql += " select cod_emitente, cod_contato, cod_analista, tipo_chamado, numero_serie, cod_usuario, cod_status, data_chamado, cod_sla, cod_sistema, cod_modulo, caminho_menu, programa, "
            strSql += "        data_encerramento_prevista, data_encerramento_prevista_inicio, data_encerramento, assunto, os_cliente, encerramento_aceito, seq_prioridade, "
            strSql += "        observacao, cnpj, cod_veiculo, cod_emitente_atendimento, cnpj_atendimento, cod_contato_atendimento, numero_ponto_atendimento, isnull(encerrado,'N') encerrado "
            strSql += "   from chamado "
            strSql += "  where cod_chamado = " + CodChamado
            strSql += "    and empresa = " + Empresa

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                SeqPrioridade = dt.Rows.Item(0).Item("seq_prioridade").ToString
                CodEmitente = dt.Rows.Item(0).Item("cod_emitente").ToString
                CodEmitenteAtendimento = dt.Rows.Item(0).Item("cod_emitente_atendimento").ToString
                Cnpj = dt.Rows.Item(0).Item("cnpj").ToString
                CnpjAtendimento = dt.Rows.Item(0).Item("cnpj_atendimento").ToString
                CodContato = dt.Rows.Item(0).Item("cod_contato").ToString
                CodContatoAtendimento = dt.Rows.Item(0).Item("cod_contato_atendimento").ToString
                CodAnalista = dt.Rows.Item(0).Item("cod_analista").ToString
                TipoChamado = dt.Rows.Item(0).Item("tipo_chamado").ToString
                NumeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                CodStatus = dt.Rows.Item(0).Item("cod_status").ToString
                Assunto = dt.Rows.Item(0).Item("assunto").ToString
                Encerrado = dt.Rows.Item(0).Item("encerrado").ToString
                OSCliente = dt.Rows.Item(0).Item("os_cliente").ToString.ToUpper
                Observacao = dt.Rows.Item(0).Item("observacao").ToString
                CodVeiculo = dt.Rows.Item(0).Item("cod_veiculo").ToString
                EncerramentoAceito = dt.Rows.Item(0).Item("encerramento_aceito").ToString
                NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
                CodSla = dt.Rows.Item(0).Item("cod_sla").ToString
                CodSistema = dt.Rows.Item(0).Item("cod_sistema").ToString
                CodModulo = dt.Rows.Item(0).Item("cod_modulo").ToString
                CaminhoMenu = dt.Rows.Item(0).Item("caminho_menu").ToString
                Programa = dt.Rows.Item(0).Item("programa").ToString

                If Not IsDBNull(dt.Rows.Item(0).Item("data_chamado")) Then
                    DataChamado = CDate(dt.Rows.Item(0).Item("data_chamado")).ToString("dd/MM/yyyy")
                    HoraChamado = CType(dt.Rows.Item(0).Item("data_chamado"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento_prevista")) Then
                    DataEncerramentoPrevista = CDate(dt.Rows.Item(0).Item("data_encerramento_prevista")).ToString("dd/MM/yyyy")
                    HoraEncerramentoPrevista = CType(dt.Rows.Item(0).Item("data_encerramento_prevista"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio")) Then
                    DataEncerramentoPrevistaInicio = CDate(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio")).ToString("dd/MM/yyyy")
                    HoraEncerramentoPrevistaInicio = CType(dt.Rows.Item(0).Item("data_encerramento_prevista_inicio"), DateTime).ToString("HH:mm")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_encerramento")) Then
                    DataEncerramento = CDate(dt.Rows.Item(0).Item("data_encerramento")).ToString("dd/MM/yyyy")
                    HoraEncerramento = CType(dt.Rows.Item(0).Item("data_encerramento"), DateTime).ToString("HH:mm")
                End If

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim strSql As String
            Dim dbDataChamado As String
            Dim dbDataEncerramentoPrevista As String
            Dim dbDataEncerramentoPrevistaInicio As String
            Dim dbDataEncerramento As String
            Dim dbDataAceiteEncerramento As String

            If DDataChamado <> Nothing Then
                dbDataChamado = DDataChamado.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraChamado) Then
                    dbDataChamado += " " + HoraChamado + ":00"
                End If
                dbDataChamado = "'" + dbDataChamado + "'"
            Else
                dbDataChamado = "null"
            End If

            If DDataEncerramentoPrevista <> Nothing Then
                dbDataEncerramentoPrevista = DDataEncerramentoPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramentoPrevista) Then
                    dbDataEncerramentoPrevista += " " + HoraEncerramentoPrevista + ":00"
                End If
                dbDataEncerramentoPrevista = "'" + dbDataEncerramentoPrevista + "'"
            Else
                dbDataEncerramentoPrevista = "null"
            End If

            If DDataEncerramentoPrevistaInicio <> Nothing Then
                dbDataEncerramentoPrevistaInicio = DDataEncerramentoPrevistaInicio.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramentoPrevistaInicio) Then
                    dbDataEncerramentoPrevistaInicio += " " + HoraEncerramentoPrevistaInicio + ":00"
                End If
                dbDataEncerramentoPrevistaInicio = "'" + dbDataEncerramentoPrevistaInicio + "'"
            Else
                dbDataEncerramentoPrevistaInicio = "null"
            End If

            If DDataEncerramento <> Nothing Then
                dbDataEncerramento = DDataEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramento) Then
                    dbDataEncerramento += " " + HoraEncerramento + ":00"
                End If
                dbDataEncerramento = "'" + dbDataEncerramento + "'"
            Else
                dbDataEncerramento = "null"
            End If

            If DDataEncerramento <> Nothing Then
                dbDataAceiteEncerramento = DDataAceiteEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HHoraAceiteEncerramento) Then
                    dbDataAceiteEncerramento += " " + HoraEncerramento + ":00"
                End If
                dbDataAceiteEncerramento = "'" + dbDataAceiteEncerramento + "'"
            Else
                dbDataAceiteEncerramento = "null"
            End If

            If String.IsNullOrEmpty(EncerramentoAceito) Then
                EncerramentoAceito = "N"
            End If

            strSql = ""
            strSql += "insert into chamado("
            strSql += "   empresa, "
            strSql += "   estabelecimento, "
            strSql += "   cod_chamado, "
            strSql += "   cod_emitente, "
            strSql += "   cod_contato, "
            strSql += "   cod_analista, "
            strSql += "   tipo_chamado, "
            strSql += "   numero_serie, "
            strSql += "   cod_usuario, "
            strSql += "   cod_status, "
            strSql += "   data_chamado, "
            strSql += "   data_encerramento_prevista, "
            strSql += "   data_encerramento_prevista_inicio, "
            strSql += "   data_encerramento, "
            strSql += "   assunto, "
            strSql += "   os_cliente, "
            strSql += "   observacao, "
            strSql += "   cnpj, "
            strSql += "   cod_emitente_atendimento, "
            strSql += "   cnpj_atendimento, "
            strSql += "   numero_ponto_atendimento, "
            strSql += "   cod_contato_atendimento, "
            strSql += "   encerramento_aceito, "
            strSql += "   data_aceite_encerramento, "
            strSql += "   ip_aceite_encerramento, "
            strSql += "   modulo_origem, "
            strSql += "   encerrado, "
            strSql += "   cod_sla, "
            strSql += "   cod_sistema, "
            strSql += "   cod_modulo, "
            strSql += "   caminho_menu, "
            strSql += "   programa, "
            strSql += "   seq_prioridade, "
            strSql += "   cod_veiculo) "
            strSql += "  values("
            strSql += Empresa + ", "
            strSql += "1, "
            strSql += CodChamado + ", "
            strSql += CodEmitente + ", "
            strSql += IIf(String.IsNullOrEmpty(CodContato), "null", CodContato) + ", "
            strSql += IIf(String.IsNullOrEmpty(CodAnalista), "null", CodAnalista) + ", "
            strSql += IIf(String.IsNullOrEmpty(TipoChamado), "null", TipoChamado) + ", "
            strSql += IIf(String.IsNullOrEmpty(NumeroSerie), "null", "'" + NumeroSerie + "'") + ", "
            strSql += IIf(String.IsNullOrEmpty(CodUsuario), "null", CodUsuario) + ", "
            strSql += IIf(String.IsNullOrEmpty(CodStatus), "null", CodStatus) + ", "
            strSql += dbDataChamado + ", "
            strSql += dbDataEncerramentoPrevista + ", "
            strSql += dbDataEncerramentoPrevistaInicio + ", "
            strSql += dbDataEncerramento + ", "
            strSql += "'" + Assunto.ToString + "', "
            If String.IsNullOrEmpty(OSCliente) Then
                strSql += "null, "
            Else
                strSql += "'" + OSCliente.ToString.ToUpper + "', "
            End If
            strSql += "'" + Observacao.ToString + "', "
            strSql += "'" + Cnpj + "', "
            strSql += IIf(String.IsNullOrEmpty(CodEmitenteAtendimento), "null", CodEmitenteAtendimento) + ", "
            strSql += IIf(String.IsNullOrEmpty(CnpjAtendimento), "null", "'" + CnpjAtendimento + "'") + ", "
            strSql += IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            strSql += IIf(String.IsNullOrEmpty(CodContatoAtendimento), "null", CodContatoAtendimento) + ", "
            strSql += "'" + EncerramentoAceito + "', "
            strSql += dbDataAceiteEncerramento + ", "
            strSql += "'" + IPAceiteEncerramento + "', "
            strSql += "3, "
            strSql += "'" + Encerrado + "', "
            strSql += IIf(String.IsNullOrWhiteSpace(CodSla), "null", CodSla) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodSistema), "null", CodSistema) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CodModulo), "null", CodModulo) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(CaminhoMenu), "null", "'" + CaminhoMenu + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(Programa), "null", "'" + Programa + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(SeqPrioridade), "null", "'" + SeqPrioridade + "'") + ", "
            strSql += IIf(String.IsNullOrEmpty(CodVeiculo), "null", CodVeiculo) + ")"
            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim strSql As String
            Dim dbDataChamado As String
            Dim dbDataEncerramentoPrevista As String
            Dim dbDataEncerramentoPrevistaInicio As String
            Dim dbDataEncerramento As String
            Dim dbDataAceiteEncerramento As String

            If String.IsNullOrEmpty(EncerramentoAceito) Then
                EncerramentoAceito = "N"
            End If

            If DDataChamado <> Nothing Then
                dbDataChamado = DDataChamado.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraChamado) Then
                    dbDataChamado += " " + HoraChamado + ":00"
                End If
                dbDataChamado = "'" + dbDataChamado + "'"
            Else
                dbDataChamado = "null"
            End If

            If DDataEncerramentoPrevista <> Nothing Then
                dbDataEncerramentoPrevista = DDataEncerramentoPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramentoPrevista) Then
                    dbDataEncerramentoPrevista += " " + HoraEncerramentoPrevista + ":00"
                End If
                dbDataEncerramentoPrevista = "'" + dbDataEncerramentoPrevista + "'"
            Else
                dbDataEncerramentoPrevista = "null"
            End If

            If DDataEncerramentoPrevistaInicio <> Nothing Then
                dbDataEncerramentoPrevistaInicio = DDataEncerramentoPrevistaInicio.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramentoPrevistaInicio) Then
                    dbDataEncerramentoPrevistaInicio += " " + HoraEncerramentoPrevistaInicio + ":00"
                End If
                dbDataEncerramentoPrevistaInicio = "'" + dbDataEncerramentoPrevistaInicio + "'"
            Else
                dbDataEncerramentoPrevistaInicio = "null"
            End If

            If DDataEncerramento <> Nothing Then
                dbDataEncerramento = DDataEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEncerramento) Then
                    dbDataEncerramento += " " + HoraEncerramento + ":00"
                End If
                dbDataEncerramento = "'" + dbDataEncerramento + "'"
            Else
                dbDataEncerramento = "null"
            End If

            If DDataAceiteEncerramento <> Nothing Then
                dbDataAceiteEncerramento = DDataAceiteEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HHoraAceiteEncerramento) Then
                    dbDataAceiteEncerramento += " " + HHoraAceiteEncerramento + ":00"
                End If
                dbDataAceiteEncerramento = "'" + dbDataAceiteEncerramento + "'"
            Else
                dbDataAceiteEncerramento = "null"
            End If

            strSql = ""
            strSql += "update chamado"
            strSql += "   set cod_emitente               = " + CodEmitente + ", "
            strSql += "       cod_usuario                = " + IIf(String.IsNullOrEmpty(CodUsuario), "null", CodUsuario) + ", "
            strSql += "       cod_contato                = " + IIf(String.IsNullOrEmpty(CodContato), "null", CodContato) + ", "
            strSql += "       cod_analista               = " + IIf(String.IsNullOrEmpty(CodAnalista), "null", CodAnalista) + ", "
            strSql += "       tipo_chamado               = " + IIf(String.IsNullOrEmpty(TipoChamado), "null", TipoChamado) + ", "
            strSql += "       numero_serie               = " + IIf(String.IsNullOrEmpty(NumeroSerie), "null", "'" + NumeroSerie + "'") + ", "
            strSql += "       cod_status                 = " + IIf(String.IsNullOrEmpty(CodStatus), "null", CodStatus) + ", "
            strSql += "       data_chamado               = " + dbDataChamado + ", "
            strSql += "       data_encerramento_prevista = " + dbDataEncerramentoPrevista + ", "
            strSql += "       data_encerramento_prevista_inicio = " + dbDataEncerramentoPrevistaInicio + ", "
            strSql += "       data_encerramento          = " + dbDataEncerramento + ", "
            strSql += "       assunto                    = '" + Assunto + "', "
            strSql += "       os_cliente                 = '" + OSCliente.ToUpper + "', "
            strSql += "       observacao                 = '" + Observacao + "', "
            strSql += "       cnpj                       = '" + Cnpj + "', "
            strSql += "       encerramento_aceito        = '" + EncerramentoAceito + "', "
            strSql += "       data_aceite_encerramento   = " + dbDataAceiteEncerramento + ", "
            strSql += "       ip_aceite_encerramento     = '" + IPAceiteEncerramento + "', "
            strSql += "       encerrado                  = '" + Encerrado + "', "
            strSql += "       estabelecimento            = isnull(estabelecimento,1), "
            strSql += "       cod_sla                    = " + IIf(String.IsNullOrWhiteSpace(CodSla), "null", CodSla) + ", "
            strSql += "       cod_sistema                = " + IIf(String.IsNullOrWhiteSpace(CodSistema), "null", CodSistema) + ", "
            strSql += "       cod_modulo                 = " + IIf(String.IsNullOrWhiteSpace(CodModulo), "null", CodModulo) + ", "
            strSql += "       caminho_menu               = " + IIf(String.IsNullOrWhiteSpace(CaminhoMenu), "null", "'" + CaminhoMenu + "'") + ", "
            strSql += "       programa                   = " + IIf(String.IsNullOrWhiteSpace(Programa), "null", "'" + Programa + "'") + ", "
            strSql += "       numero_ponto_atendimento   = " + IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            strSql += "       cod_emitente_atendimento   = " + IIf(String.IsNullOrEmpty(CodEmitenteAtendimento), "null", CodEmitenteAtendimento) + ", "
            strSql += "       cnpj_atendimento           = " + IIf(String.IsNullOrEmpty(CnpjAtendimento), "null", "'" + CnpjAtendimento + "'") + ", "
            strSql += "       cod_contato_atendimento    = " + IIf(String.IsNullOrEmpty(CodContatoAtendimento), "null", CodContatoAtendimento) + ", "
            strSql += "       seq_prioridade             = " + IIf(String.IsNullOrWhiteSpace(SeqPrioridade), "null", "'" + SeqPrioridade + "'") + ", "
            strSql += "       cod_veiculo                = " + IIf(String.IsNullOrEmpty(CodVeiculo), "null", CodVeiculo)
            strSql += " where empresa = " + Empresa
            strSql += "   and cod_chamado = " + CodChamado
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_chamado),0) + 1 max from chamado where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function EnviaEmailStatus() As String
        Try
            Dim strSql As String = "select f_email_chamado_cabecalho( " + Empresa + ", " + CodChamado + " ) ret from dummy"
            Dim retorno As String = objAcessoDados.BuscarDadosComTransacao(strSql)
            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExistemOSsAbertas() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select count(1) qtd "
            strSql += "  from pedido_venda "
            strSql += " where empresa         = " + Empresa
            strSql += "   and cod_chamado     = " + CodChamado
            strSql += "   and status_digitacao = 1 "

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("qtd") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNumeroChamado(ByVal pEmpresa As String, ByVal pCodCliente As String, ByVal pOsCliente As String) As String
        Try
            Dim strSql As String = "select cod_chamado from chamado where empresa = " + pEmpresa + " and os_cliente = '" + pOsCliente + "' and cod_emitente = " + pCodCliente
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            Dim ret As String = ""
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("cod_chamado").ToString
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQtdChamadosRespondidos(ByVal pEmpresa As String, ByVal pCodCliente As String, ByVal pCNPJ As String) As Long
        Try
            Dim qtd As Long = 0
            Dim strSql As String = ""
            strSql += " SELECT count(1) qtd "
            strSql += "   FROM chamado c left outer join status_chamado sc on sc.cod_status = c.cod_status "
            strSql += "  WHERE c.empresa         = " + pEmpresa
            strSql += "    AND c.cod_emitente    = " + pCodCliente
            strSql += "    AND isnull(c.cnpj,'') = '" + pCNPJ + "'"
            strSql += "    AND c.modulo_origem   = 3 "
            strSql += "    AND sc.tipo           = 3 "
            strSql += "    AND isnull(c.encerrado,'N') = 'N' "
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd")
            End If
            Return qtd
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
