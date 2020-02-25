<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lnkConsultasAdm.aspx.vb" Inherits="lnkConsultasAdm" %>

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
            <li class="active">Processar</li>
        </ol>
    </section>

    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>

                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-blue">
                            <div class="box-header">
                                <h3 class="box-title">Manipulação de Arquivos para Exportação de Dados para os Correios</h3>
                            </div>

                            <div class="box-body">
                                <asp:Panel ID="pnlCadastro" runat="server">
                                    <div class="row">
                                        <div class="form-group col-sm-6">
                                            Cliente<br />
                                            <asp:DropDownList ID="drpCliente" runat="server" class="form-control" AutoPostBack="true"/>
                                        </div>
                                         <div class="form-group col-sm-6">
                                            Tipo<br />
                                            <asp:DropDownList ID="drpNatNip" runat="server" class="form-control"/>
                                        </div>
                                    </div>
                                     <div class="row">
                                          <div class="form-group col-sm-6">
                                            Propriétario<br />
                                            <asp:TextBox ID="txtProprietario" runat="server" MaxLength="30" class="form-control" />
                                        </div>
                                        <div class="form-group col-sm-6">
                                            Placa<br />
                                            <asp:TextBox ID="txtPlaca" runat="server" MaxLength="7" class="form-control" />
                                        </div>
                                     </div>
                                </asp:Panel>
                            </div>
                            <div class="box-footer">
                                <div class="btn-group">
                                    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" class="btn btn-default" />
                                </div>
                                <div class="btn-group">
                                    <asp:Button ID="btnGerar" runat="server" Text="Gerar" class="btn btn-success" />
                                </div>
                            </div>

                            <div class="box-footer">
                                <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-aqua" />
                                <asp:GridView ID="grdTabelaoInfracao" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="IN01_COD_TABELAO_INFRACAO">
                                    <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                                    <Columns>
                                        <asp:ButtonField DataTextField="IN05_NOME" SortExpression="IN05_NOME" HeaderText="Cliente" />
                                        <asp:ButtonField DataTextField="IN01_DATA_HORA_COMETIMENTO" SortExpression="IN01_DATA_HORA_COMETIMENTO" HeaderText="Data/Hora" />
                                        <asp:ButtonField DataTextField="IN01_AUTO_INFRACAO" SortExpression="IN01_AUTO_INFRACAO" HeaderText="Auto" />
                                        <asp:ButtonField DataTextField="IN01_PROPRIETARIO" SortExpression="IN01_PROPRIETARIO" HeaderText="Proprietário" />
                                        <asp:ButtonField DataTextField="IN01_PLACA_VEICULO" SortExpression="IN01_PLACA_VEICULO" HeaderText="Placa" />
                                        <asp:ButtonField DataTextField="IN01_LOCAL_COMETIMENTO" SortExpression="IN01_LOCAL_COMETIMENTO" HeaderText="Local Infração" />
                                        <asp:ButtonField DataTextField="IN01_DES_INFRACAO" SortExpression="IN01_DES_INFRACAO" HeaderText="Descrição Infração" />
                                        <asp:ButtonField DataTextField="IN01_VALOR_INFRACAO" SortExpression="IN01_VALOR_INFRACAO" HeaderText="Valor" />
                                    </Columns>
                                </asp:GridView>
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
