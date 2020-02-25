
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim blnTeste As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste").ToString)

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not Page.IsPostBack Then
            Dim objUsuario As New Usuario

            objUsuario.Obter(Session("Usuario"))
            If Not blnTeste Then

                Session("Usuario") = objUsuario.Codigo
                If Session("Usuario") = 0 Then
                    Session.Clear()
                    Session.Abandon()
                    Response.Redirect("lnkAcesso.aspx")
                End If
            Else
                Session("Usuario") = 1
            End If
        End If


    End Sub

End Class


