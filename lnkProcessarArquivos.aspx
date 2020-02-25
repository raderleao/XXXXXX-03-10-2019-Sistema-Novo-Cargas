
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lnkProcessarArquivos.aspx.vb" Inherits="lnkProcessarArquivos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <section class="content-header">
        <h1>Correios/Notificações
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="lnkBemVindo.aspx"><i class="fa fa-2x fa-home"></i>Home</a></li>
            <li><a href="#"><i class="fa fa-file-text"></i>Sistema SETRAN/Correios</a></li>
            <li class="active">Gravar no Banco</li>
        </ol>
    </section>
   
    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-blue">
                            <div class="box-header">
                                <h3 class="box-title">Manipulação de Arquivos para Importação e Exportação de Dados para os Correios</h3>
                            </div>

                            <div class="box-body">
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnGravarNoBanco">
                                            
                                           <section runat="server" id="secGridArquivosImportados">
                                                <div class="box-header">
                                                    <h3 class="box-title" style="font-style:italic; align-content:center">Arquivos disponíveis para processamento</h3>
                                                </div>
                                                <asp:Label ID="lblArquivosImportados" runat="server" />
                                                <div class="box-footer"">                                
                                                    <asp:GridView ID="gvArquivosImportados" runat="server"  CssClass="table table-bordered" AllowSorting="True" AllowPaging="True" PageSize="80" PagerStyle-CssClass="paginacao" AutoGenerateColumns="False" DataKeyNames="Caminho">
                                                        <HeaderStyle CssClass="bg-info" ForeColor="black" />
                                                        <Columns>
                                                           <asp:ButtonField DataTextField="Id" SortExpression="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                           <asp:ButtonField DataTextField="Pasta" SortExpression="Pasta" HeaderText="Pasta" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                           <asp:ButtonField DataTextField="Nome" SortExpression="Nome" HeaderText="Nome Arquivo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                           <asp:ButtonField DataTextField="" Text="Processar" ButtonType="Button" HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" CommandName="Processar" />
                                                           <asp:ButtonField DataTextField="" Text="Excluir" ButtonType="Button" HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" CommandName="Excluir" />
                                                         </Columns>                                  
                                                    </asp:GridView>                                
                                                </div>
                                           </section>
                                            <section runat="server" id="secGridArquivosProcessados" visible="false">
                                                <div class="box-header">
                                                    <h3 class="box-title" style="font-style:italic; align-content:center">Arquivos já Processados</h3>
                                                </div>
                                                <div class="box-footer" id="divGridArquivosProcessador">
                                
                                                    <asp:GridView ID="gvArquivosProcessados" runat="server"  CssClass="table table-bordered" AllowSorting="True" AllowPaging="True" PageSize="20" PagerStyle-CssClass="paginacao" AutoGenerateColumns="False" DataKeyNames="Caminho">
                                                        <HeaderStyle CssClass="bg-info" ForeColor="black" BackColor="#00cc99"/>
                                                        <Columns>
                                                           <asp:ButtonField DataTextField="Id" SortExpression="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                           <asp:ButtonField DataTextField="Pasta" SortExpression="Pasta" HeaderText="Pasta" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                                           <asp:ButtonField DataTextField="Nome" SortExpression="Nome" HeaderText="Nome Arquivo" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" />
                                       
                                                        </Columns>                                 
                                    
                                                    </asp:GridView>                                
                                                </div>
                                            </section>
                                            <section runat="server" id="secGridListaArquivosProcessados" visible="false">
                                             
                                                    <div class="box-footer">
                                                        <asp:Label ID="lblRegistrosMultas" runat="server" Text="" />
                                                        <asp:GridView ID="gvListaArquivosProcessados" runat="server" CssClass="table table-bordered">
                                                            <HeaderStyle CssClass="bg-info" ForeColor="black" />
                                                        </asp:GridView>                               
                                                    </div>
                                              
                                            </section>
                                            <asp:Button id="btnGravarNoBanco" runat="server" Text="" Visible="false"/>

                                        </asp:Panel>                                                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                                         
                    </div>
                </div>                
               
            </ContentTemplate>
            
        </asp:UpdatePanel>
         <%-- controla a inicialização da mensagem de aguarde (espera 2 segundos) antes de fazer post/desabilita no response --%>
        <%--<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
                Launch demo modal
            </button>--%>
        <div id="WaitModal" role="dialog" aria-labelledby="WaitModalLabel" class="modal fade" style="background-color: rgba(255, 250, 250, 0.5);" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <%--<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                        </div>--%>
                    <div class="modal-body">
                        <h1>Aguarde, processando...</h1>
                        <div class="progress">
                            <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                <span class="sr-only">45% Complete</span>
                            </div>
                        </div>
                    </div>
                    <%--<div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>--%>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            var triggerAguarde = false;
            // Get the instance of PageRequestManager.
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            // Add initializeRequest and endRequest
            prm.add_initializeRequest(prm_InitializeRequest);
            prm.add_endRequest(prm_EndRequest);

            // Called when async postback begins
            function prm_InitializeRequest(sender, args) {

                //$('#WaitModal').modal('show');
                triggerAguarde = true;
                setTimeout(showAguarde, 1000);
                //sleep(5);

                // Disable button that caused a postback
                $get(args._postBackElement.id).disabled = true;
            }

            // Called when async postback ends
            function prm_EndRequest(sender, args) {
                // get the divImage and hide it again
                triggerAguarde = false;
                attachedMethods();
                //$('#WaitModal').modal('hide');
                setTimeout(hideAguarde, 100);

                // Enable button that caused a postback
                //$get(sender._postBackSettings.sourceElement.id).disabled = false;
            }

            function showAguarde() {
                if (triggerAguarde == true) {
                    $('#WaitModal').modal('show');
                    triggerAguarde = false;
                }
            }
            function hideAguarde() {
                $('#WaitModal').modal('hide');
            }

            function attachedMethods() {

            }

            function sleep(milliseconds) {
                var start = new Date().getTime();
                for (var i = 0; i < 1e7; i++) {
                    if ((new Date().getTime() - start) > milliseconds) {
                        break;
                    }
                }
            }
        </script>
               
    </section>


    <script type="text/javascript">
        function ismaxlength(obj) {
            var mlength = obj.getAttribute ? parseInt(obj.getAttribute("maxlength")) : ""
            if (obj.getAttribute && obj.value.length > mlength) {
                obj.value = obj.value.substring(0, mlength)
            }
        }
   
    </script>
</asp:Content>
