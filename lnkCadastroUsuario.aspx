<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lnkCadastroUsuario.aspx.vb" Inherits="lnkCadastroUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="content-header">
        <h1>Usuário
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="lnkBemVindo.aspx"><i class="fa fa-2x fa-home"></i>Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i>Gerencial</a></li>
            <li class="active">Usuário</li>
        </ol>
    </section> 

    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-blue">
                            <div class="box-header">
                                <h3 class="box-title">Cadastro de Usuário</h3>
                            </div>

                            <div class="box-body">
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <div id="Cadastro" runat="server">
                                            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSalvar">
                                                <div class="row">
                                                    <div class="form-group col-sm-8">
                                                        Nome<br />
                                                        <asp:TextBox ID="txtNome" runat="server" Enabled="true" Class="form-control" />
                                                    </div>
                                                    <div class="form-group col-sm-4">
                                                        Cpf<br />
                                                        <asp:TextBox ID="txtCpf" runat="server" Enabled="true" Class="form-control" />
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group col-sm-4">
                                                        Permissão<br />
                                                        <asp:DropDownList ID="drpPermissao" runat="server" Enabled="true" Class="form-control" />
                                                    </div>

                                                    <div class="form-group col-sm-8">
                                                        E-mail<br />
                                                        <asp:TextBox ID="txtEmail" runat="server" Enabled="true" Class="form-control" />
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="form-group col-sm-4">
                                                        Login<br />
                                                        <asp:TextBox ID="txtlogin" runat="server" Enabled="true" Class="form-control" />
                                                    </div>
                                                    <div class="form-group col-sm-6">
                                                        Senha<br />
                                                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Enabled="true" Class="form-control" />
                                                    </div>
                                                    <div class="form-group col-sm-2">
                                                        Ativo<br />
                                                        <asp:CheckBox ID="chkAtivo" runat="server" />
                                                    </div>
                                                </div>

                                            </asp:Panel>

                                            <div class="box-footer">
                                                <div class="btn-group">
                                                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Class="btn btn-info" />
                                                </div>

                                                <div class="btn-group">
                                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Class="btn btn-success" />
                                                </div>

                                                <div class="btn-group">
                                                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Class="btn btn-danger" />
                                                </div>

                                                <div class="btn-group">
                                                    <asp:Button ID="btnVoltar" runat="server" Text="Listar" Class="btn btn-warning" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="box-body">
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <div id="Listagem" runat="server">
                                            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnLocalizar">
                                                <div class="row">
                                                    <div class="form-group col-sm-6">
                                                        Localizar<br />
                                                        <asp:TextBox ID="txtLocalizar" runat="server" Enabled="true" Class="form-control" />
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                            <div class="box-footer">
                                                <div class="btn-group">
                                                    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" Class="btn btn-default" />
                                                </div>

                                                <div class="btn-group">
                                                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" Class="btn btn-success" />
                                                </div>
                                            </div>

                                            <div class="box-footer">
                                                <asp:Label ID="lblRegistros" runat="server" CssClass="contador" />
                                                <asp:GridView ID="grdUsuario" runat="server" CssClass="table table-bordered" AllowSorting="True" AllowPaging="True" PageSize="20" PagerStyle-CssClass="paginacao" AutoGenerateColumns="False" DataKeyNames="AL08_COD_LOGIN">
                                                    <HeaderStyle CssClass="bg-gray" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:ButtonField DataTextField="AL08_NOME" SortExpression="AL08_NOME" HeaderText="Nome" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                        <asp:ButtonField DataTextField="AL08_CPF" SortExpression="AL08_CPF" HeaderText="Cpf" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                        <asp:ButtonField DataTextField="AL08_EMAIL" SortExpression="AL08_EMAIL" HeaderText="E-mail" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                        <asp:ButtonField DataTextField="AL09_DESCRICAO" SortExpression="AL09_DESCRICAO" HeaderText="Permissão" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                        <asp:ButtonField DataTextField="AL08_ATIVO" SortExpression="AL08_ATIVO" HeaderText="Ativo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>

</asp:Content>
