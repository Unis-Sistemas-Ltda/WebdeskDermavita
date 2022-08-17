Public Class UCLEmpresa

    Private _CodEmpresa As String
    Private _RazaoSocial As String
    Private _CodClienteUnis As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodEmpresa() As String
        Get
            Return _CodEmpresa
        End Get
        Set(ByVal value As String)
            _CodEmpresa = value
        End Set
    End Property

    Public Property RazaoSocial() As String
        Get
            Return _RazaoSocial
        End Get
        Set(ByVal value As String)
            _RazaoSocial = value
        End Set
    End Property

    Public Property CodClienteUnis() As String
        Get
            Return _CodClienteUnis
        End Get
        Set(ByVal value As String)
            _CodClienteUnis = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = "select e.razao_social, s.cod_cliente from empresa e, sysparm s where empresa = '" + CodEmpresa + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            RazaoSocial = dt.Rows.Item(0).Item("razao_social").ToString
            CodClienteUnis = dt.Rows.Item(0).Item("cod_cliente").ToString
            Return True
        Else
            Return False
        End If

    End Function

End Class