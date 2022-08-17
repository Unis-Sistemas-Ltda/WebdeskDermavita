Public Class UCLGrupoTEFClienteOperadoraBandeira
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("grupo_tef_cliente_operadora_bandeira")
    End Sub

    Public Function Buscar(ByVal pCodGrupo As String, ByVal pSeqCliente As String, ByVal pCodOperadora As String, ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("seq_cliente", pSeqCliente)
            Me.SetConteudo("cod_operadora", pCodOperadora)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodGrupo As String, ByVal pSeqCliente As String, ByVal pCodOperadora As String, ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("cod_grupo", pCodGrupo)
            Me.SetConteudo("seq_cliente", pSeqCliente)
            Me.SetConteudo("cod_operadora", pCodOperadora)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
