Partial Public Class TextBoxCNPJCPF
    Inherits System.Web.UI.UserControl

    Private _Text As String
    Private _AutoPostBack As String
    Private _Width As String
    Private _Tipo As String

    Public Enum TipoEdicao
        CNPJ = 1
        CPF = 2
    End Enum

    Public Property Tipo() As TipoEdicao
        Get
            Return _Tipo
        End Get
        Set(ByVal value As TipoEdicao)
            _Tipo = value
        End Set
    End Property

    Public Property Text() As String
        Get
            If Tipo = TipoEdicao.CNPJ Then
                _Text = TextBoxCNPJ1.Text
            ElseIf Tipo = TipoEdicao.CPF Then
                _Text = TextBoxCPF1.Text
            End If
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            If Tipo = TipoEdicao.CNPJ Then
                TextBoxCNPJ1.Text = _Text
            ElseIf Tipo = TipoEdicao.CPF Then
                _TextBoxCPF1.Text = _Text
            End If
        End Set
    End Property

    Public Property AutoPostBack() As Boolean
        Get
            If Tipo = TipoEdicao.CNPJ Then
                _AutoPostBack = TextBoxCNPJ1.AutoPostBack
            ElseIf Tipo = TipoEdicao.CPF Then
                _AutoPostBack = TextBoxCPF1.AutoPostBack
            End If
            Return _AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            _AutoPostBack = value
            If Tipo = TipoEdicao.CPF Then
                TextBoxCPF1.AutoPostBack = value
            Else
                TextBoxCNPJ1.AutoPostBack = value
            End If
        End Set
    End Property

    Public Property Width() As String
        Get
            If Tipo = TipoEdicao.CNPJ Then
                _Width = TextBoxCNPJ1.Width
            ElseIf Tipo = TipoEdicao.CPF Then
                _Width = TextBoxCPF1.Width
            End If
            Return _Width
        End Get
        Set(ByVal value As String)
            _Width = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Tipo = TipoEdicao.CNPJ Then
                TextBoxCNPJ1.Visible = True
                TextBoxCPF1.Visible = False
                If Not String.IsNullOrEmpty(Width) Then
                    TextBoxCNPJ1.Width = Width
                End If
                TextBoxCNPJ1.AutoPostBack = AutoPostBack
                TextBoxCNPJ1.Text = Text
            ElseIf Tipo = TipoEdicao.CPF Then
                TextBoxCNPJ1.Visible = False
                TextBoxCPF1.Visible = True
                If Not String.IsNullOrEmpty(Width) Then
                    TextBoxCPF1.Width = Width
                End If
                TextBoxCPF1.AutoPostBack = AutoPostBack
                TextBoxCPF1.Text = Text
            End If
        End If
    End Sub

End Class