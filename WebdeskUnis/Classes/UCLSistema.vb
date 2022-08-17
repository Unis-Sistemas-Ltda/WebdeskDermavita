Public Class UCLSistema
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("sistema")
    End Sub

    Public Function Buscar(ByVal pCodSistema As String) As Boolean
        Try
            Me.SetConteudo("cod_sistema", pCodSistema)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodSistema As String)
        Try
            Me.SetConteudo("cod_sistema", pCodSistema)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_sistema),0) + 1 seq from sistema "
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("seq")
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, Optional ByVal AdicionarRegistroEmBranco As Boolean = False, Optional ByVal DescricaoRegistroEmBranco As String = "")
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_sistema, descricao "
        strSql += "   from sistema "
        strSql += "  order by if cod_sistema = 1 then space(10) || descricao else descricao endif "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_sistema") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_sistema"
        DDL.DataBind()
    End Sub

    Public Function GetLista(ByVal MenuWebdesk As String) As List(Of UCLSistema)
        Try
            Dim ObjSistema As UCLSistema
            Dim lista As New List(Of UCLSistema)
            Dim StrSql As String = "select cod_sistema from sistema " + IIf(Not String.IsNullOrWhiteSpace(MenuWebdesk), " where menu_webdesk = '" + MenuWebdesk + "'", "") + " order by cod_sistema"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            For Each dr As DataRow In dt.Rows
                ObjSistema = New UCLSistema
                ObjSistema.Buscar(dr.Item("cod_sistema"))
                lista.Add(ObjSistema)
            Next

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLista() As List(Of UCLSistema)
        Try
            Return GetLista("")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
