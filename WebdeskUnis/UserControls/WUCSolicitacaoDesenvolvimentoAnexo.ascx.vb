Public Class WUCSolicitacaoDesenvolvimentoAnexo
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _SeqAnexo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjSolicitacaoDesenvolvimentoAnexo As New UCLSolicitacaoDesenvolvimentoAnexo(StrConexao)
        ObjSolicitacaoDesenvolvimentoAnexo.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimentoAnexo.CodSolicitacao = Session("SCodSolicitacao")
        ObjSolicitacaoDesenvolvimentoAnexo.SeqAnexo = SeqAnexo
        ObjSolicitacaoDesenvolvimentoAnexo.Buscar()
        LblSeqAnexo.Text = ObjSolicitacaoDesenvolvimentoAnexo.SeqAnexo
        TxtDescricao.Text = ObjSolicitacaoDesenvolvimentoAnexo.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjSolicitacaoDesenvolvimentoAnexo As New UCLSolicitacaoDesenvolvimentoAnexo(StrConexao)
        ObjSolicitacaoDesenvolvimentoAnexo.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimentoAnexo.CodSolicitacao = Session("SCodSolicitacao")
        LblSeqAnexo.Text = ObjSolicitacaoDesenvolvimentoAnexo.GetProximoCodigo()
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjSolicitacaoDesenvolvimentoAnexo As New UCLSolicitacaoDesenvolvimentoAnexo(StrConexao)
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjSolicitacaoDesenvolvimentoAnexo.Empresa = Session("GlEmpresa")
                    ObjSolicitacaoDesenvolvimentoAnexo.CodSolicitacao = Session("SCodSolicitacao")
                    ObjSolicitacaoDesenvolvimentoAnexo.SeqAnexo = LblSeqAnexo.Text
                    ObjSolicitacaoDesenvolvimentoAnexo = CarregaObjeto(ObjSolicitacaoDesenvolvimentoAnexo)
                    ObjSolicitacaoDesenvolvimentoAnexo.Alterar()
                    If Not String.IsNullOrWhiteSpace(ObjSolicitacaoDesenvolvimentoAnexo.Anexo) Then
                        FU_Anexo.SaveAs("C:\Inetpub\wwwroot\crm\Arquivos\AnexoSolicitacaoDesenvolvimento\" + NomeArquivoAnexo())
                    End If
                    Response.Redirect("WGSolicitacaoDesenvolvimentoAnexo.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjSolicitacaoDesenvolvimentoAnexo.Empresa = Session("GlEmpresa")
                    ObjSolicitacaoDesenvolvimentoAnexo.CodSolicitacao = Session("SCodSolicitacao")
                    ObjSolicitacaoDesenvolvimentoAnexo.SeqAnexo = LblSeqAnexo.Text
                    ObjSolicitacaoDesenvolvimentoAnexo = CarregaObjeto(ObjSolicitacaoDesenvolvimentoAnexo)
                    ObjSolicitacaoDesenvolvimentoAnexo.Incluir()
                    FU_Anexo.SaveAs("C:\Inetpub\wwwroot\crm\Arquivos\AnexoSolicitacaoDesenvolvimento\" + NomeArquivoAnexo())
                    Response.Redirect("WGSolicitacaoDesenvolvimentoAnexo.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef ObjSolicitacaoDesenvolvimentoAnexo As UCLSolicitacaoDesenvolvimentoAnexo) As UCLSolicitacaoDesenvolvimentoAnexo
        Try
            ObjSolicitacaoDesenvolvimentoAnexo.Descricao = TxtDescricao.Text.GetValidInputContent
            If Not String.IsNullOrWhiteSpace(FU_Anexo.FileName) Then
                ObjSolicitacaoDesenvolvimentoAnexo.Anexo = NomeArquivoAnexo()
            Else
                ObjSolicitacaoDesenvolvimentoAnexo.Anexo = ""
            End If
            Return ObjSolicitacaoDesenvolvimentoAnexo
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function NomeArquivoAnexo() As String
        Try
            Return Session("SCodSolicitacao").ToString.PadLeft(7, "0") + "_" + LblSeqAnexo.Text.PadLeft(3, "0") + "_" + FU_Anexo.FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function IsDigitacaoOk() As Boolean
        Try
            LblErro.Text = ""
            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text += "Preencha o campo Descrição.<br/>"
            End If
            If Acao = "INCLUIR" Then
                If String.IsNullOrWhiteSpace(FU_Anexo.FileName) Then
                    LblErro.Text += "Selecione o arquivo a ser anexado.<br/>"
                End If
            End If
            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class