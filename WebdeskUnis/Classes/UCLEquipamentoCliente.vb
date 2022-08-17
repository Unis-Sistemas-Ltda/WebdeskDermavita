Public Class UCLEquipamentoCliente

    Private ObjAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _NumeroSerie As String
    Private _CodItem As String
    Private _EstabelecimentoNFS As String
    Private _Serie As String
    Private _CodNFS As String
    Private _CodOP As String
    Private _CodCliente As String
    Private _CNPJ As String
    Private _DataReferenciaGarantia As String
    Private _DDataReferenciaGarantia As Date
    Private _DataValidadeGarantia As String
    Private _DDataValidadeGarantia As Date
    Private _NumeroRegistroPatrimonio As String
    Private _Observacao As String
    Private _TipoFrequenciaManutencao As String
    Private _DataUltimaPreventiva As String
    Private _DDataUltimaPreventiva As Date
    Private _NumeroPontoAtendimento As String
    Private _Ativo As String
    Public Property Referencia As String
    Public Property Lote As String
    Public Property NumeroSerieTerceiro As String
    Private _Placa As String
    Private _Quantidade As Integer

    Function GetNSU(pEmpresa As String, ByVal incrementado As Boolean, ByVal pEstabelecimento As String) As Long
        Try
            Dim StrSql As String = "select isnull(nsu_equipamento,0) nsu from parametros_manutencao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            Dim ret As Long

            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("nsu")
            Else
                ret = 0
            End If

            If incrementado Then
                ret += 1

                Do While True
                    StrSql = "select empresa from equipamento where numero_registro = '" + ret.ToString + "' and empresa = " + pEmpresa
                    dt = ObjAcessoDados.BuscarDados(StrSql)

                    If dt.Rows.Count > 0 Then
                        ret += 1
                    Else
                        StrSql = "update parametros_manutencao set nsu_equipamento = " + ret.ToString + " where empresa = " + pEmpresa
                        ObjAcessoDados.ExecutarSql(StrSql)
                        Return ret
                    End If
                Loop

            End If

            Return ret

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GerarNumeroSerieAutomatico(ByVal pEmpresa As String) As Boolean
        Try
            Dim StrSql As String = " select isnull(gerar_automatico,'N') gerar_automatico from serie_equipamento where empresa = " + pEmpresa
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count <= 0 Then
                Return True
            Else
                If dt.Rows.Item(0).Item("gerar_automatico").ToString = "S" Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(convert(integer,numero_serie)),0) + 1 max    from equipamento  where isnumeric(numero_serie) = 1 "
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
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

    Public Property CodItem() As String
        Get
            Return _CodItem
        End Get
        Set(ByVal value As String)
            _CodItem = value
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

    Public Property EstabelecimentoNFS() As String
        Get
            Return _EstabelecimentoNFS
        End Get
        Set(ByVal value As String)
            _EstabelecimentoNFS = value
        End Set
    End Property

    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal value As String)
            _Serie = value
        End Set
    End Property

    Public Property CodNFS() As String
        Get
            Return _CodNFS
        End Get
        Set(ByVal value As String)
            _CodNFS = value
        End Set
    End Property

    Public Property CodOP() As String
        Get
            Return _CodOP
        End Get
        Set(ByVal value As String)
            _CodOP = value
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

    Public Property DataReferenciaGarantia() As String
        Get
            Return _DataReferenciaGarantia
        End Get
        Set(ByVal value As String)
            If IsDate(value) Then
                DDataReferenciaGarantia = value
            End If
            _DataReferenciaGarantia = value
        End Set
    End Property

    Public Property DDataReferenciaGarantia() As Date
        Get
            Return _DDataReferenciaGarantia
        End Get
        Set(ByVal value As Date)
            _DDataReferenciaGarantia = value
        End Set
    End Property

    Public Property DataValidadeGarantia() As String
        Get
            Return _DataValidadeGarantia
        End Get
        Set(ByVal value As String)
            If IsDate(value) Then
                DDataValidadeGarantia = value
            End If
            _DataValidadeGarantia = value
        End Set
    End Property

    Public Property DDataValidadeGarantia() As Date
        Get
            Return _DDataValidadeGarantia
        End Get
        Set(ByVal value As Date)
            _DDataValidadeGarantia = value
        End Set
    End Property

    Public Property NumeroRegistroPatrimonio() As String
        Get
            Return _NumeroRegistroPatrimonio
        End Get
        Set(ByVal value As String)
            _NumeroRegistroPatrimonio = value
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

    Public Property TipoFrequenciaManutencao() As String
        Get
            Return _TipoFrequenciaManutencao
        End Get
        Set(ByVal value As String)
            _TipoFrequenciaManutencao = value
        End Set
    End Property

    Public Property DataUltimaPreventiva() As String
        Get
            Return _DataUltimaPreventiva
        End Get
        Set(ByVal value As String)
            If IsDate(value) Then
                DDataUltimaPreventiva = value
            End If
            _DataUltimaPreventiva = value
        End Set
    End Property

    Public Property DDataUltimaPreventiva() As Date
        Get
            Return _DDataUltimaPreventiva
        End Get
        Set(ByVal value As Date)
            _DDataUltimaPreventiva = value
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

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
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

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Enum TipoDescricaoEquipamento As Int16
        Observacao = 1
        DescricaoItem = 2
    End Enum

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, tipo As TipoDescricaoEquipamento, numeroSerieSelecionado As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "  SELECT e.numero_serie, "
        If tipo = TipoDescricaoEquipamento.Observacao Then
            strSql += "         e.numero_serie || ' - ' || e.observacao || ' (' || isnull(e.numero_registro,'') || ')' as descricao "
        Else
            strSql += "         e.numero_serie || ' - ' || i.descricao || ' (' || e.numero_registro || ') ' || r.cod_referencia as descricao "
        End If
        strSql += "    FROM equipamento e "
        If tipo = TipoDescricaoEquipamento.DescricaoItem Then
            strSql += "       inner join item i on e.cod_item = i.cod_item "
            strSql += "       left outer join referencia r on e.referencia = r.cod_referencia "
        End If
        strSql += "   WHERE e.empresa     = " + Empresa
        strSql += "     AND (e.numero_serie = '" + numeroSerieSelecionado + "') or (e.cod_cliente = " + CodCliente
        If Not String.IsNullOrWhiteSpace(NumeroPontoAtendimento) Then
            strSql += "     AND e.numero_ponto_atendimento = '" + NumeroPontoAtendimento + "'"
        End If
        strSql += ") ORDER BY e.numero_serie "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("numero_serie") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "numero_serie"
        DDL.DataBind()
    End Sub

    Public Function DtGridEquipamentosServicosSolicitadosOS(ByVal empresa As String, ByVal estabelecimento As String, ByVal codPedidoVenda As String) As DataTable
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select e.numero_serie, e.observacao, e.observacao desc_equipamento, e.numero_registro nr_patrimonio, e.numero_serie_terceiro, "
            strSql += "        trim(list(' ' || (select trim(list(' ' || itq.descricao || if trim(isnull(eqcc.observacao,'')) <> '' then ' - ' || eqcc.observacao else '' endif))"
            strSql += "                            from item itq inner join equipamento_componente eqcc on itq.cod_item = eqcc.cod_item"
            strSql += "                           where empresa = pvq.empresa"
            strSql += "                             and numero_serie = pvq.numero_serie"
            strSql += "                             and seq_componente = pvq.seq_componente))) componentes, it.descricao item_descricao, item_descricao || ' ' || desc_equipamento cf_item_descricao"
            strSql += "   from pedido_venda_solicitacao pvi left outer join equipamento e on pvi.empresa      = e.empresa"
            strSql += "                                                                  and pvi.numero_serie = e.numero_serie"
            strSql += "                              left outer join item it on it.cod_item = e.cod_item"
            strSql += "                              inner join pedido_venda pv on pv.empresa          = pvi.empresa"
            strSql += "                                                        and pv.estabelecimento  = pvi.estabelecimento"
            strSql += "                                                        and pv.cod_pedido_venda = pvi.cod_pedido_venda"
            strSql += "                              inner join chamado c on c.empresa      = pv.empresa"
            strSql += "                                                  and pv.cod_chamado = c.cod_chamado"
            strSql += "                              left outer join pedido_venda_solicitacao_equipamento_componente pvq on pvq.empresa           = pv.empresa"
            strSql += "                                                                                                 and pvq.estabelecimento   = pv.estabelecimento"
            strSql += "                                                                                                 and pvq.cod_pedido_venda  = pv.cod_pedido_venda"
            strSql += "                                                                                                 and pvq.seq_solicitacao   = pvi.seq_solicitacao"
            strSql += "                                                                                                 and pvq.numero_serie      = e.numero_serie"
            strSql += "  where c.empresa           = " + empresa
            strSql += "    and pv.estabelecimento  = " + estabelecimento
            strSql += "    and pv.cod_pedido_venda = " + codPedidoVenda
            strSql += "  group by e.numero_serie, e.observacao, e.observacao, e.numero_registro, e.numero_serie_terceiro, it.descricao, e.placa, e.quantidade"

            strSql += " union all "

            strSql += " select e.numero_serie, e.observacao, e.observacao desc_equipamento, e.numero_registro, e.numero_serie_terceiro,"
            strSql += "        '', it.descricao item_descricao, item_descricao || ' ' || desc_equipamento cf_item_descricao"
            strSql += "    from pedido_venda pv inner join chamado c on pv.empresa = c.empresa and pv.cod_chamado = c.cod_chamado"
            strSql += "                         inner join equipamento e on e.empresa = c.empresa and e.numero_serie = c.numero_serie"
            strSql += "                         left outer join item it on it.cod_item = e.cod_item"
            strSql += "  where c.empresa           = " + empresa
            strSql += "    and pv.estabelecimento  = " + estabelecimento
            strSql += "    and pv.cod_pedido_venda = " + codPedidoVenda
            strSql += "    and c.numero_serie is not null"

            dt = ObjAcessoDados.BuscarDados(strSql)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DtGridServicosSolicitadosOS(ByVal empresa As String, ByVal estabelecimento As String, ByVal codPedidoVenda As String, ByVal nrLinhas As Long, ByVal numeroSerie As String) As DataTable
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select pvi.seq_solicitacao, e.numero_serie, e.observacao, replace(pvi.servico_solicitado,char(13),'<br>') servico_solicitado, e.observacao desc_equipamento, e.numero_registro nr_patrimonio, e.numero_serie_terceiro, "
            strSql += "        trim(list(' ' || (select trim(list(' ' || itq.descricao || if trim(isnull(eqcc.observacao,'')) <> '' then ' - ' || eqcc.observacao else '' endif || ' /' || eqcc.quantidade || ' /' || eqcc.cod_item))"
            strSql += "                            from item itq inner join equipamento_componente eqcc on itq.cod_item = eqcc.cod_item"
            strSql += "                           where empresa = pvq.empresa"
            strSql += "                             and numero_serie = pvq.numero_serie"
            strSql += "                             and seq_componente = pvq.seq_componente))) componentes, it.descricao item_descricao, item_descricao || ' ' || desc_equipamento cf_item_descricao, e.placa, e.quantidade,tsa.descricao, c.tipo_chamado"
            strSql += "   from pedido_venda_solicitacao pvi left outer join equipamento e on pvi.empresa      = e.empresa"
            strSql += "                                                                  and pvi.numero_serie = e.numero_serie"
            strSql += "                              left outer join item it on it.cod_item = e.cod_item"
            strSql += "                              inner join pedido_venda pv on pv.empresa          = pvi.empresa"
            strSql += "                                                        and pv.estabelecimento  = pvi.estabelecimento"
            strSql += "                                                        and pv.cod_pedido_venda = pvi.cod_pedido_venda"
            strSql += "                              inner join chamado c on c.empresa      = pv.empresa"
            strSql += "                                                  and pv.cod_chamado = c.cod_chamado"
            strSql += "                              left outer join pedido_venda_solicitacao_equipamento_componente pvq on pvq.empresa           = pv.empresa"
            strSql += "                                                                                                 and pvq.estabelecimento   = pv.estabelecimento"
            strSql += "                                                                                                 and pvq.cod_pedido_venda  = pv.cod_pedido_venda"
            strSql += "                                                                                                 and pvq.seq_solicitacao   = pvi.seq_solicitacao"
            strSql += "                                                                                                 and pvq.numero_serie      = e.numero_serie"

            strSql += "                              left outer join pedido_venda_solicitacao_tipo_servico_atendimento pvsa on pvsa.empresa       = pv.empresa"
            strSql += "                                                                                                 and pvsa.estabelecimento  = pv.estabelecimento"
            strSql += "                                                                                                 and pvsa.cod_pedido_venda = pv.cod_pedido_venda"
            strSql += "                                                                                                 and pvsa.seq_solicitacao  = pvi.seq_solicitacao"
            strSql += "                                                left outer join tipo_servico_atendimento tsa on tsa.cod_tipo_servico       = pvsa.cod_tipo_servico"

            strSql += "  where c.empresa           = " + empresa
            strSql += "    and pv.estabelecimento  = " + estabelecimento
            strSql += "    and pv.cod_pedido_venda = " + codPedidoVenda
            If Not String.IsNullOrEmpty(numeroSerie) Then
                strSql += "    and e.numero_serie = '" + numeroSerie + "' "
            End If
            strSql += "  group by pvi.seq_solicitacao, e.numero_serie, e.observacao, servico_solicitado, e.observacao, e.numero_registro, e.numero_serie_terceiro, it.descricao, e.placa, e.quantidade,tsa.descricao, c.tipo_chamado"

            strSql += " union all "

            strSql += " select 0, e.numero_serie, e.observacao, '', e.observacao desc_equipamento, e.numero_registro, e.numero_serie_terceiro,"
            strSql += "        '', it.descricao item_descricao, item_descricao || ' ' || desc_equipamento cf_item_descricao, e.placa, e.quantidade,'',''"
            strSql += "    from pedido_venda pv inner join chamado c on pv.empresa = c.empresa and pv.cod_chamado = c.cod_chamado"
            strSql += "                         inner join equipamento e on e.empresa = c.empresa and e.numero_serie = c.numero_serie"
            strSql += "                         left outer join item it on it.cod_item = e.cod_item"
            strSql += "  where c.empresa           = " + empresa
            strSql += "    and pv.estabelecimento  = " + estabelecimento
            strSql += "    and pv.cod_pedido_venda = " + codPedidoVenda
            strSql += "    and c.numero_serie is not null"
            If Not String.IsNullOrEmpty(numeroSerie) Then
                strSql += "  and c.numero_serie = '" + numeroSerie + "' "
            End If

            dt = ObjAcessoDados.BuscarDados(strSql)

            'For i As Long = dt.Rows.Count + 1 To nrLinhas
            '    dt.Rows.Add(dt.NewRow)
            'Next

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String = ""

            If String.IsNullOrEmpty(EstabelecimentoNFS) Then
                EstabelecimentoNFS = "null"
            End If

            If String.IsNullOrEmpty(CodNFS) Then
                CodNFS = "null"
            End If

            If String.IsNullOrEmpty(CodOP) Then
                CodOP = "null"
            End If

            If String.IsNullOrEmpty(CodCliente) Then
                CodCliente = "null"
            End If

            If String.IsNullOrEmpty(Referencia) Then
                Referencia = ""
            End If

            StrSql += " insert into equipamento(empresa, numero_serie, cod_item, referencia, lote, estabelecimento_nfs, serie, cod_nfs, "
            StrSql += "     cod_op, cod_cliente, cnpj, data_referencia_garantia, data_validade_garantia, numero_registro, "
            StrSql += "     observacao, tipo_frequencia_manutencao, data_ultima_preventiva, ativo, numero_ponto_atendimento, numero_serie_terceiro, placa, quantidade)"
            StrSql += "  values(" + Empresa + ", '" + NumeroSerie + "', " + IIf(String.IsNullOrEmpty(CodItem), "null", "'" + CodItem + "'") + ", '" + Referencia.Replace("'", "' || char(39) || '") + "', '" + Lote + "'," + EstabelecimentoNFS + ", '" + Serie + "',"
            StrSql += CodNFS + ", " + CodOP + ", " + CodCliente + ", " + IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(DataReferenciaGarantia), "null", "'" + DDataReferenciaGarantia.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(DataValidadeGarantia), "null", "'" + DDataValidadeGarantia.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "'" + NumeroRegistroPatrimonio + "', '" + Observacao + "', '" + TipoFrequenciaManutencao + "',"
            StrSql += IIf(String.IsNullOrEmpty(DataUltimaPreventiva), "null", "'" + DDataUltimaPreventiva.ToString("yyyy-MM-dd") + "'") + ",'S', "
            StrSql += IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(NumeroSerieTerceiro), "null", "'" + NumeroSerieTerceiro + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(Placa), "null", "'" + Placa + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(Quantidade), "null", "'" + Quantidade + "'") + ") "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String

            StrSql = " delete from equipamento_componente where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "'; "
            StrSql += " delete from equipamento where empresa = " + Empresa + " and numero_serie = '" + NumeroSerie + "'"

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw New Exception("Não é possível excluir o equipamento selecionado pois o mesmo já possui vínculos.")
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String = ""

            If String.IsNullOrEmpty(EstabelecimentoNFS) Then
                EstabelecimentoNFS = "null"
            End If

            If String.IsNullOrEmpty(CodNFS) Then
                CodNFS = "null"
            End If

            If String.IsNullOrEmpty(CodOP) Then
                CodOP = "null"
            End If

            If String.IsNullOrEmpty(CodCliente) Then
                CodCliente = "null"
            End If

            If String.IsNullOrEmpty(Referencia) Then
                Referencia = ""
            End If

            StrSql += " update equipamento "
            StrSql += "    set cod_item                   = " + IIf(String.IsNullOrEmpty(CodItem), "null", "'" + CodItem + "'") + ", "
            StrSql += "        referencia                 = '" + Referencia.Replace("'", "' || char(39) || '") + "', "
            StrSql += "        lote                       = '" + Lote + "', "
            StrSql += "        estabelecimento_nfs        = " + EstabelecimentoNFS + ", "
            StrSql += "        serie                      = '" + Serie + "', "
            StrSql += "        cod_nfs                    = " + CodNFS + ", "
            StrSql += "        cod_op                     = " + CodOP + ", "
            StrSql += "        cod_cliente                = " + CodCliente + ", "
            StrSql += "        cnpj                       = " + IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ", "
            StrSql += "        numero_ponto_atendimento   = " + IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            StrSql += "        data_referencia_garantia   = " + IIf(String.IsNullOrEmpty(DataReferenciaGarantia), "null", "'" + DDataReferenciaGarantia.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "        data_validade_garantia     = " + IIf(String.IsNullOrEmpty(DataValidadeGarantia), "null", "'" + DDataValidadeGarantia.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "        numero_registro            = '" + NumeroRegistroPatrimonio + "', "
            StrSql += "        observacao                 = '" + Observacao + "', "
            StrSql += "        ativo                      = '" + Ativo + "', "
            StrSql += "        tipo_frequencia_manutencao = '" + TipoFrequenciaManutencao + "', "
            StrSql += "        numero_serie_terceiro      = " + IIf(String.IsNullOrEmpty(NumeroSerieTerceiro), "null", "'" + NumeroSerieTerceiro + "'") + ", "
            StrSql += "        data_ultima_preventiva     = " + IIf(String.IsNullOrEmpty(DataUltimaPreventiva), "null", "'" + DDataUltimaPreventiva.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "        placa                      = " + IIf(String.IsNullOrEmpty(Placa), "null", "'" + Placa + "'") + ", "
            StrSql += "        quantidade                 = " + IIf(String.IsNullOrEmpty(Quantidade), "null", "'" + Quantidade + "'") + ""
            StrSql += "  where empresa      = " + Empresa
            StrSql += "    and numero_serie = '" + NumeroSerie + "'"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim strsql As String
            Dim dt As DataTable

            strsql = "  select * "
            strsql += "   from equipamento "
            strsql += "  where empresa      = " + Empresa
            strsql += "    and numero_serie = '" + NumeroSerie + "'"
            dt = ObjAcessoDados.BuscarDados(strsql)

            If dt.Rows.Count > 0 Then
                NumeroSerieTerceiro = dt.Rows.Item(0).Item("numero_serie_terceiro").ToString
                Ativo = dt.Rows.Item(0).Item("ativo").ToString
                CodItem = dt.Rows.Item(0).Item("cod_item").ToString
                Referencia = dt.Rows.Item(0).Item("referencia").ToString
                Lote = dt.Rows.Item(0).Item("lote").ToString
                EstabelecimentoNFS = dt.Rows.Item(0).Item("estabelecimento_nfs").ToString
                Serie = dt.Rows.Item(0).Item("serie").ToString
                CodNFS = dt.Rows.Item(0).Item("cod_nfs").ToString
                CodOP = dt.Rows.Item(0).Item("cod_op").ToString
                CodCliente = dt.Rows.Item(0).Item("cod_cliente").ToString
                CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
                NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("data_referencia_garantia")) Then
                    DataReferenciaGarantia = CDate(dt.Rows.Item(0).Item("data_referencia_garantia")).ToString("dd/MM/yyyy")
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("data_validade_garantia")) Then
                    DataValidadeGarantia = CDate(dt.Rows.Item(0).Item("data_validade_garantia")).ToString("dd/MM/yyyy")
                End If
                NumeroRegistroPatrimonio = dt.Rows.Item(0).Item("numero_registro").ToString
                Observacao = dt.Rows.Item(0).Item("observacao").ToString
                TipoFrequenciaManutencao = dt.Rows.Item(0).Item("tipo_frequencia_manutencao").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("data_ultima_preventiva")) Then
                    DataUltimaPreventiva = CDate(dt.Rows.Item(0).Item("data_ultima_preventiva")).ToString("dd/MM/yyyy")
                End If
                Placa = dt.Rows.Item(0).Item("placa").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("quantidade")) Then
                    Quantidade = Convert.ToInt32(dt.Rows.Item(0).Item("quantidade"))
                End If
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

