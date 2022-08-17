Public Class UCLTipoChamado
    Private _Empresa As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodTipoChamado As String
    Public Property Nome As String
    Public Property Cod_Usuario As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Sub Buscar()
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select *"
            strSql += "   from tipo_chamado"
            strSql += "  where empresa = " + Empresa
            strSql += "    and codigo  = " + CodTipoChamado
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                Nome = dt.Rows.Item(0).Item("nome").ToString()
                Cod_Usuario = dt.Rows.Item(0).Item("cod_usuario").ToString()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select codigo, nome"
        strSql += "   from tipo_chamado"
        strSql += "  where empresa = " + Empresa
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDownChamado(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select codigo, nome + '(' + convert(varchar,codigo) + ')' as nome"
        strSql += "   from tipo_chamado"
        strSql += "  where empresa = " + Empresa + "and visualiza_webdesk = 'S'"
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub

End Class
