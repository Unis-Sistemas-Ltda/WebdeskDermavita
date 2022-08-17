Public Class UCLCarteiraCRM
    Private _CodCarteira As String
    Private _Descricao As String
    Private _CodRepresentante As String
    Private _Tipo As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodCarteira() As String
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As String)
            _CodCarteira = value
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

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property CodRepresentante() As String
        Get
            Return _CodRepresentante
        End Get
        Set(ByVal value As String)
            _CodRepresentante = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into carteira ( cod_carteira, descricao, tipo, cod_representante) "
            strSql += " values (" + CodCarteira + ", '" + Descricao + "', '" + Tipo + "', " + IIf(CodRepresentante.ToString = "0" Or CodRepresentante.ToString.Trim = "", "null", CodRepresentante) + ")"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update carteira set descricao = '" + Descricao + "', tipo = '" + Tipo + "', cod_representante = " + IIf(CodRepresentante.ToString = "0" Or CodRepresentante.ToString.Trim = "", "null", CodRepresentante)
            strSql += " where cod_carteira = " + CodCarteira

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select cod_carteira, descricao, tipo, cod_representante "
        StrSql += "  from carteira"
        StrSql += " where cod_carteira = " + CodCarteira

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_representante")) Then
                CodRepresentante = dt.Rows.Item(0).Item("cod_representante").ToString
            Else
                CodRepresentante = Nothing
            End If
        End If

        Return dt
    End Function

    Public Sub FillControl(ByRef DDL As Object, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_carteira, descricao "
        strSql += "   from carteira "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_carteira") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        If TypeOf DDL Is DropDownList Then
            CType(DDL, DropDownList).DataSource = dt
            CType(DDL, DropDownList).DataTextField = "descricao"
            CType(DDL, DropDownList).DataValueField = "cod_carteira"
            CType(DDL, DropDownList).DataBind()
        ElseIf TypeOf DDL Is ListBox Then
            CType(DDL, ListBox).DataSource = dt
            CType(DDL, ListBox).DataTextField = "descricao"
            CType(DDL, ListBox).DataValueField = "cod_carteira"
            CType(DDL, ListBox).DataBind()
        End If

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_carteira),0) + 1 max from carteira "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function
End Class
