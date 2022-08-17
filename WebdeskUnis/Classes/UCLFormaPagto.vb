Public Class UCLFormaPagto
    Private _Codigo As String
    Private _Descricao As String
    Private _Tipo As String
    Private _EventoBaixa As String
    Private _ImprimirReciboRomaneio As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property EventoBaixa() As String
        Get
            Return _EventoBaixa
        End Get
        Set(ByVal value As String)
            _EventoBaixa = value
        End Set
    End Property

    Public Property ImprimirReciboRomaneio() As String
        Get
            Return _ImprimirReciboRomaneio
        End Get
        Set(ByVal value As String)
            _ImprimirReciboRomaneio = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select *"
        StrSql += "   from formas_pagamento "
        StrSql += "  where cod_forma_pagamento = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
            EventoBaixa = dt.Rows.Item(0).Item("evento_baixa").ToString
            ImprimirReciboRomaneio = dt.Rows.Item(0).Item("imprimir_recibo_romaneio").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_forma_pagamento, descricao"
        strSql += "   from formas_pagamento "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_forma_pagamento") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_forma_pagamento"
        DDL.DataBind()
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            If String.IsNullOrEmpty(ImprimirReciboRomaneio) Then
                ImprimirReciboRomaneio = "N"
            End If

            strSql += " insert into formas_pagamento ( cod_forma_pagamento, descricao, tipo, evento_baixa, imprimir_recibo_romaneio) "
            strSql += " values (" + Codigo + ", '" + Descricao + "', " + Tipo + ", " + EventoBaixa + ", '" + ImprimirReciboRomaneio + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            If String.IsNullOrEmpty(ImprimirReciboRomaneio) Then
                ImprimirReciboRomaneio = "N"
            End If

            strSql += " update formas_pagamento "
            strSql += "    set descricao                = '" + Descricao + "', "
            strSql += "        tipo                     = " + Tipo + ", "
            strSql += "        evento_baixa             = " + EventoBaixa + ", "
            strSql += "        imprimir_recibo_romaneio = '" + ImprimirReciboRomaneio + "'"
            strSql += "  where cod_forma_pagamento      = " + Codigo

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_forma_pagamento),0) + 1 max from formas_pagamento "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
