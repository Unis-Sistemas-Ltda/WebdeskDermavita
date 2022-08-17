Public Class UCLMoeda
    Private _CodMoeda As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodCanalVenda() As String
        Get
            Return _CodMoeda
        End Get
        Set(ByVal value As String)
            _CodMoeda = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_indicador, nome_indicador "
        strSql += "   from moedas "
        strSql += "  order by nome_indicador "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_indicador") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_indicador") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome_indicador"
        DDL.DataValueField = "cod_indicador"
        DDL.DataBind()
    End Sub

End Class
