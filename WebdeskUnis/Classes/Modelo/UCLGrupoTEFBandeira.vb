Public Class UCLGrupoTEFBandeira
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("grupo_tef_bandeira")
    End Sub

    Public Function Buscar(ByVal pCodGrupo As String, ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodGrupo As String, ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
