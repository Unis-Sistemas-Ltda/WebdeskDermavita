Public Class UCLCalculoImposto

#Region "PublicProperties"
    Private _Quantidade As Double
    Private _QuantidadeUD As Double
    Private _PrecoUnitario As Double
    Private _PrecoUnitarioUD As Double
    Private _PercentualDesconto As Double
    Private _ValorDesconto As Double
    Private _AliquotaICMS As Double
    Private _AliquotaIPI As Double
    Private _Empresa As Integer
    Private _Estabelecimento As Integer
    Private _CodItem As String
    Private _CNPJ As String
    Private _CodEmitente As Long
    Private _CodNaturOper As String
    Private _BaseIcms As Double
    Private _BaseIcmsSubstituicao As Double
    Private _IcmsSubstituicao As Double
    Private _ValorMercadoria As Double
    Private _ValorTotalMercadoria As Double
    Private _ValorICMS As Double
    Private _ValorIPI As Double
    Private _MargemLiquida As Double

    Public Property ValorDesconto() As Double
        Get
            Return _ValorDesconto
        End Get
        Set(ByVal value As Double)
            _ValorDesconto = value
        End Set
    End Property

    Public Property Quantidade() As Double
        Get
            Return _Quantidade
        End Get
        Set(ByVal value As Double)
            _Quantidade = value
        End Set
    End Property

    Public Property QuantidadeUD() As Double
        Get
            Return _QuantidadeUD
        End Get
        Set(ByVal value As Double)
            _QuantidadeUD = value
        End Set
    End Property

    Public Property PrecoUnitario() As Double
        Get
            Return _PrecoUnitario
        End Get
        Set(ByVal value As Double)
            _PrecoUnitario = value
        End Set
    End Property

    Public Property PercentualDesconto() As Double
        Get
            Return _PercentualDesconto
        End Get
        Set(ByVal value As Double)
            _PercentualDesconto = value
        End Set
    End Property

    Public Property AliquotaICMS() As Double
        Get
            Return _AliquotaICMS
        End Get
        Set(ByVal value As Double)
            _AliquotaICMS = value
        End Set
    End Property

    Public Property AliquotaIPI() As Double
        Get
            Return _AliquotaIPI
        End Get
        Set(ByVal value As Double)
            _AliquotaIPI = value
        End Set
    End Property

    Public Property Empresa() As Integer
        Get
            Return _Empresa
        End Get
        Set(ByVal value As Integer)
            _Empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As Integer
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As Integer)
            _Estabelecimento = value
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

    Public Property CodEmitente() As Long
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As Long)
            _CodEmitente = value
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

    Public Property CodNaturOper() As String
        Get
            Return _CodNaturOper
        End Get
        Set(ByVal value As String)
            _CodNaturOper = value
        End Set
    End Property

    Public Property BaseIcms() As Double
        Get
            Return _BaseIcms
        End Get
        Set(ByVal value As Double)
            _BaseIcms = value
        End Set
    End Property

    Public Property BaseIcmsSubstituicao() As Double
        Get
            Return _BaseIcmsSubstituicao
        End Get
        Set(ByVal value As Double)
            _BaseIcmsSubstituicao = value
        End Set
    End Property

    Public Property IcmsSubstituicao() As Double
        Get
            Return _IcmsSubstituicao
        End Get
        Set(ByVal value As Double)
            _IcmsSubstituicao = value
        End Set
    End Property

    Public Property PrecoUnitarioUD() As Double
        Get
            Return _PrecoUnitarioUD
        End Get
        Set(ByVal value As Double)
            _PrecoUnitarioUD = value
        End Set
    End Property

    Public Property ValorMercadoria() As Double
        Get
            Return _ValorMercadoria
        End Get
        Set(ByVal value As Double)
            _ValorMercadoria = value
        End Set
    End Property

    Public Property ValorTotalMercadoria() As Double
        Get
            Return _ValorTotalMercadoria
        End Get
        Set(ByVal value As Double)
            _ValorTotalMercadoria = value
        End Set
    End Property

    Public Property ValorICMS() As Double
        Get
            Return _ValorICMS
        End Get
        Set(ByVal value As Double)
            _ValorICMS = value
        End Set
    End Property

    Public Property ValorIPI() As Double
        Get
            Return _ValorIPI
        End Get
        Set(ByVal value As Double)
            _ValorIPI = value
        End Set
    End Property

    Public Property MargemLiquida() As Double
        Get
            Return _MargemLiquida
        End Get
        Set(ByVal value As Double)
            _MargemLiquida = value
        End Set
    End Property

#End Region

#Region "Operations"
    Public Function CalculaTotais() As String

        Dim objAcessoDados As New UCLAcessoDados(strConexao)
        Dim dt As DataTable
        Dim strSql As String

        Dim ld_qtd_pedida, ld_preco_unitario, ld_aliquota_icms, ld_aliquota_ipi As Double?
        Dim ld_valor_mercadoria, ld_valor_total_mercadoria, ld_valor_total, ld_valor_liquido_avista, ld_valor_ipi As Double?
        Dim ld_perc_desconto, ld_valor_desconto, ld_valor_icms, ld_base_icms_st, ld_icms_st, ld_aliquota_simples_federal As Double?
        Dim ld_subst_perc_reducao, ld_frete, ld_seguro, ld_margem_st, ld_preco_tabela, ld_preco_fabrica As Double?
        Dim ld_aliquota_substituicao, ld_icms_auxiliar As Double?

        Dim ll_estabelecimento, ll_cod_tributacao, ll_tp_controle_subst, ll_emitente, ll_classificacao As Long?
        Dim ll_cod_tabela As Long?
        Dim ls_cnpj, ls_item, ls_cod_natur_oper, ls_controla_aliquota, ls_simples_federal, ls_subst_reduz, ls_cliente_simples As String
        Dim ls_diminui_frete, ls_diminui_ipi, ls_cst As String

        Dim ld_qtd_ud As Double?
        Dim ld_preco_ud As Double?

        ld_frete = 0
        ld_seguro = 0

        ld_qtd_pedida = Quantidade
        ld_qtd_ud = QuantidadeUD
        ld_preco_unitario = PrecoUnitario
        ld_perc_desconto = PercentualDesconto
        ld_valor_desconto = ValorDesconto

        ld_aliquota_icms = AliquotaICMS
        ld_aliquota_ipi = AliquotaIPI

        ld_valor_mercadoria = ld_qtd_pedida * ld_preco_unitario

        If ld_qtd_ud Is Nothing Or ld_qtd_ud = 0 Then
            ld_qtd_ud = 1
        End If
        ld_preco_ud = ld_valor_mercadoria / ld_qtd_ud

        If ld_perc_desconto IsNot Nothing Then ld_valor_mercadoria -= ld_valor_mercadoria * (ld_perc_desconto / 100)
        If ld_valor_desconto IsNot Nothing Then ld_valor_mercadoria -= ld_valor_desconto

        ValorMercadoria = ld_valor_mercadoria
        ValorTotalMercadoria = ld_valor_mercadoria

        ll_estabelecimento = Estabelecimento
        ls_item = CodItem

        ls_cnpj = CNPJ
        ll_emitente = CodEmitente

        ls_cod_natur_oper = CodNaturOper

        strSql = " select isnull(simples_federal,'N') simples_fed, isnull(aliquota_icms_simples_federal,0) aliq_simples_fed"
        strSql += "  from relac_empresa_impostos r "
        strSql += " where r.empresa = " + Empresa.ToString
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ls_simples_federal = dt.Rows.Item(0).Item("simples_fed").ToString
            ld_aliquota_simples_federal = dt.Rows.Item(0).Item("aliq_simples_fed").ToString
        End If

        strSql = " select isnull(optante_pelo_simples,'N') optante "
        strSql += "  from emitente "
        strSql += " where cod_emitente = " + ll_emitente.ToString
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ls_cliente_simples = dt.Rows.Item(0).Item("optante").ToString
        Else
            ls_cliente_simples = "N"
        End If

        ld_aliquota_icms = Nothing
        ls_controla_aliquota = Nothing
        ll_cod_tributacao = Nothing
        ls_subst_reduz = Nothing
        ld_subst_perc_reducao = Nothing
        ll_tp_controle_subst = Nothing
        ld_margem_st = Nothing
        ls_diminui_ipi = Nothing
        ls_diminui_frete = Nothing
        ld_aliquota_substituicao = Nothing
        ls_cst = Nothing

        'ICMS
        strSql = " select aliquota, "
        strSql += "       controla_aliquota, "
        strSql += "       cod_tributacao,"
        strSql += "       reduz_substituto, "
        strSql += "       percentual_reducao_substituto, "
        strSql += "       tp_controle_subst, "
        strSql += "       (if '" + ls_cliente_simples + "' = 'S' then margem_substituicao_simples else margem_substituicao endif) margem_st,"
        strSql += "       diminui_ipi_base_calculo_subs,"
        strSql += "       diminui_frete_base_calculo_subs,"
        strSql += "       isnull(aliquota_subs_destino,0) aliq_subs,"
        strSql += "       isnull(natureza_icms.sit_tributaria_tab_a,'0')||isnull(natureza_icms.sit_tributaria_tab_b,'00') cst"
        strSql += "  from natureza_icms "
        strSql += " where cod_natur_oper = '" + CodNaturOper + "'"
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("aliquota")) Then
                ld_aliquota_icms = Nothing
            Else
                ld_aliquota_icms = dt.Rows.Item(0).Item("aliquota").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("controla_aliquota")) Then
                ls_controla_aliquota = Nothing
            Else
                ls_controla_aliquota = dt.Rows.Item(0).Item("controla_aliquota").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("cod_tributacao")) Then
                ll_cod_tributacao = Nothing
            Else
                ll_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("reduz_substituto")) Then
                ls_subst_reduz = Nothing
            Else
                ls_subst_reduz = dt.Rows.Item(0).Item("reduz_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("percentual_reducao_substituto")) Then
                ld_subst_perc_reducao = Nothing
            Else
                ld_subst_perc_reducao = dt.Rows.Item(0).Item("percentual_reducao_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("tp_controle_subst")) Then
                ll_tp_controle_subst = Nothing
            Else
                ll_tp_controle_subst = dt.Rows.Item(0).Item("tp_controle_subst").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("margem_st")) Then
                ld_margem_st = Nothing
            Else
                ld_margem_st = dt.Rows.Item(0).Item("margem_st")
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs")) Then
                ls_diminui_ipi = Nothing
            Else
                ls_diminui_ipi = dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs")) Then
                ls_diminui_frete = Nothing
            Else
                ls_diminui_frete = dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs").ToString
            End If

            ld_aliquota_substituicao = dt.Rows.Item(0).Item("aliq_subs").ToString
            ls_cst = dt.Rows.Item(0).Item("cst")
        Else
            ld_aliquota_icms = uf_tabela_icms("V", ll_estabelecimento, ls_cnpj, ls_item).ToString
            ll_cod_tributacao = uf_tabela_icms_tributacao(ll_estabelecimento, ls_cnpj, ls_item).ToString
        End If

        If (ls_controla_aliquota = "N" Or ls_controla_aliquota Is Nothing) And ll_cod_tributacao = 1 Then
            ld_aliquota_icms = uf_tabela_icms("V", ll_estabelecimento, ls_cnpj, ls_item).ToString
        End If

        If ld_aliquota_icms Is Nothing Then ld_aliquota_icms = 0
        ld_icms_auxiliar = ld_valor_mercadoria * ld_aliquota_icms / 100

        If ll_cod_tributacao = 1 Then
            ld_valor_icms = ld_valor_mercadoria * ld_aliquota_icms / 100
        Else
            ld_valor_icms = 0
        End If

        'IPI
        strSql = " select aliquota, controla_aliquota, cod_tributacao "
        strSql += "  from natureza_ipi "
        strSql += " where cod_natur_oper = '" + ls_cod_natur_oper + "'"
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("aliquota")) Then
                ld_aliquota_ipi = Nothing
            Else
                ld_aliquota_ipi = dt.Rows.Item(0).Item("aliquota").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("controla_aliquota")) Then
                ls_controla_aliquota = Nothing
            Else
                ls_controla_aliquota = dt.Rows.Item(0).Item("controla_aliquota").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("cod_tributacao")) Then
                ll_cod_tributacao = Nothing
            Else
                ll_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
            End If
        Else
            strSql = " select aliquota_ipi, cod_tributacao  "
            strSql += "  from item i, "
            strSql += "       classificacao_fiscal c "
            strSql += " where c.classificacao_fiscal = i.classificacao_fiscal "
            strSql += "   and i.cod_item					= '" + ls_item + "'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("aliquota_ipi")) Then
                    ld_aliquota_ipi = Nothing
                Else
                    ld_aliquota_ipi = dt.Rows.Item(0).Item("aliquota_ipi").ToString
                End If
                If IsDBNull(dt.Rows.Item(0).Item("cod_tributacao")) Then
                    ll_cod_tributacao = Nothing
                Else
                    ll_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
                End If
            End If
        End If

        If (ls_controla_aliquota = "N" Or ls_controla_aliquota Is Nothing) And ll_cod_tributacao = 1 Then
            strSql = " select aliquota_ipi, cod_tributacao  "
            strSql += "  from item i, "
            strSql += "       classificacao_fiscal c "
            strSql += " where c.classificacao_fiscal = i.classificacao_fiscal"
            strSql += "   and i.cod_item 			 = '" + ls_item + "'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("aliquota_ipi")) Then
                    ld_aliquota_ipi = Nothing
                Else
                    ld_aliquota_ipi = dt.Rows.Item(0).Item("aliquota_ipi").ToString
                End If
                If IsDBNull(dt.Rows.Item(0).Item("cod_tributacao")) Then
                    ll_cod_tributacao = Nothing
                Else
                    ll_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
                End If
            Else
                Throw New Exception("Busca do IPI inválida.")
            End If
        End If

        If ll_cod_tributacao = 1 Then
            ld_valor_ipi = ld_valor_mercadoria * ld_aliquota_ipi / 100
        Else
            ld_valor_ipi = 0
        End If

        'totais
        ld_valor_total_mercadoria = ld_valor_mercadoria
        ld_valor_total = ld_valor_total_mercadoria
        ld_valor_liquido_avista = ld_valor_total - (ld_valor_mercadoria * ld_aliquota_icms / 100)

        '----- ICMS ST
        strSql = "  select preco_venda_icms_subs, "
        strSql += "        preco_fabrica_icms_subs, "
        strSql += "        cod_tabela_icms "
        strSql += "   from item_estabelecimento "
        strSql += "  where empresa          = " + Empresa.ToString
        strSql += "    and estabelecimento  = " + ll_estabelecimento.ToString
        strSql += "    and cod_item         = '" + ls_item + "'"
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("preco_venda_icms_subs")) Then
                ld_preco_tabela = Nothing
            Else
                ld_preco_tabela = dt.Rows.Item(0).Item("preco_venda_icms_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("preco_fabrica_icms_subs")) Then
                ld_preco_fabrica = Nothing
            Else
                ld_preco_fabrica = dt.Rows.Item(0).Item("preco_fabrica_icms_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("cod_tabela_icms")) Then
                ll_cod_tabela = Nothing
            Else
                ll_cod_tabela = dt.Rows.Item(0).Item("cod_tabela_icms").ToString
            End If
        End If

        If ll_cod_tabela Is Nothing Then
            Return "Tabela de ICMS não configurada no cadastro do Item."
        End If

        'busca primeiro do item
        strSql = " select " + IsNull(ll_tp_controle_subst, "i.tp_controle_subst") + " as tp_controle_subst, "
        strSql += "       if '" + ls_cliente_simples + "' = 'S' then " + IsNull(ld_margem_st, "i.margem_substituicao_simples") + " else " + IsNull(ld_margem_st, "i.margem_substituicao") + " endif as margem_substituicao,"
        strSql += "       " + IsNull(ls_diminui_frete, "i.diminui_frete_base_calculo_subs") + " as diminui_frete_base_calculo_subs,"
        strSql += "       " + IsNull(ls_diminui_ipi, "i.diminui_ipi_base_calculo_subs") + " as diminui_ipi_base_calculo_subs,"
        strSql += "       " + IsNull(ls_subst_reduz, "i.reduz_substituto") + " as reduz_substituto,"
        strSql += "       " + IsNull(ld_subst_perc_reducao, "i.percentual_reducao_substituto") + " as percentual_reducao_substituto,"
        strSql += "       " + IsNull(ls_cst, "isnull(i.sit_tributaria_tab_a,t.sit_tributaria_tab_a) || isnull(i.sit_tributaria_tab_b,t.sit_tributaria_tab_b)") + " as cst "
        strSql += "  from tabela_icms t left outer join endereco_emitente em on em.cnpj             = '" + ls_cnpj + "'"
        strSql += "                                                         and em.cod_emitente     = " + ll_emitente.ToString
        strSql += "       left outer join tabela_icms_item i   on i.cod_estado        = em.cod_estado"
        strSql += "                                           and i.cod_pais          = em.cod_pais"
        strSql += "                                           and i.cod_pais          = t.cod_pais"
        strSql += "                                           and i.cod_tabela_icms   = t.cod_tabela_icms"
        strSql += " where t.cod_tabela_icms = " + ll_cod_tabela.ToString
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("tp_controle_subst")) Then
                ll_tp_controle_subst = Nothing
            Else
                ll_tp_controle_subst = dt.Rows.Item(0).Item("tp_controle_subst").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("margem_substituicao")) Then
                ld_margem_st = Nothing
            Else
                ld_margem_st = dt.Rows.Item(0).Item("margem_substituicao").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs")) Then
                ls_diminui_frete = Nothing
            Else
                ls_diminui_frete = dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs")) Then
                ls_diminui_ipi = Nothing
            Else
                ls_diminui_ipi = dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("reduz_substituto")) Then
                ls_subst_reduz = Nothing
            Else
                ls_subst_reduz = dt.Rows.Item(0).Item("reduz_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("percentual_reducao_substituto")) Then
                ld_subst_perc_reducao = Nothing
            Else
                ld_subst_perc_reducao = dt.Rows.Item(0).Item("percentual_reducao_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("cst")) Then
                ls_cst = Nothing
            Else
                ls_cst = dt.Rows.Item(0).Item("cst").ToString
            End If

        End If

        'o que não tiver, traz do cabeçalho
        strSql = " select " + IsNull(ll_tp_controle_subst, "isnull(t.tp_controle_subst,0)") + " tp_controle_subst,"
        strSql += "       if '" + ls_cliente_simples + "' = 'S' then " + IsNull(ld_margem_st, "t.margem_substituicao_simples") + " else " + IsNull(ld_margem_st, "t.margem_substituicao") + " endif margem_substituicao,"
        strSql += "       " + IsNull(ls_diminui_frete, "t.diminui_frete_base_calculo_subs") + " as diminui_frete_base_calculo_subs,"
        strSql += "       " + IsNull(ls_diminui_ipi, "t.diminui_ipi_base_calculo_subs") + " as diminui_ipi_base_calculo_subs,"
        strSql += "       " + IsNull(ls_subst_reduz, "t.reduz_substituto") + " as reduz_substituto,"
        strSql += "       " + IsNull(ld_subst_perc_reducao, "t.percentual_reducao_substituto") + " as percentual_reducao_substituto,"
        strSql += "       " + IsNull(ls_cst, "isnull(i.sit_tributaria_tab_a,t.sit_tributaria_tab_a) || isnull(i.sit_tributaria_tab_b,t.sit_tributaria_tab_b)") + " as cst"
        strSql += "  from tabela_icms t left outer join endereco_emitente em on em.cnpj             = '" + ls_cnpj + "'"
        strSql += "                                                      and em.cod_emitente     = " + ll_emitente.ToString
        strSql += "       left outer join tabela_icms_item i   on i.cod_estado        = em.cod_estado"
        strSql += "                                                 and i.cod_pais          = em.cod_pais"
        strSql += "                                                 and i.cod_pais          = t.cod_pais"
        strSql += "                                                 and i.cod_tabela_icms   = t.cod_tabela_icms"
        strSql += " where t.cod_tabela_icms = " + ll_cod_tabela.ToString
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("tp_controle_subst")) Then
                ll_tp_controle_subst = Nothing
            Else
                ll_tp_controle_subst = dt.Rows.Item(0).Item("tp_controle_subst").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("margem_substituicao")) Then
                ld_margem_st = Nothing
            Else
                ld_margem_st = dt.Rows.Item(0).Item("margem_substituicao").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs")) Then
                ls_diminui_frete = Nothing
            Else
                ls_diminui_frete = dt.Rows.Item(0).Item("diminui_frete_base_calculo_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs")) Then
                ls_diminui_ipi = Nothing
            Else
                ls_diminui_ipi = dt.Rows.Item(0).Item("diminui_ipi_base_calculo_subs").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("reduz_substituto")) Then
                ls_subst_reduz = Nothing
            Else
                ls_subst_reduz = dt.Rows.Item(0).Item("reduz_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("percentual_reducao_substituto")) Then
                ld_subst_perc_reducao = Nothing
            Else
                ld_subst_perc_reducao = dt.Rows.Item(0).Item("percentual_reducao_substituto").ToString
            End If
            If IsDBNull(dt.Rows.Item(0).Item("cst")) Then
                ls_cst = Nothing
            Else
                ls_cst = dt.Rows.Item(0).Item("cst").ToString
            End If
        End If

        If ll_cod_tributacao = 1 Or ll_cod_tributacao = 2 Then
            ld_icms_auxiliar = 0
        End If

        strSql = " select first isnull(natureza_operacao.classificacao,0) classificacao "
        strSql += "  from natureza_operacao "
        strSql += " where natureza_operacao.cod_natur_oper = '" + ls_cod_natur_oper + "'"
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ll_classificacao = dt.Rows.Item(0).Item("classificacao").ToString
        End If

        If ll_classificacao Is Nothing Then
            ll_classificacao = 0
        End If

        If (ll_cod_tributacao <> 2 And ll_tp_controle_subst >= 1 And ll_classificacao <> 8) Or (ll_tp_controle_subst >= 1 And ll_classificacao <> 8 And ls_simples_federal = "S") Then

            If ld_aliquota_substituicao <> 0 Then
                ld_aliquota_icms = ld_aliquota_substituicao
            End If

            If ls_diminui_frete = "S" Then
                ld_frete = 0
            End If

            If ls_diminui_ipi = "S" Then
                ld_valor_ipi = 0
            End If

            If ll_tp_controle_subst = 0 Then
                ld_base_icms_st = 0
            ElseIf ll_tp_controle_subst = 1 Then
                ld_base_icms_st = (ld_valor_total_mercadoria + ld_frete + ld_seguro + ld_valor_ipi) * (1 + ld_margem_st / 100)
            ElseIf ll_tp_controle_subst = 2 Then
                If ld_preco_fabrica Is Nothing Then
                    Return "Preço de Fábrica para ICMS de Substituição do Item ('+ls_item+') não pode ser nulo no estabelecimento."
                End If
                ld_base_icms_st = ld_preco_fabrica * (1 + ld_margem_st / 100)
            ElseIf ll_tp_controle_subst = 3 Then
                If ld_preco_tabela Is Nothing Then
                    Return "Preço de Venda para ICMS de Substituição do Item ('+ls_item+') não pode ser nulo no estabelecimento."

                End If
                ld_base_icms_st = ld_preco_tabela
            End If

            If ls_subst_reduz = "S" Then
                ld_base_icms_st = ld_base_icms_st - (ld_base_icms_st * ld_subst_perc_reducao / 100)
            End If

            If ls_simples_federal = "N" Then
                ld_icms_st = (ld_base_icms_st * ld_aliquota_icms / 100) - ld_valor_icms - ld_icms_auxiliar
                'If ld_icms_st <= 0 And ld_valor_total_mercadoria > 0 Then
                'Return "ICMS de Substituição não pode ser inferior a 0.00(zero)."
                'End If
            Else
                ld_icms_st = (ld_base_icms_st * ld_aliquota_icms / 100) - (ld_valor_total_mercadoria * ld_aliquota_icms / 100)
                'If ld_icms_st <= 0 And ld_valor_total_mercadoria > 0 Then
                ' Return "ICMS de Substituição não pode ser inferior a 0.00(zero)."
                'End If
            End If

        End If

        If ld_base_icms_st Is Nothing Then
            ld_base_icms_st = 0
        End If

        If ld_icms_st Is Nothing Then
            ld_icms_st = 0
        End If

        BaseIcmsSubstituicao = ld_base_icms_st
        IcmsSubstituicao = ld_icms_st
        '------

        ld_valor_total_mercadoria += ld_valor_ipi
        ld_valor_total_mercadoria += ld_icms_st

        PrecoUnitarioUD = ld_preco_ud
        PrecoUnitarioUD = ld_preco_ud
        ValorMercadoria = ld_valor_mercadoria
        ValorTotalMercadoria = ld_valor_total_mercadoria
        MargemLiquida = ld_valor_liquido_avista
        ValorIPI = IsNull(ld_valor_ipi, 0, False)
        ValorICMS = IsNull(ld_valor_icms, 0, False)
        AliquotaICMS = IsNull(ld_aliquota_icms, 0, False)
        AliquotaIPI = IsNull(ld_aliquota_ipi, 0, False)
        Return ""
    End Function

    Function uf_tabela_icms(ByVal as_tipo As String, ByVal al_estabelecimento As Integer, ByVal as_cnpj As String, ByVal as_item As String)
        '
        'tipo ->C = compra
        '       V = venda

        Dim objAcessoDados As New UCLAcessoDados(strConexao)
        Dim strSql As String
        Dim dt As DataTable

        Dim ll_tabela, ll_pais_tabela, ll_estado_tabela, ll_pais_emitente, ll_estado_emitente As Long
        Dim ldc_origem, ldc_destino As Double

        If as_item <> "" Then
            strSql = " Select isnull(cod_tabela_icms, 0) cod_tabela "
            strSql += "  from item_estabelecimento "
            strSql += " where empresa 			= " + Empresa.ToString
            strSql += "   and estabelecimento 	= " + al_estabelecimento.ToString
            strSql += "   and cod_item 			= '" + as_item + "'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                ll_tabela = dt.Rows.Item(0).Item("cod_tabela").ToString
            Else
                Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela relacionada ao item.")
                Return 0
            End If

        End If

        If ll_tabela = 0 Or as_item = "" Then
            strSql = " Select isnull(cod_tabela_icms, 0) cod_tabela "
            strSql += "  from Estabelecimento "
            strSql += " where empresa = " + Empresa.ToString
            strSql += "   and estabelecimento = " + al_estabelecimento.ToString
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                ll_tabela = dt.Rows.Item(0).Item("cod_tabela").ToString
            Else
                Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela relacionada ao estabelecimento.")
                Return 0
            End If

        End If

        If ll_tabela = 0 Then
            Throw New Exception("Tabela de ICMS não parametrizada para o estabelecimento.")
            Return 0
        End If

        strSql = " select t.cod_pais, "
        strSql += "       t.cod_estado, "
        strSql += "       t.aliquota_origem, "
        strSql += "       t.aliquota_destino "
        strSql += "  from tabela_icms t "
        strSql += " where t.cod_tabela_icms = " + ll_tabela.ToString
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ll_pais_tabela = dt.Rows.Item(0).Item("cod_pais").ToString
            ll_estado_tabela = dt.Rows.Item(0).Item("cod_estado").ToString
            ldc_origem = dt.Rows.Item(0).Item("aliquota_origem").ToString
            ldc_destino = dt.Rows.Item(0).Item("aliquota_destino").ToString
        Else
            Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela.")
            Return 0
        End If

        If Not String.IsNullOrEmpty(CNPJ) AndAlso CDbl(CNPJ) > 0 Then
            strSql = " select first e.cod_pais, "
            strSql += "       e.cod_estado "
            strSql += "  from endereco_emitente e"
            strSql += " where e.cnpj = '" + CNPJ + "'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                ll_pais_emitente = dt.Rows.Item(0).Item("cod_pais").ToString
                ll_estado_emitente = dt.Rows.Item(0).Item("cod_estado").ToString
            Else
                Throw New Exception("Problemas na pesquisa de ICMS, CNPJ não cadastrado.")
                Return 0
            End If

            If ll_pais_tabela <> ll_pais_emitente Or ll_estado_tabela <> ll_estado_emitente Then
                strSql = " select i.aliquota_origem, "
                strSql += "       i.aliquota_destino "
                strSql += "  from tabela_icms_item i, "
                strSql += "       tabela_icms t "
                strSql += " where i.cod_estado      = " + ll_estado_emitente.ToString
                strSql += "   and i.cod_pais        = " + ll_pais_emitente.ToString
                strSql += "   and i.cod_pais        = t.cod_pais "
                strSql += "   and i.cod_tabela_icms = t.cod_tabela_icms "
                strSql += "   and t.cod_tabela_icms = " + ll_tabela.ToString
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    ldc_origem = dt.Rows.Item(0).Item("aliquota_origem").ToString
                    ldc_destino = dt.Rows.Item(0).Item("aliquota_destino").ToString
                Else
                    Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela ou item da tabela para o endereço do cnpj.")
                    Return 0
                End If

            End If

        End If

        If as_tipo = "C" Then
            Return ldc_origem
        Else
            Return ldc_destino
        End If

    End Function

    Function uf_tabela_icms_tributacao(ByVal al_estabelecimento As Long, ByVal as_cnpj As String, ByVal as_item As String)
        Dim StrSql As String
        Dim dt As DataTable
        Dim objAcessoDados As New UCLAcessoDados(strConexao)

        Dim ll_tabela, ll_pais_tabela, ll_estado_tabela, ll_pais_emitente, ll_estado_emitente As Long
        Dim li_cod_tributacao As Integer

        If as_item <> "" Then
            StrSql = " Select isnull(cod_tabela_icms, 0) cod_tabela_icms "
            StrSql += "  from item_estabelecimento "
            StrSql += " where empresa         = " + Empresa.ToString
            StrSql += "   and estabelecimento = " + al_estabelecimento.ToString
            StrSql += "   and cod_item 		  = '" + as_item + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ll_tabela = dt.Rows.Item(0).Item("cod_tabela_icms").ToString
            Else
                Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela relacionada ao item.")
                Return 0
            End If
        End If

        If ll_tabela = 0 Or as_item = "" Then
            StrSql = " Select isnull(cod_tabela_icms, 0) cod_tabela_icms "
            StrSql += "  from Estabelecimento "
            StrSql += " where empresa 		  = " + Empresa.ToString
            StrSql += "   and estabelecimento = " + al_estabelecimento.ToString
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ll_tabela = dt.Rows.Item(0).Item("cod_tabela_icms")
            Else
                Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela relacionada ao estabelecimento.")
                Return 0
            End If

        End If

        If ll_tabela = 0 Then
            Throw New Exception("Tabela de ICMS não parametrizada para o estabelecimento.")
            Return 0
        End If

        StrSql = " select t.cod_pais, "
        StrSql += "   	  t.cod_estado, "
        StrSql += "   	  cod_tributacao "
        StrSql += "  from tabela_icms t "
        StrSql += " where t.cod_tabela_icms = " + ll_tabela.ToString
        dt = objAcessoDados.BuscarDados(StrSql)
        If dt.Rows.Count > 0 Then
            ll_pais_tabela = dt.Rows.Item(0).Item("cod_pais").ToString
            ll_estado_tabela = dt.Rows.Item(0).Item("cod_estado").ToString
            li_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
        Else
            Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela.")
            Return 0
        End If

        If Not String.IsNullOrEmpty(CNPJ) AndAlso CDbl(CNPJ) > 0 Then
            StrSql = " select first e.cod_pais, "
            StrSql += "       e.cod_estado "
            StrSql += "  from endereco_emitente e "
            StrSql += " where e.cnpj = '" + as_cnpj + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ll_pais_emitente = dt.Rows.Item(0).Item("cod_pais").ToString
                ll_estado_emitente = dt.Rows.Item(0).Item("cod_estado").ToString
            Else
                Throw New Exception("Problemas na pesquisa de ICMS, CNPJ não cadastrado.")
                Return 0
            End If

            If ll_pais_tabela <> ll_pais_emitente Or ll_estado_tabela <> ll_estado_emitente Then
                StrSql = " Select i.cod_tributacao "
                StrSql += "   from tabela_icms_item i, "
                StrSql += "        tabela_icms t "
                StrSql += "  where i.cod_estado 		 = " + ll_estado_emitente.ToString
                StrSql += "   and i.cod_pais			 = " + ll_pais_emitente.ToString
                StrSql += "   and i.cod_pais			 = t.cod_pais "
                StrSql += "   and i.cod_tabela_icms      = t.cod_tabela_icms "
                StrSql += "   and t.cod_tabela_icms      = " + ll_tabela.ToString
                dt = objAcessoDados.BuscarDados(StrSql)
                If dt.Rows.Count > 0 Then
                    li_cod_tributacao = dt.Rows.Item(0).Item("cod_tributacao").ToString
                Else
                    Throw New Exception("Problemas na pesquisa de ICMS. Não foi possível localizar tabela ou item da tabela para o endereço do cnpj.")
                    Return 0
                End If

            End If

        End If

        Return li_cod_tributacao

    End Function
#End Region

End Class
