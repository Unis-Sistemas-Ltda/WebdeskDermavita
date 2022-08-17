Partial Public Class WUCAtendimentoCabecalho_Suporte
    Inherits System.Web.UI.UserControl

    Private _CodAtendimento As String
    Private _Acao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodAtendimento() As String
        Get
            Return _CodAtendimento
        End Get
        Set(ByVal value As String)
            _CodAtendimento = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MultiView1.ActiveViewIndex = 0
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()

                    If Session("SFiltroChamado") = "2" Then
                        LblMensagemAceite.Visible = True
                        RblAceito.Visible = True
                        LblMensagemNovaPergunta.Visible = True
                        RblNovaPergunta.Visible = True
                        BtnGravar.Text = "Confirmar"
                        BtnGravar.Visible = True
                    End If

                    If Session("SFiltroChamado") = "2" Then
                        LblMensagemAceite.Visible = True
                        RblAceito.Visible = True
                        BtnGravar.Text = "Confirmar"
                        BtnGravar.Visible = True
                    End If
                    Call RedigirNovoFollowUp(TipoFollowUp.Normal)

                ElseIf Acao = "INCLUIR" Then
                    GridView1.EmptyDataText = ""
                    LblHistorico.Visible = False
                    Session("SFiltroChamado") = "1"
                    LblEncerramento.Visible = False
                    LblDataEncerramento.Visible = False
                    LblHoraEncerramento.Visible = False
                    Call CarregaNovaPK()
                    Call CarregaDropDowns()
                    Call CarregaInformacoesComplementares()
                    LblSolic.Visible = True
                    TxtDescricaoFollowUP.Visible = True
                    LblAnex.Visible = True
                    FUAnexo1.Visible = True
                    FUAnexo2.Visible = True
                    FUAnexo3.Visible = True
                    LblMensagem.Visible = True
                    If DdlStatus.Items.Count > 0 Then
                        DdlStatus.SelectedIndex = 1
                        DdlStatus.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub CarregaInformacoesComplementares()
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim objTipoChamado As New UCLTipoChamado

            LblData.Text = Now.Date.ToString("dd/MM/yyyy")
            LblHora.Text = Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") + ":" + Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0")

            objParametrosManutencao.Empresa = 1
            objParametrosManutencao.Buscar()
            If Not String.IsNullOrEmpty(objParametrosManutencao.CodStatusInicial) Then
                If DdlStatus.Items.FindByValue(objParametrosManutencao.CodStatusInicial) IsNot Nothing Then
                    DdlStatus.SelectedValue = objParametrosManutencao.CodStatusInicial
                End If
            End If

            objTipoChamado.Empresa = Session("GlEmpresa")
            objTipoChamado.CodTipoChamado = DdlTipoChamado.SelectedValue
            objTipoChamado.Buscar()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Gravar_Chamado(ByVal ReaberturaPeloFollowUp As Boolean)
        Dim objAtendimento As New UCLAtendimento()
        Dim caminhocompleto As String
        Try
            If IsDigitacaoOk() Then
                If Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Session("SCodAtendimento") = LblNrAtendimento.Text
                    Call CarregaInformacoesComplementares()
                End If


                objAtendimento.Empresa = 1
                objAtendimento.CodChamado = LblNrAtendimento.Text
                objAtendimento.NumeroSerie = DdlEquipamento.SelectedValue

                If Acao = "ALTERAR" Then
                    objAtendimento.Buscar()
                Else
                    objAtendimento.Observacao = ""
                End If

                objAtendimento = CarregaObjeto(objAtendimento, ReaberturaPeloFollowUp)

                If Acao = "ALTERAR" Then
                    objAtendimento.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    objAtendimento.Incluir()
                    Session("SAcao") = "ALTERAR"
                End If

                If TxtDescricaoFollowUP.Visible Then
                    Dim objFollowUP As New UCLAtendimentoFollowUp
                    Dim objFollowUPAnexo As New UCLAtendimentoFollowUpAnexo
                    Dim arquivo As String
                    Dim retorno As String

                    objFollowUP.Empresa = Session("GlEmpresa")
                    objFollowUP.CodChamado = LblNrAtendimento.Text
                    objFollowUP.SeqFollowUP = objFollowUP.GetProximoCodigo()
                    objFollowUP.CodUsuario = UsuarioPadraoResults
                    objFollowUP.DataFollowUp = Now.ToString("dd/MM/yyyy")
                    objFollowUP.HoraFollowUp = Now.ToString("HH:mm")
                    objFollowUP.Descricao = TxtDescricaoFollowUP.Text.GetValidInputContent
                    objFollowUP.Email = "S"
                    objFollowUP.Tipo = 2
                    objFollowUP.Incluir()

                    If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                        arquivo = FUAnexo1.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUP.CodChamado + "_" + objFollowUP.SeqFollowUP + "_1_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo1.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Empresa = objFollowUP.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUP.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUP.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = 1
                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                        arquivo = FUAnexo2.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUP.CodChamado + "_" + objFollowUP.SeqFollowUP + "_2_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo2.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Empresa = objFollowUP.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUP.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUP.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = 2
                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                        arquivo = FUAnexo3.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUP.CodChamado + "_" + objFollowUP.SeqFollowUP + "_3_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo3.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Empresa = objFollowUP.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUP.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUP.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = 3
                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    retorno = objFollowUP.EnviaEmailFollowUP()
                    If Not String.IsNullOrEmpty(retorno) Then
                        Throw New System.Exception(retorno)
                    End If

                End If

                If objAtendimento.ChecaEnvioEmailStatus Then
                    objAtendimento.EnviaEmailStatus()
                End If

                If Acao = "INCLUIR" Then
                    Session("SSErro") = MensagemChamadoCadastrado(LblNrAtendimento.Text, DdlContatos.SelectedItem.Text, Session("GlDepto"), 2)
                End If

                If Not ReaberturaPeloFollowUp Then
                    Response.Redirect("WGAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Gravar_Chamado(False)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaStatus()
        Call CarregaContatos()
        Call CarregaTipoChamado()
        Call CarregaEquipamento()
    End Sub

    Private Sub CarregaContatos()
        Dim objContatos As New UCLContato
        objContatos.CodEmitente = Session("GlEmitente")
        objContatos.FillDropDown(DdlContatos, True, "(selecione)", "0")
    End Sub

    Private Sub CarregaTipoChamado()
        Dim objTipoChamado As New UCLTipoChamado
        objTipoChamado.Empresa = Session("GlEmpresa")
        objTipoChamado.FillDropDownChamado(DdlTipoChamado, True, "(selecione)", "0")
    End Sub

    Private Sub CarregaEquipamento()
        Dim objEquipamento As New UCLItem
        objEquipamento.CodEmitente = Session("GlEmitente")
        objEquipamento.FillDropDownEquipamentoChamado(DdlEquipamento, True, "(selecione)")
    End Sub

    Private Function MensagemChamadoCadastrado(ByVal chamado As String, ByVal responsavel As String, codDepartamento As String, ByVal pCodSLA As String) As String
        Try
            Dim texto As String
            Dim dataEncerramentoPrevista As DateTime
            Dim dataChamado As DateTime

            If isValidDate(LblData.Text) Then
                If String.IsNullOrEmpty(LblHora.Text) Then
                    dataChamado = New DateTime(CDate(LblData.Text).Year, CDate(LblData.Text).Month, CDate(LblData.Text).Day, 0, 0, 0)
                Else
                    dataChamado = New DateTime(CDate(LblData.Text).Year, CDate(LblData.Text).Month, CDate(LblData.Text).Day, CLng(LblHora.Text.Substring(0, 2)), CLng(LblHora.Text.Substring(3, 2)), 0)
                End If
            Else
                dataChamado = Now()
            End If

            dataEncerramentoPrevista = GetDataEncerramentoPrevista(pCodSLA, dataChamado)

            texto = "Prezado(a) " + responsavel + ",<br><br>"
            texto += "Sua solicitação foi registrada.<br><br>"
            texto += "Nº do chamado: " + chamado + "<br>"
            texto += "Nosso atendimento ocorre de segunda a sexta-feira, das 08:00 às 12:00 e das 14:00 às 18:00h - Horário de Brasília.<br>"
            texto += "O prazo previsto para resposta do seu chamado é até " + dataEncerramentoPrevista.ToString("dd/MM/yyyy HH:mm") + "."

            Return texto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CarregaStatus()
        Try
            Dim objStatusChamado As New UCLStatusChamado
            objStatusChamado.FillDropDown(DdlStatus, True, "(selecione)", "-1", UCLStatusChamado.TipoDropDown.SubSeq, CodStatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Property CodStatus() As String
        Get
            If String.IsNullOrEmpty(LblCodStatus.Text) Then
                LblCodStatus.Text = "-1"
            End If
            Return LblCodStatus.Text
        End Get
        Set(ByVal value As String)
            LblCodStatus.Text = value
        End Set
    End Property

    Private Property CodAnalista() As String
        Get
            If String.IsNullOrEmpty(LblCodAnalista.Text) Then
                LblCodAnalista.Text = "-1"
            End If
            Return LblCodAnalista.Text
        End Get
        Set(ByVal value As String)
            LblCodAnalista.Text = value
        End Set
    End Property

    Private Sub CarregaInfoContato()
        Dim objContato As New UCLContato
        objContato.CodEmitente = Session("GlEmitente")
        objContato.Codigo = DdlContatos.SelectedValue
        If Not String.IsNullOrEmpty(objContato.Codigo) Then
            objContato.Buscar()
            LblEmail.Text = objContato.Email
        Else
            LblEmail.Text = ""
        End If
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim objAtendimento As New UCLAtendimento()
            LblErro.Text = ""

            If DdlStatus.SelectedValue = "-1" Then
                LblErro.Text += "Preencha o campo Status.<br/>"
            End If

            If String.IsNullOrEmpty(TxtAssunto.Text) Then
                LblErro.Text += "Preencha o campo Assunto.<br/>"
            End If

            If String.IsNullOrEmpty(DdlContatos.SelectedValue) Then
                LblErro.Text += "Informe o Contato Responsável.<br/>"
            Else
                If DdlContatos.SelectedValue = "0" Then
                    LblErro.Text += "Informe o Contato Responsável.<br/>"
                End If
            End If

            If String.IsNullOrEmpty(DdlTipoChamado.SelectedValue) Then
                LblErro.Text += "Informe o Tipo de Chamado.<br/>"
            Else
                If DdlTipoChamado.SelectedValue = "0" Then
                    LblErro.Text += "Informe o Tipo de Chamado.<br/>"
                End If
            End If

            If String.IsNullOrEmpty(DdlEquipamento.SelectedValue) Then
                LblErro.Text += "Informe o Equipamento.<br/>"
            Else
                If DdlEquipamento.SelectedValue = "0" Then
                    LblErro.Text += "Informe o Equipamento.<br/>"
                End If
            End If

            If TxtDescricaoFollowUP.Visible Then
                If Session("SFiltroChamado") = "1" Then
                    If String.IsNullOrEmpty(TxtDescricaoFollowUP.Text) Then
                        LblErro.Text += "Descreva sua solicitação no campo abaixo.<br/>"
                    End If
                Else
                    If String.IsNullOrEmpty(TxtDescricaoFollowUP.Text) Then
                        LblErro.Text += "Informe o motivo no campo abaixo.<br/>"
                    End If
                End If

            End If

            If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                If Not FUAnexo1.FileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".doc", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".ppt", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".pptx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".xls", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo1.FileName.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) Then
                    LblErro.Text += "O anexo a ser enviado deve ter um dos seguintes formatos: PDF, PNG, JPG, DOC, DOCX, PPT, PPTX, XLS, XLSX ou GIF<br/>"
                End If
            End If

            If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                If Not FUAnexo2.FileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".doc", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".ppt", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".pptx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".xls", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo2.FileName.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) Then
                    LblErro.Text += "O anexo a ser enviado deve ter um dos seguintes formatos: PDF, PNG, JPG, DOC, DOCX, PPT, PPTX, XLS, XLSX ou GIF<br/>"
                End If
            End If

            If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                If Not FUAnexo3.FileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".doc", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".ppt", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".pptx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".xls", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase) _
                   And Not FUAnexo3.FileName.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) Then
                    LblErro.Text += "O anexo a ser enviado deve ter um dos seguintes formatos: PDF, PNG, JPG, DOC, DOCX, PPT, PPTX, XLS, XLSX ou GIF<br/>"
                End If
            End If

            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function CarregaObjeto(ByRef objAtendimento As UCLAtendimento, ByVal ReaberturaPeloFollowUp As Boolean) As UCLAtendimento
        Dim objAtendimentoChk As New UCLAtendimento()
        Dim objParametrosManutencao As New UCLParametrosManutencao
        Dim objDepartamentoAtendimento As New UCLDepartamentoAtendimento
        Dim objTipoChamado As New UCLTipoChamado
        objTipoChamado.Empresa = Session("GlEmpresa")
        objTipoChamado.CodTipoChamado = DdlTipoChamado.SelectedValue
        objTipoChamado.Buscar()
        objParametrosManutencao.Empresa = 1
        objParametrosManutencao.Buscar()

        objDepartamentoAtendimento.CodDepartamento = 1
        objDepartamentoAtendimento.Buscar()

        objAtendimento.CodEmitente = Session("GlEmitente")
        objAtendimento.CodContato = DdlContatos.SelectedValue
        objAtendimento.TipoChamado = DdlTipoChamado.SelectedValue
        objAtendimento.NumeroSerie = DdlEquipamento.SelectedValue

        If String.IsNullOrEmpty(objAtendimento.TipoChamado) Then
            objAtendimento.TipoChamado = objParametrosManutencao.TipoChamadoPadrao
        End If

        If String.IsNullOrEmpty(objAtendimento.CodAnalista) Then
            objAtendimento.CodAnalista = objTipoChamado.Cod_Usuario
            'If String.IsNullOrWhiteSpace(objDepartamentoAtendimento.CodAnalistaPadrao) Then
            '    objAtendimento.CodAnalista = objParametrosManutencao.CodAnalistaPadrao
            'Else
            '    objAtendimento.CodAnalista = objDepartamentoAtendimento.CodAnalistaPadrao
            'End If
        End If

        objAtendimento.CodUsuario = 1

        If DdlStatus.SelectedValue = "-1" Then
            objAtendimento.CodStatus = ""
        Else
            objAtendimento.CodStatus = DdlStatus.SelectedValue
        End If

        objAtendimento.DataChamado = LblData.Text
        objAtendimento.HoraChamado = LblHora.Text
        objAtendimento.DataEncerramentoPrevistaInicio = LblDataPrevisaoFim.Text
        objAtendimento.HoraEncerramentoPrevistaInicio = LblHoraPrevisaoFim.Text
        objAtendimento.DataEncerramentoPrevista = LblDataPrevisaoFim.Text
        objAtendimento.HoraEncerramentoPrevista = LblHoraPrevisaoFim.Text
        objAtendimento.Assunto = TxtAssunto.Text.GetValidInputContent
        objAtendimento.Cnpj = Session("GlCNPJ")
        objAtendimento.CodVeiculo = ""
        objAtendimento.SeqPrioridade = TxtSeqPrioridade.Text

        'Testa se é para gerar e-mail ou não
        objAtendimento.ChecaEnvioEmailStatus = False
        objAtendimentoChk.Empresa = objAtendimento.Empresa
        objAtendimentoChk.CodChamado = objAtendimento.CodChamado
        If objAtendimentoChk.Buscar() Then
            If Not String.IsNullOrEmpty(objAtendimento.CodStatus) And Not String.IsNullOrEmpty(objAtendimentoChk.CodStatus) Then
                If objAtendimento.CodStatus <> objAtendimentoChk.CodStatus Then
                    objAtendimento.ChecaEnvioEmailStatus = True
                End If
            End If
        Else
            objAtendimento.ChecaEnvioEmailStatus = True
        End If

        If Session("SFiltroChamado") = "2" Then
            objAtendimento.EncerramentoAceito = RblAceito.SelectedValue
            objAtendimento.DataAceiteEncerramento = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
            objAtendimento.DDataAceiteEncerramento = System.DateTime.Now.Date
            objAtendimento.HHoraAceiteEncerramento = System.DateTime.Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") + ":" + System.DateTime.Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0")
        End If

        If Session("SFiltroChamado") = "2" OrElse Session("SFiltroChamado") = 3 Then
            If ReaberturaPeloFollowUp OrElse RblNovaPergunta.SelectedValue = "S" Then
                objAtendimento.CodStatus = 1
                LblData.Text = Now.ToString("dd/MM/yyyy")
                LblHora.Text = Now.ToString("HH:mm")
                LblDataPrevisaoFim.Text = F_DateAdd(Now.Date, "d", 3, "s").ToString("dd/MM/yyyy")
                LblHoraPrevisaoFim.Text = "23:59"

                objAtendimento.DataChamado = LblData.Text
                objAtendimento.HoraChamado = LblHora.Text
                objAtendimento.DataEncerramentoPrevistaInicio = LblDataPrevisaoFim.Text
                objAtendimento.HoraEncerramentoPrevistaInicio = LblHoraPrevisaoFim.Text
                objAtendimento.DataEncerramentoPrevista = LblDataPrevisaoFim.Text
                objAtendimento.HoraEncerramentoPrevista = LblHoraPrevisaoFim.Text

                objAtendimento.Encerrado = "N"
            Else
                objAtendimento.Encerrado = "S"
            End If
        End If

        objAtendimento.Encerrado = IIf(objAtendimento.Encerrado Is Nothing OrElse String.IsNullOrWhiteSpace(objAtendimento.Encerrado), "N", objAtendimento.Encerrado)

        If Acao = "INCLUIR" Then
            objAtendimento.CodSla = 2
        End If

        Return objAtendimento
    End Function

    Private Function GetPrazoSLA(ByVal pCodSla) As Long
        Try
            Dim ObjSLA As New UCLSLA
            Dim prazoEncerramento As Long

            ObjSLA.CodSLA = pCodSla
            ObjSLA.Buscar()
            If IsNumeric(ObjSLA.PrazoEncerramento) Then
                prazoEncerramento = ObjSLA.PrazoEncerramento
            Else
                prazoEncerramento = 0
            End If

            Return prazoEncerramento
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetDataEncerramentoPrevista(ByVal pCodSla As String, ByVal dataChamado As DateTime) As DateTime
        Try
            Dim prazoEncerramento As Long
            Dim dataEncerramentoPrevista As DateTime
            Dim dif As Long

            prazoEncerramento = GetPrazoSLA(pCodSla)

            If dataChamado.DayOfWeek = DayOfWeek.Saturday Then
                dataChamado.AddDays(2)
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 0, 0, 1)
            End If

            If dataChamado.DayOfWeek = DayOfWeek.Sunday Then
                dataChamado.AddDays(1)
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 0, 0, 1)
            End If

            If dataChamado.Hour < 8 Then
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 8, 0, 0)
            ElseIf dataChamado.Hour >= 18 Then
                dataChamado.AddDays(1)
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 8, 0, 0)
            End If

            dataEncerramentoPrevista = dataChamado.AddHours(prazoEncerramento)

            If dataEncerramentoPrevista.Hour >= 18 Then
                dif = DateDiff(DateInterval.Minute, dataEncerramentoPrevista, New DateTime(dataEncerramentoPrevista.Year, dataEncerramentoPrevista.Month, dataEncerramentoPrevista.Day, 18, 0, 0))
                dataEncerramentoPrevista = dataEncerramentoPrevista.AddDays(1)
                dataEncerramentoPrevista = New DateTime(dataEncerramentoPrevista.Year, dataEncerramentoPrevista.Month, dataEncerramentoPrevista.Day, 8, 0, 0).AddMinutes(dif * -1)
            End If

            If dataEncerramentoPrevista.DayOfWeek = DayOfWeek.Saturday Or dataEncerramentoPrevista.DayOfWeek = DayOfWeek.Sunday Then
                dataEncerramentoPrevista = dataEncerramentoPrevista.AddHours(48)
            End If

            Return dataEncerramentoPrevista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub CarregaPrazos(ByVal pCodSla As String)
        Try
            Dim dataChamado As DateTime
            Dim dataEncerramentoPrevista As DateTime

            If String.IsNullOrWhiteSpace(LblHora.Text) Then
                If Acao = "INCLUIR" Then
                    LblHora.Text = Now.ToString("HH:mm")
                End If
            End If

            If isValidDate(LblData.Text) Then
                If String.IsNullOrEmpty(LblHora.Text) Then
                    dataChamado = New DateTime(CDate(LblData.Text).Year, CDate(LblData.Text).Month, CDate(LblData.Text).Day, 0, 0, 0)
                Else
                    dataChamado = New DateTime(CDate(LblData.Text).Year, CDate(LblData.Text).Month, CDate(LblData.Text).Day, CLng(LblHora.Text.Substring(0, 2)), CLng(LblHora.Text.Substring(3, 2)), 0)
                End If
            Else
                dataChamado = Now()
            End If

            dataEncerramentoPrevista = GetDataEncerramentoPrevista(pCodSla, dataChamado)

            LblDataPrevisaoFim.Text = dataEncerramentoPrevista.ToString("dd/MM/yyyy")
            LblHoraPrevisaoFim.Text = dataEncerramentoPrevista.ToString("HH:mm")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objAtendimento As New UCLAtendimento()
        Dim objUsuario As New UCLUsuario(StrConexao)
        Dim objTipoChamado As New UCLTipoChamado
        LblNrAtendimento.Text = CodAtendimento

        objAtendimento.Empresa = 1
        objAtendimento.CodChamado = CodAtendimento
        objAtendimento.Buscar()

        LblData.Text = objAtendimento.DataChamado
        LblHora.Text = objAtendimento.HoraChamado
        LblDataEncerramento.Text = objAtendimento.DataEncerramento
        LblHoraEncerramento.Text = objAtendimento.HoraEncerramento
        LblDataPrevisaoFim.Text = objAtendimento.DataEncerramentoPrevista
        LblHoraPrevisaoFim.Text = objAtendimento.HoraEncerramentoPrevista
        CodStatus = objAtendimento.CodStatus
        CodAnalista = objAtendimento.CodAnalista
        TxtSeqPrioridade.Text = objAtendimento.SeqPrioridade
        DdlTipoChamado.SelectedValue = objAtendimento.TipoChamado
        DdlEquipamento.SelectedValue = objAtendimento.NumeroSerie

        objTipoChamado.Empresa = Session("GlEmpresa")
        objTipoChamado.CodTipoChamado = objAtendimento.TipoChamado
        objTipoChamado.Buscar()

        'Necessário para que a alteração de emitente funcione via tela do chamado, não retirar
        '----------------------------------------------
        Session("SCNPJEmitente") = objAtendimento.Cnpj
        '----------------------------------------------

        Call CarregaDropDowns()

        'Mostra nome contato

        DdlContatos.SelectedValue = objAtendimento.CodContato
        Call CarregaInfoContato()

        If Not String.IsNullOrEmpty(objAtendimento.CodStatus) Then
            DdlStatus.SelectedValue = objAtendimento.CodStatus
        End If

        TxtAssunto.Text = objAtendimento.Assunto
        objUsuario.CodUsuario = objAtendimento.CodUsuario
        objUsuario.BuscarPorCodigo()

        TxtAssunto.Enabled = False

        LblAssuntoLbl.Visible = True
        TxtAssunto.Visible = True
        LblResponsavelLbl.Visible = False
        DdlContatos.Visible = False
        BtnIncluir.Visible = False
        BtnAlterar.Visible = False
        LblEmail.Visible = False
        'BtnGravar.Visible = False
        LblMensagem.Visible = False

        If String.IsNullOrEmpty(LblDataEncerramento.Text) And String.IsNullOrEmpty(LblHoraEncerramento.Text) Then
            LblEncerramento.Visible = False
            LblDataEncerramento.Visible = False
            LblHoraEncerramento.Visible = False
        Else
            LblEncerramento.Visible = True
            LblDataEncerramento.Visible = True
            LblHoraEncerramento.Visible = True
        End If

        If objAtendimento.CodStatus = 12 OrElse objAtendimento.EncerramentoAceito = "I" OrElse objAtendimento.EncerramentoAceito = "S" Then
            LblTipoEdicaoFollowUp.Text = TipoFollowUp.AposResposta
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim objAtendimento As New UCLAtendimento()
        objAtendimento.Empresa = 1
        LblNrAtendimento.Text = objAtendimento.GetProximoCodigo
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Session("SFiltroChamado") = 1
        Response.Redirect("WGAtendimento.aspx")
    End Sub

    Protected Sub DdlContatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContatos.SelectedIndexChanged
        Call CarregaInfoContato()
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        WUCContato1.Acao = "INCLUIR"
        WUCContato1.CodContato = -1
        WUCContato1.CodEmitente = Session("GlEmitente")
        WUCContato1.Bind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnAlterar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAlterar.Click
        WUCContato1.Acao = "ALTERAR"
        WUCContato1.CodContato = DdlContatos.SelectedValue
        WUCContato1.CodEmitente = Session("GlEmitente")
        WUCContato1.Bind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnGravarContato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravarContato.Click
        Dim codContato As String
        Try
            If WUCContato1.Gravar() Then
                MultiView1.ActiveViewIndex = 0
                Call CarregaContatos()
                codContato = WUCContato1.CodContato
                DdlContatos.SelectedValue = codContato
                Call CarregaInfoContato()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BtnVoltarContato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltarContato.Click
        Try
            Call WUCContato1.Voltar()
            MultiView1.ActiveViewIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Enum TipoFollowUp As Short
        Normal = 1
        AposResposta = 2
    End Enum

    Private Sub RedigirNovoFollowUp(Tipo As TipoFollowUp)
        Try
            WUCFollowUPAtendimento1.Visible = True
            BtnGravarFollowUP.Visible = True
            'LblTipoEdicaoFollowUp.Text = Tipo
            WUCFollowUPAtendimento1.Acao = "INCLUIR"
            WUCFollowUPAtendimento1.CodAtendimento = CodAtendimento
            WUCFollowUPAtendimento1.SeqFolowUP = -1
            WUCFollowUPAtendimento1.Bind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravarFollowUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravarFollowUP.Click
        Try
            If WUCFollowUPAtendimento1.Gravar() Then
                MultiView1.ActiveViewIndex = 0
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()

                If LblTipoEdicaoFollowUp.Text = TipoFollowUp.AposResposta Then
                    Call Gravar_Chamado(True)
                    LblErro.Text = MensagemChamadoCadastrado(LblNrAtendimento.Text, DdlContatos.SelectedItem.Text, Session("GlDepto"), 2)
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function EnviaEmail(pEmpresa As Integer, pCodChamado As Long, pSeqFollowUp As Integer) As String
        Try
            Dim retorno As String
            Dim objAtendimentoFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))

            objAtendimentoFollowUp.Empresa = pEmpresa
            objAtendimentoFollowUp.CodChamado = pCodChamado
            objAtendimentoFollowUp.SeqFollowUP = pSeqFollowUp
            retorno = objAtendimentoFollowUp.EnviaEmailFollowUP(StrConexaoUsuario(Session("GlUsuario")))
            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class