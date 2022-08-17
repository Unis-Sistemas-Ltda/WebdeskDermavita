Public Class UCLItemReferencia
    Private ObjAcessoDados As UCLAcessoDados
    Public Property CodItem As String = ""
    Public Property Referencia As String = ""

    Public Sub New(ByVal StrC As String)
        ObjAcessoDados = New UCLAcessoDados(StrC)
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim NovaLinha As DataRow

        strSql += " select ir.cod_referencia, r.descricao "
        strSql += "   from item_referencia ir inner join referencia r on ir.cod_referencia = r.cod_referencia "
        strSql += "  where ir.cod_item = '" + CodItem + "'"
        If Referencia.Trim <> "" Then
            strSql += " and ir.cod_referencia <> '" + Referencia + "'"
        End If
        strSql += "  order by r.cod_cor, r.cod_tamanho, r.descricao "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If Referencia.Trim <> "" Then
            NovaLinha = dt.NewRow
            NovaLinha("cod_referencia") = Referencia
            NovaLinha("descricao") = Referencia
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        If AdicionarRegistroEmBranco Then
            NovaLinha = dt.NewRow
            NovaLinha("cod_referencia") = ""
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_referencia"
        DDL.DataBind()
    End Sub

End Class

