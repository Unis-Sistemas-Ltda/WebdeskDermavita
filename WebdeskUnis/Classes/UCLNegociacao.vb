Public Class UCLNegociacao
    Inherits System.Web.UI.Page
    Private _CodChamado As String
    Private _CodNegociacao As String
    Private _CodCliente As String
    Private _CNPJ As String
    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodContato As String
    Private _CodCanalVendas As String
    Private _CodCarteira As String
    Private _CodNaturOper As String
    Private _CodAgenteVenda As String
    Private _CodRepresentante As String
    Private _CodEtapaNegociacao As String
    Private _CodModelo As String
    Private _CodFormaPagto As String
    Private _CodCondPagto As String
    Private _CodFonteOrigemNegociacao As String
    Private _CodGestorConta As String
    Private _DataRecontato As String
    Private _Moeda As String
    Private _DDataRecontato As DateTime
    Private _ManterInformado As String
    Private _ProbabilidadeSucesso As String
    Private _Prioridade As String
    Private _Receptividade As String
    Private _TotalMercadoria As String
    Private _TotalPedido As String
    Private _TotalDesconto As String
    Private _TotalICMS As String
    Private _TotalICMSST As String
    Private _TotalIPI As String
    Private _Cabecalho As String
    Private _Rodape As String
    Private _CodStatus As String
    Private _GerarPedido As String
    Private _AuxLabel1 As String
    Private _AuxLabel2 As String
    Private _AuxLabel3 As String
    Private _Observacao As String
    Private _CodTransportadora As String
    Private _Aux1 As String
    Private _Aux2 As String
    Private _Aux3 As String
    Private _DetalhesFormulacao As String
    Private _DetalhesEmbalagem As String
    Private _DetalhesRotulos As String
    Private _DetalhesPrazoEntrega As String
    Private _DetalhesPagamento As String

    Private _DataPrevisaoFechamento As String
    Private _DDataPrevisaoFechamento As Date

    Private _DataEmissaoContrato As String
    Private _DataVencimentoContrato As String
    Public Property DiaVencimentoContrato As String

    Private _DataValidade As String
    Private _DDataValidade As Date
    Private _tipo_frete As String

    Public Property NumeroSerie As String
    Public Property CodTipoObra As String
    Public Property CodModalidadeObra As String
    Public Property CodEstagioObra As String
    Public Property TamanhoObra As String
    Public Property DataCadastramento As String
    Public Property AnexoProposta As String
    Public Property CodFunil As String
    Public DetalhesFormulacao As String
    Public DetalhesEmbalagem As String
    Public DetalhesRotulos As String
    Public DetalhesPrazoEntrega As String
    Public DetalhesPagamento As String

    Private _CodTipoCobrancaOs As String
    Private _CodMotivo As String

    Private objAcessoDados As UCLAcessoDados

    Public Property CodChamado As String
        Get
            Return _CodChamado
        End Get
        Set(value As String)
            _CodChamado = value
        End Set
    End Property

    Public Function GeraNegociacaoAdesaoTEF(pEmpresa As String, pCodEmitente As String)
        Dim retorno As String = ""
        Dim StrSql As String = ""

        Try
            StrSql = "select f_gera_negociacao_campanha_tef(" + pEmpresa + ", " + pCodEmitente + ") "
            objAcessoDados.BuscarDados(StrSql)
        Catch ex As Exception
            Throw ex
        End Try

        Return retorno
    End Function

    Public Function GetCodNaturOper(ByVal pEmpresa As String, ByVal pEstabelelecimento As String, ByVal pCodNegociacaoCliente As String) As String
        Try
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim ret As String

            strSql += " select isnull(cod_natur_oper,'') cod_natur_oper"
            strSql += "   from negociacao_cliente "
            strSql += "  where empresa                = " + pEmpresa
            strSql += "    and estabelecimento        = " + pEstabelelecimento
            strSql += "    and cod_negociacao_cliente = " + pCodNegociacaoCliente

            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("cod_natur_oper")
            Else
                ret = ""
            End If

            ret = ret.Trim

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public ReadOnly Property GetNrPedido() As String
        Get
            Dim strSql As String = "select cod_pedido_venda from pedido_venda where cod_negociacao_cliente = " + CodNegociacao + " and empresa = " + Empresa + " and estabelecimento = " + Estabelecimento
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("cod_pedido_venda").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Public Property CodRepresentante() As String
        Get
            Return _CodRepresentante
        End Get
        Set(ByVal value As String)
            _CodRepresentante = value
        End Set
    End Property

    Public Property AuxLabel1() As String
        Get
            Return _AuxLabel1
        End Get
        Set(ByVal value As String)
            _AuxLabel1 = value
        End Set
    End Property

    Public Property AuxLabel2() As String
        Get
            Return _AuxLabel2
        End Get
        Set(ByVal value As String)
            _AuxLabel2 = value
        End Set
    End Property

    Public Property AuxLabel3() As String
        Get
            Return _AuxLabel3
        End Get
        Set(ByVal value As String)
            _AuxLabel3 = value
        End Set
    End Property

    Public Property Aux1() As String
        Get
            Return _Aux1
        End Get
        Set(ByVal value As String)
            _Aux1 = value
        End Set
    End Property

    Public Property Aux2() As String
        Get
            Return _Aux2
        End Get
        Set(ByVal value As String)
            _Aux2 = value
        End Set
    End Property

    Public Property Aux3() As String
        Get
            Return _Aux3
        End Get
        Set(ByVal value As String)
            _Aux3 = value
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

    Public Property CodTransportadora() As String
        Get
            Return _CodTransportadora
        End Get
        Set(ByVal value As String)
            _CodTransportadora = value
        End Set
    End Property

    Public Property CodNaturOper()
        Get
            Return _CodNaturOper
        End Get
        Set(ByVal value)
            _CodNaturOper = value
        End Set
    End Property

    Public Property GerarPedido()
        Get
            If String.IsNullOrEmpty(_GerarPedido) Then
                _GerarPedido = "N"
            End If
            Return _GerarPedido
        End Get
        Set(ByVal value)
            _GerarPedido = value
        End Set
    End Property

    Public Property CodModelo()
        Get
            Return _CodModelo
        End Get
        Set(ByVal value)
            _CodModelo = value
        End Set
    End Property

    Public Property CodCanalVendas() As String
        Get
            Return _CodCanalVendas
        End Get
        Set(ByVal value As String)
            _CodCanalVendas = value
        End Set
    End Property

    Public Property Rodape() As String
        Get
            Return _Rodape
        End Get
        Set(ByVal value As String)
            _Rodape = value
        End Set
    End Property

    Public Property Moeda() As String
        Get
            Return _Moeda
        End Get
        Set(ByVal value As String)
            _Moeda = value
        End Set
    End Property

    Public Property Cabecalho() As String
        Get
            Return _Cabecalho
        End Get
        Set(ByVal value As String)
            _Cabecalho = value
        End Set
    End Property

    Public Property TotalMercadoria() As String
        Get
            Return _TotalMercadoria
        End Get
        Set(ByVal value As String)
            _TotalMercadoria = value
        End Set
    End Property

    Public Property TotalPedido() As String
        Get
            Return _TotalPedido
        End Get
        Set(ByVal value As String)
            _TotalPedido = value
        End Set
    End Property

    Public Property TotalICMS() As String
        Get
            Return _TotalICMS
        End Get
        Set(ByVal value As String)
            _TotalICMS = value
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

    Public Property TotalICMSST() As String
        Get
            Return _TotalICMSST
        End Get
        Set(ByVal value As String)
            _TotalICMSST = value
        End Set
    End Property

    Public Property TotalIPI() As String
        Get
            Return _TotalIPI
        End Get
        Set(ByVal value As String)
            _TotalIPI = value
        End Set
    End Property

    Public Property TotalDesconto() As String
        Get
            Return _TotalDesconto
        End Get
        Set(ByVal value As String)
            _TotalDesconto = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property CodCliente() As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
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

    Public Property CodFormaPagto() As String
        Get
            Return _CodFormaPagto
        End Get
        Set(ByVal value As String)
            _CodFormaPagto = value
        End Set
    End Property

    Public Property CodCondPagto() As String
        Get
            Return _CodCondPagto
        End Get
        Set(ByVal value As String)
            _CodCondPagto = value
        End Set
    End Property

    Public Property CodFonteOrigemNegociacao() As String
        Get
            Return _CodFonteOrigemNegociacao
        End Get
        Set(ByVal value As String)
            _CodFonteOrigemNegociacao = value
        End Set
    End Property

    Public Property CodCarteira() As String
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As String)
            _CodCarteira = value
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

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
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

    Public Property CodAgenteVenda() As String
        Get
            Return _CodAgenteVenda
        End Get
        Set(ByVal value As String)
            _CodAgenteVenda = value
        End Set
    End Property

    Public Property CodEtapaNegociacao() As String
        Get
            Return _CodEtapaNegociacao
        End Get
        Set(ByVal value As String)
            _CodEtapaNegociacao = value
        End Set
    End Property
    Public Property DataValidade As String
        Get
            If DDataValidade <> Nothing Then
                _DataValidade = DDataValidade.ToString("dd/MM/yyyy")
            End If
            Return _DataValidade
        End Get
        Set(value As String)
            value = value.Trim
            If Not String.IsNullOrEmpty(value) Then
                DDataValidade = value
            Else
                DDataValidade = Nothing
            End If
            _DataValidade = value
        End Set
    End Property
    Public Property DDataValidade() As DateTime
        Get
            Return _DDataValidade
        End Get
        Set(ByVal value As DateTime)
            _DDataValidade = value
        End Set
    End Property

    Public Property DataPrevisaoFechamento As String
        Get
            If _DDataPrevisaoFechamento <> Nothing Then
                _DataPrevisaoFechamento = _DDataPrevisaoFechamento.ToString("dd/MM/yyyy")
            End If
            Return _DataPrevisaoFechamento
        End Get
        Set(value As String)
            value = value.Trim
            If Not String.IsNullOrEmpty(value) Then
                DDataPrevisaoFechamento = value
            Else
                DDataPrevisaoFechamento = Nothing
            End If
            _DataPrevisaoFechamento = value
        End Set
    End Property
    Public Property DDataPrevisaoFechamento() As DateTime
        Get
            Return _DDataPrevisaoFechamento
        End Get
        Set(ByVal value As DateTime)
            _DDataPrevisaoFechamento = value
        End Set
    End Property

    Public Property DDataEmissaoContrato As Date = Nothing

    Public Property DataEmissaoContrato As String
        Get
            If DDataEmissaoContrato <> Nothing Then
                _DataEmissaoContrato = DDataEmissaoContrato.ToString("dd/MM/yyyy")
            End If
            Return _DataEmissaoContrato
        End Get
        Set(value As String)
            value = value.Trim
            If Not String.IsNullOrEmpty(value) Then
                DDataEmissaoContrato = value
            Else
                DDataEmissaoContrato = Nothing
            End If
            _DataEmissaoContrato = value
        End Set
    End Property

    Public Property DDataVencimentoContrato As Date = Nothing

    Public Property DataVencimentoContrato As String
        Get
            If DDataVencimentoContrato <> Nothing Then
                _DataVencimentoContrato = DDataVencimentoContrato.ToString("dd/MM/yyyy")
            End If
            Return _DataVencimentoContrato
        End Get
        Set(value As String)
            value = value.Trim
            If Not String.IsNullOrEmpty(value) Then
                DDataVencimentoContrato = value
            Else
                DDataVencimentoContrato = Nothing
            End If
            _DataVencimentoContrato = value
        End Set
    End Property

    Public Property DDataRecontato() As DateTime
        Get
            Return _DDataRecontato
        End Get
        Set(ByVal value As DateTime)
            _DDataRecontato = value
        End Set
    End Property

    Public Property DataRecontato() As String
        Get
            If DDataRecontato <> Nothing Then
                _DataRecontato = DDataRecontato.ToString("dd/MM/yyyy HH:mm")
            End If
            Return _DataRecontato
        End Get
        Set(ByVal value As String)
            value = value.Trim
            If Not String.IsNullOrEmpty(value) Then
                DDataRecontato = value
            Else
                DDataRecontato = Nothing
            End If
            _DataRecontato = value
        End Set
    End Property

    Public Property ManterInformado() As String
        Get
            Return _ManterInformado
        End Get
        Set(ByVal value As String)
            _ManterInformado = value
        End Set
    End Property

    Public Property Prioridade() As String
        Get
            Return _Prioridade
        End Get
        Set(ByVal value As String)
            _Prioridade = value
        End Set
    End Property

    Public Property Receptividade() As String
        Get
            Return _Receptividade
        End Get
        Set(ByVal value As String)
            _Receptividade = value
        End Set
    End Property

    Public Property ProbabilidadeSucesso() As String
        Get
            Return _ProbabilidadeSucesso
        End Get
        Set(ByVal value As String)
            _ProbabilidadeSucesso = value
        End Set
    End Property

    Public Property CodGestorConta() As String
        Get
            Return _CodGestorConta
        End Get
        Set(ByVal value As String)
            _CodGestorConta = value
        End Set
    End Property

    Public Property tipo_frete() As String
        Get
            Return _tipo_frete
        End Get
        Set(value As String)
            _tipo_frete = value
        End Set
    End Property

    Public Property CodTipoCobrancaOs As String
        Get
            Return _CodTipoCobrancaOs
        End Get
        Set(value As String)
            _CodTipoCobrancaOs = value
        End Set
    End Property

    Public Property CodMotivo As String
        Get
            Return _CodMotivo
        End Get
        Set(value As String)
            _CodMotivo = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Sub BuscarLabelsAuxiliares()
        Dim StrSql As String
        Dim dt As DataTable

        Try
            StrSql = " select aux_negociacao1, aux_negociacao2, aux_negociacao3 "
            StrSql += "  from parametros_venda "
            StrSql += " where empresa = " + Empresa

            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                AuxLabel1 = dt.Rows.Item(0).Item("aux_negociacao1").ToString
                AuxLabel2 = dt.Rows.Item(0).Item("aux_negociacao2").ToString
                AuxLabel3 = dt.Rows.Item(0).Item("aux_negociacao3").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        Estabelecimento = Session("SEstabelecimentoNegociacao")

        If Estabelecimento Is Nothing Then
            Estabelecimento = 1
        End If

        StrSql = " select cod_emitente, "
        StrSql += "       estabelecimento, "
        StrSql += "       cnpj, "
        StrSql += "       cod_chamado, "
        StrSql += "       isnull(cod_contato,0) cod_contato, "
        StrSql += "       isnull(cod_agente_venda,0) cod_agente_venda, "
        StrSql += "       cod_etapa, cod_funil,"
        StrSql += "       isnull(cod_cond_pagto,0) cod_cond_pagto, "
        StrSql += "       isnull(cod_forma_pagamento,0) cod_forma_pagamento, "
        StrSql += "       data_recontato, "
        StrSql += "       data_validade, "
        StrSql += "       data_previsao_fechamento, "
        StrSql += "       data_emissao_contrato, "
        StrSql += "       data_vencimento_contrato, "
        StrSql += "       dia_vencimento_contrato, "
        StrSql += "       manter_informado, "
        StrSql += "       probabilidade_sucesso, "
        StrSql += "       isnull(prioridade,'M') prioridade, "
        StrSql += "       isnull(receptividade,'M') receptividade, "
        StrSql += "       isnull(cod_carteira,0) cod_carteira, "
        StrSql += "       isnull(cod_gestor_conta,0) cod_gestor_conta, "
        StrSql += "       isnull(total_mercadoria,0) total_mercadoria, "
        StrSql += "       isnull(total_pedido,0) total_pedido, "
        StrSql += "       isnull(total_desconto,0) total_desconto, "
        StrSql += "       isnull(total_icms,0) total_icms, "
        StrSql += "       isnull(total_ipi,0) total_ipi, "
        StrSql += "       isnull(cod_indicador,'1') cod_indicador, "
        StrSql += "       isnull(total_icms_substituicao,0) total_icms_substituicao, "
        StrSql += "       isnull(cabecalho_proposta,'') cabecalho, "
        StrSql += "       isnull(rodape_proposta,'') rodape, "
        StrSql += "       cod_fonte, "
        StrSql += "       isnull(cod_natur_oper,'0') cod_natur_oper, "
        StrSql += "       isnull(cod_status,0) cod_status, "
        StrSql += "       isnull(cod_canal_venda,0) cod_canal_venda, "
        StrSql += "       isnull(cod_modelo,0) cod_modelo, "
        StrSql += "       isnull(gerou_pedido,'N') gerar_pedido, "
        StrSql += "       aux_1, "
        StrSql += "       aux_2, "
        StrSql += "       aux_3, "
        StrSql += "       isnull(cod_representante,0) cod_representante,"
        StrSql += "       observacao, "
        StrSql += "       cod_transportadora, "
        StrSql += "       isnull(cod_tipo_obra,1) cod_tipo_obra, "
        StrSql += "       isnull(cod_modalidade_obra,1) cod_modalidade_obra, "
        StrSql += "       isnull(cod_estagio_obra,1) cod_estagio_obra,  "
        StrSql += "       isnull(data_cadastramento,getdate()) data_cadastramento,  "
        StrSql += "       tamanho_obra, isnull(anexo_proposta,'') anexo_proposta,"
        StrSql += "       tipo_frete, isnull(numero_serie,'') numero_serie, "
        StrSql += "       isnull(cod_motivo,0) cod_motivo, "
        StrSql += "       isnull(cod_tipo_cobranca_os,0) cod_tipo_cobranca_os, "
        StrSql += "       detalhes_formulacao, "
        StrSql += "       detalhes_embalagem, "
        StrSql += "       detalhes_rotulos, "
        StrSql += "       detalhes_prazo_entrega, "
        StrSql += "       detalhes_pagamento "
        StrSql += "  from negociacao_cliente"
        StrSql += " where empresa = " + Empresa
        StrSql += "   and cod_negociacao_cliente = " + CodNegociacao

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            DataCadastramento = CType(dt.Rows.Item(0).Item("data_cadastramento"), DateTime).ToString("dd/MM/yyyy")
            CodTipoObra = dt.Rows.Item(0).Item("cod_tipo_obra").ToString
            CodChamado = dt.Rows.Item(0).Item("cod_chamado").ToString
            CodModalidadeObra = dt.Rows.Item(0).Item("cod_modalidade_obra").ToString
            CodEstagioObra = dt.Rows.Item(0).Item("cod_estagio_obra").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("tamanho_obra")) Then
                TamanhoObra = CDbl(dt.Rows.Item(0).Item("tamanho_obra")).ToString("F2")
            Else
                TamanhoObra = ""
            End If
            Moeda = dt.Rows.Item(0).Item("cod_indicador").ToString
            CodCliente = dt.Rows.Item(0).Item("cod_emitente").ToString
            Estabelecimento = dt.Rows.Item(0).Item("estabelecimento").ToString
            CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
            CodContato = dt.Rows.Item(0).Item("cod_contato").ToString
            CodAgenteVenda = dt.Rows.Item(0).Item("cod_agente_venda").ToString
            CodRepresentante = dt.Rows.Item(0).Item("cod_representante").ToString
            CodEtapaNegociacao = dt.Rows.Item(0).Item("cod_etapa").ToString
            CodFunil = dt.Rows.Item(0).Item("cod_funil").ToString
            CodCondPagto = dt.Rows.Item(0).Item("cod_cond_pagto").ToString
            CodModelo = dt.Rows.Item(0).Item("cod_modelo").ToString
            CodFormaPagto = dt.Rows.Item(0).Item("cod_forma_pagamento").ToString
            CodNaturOper = dt.Rows.Item(0).Item("cod_natur_oper").ToString
            NumeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
            DataRecontato = dt.Rows.Item(0).Item("data_recontato").ToString
            AnexoProposta = dt.Rows.Item(0).Item("anexo_proposta").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("data_validade")) Then
                DataValidade = CDate(dt.Rows.Item(0).Item("data_validade")).ToString("dd/MM/yyyy")
            Else
                DataValidade = ""
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("data_emissao_contrato")) Then
                DataEmissaoContrato = CDate(dt.Rows.Item(0).Item("data_emissao_contrato")).ToString("dd/MM/yyyy")
            Else
                DataEmissaoContrato = ""
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("data_vencimento_contrato")) Then
                DataVencimentoContrato = CDate(dt.Rows.Item(0).Item("data_vencimento_contrato")).ToString("dd/MM/yyyy")
            Else
                DataVencimentoContrato = ""
            End If
            DiaVencimentoContrato = dt.Rows.Item(0).Item("dia_vencimento_contrato").ToString()
            If Not IsDBNull(dt.Rows.Item(0).Item("data_previsao_fechamento")) Then
                DataPrevisaoFechamento = CDate(dt.Rows.Item(0).Item("data_previsao_fechamento")).ToString("dd/MM/yyyy")
            Else
                DataPrevisaoFechamento = ""
            End If
            CodCanalVendas = dt.Rows.Item(0).Item("cod_canal_venda").ToString
            ManterInformado = dt.Rows.Item(0).Item("manter_informado").ToString
            ProbabilidadeSucesso = dt.Rows.Item(0).Item("probabilidade_sucesso").ToString
            Prioridade = dt.Rows.Item(0).Item("prioridade").ToString
            Receptividade = dt.Rows.Item(0).Item("receptividade").ToString
            CodCarteira = dt.Rows.Item(0).Item("cod_carteira").ToString
            CodGestorConta = dt.Rows.Item(0).Item("cod_gestor_conta").ToString
            TotalMercadoria = CDbl(dt.Rows.Item(0).Item("total_mercadoria").ToString).ToString("F2")
            TotalPedido = CDbl(dt.Rows.Item(0).Item("total_pedido").ToString).ToString("F2")
            TotalDesconto = CDbl(dt.Rows.Item(0).Item("total_desconto").ToString).ToString("F2")
            TotalICMS = CDbl(dt.Rows.Item(0).Item("total_icms").ToString).ToString("F2")
            TotalIPI = CDbl(dt.Rows.Item(0).Item("total_ipi").ToString).ToString("F2")
            TotalICMSST = CDbl(dt.Rows.Item(0).Item("total_icms_substituicao").ToString).ToString("F2")
            CodStatus = dt.Rows.Item(0).Item("cod_status").ToString
            DetalhesFormulacao = dt.Rows.Item(0).Item("detalhes_formulacao").ToString
            DetalhesEmbalagem = dt.Rows.Item(0).Item("detalhes_embalagem").ToString
            DetalhesRotulos = dt.Rows.Item(0).Item("detalhes_rotulos").ToString
            DetalhesPrazoEntrega = dt.Rows.Item(0).Item("detalhes_prazo_entrega").ToString
            DetalhesPagamento = dt.Rows.Item(0).Item("detalhes_pagamento").ToString
            GerarPedido = dt.Rows.Item(0).Item("gerar_pedido").ToString
            Aux1 = dt.Rows.Item(0).Item("aux_1").ToString
            Aux2 = dt.Rows.Item(0).Item("aux_2").ToString
            Aux3 = dt.Rows.Item(0).Item("aux_3").ToString
            CodTransportadora = dt.Rows.Item(0).Item("cod_transportadora").ToString
            Observacao = dt.Rows.Item(0).Item("observacao").ToString
            Cabecalho = dt.Rows.Item(0).Item("cabecalho").ToString
            Rodape = dt.Rows.Item(0).Item("rodape").ToString

            If Not IsDBNull(dt.Rows.Item(0).Item("cod_fonte")) Then
                CodFonteOrigemNegociacao = dt.Rows.Item(0).Item("cod_fonte").ToString
            Else
                CodFonteOrigemNegociacao = Nothing
            End If

            tipo_frete = dt.Rows.Item(0).Item("tipo_frete").ToString
            CodTipoCobrancaOs = dt.Rows(0).Item("cod_tipo_cobranca_os").ToString
            CodMotivo = dt.Rows(0).Item("cod_motivo").ToString

        End If

        Return dt
    End Function

    Public Sub Alterar()
        Dim StrSql As String = ""
        Dim StrSql2 As String
        Dim dt As DataTable
        Dim tmpEtapa As String = ""
        Dim CodModeloAnt As String = ""
        Dim cliant As String
        Dim objCarteira As New UCLCarteiraCRM

        Try
            StrSql2 = "select cod_etapa, cod_emitente, cod_modelo from negociacao_cliente where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao

            dt = objAcessoDados.BuscarDados(StrSql2)
            If dt.Rows.Count > 0 Then
                tmpEtapa = dt.Rows.Item(0).Item("cod_etapa").ToString
                cliant = dt.Rows.Item(0).Item("cod_emitente").ToString
                If IsDBNull(dt.Rows.Item(0).Item("cod_modelo")) Then
                    CodModeloAnt = ""
                Else
                    CodModeloAnt = dt.Rows.Item(0).Item("cod_modelo").ToString
                End If
            Else
                cliant = ""
            End If

            If String.IsNullOrEmpty(CodRepresentante) OrElse CodRepresentante = "0" Then
                objCarteira.CodCarteira = CodCarteira
                objCarteira.Buscar()
                CodRepresentante = objCarteira.CodRepresentante
                If String.IsNullOrEmpty(CodRepresentante) OrElse CodRepresentante = "0" Then
                    CodRepresentante = "null"
                End If
            End If

            If CodModeloAnt <> CodModelo Then
                If Not String.IsNullOrWhiteSpace(CodModelo) Then
                    StrSql2 = "select cabecalho, rodape from modelo_negociacao where empresa = " + Empresa + " and cod_modelo = " + CodModelo
                    dt = objAcessoDados.BuscarDados(StrSql2)
                    If dt.Rows.Count > 0 Then
                        Cabecalho = dt.Rows.Item(0).Item("cabecalho").ToString
                        Rodape = dt.Rows.Item(0).Item("rodape").ToString
                    End If
                End If
            End If


            StrSql += " update negociacao_cliente "
            StrSql += "    set cod_emitente = " + CodCliente + ", "
            StrSql += "        cnpj = '" + CNPJ + "', "
            StrSql += "        cod_contato = " + CodContato + ", "
            StrSql += "        cod_agente_venda = " + CodAgenteVenda + ", "
            StrSql += "        cod_representante = " + CodRepresentante + ", "
            If CodEtapaNegociacao <> tmpEtapa Then
                StrSql += "        cod_etapa = " + CodEtapaNegociacao + ", "
            End If
            StrSql += "        cod_funil = " + IIf(String.IsNullOrEmpty(CodFunil) OrElse CodFunil = "0", "null", CodFunil) + ","
            StrSql += "        cod_cond_pagto = " + CodCondPagto + ", "
            StrSql += "        cod_carteira = " + CodCarteira + ", "
            StrSql += "        cod_gestor_conta = " + CodGestorConta + ", "
            StrSql += "        cod_forma_pagamento = " + CodFormaPagto + ", "
            StrSql += "        cod_canal_venda = " + CodCanalVendas + ", "
            StrSql += "        cod_indicador = " + Moeda + ", "
            StrSql += "        cod_tipo_obra = " + CodTipoObra + ", "
            StrSql += "        cod_modalidade_obra = " + CodModalidadeObra + ", "
            StrSql += "        cod_estagio_obra = " + CodEstagioObra + ", "
            StrSql += "        tamanho_obra = " + IIf(String.IsNullOrWhiteSpace(TamanhoObra), "null", TamanhoObra.Replace(",", ".")) + ", "
            StrSql += "        observacao = '" + Observacao + "', "
            StrSql += "        detalhes_formulacao = '" + DetalhesFormulacao + "', "
            StrSql += "        detalhes_embalagem = '" + DetalhesEmbalagem + "', "
            StrSql += "        detalhes_rotulos = '" + DetalhesRotulos + "', "
            StrSql += "        detalhes_prazo_entrega = '" + DetalhesPrazoEntrega + "', "
            StrSql += "        detalhes_pagamento = '" + DetalhesPagamento + "', "
            If String.IsNullOrEmpty(CodTransportadora) Then
                StrSql += "        cod_transportadora = null,"
            Else
                StrSql += "        cod_transportadora = " + CodTransportadora + ", "
            End If
            If String.IsNullOrEmpty(AnexoProposta) Then
                StrSql += "        anexo_proposta = null,"
            Else
                StrSql += "        anexo_proposta = '" + AnexoProposta + "', "
            End If
            If String.IsNullOrEmpty(NumeroSerie) Then
                StrSql += "        numero_serie = null,"
            Else
                StrSql += "        numero_serie = '" + NumeroSerie + "', "
            End If
            If String.IsNullOrEmpty(CodChamado) Then
                StrSql += "        cod_chamado = null,"
            Else
                StrSql += "        cod_chamado = " + CodChamado + ", "
            End If
            StrSql += "        aux_1 = '" + Aux1 + "', "
            StrSql += "        aux_2 = '" + Aux2 + "', "
            StrSql += "        aux_3 = '" + Aux3 + "', "
            If String.IsNullOrEmpty(CodModelo) Then
                StrSql += "        cod_modelo = null, "
            Else
                StrSql += "        cod_modelo = " + CodModelo + ", "
            End If
            If CodNaturOper = "null" Or String.IsNullOrEmpty(CodNaturOper) Then
                StrSql += "        cod_natur_oper = null, "
            Else
                StrSql += "        cod_natur_oper = '" + CodNaturOper + "', "
            End If
            StrSql += "        cod_status = " + IIf(CodStatus.ToString.Replace("0", "").Trim = "", "null", CodStatus) + ", "
            If DDataRecontato <> Nothing Then
                StrSql += "        data_recontato = '" + DDataRecontato.ToString("yyyy-MM-dd HH:mm") + "', "
            Else
                StrSql += "        data_recontato = null, "
            End If
            If DDataValidade <> Nothing Then
                StrSql += "        data_validade = '" + DDataValidade.ToString("yyyy-MM-dd") + "', "
            Else
                StrSql += "        data_validade = null, "
            End If
            If DDataVencimentoContrato <> Nothing Then
                StrSql += "        data_vencimento_contrato = '" + DDataVencimentoContrato.ToString("yyyy-MM-dd") + "', "
            Else
                StrSql += "        data_vencimento_contrato = null, "
            End If

            StrSql += " dia_vencimento_contrato = " + IIf(String.IsNullOrEmpty(DiaVencimentoContrato), "null", DiaVencimentoContrato) + ", "

            If DDataEmissaoContrato <> Nothing Then
                StrSql += "        data_emissao_contrato = '" + DDataEmissaoContrato.ToString("yyyy-MM-dd") + "', "
            Else
                StrSql += "        data_emissao_contrato = null, "
            End If

            If DDataPrevisaoFechamento <> Nothing Then
                StrSql += "        data_previsao_fechamento = '" + DDataPrevisaoFechamento.ToString("yyyy-MM-dd") + "', "
            Else
                StrSql += "        data_previsao_fechamento = null, "
            End If

            StrSql += "        manter_informado = '" + ManterInformado + "', "
            If String.IsNullOrEmpty(ProbabilidadeSucesso) Then
                StrSql += "        probabilidade_sucesso = null, "
            Else
                StrSql += "        probabilidade_sucesso = " + ProbabilidadeSucesso.Replace(",", ".") + ", "
            End If

            StrSql += "        cabecalho_proposta = '" + Cabecalho + "', "
            StrSql += "        rodape_proposta = '" + Rodape + "', "
            StrSql += "        prioridade = '" + Prioridade + "', "
            StrSql += "        receptividade = '" + Receptividade + "', "
            StrSql += "        tipo_frete = '" + tipo_frete + "', "
            If CodFonteOrigemNegociacao Is Nothing OrElse CodFonteOrigemNegociacao = "0" Then
                StrSql += "    cod_fonte            = null " + ", "
            Else
                StrSql += "    cod_fonte            = " + CodFonteOrigemNegociacao + ", "
            End If

            If String.IsNullOrEmpty(CodMotivo) OrElse CodMotivo = "0" Then
                StrSql += "        cod_motivo = null,"
            Else
                StrSql += "        cod_motivo = " + CodMotivo + ", "
            End If

            If String.IsNullOrEmpty(CodTipoCobrancaOs) OrElse CodTipoCobrancaOs = "0" Then
                StrSql += "        cod_tipo_cobranca_os = null "
            Else
                StrSql += "        cod_tipo_cobranca_os = " + CodTipoCobrancaOs
            End If

            StrSql += "  where cod_negociacao_cliente = " + CodNegociacao
            StrSql += "    and empresa = " + Empresa
            StrSql += "    and estabelecimento = " + Estabelecimento

            objAcessoDados.ExecutarSql("call sp_sysvar();" & StrSql)

            StrSql = " update negociacao_cliente "
            StrSql += "   set gerou_pedido = '" + GerarPedido + "', "
            If GerarPedido = "S" Then
                StrSql += "   situacao = 3 "
            ElseIf GerarPedido = "N" Then
                StrSql += "   situacao = 1 "
            End If
            StrSql += "  where cod_negociacao_cliente = " + CodNegociacao
            StrSql += "    and empresa = " + Empresa
            StrSql += "    and estabelecimento = " + Estabelecimento

            objAcessoDados.ExecutarSql("call sp_sysvar();" & StrSql)

            If Not String.IsNullOrEmpty(cliant) AndAlso cliant <> Me.CodCliente Then
                Dim objFU As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
                objFU.Empresa = Empresa
                objFU.Estabelecimento = Estabelecimento
                objFU.CodNegociacaoCliente = CodNegociacao
                objFU.CodEmitente = CodCliente
                objFU.AlterarEmitenteNegociacao()
            End If

            'If CodEtapaNegociacao <> tmpEtapa Then
            '    If Not String.IsNullOrEmpty(Me.ManterInformado) Then
            '        Call EnviaEmailAlteracaoStatus()
            '    End If
            'End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function CopiaNegociacao(ByVal empresa As String, ByVal estabelecimento As String, ByVal negociacao As String) As String
        Dim strSql As String = "select f_copia_negociacao(" + empresa + "," + estabelecimento + "," + negociacao + ") novaneg"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim novaneg As String = ""

        If dt.Rows.Count > 0 Then
            novaneg = dt.Rows.Item(0).Item("novaneg").ToString
        End If

        Return novaneg

    End Function

    Public Sub Incluir()
        Dim strSql As String = ""
        Dim strsql2 As String = ""
        Dim dt As DataTable
        Dim objCarteira As New UCLCarteiraCRM

        Try
            If String.IsNullOrEmpty(CodRepresentante) OrElse CodRepresentante = "0" Then
                objCarteira.CodCarteira = CodCarteira
                objCarteira.Buscar()
                CodRepresentante = objCarteira.CodRepresentante
                If String.IsNullOrEmpty(CodRepresentante) OrElse CodRepresentante = "0" Then
                    CodRepresentante = "null"
                End If
            End If

            If Not String.IsNullOrWhiteSpace(CodModelo) Then
                strsql2 = "select cabecalho, rodape from modelo_negociacao where empresa = " + Empresa + " and cod_modelo = " + CodModelo
                dt = objAcessoDados.BuscarDados(strsql2)
                If dt.Rows.Count > 0 Then
                    If String.IsNullOrWhiteSpace(Cabecalho) Then
                        Cabecalho = dt.Rows.Item(0).Item("cabecalho").ToString
                    End If
                    If String.IsNullOrWhiteSpace(Rodape) Then
                        Rodape = dt.Rows.Item(0).Item("rodape").ToString
                    End If
                End If
            End If

            strSql += " insert into negociacao_cliente( empresa, estabelecimento, cod_negociacao_cliente, cod_emitente, cnpj, cod_agente_venda, cod_indicador, "
            strSql += "    cod_funil, cod_etapa, cod_representante, cod_cond_pagto, data_cadastramento, tipo_frete, total_mercadoria, cenario, total_mercadoria_orig, "
            strSql += "    total_icms, total_ipi, total_desconto, total_pedido, cod_forma_pagamento, cod_contato, cod_fonte, cod_chamado, total_icms_substituicao, cod_status, "
            strSql += "    cabecalho_proposta, rodape_proposta, cod_canal_venda, cod_natur_oper, cod_modelo, gerou_pedido, Observacao, aux_2, aux_3, "
            strSql += "    cod_tipo_obra, cod_modalidade_obra, cod_estagio_obra, tamanho_obra, numero_serie, anexo_proposta, data_emissao_contrato, data_vencimento_contrato, dia_vencimento_contrato, "
            strSql += "    detalhes_formulacao, detalhes_embalagem, detalhes_rotulos, detalhes_prazo_entrega, detalhes_pagamento, "
            strSql += "    data_recontato, data_validade, data_previsao_fechamento, manter_informado, probabilidade_sucesso, prioridade, receptividade, cod_carteira, cod_gestor_conta, cod_tipo_cobranca_os, cod_motivo ) values ("
            strSql += Empresa + ", "
            strSql += Estabelecimento + ", "
            strSql += CodNegociacao + ", "
            strSql += CodCliente + ", "
            strSql += "'" + CNPJ + "', "
            strSql += CodAgenteVenda + ", "
            strSql += "'" + Moeda + "', "
            strSql += IIf(String.IsNullOrEmpty(CodFunil) OrElse CodFunil = "0", "null", CodFunil) + ","
            strSql += IIf(String.IsNullOrEmpty(CodEtapaNegociacao) OrElse CodEtapaNegociacao = "0", "null", CodEtapaNegociacao) + ","
            strSql += CodRepresentante + ", "
            strSql += CodCondPagto + ", "
            strSql += "now(), "
            strSql += tipo_frete + ", "
            strSql += "0, " 'Total Mercadoria calculado nos itens
            strSql += "1, " 'Cenário = 1-Unico ou 2-Multi
            strSql += "0, " 'Total Mercadoria Original calculado nos itens
            strSql += "0, " 'Total ICMS calculado nos itens
            strSql += "0, " 'Total IPI calculado nos itens
            strSql += "0, " 'Total Desconto calculado nos itens
            strSql += "0, " 'Total Pedido calculado nos itens
            strSql += CodFormaPagto + ", "
            strSql += CodContato + ", "

            If CodFonteOrigemNegociacao Is Nothing Then
                strSql += "null, "
            Else
                strSql += CodFonteOrigemNegociacao + ", "
            End If
            If String.IsNullOrEmpty(CodChamado) Then
                strSql += "null, "
            Else
                strSql += CodChamado + ", "
            End If

            strSql += "0, " 'Total ICMS ST calculado nos itens
            strSql += CodStatus + ", "

            strSql += "'" + Cabecalho + "', "
            strSql += "'" + Rodape + "', "

            strSql += CodCanalVendas + ", "

            If CodNaturOper = "null" Then
                strSql += "null, "
            Else
                strSql += "'" + CodNaturOper + "', "
            End If

            strSql += CodModelo + ", "
            strSql += "'" + GerarPedido + "', "

            strSql += "'" + Observacao + "', "
            strSql += "'" + Aux2 + "', "
            strSql += "'" + Aux3 + "', "

            strSql += CodTipoObra + ", "
            strSql += CodModalidadeObra + ", "
            strSql += CodEstagioObra + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(TamanhoObra), "null", TamanhoObra.Replace(",", ".")) + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null", "'" + NumeroSerie.Replace(",", ".") + "'") + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(AnexoProposta), "null", "'" + AnexoProposta + "'") + ", "

            If DDataEmissaoContrato <> Nothing Then
                strSql += "'" + DDataEmissaoContrato.ToString("yyyy-MM-dd HH:mm") + "', "
            Else
                strSql += "null, "
            End If

            If DDataVencimentoContrato <> Nothing Then
                strSql += "'" + DDataVencimentoContrato.ToString("yyyy-MM-dd HH:mm") + "', "
            Else
                strSql += "null, "
            End If

            strSql += "'" + DetalhesFormulacao + "', "
            strSql += "'" + DetalhesEmbalagem + "', "
            strSql += "'" + DetalhesRotulos + "', "
            strSql += "'" + DetalhesPrazoEntrega + "', "
            strSql += "'" + DetalhesPagamento + "', "

            strSql += IIf(String.IsNullOrEmpty(DiaVencimentoContrato), "null", DiaVencimentoContrato) + ", "

            If DDataRecontato <> Nothing Then
                strSql += "'" + DDataRecontato.ToString("yyyy-MM-dd HH:mm") + "', "
            Else
                strSql += "null, "
            End If
            If DDataValidade <> Nothing Then
                strSql += "'" + DDataValidade.ToString("yyyy-MM-dd") + "', "
            Else
                strSql += "null, "
            End If
            If DDataPrevisaoFechamento <> Nothing Then
                strSql += "'" + DDataPrevisaoFechamento.ToString("yyyy-MM-dd") + "', "
            Else
                strSql += "null, "
            End If
            strSql += "'" + ManterInformado + "', "
            strSql += ProbabilidadeSucesso.Replace(",", ".") + ", "
            strSql += "'" + Prioridade + "', "
            strSql += "'" + Receptividade + "', "
            strSql += CodCarteira + ", "
            strSql += CodGestorConta + ", "
            strSql += CodMotivo + ", "
            strSql += CodTipoCobrancaOs + ")"

            objAcessoDados.ExecutarSql("call sp_sysvar();" & strSql)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_negociacao_cliente),0) + 1 max from negociacao_cliente "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function DadosNegociacao() As DataTable
        Dim strSql As String = "call sp_imp_negociacao_crm(" + Empresa + ", " + Estabelecimento + ", " + CodNegociacao + ");"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Return dt
    End Function


    Public Function TemItens() As Boolean
        Try
            Dim StrSql As String = "select count(1) qtd from negociacao_cliente_item where empresa = " + Empresa + " and cod_negociacao_cliente = " + CodNegociacao
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return (dt.Rows.Item(0).Item("qtd") > 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TemMotivoDeFechamentoOuPerda(ByVal empresa As String, ByVal estabelecimento As String, ByVal codNegociacaoCliente As String) As Boolean
        Try
            Dim StrSql As String = "select count(1) qtd from negociacao_cliente_motivo_fechamento where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_negociacao_cliente = " + codNegociacaoCliente
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return (dt.Rows.Item(0).Item("qtd") > 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCodEtapa(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String) As String
        Dim StrSql As String = "select cod_etapa from negociacao_cliente where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_etapa")) Then
                Return dt.Rows.Item(0).Item("cod_etapa").ToString()
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            'Delete negociacao_cliente_etapas
            strSql = " delete from negociacao_cliente_etapas where empresa = " + Empresa + " and estabelecimento = '" + Estabelecimento + "' and cod_negociacao_cliente = " + CodNegociacao
            objAcessoDados.ExecutarSql(strSql)
            'Delete negociacao_cliente_item
            strSql = " delete from negociacao_cliente_item where empresa = " + Empresa + " and estabelecimento = '" + Estabelecimento + "' and cod_negociacao_cliente = " + CodNegociacao
            objAcessoDados.ExecutarSql(strSql)
            'Delete negociacao_tarefa
            strSql = " delete from negociacao_tarefa where empresa = " + Empresa + " and estabelecimento = '" + Estabelecimento + "' and cod_negociacao_cliente = " + CodNegociacao
            objAcessoDados.ExecutarSql(strSql)
            'Delete negociacao_cliente
            strSql = " delete from negociacao_cliente where empresa = " + Empresa + " and estabelecimento = '" + Estabelecimento + "' and cod_negociacao_cliente = " + CodNegociacao
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
