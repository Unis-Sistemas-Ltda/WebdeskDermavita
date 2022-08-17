Public Class UCLFunilVenda
    Private _Codigo As String
    Private _Descricao As String
    Private _Empresa As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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

    Public Property CodEtapaFinalSucesso As String
    Public Property CodEtapaFinalInsucesso As String
    Public Property OcultarEquipamento As String

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select descricao, cod_etapa_final_sucesso, cod_etapa_final_insucesso, ocultar_equipamento "
        StrSql += "   from funil_venda "
        StrSql += "  where empresa   = " + Empresa
        StrSql += "    and cod_funil = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_etapa_final_sucesso")) Then
                CodEtapaFinalSucesso = dt.Rows.Item(0).Item("cod_etapa_final_sucesso").ToString
            Else
                CodEtapaFinalSucesso = ""
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_etapa_final_insucesso")) Then
                CodEtapaFinalInsucesso = dt.Rows.Item(0).Item("cod_etapa_final_insucesso").ToString
            Else
                CodEtapaFinalInsucesso = ""
            End If
            OcultarEquipamento = dt.Rows.Item(0).Item("ocultar_equipamento").ToString()
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetFunis(ByVal pEmpresa As String) As DataTable
        Dim strSql As String = ""
        Dim dt As DataTable
        strSql += " select cod_funil, descricao"
        strSql += "   from funil_venda "
        strSql += "  where empresa = " + pEmpresa
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pEmpresa As String, ByVal pCodAgenteVenda As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_funil, descricao"
        strSql += "   from funil_venda f "
        strSql += "  where empresa = " + pEmpresa
        If Not String.IsNullOrEmpty(pCodAgenteVenda) AndAlso pCodAgenteVenda > "0" Then
            strSql += " and ( not exists(select 1 from agente_venda_funil_venda where empresa = " + pEmpresa + " and cod_agente_venda = " + pCodAgenteVenda + ") or exists(select 1 from agente_venda_funil_venda a where a.empresa = " + pEmpresa + " and a.cod_agente_venda = " + pCodAgenteVenda + " and a.cod_funil = f.cod_funil) )"
        End If
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_funil") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_funil"
        DDL.DataBind()
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into funil_venda (empresa, cod_funil, descricao, cod_etapa_final_sucesso, cod_etapa_final_insucesso, ocultar_equipamento) "
            strSql += " values ( " + Empresa + "," + Codigo + ", '" + Descricao + "'," + IIf(String.IsNullOrEmpty(CodEtapaFinalSucesso), "null", CodEtapaFinalSucesso) + "," + IIf(String.IsNullOrEmpty(CodEtapaFinalInsucesso), "null", CodEtapaFinalInsucesso) + ", " + IIf(String.IsNullOrEmpty(OcultarEquipamento), "null", "'" + OcultarEquipamento + "'") + ") "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update funil_venda "
            strSql += "    set descricao = '" + Descricao + "', "
            strSql += "        cod_etapa_final_sucesso   = " + IIf(String.IsNullOrEmpty(CodEtapaFinalSucesso), "null", CodEtapaFinalSucesso) + ", "
            strSql += "        cod_etapa_final_insucesso = " + IIf(String.IsNullOrEmpty(CodEtapaFinalInsucesso), "null", CodEtapaFinalInsucesso) + ", "
            strSql += "        ocultar_equipamento       = " + IIf(String.IsNullOrEmpty(OcultarEquipamento), "null", "'" + OcultarEquipamento + "'")
            strSql += "  where cod_funil = " + Codigo
            strSql += "    and empresa = " + Empresa
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_funil),0) + 1 max from funil_venda where empresa = " + Empresa
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
