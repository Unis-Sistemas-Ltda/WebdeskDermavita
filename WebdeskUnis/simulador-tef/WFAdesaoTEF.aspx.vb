Public Class WFAdesaoTEF
    Inherits System.Web.UI.Page

    Public ReadOnly Property Prop_CodEmitente As String
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmitente As New UCLEmitente
            Dim cnpjPrincipal As String = objEmitente.GetCNPJ(Prop_CodEmitente, UCLEmitente.TipoCNPJ.Preferencial)
            If Not IsPostBack Then
                Call IniciaAdesao()
                Call CarregaTela(TipoChamadaCarregamentoTela.PageLoad, IsPostBack)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub IniciaAdesao()
        Try
            Dim objAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            Dim ObjContato As New UCLContato
            Dim ObjEmitente As New UCLEmitente
            Dim nome_contato As String = ""
            Dim telefone1_contato As String = ""
            Dim telefone2_contato As String = ""
            Dim email_contato As String = ""

            If Not objAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente) Then
                ObjContato.CodEmitente = Prop_CodEmitente
                ObjContato.Codigo = ObjContato.GetCodContatoPreferencial()
                If Not String.IsNullOrWhiteSpace(ObjContato.Codigo) AndAlso IsNumeric(ObjContato.Codigo) AndAlso ObjContato.Codigo > 0 AndAlso Not String.IsNullOrWhiteSpace(ObjContato.CodEmitente) Then
                    If ObjContato.Buscar() Then
                        nome_contato = ObjContato.Nome
                        email_contato = ObjContato.Email
                    End If
                    telefone1_contato = ObjEmitente.GetTelefone(Prop_CodEmitente)
                    telefone2_contato = ObjEmitente.GetTelefone2(Prop_CodEmitente)
                End If

                objAdesaoTEFEmitente.SetConteudo("cod_emitente", Prop_CodEmitente)
                objAdesaoTEFEmitente.SetConteudo("cadastro_conferido", "N")
                objAdesaoTEFEmitente.SetConteudo("nome_contato", nome_contato)
                objAdesaoTEFEmitente.SetConteudo("telefone1_contato", telefone1_contato)
                objAdesaoTEFEmitente.SetConteudo("telefone2_contato", telefone2_contato)
                objAdesaoTEFEmitente.SetConteudo("email_contato", email_contato)
                objAdesaoTEFEmitente.SetConteudo("aceito", "N")
                objAdesaoTEFEmitente.SetConteudo("ip_aceite", "")
                objAdesaoTEFEmitente.SetConteudo("confirmou_lojas", "N")
                objAdesaoTEFEmitente.SetConteudo("confirmou_contato", "N")
                objAdesaoTEFEmitente.SetConteudo("nome_responsavel", nome_contato)
                objAdesaoTEFEmitente.Incluir()

                objAdesaoTEFEmitente.InsereCNPJsQueAindaNaoForamInseridos(1, Prop_CodEmitente)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum TipoChamadaCarregamentoTela As Integer
        PageLoad = 1
        'CbxAceito = 2
        BtnConfirmarDadosContato = 3
        'BtnConfirmarLojas = 3
        BtnAdesao = 4
    End Enum

    Private Sub CarregaTela(ByVal pChamada As TipoChamadaCarregamentoTela, ByVal pIsPostBack As Boolean)
        Try
            Dim objAdesaoTEFEmitente As New UCLAdesaoTEFEmitente

            If objAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente) Then
                If objAdesaoTEFEmitente.GetConteudo("aceito") = "S" Then
                    LblSitEtapa1.Text = "Concluída"
                    ColoreStatus(LblSitEtapa1, StatusAndamento.Concluida)
                    LblSitEtapa2.Text = "Concluída"
                    ColoreStatus(LblSitEtapa2, StatusAndamento.Concluida)
                    LblSitEtapa3.Text = "Concluída"
                    ColoreStatus(LblSitEtapa3, StatusAndamento.Concluida)
                    CarregaDadosContato(False)
                    BtnIncluir.Enabled = False
                    GridView1.Enabled = False
                    BtnConfirmarDadosContato.Visible = False
                    BtnAdesao.Enabled = False
                    LblMensagemValidacaoAdesao.Text = "Sua adesão ao Convênio TEF foi registrada com sucesso em " + CType(objAdesaoTEFEmitente.GetConteudo("data_aceite"), DateTime).ToString("dd/MM/yyyy HH:mm:ss") + "."
                    If pChamada = TipoChamadaCarregamentoTela.BtnAdesao Then
                        LblMensagemValidacaoAdesao.Text += "<br>Em instantes, você receberá um e-mail contendo um link de confirmação.<br>Por gentileza clique no respectivo link recebido para registrarmos a confirmação da sua adesão."
                    End If
                Else
                    If objAdesaoTEFEmitente.GetConteudo("confirmou_contato") = "S" Then
                        LblSitEtapa1.Text = "Concluída"
                        ColoreStatus(LblSitEtapa1, StatusAndamento.Concluida)
                    Else
                        LblSitEtapa1.Text = "Pendente"
                        ColoreStatus(LblSitEtapa1, StatusAndamento.Pendente)
                    End If
                    If (pChamada = TipoChamadaCarregamentoTela.PageLoad And Not pIsPostBack) OrElse ((pChamada = TipoChamadaCarregamentoTela.BtnConfirmarDadosContato)) Then
                        CarregaDadosContato(True)
                    End If
                    If objAdesaoTEFEmitente.GetConteudo("confirmou_lojas") = "S" Then
                        LblSitEtapa2.Text = "Concluída"
                        ColoreStatus(LblSitEtapa2, StatusAndamento.Concluida)
                    Else
                        LblSitEtapa2.Text = "Pendente"
                        ColoreStatus(LblSitEtapa2, StatusAndamento.Pendente)
                    End If
                    If (pChamada = TipoChamadaCarregamentoTela.PageLoad And Not pIsPostBack) Then
                        GridView1.DataBind()
                    End If
                    LblSitEtapa3.Text = "Pendente"
                    ColoreStatus(LblSitEtapa3, StatusAndamento.Pendente)
                End If
            Else
                CarregaDadosContato(True)
                LblSitEtapa1.Text = "Pendente"
                ColoreStatus(LblSitEtapa1, StatusAndamento.Pendente)
                LblSitEtapa1.Text = "Pendente"
                ColoreStatus(LblSitEtapa1, StatusAndamento.Pendente)
                LblSitEtapa2.Text = "Pendente"
                ColoreStatus(LblSitEtapa2, StatusAndamento.Pendente)
                LblSitEtapa3.Text = "Pendente"
                ColoreStatus(LblSitEtapa3, StatusAndamento.Pendente)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Enum StatusAndamento
        Concluida = 1
        Pendente = 2
    End Enum

    Protected Sub ColoreStatus(ByRef Lbl As Label, sts As StatusAndamento)
        If sts = StatusAndamento.Concluida Then
            Lbl.ForeColor = Drawing.Color.DarkGreen
            Lbl.BackColor = Drawing.Color.LightGreen
            Lbl.BorderColor = Drawing.Color.DarkGreen
            Lbl.ToolTip = "Esta etapa já está concluída."
        ElseIf sts = StatusAndamento.Pendente Then
            Lbl.ForeColor = Drawing.Color.DarkRed
            Lbl.BackColor = Drawing.Color.LightYellow
            Lbl.BorderColor = Drawing.Color.DarkRed
            Lbl.ToolTip = "Esta etapa ainda está pendente."
        End If
        Lbl.Text = "  " + Lbl.Text.Trim.Replace(" ", "") + "  "
    End Sub

    Protected Sub CarregaDadosContato(ByVal pEnabled As Boolean)
        Try
            Dim ObjAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            Dim ObjEmitente As New UCLEmitente()
            LblNomeFarmacia.Text = ObjEmitente.GetRazaoSocial(Prop_CodEmitente)

            If ObjAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente) Then
                TxtNomeResponsavel.Text = ObjAdesaoTEFEmitente.GetConteudo("nome_responsavel")
                TxtNomeResponsavel.Enabled = pEnabled
                TxtCPF.Text = ObjAdesaoTEFEmitente.GetConteudo("cpf_responsavel")
                TxtCPF.Enabled = pEnabled
                If Not ObjAdesaoTEFEmitente.IsNull("data_nascimento_responsavel") Then
                    TxtDataNascimento.Text = ObjAdesaoTEFEmitente.GetConteudo("data_nascimento_responsavel").Substring(8, 2) + "/" + ObjAdesaoTEFEmitente.GetConteudo("data_nascimento_responsavel").Substring(5, 2) + "/" + ObjAdesaoTEFEmitente.GetConteudo("data_nascimento_responsavel").Substring(0, 4)
                Else
                    TxtDataNascimento.Text = ""
                End If
                TxtRG.Text = ObjAdesaoTEFEmitente.GetConteudo("rg_responsavel")
                TxtRG.Enabled = pEnabled
                TxtDataNascimento.Enabled = pEnabled
                TxtNomeContato.Text = ObjAdesaoTEFEmitente.GetConteudo("nome_contato")
                TxtNomeContato.Enabled = pEnabled
                TxtFone1Contato.Text = ObjAdesaoTEFEmitente.GetConteudo("telefone1_contato")
                TxtFone1Contato.Enabled = pEnabled
                TxtFone2Contato.Text = ObjAdesaoTEFEmitente.GetConteudo("telefone2_contato")
                TxtFone2Contato.Enabled = pEnabled
                TxtEmailContato.Text = ObjAdesaoTEFEmitente.GetConteudo("email_contato")
                If ObjAdesaoTEFEmitente.GetConteudo("validado") <> "S" Then
                    TxtEmailContato.Enabled = True
                Else
                    TxtEmailContato.Enabled = pEnabled
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnConfirmarDadosContato_Click(sender As Object, e As EventArgs) Handles BtnConfirmarDadosContato.Click
        Try
            If GravaDadosContato() Then
                Call CarregaTela(TipoChamadaCarregamentoTela.BtnConfirmarDadosContato, IsPostBack)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function GravaDadosContato() As Boolean
        Try
            Dim erros As String = ""
            LblErro.Text = ""

            If String.IsNullOrWhiteSpace(TxtNomeResponsavel.Text) Then
                erros += "Informe o nome da pessoa responsável pela sua empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtDataNascimento.Text) Then
                erros += "Informe a data de nascimento da pessoa responsável pela sua empresa.<br/>"
            ElseIf Not isValidDate(TxtDataNascimento.Text) Then
                erros += "Informe corretamente data de nascimento da pessoa responsável pela sua empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtCPF.Text) Then
                erros += "Informe o CPF da pessoa responsável pela sua empresa.<br/>"
            ElseIf Not IsValidCPF(TxtCPF.Text.Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")) Then
                erros += "Informe corretamente o CPF da pessoa responsável pela sua empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtRG.Text) Then
                erros += "Informe o RG da pessoa responsável pela sua empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtNomeContato.Text) Then
                erros += "Informe o nome da pessoa de contato na sua empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtFone1Contato.Text) Then
                erros += "Informe o telefone para contato.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtEmailContato.Text) Then
                erros += "Informe pelo menos um e-mail para contato.<br/>"
            ElseIf Not IsValidEmail(TxtEmailContato.Text) Then
                erros += "Informe corretamente o(s) e-mail(s) para contato (Se desejar informar mais de um e-mail, separe-os com vírgula).<br/>"
            End If

            If Not String.IsNullOrWhiteSpace(erros) Then
                LblErro.Text = erros
                Return False
            End If

            Dim ObjAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            If ObjAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente) Then
                ObjAdesaoTEFEmitente.SetConteudo("nome_responsavel", TxtNomeResponsavel.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("data_nascimento_responsavel", TxtDataNascimento.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("cpf_responsavel", TxtCPF.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP)
                ObjAdesaoTEFEmitente.SetConteudo("rg_responsavel", TxtRG.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("nome_contato", TxtNomeContato.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("telefone1_contato", TxtFone1Contato.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("telefone2_contato", TxtFone2Contato.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("email_contato", TxtEmailContato.Text.GetValidInputContent)
                ObjAdesaoTEFEmitente.SetConteudo("confirmou_contato", "S")
                ObjAdesaoTEFEmitente.Alterar()

                Dim objContato As New UCLContato
                objContato.CodEmitente = Prop_CodEmitente
                objContato.Codigo = objContato.GetCodContatoPreferencial()
                If objContato.Buscar() Then
                    objContato.Nome = TxtNomeContato.Text
                    objContato.Telefone = TxtFone1Contato.Text
                    objContato.Telefone2 = TxtFone2Contato.Text
                    objContato.Email = TxtEmailContato.Text
                    objContato.Alterar()
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnAdesao_Click(sender As Object, e As EventArgs) Handles BtnAdesao.Click
        Try
            If GravaDadosContato() Then
                Call CarregaTela(TipoChamadaCarregamentoTela.BtnAdesao, IsPostBack)
                If LblSitEtapa1.Text.Trim = "Concluída" AndAlso LblSitEtapa2.Text.Trim = "Concluída" Then
                    Dim ObjAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
                    ObjAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente)
                    ObjAdesaoTEFEmitente.SetConteudo("ip_aceite", Request.UserHostAddress)
                    ObjAdesaoTEFEmitente.SetConteudo("aceito", "S")
                    ObjAdesaoTEFEmitente.SetConteudo("data_aceite", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
                    ObjAdesaoTEFEmitente.Alterar()
                    ObjAdesaoTEFEmitente.EnviaEmailAceite() '<= aqui
                    Call CarregaTela(TipoChamadaCarregamentoTela.BtnAdesao, IsPostBack)
                Else
                    LblErro.Text = "Para aderir é necessário completar as etapas anteriores."
                End If
            Else
                LblErro.Text = "Para aderir é necessário completar as etapas anteriores."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim link As HyperLink
        Dim cnpj As String

        If e.Row.RowType = DataControlRowType.DataRow Then
            cnpj = CType(e.Row.FindControl("LblCNPJ"), Label).Text
            link = e.Row.FindControl("LnkContratar")
            link.NavigateUrl = "WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=" + cnpj
        End If
    End Sub


    Private Sub LinkButton1_Load(sender As Object, e As System.EventArgs) Handles BtnIncluir.Load
        CType(sender, LinkButton).OnClientClick = "window.open('WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=-1'); return false;"
    End Sub

    Protected Sub BtnAtualizar_Click(sender As Object, e As EventArgs) Handles BtnAtualizar.Click
        Call CarregaTela(TipoChamadaCarregamentoTela.PageLoad, False)
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Try
            Dim ObjAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            ObjAdesaoTEFEmitente.Buscar(1, Prop_CodEmitente)
            If ObjAdesaoTEFEmitente.GetConteudo("validado") = "S" Then
                LblErro.Text = "Validação já foi efetuada."
            Else
                Call GravaDadosContato()
                ObjAdesaoTEFEmitente.EnviaEmailAceite()
                LblErro.Text = "Novo e-mail de validação da adesão foi enviado para " + TxtEmailContato.Text + " em " + Now.ToString("dd/MM/yyyy HH:mm:ss") + "."
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class