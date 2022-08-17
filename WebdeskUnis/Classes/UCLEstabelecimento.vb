Public Class UCLEstabelecimento
    Private _CodEmpresa As String
    Private _Estabelecimento As String
    Private _RazaoSocial As String
    Private _CNPJ As String
    Private _InscEst As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodCidade As String
    Private _Telefones As String
    Private _Fax As String
    Private _Rua As String
    Private _Numero As String
    Private _Bairro As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodEmitente As String

    Public Property CodEmpresa() As String
        Get
            Return _CodEmpresa
        End Get
        Set(ByVal value As String)
            _CodEmpresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
        End Set
    End Property

    Public Property RazaoSocial() As String
        Get
            Return _RazaoSocial
        End Get
        Set(ByVal value As String)
            _RazaoSocial = value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property

    Public Property InscEst() As String
        Get
            Return _InscEst
        End Get
        Set(ByVal value As String)
            _InscEst = value
        End Set
    End Property

    Public Property CodPais() As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodEstado() As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property

    Public Property CodCidade() As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property

    Public Property Rua() As String
        Get
            Return _Rua
        End Get
        Set(ByVal value As String)
            _Rua = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Bairro() As String
        Get
            Return _Bairro
        End Get
        Set(ByVal value As String)
            _Bairro = value
        End Set
    End Property

    Public Property Telefones() As String
        Get
            Return _Telefones
        End Get
        Set(ByVal value As String)
            _Telefones = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function BuscarPorCNPJ(ByVal pCNPJ As String) As Boolean
        Dim StrSql As String = "select empresa, estabelecimento from estabelecimento where cnpj = '" + pCNPJ + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Me.CodEmpresa = dt.Rows.Item(0).Item("empresa").ToString
            Me.Estabelecimento = dt.Rows.Item(0).Item("estabelecimento").ToString
            Return Me.Buscar()
        Else
            Return False
        End If

    End Function

    Public Function Buscar() As Boolean
        Dim StrSql As String = "select cod_emitente, cnpj, inscr_est, rua, numero, bairro, razao_social, cod_pais, cod_estado, cod_cidade, fones, fax from estabelecimento where empresa = " + CodEmpresa + " and estabelecimento = " + Estabelecimento
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            RazaoSocial = dt.Rows.Item(0).Item("razao_social").ToString
            CodPais = dt.Rows.Item(0).Item("cod_pais").ToString
            CodEstado = dt.Rows.Item(0).Item("cod_estado").ToString
            CodCidade = dt.Rows.Item(0).Item("cod_cidade").ToString
            Rua = dt.Rows.Item(0).Item("rua").ToString
            Numero = dt.Rows.Item(0).Item("numero").ToString
            Bairro = dt.Rows.Item(0).Item("bairro").ToString
            Telefones = dt.Rows.Item(0).Item("fones").ToString
            Fax = dt.Rows.Item(0).Item("fax").ToString
            CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
            InscEst = dt.Rows.Item(0).Item("inscr_est").ToString
            CodEmitente = dt.Rows.Item(0).Item("cod_emitente").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Enum TipoExibicao
        NomeFantasia = 1
        NomeAbreviado = 2
    End Enum

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal tipo As TipoExibicao)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select estabelecimento, nome_fantasia, nome_abreviado "
        strSql += "   from estabelecimento "
        strSql += "  where empresa = " + CodEmpresa
        strSql += "  order by estabelecimento "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("estabelecimento") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_fantasia") = DescricaoRegistroEmBranco
            NovaLinha("nome_abreviado") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        If tipo = TipoExibicao.NomeFantasia Then
            DDL.DataTextField = "nome_fantasia"
        ElseIf tipo = TipoExibicao.NomeAbreviado Then
            DDL.DataTextField = "nome_abreviado"
        End If
        DDL.DataValueField = "estabelecimento"
        DDL.DataBind()
    End Sub

    Public Function buscarRegionais() As DataTable
        Dim strSql As String = "select estabelecimento,nome_abreviado from estabelecimento where empresa = 1 and not (estabelecimento = 1)"
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

End Class
