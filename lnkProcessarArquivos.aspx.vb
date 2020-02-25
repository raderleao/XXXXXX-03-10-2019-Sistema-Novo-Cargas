Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Partial Class lnkProcessarArquivos
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

            Carregar()

        End If



    End Sub

    Private Sub Carregar()

        'Carregando Pasta Importados
        CarregarListaArquivosPasta("~/Arquivos/Importados/", gvArquivosImportados)

        'Carregando Pasta Processados
        CarregarListaArquivosPasta("~/Arquivos/Processados/", gvArquivosProcessados)

        'If gvListaArquivosProcessados.DataSource IsNot Nothing Then
        '    secGridListaArquivosProcessados.Visible = True
        'End If

        'lblArquivosImportados.Text = ""
        'If Not gvArquivosImportados.DataSource IsNot Nothing Then
        '    lblArquivosImportados.Text = " - Nenhum - "
        'End If


    End Sub
    Private Sub CarregarListaArquivosPasta(ByVal diretorio As String, ByRef grid As GridView)
        Dim caminhoArquivo() As String = Directory.GetFiles(Server.MapPath(diretorio))
        Dim nomeCaminho As String = ""
        Dim lista As List(Of String)

        'Jogando dados do Array numa tabela
        Dim tabela As DataTable = New DataTable()
        tabela.Columns.Add("Id")
        tabela.Columns.Add("Pasta")
        tabela.Columns.Add("Nome")
        tabela.Columns.Add("Caminho")

        For i = 0 To caminhoArquivo.GetUpperBound(0)
            Dim nomeArquivo() As String = caminhoArquivo(i).Split("\")

            tabela.Rows.Add()
            tabela.Rows(i)("Id") = i + 1
            tabela.Rows(i)("Nome") = vbLf + nomeArquivo(nomeArquivo.GetUpperBound(0)) + vbLf

            lista = nomeArquivo.ToList
            lista.Remove(lista(lista.Count - 1))

            For Each j As String In lista
                nomeCaminho = nomeCaminho + j & "\"
            Next

            tabela.Rows(i)("Pasta") = vbLf + nomeCaminho + vbLf
            tabela.Rows(i)("Caminho") = caminhoArquivo(i)
            nomeCaminho = Nothing
            nomeArquivo = Nothing
        Next

        grid.DataSource = tabela
        grid.DataBind()

        If grid.Equals(gvArquivosProcessados) Then
            If tabela.Rows.Count > 0 Then
                secGridArquivosProcessados.Visible = True
            End If
        End If

    End Sub

    Protected Sub gvArquivosImportados_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvArquivosImportados.RowCommand

        If e.CommandName = "Processar" Then
            gvListaArquivosProcessados.DataSource = Nothing
            Select Case TemDados(gvArquivosImportados.DataKeys(e.CommandArgument).Item(0))
                Case 0
                    ProcessaArquvio(gvArquivosImportados.DataKeys(e.CommandArgument).Item(0))
                    ''JavaScript.MsgBox(eTipoMensagem.SALVAR_SUCESSO)
                Case 1
                    MsgBox("Arquivo já Importado!")
                Case 2
                    MsgBox("Arquivo sem Dados!")
                Case Else
                    MsgBox("Arquivo não importado por erro !!! tente novamente ou arquivo não convem de informações para exportação")
            End Select

        End If

        If e.CommandName = "Excluir" Then

            Try
                System.IO.File.Delete(gvArquivosImportados.DataKeys(e.CommandArgument).Item(0))
                gvListaArquivosProcessados.DataSource = Nothing
                secGridListaArquivosProcessados.Visible = False

            Catch ExIO As Exception

                JavaScript.MsgBox(ExIO.Message, "deu erro")

            End Try

        End If

        Carregar()
        UpdatePanel1.Update()

    End Sub

    Private Sub ProcessaArquvio(ByVal caminhoArquivo As String)
        Dim Linha As String
        Dim Srd As StreamReader
        Dim objCabecalho As New Cabecalho
        Dim objTabelaoInfracao As New TabelaoInfracao
        Dim objNatNip As New NatNip
        Dim pastasArqNome() As String = caminhoArquivo.Split("\")
        Dim nomeArquivo As String = pastasArqNome(pastasArqNome.GetUpperBound(0)).Trim()
        Dim TipoCliente() As String = nomeArquivo.Split(".")
        Dim Sigla As String = ""

        Dim i As Integer = 0
        While i < TipoCliente.Count
            If TipoCliente(i) = "itz" Or TipoCliente(i) = "cxa" Or TipoCliente(i) = "acl" Or TipoCliente(i) = "pdz" Then
                Sigla = TipoCliente(i)
            End If
            i += 1
        End While

        If (File.Exists(caminhoArquivo)) Then
            Srd = New StreamReader(caminhoArquivo)


            While (Not Srd.EndOfStream)
                Linha = Srd.ReadLine

                If Linha.Substring(0, 1) = 1 Then
                    With objCabecalho
                        .Tipo = Linha.Substring(0, 1)
                        .NatNip = objNatNip.Pesquisar(,, Sigla, Linha.Substring(2, 3).ToString).Rows(0).Item("IN04_COD_NAT_NIP")
                        .Descricao = Linha.Substring(1, 11)
                        .DataGeracao = Utilidades.FormatarValor(Linha.Substring(12, 8), 1)
                        .NumeroRemessa = Linha.Substring(20, 6)
                        .DataRemessa = Utilidades.FormatarValor(Linha.Substring(26, 8), 1)
                        .Cnpj = Linha.Substring(34, 14)
                        .DataHoraImportado = Now

                        .Salvar()

                        If ViewState("CodigoCabecalho") Is Nothing Then
                            ViewState("CodigoCabecalho") = .ObterUltimo
                        End If
                    End With
                End If

                If Linha.Substring(0, 1) = 2 Then

                    With objTabelaoInfracao
                        .Cabecalho = ViewState("CodigoCabecalho")
                        .TipoRegistro = Linha.Substring(0, 1)
                        If Linha.Substring(1, 1) = 0 Then
                            .TipoInfracao = 2
                        Else
                            .TipoInfracao = Linha.Substring(1, 1)
                        End If

                        .CodLocalOcorrencia = Linha.Substring(2, 6)
                        .NumRemessa = Linha.Substring(8, 6)
                        .DataRemessa = Utilidades.FormatarValor(Linha.Substring(14, 8), 1)
                        .CodOrgaoAutuador = Linha.Substring(22, 6)
                        .DesOrgaoAutuador = Linha.Substring(28, 40)
                        .AutoInfracao = Linha.Substring(68, 10)
                        .DataHoraCometimento = Utilidades.FormatarValor(Linha.Substring(78, 12), 3)
                        .LocalCometimento = Linha.Substring(90, 60)
                        .PlacaVeiculo = Linha.Substring(150, 7)
                        .UfPlaca = Linha.Substring(157, 2)
                        .Agente = Linha.Substring(159, 11)
                        .DesModelo = Linha.Substring(170, 45)
                        .CategoriaVeiculo = Linha.Substring(215, 30)
                        .TipoVeiculo = Linha.Substring(245, 16)
                        .Cor = Linha.Substring(261, 10)
                        .DataAfericao = Utilidades.FormatarValor(Linha.Substring(271, 8), 1)
                        .Proprietario = Linha.Substring(279, 44)
                        .Endereco = Linha.Substring(323, 40)
                        .ComplementoBairro = Linha.Substring(363, 40)
                        .Cep = Linha.Substring(403, 8)
                        .Cidade = Linha.Substring(411, 20)
                        .UfEndereco = Linha.Substring(431, 2)
                        .DesInfracao = Linha.Substring(433, 50)
                        .Artigo = Linha.Substring(483, 19)
                        .VelAferida = Linha.Substring(502, 3)
                        .VelPermitida = Linha.Substring(505, 3)
                        .VelCOnsiderada = Linha.Substring(508, 3)
                        .Penalidade = Linha.Substring(511, 8)
                        .ValorInfracao = Utilidades.FormatarValor(Linha.Substring(519, 9), 4)
                        .CodMunicipio = Linha.Substring(528, 5)
                        .DataEmissao = Utilidades.FormatarValor(Linha.Substring(533, 8), 1)
                        .DataVencimento = Utilidades.FormatarValor(Linha.Substring(541, 8), 1)
                        .NumControle = Linha.Substring(549, 14)
                        .ValorBarra = Linha.Substring(563, 11)
                        .CodigoBarras = Linha.Substring(574, 48)
                        .Prontuario = Linha.Substring(622, 11)
                        .UfProntuario = Linha.Substring(633, 2)
                        .CodigoRetorno = Linha.Substring(635, 3)
                        .Sequencial = Linha.Substring(641, 6)
                        .NumPontos = Linha.Substring(647, 4)
                        .CodInfraest = Linha.Substring(651, 11)
                        .CodInfracao = Linha.Substring(662, 5)
                        .EspecieVeiculo = Linha.Substring(667, (Linha.Count - 667))
                        .Processado = 0

                        .Salvar()

                    End With
                End If

                If Linha.Substring(0, 1) = 3 Then
                    'With objRodape
                    '    .Cabecalho = ViewState("CodigoCabecalho")
                    '    .Tipo = Linha.Substring(0, 1)
                    '    .QtdSemRestricao = Linha.Substring(1, 6)
                    '    .QtdComRestricao = Linha.Substring(7, 6)
                    '    .QtdTotal = Linha.Substring(13, 6)

                    '    .Salvar()
                    'End With

                End If

            End While
            Srd.Close()
        End If

        ViewState("CodigoCabecalho") = Nothing
        objCabecalho = Nothing
        objTabelaoInfracao = Nothing
        'objRodape = Nothing

        MoverArquivo(caminhoArquivo, nomeArquivo)

    End Sub

    Public Function TemDados(ByVal caminhoArquivo As String) As Integer
        Dim Linha As String
        Dim Srd As StreamReader
        Dim objCabecalho As New Cabecalho
        Dim dados As Integer = 0

        If (File.Exists(caminhoArquivo)) Then
            Srd = New StreamReader(caminhoArquivo)

            While (Not Srd.EndOfStream)
                Linha = Srd.ReadLine

                If Linha.Substring(0, 1) = 1 Then
                    If objCabecalho.ObterRemessa(Linha.Substring(20, 6), Linha.Substring(2, 11)) Then
                        dados = 1
                        Return dados
                    End If
                End If

                If Linha.Substring(0, 1) = 3 Then
                    If Linha.Count < 19 Then
                        dados = 2
                        Return dados
                    End If
                End If

            End While
            Srd.Close()
        End If

        objCabecalho = Nothing

        Return dados
    End Function


    Private Sub MoverArquivo(ByVal arqOrigem As String, ByVal arqDestino As String)

        Try
            File.Move(arqOrigem, Server.MapPath("~\Arquivos\Processados\") & arqDestino)
            JavaScript.MsgBox("Processo ok, Arquivo Carregado com Sucesso !!!", eCategoriaMensagem.SUCESSO)
        Catch ex As Exception
            JavaScript.MsgBox(ex.Message)
        End Try

    End Sub

End Class
