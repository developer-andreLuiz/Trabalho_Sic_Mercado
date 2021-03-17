using Mercado.VariaveisGlobais;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado.FuncoesDB
{
    class MovimentosDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis
        public object controle = 0;
        public object numeroNf;
        public object referencia;
        public object codigoFornecedor;
        public object dataAtual;
        public object hora;
        public object quantidade;
        public object total;
        public object dataEntrada;
        public object quant;
        public object codigo;
        public object quantTotal;
        public object id;

        public int repeticao = 0;
        #endregion



        public void BuscarDados(int localNumeroNf, int localCodigo)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_movimentos where numero_nf = @localNumeroNf && codigo = @localCodigo ;";
                comando.Parameters.AddWithValue("localNumeroNf", localNumeroNf);
                comando.Parameters.AddWithValue("localCodigo", localCodigo);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["codigo"] != null)
                    {
                        controle = reader["controle"].ToString();
                        numeroNf = reader["numero_nf"].ToString();
                        referencia = reader["referencia"].ToString();
                        codigoFornecedor = reader["codigo_fornecedor"].ToString();
                        dataAtual = reader["data_atual"].ToString();
                        hora = reader["hora"].ToString();
                        quantidade = reader["quantidade"].ToString();
                        total = reader["total"].ToString();
                        dataEntrada = reader["data_entrada"].ToString();
                        quant = reader["quant"].ToString();
                        codigo = reader["codigo"].ToString();
                        quantTotal = reader["quant_total"].ToString();
                        id = reader["id"].ToString();
                    }
                }
            }
            catch (Exception a)
            {

            }
            finally
            {
               conexao.Close();
            }
        }

        public void BuscarDadosProdutosMovimento(string localNumeroNf, string localCodigo, string localCodigoFornecedor)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_movimentos where codigo_fornecedor = @localCodigoFornecedor && numero_nf = @localNumeroNf && codigo = @localCodigo;";
                comando.Parameters.AddWithValue("localNumeroNf", localNumeroNf);
                comando.Parameters.AddWithValue("localCodigo", localCodigo);
                comando.Parameters.AddWithValue("localCodigoFornecedor", localCodigoFornecedor);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["codigo"] != null)
                    {
                        controle = reader["controle"].ToString();
                        numeroNf = reader["numero_nf"].ToString();
                        referencia = reader["referencia"].ToString();
                        codigoFornecedor = reader["codigo_fornecedor"].ToString();
                        dataAtual = reader["data_atual"].ToString();
                        hora = reader["hora"].ToString();
                        quantidade = reader["quantidade"].ToString();
                        total = reader["total"].ToString();
                        dataEntrada = reader["data_entrada"].ToString();
                        quant = reader["quant"].ToString();
                        codigo = reader["codigo"].ToString();
                        quantTotal = reader["quant_total"].ToString();
                        id = reader["id"].ToString();
                    }
                }
            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }


        public void ContarLinhas( )
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "SELECT COUNT(id) as 'Total' from tb_movimentos where codigo_fornecedor = @codigoFornecedor && numero_nf = @numeroNf;";
                comando.Parameters.AddWithValue("numeroNf", Singleton.instancia.numNotaFiscal.ToString());
                comando.Parameters.AddWithValue("codigoFornecedor", Singleton.instancia.codigoFornecedor.ToString());
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Total"] != null)
                    {
                        repeticao = int.Parse(reader["Total"].ToString());
                    }
                }
            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }


        public void InserirDados()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_movimentos (controle, numero_nf, referencia, codigo_fornecedor, data_atual, hora, quantidade, total, data_entrada, quant, codigo, quant_total) values (@controle, @numeroNf, @referencia, @codigoFornecedor, @dataAtual, @hora, @quantidade, @total, @dataEntrada, @quant, @codigo, @quantTotal);";
                comando.Parameters.AddWithValue("controle", controle);
                comando.Parameters.AddWithValue("numeroNf", numeroNf);
                comando.Parameters.AddWithValue("referencia", referencia);
                comando.Parameters.AddWithValue("codigoFornecedor", codigoFornecedor);
                comando.Parameters.AddWithValue("dataAtual", dataAtual);
                comando.Parameters.AddWithValue("hora", hora);
                comando.Parameters.AddWithValue("quantidade", quantidade);
                comando.Parameters.AddWithValue("total", total);
                comando.Parameters.AddWithValue("dataEntrada", dataEntrada);
                comando.Parameters.AddWithValue("quant", quant);
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("quantTotal", quantTotal);

                comando.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                MessageBox.Show("erro insert"+a.Message);
            }
            finally
            {
                conexao.Close();

            }
        }

        public void DeletarDados(int localNumeroNf, int localCodigo)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_movimentos where numero_nf = @localNumeroNf && codigo = @localCodigo ;";
                comando.Parameters.AddWithValue("localNumeroNf", localNumeroNf);
                comando.Parameters.AddWithValue("localCodigo", localCodigo);
                comando.ExecuteNonQuery();
            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        public void ObjVazio()
        {
           
            numeroNf = null;
            referencia = null;
            codigoFornecedor = null;
            dataAtual = null;
            hora = null;
            quantidade = null;
            total = null;
            dataEntrada = null;
            quant = null;
            codigo = null;
            quantTotal = null;
            id = null;
        }

        /// <summary>
        /// Exibe dados da tabela tb_movimentos no ListView
        /// </summary>
        /// <param name="dtLista"></param>
        /// <param name="dataGridView"></param>
        public void CarregarProdutosMovimentos(DataTable dtLista, DataGridView dataGridView, string LocalNumeroNf, string localCodigoFornecedor)
        {
            try
            {
                string strgComando = "select * from tb_movimentos where codigo_fornecedor = @cod_fornecedor && numero_nf = @numero_nf;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("numero_nf", LocalNumeroNf);
                comando.Parameters.AddWithValue("cod_fornecedor", localCodigoFornecedor);

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
    }
}
