Public Class UCLAcessoDados

    Dim conn As New Odbc.OdbcConnection

    Public Sub New()
        conn.ConnectionString = StrConexao
    End Sub

    Public Sub New(ByVal strConexao As String)
        conn.ConnectionString = strConexao
    End Sub

    Public Function BuscarDados(ByVal StrSql As String) As DataTable
        Dim dt As New DataTable
        Dim da As New Odbc.OdbcDataAdapter(StrSql, conn)

        'O metodo fill se encarrega automaticamente de abrir a conexão, preencher o dataset e fechar a conexão.
        da.Fill(dt)
        Return dt
    End Function

    Public Function BuscarDadosComTransacao(ByVal strSql As String) As String
        Dim sqlConnection1 As New System.Data.Odbc.OdbcConnection
        Dim Trans As System.Data.Odbc.OdbcTransaction
        Dim strRetVal As String
        Dim sqlDataReader1 As System.Data.Odbc.OdbcDataReader
        Dim sqlCommand1 As New System.Data.Odbc.OdbcCommand
        Try
            sqlConnection1.ConnectionString = strConexao
            sqlConnection1.Open()

            '*** Start Transaction ***'  
            Trans = sqlConnection1.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Create a command object to call Function1.

            sqlCommand1.CommandText = strSql
            sqlCommand1.CommandType = CommandType.Text
            sqlCommand1.Connection = sqlConnection1
            sqlCommand1.Transaction = Trans

            ' Call Function1.
            sqlDataReader1 = sqlCommand1.ExecuteReader
            sqlDataReader1.Read()

            If sqlDataReader1.HasRows Then
                If Not IsDBNull(sqlDataReader1.Item(0)) Then
                    strRetVal = sqlDataReader1.Item(0)
                Else
                    strRetVal = ""
                End If
            Else
                strRetVal = ""
            End If

            If Not String.IsNullOrEmpty(strRetVal) Then
                Throw New Exception(strRetVal)
            Else
                Trans.Commit()  '*** Commit Transaction ***'  
                sqlDataReader1.Close()
            End If

        Catch ex As Exception
            Trans.Rollback() '*** RollBack Transaction ***'  
            Throw ex
        End Try

        Return strRetVal

    End Function

    Public Sub ExecutarSql(ByVal StrSql As String)
        Try
            Dim cmd As New Odbc.OdbcCommand(StrSql, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'Descarrega o erro para a função superior
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub ExecutarSqlComTransacao(ByVal strSql As String)

        Dim objConn As System.Data.Odbc.OdbcConnection
        Dim objCmd As System.Data.Odbc.OdbcCommand
        Dim Trans As System.Data.Odbc.OdbcTransaction

        objConn = New System.Data.Odbc.OdbcConnection(StrConexao)
        objConn.Open()

        '*** Start Transaction ***'  
        Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted)

        Try

            '*** Query 1 ***'  
            objCmd = New System.Data.Odbc.OdbcCommand()
            With objCmd
                .Connection = objConn
                .Transaction = Trans
                .CommandType = CommandType.Text
                .CommandText = strSql
            End With
            objCmd.ExecuteNonQuery()

            Trans.Commit()  '*** Commit Transaction ***'  

        Catch ex As Exception
            Trans.Rollback() '*** RollBack Transaction ***'  
            Throw ex
        End Try

        objCmd = Nothing
        objConn.Close()
        objConn = Nothing

    End Sub

End Class
