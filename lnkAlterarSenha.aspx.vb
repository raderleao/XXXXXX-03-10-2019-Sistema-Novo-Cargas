Imports System.Data

Partial Class lnkAlterarSenha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing Then
            Response.Redirect("lnkAcesso.aspx")
        End If
        Validacao.Livre(txtSenhaAtual, True, "Senha Atual")
        Validacao.Livre(txtSenhaNova, True, "Nova Senha")
        Validacao.Livre(txtSenhaNovaConfirmacao, True, "Nova Senha Confirmação")
        Validacao.Finalizar(btnAlterar, , True)

    End Sub

    Public Function Criptografar(ByVal strTexto As String) As String
        Criptografar = FormsAuthentication.HashPasswordForStoringInConfigFile(strTexto, "MD5")
    End Function

#Region "Funções de Cadastro"

    Private Sub Salvar()
        Dim objUsuario As New Usuario((Session("Usuario")))

        With objUsuario
            If Criptografar(txtSenhaAtual.Text) = objUsuario.Senha Then
                If txtSenhaNova.Text = txtSenhaNovaConfirmacao.Text Then

                    objUsuario.Senha = Criptografar(txtSenhaNova.Text)
                    objUsuario.Salvar()

                    MsgBox(eTipoMensagem.SALVAR_SUCESSO)
                    LimparCampos()
                Else
                    MsgBox("A Nova Senha não Confirma!")
                End If
            Else
                MsgBox("Senha Atual Incorreta!")
            End If
        End With
        objUsuario = Nothing
    End Sub

    Private Sub LimparCampos()
        txtSenhaAtual.Text = ""
        txtSenhaNova.Text = ""
        txtSenhaNovaConfirmacao.Text = ""
    End Sub

#End Region

#Region "Funçoes dos Botoes"

    Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
        Salvar()
    End Sub

    Protected Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        LimparCampos()
    End Sub

#End Region



End Class
