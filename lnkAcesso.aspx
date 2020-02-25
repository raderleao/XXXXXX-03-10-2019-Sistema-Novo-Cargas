<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lnkAcesso.aspx.vb" Inherits="lnkAcesso" %>

<%@ Register Src="crtMensagens.ascx" TagName="crtMensagens" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" class="">
<head>
    <meta charset="UTF-8">
    <title>Sistema de Notificações</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />

    <link href="css/PersonalizacaoAcesso.css" rel="stylesheet" type="text/css" />
</head>
<body class="">
    <div style="margin-left: 20%; margin-right: 20%;">
        <uc1:crtMensagens ID="crtMensagens1" runat="server" />
    </div>

    <div class="form-box" id="login-box">
        <div class="header">
            <%--<img src="Imagens/imagem.png" alt="" height="80" style="text-align:center" />--%>
            <br />
            Acesso
        </div>
        <form id="Form1" method="post" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <div class="body bg-gray">
                <asp:Panel ID="pnlN" runat="server">
                    <div class="form-group" id="divLogin">
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" MaxLength="250" placeholder="Login" />
                    </div>
                    <div class="form-group" id="divSenha">
                        <asp:TextBox ID="txtSenha" runat="server" class="form-control" MaxLength="100" placeholder="Senha" TextMode="Password"/>
                    </div>
                </asp:Panel>
            </div>
            <div class="footer bg-gray">
                <asp:Button ID="btnEntrarN" CssClass="btn bg-black btn-block" runat="server" AccessKey="E" Text="Entrar" CausesValidation="true" ValidationGroup="loginN"/>
                <asp:PlaceHolder ID = "sMsgErroLogin" runat="server" />
            </div>
        </form>
    </div>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/Validacao.js" type="text/javascript"></script>
</body>
</html>