Public Class UCLTabelaGenerica
    Private ObjAcessoDados As UCLAcessoDados

    Public Property NomeTabela As String
    Public Property CamposPK As List(Of UCLTabelaGenericaCampo)
    Public Property Campos As List(Of UCLTabelaGenericaCampo)

    Public Sub New(ByVal pNomeTabela As String)
        Try
            NomeTabela = pNomeTabela
            CamposPK = New List(Of UCLTabelaGenericaCampo)
            Campos = New List(Of UCLTabelaGenericaCampo)
            Call Inicializar(pNomeTabela)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        Try
            ObjAcessoDados = New UCLAcessoDados
            CamposPK = New List(Of UCLTabelaGenericaCampo)
            Campos = New List(Of UCLTabelaGenericaCampo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Inicializar(ByVal pNomeTabela As String)
        Try
            Dim StrSql As String
            Dim dt As DataTable
            Dim TipoDeDado As UCLTabelaGenericaCampo.ENTipoCampo

            ObjAcessoDados = New UCLAcessoDados

            StrSql = ""
            StrSql += " select c.column_name, c.domain_id, c.pkey, d.domain_name, t.table_id"
            StrSql += "   from syscolumn c inner join sysdomain d on c.domain_id = d.domain_id"
            StrSql += "                    inner join systable t on t.table_id = c.table_id"
            StrSql += "  where t.table_name = '" + pNomeTabela + "'"
            dt = ObjAcessoDados.BuscarDados(StrSql)

            For Each row As DataRow In dt.Rows

                Select Case row.Item("domain_name").ToString
                    Case "smallint", "integer", "unsigned integer", "unsigned int", "unsigned smallint", "unsigned bigint"
                        TipoDeDado = UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                    Case "numeric", "float", "double", "decimal"
                        TipoDeDado = UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                    Case "date", "timestamp"
                        TipoDeDado = UCLTabelaGenericaCampo.ENTipoCampo.Data
                    Case "char", "varchar", "long varchar"
                        TipoDeDado = UCLTabelaGenericaCampo.ENTipoCampo.Texto
                    Case Else
                        TipoDeDado = UCLTabelaGenericaCampo.ENTipoCampo.Texto
                End Select

                If row.Item("pkey") = "Y" Then
                    CamposPK.Add(New UCLTabelaGenericaCampo(row.Item("column_name").ToString, TipoDeDado))
                End If
                Campos.Add(New UCLTabelaGenericaCampo(row.Item("column_name").ToString, TipoDeDado))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String
            Dim campo As UCLTabelaGenericaCampo

            If Campos.Count = 0 Then
                Throw New Exception("Lista de campos não atribuída")
            End If

            StrSql = " insert into " + NomeTabela + " ("

            For i As Long = 0 To Campos.Count - 1
                campo = Campos.Item(i)
                StrSql += campo.NomeCampo
                If i < Campos.Count - 1 Then
                    StrSql += ", "
                End If
            Next

            StrSql += ") values ("
            For i As Long = 0 To Campos.Count - 1
                campo = Campos.Item(i)

                If Not campo.IsNull Then
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                            StrSql += "'"
                    End Select
                End If

                If campo.IsNull OrElse (String.IsNullOrWhiteSpace(campo.Conteudo) AndAlso campo.Tipo <> UCLTabelaGenericaCampo.ENTipoCampo.Texto) Then
                    StrSql += "null"
                Else
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data, UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                            StrSql += campo.Conteudo.Replace("'", "\'")
                        Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                            StrSql += campo.Conteudo.Replace(".", "").Replace(",", ".").Replace("'", "\'")
                    End Select
                End If

                If Not campo.IsNull Then
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                            StrSql += "'"
                    End Select
                End If

                If i < Campos.Count - 1 Then
                    StrSql += ", "
                End If
            Next
            StrSql += ")"

            ObjAcessoDados.ExecutarSql("call sp_sysvar(); " + StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            Dim campo As UCLTabelaGenericaCampo

            If Campos.Count = 0 Then
                Throw New Exception("Lista de campos não atribuída")
            End If

            If CamposPK.Count = 0 Then
                Throw New Exception("Lista de campos PK não atribuída")
            End If

            StrSql = " update " + NomeTabela + " set "

            For i As Long = 0 To Campos.Count - 1
                campo = Campos.Item(i)

                StrSql += campo.NomeCampo + " = "

                If Not campo.IsNull Then
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                            StrSql += "'"
                    End Select
                End If

                If campo.IsNull OrElse (String.IsNullOrWhiteSpace(campo.Conteudo) AndAlso campo.Tipo <> UCLTabelaGenericaCampo.ENTipoCampo.Texto) Then
                    StrSql += "null"
                Else
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data, UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                            StrSql += campo.Conteudo.Replace("'", "\'")
                        Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                            StrSql += campo.Conteudo.Replace(".", "").Replace(",", ".").Replace("'", "\'")
                    End Select
                End If

                If Not campo.IsNull Then
                    Select Case campo.Tipo
                        Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                            StrSql += "'"
                    End Select
                End If

                If i < Campos.Count - 1 Then
                    StrSql += ", "
                End If
            Next

            StrSql += " where "

            For i As Long = 0 To CamposPK.Count - 1
                campo = CamposPK.Item(i)

                StrSql += campo.NomeCampo + " = "

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro, UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        If String.IsNullOrWhiteSpace(campo.Conteudo) Then
                            Throw New Exception("Conteúdo do campo [" + campo.NomeCampo + "] não informado. Não é possível atualizar o registro.")
                        End If
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data, UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                        StrSql += campo.Conteudo.Replace("'", "\'")
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        StrSql += campo.Conteudo.Replace(".", "").Replace(",", ".").Replace("'", "\'")
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                If i < CamposPK.Count - 1 Then
                    StrSql += " and "
                End If
            Next

            ObjAcessoDados.ExecutarSql("call sp_sysvar(); " + StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            Dim campo As UCLTabelaGenericaCampo

            If CamposPK.Count = 0 Then
                Throw New Exception("Lista de campos PK não atribuída")
            End If

            StrSql = " delete from " + NomeTabela
            StrSql += " where "

            For i As Long = 0 To CamposPK.Count - 1
                campo = CamposPK.Item(i)

                StrSql += campo.NomeCampo + " = "

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro, UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        If String.IsNullOrWhiteSpace(campo.Conteudo) Then
                            Throw New Exception("Conteúdo do campo [" + campo.NomeCampo + "] não informado. Não é possível excluir o registro.")
                        End If
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data, UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                        StrSql += campo.Conteudo.Replace("'", "\'")
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        StrSql += campo.Conteudo.Replace(".", "").Replace(",", ".").Replace("'", "\'")
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                If i < CamposPK.Count - 1 Then
                    StrSql += " and "
                End If
            Next

            ObjAcessoDados.ExecutarSql("call sp_sysvar(); " + StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim campo As UCLTabelaGenericaCampo
            Dim dt As DataTable

            If Campos.Count = 0 Then
                Throw New Exception("Lista de campos não atribuída")
            End If

            If CamposPK.Count = 0 Then
                Throw New Exception("Lista de campos PK não atribuída")
            End If

            StrSql = " select * from " + NomeTabela
            StrSql += " where "

            For i As Long = 0 To CamposPK.Count - 1
                campo = CamposPK.Item(i)

                StrSql += campo.NomeCampo + " = "

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro, UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        If String.IsNullOrWhiteSpace(campo.Conteudo) Then
                            Throw New Exception("Conteúdo do campo [" + campo.NomeCampo + "] não informado. Não é possível realizar a busca.")
                        End If
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data, UCLTabelaGenericaCampo.ENTipoCampo.NumeroInteiro
                        StrSql += campo.Conteudo.Replace("'", "\'")
                    Case UCLTabelaGenericaCampo.ENTipoCampo.NumeroDecimal
                        StrSql += campo.Conteudo.Replace(".", "").Replace(",", ".").Replace("'", "\'")
                End Select

                Select Case campo.Tipo
                    Case UCLTabelaGenericaCampo.ENTipoCampo.Texto, UCLTabelaGenericaCampo.ENTipoCampo.Data
                        StrSql += "'"
                End Select

                If i < CamposPK.Count - 1 Then
                    StrSql += " and "
                End If
            Next

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                For i As Long = 0 To Campos.Count - 1
                    campo = Campos.Item(i)
                    If IsDBNull(dt.Rows.Item(0).Item(campo.NomeCampo)) Then
                        campo.IsNull = True
                        campo.Conteudo = ""
                    Else
                        If campo.Tipo = UCLTabelaGenericaCampo.ENTipoCampo.Data Then
                            campo.Conteudo = CType(dt.Rows.Item(0).Item(campo.NomeCampo), DateTime).ToString("yyyy-MM-dd HH:mm:ss.fff")
                        Else
                            campo.Conteudo = dt.Rows.Item(0).Item(campo.NomeCampo).ToString
                        End If
                        campo.IsNull = False
                    End If
                Next
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class