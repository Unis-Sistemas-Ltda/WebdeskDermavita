Public Class UCLParametrosFaturamento
    Private _Empresa As String
    Private _Estabelecimento As String
    Private _Segmento As String

    Public Property CodNaturOperContratoProdutoDentroEstado As String
    Public Property CodNaturOperContratoServicoDentroEstado As String
    Public Property CodNaturOperContratoProdutoForaEstado As String
    Public Property CodNaturOperContratoServicoForaEstado As String

    Private objAcessoDados As UCLAcessoDados

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

    Public Property Segmento() As String
        Get
            Return _Segmento
        End Get
        Set(ByVal value As String)
            _Segmento = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = " select por_lote, cod_natur_oper_contrato_produto_dentro_estado, cod_natur_oper_contrato_servico_dentro_estado, cod_natur_oper_contrato_produto_fora_estado, cod_natur_oper_contrato_servico_fora_estado from parametros_faturamento where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                Segmento = dt.Rows.Item(0).Item("por_lote").ToString
                CodNaturOperContratoProdutoDentroEstado = dt.Rows.Item(0).Item("cod_natur_oper_contrato_produto_dentro_estado").ToString
                CodNaturOperContratoProdutoForaEstado = dt.Rows.Item(0).Item("cod_natur_oper_contrato_produto_fora_estado").ToString
                CodNaturOperContratoServicoDentroEstado = dt.Rows.Item(0).Item("cod_natur_oper_contrato_servico_dentro_estado").ToString
                CodNaturOperContratoServicoForaEstado = dt.Rows.Item(0).Item("cod_natur_oper_contrato_servico_fora_estado").ToString
                Return True
            Else
                Segmento = ""
                CodNaturOperContratoProdutoDentroEstado = ""
                CodNaturOperContratoProdutoForaEstado = ""
                CodNaturOperContratoServicoDentroEstado = ""
                CodNaturOperContratoServicoForaEstado = ""
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
