
Partial Class NewExtranet_ctrTopo
    Inherits System.Web.UI.UserControl

    Protected Sub NewExtranet_ctrTopo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objUsuario As New Usuario
        Dim NomeUsuario() As String

        If Not Page.IsPostBack Then
            objUsuario.Obter(Session("Usuario"))

            If objUsuario.Codigo > 0 Then
                NomeUsuario = objUsuario.Nome.Split
                lblUsuario.Text = objUsuario.Nome
                lblNomeUsuario.Text = objUsuario.Nome
            End If


        End If

        objUsuario = Nothing
    End Sub

End Class
