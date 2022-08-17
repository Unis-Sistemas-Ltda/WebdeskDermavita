Public Class UCLAdesaoParceriaSantanderCNPJ
    Private ObjAcessoDados As UCLAcessoDados
    Public Property empresa As String
    Public Property cod_emitente As String
    Public Property seq_adesao As String
    Public Property cnpj As String
    Public Property preferencial As String
    Public Property qtd_pdv As String

    Public Sub New(ByVal strC As String)
        ObjAcessoDados = New UCLAcessoDados(strC)
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String
            StrSql = "insert into adesao_parceria_santander_cnpj (empresa, seq_adesao, cod_emitente, cnpj, preferencial, qtd_pdv) "
            StrSql += " values(" + empresa + ", " + seq_adesao + ", " + cod_emitente + ", '" + cnpj + "', '" + preferencial + "', " + IIf(String.IsNullOrWhiteSpace(qtd_pdv), "null", qtd_pdv) + " ) "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            StrSql = " update adesao_parceria_santander_cnpj "
            StrSql += "   set preferencial       = '" + preferencial + "', "
            StrSql += "       qtd_pdv            = " + IIf(String.IsNullOrWhiteSpace(qtd_pdv), "null", qtd_pdv)
            StrSql += " where empresa      = " + empresa
            StrSql += "   and cod_emitente = " + cod_emitente
            StrSql += "   and cnpj         = '" + cnpj + "'"
            StrSql += "   and seq_adesao   = " + seq_adesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String

            StrSql = "delete from adesao_parceria_santander_cnpj "
            StrSql += "where empresa      = " + empresa
            StrSql += "  and cod_emitente = " + cod_emitente
            StrSql += "  and cnpj         = '" + cnpj + "'"
            StrSql += "  and seq_adesao   = " + seq_adesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "select * from adesao_parceria_santander_cnpj where empresa = " + empresa + " and cod_emitente = " + cod_emitente + " and cnpj = '" + cnpj + "' and seq_adesao = " + seq_adesao
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                preferencial = dt.Rows.Item(0).Item("preferencial").ToString
                qtd_pdv = dt.Rows.Item(0).Item("qtd_pdv").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsereCNPJs(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pSeqAdesao As String)
        Try
            Dim StrSql As String = ""

            StrSql += " insert into adesao_parceria_santander_cnpj ( empresa, seq_adesao, cod_emitente, cnpj, preferencial, qtd_pdv ) "
            StrSql += "    select " + pEmpresa + ", " + pSeqAdesao + ", ee.cod_emitente, ee.cnpj, ee.preferencial, null"
            StrSql += "      from endereco_emitente ee "
            StrSql += "     where cod_emitente = " + pCodEmitente
            StrSql += "       and isnull(ativo,'N') = 'S'"
            StrSql += "       and not exists(select 1 from adesao_parceria_santander_cnpj a where a.cod_emitente = ee.cod_emitente and a.cnpj = ee.cnpj) "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
