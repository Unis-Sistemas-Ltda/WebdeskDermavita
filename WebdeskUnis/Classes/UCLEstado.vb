Public Class UCLEstado
    Private _CodPais As String
    Private _CodEstado As String
    Private _NomeEstado As String
    Private _Sigla As String
    Private ObjAcessoDados As UCLAcessoDados

    Public Enum Tipo As Integer
        NomeEstado = 1
        Sigla = 2
    End Enum

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

    Public Property NomeEstado() As String
        Get
            Return _NomeEstado
        End Get
        Set(ByVal value As String)
            _NomeEstado = value
        End Set
    End Property

    Public Property Sigla() As String
        Get
            Return _Sigla
        End Get
        Set(ByVal value As String)
            _Sigla = value
        End Set
    End Property

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal TipoExibicao As Tipo)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_estado, nome_estado, sigla "
        strSql += "   from estado "
        strSql += "  where cod_pais = " + CodPais
        strSql += "  order by nome_estado "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_estado") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_estado") = DescricaoRegistroEmBranco
            NovaLinha("sigla") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt

        If TipoExibicao = Tipo.NomeEstado Then
            DDL.DataTextField = "nome_estado"
        ElseIf Tipo.Sigla Then
            DDL.DataTextField = "sigla"
        Else
            DDL.DataTextField = "nome_estado"
        End If

        DDL.DataValueField = "cod_estado"
        DDL.DataBind()
    End Sub

    Public Sub Buscar()
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select nome_estado, sigla "
            strSql += "   from estado "
            strSql += "  where cod_pais = " + CodPais
            strSql += "    and cod_estado = " + CodEstado
            dt = ObjAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                NomeEstado = dt.Rows.Item(0).Item("nome_estado").ToString
                Sigla = dt.Rows.Item(0).Item("sigla").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
