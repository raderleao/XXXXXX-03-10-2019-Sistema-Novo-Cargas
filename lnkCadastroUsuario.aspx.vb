
Partial Class lnkCadastroUsuario
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim blnParaTestar As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste"))
            'Dim objUsuario As New Usuario(Session("Usuario"))
            'If Not blnParaTestar Then
            '    If objUsuario.Permissao <> 1 Or Session("Usuario") Is Nothing Then
            '        Response.Redirect("lnkAcesso.aspx")
            '    End If
            'End If
            CarregarComboTabela(drpPermissao, New Permissao)
            CarregarGrid()

            Cadastro.Visible = False
            Listagem.Visible = True

            txtLocalizar.Focus()
        End If

        Validacao.Livre(txtNome, True, "Nome")
        Validacao.Livre(txtlogin, True, "Login")
        Validacao.Livre(txtEmail, True, "E-mail")
        Validacao.Outros(txtCpf, True, "CPF",, Validacao.eFormato.CPF)
        Validacao.Combo(drpPermissao, True, "Permissao")

        Validacao.Finalizar(btnSalvar, , True)

        JavaScript.ExibirConfirmacao(btnNovo, eTipoConfirmacao.NOVO)
        JavaScript.ExibirConfirmacao(btnExcluir, eTipoConfirmacao.EXCLUIR)
        JavaScript.ExibirConfirmacao(btnVoltar, eTipoConfirmacao.VOLTAR)
    End Sub

#Region "Funções de Cadastro"

    Private Sub LimparCampos()
        ViewState("Codigo") = Nothing

        txtNome.Text = ""
        txtCpf.Text = ""
        txtEmail.Text = ""
        txtSenha.Text = ""
        txtlogin.Text = ""
        chkAtivo.Checked = False
        drpPermissao.ClearSelection()

        CarregarGrid()

        txtNome.Focus()
    End Sub

    Private Sub Carregar(ByVal Codigo As Integer)
        Dim objUsuario As New Usuario(Codigo)

        With objUsuario
            ViewState("Codigo") = Codigo

            txtNome.Text = .Nome
            txtCpf.Text = .Cpf
            txtEmail.Text = .Email
            chkAtivo.Checked = .Ativo
            txtlogin.Text = .User
            'SelecionarCombo(drpPermissao, .Permissao)

        End With

        objUsuario = Nothing
    End Sub

    'Public Function Criptografar(ByVal strTexto As String) As String
    '    Criptografar = FormsAuthentication.HashPasswordForStoringInConfigFile(strTexto, "MD5")
    'End Function

    Private Sub Salvar()
        Dim objUsuario As New Usuario(ViewState("Codigo"))
        Dim blnErro As Boolean = False

        With objUsuario
            .Nome = txtNome.Text
            .Cpf = Replace(Replace(Replace(txtCpf.Text, ".", ""), "/", ""), "-", "")
            .User = txtlogin.Text
            .Email = txtEmail.Text
            .Ativo = chkAtivo.Checked
            .DataCadastro = Now
            '.DataUltimaAlteracao = Now
            '.Permissao = drpPermissao.SelectedValue
            'If txtSenha.Text <> "" Then
            '    .Senha = Criptografar(txtSenha.Text)
            'End If

            .Salvar()

            If ViewState("Codigo") Is Nothing Then
                ViewState("Codigo") = .ObterUltimo
            End If
        End With

        MsgBox(eTipoMensagem.SALVAR_SUCESSO)

        objUsuario = Nothing
    End Sub

    Private Sub Excluir()
        Dim objUsuario As New Usuario

        If objUsuario.Excluir(ViewState("Codigo")) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objUsuario = Nothing
    End Sub

    Private Sub Voltar()
        LimparCampos()

        Cadastro.Visible = False
        Listagem.Visible = True

        txtLocalizar.Focus()
    End Sub

#End Region

#Region "Eventos de Cadastro"

    Protected Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        LimparCampos()
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Salvar()
        LimparCampos()
        Cadastro.Visible = False
        Listagem.Visible = True
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Excluir()
        Voltar()
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Voltar()
    End Sub

#End Region

#Region "Funções de Listagem"

    Private Sub CarregarGrid()
        Dim objUsuario As New Usuario

        grdUsuario.DataSource = objUsuario.Pesquisar(, ,, txtLocalizar.Text)
        grdUsuario.DataBind()

        objUsuario = Nothing

        lblRegistros.Text = DirectCast(grdUsuario.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

#End Region

#Region "Eventos de Listagem"

    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadastrar.Click
        Cadastro.Visible = True
        Listagem.Visible = False

        txtNome.Focus()
    End Sub

    Protected Sub btnLocalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLocalizar.Click
        CarregarGrid()
    End Sub

    Protected Sub grdUsuario_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUsuario.RowCommand
        If e.CommandName = "" Then
            Carregar(grdUsuario.DataKeys(e.CommandArgument).Item(0))

            Cadastro.Visible = True
            Listagem.Visible = False
        End If

        txtNome.Focus()
    End Sub

    Private Sub grdUsuario_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdUsuario.PageIndexChanging
        grdUsuario.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Private Sub grdUsuario_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdUsuario.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

#End Region
End Class
