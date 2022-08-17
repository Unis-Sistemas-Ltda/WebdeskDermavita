Public Class UCLVersaoSistema
    Private objAcessoDados As UCLAcessoDados

    Public Property Versao As String
    Public Property Release As String
    Public Property Descricao As String
    Public Property InicioVigencia As String
    Public Property TerminoVigencia As String
    Public Property Liberado As String

    Public Sub Incluir()
        Dim strSql As String = ""
        Dim inivig As String
        Dim fimvig As String
        Try
            If IsDate(InicioVigencia) Then
                inivig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                inivig = "null"
            End If
            If IsDate(TerminoVigencia) Then
                fimvig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                fimvig = "null"
            End If

            strSql += " insert into versao_sistema (versao, " + Chr(34) + "release" + Chr(34) + ", descricao, inicio_vigencia, termino_vigencia, liberado) "
            strSql += " values ( " + Versao + ", " + Release + ", '" + Descricao + "', " + inivig + ", " + fimvig + ", '" + Liberado + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Dim inivig As String
        Dim fimvig As String
        Try
            If IsDate(InicioVigencia) Then
                inivig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                inivig = "null"
            End If
            If IsDate(TerminoVigencia) Then
                fimvig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                fimvig = "null"
            End If

            strSql += " update versao_sistema "
            strSql += "    set descricao        = '" + Descricao + "', "
            strSql += "        inicio_vigencia  = " + inivig + ", "
            strSql += "        termino_vigencia = " + fimvig + ", "
            strSql += "        liberado         = '" + Liberado + "'"
            strSql += "  where versao = " + Versao
            strSql += "    and " + Chr(34) + "release" + Chr(34) + " = " + Release
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from versao_sistema "
            strSql += "  where versao  = " + Versao
            strSql += "    and " + Chr(34) + "release" + Chr(34) + " = " + Release
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select descricao, inicio_vigencia, termino_vigencia, liberado "
        StrSql += "   from versao_sistema "
        StrSql += "  where versao  = " + Versao
        StrSql += "    and " + Chr(34) + "release" + Chr(34) + " = " + Release
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Liberado = dt.Rows.Item(0).Item("liberado").ToString
            If IsDBNull(dt.Rows.Item(0).Item("inicio_vigencia")) Then
                InicioVigencia = ""
            Else
                InicioVigencia = CDate(dt.Rows.Item(0).Item("inicio_vigencia")).ToString("dd/MM/yyyy")
            End If
            If IsDBNull(dt.Rows.Item(0).Item("termino_vigencia")) Then
                TerminoVigencia = ""
            Else
                TerminoVigencia = CDate(dt.Rows.Item(0).Item("termino_vigencia")).ToString("dd/MM/yyyy")
            End If
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select " + Chr(34) + "release" + Chr(34) + ", descricao, " + Chr(34) + "release" + Chr(34) + " || ' ' || descricao cf_descricao "
        strSql += "   from versao_sistema "
        strSql += "  order by " + Chr(34) + "release" + Chr(34) + " desc "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("release") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "release"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(release),0) + 1 max from versao_sistema "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
