Public Class UCLUsuario
    Dim ObjAcessoDados As UCLAcessoDados
    Private _CodUsuario As String
    Private _Usuario As String
    Private _Senha As String
    Private _NomeUsuario As String
    Private _EmpresaPadrao As String
    Private _EstabelecimentoPadrao As String
    Private _Situacao As String

    Public Enum SituacaoUsuario As Integer
        Administrador = 1
        Liberado = 2
        Restrito = 3
        Bloqueado = 4
        Cancelado = 5
    End Enum

    Public Property Situacao() As String
        Get
            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
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

    Public Property NomeUsuario() As String
        Get
            Return _NomeUsuario
        End Get
        Set(ByVal value As String)
            _NomeUsuario = value
        End Set
    End Property

    Public Property EmpresaPadrao() As String
        Get
            Return _EmpresaPadrao
        End Get
        Set(ByVal value As String)
            _EmpresaPadrao = value
        End Set
    End Property

    Public Property EstabelecimentoPadrao()
        Get
            Return _EstabelecimentoPadrao
        End Get
        Set(ByVal value)
            _EstabelecimentoPadrao = value
        End Set
    End Property

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub
    Public Sub New(ByVal strConexao As String)
        ObjAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Inserir(ByVal strNome As String, ByVal strDescricao As String)
        Try
            Dim strSql As String = "insert into sysusuario (categoryname, description) values('" & strNome & "','" & strDescricao & "')"
            Call ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            'Descarrega o erro para a função superior
            Throw ex
        End Try
    End Sub

    Public Sub Alterar(ByVal strNome As String, ByVal strDescricao As String, ByVal id As Int32)
        Try
            Dim strSql As String = "update sysusuario set categoryname = '" & strNome & "' , description = '" & strDescricao & "' where categoryid = " & id
            Call ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            'Descarrega o erro para a função superior
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal id As Int32)
        Try
            Dim strSql As String = "Delete sysusuario where categoryid = " & id
            Call ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            'Descarrega o erro para a função superior
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As DataTable
        Dim strSql As String = " select  *  from sysusuario "
        'Dim ds As New DataSet
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt

    End Function

    Public Function Buscar2() As Boolean
        Dim StrSql As String = "select cod_usuario, ds_senha senha, id_situacao, nome_usuario, cod_empresa_padrao empresa, cod_estabelecimento_padrao estabelecimento from sysusuario where nome_identificacao = '" + Usuario + "'"
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Senha = dt.Rows.Item(0).Item("senha").ToString
            EmpresaPadrao = dt.Rows.Item(0).Item("empresa").ToString
            EstabelecimentoPadrao = dt.Rows.Item(0).Item("estabelecimento").ToString
            NomeUsuario = dt.Rows.Item(0).Item("nome_usuario").ToString
            CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
            Situacao = dt.Rows.Item(0).Item("id_situacao").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Function BuscarPorCodigo() As Boolean
        Dim StrSql As String = "select nome_identificacao, id_situacao, ds_senha senha, nome_usuario, cod_empresa_padrao empresa, cod_estabelecimento_padrao estabelecimento from sysusuario where cod_usuario = " + CodUsuario
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Usuario = dt.Rows.Item(0).Item("nome_identificacao")
            Senha = dt.Rows.Item(0).Item("senha").ToString
            EmpresaPadrao = dt.Rows.Item(0).Item("empresa").ToString
            EstabelecimentoPadrao = dt.Rows.Item(0).Item("estabelecimento").ToString
            NomeUsuario = dt.Rows.Item(0).Item("nome_usuario").ToString
            Situacao = dt.Rows.Item(0).Item("id_situacao").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_usuario, a.nome_usuario "
        strSql += "   from sysusuario a "
        strSql += "  where id_situacao in (1,2,3)"
        strSql += "  order by nome_usuario "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_usuario") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_usuario") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome_usuario"
        DDL.DataValueField = "cod_usuario"
        DDL.DataBind()
    End Sub

    Public Function GetTipoAcesso(ByVal CodUsuario As String) As TipoAcesso
        Dim strSql As String
        Dim CodTpAgenteVendas As String = ""
        Dim dt As DataTable
        Dim retorno As TipoAcesso

        strSql = ""
        strSql += " select cod_tp_agente_venda "
        strSql += "   from agente_venda a "
        strSql += "  where cod_agente_venda = " + CodUsuario
        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("cod_tp_agente_venda")) Then
                retorno = TipoAcesso.SemAcesso
            Else
                CodTpAgenteVendas = dt.Rows.Item(0).Item("cod_tp_agente_venda").ToString
            End If
        Else
            retorno = TipoAcesso.SemAcesso
        End If

        If retorno <> TipoAcesso.SemAcesso Then
            If Not String.IsNullOrEmpty(CodTpAgenteVendas) Then
                strSql = ""
                strSql += " select isnull(acesso,1) acesso "
                strSql += "   from tipo_agente_venda a "
                strSql += "  where cod_tp_agente_vendas = " + CodTpAgenteVendas
                dt = objAcessoDados.BuscarDados(strSql)

                If dt.Rows.Count > 0 Then
                    retorno = dt.Rows.Item(0).Item("acesso").ToString
                Else
                    retorno = TipoAcesso.SemAcesso
                End If
            Else
                retorno = TipoAcesso.SemAcesso
            End If
        End If

        If retorno = TipoAcesso.SemAcesso Then
            strSql = ""
            strSql += " select 1 acesso "
            strSql += "   from analista a "
            strSql += "  where cod_analista = " + CodUsuario
            strSql += "    and isnull(inativo,'N') = 'N'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                retorno = TipoAcesso.PosVendas
            Else
                retorno = TipoAcesso.SemAcesso
            End If
        End If

        Return retorno

    End Function

    Public Enum TipoAcesso As Integer
        SemAcesso = -1
        Vendas = 1
        PosVendas = 2
        Total = 0
    End Enum
End Class
