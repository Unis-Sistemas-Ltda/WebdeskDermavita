Public Class UCLAtendimentoFollowUp
    Private objAcessoDados As UCLAcessoDados
    Private _Empresa As String
    Private _CodChamado As String
    Private _SeqFollowUP As String
    Private _CodUsuario As String
    Private _Descricao As String
    Private _DataFollowUp As String
    Private _DDataFollowUp As Date
    Private _HoraFollowUp As String
    Private _Email As String
    Private _DataEmail As String
    Private _DDataEmail As Date
    Private _HoraEmail As String
    Private _Tipo As String

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

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property DataFollowUp() As String
        Get
            Return _DataFollowUp
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataFollowUp = CDate(value)
            End If
            _DataFollowUp = value
        End Set
    End Property

    Public Property DDataFollowUp() As Date
        Get
            Return _DDataFollowUp
        End Get
        Set(ByVal value As Date)
            _DDataFollowUp = value
        End Set
    End Property

    Public Property HoraFollowUp() As String
        Get
            Return _HoraFollowUp
        End Get
        Set(ByVal value As String)
            _HoraFollowUp = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) AndAlso (value = "S" OrElse value = "N") Then
                _Email = value
            Else
                _Email = "N"
            End If
        End Set
    End Property

    Public Property DataEmail() As String
        Get
            Return _DataEmail
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEmail = CDate(value)
            End If
            _DataEmail = value
        End Set
    End Property

    Public Property DDataEmail() As Date
        Get
            Return _DDataEmail
        End Get
        Set(ByVal value As Date)
            _DDataEmail = value
        End Set
    End Property

    Public Property HoraEmail() As String
        Get
            Return _HoraEmail
        End Get
        Set(ByVal value As String)
            _HoraEmail = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao())
    End Sub

    Public Sub New(ByVal ConnectString As String)
        objAcessoDados = New UCLAcessoDados(ConnectString)
    End Sub

    Public Function Buscar() As DataTable
        Dim StrSql As String
        Dim dt As DataTable

        StrSql = " select * "
        StrSql += "  from follow_up_chamado "
        StrSql += " where empresa       = " + Empresa
        StrSql += "   and cod_chamado   = " + CodChamado
        StrSql += "   and seq_follow_up = " + SeqFollowUP

        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
            If IsDBNull(dt.Rows.Item(0).Item("data_follow_up")) Then
                DataFollowUp = ""
                HoraFollowUp = ""
            Else
                DataFollowUp = CType(dt.Rows.Item(0).Item("data_follow_up"), Date).ToString("dd/MM/yyyy")
                HoraFollowUp = CType(dt.Rows.Item(0).Item("data_follow_up"), DateTime).ToString("HH:mm")
            End If
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            If IsDBNull(dt.Rows.Item(0).Item("data_email")) Then
                DataEmail = ""
                HoraEmail = ""
            Else
                DataEmail = CType(dt.Rows.Item(0).Item("data_email"), Date).ToString("dd/MM/yyyy")
                HoraEmail = CType(dt.Rows.Item(0).Item("data_email"), DateTime).ToString("HH:mm")
            End If
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
        End If

        Return dt
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = ""

        strSql = " select isnull(max(seq_follow_up),0) + 1 max  "
        strSql += "  from follow_up_chamado"
        strSql += " where empresa     = " + Empresa
        strSql += "   and cod_chamado = " + CodChamado

        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""
        Dim dbDataFollowUp As String
        Dim dbDataEmail As String
        Try

            If DDataFollowUp = Nothing Then
                dbDataFollowUp = "null"
            Else
                dbDataFollowUp = DDataFollowUp.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraFollowUp) Then
                    dbDataFollowUp += " " + HoraFollowUp + ":00"
                End If
                dbDataFollowUp = "'" + dbDataFollowUp + "'"
            End If

            If DDataEmail = Nothing Then
                dbDataEmail = "null"
            Else
                dbDataEmail = DDataEmail.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEmail) Then
                    dbDataEmail += " " + HoraEmail + ":00"
                End If
                dbDataEmail = "'" + dbDataEmail + "'"
            End If

            strSql = " insert into follow_up_chamado (empresa, cod_chamado, seq_follow_up, cod_usuario, data_follow_up, descricao, email, data_email, tipo) "
            strSql += " values ( " + Empresa + ", " + CodChamado + "," + SeqFollowUP + ", " + CodUsuario + ", " + dbDataFollowUp + ", '" + Descricao + "', '" + Email + "', " + dbDataEmail + ", '" + Tipo + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Dim dbDataFollowUp As String
        Dim dbDataEmail As String
        Try

            If DDataFollowUp = Nothing Then
                dbDataFollowUp = "null"
            Else
                dbDataFollowUp = DDataFollowUp.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraFollowUp) Then
                    dbDataFollowUp += " " + HoraFollowUp + ":00"
                End If
                dbDataFollowUp = "'" + dbDataFollowUp + "'"
            End If

            If DDataEmail = Nothing Then
                dbDataEmail = "null"
            Else
                dbDataEmail = DDataEmail.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(HoraEmail) Then
                    dbDataEmail += " " + HoraEmail + ":00"
                End If
                dbDataEmail = "'" + dbDataEmail + "'"
            End If

            strSql += " update follow_up_chamado "
            strSql += "    set data_follow_up = " + dbDataFollowUp + ", "
            strSql += "        descricao = '" + Descricao + "', "
            strSql += "        email = '" + Email + "', "
            strSql += "        data_email = " + dbDataEmail + ", "
            strSql += "        tipo = '" + Tipo + "'"
            strSql += "  where empresa = " + Empresa
            strSql += "    and cod_chamado = " + CodChamado
            strSql += "    and seq_follow_up = " + SeqFollowUP

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function EnviaEmailFollowUP() As String
        Try
            Dim strSql As String = "select f_email_chamado_follow_up( " + Empresa + ", " + CodChamado + ", " + SeqFollowUP + " ) as ret from dummy"
            Dim retorno As String = objAcessoDados.BuscarDadosComTransacao(strSql)
            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class