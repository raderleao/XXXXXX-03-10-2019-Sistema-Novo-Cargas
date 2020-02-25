
Partial Class NewExtranet_ctrMenu
    Inherits System.Web.UI.UserControl
    Dim blnParaTestar As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste"))

    Protected Sub NewExtranet_ctrMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objUsuario As New Usuario
        Dim NomeUsuario() As String

        If Not Page.IsPostBack Then
            objUsuario.Obter(Session("Usuario"))

            If objUsuario.Codigo > 0 Then
                NomeUsuario = objUsuario.Nome.Split
                lblUsuario.Text = NomeUsuario(0)
            End If

            MenuImportacao.Visible = True
            MenuRelatorios.Visible = True
            MenuGerencial.Visible = True

            PerfilUsuario()

        End If

        objUsuario = Nothing
    End Sub

    Private Sub PerfilUsuario()
        Dim objUsuario As New Usuario(Session("Usuario"))
        Dim objPermissao As New Permissao


        If Not blnParaTestar Then

            'If objPermissao.Funcionalidade(Session("Usuario"), 1) > 0 Then 'IMPORTACAO
            '    liImportar.Visible = True
            '    MenuImportacao.Visible = True
            'End If
            If objPermissao.Funcionalidade(Session("Usuario"), 3) > 0 Then 'PROCESSAMENTO
                liProcessar.Visible = True
                MenuImportacao.Visible = True
            End If
            If objPermissao.Funcionalidade(Session("Usuario"), 4) > 0 Then 'ENVIO
                liGerarArquivoTxt.Visible = True
                MenuImportacao.Visible = True
            End If


        Else

            MenuImportacao.Visible = True
            MenuGerencial.Visible = True

            ' liImportar.Visible = True
            liProcessar.Visible = True
            liGerarArquivoTxt.Visible = True
            liConsultasAdmin.Visible = True

        End If

        If objUsuario.Programador Then

            MenuImportacao.Visible = True
            MenuGerencial.Visible = True

            ' liImportar.Visible = True
            liProcessar.Visible = True
            liGerarArquivoTxt.Visible = True
            liConsultasAdmin.Visible = True

        End If

        objUsuario = Nothing
    End Sub
End Class
