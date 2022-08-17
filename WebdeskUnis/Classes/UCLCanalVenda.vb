Public Class UCLCanalVenda
    Private _CodCanalVenda As String
    Private _Empresa As String
    Private _Descricao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodCanalVenda() As String
        Get
            Return _CodCanalVenda
        End Get
        Set(ByVal value As String)
            _CodCanalVenda = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillControl(ByRef DDL As Object, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_canal_venda, descricao "
        strSql += "   from canal_venda "
        strSql += "  where empresa = " + Empresa
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_canal_venda") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        If TypeOf DDL Is DropDownList Then
            CType(DDL, DropDownList).DataSource = dt
            CType(DDL, DropDownList).DataTextField = "descricao"
            CType(DDL, DropDownList).DataValueField = "cod_canal_venda"
            CType(DDL, DropDownList).DataBind()
        ElseIf TypeOf DDL Is ListBox Then
            CType(DDL, ListBox).DataSource = dt
            CType(DDL, ListBox).DataTextField = "descricao"
            CType(DDL, ListBox).DataValueField = "cod_canal_venda"
            CType(DDL, ListBox).DataBind()
        End If

    End Sub
End Class
