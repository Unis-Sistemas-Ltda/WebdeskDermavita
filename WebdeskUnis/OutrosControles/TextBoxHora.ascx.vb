Partial Public Class TextBoxHora
    Inherits System.Web.UI.UserControl

    Private _MostrarSegundos As Boolean

    Public Property Width() As String
        Get
            Return TextBox1.Width.ToString
        End Get
        Set(ByVal value As String)
            TextBox1.Width = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Property MostrarSegundos() As Boolean
        Get
            Return _MostrarSegundos
        End Get
        Set(ByVal value As Boolean)
            _MostrarSegundos = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mask As String = "??:??"
        If MostrarSegundos Then
            mask += ":??"
        End If
        TextBox1.Attributes.Add("OnKeyPress", "formatacampo(this,'" + mask + "')")
        'TextBox1.Attributes.Add("OnClick", "selecionaCampo(this)")
    End Sub

End Class