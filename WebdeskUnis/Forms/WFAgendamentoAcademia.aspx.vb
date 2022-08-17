Public Class WFAgendamentoAcademia
    Inherits System.Web.UI.Page

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GridView1.DataBind()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Agendar(ByVal Turma As String, ByVal Local As String, Horario As String)
        Try
            Dim objAgendaAluno As New UCLAgendaAluno

            objAgendaAluno.SetConteudo("empresa", Session("GlEmpresa"))
            objAgendaAluno.SetConteudo("estabelecimento", Local)
            objAgendaAluno.SetConteudo("seq_agendamento", objAgendaAluno.GetProximoCodigo(objAgendaAluno.GetConteudo("empresa"), objAgendaAluno.GetConteudo("estabelecimento")))
            objAgendaAluno.SetConteudo("cod_emitente", Session("GlEmitente"))
            objAgendaAluno.SetConteudo("cnpj", Session("GlCNPJ"))
            objAgendaAluno.SetConteudo("cod_turma", Turma)
            objAgendaAluno.SetConteudo("seq_horario", Horario)
            objAgendaAluno.Incluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim parm As String()
            If e.CommandName = "EXCLUIR" Then
                parm = e.CommandArgument.ToString.Split(";")
                Dim objAgendaAluno As New UCLAgendaAluno
                objAgendaAluno.Excluir(Session("GlEmpresa"), parm(1), parm(0))
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Agendamento cancelado com sucesso.');", True)
                GridView1.DataBind()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView2_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "AGENDAR" Then
                Dim parm As String() = e.CommandArgument.ToString.Split(";")
                Call Agendar(parm(2), parm(1), parm(3))
                GridView1.DataBind()
                GridView2.DataBind()
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Agendamento registrado com sucesso.');", True)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString()
        End Try
    End Sub
End Class