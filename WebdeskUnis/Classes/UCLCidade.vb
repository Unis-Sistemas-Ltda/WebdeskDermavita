Public Class UCLCidade

    Private _CodPais As String
    Private _CodEstado As String
    Private _CodCidade As String
    Private _NomeCidade As String
    Private ObjAcessoDados As UCLAcessoDados

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

    Public Property NomeCidade() As String
        Get
            Return _NomeCidade
        End Get
        Set(ByVal value As String)
            _NomeCidade = value
        End Set
    End Property

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_cidade, nome_cidade "
        strSql += "   from cidade "
        strSql += "  where cod_pais = " + CodPais
        strSql += "    and cod_estado = " + CodEstado
        strSql += "  order by nome_cidade "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_cidade") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_cidade") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome_cidade"
        DDL.DataValueField = "cod_cidade"
        DDL.DataBind()
    End Sub

    Public Sub Buscar()
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select nome_cidade "
            strSql += "   from cidade "
            strSql += "  where cod_pais = " + CodPais
            strSql += "    and cod_estado = " + CodEstado
            strSql += "   and cod_cidade = " + CodCidade
            dt = ObjAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                NomeCidade = dt.Rows.Item(0).Item("nome_cidade").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
