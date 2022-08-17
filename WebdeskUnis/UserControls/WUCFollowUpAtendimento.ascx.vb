Public Class WUCFollowUpAtendimento
    Inherits System.Web.UI.UserControl

    Public Property CodAtendimento As String
        Get
            Return LblCodAtendimento.Text
        End Get
        Set(ByVal value As String)
            LblCodAtendimento.Text = value
        End Set
    End Property

    Public Property SeqFolowUP As String
        Get
            Return LblCodigo.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property Acao As String
        Get
            Return LblAcao.Text
        End Get
        Set(ByVal value As String)
            LblAcao.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CarregaFormulario()
        Dim objFollowUp As New UCLAtendimentoFollowUp

        Try
            objFollowUp.Empresa = Session("GlEmpresa")
            objFollowUp.CodChamado = CodAtendimento
            objFollowUp.SeqFollowUP = SeqFolowUP
            objFollowUp.Buscar()

            TxtDescricao.Text = objFollowUp.Descricao
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CarregaObjeto(ByVal objFollowUP As UCLAtendimentoFollowUp) As UCLAtendimentoFollowUp
        If Acao = "INCLUIR" Then
            objFollowUP.CodUsuario = UsuarioPadraoResults
            objFollowUP.DataFollowUp = Now.ToString("dd/MM/yyyy")
            objFollowUP.HoraFollowUp = Now.ToString("HH:mm")
            objFollowUP.Email = "S"
            objFollowUP.Tipo = 2
        End If

        objFollowUP.Descricao = TxtDescricao.Text.GetValidInputContent

        Return objFollowUP
    End Function

    Public Sub Bind()
        Try
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaNovaPK()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim objFollowUp As New UCLAtendimentoFollowUp
        objFollowUp.Empresa = 1
        objFollowUp.CodChamado = CodAtendimento
        LblCodigo.Text = objFollowUp.GetProximoCodigo()
    End Sub

    Public Function IsDigitacaoOK()
        Try
            LblErro.Text = ""
            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text += "Descreva sua solicitação ou problema no campo descrição abaixo."
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

            Return (LblErro.Text = "")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Gravar() As Boolean
        Try
            Dim objFollowUp As New UCLAtendimentoFollowUp
            Dim caminhocompleto As String
            Dim arquivo As String

            If IsDigitacaoOK() Then
                objFollowUp.Empresa = 1
                objFollowUp.CodChamado = CodAtendimento
                If Acao = "INCLUIR" Then
                    CarregaNovaPK()
                End If
                objFollowUp.SeqFollowUP = SeqFolowUP
                If Acao = "ALTERAR" Then
                    objFollowUp.Buscar()
                End If
                objFollowUp = CarregaObjeto(objFollowUp)

                If Acao = "INCLUIR" Then
                    Dim retorno As String
                    objFollowUp.Incluir()

                    If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                        Dim objFollowUPAnexo As New UCLAtendimentoFollowUpAnexo

                        objFollowUPAnexo.Empresa = objFollowUp.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUp.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUp.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = objFollowUPAnexo.GetProximoCodigo()

                        arquivo = FUAnexo1.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUp.CodChamado + "_" + objFollowUp.SeqFollowUP + "_" + objFollowUPAnexo.SeqAnexo + "_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo1.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                        Dim objFollowUPAnexo As New UCLAtendimentoFollowUpAnexo

                        objFollowUPAnexo.Empresa = objFollowUp.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUp.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUp.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = objFollowUPAnexo.GetProximoCodigo()

                        arquivo = FUAnexo2.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUp.CodChamado + "_" + objFollowUp.SeqFollowUP + "_" + objFollowUPAnexo.SeqAnexo + "_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo2.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                        Dim objFollowUPAnexo As New UCLAtendimentoFollowUpAnexo

                        objFollowUPAnexo.Empresa = objFollowUp.Empresa
                        objFollowUPAnexo.CodChamado = objFollowUp.CodChamado
                        objFollowUPAnexo.SeqFollowUP = objFollowUp.SeqFollowUP
                        objFollowUPAnexo.SeqAnexo = objFollowUPAnexo.GetProximoCodigo()

                        arquivo = FUAnexo3.FileName
                        arquivo = arquivo.Substring(arquivo.LastIndexOf("/") + 1)
                        arquivo = objFollowUp.CodChamado + "_" + objFollowUp.SeqFollowUP + "_" + objFollowUPAnexo.SeqAnexo + "_" + arquivo

                        'caminhocompleto = Server.MapPath("/")
                        'If Not String.IsNullOrEmpty(Ambiente) Then
                        '    caminhocompleto += Ambiente + "/"
                        'End If
                        caminhocompleto = CaminhoAnexoFollowUp
                        caminhocompleto += arquivo

                        FUAnexo3.SaveAs(caminhocompleto)

                        objFollowUPAnexo.Arquivo = arquivo
                        objFollowUPAnexo.Incluir()
                    End If

                    retorno = objFollowUp.EnviaEmailFollowUP()
                    If Not String.IsNullOrEmpty(retorno) Then
                        Throw New System.Exception(retorno)
                    End If
                Else
                    objFollowUp.Alterar()
                End If
                TxtDescricao.Text = ""
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
            Return False
        End Try
    End Function

End Class