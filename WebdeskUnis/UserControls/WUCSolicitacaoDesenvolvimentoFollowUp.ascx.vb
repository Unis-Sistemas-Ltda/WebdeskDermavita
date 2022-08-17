Public Class WUCSolicitacaoDesenvolvimentoFollowUp
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _SeqFollowUp As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property SeqFollowUp() As String
        Get
            Return _SeqFollowUp
        End Get
        Set(ByVal value As String)
            _SeqFollowUp = value
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
        Dim ObjSolicitacaoDesenvolvimentoFollowUp As New UCLSolicitacaoDesenvolvimentoFollowUp(StrConexao)
        ObjSolicitacaoDesenvolvimentoFollowUp.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimentoFollowUp.CodSolicitacao = Session("SCodSolicitacao")
        ObjSolicitacaoDesenvolvimentoFollowUp.SeqFollowUp = SeqFollowUp
        ObjSolicitacaoDesenvolvimentoFollowUp.Buscar()
        If ObjSolicitacaoDesenvolvimentoFollowUp.VisivelCliente = "S" Then
            CbxVisivelCliente.Checked = True
        Else
            CbxVisivelCliente.Checked = True = False
        End If
        LblSeqFollowUp.Text = ObjSolicitacaoDesenvolvimentoFollowUp.SeqFollowUp
        TxtDescricao.Text = ObjSolicitacaoDesenvolvimentoFollowUp.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjSolicitacaoDesenvolvimentoFollowUp As New UCLSolicitacaoDesenvolvimentoFollowUp(StrConexao)
        ObjSolicitacaoDesenvolvimentoFollowUp.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimentoFollowUp.CodSolicitacao = Session("SCodSolicitacao")
        LblSeqFollowUp.Text = ObjSolicitacaoDesenvolvimentoFollowUp.GetProximoCodigo()
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjSolicitacaoDesenvolvimentoFollowUp As New UCLSolicitacaoDesenvolvimentoFollowUp(StrConexao)
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjSolicitacaoDesenvolvimentoFollowUp.Empresa = Session("GlEmpresa")
                    ObjSolicitacaoDesenvolvimentoFollowUp.CodSolicitacao = Session("SCodSolicitacao")
                    ObjSolicitacaoDesenvolvimentoFollowUp.SeqFollowUp = LblSeqFollowUp.Text
                    ObjSolicitacaoDesenvolvimentoFollowUp.CodUsuarioAlteracao = UsuarioPadraoResults
                    ObjSolicitacaoDesenvolvimentoFollowUp = CarregaObjeto(ObjSolicitacaoDesenvolvimentoFollowUp)
                    ObjSolicitacaoDesenvolvimentoFollowUp.Alterar()
                    Response.Redirect("WGSolicitacaoDesenvolvimentoFollowUp.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjSolicitacaoDesenvolvimentoFollowUp.Empresa = Session("GlEmpresa")
                    ObjSolicitacaoDesenvolvimentoFollowUp.CodSolicitacao = Session("SCodSolicitacao")
                    ObjSolicitacaoDesenvolvimentoFollowUp.SeqFollowUp = LblSeqFollowUp.Text
                    ObjSolicitacaoDesenvolvimentoFollowUp.CodUsuarioInclusao = UsuarioPadraoResults
                    ObjSolicitacaoDesenvolvimentoFollowUp.CodUsuarioAlteracao = UsuarioPadraoResults
                    ObjSolicitacaoDesenvolvimentoFollowUp = CarregaObjeto(ObjSolicitacaoDesenvolvimentoFollowUp)
                    ObjSolicitacaoDesenvolvimentoFollowUp.Incluir()
                    Response.Redirect("WGSolicitacaoDesenvolvimentoFollowUp.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef ObjSolicitacaoDesenvolvimentoFollowUp As UCLSolicitacaoDesenvolvimentoFollowUp) As UCLSolicitacaoDesenvolvimentoFollowUp
        Try
            ObjSolicitacaoDesenvolvimentoFollowUp.Descricao = TxtDescricao.Text.GetValidInputContent
            If CbxVisivelCliente.Checked Then
                ObjSolicitacaoDesenvolvimentoFollowUp.VisivelCliente = "S"
            Else
                ObjSolicitacaoDesenvolvimentoFollowUp.VisivelCliente = "N"
            End If
            Return ObjSolicitacaoDesenvolvimentoFollowUp
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
            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class