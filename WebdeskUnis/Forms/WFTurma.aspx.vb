Public Class WFTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaEstabelecimentos()
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Call CarregaDefault()
                    TxtData.Text = Now.Date.AddDays(1).ToString("dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim turma As New UCLTurma
            TxtCodigo.Text = Session("SCodTurma")
            turma.Buscar(Session("GlEmpresa"), TxtCodigo.Text)
            DdlEstabelecimento.SelectedValue = turma.GetConteudo("estabelecimento")
            DdlSituacao.SelectedValue = turma.GetConteudo("situacao")
            TxtDescricao.Text = turma.GetConteudo("descricao")
            TxtCapacidade.Text = turma.GetConteudo("capacidade")
            TxtData.Text = turma.GetConteudo("data_turma")
            TxtNarrativa.Text = turma.GetConteudo("narrativa")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim turma As New UCLTurma
        TxtCodigo.Text = turma.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Private Sub CarregaDefault()
        Try
            If Acao = "INCLUIR" Then
                Dim turma As New UCLTurma
                Dim codTurmaPadrao As String = turma.GetCodTurmaPadrao(Session("GlEmpresa"), DdlEstabelecimento.SelectedValue)
                If Not String.IsNullOrWhiteSpace(codTurmaPadrao) AndAlso codTurmaPadrao <> "0" Then
                    If turma.Buscar(Session("GlEmpresa"), codTurmaPadrao) Then
                        TxtCapacidade.Text = turma.GetConteudo("capacidade")
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlEstabelecimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlEstabelecimento.SelectedIndexChanged
        Try
            Call CarregaDefault()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CarregaEstabelecimentos()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimento, False, "", UCLEstabelecimento.TipoExibicao.NomeAbreviado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property Acao() As String
        Get
            Return Session("SAcaoTurma")
        End Get
        Set(value As String)
            Session("SAcaoTurma") = value
        End Set
    End Property

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGTurma.aspx?t=" + Now.ToString("yyyyMMddHHmmss"))
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Dim turma As New UCLTurma

        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    turma.SetConteudo("empresa", Session("GlEmpresa"))
                    turma.SetConteudo("cod_turma", TxtCodigo.Text)
                    turma.Buscar(Session("GlEmpresa"), TxtCodigo.Text)
                    turma = CarregaObjeto(turma)
                    turma.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    turma.SetConteudo("empresa", Session("GlEmpresa"))
                    turma.SetConteudo("cod_turma", TxtCodigo.Text)
                    turma.SetConteudo("cod_professor", Session("GlEmitente"))
                    turma = CarregaObjeto(turma)
                    turma.Incluir()
                    turma.GerarHorariosConformePadrao(Session("GlEmpresa"), TxtCodigo.Text)
                    GridView1.DataBind()
                End If
            End If
            LblErro.Text = "Dados gravados com sucesso."

            Acao = "ALTERAR"
            Session("SCodTurma") = TxtCodigo.Text

        Catch ex As Exception
            LblErro.Text = ex.Message
            Throw ex
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        If String.IsNullOrEmpty(TxtCapacidade.Text) Then
            LblErro.Text += "Preencha o campo Capacidade.<br/>"
        ElseIf Not IsNumeric(TxtCapacidade.Text) Then
            LblErro.Text += "Preencha corretamente o campo Capacidade.<br/>"
        End If

        If String.IsNullOrEmpty(TxtData.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        ElseIf Not isValidDate(TxtData.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef turma As UCLTurma) As UCLTurma
        turma.SetConteudo("estabelecimento", DdlEstabelecimento.SelectedValue)
        turma.SetConteudo("situacao", DdlSituacao.SelectedValue)
        turma.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        turma.SetConteudo("capacidade", TxtCapacidade.Text.GetValidInputContent)
        turma.SetConteudo("data_turma", TxtData.Text.GetValidInputContent)
        turma.SetConteudo("narrativa", TxtNarrativa.Text.GetValidInputContent)
        Return turma
    End Function

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim turmaHorario As New UCLTurmaHorario
            turmaHorario.Excluir(Session("GlEmpresa"), TxtCodigo.Text, e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            LblErro.Text = ""
            If Acao = "INCLUIR" Then
                LblErro.Text = "É necessário gravar o cadastro da turma antes de prosseguir."
                Return
            End If

            If TxtHoraInicio.Text = "" Then
                LblErro.Text = "Informe a hora de início para prosseguir."
                Return
            End If

            If TxtHoraTermino.Text = "" Then
                LblErro.Text = "Informe a hora de término para prosseguir."
                Return
            End If

            Dim turmaHorario As New UCLTurmaHorario
            turmaHorario.SetConteudo("empresa", Session("GlEmpresa"))
            turmaHorario.SetConteudo("cod_turma", TxtCodigo.Text)
            turmaHorario.SetConteudo("seq_horario", turmaHorario.GetProximoCodigo(Session("GlEmpresa"), TxtCodigo.Text))
            turmaHorario.SetConteudo("hora_inicio", TxtHoraInicio.Text.GetValidInputContent)
            turmaHorario.SetConteudo("hora_termino", TxtHoraTermino.Text.GetValidInputContent)
            turmaHorario.Incluir()
            TxtHoraInicio.Text = ""
            TxtHoraTermino.Text = ""
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class