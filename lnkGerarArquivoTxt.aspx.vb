Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Partial Class lnkGerarArquivoTxt
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Dim blnParaTestar As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste"))
            Dim objUsuario As New Usuario(Session("Usuario"))
            Dim objPermissao As New Permissao
            'If Not blnParaTestar Then
            '    If (Not objPermissao.Funcionalidade(Session("Usuario"), 3) > 0) And (Not objUsuario.Programador) Then
            '        Response.Redirect("lnkAcesso.aspx")
            '    End If
            'End If

            CarregarComboTabela(drpCliente, New Cliente, "...")
            CarregarGrid()


        End If



    End Sub

#Region "Funções de Cadastro"

    'Private Sub CarregarLocalizarGrupoEscola()
    '    Dim cnn As New Conexao
    '    Dim strSQL As New StringBuilder

    '    ' strSQL.Append(" select ED170_COD_GRUPO_ESCOLA as CODIGO, ED170_DES_GRUPO_ESCOLA as DESCRICAO")
    '    strSQL.Append(" select cast(ED170_COD_GRUPO_ESCOLA as varchar(10)) as CODIGO, ED170_DES_GRUPO_ESCOLA as DESCRICAO")
    '    strSQL.Append(" from ED170_GRUPO_ESCOLA")
    '    strSQL.Append(" where ED170_COD_GRUPO_ESCOLA not in (4,5) ")
    '    strSQL.Append(" union ")
    '    ' strSQL.Append(" select '999' as CODIGO, 'EDUCACAO DO CAMPO' as DESCRICAO")
    '    strSQL.Append(" select '4,5' as CODIGO, 'EDUCACAO DO CAMPO' as DESCRICAO")
    '    strSQL.Append(" from ED170_GRUPO_ESCOLA")
    '    strSQL.Append(" order by 2 ")

    '    drpLocalizarGrupoEscola.DataValueField = "CODIGO"
    '    drpLocalizarGrupoEscola.DataTextField = "DESCRICAO"

    '    drpLocalizarGrupoEscola.DataSource = cnn.AbrirDataTable(strSQL.ToString)
    '    drpLocalizarGrupoEscola.DataBind()

    '    drpLocalizarGrupoEscola.Items.Insert(0, New ListItem("TODOS", 0))

    '    cnn = Nothing
    'End Sub

    '    Private Sub LimparCampos()
    '        ViewState("Codigo") = Nothing

    '        txtNome.Text = ""
    '        drpModalidade.ClearSelection()

    '        CarregarGrid()
    '    End Sub

    '    Private Sub Carregar(ByVal Codigo As Integer)
    '        Dim objTabelaoInfracao As New TabelaoInfracao(Codigo)

    '        With objTabelaoInfracao
    '            ViewState("Codigo") = Codigo

    '            txtNome.Text = .Nome
    '            SelecionarCombo(drpModalidade, .Modalidade)

    '        End With

    '        objTabelaoInfracao = Nothing
    '    End Sub

    Private Sub Gerar()
        Dim objTabelaoInfracao As New TabelaoInfracao

        Dim SW As StreamWriter
        Dim SWResposta As StreamWriter
        Dim linhaRecebida As String
        Dim i As Integer = 0

        GeraNomeArquivo()

        Dim dt = objTabelaoInfracao.GerarExportacao(drpCliente.SelectedValue, drpNatNip.SelectedValue, Session("RemessaRecebida"))

        If dt.Rows.Count = 0 Then
            MsgBox("Sem dados para exportacão!")
            Exit Sub
        End If

        '------------------------- SE HOUVER OUTRO MUNICIPIO CRIAR A PASTA NESSE DIRETORIO "~/Arquivos/PreparadosEnvioCorreio/ " E REPLICAR O CODIGO ABAIXO

        If drpCliente.SelectedValue = 2 Then   'Pasta Imperatriz
            SW = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Imperatriz/") + ViewState("nomeServico").ToString + ".txt", True) ' Cria o arquivo de texto

            SWResposta = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Imperatriz/") + ViewState("nomeResposta").ToString + ".txt", True) ' Cria o arquivo de texto
            SWResposta.WriteLine("1|" & ViewState("nomeResposta").Substring(13, 4) & "|A")
            SWResposta.Close()
        End If

        If drpCliente.SelectedValue = 4 Then   'Pasta Caxias
            SW = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Caxias/") + ViewState("nomeServico").ToString + ".txt", True) ' Cria o arquivo de texto

            SWResposta = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Caxias/") + ViewState("nomeResposta").ToString + ".txt", True) ' Cria o arquivo de texto
            SWResposta.WriteLine("1|" & ViewState("nomeResposta").Substring(13, 4) & "|A")
            SWResposta.Close()
        End If

        If drpCliente.SelectedValue = 5 Then   'Pasta Acailandia
            SW = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Acailandia/") + ViewState("nomeServico").ToString + ".txt", True) ' Cria o arquivo de texto

            SWResposta = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Acailandia/") + ViewState("nomeResposta").ToString + ".txt", True) ' Cria o arquivo de texto
            SWResposta.WriteLine("1|" & ViewState("nomeResposta").Substring(14, 4) & "|A")
            SWResposta.Close()
        End If

        If drpCliente.SelectedValue = 6 Then   'Pasta Pedreiras
            SW = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Pedreiras/") + ViewState("nomeServico").ToString + ".txt", True) ' Cria o arquivo de texto

            SWResposta = New StreamWriter(Server.MapPath("~/Arquivos/PreparadosEnvioCorreio/Pedreiras/") + ViewState("nomeResposta").ToString + ".txt", True) ' Cria o arquivo de texto
            SWResposta.WriteLine("1|" & ViewState("nomeResposta").Substring(13, 4) & "|A")
            SWResposta.Close()
        End If

        While i < dt.Rows.Count

            linhaRecebida = dt.Rows(i).Item("LINHA")
            SW.WriteLine(linhaRecebida)

            i += 1
        End While

        SW.Close()

        objTabelaoInfracao.SalvarProcessados(drpCliente.SelectedValue, drpNatNip.SelectedValue)

        Dim objCabecalho As New Cabecalho
        objCabecalho.SalvarCabecalhoProcessado(ViewState("CodigoCabecalho"), drpCliente.SelectedValue, drpNatNip.SelectedValue)

        MsgBox("Sucesso", eCategoriaMensagem.SUCESSO)
        CarregarGrid()
        objTabelaoInfracao = Nothing
        objCabecalho = Nothing
        dt = Nothing
        ViewState("CodigoCabecalho") = Nothing

    End Sub

    Private Sub GeraNomeArquivo()

        Dim objCabecalho As New Cabecalho
        Dim dt = objCabecalho.PesquisarDistinct(drpCliente.SelectedValue, drpNatNip.SelectedValue)
        Dim objControleCarga As New ControleCarga
        Dim numGerado As String
        Dim numArquivo As Integer
        Dim tam As Integer = 6
        Dim recCodigo As String


        recCodigo = objControleCarga.ObterUltimo()

        If recCodigo <> 0 Then

            If recCodigo.Substring(0, 4) = Now.Year Then
                numArquivo = recCodigo.Substring(4, 6)
            Else

                numArquivo = 0
            End If
        Else
            numArquivo = 0
        End If

        If numArquivo = 0 Then
            numGerado = Now.Year & Utilidades.ZeroEsquerda(1, tam)
        Else
            numGerado = Now.Year & Utilidades.ZeroEsquerda((numArquivo + 1), tam)
        End If

        Session("RemessaRecebida") = dt.Rows(0).Item("IN03_NUMERO_REMESSA").SubString(2, 4)

        'Nomenclatura e-Carta_8181_3052_servico.txt
        ViewState("nomeServico") = "e-Carta_" & dt.Rows(0).Item("IN04_COD_NAT_NIP").ToString & "_" & Session("RemessaRecebida").ToString & "_servico"
        SalvarControleCarga(numGerado, Val(Session("RemessaRecebida").ToString), dt.Rows(0).Item("IN03_DATA_REMESSA"), ViewState("nomeServico").ToString)

        'Nomenclatura e-Carta_8181_5188_Resposta26042018133401.txt
        ViewState("nomeResposta") = "e-Carta_" & dt.Rows(0).Item("IN04_COD_NAT_NIP").ToString & "_" & Session("RemessaRecebida").ToString & "_Resposta" & DataHoraAtual()

        ViewState("CodigoCabecalho") = dt.Rows(0).Item("IN03_COD_CABECALHO")
        objCabecalho = Nothing
        dt = Nothing

    End Sub

    Private Sub SalvarControleCarga(ByVal numArquivo As Integer, ByVal numRemessaDetran As Integer, ByVal dataRemessaDetran As String, ByRef nomeGerado As String)
        Dim objControleCarga As New ControleCarga()

        With objControleCarga

            .DataCriacaoArquivo = Now
            .NumArquivo = numArquivo
            .NumRemessaDetran = numRemessaDetran
            .DataRemessaDetran = dataRemessaDetran
            .NomeArquivoECarta = nomeGerado

            .Salvar()


        End With

        objControleCarga = Nothing

    End Sub
    Private Function DataHoraAtual() As String
        Dim agoraX As String = DateTime.Now.ToString("ddMMyyyyHHmmss")

        Return agoraX
    End Function

    '    Private Sub Excluir()
    '        Dim objTabelaoInfracao As New TabelaoInfracao

    '        If objTabelaoInfracao.Excluir(ViewState("Codigo")) > 0 Then
    '            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
    '        Else
    '            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
    '        End If

    '        objTabelaoInfracao = Nothing
    '    End Sub

#End Region

#Region "Eventos de Cadastro"

    'Protected Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
    '    LimparCampos()
    'End Sub

    'Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
    '    Salvar()
    '    LimparCampos()
    'End Sub

    'Protected Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
    '    Excluir()
    '    LimparCampos()
    'End Sub
    Protected Sub btnGerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerar.Click
        If Val(drpCliente.SelectedValue) > 0 Then
            If Val(drpNatNip.SelectedValue) > 0 Then
                Gerar()
            Else
                MsgBox("Selecione um Tipo!")
            End If
        Else
            MsgBox("Selecione um Cliente!")

        End If
    End Sub

    Protected Sub btnLocalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLocalizar.Click
        CarregarGrid()
    End Sub

    Protected Sub drpCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpCliente.SelectedIndexChanged
        CarregarComboTabelaRelacionada(drpNatNip, New NatNip, drpCliente.SelectedValue, "...")
    End Sub

#End Region

#Region "Funções de Listagem"

    Private Sub CarregarGrid()
        Dim objTabelaoInfracao As New TabelaoInfracao

        grdTabelaoInfracao.DataSource = objTabelaoInfracao.Pesquisar(ViewState("OrderBy"),,, txtPlaca.Text, txtProprietario.Text, drpCliente.SelectedValue, IIf(drpNatNip.SelectedValue = "", 0, drpNatNip.SelectedValue))
        grdTabelaoInfracao.DataBind()

        objTabelaoInfracao = Nothing

        lblRegistros.Text = DirectCast(grdTabelaoInfracao.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

#End Region






End Class
