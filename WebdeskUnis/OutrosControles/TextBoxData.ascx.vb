Partial Public Class TextBoxData
    Inherits System.Web.UI.UserControl

    Private _QtdCasas As String

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        'TextBox1.Attributes.Add("OnClick", "selecionaCampo(this)")
    End Sub

End Class