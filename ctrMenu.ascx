<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrMenu.ascx.vb" Inherits="NewExtranet_ctrMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!-- sidebar: style can be found in sidebar.less -->
<section class="sidebar">
    <div class="user-panel" id="divGoverno" runat="server">
        <%--<center><img src="Imagens/logoSetran.png" alt="" height="80" /></center>--%>
    </div>
    
    <!-- Sidebar user panel -->
    <div class="user-panel" id="divUsuario" runat="server">
        <div class="pull-left image">
            <img src="Imagens/avatar.png" class="img-circle" alt="User Image" />
        </div>
        <div class="pull-left info">
            <p>
                Ola,
                <asp:Label ID="lblUsuario" runat="server" Text="" />
            </p>

            <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
        </div>
    </div>

 <%--MENU INICIAL--%>
    <ul class="sidebar-menu">
        <li class="active">
            <li id="liPaginaInicial" runat="server" visible="true"><a href="lnkBemVindo.aspx"><i class="fa fa-home"></i>Página Inicial</a></li>
        </li>
    </ul>

    <%--MENU IMPORTAÇÃO--%>
    <ul class="sidebar-menu">

        <li id="MenuImportacao" runat="server" visible="false" class="treeview">
            <a href="#">
                <i class="fa fa-car"></i>
                <span>Importação</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li id="liProcessar" runat="server" visible="false"><a href="lnkProcessarArquivos.aspx"><i class="fa fa-angle-double-right"></i>Processar Arquivos</a></li>
                <li id="liGerarArquivoTxt" runat="server" visible="false"><a href="lnkGerarArquivoTxt.aspx"><i class="fa fa-angle-double-right"></i>Gerar Arquivos txt</a></li>
            </ul>
        </li>
    </ul>



    

    <%--MENU RELATÓRIOS--%>
    <ul class="sidebar-menu">

        <li id="MenuRelatorios" runat="server" visible="false" class="treeview">
            <a href="#">
                <i class="fa fa-file-pdf-o"></i>
                <span>Relatórios</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <%-- <li id="liRelatorioEquipamento" runat="server" visible="false"><a href="frmRelatorioEquipamento.aspx"> <i class="fa fa-angle-double-right"></i>Relatório de Equipamentos</a> </li>--%>
            </ul>
        </li>
    </ul>

    <%--MENU GERENCIAL--%>
    <ul class="sidebar-menu">

        <li id="MenuGerencial" runat="server" visible="false" class="treeview">
            <a href="#">
                <i class="fa fa-gears"></i>
                <span>Gerencial</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li id="liCadastroUsuario" runat="server" visible="false"><a href="lnkCadastroUsuario.aspx"><i class="fa fa-angle-double-right"></i>Cadastro Usuário</a> </li>
                <li id="liAlvaraGerencial" runat="server" visible="false"><a href="lnkAlvaraGerencial.aspx"><i class="fa fa-angle-double-right"></i>Alvará Gerencial</a> </li>
                <li id="liConsultasAdmin" runat="server" visible="false"><a href="lnkConsultasAdm.aspx"><i class="fa fa-angle-double-right"></i>Consultas Admin</a> </li>
            </ul>
        </li>
    </ul>
    
</section>
<footer class="main-footer">
            <div class="pull-right hidden-xs">
              <b>Version</b> 1.1
            </div>
            <strong>Copyright &copy; 2018 - Ráder Leão - (098) 98821-2773.</strong> All rights reserved.
       </footer>