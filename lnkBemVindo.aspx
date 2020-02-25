<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lnkBemVindo.aspx.vb" Inherits="lnkBemVindo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <section class="content-header">
        <h1>Sistema SETRAN/CORREIOS
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="lnkBemVindo.aspx"><i class="fa fa-2x fa-home"></i>Home</a></li>
        </ol>
    </section>
  <section class="content">
            <!-- Small boxes (Stat box) -->
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-blue">
                        <div class="box-header">
                            <h3 class="box-title">Bem-Vindo</h3>
                        </div>

                        <%--<div class="box-body">
                            <div class="row">
                                <div class="form-group col-sm-12">

                                </div>
                            </div>
                        </div>--%>



                    </div>
                </div>
            </div>
        </section>
       
</asp:Content>
