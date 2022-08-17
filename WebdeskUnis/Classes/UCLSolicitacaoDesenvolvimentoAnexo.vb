Public Class UCLSolicitacaoDesenvolvimentoAnexo

    Private ObjAcessoDados As UCLAcessoDados
    Public Property Empresa As String
    Public Property CodSolicitacao As String
    Public Property SeqAnexo As String
    Public Property Anexo As String
    Public Property Descricao As String

    Public Sub New(ByVal StrC As String)
        ObjAcessoDados = New UCLAcessoDados(StrC)
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String
            StrSql = " insert into solicitacao_desenvolvimento_anexo (empresa, cod_solicitacao, seq_anexo, anexo, descricao)"
            StrSql += "  values(" + Empresa + ", " + CodSolicitacao + ", " + SeqAnexo + ", '" + Anexo + "', '" + Descricao + "')"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            StrSql = " update solicitacao_desenvolvimento_anexo"
            StrSql += "   set "
            If Anexo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Anexo) Then
                StrSql += " anexo = '" + Anexo + "', "
            End If
            StrSql += "       descricao = '" + Descricao + "'"
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_anexo       = " + SeqAnexo
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String = ""
            StrSql = " delete from solicitacao_desenvolvimento_anexo"
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_anexo       = " + SeqAnexo
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql = " select anexo, descricao "
            StrSql += "  from solicitacao_desenvolvimento_anexo"
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_anexo       = " + SeqAnexo
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Anexo = dt.Rows.Item(0).Item("anexo").ToString
                Descricao = dt.Rows.Item(0).Item("descricao").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql
        Dim dt As DataTable
        strSql = " select isnull(max(seq_anexo),0) + 1 max "
        strSql += "  from solicitacao_desenvolvimento_anexo"
        strSql += " where empresa         = " + Empresa
        strSql += "   and cod_solicitacao = " + CodSolicitacao
        dt = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function


End Class
