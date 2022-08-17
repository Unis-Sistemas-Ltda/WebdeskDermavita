Public Class WFAtualizacaoCadastro
    Inherits System.Web.UI.Page

    Private ReadOnly Property Prop_CodEmitente
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Private ReadOnly Property Prop_CNPJ
        Get
            Return Request.QueryString.Item("c")
        End Get
    End Property

    Dim recarregarGrid As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BtnIncluirEstabelecimento.PostBackUrl = "WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=-1"
        CadastroEmitente1.TipoExibicao = "C"
        CadastroEmitente1.P_CodEmitente = Prop_CodEmitente
        CadastroEmitente1.P_CNPJ = Prop_CNPJ
        If IsPostBack Then
            If IsMarcacaoOk() Then
                Call recarregaGrids()
            End If
        End If
    End Sub

    Public Sub recarregaGrids()
        Dim cbPrincipal As CheckBox
        Dim cnpjPrincipal As String = ""

        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                cbPrincipal = CType(row.FindControl("chkPrincipal"), CheckBox)
                If cbPrincipal.Checked Then
                    cnpjPrincipal = CType(row.FindControl("lblCNPJ"), Label).Text.ToString
                End If
            End If
        Next

        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        GridView1.DataBind()

        If cnpjPrincipal <> "" Then
            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    If CType(row.FindControl("lblCNPJ"), Label).Text.ToString = cnpjPrincipal Then
                        cbPrincipal = CType(row.FindControl("chkPrincipal"), CheckBox)
                        cbPrincipal.Checked = True
                    Else
                        cbPrincipal = CType(row.FindControl("chkPrincipal"), CheckBox)
                        cbPrincipal.Checked = False
                    End If
                End If
            Next
        End If

    End Sub

    Protected Function IsMarcacaoOk() As Boolean
        Dim cnpj As String = Nothing
        Dim cnpjs As New List(Of String)
        Dim isChecked As Boolean

        LblErro.Text = ""
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                isChecked = CType(row.FindControl("chkPrincipal"), CheckBox).Checked
                If isChecked Then
                    cnpj = CType(row.FindControl("lblCNPJ"), Label).Text
                    cnpjs.Add(cnpj)
                End If
            End If
        Next
        If cnpjs.Count > 1 Then
            LblErro.Text = "Marque apenas uma Unidade como Principal."
        ElseIf cnpjs.Count = 0 Then
            LblErro.Text = "Por favor identifique e marque na lista a Unidade Principal."
        End If

        If Not CheckBox1.Checked Then
            LblErro.Text += "<br/>Por favor verifique os dados informados e em seguida clique em <strong>Confirmo os dados cadastrais acima informados</strong>."
        End If

        Return (LblErro.Text = "")
    End Function

    Protected Sub guardaPrincipal()
        Dim cnpj As String = Nothing
        Dim isChecked As Boolean

        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                isChecked = CType(row.FindControl("chkPrincipal"), CheckBox).Checked
                If isChecked Then
                    cnpj = CType(row.FindControl("lblCNPJ"), Label).Text
                    Exit For
                End If
            End If
        Next
        Session("CNPJPrincipal") = cnpj
    End Sub

    Protected Sub marcaPrincipal(ByVal cnpj As String)
        If (Not cnpj Is (Nothing)) Then
            If (cnpj.Trim <> "") Then
                'cria e instancia uma variável do tipo StrinfBuilder para concatenar os registros
                Dim str As StringBuilder = New StringBuilder
                Dim i As Integer = 0
                Dim row As GridViewRow
                'Laço que percorre todas as linhas do grid
                While i < GridView1.Rows.Count
                    'Variável do tipo GridViewRow recebe a linha específica do GridView
                    row = GridView1.Rows(i)
                    'testa o CNPJ
                    If cnpj = row.Cells.Item(0).Text.ToString Then
                        'A variável booleana recebe true se o checkbox desse registro estiver marcado
                        CType(row.FindControl("chkPrincipal"), CheckBox).Checked = True
                        Exit While
                    End If
                    i += 1
                End While
            End If
        End If
    End Sub

    Protected Function gravaPrincipal(ByVal cnpj As String) As Boolean
        Try
            Dim objEmitente As UCLEmitente
            objEmitente = New UCLEmitente
            If Not cnpj = Nothing Then
                Dim objAdesaoParceriaSantanderCNPJ As New UCLAdesaoParceriaSantanderCNPJ(StrConexao)
                objEmitente.gravaPrincipalParceriaSantander(Prop_CodEmitente, cnpj)
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub GravaConferenciaCadastro()
        Try

            Dim objAdesaoParceriaSantander As New UCLAdesaoParceriaSantander(StrConexao)
            objAdesaoParceriaSantander.empresa = 1
            objAdesaoParceriaSantander.cod_emitente = Prop_CodEmitente
            objAdesaoParceriaSantander.Buscar(1, GetSeqAdesaoConvenioAnfarmag(1, objAdesaoParceriaSantander.cod_emitente, Session("S_CNV_TIPO")))
            objAdesaoParceriaSantander.cadastro_conferido = "S"
            objAdesaoParceriaSantander.Alterar(1, GetSeqAdesaoConvenioAnfarmag(1, objAdesaoParceriaSantander.cod_emitente, Session("S_CNV_TIPO")))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluirEstabelecimento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIncluirEstabelecimento.Click

    End Sub

    Private Sub GridDataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim link As LinkButton
        Dim cnpj As String

        If e.Row.RowType = DataControlRowType.DataRow Then
            cnpj = CType(e.Row.FindControl("lblCNPJ"), Label).Text
            link = e.Row.FindControl("LnkAtualizar")
            link.PostBackUrl = "WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=" + cnpj + ""
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Call Voltar()
        Catch ex As Exception
            LblErro.Text = ex.ToString()
        End Try
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Call Voltar()
        Catch ex As Exception
            LblErro.Text = ex.ToString()
        End Try
    End Sub

    Protected Sub Voltar()
        Try
            Dim comando As String = "window.opener.document.forms[0].submit();self.close();"

            Call guardaPrincipal()
            If IsMarcacaoOk() Then
                Call gravaPrincipal(Session("CNPJPrincipal"))
                Call GravaConferenciaCadastro()
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", comando, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum TipoAtualizacaoCadastral As Integer
        SINAMM = 1
        ParceriaSantander = 2
    End Enum

    Private Function GetTipoAtualizacaoCadastral() As TipoAtualizacaoCadastral
        Dim tp As Integer
        If Request.QueryString.Count = 0 Then
            Return TipoAtualizacaoCadastral.SINAMM
        Else
            If Request.QueryString.Item("tp") = 2 Then
                Return TipoAtualizacaoCadastral.ParceriaSantander
            Else
                Return TipoAtualizacaoCadastral.SINAMM
            End If
        End If
    End Function

End Class