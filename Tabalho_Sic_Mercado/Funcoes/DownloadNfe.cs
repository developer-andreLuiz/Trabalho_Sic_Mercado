using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Recepcao = Mercado.NFeRecepcaoEvento;
using Download = Mercado.NFeDistribuicaoDFe;
using System.Security.Cryptography.Xml;
using System.Xml.Serialization;
using Mercado.FuncoesDB;
using System.Drawing.Printing;
using Mercado.VariaveisGlobais;

namespace Mercado.Funcoes
{
    class DownloadNfe

    ///<summary>
    /// Baixa nota fiscal da receita federal, produtos a serem repostos, dados do fornecedor (se for cadastrado);
    ///</summary>
    {
        FornecedorDB f { get; set; }
        //FornecedorDB f = new FornecedorDB();
        ProdutoDB p { get; set; }
        //ProdutoDB p = new ProdutoDB();
        NFePesqProdutoDB pesq { get; set; }
        //NFePesqProdutoDB pesq = new NFePesqProdutoDB();
        string nomeNota;
        string produtosEncontrados = string.Empty;


        ////Fuções de Download Xml
        //public void DownloadoNotaFiscal(string chaveNota)
        //{
        //    nomeNota = chaveNota;
        //    if (File.Exists(@"C:\Users\Public\Documents\" + nomeNota + ".xml")==false)
        //    {
        //        try
        //        {
        //            var NFe_Rec = new Recepcao.RecepcaoEventoSoapClient();
        //            NFe_Rec.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "0107bb74");
        //            var notas = new string[] { chaveNota }; // este array não deve passar de 20 elementos, máximo permitido por lote de manifestação
        //            var sbXml = new StringBuilder();
        //            sbXml.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>
        //        <envEvento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
        //        <idLote>1</idLote>");
        //            foreach (var nota in notas)
        //            {
        //                sbXml.Append(@" <evento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
        //        <infEvento Id=""ID210210" + nota + @"01"">
        //        <cOrgao>91</cOrgao>
        //        <tpAmb>1</tpAmb>
        //        <CNPJ>24952156000130</CNPJ>
        //        <chNFe>" + nota + @"</chNFe>
        //        <dhEvento>" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss") + @"-03:00</dhEvento>
        //        <tpEvento>210210</tpEvento>
        //        <nSeqEvento>1</nSeqEvento>
        //        <verEvento>1.00</verEvento>
        //        <detEvento versao=""1.00"">
        //        <descEvento>Ciencia da Operacao</descEvento>
        //        </detEvento>
        //        </infEvento>
        //        </evento>");
        //            }
        //            sbXml.Append("</envEvento>");
        //            var xml = new XmlDocument();
        //            xml.LoadXml(sbXml.ToString());
        //            var i = 0;
        //            foreach (var nota in notas)
        //            {
        //                var docXML = new SignedXml(xml);
        //                docXML.SigningKey = NFe_Rec.ClientCredentials.ClientCertificate.Certificate.PrivateKey;
        //                var refer = new Reference();
        //                refer.Uri = "#ID210210" + nota + "01";
        //                refer.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        //                refer.AddTransform(new XmlDsigC14NTransform());
        //                docXML.AddReference(refer);

        //                var ki = new KeyInfo();
        //                ki.AddClause(new KeyInfoX509Data(NFe_Rec.ClientCredentials.ClientCertificate.Certificate));
        //                docXML.KeyInfo = ki;

        //                docXML.ComputeSignature();
        //                i++;
        //                xml.ChildNodes[1].ChildNodes[i].AppendChild(xml.ImportNode(docXML.GetXml(), true));
        //            }
        //            var NFe_Cab = new Recepcao.nfeCabecMsg();
        //            NFe_Cab.cUF = "33"; //RJ => De acordo com a Tabela de Código de UF do IBGE
        //            NFe_Cab.versaoDados = "1.00";
        //            var resp = NFe_Rec.nfeRecepcaoEvento(NFe_Cab, xml);
        //            try
        //            {
        //                var texto = @"<distDFeInt xmlns=""http://www.portalfiscal.inf.br/nfe"" versao = ""1.01""> <tpAmb>1</tpAmb><cUFAutor>33</cUFAutor> <CNPJ>24952156000130</CNPJ><consChNFe><chNFe>" + chaveNota + "</chNFe></consChNFe></distDFeInt>";
        //                var xmlDownload = ConverterStringToXml(texto);
        //                BaixarXml(xmlDownload);

        //            }
        //            catch (Exception a)
        //            {
        //                MessageBox.Show(a.Message);
        //                MessageBox.Show("Erro ao Baixar a Nota");
        //            }
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Erro ao Manisfestar a Nota");
        //        }
        //    }
        //    if (File.Exists(@"C:\Users\Public\Documents\" + nomeNota + ".xml") )
        //    {
        //        #region CarregarDadosXml
        //        XmlSerializer ser = new XmlSerializer(typeof(nfeProc));
        //        TextReader textReader = (TextReader)new StreamReader(@"C:\Users\Public\Documents\" + chaveNota + ".xml");
        //        XmlTextReader reader = new XmlTextReader(textReader);
        //        reader.Read();
        //        Singleton.instancia.notaGlobal = (nfeProc)ser.Deserialize(reader);
        //        #endregion
        //        int numeroItens = Singleton.instancia.notaGlobal.NFe.infNFe.det.Count<nfeProcNFeInfNFeDet>();
        //        if (numeroItens > 0)
        //        {
        //            f.VerificarCadastroFornecedor(Singleton.instancia.notaGlobal.NFe.infNFe.emit.CNPJ.ToString());
        //            if (f.nome == null)
        //            {
        //                f.VerificarCadastroFornecedorCodigo(Singleton.instancia.notaGlobal.NFe.infNFe.emit.CNPJ.ToString());

        //                if (f.nome == null)
        //                {
        //                    if (MessageBox.Show("Deseja Cadastrar Fornecedor Ausente?", "Ausente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                    {
        //                        FrmCadastroFornecedor fornecedor = new FrmCadastroFornecedor();
        //                        fornecedor.ShowDialog();
        //                    }
        //                }
        //                else
        //                {
        //                    #region verifica Prod
        //                    Singleton.instancia.matriz = 0;
        //                    MessageBox.Show( Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN.ToString());


        //                    while (Singleton.instancia.matriz < numeroItens)
        //                    {
        //                        p.ObjVazio();
        //                        p.BuscarDadosRefNovo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN.ToString());
        //                        if (p.descricao != null)
        //                        {
        //                            Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                            Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                            Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                            Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                            Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                            Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                        }
        //                        else
        //                        {
        //                            p.ObjVazio();
        //                            p.BuscarDadosRefNovo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEANTrib.ToString());
        //                            if (p.descricao != null)
        //                            {

        //                                Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                            }
        //                            else
        //                            {
        //                                p.ObjVazio();
        //                                p.BuscarDadosCodCodigo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN.ToString());
        //                                if (p.descricaoCodigo != null)
        //                                {
        //                                    p.BuscarDados();
        //                                    Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                    Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                    Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                    Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                    Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                    Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                                }
        //                                else
        //                                {
        //                                    p.ObjVazio();
        //                                    p.BuscarDadosCodCodigo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEANTrib.ToString());
        //                                    if (p.descricaoCodigo != null)
        //                                    {
        //                                        p.BuscarDados();
        //                                        Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                        Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                        Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                        Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                        Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                        Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                                    }
        //                                    else
        //                                    {
        //                                        pesq.ObjVazio();
        //                                        pesq.BuscarDadosPesqProd(f.codigo.ToString(), Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cProd.ToString());
        //                                        if (pesq.descricao != null)
        //                                        {
        //                                            p.codigo = int.Parse(pesq.codigo.ToString());
        //                                            p.BuscarDados();
        //                                            Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                            Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                            Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                            Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                            Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                            Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                                        }
        //                                        else
        //                                        {
        //                                            Singleton.instancia.produtosFaltando += Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.xProd + System.Environment.NewLine.ToString();
        //                                        }
        //                                    }

        //                                }
        //                            }

        //                        }

        //                        Singleton.instancia.matriz++;
        //                    }
                          


        //                    #endregion
        //                }
        //            }
        //            else
        //            {

        //                #region verifica Prod
        //                Singleton.instancia.matriz = 0;
                        


        //                while (Singleton.instancia.matriz < numeroItens)
        //                {
        //                    p.ObjVazio();
        //                    p.BuscarDadosRefNovo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN.ToString());
        //                    if (p.descricao != null)
        //                    {
        //                        Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                        Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                        Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                        Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                        Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                        Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                    }
        //                    else
        //                    {
        //                        p.ObjVazio();
        //                        p.BuscarDadosRefNovo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEANTrib.ToString());
        //                        if (p.descricao != null)
        //                        {

        //                            Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                            Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                            Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                            Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                            Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                            Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                        }
        //                        else
        //                        {
        //                            p.ObjVazio();
        //                            p.BuscarDadosCodCodigo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN.ToString());
        //                            if (p.descricaoCodigo != null)
        //                            {
        //                                p.BuscarDados();
        //                                Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                            }
        //                            else
        //                            {
        //                                p.ObjVazio();
        //                                p.BuscarDadosCodCodigo(Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEANTrib.ToString());
        //                                if (p.descricaoCodigo != null)
        //                                {
        //                                    p.BuscarDados();
        //                                    Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                    Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                    Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                    Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                    Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                    Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                                }
        //                                else
        //                                {
        //                                    pesq.ObjVazio();
        //                                    pesq.BuscarDadosPesqProd(f.codigo.ToString(), Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cProd.ToString());
        //                                    if (pesq.descricao != null)
        //                                    {
        //                                        p.codigo = int.Parse(pesq.codigo.ToString());
        //                                        p.BuscarDados();
        //                                        Singleton.instancia.codProd_nfe_produto = p.codigo.ToString();
        //                                        Singleton.instancia.descricaoDB_nfe_Produto = p.descricao;
        //                                        Singleton.instancia.quantUnitCx_nfe_Produto = p.quantidade.ToString();
        //                                        Singleton.instancia.embalagemDB_nfe_Produto = p.embalagem;
        //                                        Singleton.instancia.codFornecedor_nfe_produto = f.codigo.ToString();
        //                                        Singleton.instancia.nomeFornecedor_nfe_produto = f.nome.ToString();
        //                                    }
        //                                    else
        //                                    {
        //                                        Singleton.instancia.produtosFaltando += Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.xProd + System.Environment.NewLine.ToString();
        //                                    }
        //                                }

        //                            }
        //                        }

        //                    }

        //                    Singleton.instancia.matriz++;
        //                }



        //                #endregion
        //            }

        //        }
        //    }




        //}
        //private void BaixarXml(XmlDocument xml)
        //{

        //    var NFe_Sc = new Download.NFeDistribuicaoDFeSoapClient();

        //    NFe_Sc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "0107bb74");
        //    XElement x = XElement.Parse(xml.InnerXml);
        //    var arquivo = NFe_Sc.nfeDistDFeInteresse(x).ToString();

        //    var xmlNota = ConverterStringToXml(arquivo);
        //    var conteuZip = xmlNota.GetElementsByTagName("docZip")[0].InnerText;
        //    byte[] dados = Convert.FromBase64String(conteuZip);
        //    //TODO: fazer uso dos dados da variável retorno
        //    var xmlRetorno = descompactar(dados);
        //    // var path = @"C:\Users\Public\Documents\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".xml";
        //    var path = @"C:\Users\Public\Documents\" + nomeNota + ".xml";
        //    File.AppendAllText(path, xmlRetorno);
        //}
        //private XmlDocument ConverterStringToXml(string texto)
        //{
        //    var xml = new XmlDocument();
        //    xml.LoadXml(texto);
        //    return xml;
        //}
        //public string descompactar(byte[] conteudo)
        //{
        //    using (var memory = new MemoryStream(conteudo))
        //    using (var compression = new GZipStream(memory, CompressionMode.Decompress))
        //    using (var reader = new StreamReader(compression))
        //    {
        //        return reader.ReadToEnd();
        //    }
        //}
      

        ////Funções de Leitura dos dados do Xml
        //public void LerXmlFornecedor(string chaveNota)
        //{
        //    #region CarregarDadosXml
        //    XmlSerializer ser = new XmlSerializer(typeof(nfeProc));
        //    TextReader textReader = (TextReader)new StreamReader(@"C:\Users\Public\Documents\" + chaveNota + ".xml");
        //    XmlTextReader reader = new XmlTextReader(textReader);
        //    reader.Read();
        //    nfeProc nota = (nfeProc)ser.Deserialize(reader);
        //    #endregion

           
        //    f.VerificarCadastroFornecedor(nota.NFe.infNFe.emit.CNPJ.ToString());
        //    if (f.nome == null)
        //    {
        //        f.VerificarCadastroFornecedorCodigo(nota.NFe.infNFe.emit.CNPJ.ToString());

        //        if (f.nome == null)
        //        {
        //            if (MessageBox.Show("Deseja Cadastrar Fornecedor Ausente?", "Ausente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                FrmCadastroFornecedor fornecedor = new FrmCadastroFornecedor();
        //                fornecedor.ShowDialog();
        //            }
        //        }
              
        //    }
           
        //}
        //public void LerXmlProduto(string chaveNota)
        //{
        //   #region CarregarDadosXml
        //    XmlSerializer ser = new XmlSerializer(typeof(nfeProc));
        //    TextReader textReader = (TextReader)new StreamReader(@"C:\Users\Public\Documents\" + chaveNota + ".xml");
        //    XmlTextReader reader = new XmlTextReader(textReader);
        //    reader.Read();
        //    nfeProc nota = (nfeProc)ser.Deserialize(reader);
        //    #endregion
        //   int numeroItens = nota.NFe.infNFe.det.Count<nfeProcNFeInfNFeDet>();
        //   int rep = 0;
        //   string produtosFaltando =string.Empty;
        //   string produtosCadastrados = string.Empty;
        //   while (rep < numeroItens)
        //   {

        //        p.ObjVazio();
        //        p.referencia = nota.NFe.infNFe.det[rep].prod.cEAN.ToString();
        //        p.BuscarDadosRef();
        //        if (p.descricao==null)
        //        {
        //            p.referenciaCodigo = nota.NFe.infNFe.det[rep].prod.cEAN.ToString();
        //            p.BuscarDadosRefCodigo();
        //            if (p.referenciaCodigo==null)
        //            {
        //                pesq.ObjVazio();
        //                pesq.BuscarDadosPesqProd(f.codigo.ToString(), nota.NFe.infNFe.det[rep].prod.cProd.ToString());
        //                if (pesq.referencia==null)
        //                {
        //                    produtosFaltando += nota.NFe.infNFe.det[rep].prod.xProd;
        //                }
        //                else
        //                {
        //                    produtosCadastrados += rep.ToString()+" "+nota.NFe.infNFe.det[rep].prod.xProd+ System.Environment.NewLine.ToString();
        //                }
        //            }
        //            else
        //            {
        //                produtosCadastrados += rep.ToString() + " " + nota.NFe.infNFe.det[rep].prod.xProd+ System.Environment.NewLine.ToString();
        //            }
        //        }
        //        else
        //        {
        //            produtosCadastrados+= rep.ToString() + " " + nota.NFe.infNFe.det[rep].prod.xProd+ System.Environment.NewLine.ToString();
        //        }
                
        //      rep++;
        //   }
        //    //MessageBox.Show(produtosFaltando,"Produtos Faltando");
        //    //MessageBox.Show(produtosCadastrados, "Produtos Cadastrados");
        //}

      
        ////TODO: Revisar entrada do xml ( padrão receita federal)


    }
}
