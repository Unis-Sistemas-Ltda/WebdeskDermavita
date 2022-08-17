Public Class UCLDepartamentoAtendimento
    Private _CodDepartamento As String
    Private _Descricao As String
    Private _CodAnalistaPadrao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodDepartamento() As String
        Get
            Return _CodDepartamento
        End Get
        Set(ByVal value As String)
            _CodDepartamento = value
        End Set
    End Property

    Public Property Descricao()
        Get
            Return _Descricao
        End Get
        Set(ByVal value)
            _Descricao = value
        End Set
    End Property

    Public Property CodAnalistaPadrao()
        Get
            Return _CodAnalistaPadrao
        End Get
        Set(ByVal value)
            _CodAnalistaPadrao = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub Buscar()
        Dim StrSql As String = " select descricao, cod_analista_padrao from departamento_atendimento where cod_departamento = " + CodDepartamento
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            CodAnalistaPadrao = dt.Rows.Item(0).Item("cod_analista_padrao").ToString
        End If
    End Sub

End Class
