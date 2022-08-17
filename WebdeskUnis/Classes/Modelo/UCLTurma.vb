Public Class UCLTurma
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("turma")
    End Sub

    Public Function GerarHorariosConformePadrao(ByVal pEmpresa As String, ByVal pCodTurma As String)
        Try
            Dim StrSql As String
            StrSql = " insert into turma_horario(empresa, cod_turma, seq_horario, hora_inicio, hora_termino) "
            StrSql += "  select th.empresa, " + pCodTurma + ", th.seq_horario, th.hora_inicio, th.hora_termino "
            StrSql += "    from turma_horario th inner join turma t on t.empresa = th.empresa and t.cod_turma = th.cod_turma "
            StrSql += "   where t.empresa = " + pEmpresa
            StrSql += "     and t.padrao  = 'S'"
            StrSql += "     and t.estabelecimento = (select estabelecimento from turma where empresa = " + pEmpresa + " and cod_turma = " + pCodTurma + ")"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodTurma As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_turma", pCodTurma)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodTurma As String)
        Try
            Dim StrSql As String = "delete from turma_horario where empresa = " + pEmpresa + " and cod_turma = " + pCodTurma
            ObjAcessoDados.ExecutarSql(StrSql)

            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_turma", pCodTurma)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_turma),0) + 1 max from turma where empresa = " + pEmpresa
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function GetCodTurmaPadrao(ByVal pEmpresa As String, ByVal pEstabelecimento As String) As String
        Try
            Dim strSql As String = "select cod_turma from turma where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and padrao = 'S'"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count <= 0 Then
                Return "0"
            Else
                Return dt.Rows.Item(0).Item("cod_turma").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
