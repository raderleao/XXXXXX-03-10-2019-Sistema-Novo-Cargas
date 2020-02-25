Partial Class lnkAcesso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("Usuario") Is Nothing Then
                'Caso tenha usuário ativo, faz logoff

                Session("Usuario") = Nothing
            End If

            Session.Clear()
            Session.Abandon()
        End If

        Validacao.Livre(txtLogin, True, "Login", "loginN")
        Validacao.Livre(txtSenha, True, "Senha", "loginN")

        Validacao.Finalizar(btnEntrarN, "loginN")
    End Sub

    Protected Sub btnEntrarN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntrarN.Click
        Dim objUsuario As New Usuario
        Dim strHtml As New StringBuilder

        With objUsuario.Pesquisar(,, RTrim(LTrim(txtLogin.Text)))

            If .Rows.Count > 0 Then

                If FormsAuthentication.HashPasswordForStoringInConfigFile(txtSenha.Text, "MD5") = .Rows(0)("AC06_SENHA") Then
                    Dim CodigoUsuario As Integer = .Rows(0)("AC06_COD_USUARIO")

                    objUsuario.Obter(CodigoUsuario)

                    If .Rows(0)("DIAS_SEM_ACESSO") >= 45 Then
                        objUsuario.Ativo = False
                        objUsuario.DataUltimoAcesso = Now
                        objUsuario.Salvar()

                        strHtml.Append("Usuário inativo, entre em contato com o Suporte!")
                        sMsgErroLogin.Controls.Add(New Literal() With {
                              .Text = strHtml.ToString()
                            })
                        Exit Sub
                    End If

                    objUsuario.DataUltimoAcesso = Now
                    objUsuario.Salvar()

                    If Not objUsuario.Ativo Then
                        strHtml.Append("Usuário inativo, entre em contato com o Suporte!")
                        sMsgErroLogin.Controls.Add(New Literal() With {
                              .Text = strHtml.ToString()
                            })
                        Exit Sub
                    End If

                    Session("Usuario") = CodigoUsuario
                Else
                    strHtml.Append("Senha Inválida!")
                    sMsgErroLogin.Controls.Add(New Literal() With {
                              .Text = strHtml.ToString()
                            })
                End If
            Else
                strHtml.Append("Usuário Inválido!")
                sMsgErroLogin.Controls.Add(New Literal() With {
                              .Text = strHtml.ToString()
                            })

                Session("Usuario") = Nothing
            End If

        End With

        If Not Session("Usuario") Is Nothing Then
            Response.Redirect("lnkBemVindo.aspx")
        End If
    End Sub

End Class
