Public Class UCLSolicitacaoDesenvolvimentoFollowUp

    Private ObjAcessoDados As UCLAcessoDados
    Public Property Empresa As String
    Public Property CodSolicitacao As String
    Public Property SeqFollowUp As String
    Public Property CodUsuarioInclusao As String
    Public Property CodUsuarioAlteracao As String
    Public Property Descricao As String
    Public Property VisivelCliente As String

    Public Sub New(ByVal StrC As String)
        ObjAcessoDados = New UCLAcessoDados(StrC)
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String
            StrSql = " insert into solicitacao_desenvolvimento_follow_up (empresa, cod_solicitacao, seq_follow_up, descricao, data_follow_up, cod_usuario_inclusao, cod_usuario_alteracao, visivel_cliente)"
            StrSql += "  values(" + Empresa + ", " + CodSolicitacao + ", " + SeqFollowUp + ", '" + Descricao + "', now(), " + CodUsuarioInclusao + "," + CodUsuarioAlteracao + ",'" + VisivelCliente + "')"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            StrSql = " update solicitacao_desenvolvimento_follow_up"
            StrSql += "   set descricao             = '" + Descricao + "', "
            StrSql += "       visivel_cliente       = '" + VisivelCliente + "', "
            StrSql += "       cod_usuario_alteracao = " + CodUsuarioAlteracao
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_follow_up   = " + SeqFollowUp
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String = ""
            StrSql = " delete from solicitacao_desenvolvimento_follow_up"
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_follow_up   = " + SeqFollowUp
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql = " select * "
            StrSql += "  from solicitacao_desenvolvimento_follow_up "
            StrSql += " where empresa         = " + Empresa
            StrSql += "   and cod_solicitacao = " + CodSolicitacao
            StrSql += "   and seq_follow_up   = " + SeqFollowUp
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                CodUsuarioInclusao = dt.Rows.Item(0).Item("cod_usuario_inclusao").ToString
                CodUsuarioAlteracao = dt.Rows.Item(0).Item("cod_usuario_alteracao").ToString
                VisivelCliente = dt.Rows.Item(0).Item("visivel_cliente").ToString
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
        strSql = " select isnull(max(seq_follow_up),0) + 1 max "
        strSql += "  from solicitacao_desenvolvimento_follow_up"
        strSql += " where empresa         = " + Empresa
        strSql += "   and cod_solicitacao = " + CodSolicitacao
        dt = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function


End Class
