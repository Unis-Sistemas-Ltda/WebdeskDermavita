Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ValidaTicket() Then
            Session("SCNPJConexao") = Ticket.Substring(9, 14)
        Else
            Session("SCNPJConexao") = ""
        End If
        If Not String.IsNullOrEmpty(Session("SCNPJConexao")) Then
            Session("SConectaAuto") = "True"
        Else
            Session("SConectaAuto") = "False"
        End If
        Response.Redirect("~/Forms/WFPrincipal.aspx")
    End Sub

    Protected ReadOnly Property Ticket() As String
        Get
            If Not String.IsNullOrEmpty(Request.QueryString.Item("tid")) Then
                Return Request.QueryString.Item("tid").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Private Function ValidaTicket() As Boolean
        Try
            Dim dia As Integer
            Dim mes As Integer
            Dim ano As Integer
            Dim id As Integer
            Dim cnpj As String
            Dim dv As Integer
            Dim dataTicket As DateTime
            Dim soma As Long
            Dim caractere As String

            If String.IsNullOrEmpty(Ticket) Then
                Return False
            End If

            If Ticket.Length <> 26 Then
                Return False
            End If

            If Not IsNumeric(Ticket) Then
                Return False
            End If

            '         0         1         2
            '         01234567890123456789012345
            'Ticket = DDMMAAAAICCCCCCCCCCCCCCVVV
            ' HH - Hora
            ' MM - Minuto
            ' DD - Dia
            ' MM - Mes
            ' AAAA - Ano
            ' I - 0 para CNPJ / 1 para CPF
            ' CCCCCCCCCCCCCC - CNPJ/CPF
            ' V - Digitos Verificadores

            dia = Ticket.Substring(0, 2)
            mes = Ticket.Substring(2, 2)
            ano = Ticket.Substring(4, 4)
            id = Ticket.Substring(8, 1)
            cnpj = Ticket.Substring(9, 14)
            dv = Ticket.Substring(23, 3)

            dia = dia / 3
            mes = mes / 5
            cnpj = cnpj.Trim

            If id < 0 OrElse id > 1 Then
                Return False
            End If

            If cnpj.Length <> 11 And cnpj.Length <> 14 Then
                Return False
            End If

            If dia < 0 OrElse dia > 31 Then
                Return False
            End If

            If mes < 0 OrElse mes > 12 Then
                Return False
            End If

            If ano < 2012 OrElse ano > 2100 Then
                Return False
            End If

            dataTicket = New DateTime(ano, mes, dia)

            'Se a diferença é maior que 2 dias, não permite logar automaticamente
            If Math.Abs(DateDiff(DateInterval.Day, dataTicket, Now)) > 2 Then
                Return False
            End If

            soma = 0
            For i As Integer = 0 To 22
                caractere = Ticket.Substring(i, 1)
                If IsNumeric(caractere) Then
                    soma += CInt(caractere)
                End If
            Next

            If (300 - soma) <> dv Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class