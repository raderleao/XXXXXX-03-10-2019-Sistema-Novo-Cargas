<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lnkAlterarSenha.aspx.vb" Inherits="lnkAlterarSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/frmAlterarSenha.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Senha
            <small>Alteração</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="lnkBemVindo.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Alterar Senha</li>
        </ol>
    </section>
    <section id="Cadastro" runat="server" class="content">
        <asp:Panel ID="Panel1" runat="server" CssClass="panel" DefaultButton="btnAlterar">
            <div class="box box-blue">
                <div class="box-body">
                    <div class="row">
                        <div class="form-group col-sm-4">
                            Senha Atual<br />
                            <asp:TextBox ID="txtSenhaAtual" runat="server" MaxLength="20" TextMode="Password" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-sm-4">
                            Nova Senha<br />
                            <asp:TextBox ID="txtSenhaNova" runat="server" MaxLength="20" TextMode="Password" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-sm-4">
                            Confirmação<br />
                            <asp:TextBox ID="txtSenhaNovaConfirmacao" runat="server" MaxLength="20" TextMode="Password" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <div class="btn-group">
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" Visible="false" class="btn btn-default" />
                    </div>
                    <div class="btn-group">
                        <asp:Button ID="btnAlterar" runat="server" Text="Salvar" class="btn btn-success" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </section>
</asp:Content>

