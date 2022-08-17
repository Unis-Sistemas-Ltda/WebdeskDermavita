Public Class UCLGrupoTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("grupo_tef")
    End Sub

    Public Function Buscar(ByVal pCodGrupo As String) As Boolean
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodGrupo As String)
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
