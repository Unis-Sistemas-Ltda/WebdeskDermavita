Public Class UCLEtapaTarefaPadrao

    Private _Empresa As String
    Private _CodEtapa As String
    Private _Tarefas As List(Of String)
    Private objAcessoDados As UCLAcessoDados

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodEtapa() As String
        Get
            Return _CodEtapa
        End Get
        Set(ByVal value As String)
            _CodEtapa = value
        End Set
    End Property

    Public Property Tarefas() As List(Of String)
        Get
            Return _Tarefas
        End Get
        Set(ByVal value As List(Of String))
            _Tarefas = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub BuscarTarefas()
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = ""
            strSql += " select cod_tarefa_padrao "
            strSql += "   from etapa_negociacao_tarefa_padrao "
            strSql += "  where empresa   = " + Empresa
            strSql += "    and cod_etapa = " + CodEtapa
            dt = objAcessoDados.BuscarDados(strSql)

            Tarefas = New List(Of String)

            For Each row As DataRow In dt.Rows
                Tarefas.Add(row.Item("cod_tarefa_padrao").ToString)
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub GravarTarefas()
        Dim StrSql As String

        Try
            'Deleta as tarefas atualmente cadastradas
            StrSql = ""
            StrSql += " delete from etapa_negociacao_tarefa_padrao "
            StrSql += "  where empresa   = " + Empresa
            StrSql += "    and cod_etapa = " + CodEtapa
            objAcessoDados.ExecutarSql(StrSql)

            'Reinsere com a nova lista de tarefas
            For Each CodTarefa As String In Tarefas
                StrSql = ""
                StrSql += " insert into etapa_negociacao_tarefa_padrao ( empresa, cod_etapa, cod_tarefa_padrao ) "
                StrSql += "    values ( " + Empresa + "," + CodEtapa + "," + CodTarefa + " );"
                objAcessoDados.ExecutarSql(StrSql)
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
