Public Class UCLAcaoFollowUp
    Private objAcessoDados As UCLAcessoDados
    Private _CodAcao As String
    Private _Descricao As String
    Private _EnviaEmail As String

    Public Property CodAcao() As String
        Get
            Return _CodAcao
        End Get
        Set(ByVal value As String)
            _CodAcao = value
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

    Public Property EnviaEmail() As String
        Get
            Return _EnviaEmail
        End Get
        Set(ByVal value As String)
            _EnviaEmail = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Buscar()
        Dim strSql As String = " select descricao, envia_email from acao_follow_up where cod_acao = " + CodAcao
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            EnviaEmail = dt.Rows.Item(0).Item("envia_email").ToString
        End If
    End Sub

    Public Sub Incluir()
        Dim strSql As String = " insert into acao_follow_up(cod_acao, descricao, envia_email) values (" + CodAcao + ", '" + Descricao + "', '" + EnviaEmail + "')"

        Try
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update acao_follow_up set descricao = '" + Descricao + "', envia_email = '" + EnviaEmail + "' where cod_acao = " + CodAcao
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_acao),0) + 1 max from acao_follow_up "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_acao, descricao "
        strSql += "   from acao_follow_up"
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_acao") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_acao"
        DDL.DataBind()
    End Sub

    Public Function GetEnviaEmail(ByVal _CodAcao As String) As String
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim ret As String = "N"

        strSql += " select isnull(envia_email,'N') envia_email "
        strSql += "   from acao_follow_up "
        strSql += "  where cod_acao = " + _CodAcao

        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("envia_email").ToString
        End If

        Return ret

    End Function

End Class
