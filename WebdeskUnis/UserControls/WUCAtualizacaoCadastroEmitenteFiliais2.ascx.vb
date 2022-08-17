Partial Public Class WUCAtualizacaoCadastroEmitenteFiliais2
    Inherits System.Web.UI.UserControl

    Dim ObjEmitente As UCLEmitente
    Dim ObjEndereco As UCLEndereco
    Dim nome As String
    Dim cod_emitente As String
    Dim nome_abreviado As String
    Dim tp_pessoa As String
    Dim tipo As String
    Dim transportador As String
    Dim funcionario As String
    Dim situacao As String
    Dim procedencia As String
    Dim cod_usuario_cadastramento As String
    Dim cod_usuario_alteracao As String
    Dim data_cadastramento As String
    Dim representante As String
    Dim natureza_emitente As String
    Dim numero_de_filiais As String
    Dim numero_funcionario As String
    Dim cnpj As String
    Dim rg As String = ""
    Dim preferencial As String
    Dim insc_estadual As String
    Dim insc_unicipal As String
    Dim Endereco As String
    Dim Numero As String
    Dim complemento As String
    Dim pais As String
    Dim estado As String
    Dim cidade As String
    Dim cep As String
    Dim telefone1 As String
    Dim telefone2 As String
    Dim af As String
    Dim ae As String
    Dim NumFuncMatriz As String
    Dim RespTecnico As String
    Dim CpfRespTecnico As String
    Dim CrfRespTecnico As String
    Dim EstadoCrf As String
    Dim DataExpedicao As String
    Dim OrgaoExpeditor As String
    Dim Email As String
    Dim EmailXmlNFE As String
    Dim EmailBoleto As String
    Private Lmodo As Int16
    Private LPaginaSeguinte As String
    Private LEmitente As String
    Private LCNPJ As String
    Private _TipoExibicao As String 'S-Sinamm O-Outros
    
    Public Property PaginaSeguinte() As String
        Get
            Return LPaginaSeguinte
        End Get
        Set(ByVal value As String)
            LPaginaSeguinte = value
        End Set
    End Property

    Public Property pCNPJ() As String
        Get
            Return LCNPJ
        End Get
        Set(ByVal value As String)
            LCNPJ = value
        End Set
    End Property

    Public Property pEmitente() As String
        Get
            Return LEmitente
        End Get
        Set(ByVal value As String)
            LEmitente = value
        End Set
    End Property

    Public Property Modo() As Int16
        Get
            Return Lmodo
        End Get
        Set(ByVal value As Int16)
            Lmodo = value
        End Set
    End Property

    Public Property TipoExibicao() As String
        Get
            If String.IsNullOrEmpty(_TipoExibicao) Then
                _TipoExibicao = "O"
            End If
            Return _TipoExibicao
        End Get
        Set(ByVal value As String)
            _TipoExibicao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtCep.Attributes.Add("OnKeyPress", "formatar(this,'#####-###');")
        TxtCnpj.Attributes.Add("OnKeyPress", "formatar(this,'##.###.###/####-##');")
        TxtTelefone.Attributes.Add("OnKeyPress", "formatar(this,'##-####-#####');")
        TxtTelefone2.Attributes.Add("OnKeyPress", "formatar(this,'##-####-#####');")
        TxtCpfRespTec.Attributes.Add("OnKeyPress", "formatar(this,'###.###.###-##');")

        If Not IsPostBack Then
            CarregaEstado()
            Select Case Lmodo
                Case ModoFormulario.ConsultaAlteracao
                    Buscar()
                    TxtCnpj.Enabled = True
                    BtnGravar.Enabled = True
                    HabilitaCampos(True)
                    TxtCnpj.Enabled = False
                Case ModoFormulario.Inclusao
                    TxtCnpj.Enabled = True
                    BtnGravar.Enabled = True
                    HabilitaCampos(True)

                    Dim objContato As New UCLContato
                    objContato.CodEmitente = Request.QueryString.Item("emitente")
                    objContato.Codigo = objContato.GetCodContatoPreferencial()
                    If objContato.Buscar() Then
                        TxtEmail.Text = objContato.Email
                    End If
            End Select
        End If
    End Sub

    Protected Sub RecuperaDados()
        Dim Dt As DataTable
        ObjEmitente = New UCLEmitente
        Dt = ObjEmitente.BuscaEnderecoEmitente(LEmitente, LCNPJ)

        If Dt.Rows.Count > 0 Then
            TxtCnpj.Text = LCNPJ.MascaraCNPJ
            TxtInscEstadual.Text = Dt.Rows.Item(0).Item("insc_estadual").ToString
            TxtInscMunicipal.Text = Dt.Rows.Item(0).Item("insc_municipal").ToString
            TxtEndereco.Text = Dt.Rows.Item(0).Item("endereco").ToString
            TxtNumero.Text = Dt.Rows.Item(0).Item("numero").ToString
            TxtComplemento.Text = Dt.Rows.Item(0).Item("complemento").ToString
            CarregaEstado()
            DdlEstado.Text = Dt.Rows(0)("cod_estado").ToString
            CarregaCidade()
            DdlCidade.Text = Dt.Rows(0)("cod_cidade").ToString
            TxtCep.Text = Dt.Rows(0)("cep").ToString
            TxtTelefone.Text = Dt.Rows(0)("telefone").ToString
            TxtTelefone2.Text = Dt.Rows(0)("telefone2").ToString
            TxtFuncionamento.Text = Dt.Rows(0)("autorizacao_funcionamento").ToString
            TxtEspecial.Text = Dt.Rows(0)("autorizacao_especial").ToString
            TxtNomeRespTec.Text = Dt.Rows(0)("nome_responsavel_tecnico").ToString
            TxtCpfRespTec.Text = Dt.Rows(0)("cpf_responsavel_tecnico").ToString
            TxtCrf.Text = Dt.Rows(0)("id_profissional").ToString
            TxtEmail.Text = Dt.Rows(0)("email").ToString
            TxtEmailFinanceiro.Text = Dt.Rows(0)("contato_boleto").ToString
            If Dt.Rows(0)("cod_estado_id_profissional").ToString = "" Then
                DdlEstadoCrf.Text = 0
            Else
                DdlEstadoCrf.Text = Dt.Rows(0)("cod_estado_id_profissional").ToString
            End If
            LblOrgaoExp.Text = LblOrgaoExp.Text
        Else
            LblErro.Text = "Estabelecimento inválido!"
        End If
        TxtInscEstadual.Text = TxtInscEstadual.Text.Replace("null", "").Replace(" ", "")
        TxtInscMunicipal.Text = TxtInscMunicipal.Text.Replace("null", "").Replace(" ", "")
        TxtCep.Text = TxtCep.Text.Replace("null", "").Replace(" ", "")

        Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
        If objAdesaoTEFLoja.Buscar(1, Request.QueryString.Item("emitente"), TxtCnpj.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP) Then
            TxtQtdPDV.Text = objAdesaoTEFLoja.GetConteudo("qtd_pdv")
            TxtNomeEmpresaSoftware.Text = objAdesaoTEFLoja.GetConteudo("nome_software_house")
            TxtPessoaContatoSoftware.Text = objAdesaoTEFLoja.GetConteudo("contato_software_house")
            TxtTelefoneSoftware.Text = objAdesaoTEFLoja.GetConteudo("telefone_software_house")
            TxtEmailSoftware.Text = objAdesaoTEFLoja.GetConteudo("email_software_house")
            TxtBanco.Text = objAdesaoTEFLoja.GetConteudo("banco")
            TxtAgencia.Text = objAdesaoTEFLoja.GetConteudo("agencia")
            TxtContaCorrente.Text = objAdesaoTEFLoja.GetConteudo("conta")
        End If

        If TxtEmail.Text = "" Then
            Dim objContato As New UCLContato
            objContato.CodEmitente = Request.QueryString.Item("emitente")
            objContato.Codigo = objContato.GetCodContatoPreferencial()
            If objContato.Buscar() Then
                TxtEmail.Text = objContato.Email
            End If
        End If
        
    End Sub

    Protected Sub CarregaEstado()
        Dim DtEstado As DataTable
        Dim cod_pais As Long

        cod_pais = 1
        ObjEndereco = New UCLEndereco(StrConexao)

        DtEstado = ObjEndereco.buscar_estado(cod_pais)

        Dim NovaLinha As DataRow = DtEstado.NewRow
        NovaLinha("cod_pais") = cod_pais
        NovaLinha("cod_estado") = 0
        NovaLinha("nome_estado") = "(UF)"
        NovaLinha("sigla") = "(UF)"

        DtEstado.Rows.Add(NovaLinha)

        DdlEstado.DataSource = DtEstado
        DdlEstado.DataTextField = "sigla"
        DdlEstado.DataValueField = "cod_estado"
        DdlEstado.DataBind()
        DdlEstado.SelectedValue = 0

        DdlEstadoCrf.DataSource = DtEstado
        DdlEstadoCrf.DataTextField = "sigla"
        DdlEstadoCrf.DataValueField = "cod_estado"
        DdlEstadoCrf.DataBind()
        DdlEstadoCrf.SelectedValue = 0

    End Sub

    Protected Sub CarregaCidade()
        Dim DtCidade As DataTable
        Dim CodPais As Long
        Dim CodEstado As Long

        CodPais = 1
        CodEstado = DdlEstado.SelectedValue
        ObjEndereco = New UCLEndereco(StrConexao)

        DtCidade = ObjEndereco.buscar_cidade(CodPais, CodEstado)

        Dim NovaLinha As DataRow = DtCidade.NewRow
        NovaLinha("cod_pais") = CodPais
        NovaLinha("cod_estado") = CodEstado
        NovaLinha("cod_cidade") = 0
        NovaLinha("nome_cidade") = " "
        DtCidade.Rows.Add(NovaLinha)

        DdlCidade.DataSource = DtCidade
        DdlCidade.DataTextField = "nome_cidade"
        DdlCidade.DataValueField = "cod_cidade"
        DdlCidade.DataBind()
        DdlCidade.SelectedValue = 0
    End Sub

    Protected Sub CarregaVariaveis()
        cod_emitente = Request.QueryString.Item("emitente")

        LCNPJ = TxtCnpj.Text.Replace("/", "").Replace(".", "").Replace("-", "").Replace(" ", "").Trim

        cnpj = "'" + LCNPJ + "'"
        preferencial = "''"
        insc_estadual = TxtInscEstadual.Text.ToString()
        If insc_estadual = "" Then
            insc_estadual = "null"
        Else
            If Lmodo = ModoFormulario.Inclusao Then
                insc_estadual = "'" + insc_estadual.Replace("'", "") + "'"
            End If
        End If

        insc_unicipal = TxtInscMunicipal.Text.ToString()
        If Lmodo = ModoFormulario.Inclusao Then
            insc_unicipal = "'" + insc_unicipal.Replace("'", "") + "'"
        End If

        Endereco = "'" & TxtEndereco.Text.ToString & "'"
        complemento = "'" & TxtComplemento.Text.ToString & "'"
        Numero = TxtNumero.Text
        pais = 1
        If pais = "" Then
            pais = "null"
        End If
        estado = DdlEstado.SelectedValue.ToString
        If estado = "" Then
            estado = "null"
        End If
        cidade = DdlCidade.SelectedValue.ToString
        If cidade = "" Then
            cidade = "null"
        End If
        cep = TxtCep.Text.ToString.Replace("-", "")
        If cep = "" Then
            cep = "null"
        End If
        Email = TxtEmail.Text.GetValidInputContent
        EmailXmlNFE = TxtEmailFinanceiro.Text.GetValidInputContent
        EmailBoleto = TxtEmailFinanceiro.Text.GetValidInputContent
        telefone1 = "'" & TxtTelefone.Text.ToString & "'"
        telefone2 = "'" & TxtTelefone2.Text.ToString & "'"
        af = "'" & TxtFuncionamento.Text.ToString & "'"
        ae = "'" & TxtEspecial.Text.ToString & "'"
        NumFuncMatriz = "null"
        RespTecnico = "'" & TxtNomeRespTec.Text.ToString & "'"
        CpfRespTecnico = TxtCpfRespTec.Text.ToString.Replace("-", "").Replace(".", "")
        If CpfRespTecnico = "" Then
            CpfRespTecnico = "null"
        End If
        CrfRespTecnico = "'" & TxtCrf.Text.ToString & "'"
        EstadoCrf = DdlEstadoCrf.SelectedValue.ToString
        If EstadoCrf = "" Or EstadoCrf = 0 Then
            EstadoCrf = "null"
        End If
        OrgaoExpeditor = "'" & LblOrgaoExp.Text.ToString & "'"
        If Endereco = "''" Or estado = "null" Or cidade = "null" Or cep = "null" Then
            Throw New Exception("Informe o endereço completo: Endereço, Cidade, Estado, CEP.")
        End If

        If telefone1 = "''" Then
            Throw New Exception("Informe o número do telefone principal para contato.")
        End If

    End Sub

    Protected Sub IncluirDados()
        ObjEmitente = New UCLEmitente
        Dim sequencia As Long
        sequencia = ObjEmitente.busca_sequencia_emitente()
        Try
            CarregaVariaveis()
            ObjEmitente.IncluirEnderecoEmitente(cod_emitente, preferencial, cnpj, insc_estadual, insc_unicipal, Endereco, Numero, complemento, pais, estado, cidade, cep, telefone1, telefone2, "?", af, ae, NumFuncMatriz, RespTecnico, CpfRespTecnico, CrfRespTecnico, EstadoCrf, OrgaoExpeditor, Email, EmailXmlNFE, EmailBoleto)
            LblErro.Text = "O Cadastro do estabelecimento foi inserido com sucesso. Clique no botão Finalizar no rodapé desta tela para retornar à tela anterior."
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub GravarDados()
        ObjEmitente = New UCLEmitente
        Try
            CarregaVariaveis()
            ObjEmitente.atualiza_endereco_emitente(cod_emitente, preferencial, cnpj, insc_estadual, insc_unicipal, Endereco, Numero, complemento, pais, estado, cidade, cep, telefone1, telefone2, "?", af, ae, NumFuncMatriz, RespTecnico, CpfRespTecnico, CrfRespTecnico, EstadoCrf, OrgaoExpeditor, Email, EmailXmlNFE, EmailBoleto)
            LblErro.Text = "O Cadastro do estabelecimento foi atualizado com sucesso. Clique no botão Finalizar no rodapé desta página para retornar à tela anterior."
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DdlEstado.SelectedIndexChanged
        Call CarregaCidade()
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGravar.Click
        Try
            If IsDigitacaoOk() Then
                If Lmodo = ModoFormulario.ConsultaAlteracao Then
                    Call GravarDados()
                ElseIf Lmodo = ModoFormulario.Inclusao Then
                    Call IncluirDados()
                End If
                BtnGravar.Enabled = False
                Call GravarDadosContratacao(Lmodo)
                Call Voltar()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GravarDadosContratacao(ByVal modo As ModoFormulario)
        Try
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
            Dim incluir As Boolean = False
            If Not objAdesaoTEFLoja.Buscar(1, Request.QueryString.Item("emitente"), TxtCnpj.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP) Then
                incluir = True
                Dim objEmitente As New UCLEmitente
                Dim objContato As New UCLContato
                objContato.CodEmitente = Request.QueryString.Item("emitente")
                objAdesaoTEFLoja.SetConteudo("razao_social", objEmitente.GetRazaoSocial(Request.QueryString.Item("emitente")))
                objAdesaoTEFLoja.SetConteudo("cod_contato_responsavel", objContato.GetCodContatoPreferencial())
                objAdesaoTEFLoja.SetConteudo("cod_usuario_inclusao", 1)
                objAdesaoTEFLoja.SetConteudo("cod_usuario_alteracao", 1)
            End If
            objAdesaoTEFLoja.SetConteudo("qtd_pdv", TxtQtdPDV.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("nome_software_house", TxtNomeEmpresaSoftware.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("contato_software_house", TxtPessoaContatoSoftware.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("telefone_software_house", TxtTelefoneSoftware.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("email_software_house", TxtEmailSoftware.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("banco", TxtBanco.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("agencia", TxtAgencia.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("conta", TxtContaCorrente.Text.GetValidInputContent)
            objAdesaoTEFLoja.SetConteudo("confirmado", "S")
            If incluir Then
                objAdesaoTEFLoja.Incluir()
            Else
                objAdesaoTEFLoja.Alterar()
            End If
            
            Dim objAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            If objAdesaoTEFEmitente.Buscar(1, Request.QueryString.Item("emitente")) Then
                objAdesaoTEFEmitente.SetConteudo("confirmou_lojas", "S")
                objAdesaoTEFEmitente.Alterar()
            End If

            Dim bandeiras As New List(Of String)
            Dim adquirentes As New List(Of String)
            Dim outros As New List(Of String)

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim CbxSelecionado As CheckBox
                    CbxSelecionado = row.FindControl("CbxSelecionado")

                    Dim LblCodBandeira As Label
                    LblCodBandeira = row.FindControl("LblCodBandeira")

                    Dim DdlAdquirente As DropDownList
                    DdlAdquirente = row.FindControl("DdlAdquirente")

                    Dim LblCodAdquirente As Label
                    LblCodAdquirente = row.FindControl("LblCodAdquirente")

                    Dim TxtOutros As TextBox
                    TxtOutros = row.FindControl("TxtOutros")

                    If CbxSelecionado.Checked Then
                        bandeiras.Add(LblCodBandeira.Text)
                        If LblCodAdquirente.Text = "0" Then
                            adquirentes.Add(DdlAdquirente.SelectedValue)
                        Else
                            adquirentes.Add(LblCodAdquirente.Text)
                        End If
                        outros.Add(TxtOutros.Text)
                    End If
                End If
            Next

            Dim objAdesaoTefBandeira As New UCLAdesaoTEFBandeira
            objAdesaoTefBandeira.Excluir(1, Request.QueryString.Item("emitente"), TxtCnpj.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP)

            For i As Long = 0 To bandeiras.Count - 1
                objAdesaoTefBandeira = New UCLAdesaoTEFBandeira
                If Not objAdesaoTefBandeira.Buscar(1, Request.QueryString.Item("emitente"), TxtCnpj.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP, adquirentes.Item(i), bandeiras.Item(i)) Then
                    objAdesaoTefBandeira.SetConteudo("outros", outros.Item(i).GetValidInputContent)
                    objAdesaoTefBandeira.Incluir()
                Else
                    objAdesaoTefBandeira.SetConteudo("outros", outros.Item(i).GetValidInputContent)
                    objAdesaoTefBandeira.Alterar()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Buscar()
        Try
            LCNPJ = Request.QueryString.Item("cnpj")
            RecuperaDados()
            BtnGravar.Enabled = True
            HabilitaCampos(True)
            TxtInscEstadual.Enabled = (TxtInscEstadual.Text = "")
            TxtInscMunicipal.Enabled = (TxtInscMunicipal.Text = "")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub HabilitaCampos(ByVal habilita As Boolean)
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.ID <> "TxtCNPJ" Then
                    CType(ctrl, TextBox).Enabled = habilita
                End If
            End If
        Next
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Call Voltar()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Voltar()
        Try
            Dim comando As String = "window.opener.document.getElementById('BtnAtualizar').click(); self.close();"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", comando, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function IsDigitacaoOk() As Boolean
        Try
            LblErro.Text = ""

            If Lmodo = ModoFormulario.Inclusao Then
                If String.IsNullOrEmpty(TxtCnpj.Text) Then
                    LblErro.Text += "É necessário informar o CNPJ da loja.<br>"
                ElseIf Not IsValidCNPJ(TxtCnpj.Text) Then
                    LblErro.Text += "É necessário informar corretamente o CNPJ da loja.<br>"
                End If
            End If

            If String.IsNullOrEmpty(TxtEndereco.Text) Then
                LblErro.Text += "É necessário informar o nome da rua.<br>"
            End If

            If String.IsNullOrEmpty(TxtNumero.Text) Then
                LblErro.Text += "É necessário informar o número do endereço.<br>"
            ElseIf Not IsNumeric(TxtNumero.Text) Then
                LblErro.Text += "É necessário informar corretamente o número do endereço.<br>"
            End If

            If DdlEstado.SelectedValue = "0" Then
                LblErro.Text += "É necessário selecionar o Estado.<br>"
            End If

            If DdlCidade.SelectedValue = "0" Then
                LblErro.Text += "É necessário selecionar a Cidade.<br>"
            End If

            If String.IsNullOrEmpty(TxtCep.Text) Then
                LblErro.Text += "É necessário informar o CEP.<br>"
            End If

            If String.IsNullOrEmpty(TxtTelefone.Text) Then
                LblErro.Text += "É necessário informar o telefone principal para contato.<br>"
            End If

            If String.IsNullOrEmpty(TxtEmail.Text) Then
                LblErro.Text += "É necessário informar o e-mail para contato.<br>"
            End If

            If String.IsNullOrEmpty(TxtEmailFinanceiro.Text) Then
                LblErro.Text += "É necessário informar o e-mail financeiro.<br>"
            End If

            If String.IsNullOrEmpty(TxtQtdPDV.Text) Then
                LblErro.Text += "É necessário informar a quantidade de PDVs (caixas).<br>"
            End If

            If String.IsNullOrEmpty(TxtNomeEmpresaSoftware.Text) Then
                LblErro.Text += "É necessário informar o nome da empresa fornecedora do sistema utilizado no caixa da sua loja.<br>"
            End If

            If String.IsNullOrEmpty(TxtTelefoneSoftware.Text) Then
                LblErro.Text += "É necessário informar o telefone da empresa fornecedora do sistema utilizado no caixa da sua loja.<br>"
            End If

            If String.IsNullOrEmpty(TxtBanco.Text) Then
                LblErro.Text += "Informe o banco que será utilizado para crédito dos recebíveis.<br>"
            End If

            If String.IsNullOrEmpty(TxtAgencia.Text) Then
                LblErro.Text += "Informe a agência será utilizada para crédito dos recebíveis.<br>"
            End If

            If String.IsNullOrEmpty(TxtContaCorrente.Text) Then
                LblErro.Text += "Informe a conta corrente que será utilizada para crédito dos recebíveis.<br>"
            End If

            Dim visa As Boolean = False
            Dim master As Boolean = False
            Dim descricoesBandeiras As New List(Of String)
            Dim bandeiras As New List(Of String)
            Dim adquirentes As New List(Of String)

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim CbxSelecionado As CheckBox
                    CbxSelecionado = row.FindControl("CbxSelecionado")

                    Dim LblCodBandeira As Label
                    LblCodBandeira = row.FindControl("LblCodBandeira")

                    Dim LblDescricaoBandeira As Label
                    LblDescricaoBandeira = row.FindControl("LblDescricaoBandeira")

                    Dim DdlAdquirente As DropDownList
                    DdlAdquirente = row.FindControl("DdlAdquirente")

                    Dim LblCodAdquirente As Label
                    LblCodAdquirente = row.FindControl("LblCodAdquirente")

                    If CbxSelecionado.Checked Then
                        If LblCodBandeira.Text = "1" Then
                            visa = True
                        ElseIf LblCodBandeira.Text = "2" Then
                            master = True
                        End If

                        bandeiras.Add(LblCodBandeira.Text)
                        descricoesBandeiras.Add(LblDescricaoBandeira.Text)
                        If LblCodAdquirente.Text = "0" Then
                            adquirentes.Add(DdlAdquirente.SelectedValue)
                        Else
                            adquirentes.Add(LblCodAdquirente.Text)
                        End If
                    End If
                End If
            Next

            If Not visa Then
                LblErro.Text += "É necessário selecionar a bandeira Visa.<br>"
            End If

            If Not master Then
                LblErro.Text += "É necessário selecionar a bandeira Mastercard.<br>"
            End If

            For i = 0 To bandeiras.Count - 1
                If adquirentes.Item(i) = "0" Then
                    LblErro.Text += "É necessário informar qual a adquirente desejada para a bandeira " + descricoesBandeiras.Item(i) + ".<br>"
                End If
            Next

            If LblErro.Text <> "" Then
                LblErro.Text = "ATENÇÃO:<br><br>" + LblErro.Text + "<br>"
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
