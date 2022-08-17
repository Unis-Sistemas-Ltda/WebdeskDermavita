Public Class UCLBandeiraTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("bandeira_tef")
    End Sub

    Public Function Buscar(ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("bandeira_tef", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("bandeira_tef", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
