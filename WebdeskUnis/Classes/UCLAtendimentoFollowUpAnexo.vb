Public Class UCLAtendimentoFollowUpAnexo
    Private objAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _CodChamado As String
    Private _SeqFollowUP As String
    Private _SeqAnexo As String
    Private _Arquivo As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodChamado() As String
        Get
            Return _CodChamado
        End Get
        Set(ByVal value As String)
            _CodChamado = value
        End Set
    End Property

    Public Property SeqFollowUP() As String
        Get
            Return _SeqFollowUP
        End Get
        Set(ByVal value As String)
            _SeqFollowUP = value
        End Set
    End Property

    Public Property SeqAnexo() As String
        Get
            Return _SeqAnexo
        End Get
        Set(ByVal value As String)
            _SeqAnexo = value
        End Set
    End Property

    Public Property Arquivo() As String
        Get
            Return _Arquivo
        End Get
        Set(ByVal value As String)
            _Arquivo = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub New(ByVal ConnectString As String)
        objAcessoDados = New UCLAcessoDados(ConnectString)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select arquivo "
        StrSql += "  from follow_up_chamado_anexo "
        StrSql += " where empresa       = " + Empresa
        StrSql += "   and cod_chamado   = " + CodChamado
        StrSql += "   and seq_follow_up = " + SeqFollowUP
        StrSql += "   and seq_anexo     = " + SeqAnexo

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Arquivo = dt.Rows.Item(0).Item("arquivo").ToString
            Return True
        End If

        Return False
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = ""

        strSql = " select isnull(max(seq_anexo),0) + 1 max  "
        strSql += "  from follow_up_chamado_anexo "
        strSql += " where empresa       = " + Empresa
        strSql += "   and cod_chamado   = " + CodChamado
        strSql += "   and seq_follow_up = " + SeqFollowUP

        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""
        Try

            strSql = " insert into follow_up_chamado_anexo ( empresa, cod_chamado, seq_follow_up, seq_anexo, arquivo ) "
            strSql += " values ( " + Empresa + ", " + CodChamado + "," + SeqFollowUP + ", " + SeqAnexo + ", '" + Arquivo + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try

            strSql += " update follow_up_chamado_anexo "
            strSql += "    set arquivo = '" + Arquivo + "' "
            strSql += "  where empresa       = " + Empresa
            strSql += "    and cod_chamado   = " + CodChamado
            strSql += "    and seq_follow_up = " + SeqFollowUP
            strSql += "    and seq_anexo     = " + SeqAnexo

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim strSql As String = ""

            strSql += " delete from follow_up_chamado_anexo "
            strSql += "  where empresa       = " + Empresa
            strSql += "    and cod_chamado   = " + CodChamado
            strSql += "    and seq_follow_up = " + SeqFollowUP
            strSql += "    and seq_anexo     = " + SeqAnexo

            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
