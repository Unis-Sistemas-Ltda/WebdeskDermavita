Public Class UCLOperadoraTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("operadora_tef")
    End Sub

    Public Function Buscar(ByVal pCodOperadora As String) As Boolean
        Try
            Me.SetConteudo("cod_operadora", pCodOperadora)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodOperadora As String)
        Try
            Me.SetConteudo("cod_operadora", pCodOperadora)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
