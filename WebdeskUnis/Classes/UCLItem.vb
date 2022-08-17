Public Class UCLItem

    Private _CodItem As String
    Private _Descricao As String
    Private _TipoFaturamento As String
    Private objAcessoDados As UCLAcessoDados
    Private _CodEmitente As String

    Public Property CodItem() As String
        Get
            Return _CodItem
        End Get
        Set(ByVal value As String)
            _CodItem = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property TipoFaturamento() As String
        Get
            Return _TipoFaturamento
        End Get
        Set(ByVal value As String)
            _TipoFaturamento = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Function GetFatorConversaoItemUnidade(ByVal codItem As String, ByVal codUnidade As String) As Double
        Dim StrSql As String = ""
        Dim dt As DataTable
        Dim ret As Double = 1

        Try
            StrSql += "select isnull(fator_conversao,1) fator "
            StrSql += "  from item_unidade "
            StrSql += " where cod_item = '" + codItem + "'"
            StrSql += "   and cod_unidade = '" + codUnidade + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("fator")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function

    Public Function GetFatorConversaoUD(ByVal codItem As String) As Double
        Dim StrSql As String = ""
        Dim dt As DataTable
        Dim ret As Double = 1

        Try
            StrSql += "select isnull(u.fator_conversao,1) fator "
            StrSql += "  from item i inner join unidade_despacho u on i.cod_ud = u.cod_ud "
            StrSql += " where cod_item = '" + codItem + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("fator")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function

    Public Function Buscar() As DataTable
        Dim strSql As String
        Dim dt As DataTable

        strSql = "select descricao, isnull(tipo_faturamento,'C') tipo_faturamento from item where cod_item = '" + CodItem + "'"

        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            TipoFaturamento = dt.Rows.Item(0).Item("tipo_faturamento").ToString
        End If

        Return dt
    End Function

    Public Function PrecoItemCliente(ByVal empresa As String, ByVal estabelecimento As String, ByVal emitente As String, ByVal cnpj As String, ByVal codItem As String) As Double
        Dim strSql As String = " select f_busca_preco_item_cliente(" + empresa + "," + estabelecimento + "," + emitente + ",'" + cnpj + "','" + codItem + "',null,null,0,0, null) preco from dummy"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim retorno As Double = 0
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("preco")) Then
                retorno = 0
            Else
                retorno = CDbl(dt.Rows.Item(0).Item("preco").ToString)
            End If

        End If
        Return retorno
    End Function

    Public Function GetNarrativa(ByVal codItem As String) As String
        Dim strSql As String = "select narrativa from item where cod_item = '" + codItem + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("narrativa").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDownUnidade(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal codItem As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select iu.cod_unidade, u.descricao "
        strSql += "   from item_unidade iu, "
        strSql += "        unidade u "
        strSql += "  where cod_item       = '" + codItem + "'"
        strSql += "    and iu.cod_unidade = u.cod_unidade "
        strSql += " union "
        strSql += " select i.cod_unidade, u.descricao "
        strSql += "   from item i, "
        strSql += "        unidade u       "
        strSql += "  where cod_item      = '" + codItem + "'"
        strSql += "    and i.cod_unidade = u.cod_unidade "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_unidade") = " "
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_unidade"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_item, descricao "
        strSql += "   from item "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_item") = " "
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_item"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDownEquipamentoChamado(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select e.numero_serie,i.descricao + '(' + e.numero_serie + ')' + ' / ' + CONVERT(varchar, e.data_referencia_garantia, 365) as descricao "
        strSql += "   from item i inner join equipamento e on i.cod_item = e.cod_item"
        strSql += "   where cod_cliente = " + CodEmitente
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        Dim NovaLinhaNUll As DataRow = dt.NewRow
        NovaLinhaNUll("numero_serie") = "NULL"
        NovaLinhaNUll("descricao") = " "
        dt.Rows.InsertAt(NovaLinhaNUll, 0)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("numero_serie") = ""
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "numero_serie"
        DDL.DataBind()
    End Sub

    Public Function GetImagem()
        Dim strSql As String
        Dim dt As DataTable
        Dim retorno

        strSql = "select imagem from item where cod_item = '" + CodItem + "'"
        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("imagem")) Then
                retorno = Nothing
            Else
                retorno = dt.Rows.Item(0).Item("imagem")
            End If
        Else
            retorno = Nothing
        End If

        Return retorno

    End Function

End Class
