Public Class UCLTurmaHorario
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("turma_horario")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodTurma As String, ByVal pSeqHorario As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_turma", pCodTurma)
            Me.SetConteudo("seq_horario", pSeqHorario)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodTurma As String, ByVal pSeqHorario As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_turma", pCodTurma)
            Me.SetConteudo("seq_horario", pSeqHorario)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodTurma As String) As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_horario),0) + 1 max from turma_horario where empresa = " + pEmpresa
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
