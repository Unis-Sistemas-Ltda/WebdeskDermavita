
Public Class UCLAdesaoTEFLoja
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef_loja")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BuscarPorCodEmitente(ByVal pEmpresa As String, ByVal pCodEmitente As String) As Boolean
        Try
            Dim strSql As String = " select cnpj from adesao_tef_loja where empresa = " + pEmpresa + " and cod_emitente = " + pCodEmitente
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return Buscar(pEmpresa, pCodEmitente, dt.Rows.Item(0).Item("cnpj").ToString)
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
