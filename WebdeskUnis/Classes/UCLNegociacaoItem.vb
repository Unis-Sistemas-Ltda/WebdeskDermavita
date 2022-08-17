Public Class UCLNegociacaoItem

    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodNegociacao As String
    Private _SeqItem As String
    Private _CodItem As String
    Private _Quantidade As String
    Private _QuantidadeUD As String
    Private _PrecoUnitario As String
    Private _PrecoUnitarioUD As String
    Private _CodUnidade As String
    Private _PercentualDesconto As String
    Private _ValorDesconto As String
    Private _ValorTotal As String
    Private _ICMSST As String
    Private _IPI As String
    Private _Narrativa As String
    Private _ValorMercadoria As String
    Private _ICMS As String
    Private _CodNaturOper As String
    Private _CodCliente As String
    Private _CNPJCliente As String
    Private _AliquotaICMS As String
    Private _AliquotaIPI As String
    Private _BaseICMSSubstituicao As String
    Private _Altura As String
    Private _Largura As String
    Private _Espessura As String
    Private _Aux1 As String
    Private _Aux2 As String
    Private _Aux3 As String
    Private _Aux4 As String
    Private _Aux5 As String
    Private _Aux6 As String
    Private _Aux7 As String
    Private _Aux8 As String
    Private _Aux9 As String
    Private _Aux10 As String
    Private _Aux11 As String
    Private _Aux12 As String
    Private _Aux1Label As String
    Private _Aux2Label As String
    Private _Aux3Label As String
    Private _Aux4Label As String
    Private _Aux5Label As String
    Private _Aux6Label As String
    Private _Aux7Label As String
    Private _Aux8Label As String
    Private _Aux9Label As String
    Private _Aux10Label As String
    Private _Aux11Label As String
    Private _Aux12Label As String
    Private _FdNomeProduto As String
    Private _FdAcaoDesejadaFuncao As String
    Private _FdColoracao As String
    Private _FdCorReferencia As String
    Private _FdOdor As String
    Private _FdOdorDirecionamento As String
    Private _FdOdorReferencia As String
    Private _FdDescricaoProduto As String
    Private objAcessoDados As UCLAcessoDados
    Public Property PercAcrescimoUnitario As String
    Public Property PercDescontoUnitario1 As String
    Public Property PercDescontoUnitario2 As String
    Public Property PercDescontoUnitario3 As String
    Public Property PercDescontoUnitario4 As String
    Public Property PercDescontoUnitario5 As String
    Public Property Recurso As String
    Public Property Lote As String
    Public Property PrecoUnitarioTabela As String
    Public Property PrecoUnitarioSemComponente As String
    Public Property PrazoEntrega As String
    Public Property TpPrazoEntrega As String
    Public Property NumeroSerie As String
    Public Property Referencia() As String

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return _SeqItem
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Public Property CodItem() As String
        Get
            Return _CodItem
        End Get
        Set(ByVal value As String)
            _CodItem = value
        End Set
    End Property

    Public Property AliquotaICMS() As String
        Get
            Return _AliquotaICMS
        End Get
        Set(ByVal value As String)
            _AliquotaICMS = value
        End Set
    End Property

    Public Property AliquotaIPI() As String
        Get
            Return _AliquotaIPI
        End Get
        Set(ByVal value As String)
            _AliquotaIPI = value
        End Set
    End Property

    Public Property BaseICMSSubstituicao() As String
        Get
            Return _BaseICMSSubstituicao
        End Get
        Set(ByVal value As String)
            _BaseICMSSubstituicao = value
        End Set
    End Property

    Public Property Quantidade() As String
        Get
            Return _Quantidade
        End Get
        Set(ByVal value As String)
            _Quantidade = value
        End Set
    End Property

    Public Property QuantidadeUD() As String
        Get
            Return _QuantidadeUD
        End Get
        Set(ByVal value As String)
            _QuantidadeUD = value
        End Set
    End Property

    Public Property PrecoUnitario() As String
        Get
            Return _PrecoUnitario
        End Get
        Set(ByVal value As String)
            _PrecoUnitario = value
        End Set
    End Property

    Public Property PrecoUnitarioUD() As String
        Get
            Return _PrecoUnitarioUD
        End Get
        Set(ByVal value As String)
            _PrecoUnitarioUD = value
        End Set
    End Property


    Public Property CodUnidade() As String
        Get
            Return _CodUnidade
        End Get
        Set(ByVal value As String)
            _CodUnidade = value
        End Set
    End Property

    Public Property Altura() As String
        Get
            Return _Altura
        End Get
        Set(ByVal value As String)
            _Altura = value
        End Set
    End Property

    Public Property Largura() As String
        Get
            Return _Largura
        End Get
        Set(ByVal value As String)
            _Largura = value
        End Set
    End Property

    Public Property Espessura() As String
        Get
            Return _Espessura
        End Get
        Set(ByVal value As String)
            _Espessura = value
        End Set
    End Property

    Public Property ValorTotal() As String
        Get
            Return _ValorTotal
        End Get
        Set(ByVal value As String)
            _ValorTotal = value
        End Set
    End Property

    Public Property ICMSST() As String
        Get
            Return _ICMSST
        End Get
        Set(ByVal value As String)
            _ICMSST = value
        End Set
    End Property

    Public Property IPI() As String
        Get
            Return _IPI
        End Get
        Set(ByVal value As String)
            _IPI = value
        End Set
    End Property

    Public Property Narrativa() As String
        Get
            Return _Narrativa
        End Get
        Set(ByVal value As String)
            _Narrativa = value
        End Set
    End Property

    Public Property ValorMercadoria() As String
        Get
            Return _ValorMercadoria
        End Get
        Set(ByVal value As String)
            _ValorMercadoria = value
        End Set
    End Property

    Public Property ICMS() As String
        Get
            Return _ICMS
        End Get
        Set(ByVal value As String)
            _ICMS = value
        End Set
    End Property

    Public Property PercentualDesconto() As String
        Get
            If String.IsNullOrEmpty(_PercentualDesconto) Then
                _PercentualDesconto = 0
            End If
            Return _PercentualDesconto
        End Get
        Set(ByVal value As String)
            _PercentualDesconto = value
        End Set
    End Property

    Public Property ValorDesconto() As String
        Get
            Return _ValorDesconto
        End Get
        Set(ByVal value As String)
            _ValorDesconto = value
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

    Public Property CodNaturOper() As String
        Get
            Return _CodNaturOper
        End Get
        Set(ByVal value As String)
            _CodNaturOper = value
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

    Public Property CNPJCliente() As String
        Get
            Return _CNPJCliente
        End Get
        Set(ByVal value As String)
            _CNPJCliente = value
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

    Public Property Aux4() As String
        Get
            Return _Aux4
        End Get
        Set(ByVal value As String)
            _Aux4 = value
        End Set
    End Property

    Public Property Aux5() As String
        Get
            Return _Aux5
        End Get
        Set(ByVal value As String)
            _Aux5 = value
        End Set
    End Property

    Public Property Aux6() As String
        Get
            Return _Aux6
        End Get
        Set(ByVal value As String)
            _Aux6 = value
        End Set
    End Property

    Public Property Aux7() As String
        Get
            Return _Aux7
        End Get
        Set(ByVal value As String)
            _Aux7 = value
        End Set
    End Property

    Public Property Aux8() As String
        Get
            Return _Aux8
        End Get
        Set(ByVal value As String)
            _Aux8 = value
        End Set
    End Property

    Public Property Aux9() As String
        Get
            Return _Aux9
        End Get
        Set(ByVal value As String)
            _Aux9 = value
        End Set
    End Property

    Public Property Aux10() As String
        Get
            Return _Aux10
        End Get
        Set(ByVal value As String)
            _Aux10 = value
        End Set
    End Property

    Public Property Aux11() As String
        Get
            Return _Aux11
        End Get
        Set(ByVal value As String)
            _Aux11 = value
        End Set
    End Property

    Public Property Aux12() As String
        Get
            Return _Aux12
        End Get
        Set(ByVal value As String)
            _Aux12 = value
        End Set
    End Property

    Public Property Aux1Label() As String
        Get
            Return _Aux1Label
        End Get
        Set(ByVal value As String)
            _Aux1Label = value
        End Set
    End Property

    Public Property Aux2Label() As String
        Get
            Return _Aux2Label
        End Get
        Set(ByVal value As String)
            _Aux2Label = value
        End Set
    End Property

    Public Property Aux3Label() As String
        Get
            Return _Aux3Label
        End Get
        Set(ByVal value As String)
            _Aux3Label = value
        End Set
    End Property

    Public Property Aux4Label() As String
        Get
            Return _Aux4Label
        End Get
        Set(ByVal value As String)
            _Aux4Label = value
        End Set
    End Property

    Public Property Aux5Label() As String
        Get
            Return _Aux5Label
        End Get
        Set(ByVal value As String)
            _Aux5Label = value
        End Set
    End Property

    Public Property Aux6Label() As String
        Get
            Return _Aux6Label
        End Get
        Set(ByVal value As String)
            _Aux6Label = value
        End Set
    End Property

    Public Property Aux7Label() As String
        Get
            Return _Aux7Label
        End Get
        Set(ByVal value As String)
            _Aux7Label = value
        End Set
    End Property

    Public Property Aux8Label() As String
        Get
            Return _Aux8Label
        End Get
        Set(ByVal value As String)
            _Aux8Label = value
        End Set
    End Property

    Public Property Aux9Label() As String
        Get
            Return _Aux9Label
        End Get
        Set(ByVal value As String)
            _Aux9Label = value
        End Set
    End Property

    Public Property Aux10Label() As String
        Get
            Return _Aux10Label
        End Get
        Set(ByVal value As String)
            _Aux10Label = value
        End Set
    End Property

    Public Property Aux11Label() As String
        Get
            Return _Aux11Label
        End Get
        Set(ByVal value As String)
            _Aux11Label = value
        End Set
    End Property

    Public Property Aux12Label() As String
        Get
            Return _Aux12Label
        End Get
        Set(ByVal value As String)
            _Aux12Label = value
        End Set
    End Property

    Public Property FdAcaoDesejadaFuncao() As String
        Get
            Return _FdAcaoDesejadaFuncao
        End Get
        Set(ByVal value As String)
            _FdAcaoDesejadaFuncao = value
        End Set
    End Property
    Public Property FdColoracao() As String
        Get
            Return _FdColoracao
        End Get
        Set(ByVal value As String)
            _FdColoracao = value
        End Set
    End Property
    Public Property FdCorReferencia() As String
        Get
            Return _FdCorReferencia
        End Get
        Set(ByVal value As String)
            _FdCorReferencia = value
        End Set
    End Property
    Public Property FdDescricaoProduto() As String
        Get
            Return _FdDescricaoProduto
        End Get
        Set(ByVal value As String)
            _FdDescricaoProduto = value
        End Set
    End Property
    Public Property FdNomeProduto() As String
        Get
            Return _FdNomeProduto
        End Get
        Set(ByVal value As String)
            _FdNomeProduto = value
        End Set
    End Property
    Public Property FdOdor() As String
        Get
            Return _FdOdor
        End Get
        Set(ByVal value As String)
            _FdOdor = value
        End Set
    End Property
    Public Property FdOdorDirecionamento() As String
        Get
            Return _FdOdorDirecionamento
        End Get
        Set(ByVal value As String)
            _FdOdorDirecionamento = value
        End Set
    End Property
    Public Property FdOdorReferencia() As String
        Get
            Return _FdOdorReferencia
        End Get
        Set(ByVal value As String)
            _FdOdorReferencia = value
        End Set
    End Property


    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As DataTable
        Dim strSql As String = ""
        Dim dt As DataTable

        Try

            strSql += " select ni.cod_item,"
            strSql += "        ni.referencia, "
            strSql += "        ni.lote, "
            strSql += "        ni.qtd_pedida, "
            strSql += "        isnull(ni.qtd_ud,0) qtd_ud, "
            strSql += "        isnull(ni.cod_unidade,'0') cod_unidade, "
            strSql += "        ni.preco_unitario, "
            strSql += "        isnull(ni.preco_unitario_ud,0) preco_unitario_ud, "
            strSql += "        ni.narrativa, "
            strSql += "        isnull(ni.icms_substituicao,0) icms_substituicao, "
            strSql += "        isnull(ni.valor_ipi,0) valor_ipi, "
            strSql += "        isnull(ni.perc_desconto,0) perc_desconto, "
            strSql += "        isnull(ni.valor_desconto,0) valor_desconto,"
            strSql += "        isnull(ni.valor_icms,0) valor_icms,"
            strSql += "        ni.valor_mercadoria, "
            strSql += "        ni.valor_total_mercadoria, "
            strSql += "        ni.cod_natur_oper, "
            strSql += "        n.cod_emitente, "
            strSql += "        n.cnpj, "
            strSql += "        isnull(ni.base_icms_substituicao,0) base_icms_substituicao, "
            strSql += "        isnull(ni.aliquota_icms,0) aliquota_icms, "
            strSql += "        isnull(ni.aliquota_ipi,0) aliquota_ipi, "
            strSql += "        ni.aux1, "
            strSql += "        ni.aux2, "
            strSql += "        ni.aux3, "
            strSql += "        ni.aux4, "
            strSql += "        ni.aux5, "
            strSql += "        ni.aux6, "
            strSql += "        ni.aux7, "
            strSql += "        ni.aux8, "
            strSql += "        ni.aux9, "
            strSql += "        ni.aux10, "
            strSql += "        ni.aux11, "
            strSql += "        ni.aux12, "
            strSql += "        par.aux_ng_item1, "
            strSql += "        par.aux_ng_item2, "
            strSql += "        par.aux_ng_item3, "
            strSql += "        par.aux_ng_item4, "
            strSql += "        par.aux_ng_item5, "
            strSql += "        par.aux_ng_item6, "
            strSql += "        par.aux_ng_item7, "
            strSql += "        par.aux_ng_item8, "
            strSql += "        par.aux_ng_item9, "
            strSql += "        par.aux_ng_item10, "
            strSql += "        par.aux_ng_item11, "
            strSql += "        par.aux_ng_item12, "
            strSql += "        ni.fd_nome_produto, "
            strSql += "        ni.fd_acao_desejada_funcao, "
            strSql += "        ni.fd_coloracao, "
            strSql += "        ni.fd_cor_referencia, "
            strSql += "        ni.fd_odor, "
            strSql += "        ni.fd_odor_direcionamento, "
            strSql += "        ni.fd_odor_referencia, "
            strSql += "        ni.fd_descricao_produto, "
            strSql += "        isnull(ni.largura,0) largura, "
            strSql += "        isnull(ni.altura,0) altura, "
            strSql += "        isnull(ni.espessura,0) espessura, "
            strSql += "        isnull(ni.preco_unitario_tabela,0) preco_unitario_tabela, "
            strSql += "        isnull(ni.preco_unitario_sem_componente,0) preco_unitario_sem_componente, "
            strSql += "        isnull(ni.perc_desconto_unitario1,0) perc_desconto_unitario1, "
            strSql += "        isnull(ni.perc_desconto_unitario2,0) perc_desconto_unitario2, "
            strSql += "        isnull(ni.perc_desconto_unitario3,0) perc_desconto_unitario3, "
            strSql += "        isnull(ni.perc_desconto_unitario4,0) perc_desconto_unitario4, "
            strSql += "        isnull(ni.perc_desconto_unitario5,0) perc_desconto_unitario5, "
            strSql += "        isnull(ni.perc_acrescimo_unitario,0) perc_acrescimo_unitario, "
            strSql += "        prazo_entrega, "
            strSql += "        tp_prazo_entrga tp_prazo_entrega, "
            strSql += "        isnull(ni.recurso,0) recurso, "
            strSql += "        isnull(ni.numero_serie,'') numero_serie "
            strSql += "   from negociacao_cliente_item ni inner join negociacao_cliente n on n.empresa = ni.empresa and n.estabelecimento = ni.estabelecimento and n.cod_negociacao_cliente = ni.cod_negociacao_cliente "
            strSql += "                                   left outer join parametros_venda par on ni.empresa = par.empresa "
            strSql += "  where ni.empresa = " + Empresa
            strSql += "    and ni.cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and ni.seq_item = " + SeqItem
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                NumeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                CodItem = dt.Rows.Item(0).Item("cod_item").ToString
                Referencia = dt.Rows.Item(0).Item("referencia").ToString
                Lote = dt.Rows.Item(0).Item("lote").ToString
                Quantidade = CDbl(dt.Rows.Item(0).Item("qtd_pedida").ToString).ToString("F4")
                QuantidadeUD = CDbl(dt.Rows.Item(0).Item("qtd_ud").ToString).ToString("F4")
                PrecoUnitario = CDbl(dt.Rows.Item(0).Item("preco_unitario").ToString).ToString("F4")
                PrecoUnitarioUD = CDbl(dt.Rows.Item(0).Item("preco_unitario_ud").ToString).ToString("F4")
                CodUnidade = dt.Rows.Item(0).Item("cod_unidade").ToString
                ValorTotal = CDbl(dt.Rows.Item(0).Item("valor_total_mercadoria").ToString).ToString("F2")
                ICMSST = CDbl(dt.Rows.Item(0).Item("icms_substituicao").ToString).ToString("F2")
                IPI = CDbl(dt.Rows.Item(0).Item("valor_ipi").ToString).ToString("F2")
                Narrativa = dt.Rows.Item(0).Item("narrativa").ToString
                PercentualDesconto = CDbl(dt.Rows.Item(0).Item("perc_desconto").ToString).ToString("F4")
                ValorDesconto = CDbl(dt.Rows.Item(0).Item("valor_desconto").ToString).ToString("F2")
                ValorMercadoria = CDbl(dt.Rows.Item(0).Item("valor_mercadoria").ToString).ToString("F2")
                ICMS = CDbl(dt.Rows.Item(0).Item("valor_icms").ToString).ToString("F2")
                CodNaturOper = dt.Rows.Item(0).Item("cod_natur_oper").ToString
                CodCliente = dt.Rows.Item(0).Item("cod_emitente").ToString
                CNPJCliente = dt.Rows.Item(0).Item("cnpj").ToString
                AliquotaICMS = CDbl(dt.Rows.Item(0).Item("aliquota_icms").ToString).ToString("F2")
                AliquotaIPI = CDbl(dt.Rows.Item(0).Item("aliquota_ipi").ToString).ToString("F2")
                BaseICMSSubstituicao = CDbl(dt.Rows.Item(0).Item("base_icms_substituicao").ToString).ToString("F4")
                Altura = CDbl(dt.Rows.Item(0).Item("altura").ToString).ToString("F2")
                Largura = CDbl(dt.Rows.Item(0).Item("largura").ToString).ToString("F2")
                Espessura = CDbl(dt.Rows.Item(0).Item("espessura").ToString).ToString("F4")
                Aux1 = dt.Rows.Item(0).Item("aux1").ToString
                Aux2 = dt.Rows.Item(0).Item("aux2").ToString
                Aux3 = dt.Rows.Item(0).Item("aux3").ToString
                Aux4 = dt.Rows.Item(0).Item("aux4").ToString
                Aux5 = dt.Rows.Item(0).Item("aux5").ToString
                Aux6 = dt.Rows.Item(0).Item("aux6").ToString
                Aux7 = dt.Rows.Item(0).Item("aux7").ToString
                Aux8 = dt.Rows.Item(0).Item("aux8").ToString
                Aux9 = dt.Rows.Item(0).Item("aux9").ToString
                Aux10 = dt.Rows.Item(0).Item("aux10").ToString
                Aux11 = dt.Rows.Item(0).Item("aux11").ToString
                Aux12 = dt.Rows.Item(0).Item("aux12").ToString
                FdAcaoDesejadaFuncao = dt.Rows.Item(0).Item("fd_acao_desejada_funcao").ToString
                FdColoracao = dt.Rows.Item(0).Item("fd_coloracao").ToString
                FdCorReferencia = dt.Rows.Item(0).Item("fd_cor_referencia").ToString
                FdDescricaoProduto = dt.Rows.Item(0).Item("fd_descricao_produto").ToString
                FdNomeProduto = dt.Rows.Item(0).Item("fd_nome_produto").ToString
                FdOdor = dt.Rows.Item(0).Item("fd_odor").ToString
                FdOdorDirecionamento = dt.Rows.Item(0).Item("fd_odor_direcionamento").ToString
                FdOdorReferencia = dt.Rows.Item(0).Item("fd_odor_referencia").ToString
                Recurso = dt.Rows.Item(0).Item("recurso").ToString
                Aux1Label = dt.Rows.Item(0).Item("aux_ng_item1").ToString
                Aux2Label = dt.Rows.Item(0).Item("aux_ng_item2").ToString
                Aux3Label = dt.Rows.Item(0).Item("aux_ng_item3").ToString
                Aux4Label = dt.Rows.Item(0).Item("aux_ng_item4").ToString
                Aux5Label = dt.Rows.Item(0).Item("aux_ng_item5").ToString
                Aux6Label = dt.Rows.Item(0).Item("aux_ng_item6").ToString
                Aux7Label = dt.Rows.Item(0).Item("aux_ng_item7").ToString
                Aux8Label = dt.Rows.Item(0).Item("aux_ng_item8").ToString
                Aux9Label = dt.Rows.Item(0).Item("aux_ng_item9").ToString
                Aux10Label = dt.Rows.Item(0).Item("aux_ng_item10").ToString
                Aux11Label = dt.Rows.Item(0).Item("aux_ng_item11").ToString
                Aux12Label = dt.Rows.Item(0).Item("aux_ng_item12").ToString
                PrecoUnitarioSemComponente = dt.Rows.Item(0).Item("preco_unitario_sem_componente").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("prazo_entrega")) Then
                    PrazoEntrega = dt.Rows.Item(0).Item("prazo_entrega").ToString
                Else
                    PrazoEntrega = ""
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("tp_prazo_entrega")) Then
                    TpPrazoEntrega = dt.Rows.Item(0).Item("tp_prazo_entrega").ToString
                Else
                    TpPrazoEntrega = "1"
                End If
            Else
                strSql = " select  par.aux_ng_item1, "
                strSql += "        par.aux_ng_item2, "
                strSql += "        par.aux_ng_item3, "
                strSql += "        par.aux_ng_item4, "
                strSql += "        par.aux_ng_item5, "
                strSql += "        par.aux_ng_item6, "
                strSql += "        par.aux_ng_item7, "
                strSql += "        par.aux_ng_item8, "
                strSql += "        par.aux_ng_item9, "
                strSql += "        par.aux_ng_item10, "
                strSql += "        par.aux_ng_item11, "
                strSql += "        par.aux_ng_item12 "
                strSql += "   from parametros_venda par "
                strSql += "  where par.empresa = " + Empresa

                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    Aux1Label = dt.Rows.Item(0).Item("aux_ng_item1").ToString
                    Aux2Label = dt.Rows.Item(0).Item("aux_ng_item2").ToString
                    Aux3Label = dt.Rows.Item(0).Item("aux_ng_item3").ToString
                    Aux4Label = dt.Rows.Item(0).Item("aux_ng_item4").ToString
                    Aux5Label = dt.Rows.Item(0).Item("aux_ng_item5").ToString
                    Aux6Label = dt.Rows.Item(0).Item("aux_ng_item6").ToString
                    Aux7Label = dt.Rows.Item(0).Item("aux_ng_item7").ToString
                    Aux8Label = dt.Rows.Item(0).Item("aux_ng_item8").ToString
                    Aux9Label = dt.Rows.Item(0).Item("aux_ng_item9").ToString
                    Aux10Label = dt.Rows.Item(0).Item("aux_ng_item10").ToString
                    Aux11Label = dt.Rows.Item(0).Item("aux_ng_item11").ToString
                    Aux12Label = dt.Rows.Item(0).Item("aux_ng_item12").ToString
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Sub Excluir()
        Dim strSql As String = ""

        Try
            strSql += " delete from negociacao_cliente_item "
            strSql += "  where empresa = " + Empresa
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and seq_item = " + SeqItem
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            If Referencia Is Nothing Then
                Referencia = ""
            End If
            If String.IsNullOrWhiteSpace(PrazoEntrega) Then
                PrazoEntrega = "null"
            End If
            If String.IsNullOrWhiteSpace(TpPrazoEntrega) Then
                TpPrazoEntrega = "null"
            End If
            strSql += " update negociacao_cliente_item "
            strSql += "    set cod_item = '" + CodItem + "', "
            strSql += "        referencia = '" + Referencia.Trim + "', "
            strSql += "        lote = '" + Lote.Trim + "', "
            strSql += "        qtd_pedida = " + ValorNumericoBanco(Quantidade, 4) + ", "
            strSql += "        qtd_ud = " + ValorNumericoBanco(QuantidadeUD, 4) + ", "
            strSql += "        preco_unitario = " + ValorNumericoBanco(PrecoUnitario, 4) + ", "
            strSql += "        preco_unitario_ud = " + ValorNumericoBanco(PrecoUnitarioUD, 4) + ", "
            strSql += "        preco_unitario_tabela = " + ValorNumericoBanco(PrecoUnitarioTabela, 4) + ", "
            strSql += "        preco_unitario_sem_componente = " + ValorNumericoBanco(PrecoUnitarioSemComponente, 4) + ", "
            strSql += "        cod_unidade = " + IIf(String.IsNullOrEmpty(Trim(CodUnidade)) OrElse CodUnidade = "0", "null", "'" + CodUnidade + "'") + ", "
            strSql += "        narrativa = '" + Narrativa + "', "
            strSql += "        icms_substituicao = " + ValorNumericoBanco(ICMSST, 4) + ", "
            strSql += "        perc_desconto = " + ValorNumericoBanco(PercentualDesconto, 4) + ", "
            strSql += "        valor_desconto = " + ValorNumericoBanco(ValorDesconto, 4) + ", "
            strSql += "        valor_ipi = " + ValorNumericoBanco(IPI, 4) + ", "
            strSql += "        valor_icms = " + ValorNumericoBanco(ICMS, 4) + ", "
            strSql += "        cod_natur_oper = '" + CodNaturOper + "', "
            strSql += "        valor_total_mercadoria = " + ValorNumericoBanco(ValorTotal, 4) + ", "
            strSql += "        valor_mercadoria = " + ValorNumericoBanco(ValorMercadoria, 4) + ", "
            strSql += "        aliquota_icms = " + ValorNumericoBanco(AliquotaICMS, 4) + ", "
            strSql += "        aliquota_ipi = " + ValorNumericoBanco(AliquotaIPI, 4) + ", "
            strSql += "        base_icms_substituicao = " + ValorNumericoBanco(BaseICMSSubstituicao, 4) + ", "
            strSql += "        altura = " + ValorNumericoBanco(Altura, 2) + ", "
            strSql += "        largura = " + ValorNumericoBanco(Largura, 2) + ", "
            strSql += "        espessura = " + ValorNumericoBanco(Espessura, 4) + ", "
            strSql += "        perc_desconto_unitario1 = " + ValorNumericoBanco(PercDescontoUnitario1, 4) + ", "
            strSql += "        perc_desconto_unitario2 = " + ValorNumericoBanco(PercDescontoUnitario2, 4) + ", "
            strSql += "        perc_desconto_unitario3 = " + ValorNumericoBanco(PercDescontoUnitario3, 4) + ", "
            strSql += "        perc_desconto_unitario4 = " + ValorNumericoBanco(PercDescontoUnitario4, 4) + ", "
            strSql += "        perc_desconto_unitario5 = " + ValorNumericoBanco(PercDescontoUnitario5, 4) + ", "
            strSql += "        perc_acrescimo_unitario = " + ValorNumericoBanco(PercAcrescimoUnitario, 4) + ", "
            strSql += "        recurso                 = " + ValorNumericoBanco(Recurso, 4) + ", "
            strSql += "        prazo_entrega = " + PrazoEntrega + ", "
            strSql += "        tp_prazo_entrga = " + TpPrazoEntrega + ", "

            If String.IsNullOrEmpty(NumeroSerie) Then
                strSql += "        numero_serie = null,"
            Else
                strSql += "        numero_serie = '" + NumeroSerie + "', "
            End If

            strSql += "        aux1 = '" + Aux1 + "', "
            strSql += "        aux2 = '" + Aux2 + "', "
            strSql += "        aux3 = '" + Aux3 + "', "
            strSql += "        aux4 = '" + Aux4 + "', "
            strSql += "        aux5 = '" + Aux5 + "', "
            strSql += "        aux6 = '" + Aux6 + "', "
            strSql += "        aux7 = '" + Aux7 + "', "
            strSql += "        aux8 = '" + Aux8 + "', "
            strSql += "        aux9 = '" + Aux9 + "', "
            strSql += "        aux10 = '" + Aux10 + "',"
            strSql += "        aux11 = '" + Aux11 + "', "
            strSql += "        aux12 = '" + Aux12 + "'"
            strSql += "        fd_acao_desejada_funcao = '" + FdAcaoDesejadaFuncao + "', "
            strSql += "        fd_coloracao = " + FdColoracao + ", "
            strSql += "        fd_cor_referencia = '" + FdCorReferencia + "', "
            strSql += "        fd_descricao_produto = '" + FdDescricaoProduto + "', "
            strSql += "        fd_nome_produto = '" + FdNomeProduto + "', "
            strSql += "        fd_odor = '" + FdOdor + "', "
            strSql += "        fd_odor_direcionamento = '" + FdOdorDirecionamento + "', "
            strSql += "        fd_odor_referencia = '" + FdOdorReferencia + "', "
            strSql += "  where empresa = " + Empresa
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and seq_item = " + SeqItem
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            If Referencia Is Nothing Then
                Referencia = ""
            End If
            If String.IsNullOrWhiteSpace(PrazoEntrega) Then
                PrazoEntrega = "null"
            End If
            If String.IsNullOrWhiteSpace(TpPrazoEntrega) Then
                TpPrazoEntrega = "null"
            End If
            strSql += " insert into negociacao_cliente_item( "
            strSql += "    empresa, "
            strSql += "    estabelecimento, "
            strSql += "    cod_negociacao_cliente, "
            strSql += "    seq_item, "
            strSql += "    cod_item, "
            strSql += "    cod_natur_oper, "
            strSql += "    referencia, "
            strSql += "    lote, "
            strSql += "    numero_serie, "
            strSql += "    qtd_pedida, "
            strSql += "    qtd_ud, "
            strSql += "    cod_unidade, "
            strSql += "    preco_unitario_orig, "
            strSql += "    preco_unitario, "
            strSql += "    preco_unitario_tabela, "
            strSql += "    preco_unitario_ud, "
            strSql += "    preco_unitario_sem_componente, "
            strSql += "    perc_desconto, "
            strSql += "    valor_desconto, "
            strSql += "    valor_mercadoria, "
            strSql += "    aliquota_icms, "
            strSql += "    valor_icms, "
            strSql += "    aliquota_ipi, "
            strSql += "    valor_ipi, "
            strSql += "    valor_total_mercadoria, "
            strSql += "    valor_custo, "
            strSql += "    impostos_federais, "
            strSql += "    perc_comissao, "
            strSql += "    valor_comissao, "
            strSql += "    margem_liquida, "
            strSql += "    narrativa, "
            strSql += "    perc_desc_financ, "
            strSql += "    aux1, "
            strSql += "    aux2, "
            strSql += "    aux3, "
            strSql += "    aux4, "
            strSql += "    aux5, "
            strSql += "    aux6, "
            strSql += "    aux7, "
            strSql += "    aux8, "
            strSql += "    aux9, "
            strSql += "    aux10, "
            strSql += "    aux11, "
            strSql += "    aux12, "
            strSql += "    fd_nome_produto, "
            strSql += "    fd_acao_desejada_funcao, "
            strSql += "    fd_coloracao, "
            strSql += "    fd_cor_referencia, "
            strSql += "    fd_odor, "
            strSql += "    fd_odor_direcionamento, "
            strSql += "    fd_odor_referencia, "
            strSql += "    fd_descricao_produto, "
            strSql += "    altura, "
            strSql += "    largura, "
            strSql += "    espessura, "
            strSql += "    perc_desconto_unitario1, "
            strSql += "    perc_desconto_unitario2, "
            strSql += "    perc_desconto_unitario3, "
            strSql += "    perc_desconto_unitario4, "
            strSql += "    perc_desconto_unitario5, "
            strSql += "    perc_acrescimo_unitario, "
            strSql += "    recurso, "
            strSql += "    prazo_entrega, "
            strSql += "    tp_prazo_entrga, "
            strSql += "    base_icms_substituicao, "
            strSql += "    icms_substituicao) values ("
            strSql += Empresa + ", "
            strSql += Estabelecimento + ", "
            strSql += CodNegociacao + ", "
            strSql += SeqItem + ", "
            strSql += "'" + CodItem + "', "
            strSql += "'" + CodNaturOper + "', "
            strSql += "'" + Referencia.Trim + "', "
            strSql += "'" + Lote + "', "

            If String.IsNullOrEmpty(NumeroSerie) Then
                NumeroSerie = ""
            End If

            strSql += IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null", "'" + NumeroSerie.Replace(",", ".") + "'") + ", "

            strSql += ValorNumericoBanco(Quantidade, 4) + ", "
            strSql += ValorNumericoBanco(QuantidadeUD, 4) + ", "

            strSql += IIf(String.IsNullOrEmpty(Trim(CodUnidade)) OrElse CodUnidade = "0", "null", "'" + CodUnidade + "'") + ", "

            strSql += ValorNumericoBanco(PrecoUnitario, 4) + ", "
            strSql += ValorNumericoBanco(PrecoUnitario, 4) + ", "
            strSql += ValorNumericoBanco(PrecoUnitarioTabela, 4) + ", "
            strSql += ValorNumericoBanco(PrecoUnitarioUD, 4) + ", "
            strSql += ValorNumericoBanco(PrecoUnitarioSemComponente, 4) + ", "
            strSql += ValorNumericoBanco(PercentualDesconto, 4) + ", "
            strSql += ValorNumericoBanco(ValorDesconto, 4) + ", "
            strSql += ValorNumericoBanco(ValorMercadoria, 4) + ", "
            strSql += ValorNumericoBanco(AliquotaICMS, 4) + ", "
            strSql += ValorNumericoBanco(ICMS, 4) + ", "
            strSql += ValorNumericoBanco(AliquotaIPI, 4) + ", "
            strSql += ValorNumericoBanco(IPI, 4) + ", "
            strSql += ValorNumericoBanco(ValorTotal, 4) + ", "
            strSql += "0, "
            strSql += "0, "
            strSql += "0, "
            strSql += "0, "
            strSql += "0, "
            strSql += "'" + Narrativa + "', "
            strSql += "0, "
            strSql += "'" + Aux1 + "', "
            strSql += "'" + Aux2 + "', "
            strSql += "'" + Aux3 + "', "
            strSql += "'" + Aux4 + "', "
            strSql += "'" + Aux5 + "', "
            strSql += "'" + Aux6 + "', "
            strSql += "'" + Aux7 + "', "
            strSql += "'" + Aux8 + "', "
            strSql += "'" + Aux9 + "', "
            strSql += "'" + Aux10 + "', "
            strSql += "'" + Aux11 + "', "
            strSql += "'" + Aux12 + "', "
            strSql += "'" + FdNomeProduto + "', "
            strSql += "'" + FdAcaoDesejadaFuncao + "', "
            strSql += FdColoracao + " , "
            strSql += "'" + FdCorReferencia + "', "
            strSql += FdOdor + ", "
            strSql += FdOdorDirecionamento + ", "
            strSql += "'" + FdOdorReferencia + "', "
            strSql += "'" + FdDescricaoProduto + "', "
            strSql += ValorNumericoBanco(Altura, 2) + ", "
            strSql += ValorNumericoBanco(Largura, 2) + ", "
            strSql += ValorNumericoBanco(Espessura, 2) + ", "
            strSql += ValorNumericoBanco(PercDescontoUnitario1, 4) + ", "
            strSql += ValorNumericoBanco(PercDescontoUnitario2, 4) + ", "
            strSql += ValorNumericoBanco(PercDescontoUnitario3, 4) + ", "
            strSql += ValorNumericoBanco(PercDescontoUnitario4, 4) + ", "
            strSql += ValorNumericoBanco(PercDescontoUnitario5, 4) + ", "
            strSql += ValorNumericoBanco(PercAcrescimoUnitario, 4) + ", "
            strSql += ValorNumericoBanco(Recurso, 4) + ", "
            strSql += PrazoEntrega + ", "
            strSql += TpPrazoEntrega + ", "
            strSql += ValorNumericoBanco(BaseICMSSubstituicao, 4) + ", "
            strSql += ValorNumericoBanco(ICMSST, 4) + ") "

            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_item),0) + 1 max from negociacao_cliente_item where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function GetSeqItemPeloCodItem() As String
        Try
            Dim StrSql As String = "select seq_item from negociacao_cliente_item where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao + " and cod_item = '" + CodItem + "'"
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim lSeqItem As String
            If dt.Rows.Count > 0 Then
                lSeqItem = dt.Rows.Item(0).Item("seq_item").ToString
            Else
                lSeqItem = "0"
            End If
            Return lSeqItem
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Gravar()
        Try
            If SeqItem = 0 Then
                SeqItem = GetProximoCodigo()
                Incluir()
            Else
                Alterar()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class