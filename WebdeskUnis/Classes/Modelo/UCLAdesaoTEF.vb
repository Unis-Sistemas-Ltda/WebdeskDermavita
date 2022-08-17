Public Class UCLAdesaoTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodAdesao As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_adesao", pCodAdesao)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodAdesao As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_adesao", pCodAdesao)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_adesao),0) + 1 max from adesao_tef where empresa = " + pEmpresa
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodRegistroEmBranco As String, ByVal pEmpresa As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_adesao codigo, nome_rede nome"
        strSql += "   from adesao_tef"
        strSql += "  where empresa = " + pEmpresa
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = pCodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub

    Public Structure StLoja
        Public Property CodEmitente
        Public Property CNPJ
    End Structure

    Public Function GetLojas(ByVal pCodAdesao As String) As List(Of StLoja)
        Try
            Dim StrSql As String = "select cod_emitente, cnpj from adesao_tef_loja where cod_adesao = " + pCodAdesao
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            Dim loja As StLoja
            Dim ret As New List(Of StLoja)

            For Each row As DataRow In dt.Rows
                loja = New StLoja
                loja.CodEmitente = row.Item("cod_emitente")
                loja.CNPJ = row.Item("cnpj")
                ret.Add(loja)
            Next

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
