Public Class WUCAtualizacaoCadastroEmitente
    Inherits System.Web.UI.UserControl

    Public Property P_CodEmitente As String
    Public Property P_CNPJ As String

    Dim ObjEmitente As UCLEmitente
    Dim ObjEndereco As UCLEndereco
    Dim nome As String
    Dim cod_emitente As String
    Dim nome_abreviado As String
    Dim tp_pessoa As String
    Dim tipo As String
    Dim transportador As String
    Dim funcionario As String
    Dim qtde_funcionarios As String
    Dim situacao As String
    Dim procedencia As String
    Dim cod_usuario_cadastramento As String
    Dim cod_usuario_alteracao As String
    Dim data_cadastramento As String
    Dim representante As String
    Dim natureza_emitente As String
    Dim cnpj As String
    Dim rg As String = ""
    Dim preferencial As String
    Dim insc_estadual As String
    Dim insc_unicipal As String
    Dim Endereco As String
    Dim Numero As String
    Dim pais As String
    Dim estado As String
    Dim cidade As String
    Dim cep As String
    Dim telefone1 As String
    Dim telefone2 As String
    Dim fax As String
    Dim af As String
    Dim ae As String
    Dim NumFuncMatriz As String
    Dim RespTecnico As String
    Dim CpfRespTecnico As String
    Dim CrfRespTecnico As String
    Dim EstadoCrf As String
    Dim DataExpedicao As String
    Dim OrgaoExpeditor As String
    Dim Email As String = ""
    Dim EmailXmlNfe As String = ""
    Dim EmailBoleto As String = ""
    Dim regional As String
    Dim classificacao As String
    Dim socioABFH As String
    Private Lmodo As Int16
    Private LPaginaSeguinte As String
    Private LTipoExibicao As String 'C-Compacta E-Estendida S-Sinamm

    Public Property TipoExibicao() As String
        Get
            If LTipoExibicao = Nothing Then
                LTipoExibicao = "E"
            End If
            Return LTipoExibicao
        End Get
        Set(ByVal value As String)
            LTipoExibicao = value
        End Set
    End Property

    Public Property PaginaSeguinte() As String
        Get
            Return LPaginaSeguinte
        End Get
        Set(ByVal value As String)
            LPaginaSeguinte = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BtnGravar.Text = "Gravar"
            TxtCodEmitente.Enabled = False
            AddHandler BtnGravar.Click, AddressOf GravarDados
            If TxtCodEmitente.Text = "" Then
                CarregarRegionais()
                RecuperaDados()
            End If
        End If
    End Sub

    Protected Sub RecuperaDados()
        Dim Dt As DataTable
        Dim regional As Long
        ObjEmitente = New UCLEmitente()

        If TipoExibicao = "C" Then
            Dt = ObjEmitente.BuscarPorCNPJ(P_CNPJ)
        Else
            Dt = ObjEmitente.BuscarEmitente(CLng(P_CodEmitente))
        End If

        TxtCodEmitente.Text = Dt.Rows(0)("cod_emitente").ToString
        TxtNome.Text = Dt.Rows(0)("nome").ToString
        TxtNomefantasia.Text = Dt.Rows(0)("nome_abreviado").ToString
        DdlTpPessoa.Text = Dt.Rows(0)("tp_pessoa").ToString
        TxtEmail.Text = Dt.Rows(0)("email").ToString

        If TipoExibicao = "C" Or TipoExibicao = "S" Then
            TxtQtdFuncionarios.Visible = False
            ddlClassificacao.Visible = False
            rblSocioABFH.Visible = False
            DdlRegional.Visible = False
            LblEmail0.Visible = False
            Label5.Visible = False
        Else
            TxtQtdFuncionarios.Text = Dt.Rows(0).Item("numero_funcionario").ToString
            ddlClassificacao.SelectedValue = Dt.Rows.Item(0).Item("farmacia_classificacao").ToString
            rblSocioABFH.SelectedValue = Dt.Rows.Item(0).Item("socio_abfh").ToString

            regional = 0
            If regional > 0 Then
                DdlRegional.SelectedValue = regional.ToString
            End If
        End If

    End Sub

    Protected Sub CarregarRegionais()
        'Carrega dropdown laboratorios
        Dim DtDados As DataTable
        Dim objEstabelecimento As New UCLEstabelecimento()

        If DdlRegional.Items.Count = 0 Then
            DtDados = objEstabelecimento.buscarRegionais
            Dim NovaLinha As DataRow = DtDados.NewRow
            NovaLinha("estabelecimento") = 0
            NovaLinha("nome_abreviado") = " "
            DtDados.Rows.Add(NovaLinha)

            DdlRegional.DataSource = DtDados
            DdlRegional.DataTextField = "nome_abreviado"
            DdlRegional.DataValueField = "estabelecimento"
            DdlRegional.SelectedValue = 0
            DdlRegional.DataBind()
        End If
    End Sub

    Protected Sub CarregaVariaveis()

        Session("GlRegionalContrato") = DdlRegional.SelectedValue
        cod_emitente = TxtCodEmitente.Text
        nome = "'" & TxtNome.Text & "'"
        nome_abreviado = "'" & TxtNomefantasia.Text & "'"
        tp_pessoa = "'" & DdlTpPessoa.SelectedValue.ToString & "'"
        tipo = "2"
        transportador = "'N'"
        funcionario = "'N'"
        situacao = 1
        procedencia = "'N'"
        cod_usuario_cadastramento = "1"
        cod_usuario_alteracao = "1"
        data_cadastramento = "'" & Today().Year.ToString & "/" & Today().Month.ToString & "/" & Today().Day.ToString & "'"
        representante = "'N'"
        natureza_emitente = "2"
        Email = TxtEmail.Text.ToString()
        qtde_funcionarios = TxtQtdFuncionarios.Text
        classificacao = ddlClassificacao.SelectedValue
        socioABFH = "'" & rblSocioABFH.SelectedValue.ToString & "'"

        If ddlClassificacao.Visible And classificacao.Trim = "" Then
            Throw New Exception("Informe a classificação.")
        End If

        If rblSocioABFH.Visible And socioABFH = "''" Then
            Throw New Exception("Informe se é sócio da ABFH.")
        End If

        If Not Email.IsValidEmail Then
            Throw New Exception("Preencha corretamente o email principal.")
        End If

        If TxtQtdFuncionarios.Visible Then
            If (TxtQtdFuncionarios.Text.Trim = "" Or Not IsNumeric(TxtQtdFuncionarios.Text)) Then
                Throw New Exception("Preencha corretamente a quantidade de funcionários conforme GFIP.")
            Else
                If TxtQtdFuncionarios.Text <= 0 Then
                    Throw New Exception("Preencha corretamente a quantidade de funcionários conforme GFIP.")
                End If
            End If
        End If

    End Sub

    Protected Sub IncluirDados(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ObjEmitente = New UCLEmitente()
        Dim sequencia As Long
        sequencia = ObjEmitente.busca_sequencia_emitente()
        TxtCodEmitente.Text = sequencia.ToString
        Call CarregaVariaveis()
        Try
            ObjEmitente.IncluirEmitente(cod_emitente, nome, nome_abreviado, tp_pessoa, tipo, transportador, funcionario, situacao, procedencia, cod_usuario_cadastramento, cod_usuario_alteracao, data_cadastramento, representante, natureza_emitente, 0, qtde_funcionarios, rg, classificacao, socioABFH)
            'ObjEmitente.IncluirEnderecoEmitente(cod_emitente, nome, nome_abreviado, preferencial, P_CNPJ, insc_estadual, insc_unicipal, Endereco, pais, estado, cidade, cep, telefone1, telefone2, fax, af, ae, NumFuncMatriz, RespTecnico, CpfRespTecnico, CrfRespTecnico, EstadoCrf, OrgaoExpeditor, Email)
            LblErro.Text = "Seu cadastro foi efetuado com sucesso ! Retorne a pagina inicial e faça o seu login !"
            BtnGravar.Enabled = False
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString()
        End Try

    End Sub

    Protected Sub GravarDados(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ObjEmitente = New UCLEmitente()
        Try
            CarregaVariaveis()
            ObjEmitente.AtualizaEmitente(cod_emitente, nome, nome_abreviado, tp_pessoa, 0, qtde_funcionarios, rg, classificacao, socioABFH)
            ObjEmitente.atualiza_contato_emitente(cod_emitente, Email)
            LblErro.Text = "Os dados foram atualizados."
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString()
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click

    End Sub

End Class