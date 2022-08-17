Public Class UCLClienteFinanceiro

    Private ObjAcessoDados As UCLAcessoDados
    Private _CodEmitente As String
    Private _Empresa As String
    Private _CodRepresentante As String
    Private _CodCondPagto As String
    Private _CodFormaPagto As String
    Private _CodNatureza As String
    Private _TipoFrete As String
    Private _CodCanalVenda As String
    Private _CodGrupo As String
    Private _CodCarteira As String
    Private _CodPortador As String
    Private _CodBanco As String

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
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

    Public Property CodRepresentante() As String
        Get
            Return _CodRepresentante
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodRepresentante = value
        End Set
    End Property

    Public Property CodCondPagto() As String
        Get
            Return _CodCondPagto
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCondPagto = value
        End Set
    End Property

    Public Property CodFormaPagto() As String
        Get
            Return _CodFormaPagto
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodFormaPagto = value
        End Set
    End Property

    Public Property CodNatureza() As String
        Get
            Return _CodNatureza
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodNatureza = value
        End Set
    End Property

    Public Property TipoFrete() As String
        Get
            Return _TipoFrete
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "1"
            End If
            _TipoFrete = value
        End Set
    End Property

    Public Property CodCanalVenda() As String
        Get
            Return _CodCanalVenda
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCanalVenda = value
        End Set
    End Property

    Public Property CodGrupo() As String
        Get
            Return _CodGrupo
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodGrupo = value
        End Set
    End Property

    Public Property CodCarteira() As String
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCarteira = value
        End Set
    End Property

    Public Property CodPortador() As String
        Get
            Return _CodPortador
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodPortador = value
        End Set
    End Property

    Public Property CodBanco() As String
        Get
            Return _CodBanco
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodBanco = value
        End Set
    End Property

    Public Sub Gravar()
        Try
            If Existe() Then
                Alterar()
            Else
                Incluir()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Incluir()
        Dim StrSql As String = ""

        Try
            StrSql += " insert into cliente_financeiro(cod_emitente, empresa, cod_representante, cod_cond_pagto, cod_forma_pagamento, cod_natur_oper, tipo_frete, cod_canal_venda, cod_grupo, cod_carteira, cod_portador, cod_banco, perc_juro_mensal_atraso, perc_multa_atraso, valor_perc_desc_pag_dia ) "
            StrSql += "   values ( " + CodEmitente + ", " + Empresa + ", " + TestaNuloZero(CodRepresentante, "null") + ", " + TestaNuloZero(CodCondPagto, "null") + ", " + TestaNuloZero(CodFormaPagto, "null") + ", " + If(String.IsNullOrEmpty(CodNatureza) OrElse Trim(CodNatureza) = "0", "null", "'" + CodNatureza + "'") + ", '" + TipoFrete + "', " + TestaNuloZero(CodCanalVenda, "null") + ", " + TestaNuloZero(CodGrupo, "null") + ", " + TestaNuloZero(CodCarteira, "null") + ", " + TestaNuloZero(CodPortador, "null") + ", " + TestaNuloZero(CodBanco, "null") + ",0 ,0, 0)"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function TestaNuloZero(ByVal Campo As String, ByVal ValorAssumir As String)
        If String.IsNullOrEmpty(Campo) OrElse Campo.Trim = "0" Then
            Return ValorAssumir
        Else
            Return Trim(Campo)
        End If
    End Function

    Public Sub Alterar()
        Dim StrSql As String = ""

        Try
            StrSql += " update cliente_financeiro set "
            StrSql += "    cod_representante   = " + TestaNuloZero(CodRepresentante, "null") + ", "
            StrSql += "    cod_cond_pagto      = " + TestaNuloZero(CodCondPagto, "null") + ", "
            StrSql += "    cod_forma_pagamento = " + TestaNuloZero(CodFormaPagto, "null") + ", "
            StrSql += "    cod_natur_oper      = " + If(String.IsNullOrEmpty(CodNatureza) OrElse Trim(CodNatureza) = "0", "null", "'" + CodNatureza + "'") + ", "
            StrSql += "    tipo_frete          = '" + TipoFrete + "', "
            StrSql += "    cod_canal_venda     = " + TestaNuloZero(CodCanalVenda, "null") + ", "
            StrSql += "    cod_grupo           = " + TestaNuloZero(CodGrupo, "null") + ", "
            StrSql += "    cod_carteira        = " + TestaNuloZero(CodCarteira, "null") + ", "
            StrSql += "    cod_portador        = " + TestaNuloZero(CodPortador, "null") + ", "
            StrSql += "    cod_banco           = " + TestaNuloZero(CodBanco, "null") + " "
            StrSql += " where cod_emitente = " + CodEmitente
            StrSql += "   and empresa      = " + Empresa

            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Existe() As Boolean
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = "select 1 from cliente_financeiro where cod_emitente = " + CodEmitente + " and empresa = " + Empresa
            dt = ObjAcessoDados.BuscarDados(strSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Buscar()
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = " select cod_emitente, empresa, cod_representante, cod_cond_pagto, cod_forma_pagamento, cod_natur_oper, tipo_frete, cod_canal_venda, cod_grupo, cod_carteira, cod_portador, cod_banco from cliente_financeiro where cod_emitente = " + CodEmitente + " and empresa = " + Empresa
            dt = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                CodRepresentante = dt.Rows.Item(0).Item("cod_representante").ToString
                CodCondPagto = dt.Rows.Item(0).Item("cod_cond_pagto").ToString
                CodFormaPagto = dt.Rows.Item(0).Item("cod_forma_pagamento").ToString
                CodNatureza = dt.Rows.Item(0).Item("cod_natur_oper").ToString
                TipoFrete = dt.Rows.Item(0).Item("tipo_frete").ToString
                CodCanalVenda = dt.Rows.Item(0).Item("cod_canal_venda").ToString
                CodGrupo = dt.Rows.Item(0).Item("cod_grupo").ToString
                CodCarteira = dt.Rows.Item(0).Item("cod_carteira").ToString
                CodPortador = dt.Rows.Item(0).Item("cod_Portador").ToString
                CodBanco = dt.Rows.Item(0).Item("cod_banco").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
