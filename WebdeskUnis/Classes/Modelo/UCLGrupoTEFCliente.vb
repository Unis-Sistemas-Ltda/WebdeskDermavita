Public Class UCLGrupoTEFCliente
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("grupo_tef_cliente")
    End Sub

    Public Function Buscar(ByVal pCodGrupo As String, ByVal pSeqCliente As String) As Boolean
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("seq_cliente", pSeqCliente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodGrupo As String, ByVal pSeqCliente As String)
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("seq_cliente", pSeqCliente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
