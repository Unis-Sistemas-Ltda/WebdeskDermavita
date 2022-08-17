Public Class UCLSLA

    Private _CodSLA As String
    Private _Descricao As String
    Private _PrazoChegada As String
    Private _PrazoEncerramento As String
    Private _CodigoIntegracao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodSLA() As String
        Get
            Return _CodSLA
        End Get
        Set(ByVal value As String)
            _CodSLA = value
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

    Public Property PrazoChegada As String
        Get
            Return _PrazoChegada
        End Get
        Set(ByVal value As String)
            _PrazoChegada = value
        End Set
    End Property

    Public Property PrazoEncerramento As String
        Get
            Return _PrazoEncerramento
        End Get
        Set(ByVal value As String)
            _PrazoEncerramento = value
        End Set
    End Property

    Public Property CodigoIntegracao As String
        Get
            Return _CodigoIntegracao
        End Get
        Set(value As String)
            _CodigoIntegracao = value
        End Set
    End Property

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            PrazoChegada = IIf(String.IsNullOrEmpty(PrazoChegada), "null", PrazoChegada)
            PrazoChegada = PrazoChegada.Replace(",", ".")

            PrazoEncerramento = IIf(String.IsNullOrEmpty(PrazoEncerramento), "null", PrazoEncerramento)
            PrazoEncerramento = PrazoEncerramento.Replace(",", ".")

            strSql += " insert into sla (cod_sla, descricao, prazo_chegada, prazo_encerramento, codigo_integracao) "
            strSql += " values ( " + CodSLA + ", '" + Descricao + "', " + PrazoChegada + ", " + PrazoEncerramento + ",'" + CodigoIntegracao + "') "

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try

            PrazoChegada = IIf(String.IsNullOrEmpty(PrazoChegada), "null", PrazoChegada)
            PrazoChegada = PrazoChegada.Replace(",", ".")

            PrazoEncerramento = IIf(String.IsNullOrEmpty(PrazoEncerramento), "null", PrazoEncerramento)
            PrazoEncerramento = PrazoEncerramento.Replace(",", ".")

            strSql += " update sla set descricao = '" + Descricao + "', prazo_chegada = " + PrazoChegada + ", prazo_encerramento = " + PrazoEncerramento + ", codigo_integracao = '" + CodigoIntegracao + "'"
            strSql += "  where cod_sla = " + CodSLA

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

        StrSql += " select descricao, isnull(prazo_chegada,0) prazo_chegada, isnull(prazo_encerramento,0) prazo_encerramento, codigo_integracao "
        StrSql += "   from sla "
        StrSql += "  where cod_sla = " + CodSLA
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            PrazoChegada = CDbl(dt.Rows.Item(0).Item("prazo_chegada")).ToString("F1")
            PrazoEncerramento = CDbl(dt.Rows.Item(0).Item("prazo_encerramento")).ToString("F1")
            CodigoIntegracao = dt.Rows.Item(0).Item("codigo_integracao").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_sla, descricao"
        strSql += "   from sla "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_sla") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_sla"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodCliente As String, ByVal pCodPais As String, ByVal pCodEstado As String, ByVal pCodCidade As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_sla, descricao from sla order by cod_sla"
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_sla") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_sla"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_sla),0) + 1 max from sla "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
