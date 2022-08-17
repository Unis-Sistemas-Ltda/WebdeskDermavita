Imports System.Web.Mail
Public Class UCLEmail
    Public Sub envia_email(ByVal asSMTP As String, ByVal AsFrom As String, ByVal AsTo As String, ByVal AsSubject As String, ByVal AsCorpo As String, ByVal AsPassword As String, ByVal AsPorta As String, ByVal AsSSL As String)
        Dim ObjMailMessage As New System.Net.Mail.MailMessage

        ObjMailMessage.From = New System.Net.Mail.MailAddress(AsFrom.ToString())
        ObjMailMessage.To.Add(AsTo)
        ObjMailMessage.Subject = AsSubject
        ObjMailMessage.Body = AsCorpo
        ObjMailMessage.Priority = System.Net.Mail.MailPriority.Normal
        ObjMailMessage.IsBodyHtml = True
        '//Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
        ObjMailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        ObjMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

        'cria objeto com os dados do SMTP 
        Dim objSmtp As New System.Net.Mail.SmtpClient

        'Definimos o host -- Endereço do smtp
        objSmtp.Host = asSMTP

        If Not String.IsNullOrEmpty(AsPorta) Then
            objSmtp.Port = AsPorta
        End If

        If Not String.IsNullOrEmpty(AsSSL) Then
            objSmtp.EnableSsl = IIf(AsSSL = "S", "True", "False")
        End If

        '//Definimos a credenciais a serem utilizados
        objSmtp.Credentials = New System.Net.NetworkCredential(AsFrom, AsPassword)

        '//enviamos o e-mail através do método .send() 
        objSmtp.Send(ObjMailMessage)
    End Sub

End Class
