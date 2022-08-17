Public Class UCLOperadoraBandeiraTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("operadora_bandeira_tef")
    End Sub

    Public Function Buscar(ByVal pCodOperadora As String, ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("cod_operadora", pCodOperadora)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodOperadora As String, ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("cod_operadora", pCodOperadora)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
