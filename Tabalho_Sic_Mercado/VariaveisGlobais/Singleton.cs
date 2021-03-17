using Mercado.Funcoes;
using Mercado.FuncoesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.VariaveisGlobais
{
    /// <summary>
    /// Conjunto de variáveis globais presentes em todo o sistema
    /// </summary>
    class Singleton
    {
        public static Singleton instancia = new Singleton();

        public int codigoCliente;
        public int codigoFornecedor;
        public int codigoFuncionario;
        public int codigoProduto;
        public int numFornecNota;
        public int numNotaFiscal;
        public string tela;
        public bool inicioSistema = true;
        public string panfletonome;
        public string panfletoValor;
        public string produtosFaltando = string.Empty;
        //public int numFornecNota;
        public string codigo_nfe_pesq_prod = string.Empty;
        public string referencia_nfe_pesq_prod = string.Empty;
        public string codigo_fornecedor_nfe_pesq_prod = string.Empty;
        public string descricao_nfe_pesq_prod = string.Empty;
        public string controle_nfe_pesq_prod = string.Empty;
        public string descricaoDB_nfe_Produto = string.Empty;
        public string quantUnitCx_nfe_Produto = string.Empty;
        public string embalagemDB_nfe_Produto = string.Empty;
        public string codFornecedor_nfe_produto = string.Empty;
        public string nomeFornecedor_nfe_produto = string.Empty;
        public string codProd_nfe_produto = string.Empty;
        public int matriz;
        public nfeProc notaGlobal;


        public List<ProdutoDB> listaProdutoGlobal = new List<ProdutoDB>();
        public List<CategoriaPaiDB> listaCategoriaPaiGlobal = new List<CategoriaPaiDB>();
        public List<CategoriaFilhoDB> listaCategoriaFilhoGlobal = new List<CategoriaFilhoDB>();
        public List<CategoriaNetoDB> listaCategoriaNetoGlobal = new List<CategoriaNetoDB>();





        public void LimparNFeProduto()
        {
            descricaoDB_nfe_Produto = string.Empty;
            quantUnitCx_nfe_Produto = string.Empty;
            embalagemDB_nfe_Produto = string.Empty;
            codFornecedor_nfe_produto = string.Empty;
            nomeFornecedor_nfe_produto = string.Empty;
            codProd_nfe_produto = string.Empty;

        }
        public void LimparNFePesq()
        {
            codigo_nfe_pesq_prod = string.Empty;
            referencia_nfe_pesq_prod = string.Empty;
            codigo_fornecedor_nfe_pesq_prod = string.Empty;
            descricao_nfe_pesq_prod = string.Empty;
            controle_nfe_pesq_prod = string.Empty;
        }
    
    }
}
