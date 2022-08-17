Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq

Partial Public Class WUCContato
    Inherits System.Web.UI.UserControl

    Public Property Acao() As String
        Get
            Return LblAcao.Text
        End Get
        Set(ByVal value As String)
            LblAcao.Text = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return LblCodEmitente.Text
        End Get
        Set(ByVal value As String)
            LblCodEmitente.Text = value
        End Set
    End Property

    Public Property CodContato() As String
        Get
            Return LblCodContato.Text
        End Get
        Set(ByVal value As String)
            LblCodContato.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub Bind()
        If Acao = "ALTERAR" Then
            Call CarregaFormulario()
            LblTitulo.Text = "Alteração de Dados de Contato"
        ElseIf Acao = "INCLUIR" Then
            Call CarregaNovaPK()
            Call LimpaCampos()
            LblTitulo.Text = "Novo Contato"
        End If
    End Sub

    Private Sub LimpaCampos()
        Try
            TxtNome.Text = ""
            TxtTitulo.Text = ""
            TxtTelefone1.Text = ""
            TxtTelefone2.Text = ""
            TxtCelular1.Text = ""
            TxtCelular2.Text = ""
            TxtFax.Text = ""
            TxtEmail.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjContato As New UCLContato
        LblCodContato.Text = CodContato

        ObjContato.CodEmitente = CodEmitente
        ObjContato.Codigo = CodContato
        ObjContato.Buscar()

        TxtNome.Text = ObjContato.Nome
        TxtTitulo.Text = ObjContato.Titulo
        RblPreferencial.SelectedValue = ObjContato.Preferencial
        RblAtivo.SelectedValue = ObjContato.Ativo
        TxtTelefone1.Text = ObjContato.Telefone
        TxtTelefone2.Text = ObjContato.Telefone2
        TxtCelular1.Text = ObjContato.Celular
        TxtCelular2.Text = ObjContato.Celular2
        TxtFax.Text = ObjContato.Fax
        TxtEmail.Text = ObjContato.Email

    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjContato As New UCLContato
        ObjContato.CodEmitente = CodEmitente
        LblCodContato.Text = ObjContato.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Function Gravar() As Boolean
        Dim ObjContato As New UCLContato

        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjContato.CodEmitente = CodEmitente
                    ObjContato.Codigo = LblCodContato.Text
                    ObjContato.Buscar()
                    ObjContato = CarregaObjeto(ObjContato)
                    ObjContato.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjContato.CodEmitente = CodEmitente
                    ObjContato.Codigo = LblCodContato.Text
                    ObjContato = CarregaObjeto(ObjContato)
                    ObjContato.Incluir()
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
            Throw ex
        End Try
    End Function

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        If String.IsNullOrEmpty(TxtEmail.Text) Then
            LblErro.Text += "Preencha o campo E-mail.<br/>"
        ElseIf Not TxtEmail.Text.IsValidEmail Then
            LblErro.Text += "O E-mail informado não é válido. Por favor verifique se informou o e-mail corretamente. Lembramos ainda que, neste campo, você deve informar apenas um endereço de e-mail.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjContato As UCLContato) As UCLContato

        ObjContato.Nome = TxtNome.Text
        ObjContato.Titulo = TxtTitulo.Text
        ObjContato.Preferencial = RblPreferencial.SelectedValue
        ObjContato.Ativo = RblAtivo.SelectedValue
        ObjContato.Telefone = TxtTelefone1.Text
        ObjContato.Telefone2 = TxtTelefone2.Text
        ObjContato.Celular = TxtCelular1.Text
        ObjContato.Celular2 = TxtCelular2.Text
        ObjContato.Fax = TxtFax.Text
        ObjContato.Email = TxtEmail.Text

        Return ObjContato
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Call Voltar()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Public Sub Voltar()
        Try
            '
        Catch ex As Exception
            LblErro.Text = ex.Message
            Throw ex
        End Try
    End Sub
End Class