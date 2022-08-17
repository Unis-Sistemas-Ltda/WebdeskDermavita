Public Class UCLAgenteVendas

    Private _Codigo As String
    Private _Nome As String
    Private _Tipo As String
    Private _Email As String
    Private _Senha As String
    Private _SMTP As String
    Private objAcessoDados As UCLAcessoDados

    Public Function STMP(ByVal empresa As String) As String
        Dim strSql As String
        Dim dt As DataTable
        objAcessoDados = New UCLAcessoDados(StrConexao)

        strSql = "select smtp from parametros_email where empresa = " + empresa
        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Return dt.Rows.Item(0).Item("smtp").ToString
        Else
            Return ""
        End If

    End Function


    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return _Senha
        End Get
        Set(ByVal value As String)
            _Senha = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select a.cod_agente_venda, u.nome_usuario nome, a.cod_tp_agente_venda, a.email, a.senha "
        StrSql += "   from agente_venda a inner join sysusuario u on a.cod_agente_venda = u.cod_usuario"
        StrSql += "  where cod_agente_venda = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            Tipo = dt.Rows.Item(0).Item("cod_tp_agente_venda").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            Senha = dt.Rows.Item(0).Item("senha").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Enum TipoRestricaoAcesso
        SemRestricao = 0
        SomenteOProprioAgenteDeVendasNoCRMeNoResults = 1
        SomenteOProprioAgenteDeVendasNoCRM = 2
    End Enum

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal codigo As String, ByVal tipoRestricao As TipoRestricaoAcesso)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_agente_venda, u.nome_usuario nome"
        strSql += "   from agente_venda a inner join sysusuario u on a.cod_agente_venda = u.cod_usuario"
        If tipoRestricao = TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults OrElse tipoRestricao = TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRM Then
            strSql += "  where cod_agente_venda     = " + codigo
        Else
            strSql += "  where (cod_agente_venda     = " + codigo + " or u.id_situacao not in (4,5)) "
        End If
        strSql += "    and isnull(a.inativo,'N') = 'N' "
        strSql += "  order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If tipoRestricao = TipoRestricaoAcesso.SemRestricao Then
            If AdicionarRegistroEmBranco Then
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_agente_venda") = 0
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("nome") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_agente_venda"
        DDL.DataBind()

        If codigo <> "" AndAlso codigo <> "0" AndAlso DDL.Items.FindByValue(codigo) IsNot Nothing Then
            DDL.SelectedValue = codigo
        End If
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_agente_venda),0) + 1 max from agente_venda "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into agente_venda (cod_agente_venda, cod_tp_agente_venda, alocacao_cenario, email, senha)"
            strSql += " values ( " + Codigo + ", " + Tipo + ", 3, '" + Email + "','" + Senha + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update agente_venda set cod_tp_agente_venda = " + Tipo + ","
            strSql += "                         email = '" + Email + "',"
            strSql += "                         senha = '" + Senha + "'"
            strSql += "  where cod_agente_venda = " + Codigo
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetMaster(ByVal pCodAgenteVenda As String) As String
        Try
            Dim StrSql As String = " select isnull(t.master,'N') master from agente_venda a inner join tipo_agente_venda t on a.cod_tp_agente_venda = t.cod_tp_agente_vendas where a.cod_agente_venda = " + pCodAgenteVenda
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("master").ToString
            Else
                Return "N"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFunis(ByVal pEmpresa As String, ByVal pCodAgenteVenda As String) As List(Of String)
        Dim strSql As String = "select cod_funil from agente_venda_funil_venda where empresa = " + pEmpresa + " and cod_agente_venda = " + IIf(String.IsNullOrEmpty(pCodAgenteVenda), "0", pCodAgenteVenda)
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim funis As New List(Of String)

        For Each row As DataRow In dt.Rows
            funis.Add(row.Item("cod_funil").ToString())
        Next

        Return funis
    End Function

    Public Sub InserirFunil(ByVal pEmpresa As String, ByVal pCodAgenteVenda As String, ByVal pCodFunilVenda As String)
        Dim strSql As String = "insert into agente_venda_funil_venda(empresa, cod_agente_venda, cod_funil) values(" + pEmpresa + ", " + pCodAgenteVenda + ", " + pCodFunilVenda + ")"
        objAcessoDados.ExecutarSql(strSql)
    End Sub

    Public Sub ExcluirFunil(ByVal pEmpresa As String, ByVal pCodAgenteVenda As String, ByVal pCodFunilVenda As String)
        Dim strSql As String = "delete from agente_venda_funil_venda where empresa = " + pEmpresa + " and cod_agente_venda = " + pCodAgenteVenda + " and cod_funil = " + pCodFunilVenda
        objAcessoDados.ExecutarSql(strSql)
    End Sub

End Class