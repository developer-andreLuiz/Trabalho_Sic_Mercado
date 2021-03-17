using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mercado.VariaveisGlobais;

namespace Mercado.FuncoesDB
{
    class NotasEletronicasDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis NfeIdentificacao

        public object numeroNota;
        public object nome;
        public object codigoFornecedor;
        public object dataEmissao;
        public object valorTotalProdutos;
        public object valorTotalNota;
        public object nota;
        public object id;
        public object cnpj;

        #endregion

        #region Variaveis NfeProdutos

        public object codigo;
        public object valorProduto;
        public object qtdProdCompra;

        #endregion

        #region Variaveis NfeIdentificacao Tabela



        #endregion


        /// <summary>
        /// função f4
        /// </summary>
        /// <param name="dataGridView"></param>
        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select n_nf as 'Numero_NF', nome_fornecedor as 'nome',num as 'Numero' from tb_nfe_identificacao_nota where nota_br = 'Não';";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 100;
                dataGridView.Columns[1].Width = 335;
                dataGridView.Columns[2].Width = 50;



            }
            catch (Exception a)
            {
               // MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

        }


        /// <summary>
        /// buscar dados para o form entrada mercadoria
        /// </summary>
        /// <param name="x"></param>
        public void BuscarDadosFornecedorNota()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select n_nf as 'Numero Nota', nome_fornecedor as 'nome', cod_fornecedor as 'Cod Fornec', d_emi as 'DataEmissao', v_bc as 'Valor Total Produtos', v_nf as 'Valor Total Nota', nota_br as 'Nota', id  from tb_nfe_identificacao_nota where num = @num;";
                comando.Parameters.AddWithValue("num", Singleton.instancia.numFornecNota);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        numeroNota = reader["Numero Nota"].ToString();
                        nome = reader["nome"].ToString();
                        codigoFornecedor = reader["Cod Fornec"].ToString();
                        dataEmissao = reader["DataEmissao"].ToString();
                        valorTotalProdutos = reader["Valor Total Produtos"].ToString();
                        valorTotalNota = reader["Valor Total Nota"].ToString();
                        nota = reader["Nota"].ToString();
                        id = reader["id"].ToString();


                    }
                    else
                    {
                       
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                conexao.Close();
            }

        }
       

        public void InsertDadosIdentificacaoNota()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_nfe_identificacao_nota (id, cnpj, cod_fornecedor, nome_fornecedor, n_nf, d_emi, v_bc, v_nf, nota_br) values (@id, @cnpj, @cod_fornecedor, @nome_fornecedor, @n_nf, @d_emi, @v_bc, @v_nf, @nota_br);";
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("cnpj", cnpj);
                comando.Parameters.AddWithValue("cod_fornecedor", codigoFornecedor);
                comando.Parameters.AddWithValue("nome_fornecedor", nome);
                comando.Parameters.AddWithValue("n_nf", numeroNota);
                comando.Parameters.AddWithValue("d_emi", dataEmissao);
                comando.Parameters.AddWithValue("v_bc", valorTotalProdutos);
                comando.Parameters.AddWithValue("v_nf", valorTotalNota);
                comando.Parameters.AddWithValue("nota_br", nota);
                comando.ExecuteNonQuery();

            }
            catch (Exception a)
            {

                MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }
        }


        /// <summary>
        /// Exibe dados da tabela tb_nfe_produtos_nota no ListView
        /// </summary>
        /// <param name="dtLista"></param>
        /// <param name="dataGridView"></param>
        public void BuscarProdutosNotaProdutos(DataTable dtLista, DataGridView dataGridView)
        {
            try
            {
                string strgComando = "SELECT codigo as 'Codigo',v_prod as'Valor Produto',qtd_prod_compra as 'QtdProdCompra', v_desc as 'Desconto', v_outro as 'Outros', icms_v_icmsst as 'Icms', ipi_v_ipi as 'Ipi' FROM tb_nfeprodutos where cod_fornecedor = @cod_fornecedor  && id = @id order by x_prod asc;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("id",id);
                comando.Parameters.AddWithValue("cod_fornecedor", codigoFornecedor);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
               


                dtLista.Clear();
                sqlDataAdapter.Fill(dtLista);
                // dataGridView.Columns.Clear();
                //dataGridView.Rows.Clear();


                dataGridView.DataSource = dtLista;


            }
            catch (Exception a)
            {
                //  MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }


        public void ObjVazio()
        {
            numeroNota = null;
            nome = null;
            codigoFornecedor = null;
            dataEmissao = null;
            valorTotalProdutos = null;
            valorTotalNota = null;
            nota = null;
            id = null;
            codigo = null;
            valorProduto = null;
            qtdProdCompra = null;
        }
         

     












    }
}
