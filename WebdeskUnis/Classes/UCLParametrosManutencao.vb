Public Class UCLParametrosManutencao
    Private _Empresa As String
    Private _CodStatusInicial As String
    Private _CodStatusFinal As String
    Private _TipoChamadoPadrao As String
    Private _CodAnalistaPadrao As String
    Private _ModeloChamadoCRM As String
    Private _CaminhoAnexoEmail As String
    Private _Filtro_todos_analistas As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CaminhoAnexoEmail() As String
        Get
            Return _CaminhoAnexoEmail
        End Get
        Set(ByVal value As String)
            _CaminhoAnexoEmail = value
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

    Public Property ModeloChamadoCRM() As String
        Get
            Return _ModeloChamadoCRM
        End Get
        Set(ByVal value As String)
            _ModeloChamadoCRM = value
        End Set
    End Property

    Public Property CodStatusFinal() As String
        Get
            Return _CodStatusFinal
        End Get
        Set(ByVal value As String)
            _CodStatusFinal = value
        End Set
    End Property

    Public Property CodStatusInicial()
        Get
            Return _CodStatusInicial
        End Get
        Set(ByVal value)
            _CodStatusInicial = value
        End Set
    End Property

    Public Property TipoChamadoPadrao()
        Get
            Return _TipoChamadoPadrao
        End Get
        Set(ByVal value)
            _TipoChamadoPadrao = value
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

    Public Property Filtro_todos_analistas()
        Get
            Return _Filtro_todos_analistas
        End Get
        Set(ByVal value)
            _Filtro_todos_analistas = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub Buscar()
        Dim StrSql As String = " select caminho_anexo_email, cod_status_inicial, cod_status_final, cod_analista_padrao, tipo_chamado_padrao, modelo_chamado_crm, isnull(filtro_todos_analistas,'N') as filtro_todos_analistas from parametros_manutencao where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            CodStatusFinal = dt.Rows.Item(0).Item("cod_status_final").ToString
            CodStatusInicial = dt.Rows.Item(0).Item("cod_status_inicial").ToString
            TipoChamadoPadrao = dt.Rows.Item(0).Item("tipo_chamado_padrao").ToString
            ModeloChamadoCRM = dt.Rows.Item(0).Item("modelo_chamado_crm").ToString
            CaminhoAnexoEmail = dt.Rows.Item(0).Item("caminho_anexo_email").ToString
            Filtro_todos_analistas = dt.Rows.Item(0).Item("filtro_todos_analistas").ToString
            CodAnalistaPadrao = dt.Rows.Item(0).Item("cod_analista_padrao").ToString
        End If

    End Sub

End Class
