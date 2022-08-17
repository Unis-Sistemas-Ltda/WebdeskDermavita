Public Class UCLPais

    Private objAcessoDados As UCLAcessoDados
    Private _CodPais As String
    Private _Nome As String
    Private _Sigla As String

    Public Property CodPais() As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
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

    Public Property Sigla() As String
        Get
            Return _Sigla
        End Get
        Set(ByVal value As String)
            _Sigla = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Buscar()
        Dim strSql As String = " select nome_pais, sigla from pais where cod_pais = " + CodPais
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome_pais").ToString
            Sigla = dt.Rows.Item(0).Item("sigla").ToString
        End If
    End Sub

    Public Sub Incluir()
        Dim strSql As String = " insert into pais(cod_pais, nome_pais, sigla) values (" + CodPais + ", '" + Nome + "', '" + Sigla + "')"

        Try
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update pais set nome_pais = '" + Nome + "', sigla = '" + Sigla + "' where cod_pais = " + CodPais
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_pais),0) + 1 max from pais "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function


    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_pais, nome_pais "
        strSql += "   from pais "
        strSql += "  order by nome_pais "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_pais") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_pais") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome_pais"
        DDL.DataValueField = "cod_pais"
        DDL.DataBind()
    End Sub

End Class
