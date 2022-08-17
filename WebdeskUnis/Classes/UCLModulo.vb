Public Class UCLModulo
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("sysmodulo")
    End Sub

    Public Function Buscar(ByVal pCodModulo As String) As Boolean
        Try
            Me.SetConteudo("cod_modulo", pCodModulo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodModulo As String)
        Try
            Me.SetConteudo("cod_modulo", pCodModulo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_modulo),0) + 1 seq from modulo "
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodSistema As String)
        Dim strSql As String = ""
        Dim dt As DataTable


        strSql += " select cod_modulo, nome_modulo "
        strSql += "   from sysmodulo "
        If Not String.IsNullOrWhiteSpace(CodSistema) Then
            strSql += " where cod_sistema = " + CodSistema
        End If
        strSql += "  order by nome_modulo "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_modulo") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_modulo") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome_modulo"
        DDL.DataValueField = "cod_modulo"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select convert(varchar(4),cod_modulo) cod_modulo, nome_modulo "
        strSql += "   from sysmodulo "
        strSql += "  order by nome_modulo "
        dt = objAcessoDados.BuscarDados(strSql)

        Dim nr As DataRow = dt.NewRow
        nr.Item("cod_modulo") = " "
        nr.Item("nome_modulo") = " "
        dt.Rows.InsertAt(nr, 0)

        DDL.DataSource = dt
        DDL.DataTextField = "nome_modulo"
        DDL.DataValueField = "cod_modulo"
        DDL.DataBind()
    End Sub

    Public Function GetLista(ByVal pCodSistema As String) As List(Of UCLModulo)
        Try
            Dim ObjModulo As UCLModulo
            Dim lista As New List(Of UCLModulo)
            Dim StrSql As String = "select cod_modulo from sysmodulo where cod_sistema = " + pCodSistema + " order by ds_modulo"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            For Each dr As DataRow In dt.Rows
                ObjModulo = New UCLModulo
                ObjModulo.Buscar(dr.Item("cod_modulo"))
                lista.Add(ObjModulo)
            Next

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class