Imports System.Text.RegularExpressions

Module Extensions

    Private ReadOnly _RegExInputValido As String = "[\w][-!#$%&()*+,./:;=?@[\\\]`{|}~]"
    Private ReadOnly _RegExEmailValido As String = "^[a-z0-9\._\-]+\@+[a-z0-9\._\-]+\.[a-z]+$"

    <System.Runtime.CompilerServices.Extension()> Public Function EncriptarNumero(ByVal s As String) As String
        Dim resp As String = ((CInt(s) * 3211) - 3).ToString
        Dim dv As String = 9 - Right(resp, 1)

        Return resp & dv
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function DecriptarNumero(ByVal s As String) As String
        Return (CInt(Left(s, s.Length - 1)) + 3) / 3211
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function IsEncriptadoValido(ByVal s As String) As Boolean
        Dim dvEncontrado As String = Right(s, 1)
        Dim dvDevido As String = 9 - s.Substring(s.Length - 2, 1)

        Return dvEncontrado = dvDevido
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function IsValidEmail(ByVal s As String) As Boolean
        Dim emails As String()
        If String.IsNullOrEmpty(s) Then
            Return False
        End If
        s = s.Replace(";", ",")
        If s.Contains(",") Then
            emails = s.Trim.Split(",")
            For Each email As String In emails
                If String.IsNullOrEmpty(email) Then
                    Return False
                End If
                If Not (Regex.IsMatch(email.Trim, _RegExEmailValido)) Then
                    Return False
                End If
            Next
        Else
            If Not (Regex.IsMatch(s, _RegExEmailValido)) Then
                Return False
            End If
        End If

        Return True
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function IsValidInputContent(ByRef s As String) As Boolean
        If Not (Regex.IsMatch(s, _RegExInputValido)) Then
            Return False
        End If

        Return True
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function GetValidInputContent(ByVal s As String) As String
        Return TrocaCaracteresInvalidos(s)

        Return True
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function isCNPJMesmaRaiz(ByRef s1 As String, ByVal s2 As String) As Boolean
        Dim raiz1, raiz2 As String
        s1 = s1.Trim
        s2 = s2.Trim

        If s1.Length = 14 And s2.Length = 14 Then
            raiz1 = s1.Substring(0, 8)
            raiz2 = s2.Substring(0, 8)

            If raiz1 = raiz2 Then
                Return True
            End If
        End If

        Return False
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function MascaraCNPJ(ByRef s As String) As String
        s = s.ToString
        s = s.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace(".", "")
        If Not IsNumeric(s) Then
            Return s
        End If
        Return CDbl(s).ToString("00\.000\.000\/0000\-00")
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function RemoveMascaraCNPJ_CPF_CEP(ByRef s As String) As String
        Return s.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace(".", "")
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function MascaraCPF(ByRef s As String) As String
        s = s.ToString
        s = s.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace(".", "")
        If Not IsNumeric(s) Then
            Return s
        End If
        Return CDbl(s).ToString("000\.000\.000\-00")
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function MascaraCEP(ByRef s As String) As String
        s = s.ToString
        s = s.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace(".", "")
        If Not IsNumeric(s) Then
            Return s
        End If
        Return CDbl(s).ToString("00000\-000")
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function IsValidCNPJ(ByVal strCNPJ As String) As Boolean
        strCNPJ = strCNPJ.Replace("-", "").Replace("/", "").Replace("\", "").Replace(".", "").Replace(" ", "")
        IsValidCNPJ = False
        Dim a, j, d1, d2 As Double
        Dim i As Integer
        If Len(strCNPJ) <> 14 Then
            IsValidCNPJ = False
            Exit Function
        End If
        If Not IsNumeric(strCNPJ) Then
            IsValidCNPJ = False
            Exit Function
        End If
        a = 0
        i = 0
        d1 = 0
        d2 = 0
        j = 5
        For i = 1 To 12 Step 1
            a = a + (Val(Mid(strCNPJ, i, 1)) * j)
            j = Convert.ToDouble(IIf(j > 2, j - 1, 9))
        Next i
        a = a Mod 11
        d1 = Convert.ToDouble(IIf(a > 1, 11 - a, 0))
        a = 0
        i = 0
        j = 6
        For i = 1 To 13 Step 1
            a = a + (Val(Mid(strCNPJ, i, 1)) * j)
            j = Convert.ToDouble(IIf(j > 2, j - 1, 9))
        Next i
        a = a Mod 11
        d2 = Convert.ToDouble(IIf(a > 1, 11 - a, 0))
        If (d1 = Val(Mid(strCNPJ, 13, 1)) And d2 = Val(Mid(strCNPJ, 14, 1))) Then
            IsValidCNPJ = True
        Else
            IsValidCNPJ = False
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function IsValidCPF(ByVal s As String) As Boolean
        Dim valor As String = s.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace(" ", "")
        Dim igual As Boolean = True
        Dim i As Integer = 1

        If valor.Length <> 11 Then
            Return False
        End If
        If Not IsNumeric(valor) Then
            Return False
        End If
        While i < 11 AndAlso igual
            If valor(i) <> valor(0) Then
                igual = False
            End If
            i += 1
        End While
        If igual OrElse valor = "12345678909" Then
            Return False
        End If
        Dim numeros As Integer() = New Integer(10) {}
        For i = 0 To 10
            numeros(i) = Integer.Parse(valor(i).ToString())
        Next
        Dim soma As Integer = 0
        For i = 0 To 8
            soma += (10 - i) * numeros(i)
        Next
        Dim resultado As Integer = soma Mod 11
        If resultado = 1 OrElse resultado = 0 Then
            If numeros(9) <> 0 Then
                Return False
            End If
        ElseIf numeros(9) <> 11 - resultado Then
            Return False
        End If
        soma = 0
        For i = 0 To 9
            soma += (11 - i) * numeros(i)
        Next
        resultado = soma Mod 11
        If resultado = 1 OrElse resultado = 0 Then
            If numeros(10) <> 0 Then
                Return False
            End If
        ElseIf numeros(10) <> 11 - resultado Then
            Return False
        End If
        Return True
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function NumeroInteiroExtenso(ByVal number As Long) As String
        Try
            Return getInteger(number)
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function ValorExtenso(ByVal number As Decimal) As String
        Dim cent As Integer

        Try
            ' Verifica a parte decimal, ou seja, os centavos
            cent = Decimal.Round((number - Int(number)) * 100, MidpointRounding.ToEven)

            ' Verifica apenas a parte inteira
            number = Int(number)

            ' Caso existam centavos
            If cent > 0 Then
                ' Caso seja 1 não coloca "reais" mas sim "real"
                If number = 1 Then
                    Return "Um Real e " + getDecimal(cent) + "Centavos"
                Else
                    Return getInteger(number) + "Reais e " + getDecimal(cent) + "Centavos"
                End If
            Else
                ' Caso seja 1 não coloca "reais" mas sim "real"
                If number = 1 Then
                    Return "Um Real"
                Else
                    Return getInteger(number) + "Reais"
                End If
            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function getDecimal(ByVal number As Byte) As String

        Try
            Select Case number
                Case 0

                    Return ""

                Case 1 To 19

                    Dim strArray() As String = {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Catorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "

                Case 20 To 99

                    Dim strArray() As String = {"Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2) + " "
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getDecimal(number Mod 10) + " "
                    End If

                Case Else

                    Return ""

            End Select

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function getInteger(ByVal number As Decimal) As String

        Try
            number = Int(number)

            Select Case number

                Case Is < 0

                    Return "-" & getInteger(-number)

                Case 0

                    Return ""

                Case 1 To 19

                    Dim strArray() As String = {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "

                Case 20 To 99

                    Dim strArray() As String = {"Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2) + " "
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getInteger(number Mod 10)
                    End If

                Case 100

                    Return "Cem"

                Case 101 To 999

                    Dim strArray() As String = {"Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos"}

                    If (number Mod 100) = 0 Then
                        Return strArray(number \ 100 - 1) + " "
                    Else
                        Return strArray(number \ 100 - 1) + " e " + getInteger(number Mod 100)
                    End If

                Case 1000 To 1999

                    Select Case (number Mod 1000)
                        Case 0
                            Return "Um Mil "
                        Case Is <= 100, 200, 300, 400, 500, 600, 700, 800, 900
                            Return "Um Mil e " + getInteger(number Mod 1000)
                        Case Else
                            Return "Um Mil, " + getInteger(number Mod 1000)
                    End Select

                Case 2000 To 999999

                    Select Case (number Mod 1000)
                        Case 0
                            Return getInteger(number \ 1000) & "Mil "
                        Case Is <= 100, 200, 300, 400, 500, 600, 700, 800, 900
                            Return getInteger(number \ 1000) & "Mil e " & getInteger(number Mod 1000)
                        Case Else
                            Return getInteger(number \ 1000) & "Mil, " & getInteger(number Mod 1000)
                    End Select

                Case 1000000 To 1999999

                    Select Case (number Mod 1000000)
                        Case 0
                            Return "Um Milhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhão e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhão, " & getInteger(number Mod 1000000)
                    End Select

                Case 2000000 To 999999999

                    Select Case (number Mod 1000000)

                        Case 0
                            Return getInteger(number \ 1000000) + " Milhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhões e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhões, " & getInteger(number Mod 1000000)
                    End Select

                Case 1000000000 To 1999999999

                    Select Case (number Mod 1000000000)
                        Case 0
                            Return "Um Bilhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhão e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhão, " + getInteger(number Mod 1000000000)
                    End Select

                Case Else

                    Select Case (number Mod 1000000000)

                        Case 0

                            Return getInteger(number \ 1000000000) + " Bilhões"

                        Case Is <= 100

                            Return getInteger(number \ 1000000000) + "Bilhões e " + getInteger(number Mod 1000000000)

                        Case Else

                            Return getInteger(number \ 1000000000) + "Bilhões, " + getInteger(number Mod 1000000000)

                    End Select

            End Select

        Catch ex As Exception

            Return ""

        End Try

    End Function

    Public Function TrocaCaracteresInvalidos(ByVal s As String) As String
        s = s.Replace(Chr(34), "``")
        s = s.Replace("'", "`")
        s = s.Replace("<", " menor que ")
        s = s.Replace(">", " maior que ")
        Return s
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function isValidDate(ByVal s As String) As Boolean
        Dim dia As Int32
        Dim mes As Int32
        Dim ano As Int32
        Dim strDia As String
        Dim strMes As String
        Dim strAno As String
        Dim posBarra1 As Int16
        Dim posBarra2 As Int16

        If s.ToString.Trim = "" Then
            Return False 'Empty input
        End If

        posBarra1 = s.IndexOf("/")
        If posBarra1 = -1 Then
            Return False 'No slash
        Else
            posBarra2 = s.IndexOf("/", posBarra1 + 1)
            If posBarra2 = -1 Then
                Return False 'It should have two slashes
            End If
        End If

        strDia = s.Substring(0, posBarra1)
        strMes = s.Substring(posBarra1 + 1, posBarra2 - posBarra1 - 1)
        strAno = s.Substring(posBarra2 + 1)

        If Not IsNumeric(strDia) Then
            Return False 'Day is not a valid number
        End If

        If Not IsNumeric(strMes) Then
            Return False 'Month is not a valid number
        End If

        If Not IsNumeric(strAno) Then
            Return False 'Year is not a valid number
        End If

        dia = strDia
        mes = strMes
        ano = strAno

        ' Determine whether the given date exists in the current Gregorian calendar
        If mes >= 1 And mes <= 12 And ano <= 9999 And ano >= 1 And dia >= 1 And dia <= 31 Then
            If dia >= 1 Then
                ' Compare to maximum days in this month
                If dia <= Date.DaysInMonth(ano, mes) Then
                    Return True  ' Valid date
                Else
                    Return False ' Day exceeds max days in month
                End If
            Else
                Return False ' Day cannot be below 1
            End If
        Else
            Return False ' Invalid month or invalid year or day out of range
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> Public Function FirstLetterUpperCase(ByVal strFrase As String) As String
        Dim strFraseAlterada As String
        Dim intQtdCaracteresFrase As Integer
        Dim intPosicao As Integer
        Dim bolEspaco As Boolean

        If strFrase Is Nothing Then
            strFrase = ""
        End If
        strFrase = strFrase.ToLower
        strFraseAlterada = ""
        intQtdCaracteresFrase = Len(strFrase)
        intPosicao = 1
        bolEspaco = False

        Do While intPosicao <= intQtdCaracteresFrase
            If intPosicao = 1 Then
                strFraseAlterada = UCase(Mid(strFrase, intPosicao, 1))
            End If

            If Mid(strFrase, intPosicao, 1) = " " Then
                bolEspaco = True
                strFraseAlterada = strFraseAlterada & " "
            End If

            If (bolEspaco = False) And (intPosicao <> 1) Then
                strFraseAlterada = strFraseAlterada & Mid(strFrase, intPosicao, 1)
            ElseIf (bolEspaco = True) And (Mid(strFrase, intPosicao, 1) <> " ") Then
                bolEspaco = False
                strFraseAlterada = strFraseAlterada & UCase(Mid(strFrase, intPosicao, 1))
            End If

            intPosicao = intPosicao + 1
        Loop

        Return strFraseAlterada
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function RetiraAcentos(strcomAcentos As String) As String
        Dim strsemAcentos As String = strcomAcentos
        strsemAcentos = Regex.Replace(strsemAcentos, "[äáàâãª]", "a")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ÄÁÀÂÃ]", "A")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ëéèê]", "e")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ËÉÈÊ]", "E")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ïíìî]", "i")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ÏÍÌÎ]", "I")
        strsemAcentos = Regex.Replace(strsemAcentos, "[öóòôõº]", "o")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ÖÓÒÔÕ]", "O")
        strsemAcentos = Regex.Replace(strsemAcentos, "[üúùû]", "u")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ÜÚÙÛ]", "U")
        strsemAcentos = Regex.Replace(strsemAcentos, "[ç]", "c")
        strsemAcentos = Regex.Replace(strsemAcentos, "[Ç]", "C")
        Return strsemAcentos
    End Function

    <System.Runtime.CompilerServices.Extension()> Function PadLeftUnis(ByVal texto As String, tamanho As Integer, preenchercom As String) As String
        Try
            If texto.Length > tamanho Then
                texto = texto.Substring(0, tamanho)
            End If
            Return texto.PadLeft(tamanho, preenchercom)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Runtime.CompilerServices.Extension()> Function PadRightUnis(ByVal texto As String, tamanho As Integer, preenchercom As String) As String
        Try
            If texto.Length > tamanho Then
                texto = texto.Substring(0, tamanho)
            End If
            Return texto.PadRight(tamanho, preenchercom)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Module
