

Public Class Utilidades

    Public Shared Function CPF_Valido(ByVal CPF As String) As Boolean
        Dim dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim

        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 14 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next

        'remove a maskara
        CPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12)

        For x = 0 To 1
            n1 = 0

            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next

            n2 = 11 - (n1 - (Int(n1 / 11) * 11))

            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Shared Function DataCompleta(ByVal Data As Date) As String
        Dim strMes As String

        Select Case Month(Data)
            Case 1
                strMes = "Janeiro"
            Case 2
                strMes = "Fevereiro"
            Case 3
                strMes = "Março"
            Case 4
                strMes = "Abril"
            Case 5
                strMes = "Maio"
            Case 6
                strMes = "Junho"
            Case 7
                strMes = "Julho"
            Case 8
                strMes = "Agosto"
            Case 9
                strMes = "Setembro"
            Case 10
                strMes = "Outubro"
            Case 11
                strMes = "Novembro"
            Case 12
                strMes = "Dezembro"
            Case Else

                strMes = ""

        End Select

        Return Day(Data) & " de " & strMes & " de " & Year(Data)

    End Function

    Public Shared Function Meses(Optional ByVal PrimeiroItem As String = "") As Data.DataTable
        Dim dtMeses As New Data.DataTable
        Dim drMeses As Data.DataRow

        dtMeses.Columns.Add("CODIGO")
        dtMeses.Columns.Add("DESCRICAO")

        drMeses = dtMeses.NewRow
        drMeses("CODIGO") = ""
        drMeses("DESCRICAO") = PrimeiroItem
        dtMeses.Rows.Add(drMeses)

        For x = 1 To 12
            drMeses = dtMeses.NewRow
            drMeses("CODIGO") = x
            Select Case x
                Case 1
                    drMeses("DESCRICAO") = "JANEIRO"
                Case 2
                    drMeses("DESCRICAO") = "FEVEREIRO"
                Case 3
                    drMeses("DESCRICAO") = "MARÇO"
                Case 4
                    drMeses("DESCRICAO") = "ABRIL"
                Case 5
                    drMeses("DESCRICAO") = "MAIO"
                Case 6
                    drMeses("DESCRICAO") = "JUNHO"
                Case 7
                    drMeses("DESCRICAO") = "JULHO"
                Case 8
                    drMeses("DESCRICAO") = "AGOSTO"
                Case 9
                    drMeses("DESCRICAO") = "SETEMBRO"
                Case 10
                    drMeses("DESCRICAO") = "OUTUBRO"
                Case 11
                    drMeses("DESCRICAO") = "NOVEMBRO"
                Case 12
                    drMeses("DESCRICAO") = "DEZEMBRO"
            End Select
            dtMeses.Rows.Add(drMeses)
        Next

        Return dtMeses
    End Function

    Public Shared Sub DownloadFile(ByVal CaminhoOrigem As String, ByVal NomeDestino As String)

        Dim executingPage As Object = HttpContext.Current.Handler
        Dim fullpath As String = System.IO.Path.GetFullPath(CaminhoOrigem)
        Dim name As String = System.IO.Path.GetFileName(fullpath)
        Dim ext As String = System.IO.Path.GetExtension(fullpath).ToLower
        Dim Type As String = ""

        Select Case ext
            Case ".htm", ".html"
                Type = "text/HTML"
            Case ".txt"
                Type = "text/plain"
            Case ".doc", ".rtf"
                Type = "Application/msword"
            Case ".csv", ".xls"
                Type = "Application/x-msexcel"
            Case ".pdf"
                Type = "application/pdf"
            Case Else
                Type = "text/plain"
        End Select

        Try
            executingPage.Response.AppendHeader("content-disposition", "attachment; filename=" + NomeDestino)
            executingPage.Response.ContentType = Type
            executingPage.Response.WriteFile(fullpath)
            executingPage.Response.End()

        Catch
            MsgBox("Arquivo não Encontrado!")
        End Try

    End Sub

    Public Shared Function SenhaRandomica(Optional ByVal Tamanho As Integer = 6, Optional ByVal UsarLetras As Boolean = True, Optional ByVal UsarNumeros As Boolean = True) As String
        'a - z = 97 - 122
        '0 - 9 = 48 - 57
        Dim x As String

        SenhaRandomica = ""

        If UsarLetras = False And UsarNumeros = False Then
            Return SenhaRandomica
        End If

        While Len(SenhaRandomica) < Tamanho
            Randomize()
            'Int((Rnd * (Maximo * 1000) - 1) / 1000) + 1
            x = CInt(Rnd() * 1000)
            If (x >= 48 And x <= 57 And UsarNumeros = True) Or (x >= 97 And x <= 122 And UsarLetras = True) Then
                SenhaRandomica = SenhaRandomica & Chr(x)
            End If
        End While
    End Function

    Public Shared Function ObterAtributoStringConexao(ByVal StringConexao As String, ByVal Atributo As String) As String
        Return Mid(Mid(StringConexao, InStr(StringConexao, Atributo, CompareMethod.Text), InStr(InStr(StringConexao, Atributo, CompareMethod.Text), StringConexao, ";", CompareMethod.Text) - InStr(StringConexao, Atributo, CompareMethod.Text)), Len(Atributo) + 2)
    End Function

    Public Shared Function Encript(ByVal VarTxt$) As String
        Dim TxtCript$, i%

        TxtCript = ""

        For i = 1 To Len(VarTxt)
            TxtCript = TxtCript & Chr(Asc(Mid$(VarTxt, i, 1)) + 130 - i)
        Next

        Encript = TxtCript
    End Function

    Public Shared Function Decript(ByVal VarTxt$) As String
        Dim TxtCript$, i%

        On Error Resume Next

        TxtCript = ""

        For i = 0 To Len(VarTxt)
            TxtCript = TxtCript & Chr(Asc(Mid$(VarTxt, Len(VarTxt) - i, 1)) - 130 + Len(VarTxt) - i)
        Next

        Decript = StrReverse(TxtCript)

    End Function

    Public Shared Function EnviarEmail(ByVal Assunto As String, ByVal Mensagem As String, ByVal Destinatario As String, Optional ByVal Anexo As String = "") As Boolean
        Dim Destinatarios(0) As Net.Mail.MailAddress
        Dim Anexos(0) As Net.Mail.Attachment

        Destinatarios(0) = New Net.Mail.MailAddress(Destinatario)
        If Anexo <> "" Then
            Anexos(0) = New Net.Mail.Attachment(Anexo)
        End If

        Return EnviarEmail(Assunto, Mensagem, Destinatarios, Anexos)
    End Function

    Public Shared Function EnviarEmail(ByVal Assunto As String, ByVal Mensagem As String, ByVal Destinatarios() As Net.Mail.MailAddress, Optional ByVal Anexos() As Net.Mail.Attachment = Nothing) As Boolean
        Dim objEmail As New System.Net.Mail.MailMessage

        Try
            objEmail.From = New System.Net.Mail.MailAddress("seletivo2@seap.ma.gov.br", "Seletivo SEAP")

            For Each Destinatario As System.Net.Mail.MailAddress In Destinatarios
                If Not Destinatario Is Nothing Then
                    objEmail.To.Add(Destinatario)
                End If
            Next

            If Not Anexos Is Nothing Then
                For Each Anexo As Net.Mail.Attachment In Anexos
                    If Not Anexo Is Nothing Then
                        objEmail.Attachments.Add(Anexo)
                    End If
                Next
            End If

            objEmail.Priority = System.Net.Mail.MailPriority.Normal
            objEmail.IsBodyHtml = True

            objEmail.Subject = Assunto
            objEmail.Body = Mensagem

            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

            Dim objSmtp As New System.Net.Mail.SmtpClient

            Dim basicAuthenticationInfo As New System.Net.NetworkCredential("seletivo2@seap.ma.gov.br", "asdqwe123")

            objSmtp.Host = "mta.ma.gov.br"
            'objSmtp.Port = "587"
            objSmtp.UseDefaultCredentials = False
            objSmtp.Credentials = basicAuthenticationInfo
            objSmtp.EnableSsl = True

            objSmtp.Send(objEmail)

            objEmail.Dispose()

            objEmail = Nothing

            Return True

        Catch ex As Exception
            Return False

        End Try

    End Function

    Public Shared Function Abreviado(ByVal Palavra As String) As Boolean
        Dim Retorno As Boolean = False
        Dim i As Integer

        For i = 0 To Palavra.Length - 1
            If Palavra(i) = "." Then
                Retorno = True
            End If
            If i <> 0 And i <> (Palavra.Length - 1) Then
                If Palavra(i - 1) = " " And Palavra(i + 1) = " " Then
                    Retorno = True
                End If
            ElseIf i = (Palavra.Length - 1) Then
                If Palavra(i - 1) = " " Then
                    Retorno = True
                End If
            ElseIf i = 0 Then
                If Palavra(i + 1) = " " Then
                    Retorno = True
                End If
            End If

        Next

        Return Retorno
    End Function

    Public Shared Function NewID() As String
        Dim Retorno As String = ""
        Dim cnn As New Conexao

        Try
            Retorno = cnn.AbrirDataTable("select NEWID() ").Rows(0)(0).ToString
        Catch ex As Exception

        End Try

        cnn = Nothing
        Return Retorno
    End Function

    Public Shared Function FormatarValor(ByVal Valor As String, ByVal Tipo As Integer) As String
        Select Case Tipo
            Case 1 'FORMATO PARA DATAS DO TIPO DATE
                Valor = Valor.Substring(0, 4) & "-" & Valor.Substring(4, 2) & "-" & Valor.Substring(6, 2)
            Case 2 'FORMATO PARA HORA)
                Valor = Valor.Substring(0, 2) & ":" & Valor.Substring(2, 2)
            Case 3 'FORMATO PARA DATS DO TIPO DATEIME
                Valor = Valor.Substring(0, 4) & "-" & Valor.Substring(4, 2) & "-" & Valor.Substring(6, 2) & " " & Valor.Substring(8, 2) & ":" & Valor.Substring(10, 2)
            Case 4 'FORMATO PARA VALORES(DINHEIRO)
                Valor = Valor.Substring(0, (Valor.Length - 2)) & "," & Valor.Substring(Valor.Length - 2)
        End Select


        Return Valor
    End Function

    Public Shared Function ZeroEsquerda(ByVal Valor As String, ByVal TamanhoString As Integer) As String
        Dim aux As Integer
        Dim nome As String = ""
        Dim resultado As String

        aux = TamanhoString - Valor.Length

        For i = 1 To aux
            nome = nome & 0
        Next
        resultado = nome & Valor

        Return resultado

    End Function

End Class