using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.VariaveisGlobais;

namespace Mercado.FuncoesDB
{
    class EntradaNfDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis
        public object numeroNf;
        public object codigoFornecedor;
        public object nomeFornecedor;
        public object dataEntrada;
        public object total;
        public object nota;
        public object totalProdutos;
        public object horaAtual;
        public object numId;
        public object id;
        #endregion

        public void InserirDados()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_entrada_nf (numero_nf, codigo_fornecedor, nome_fornecedor, data_entrada, total, nota, total_produtos, hora_atual) values (@numeroNf, @codigoFornecedor, @nomeFornecedor, @dataEntrada, @total, @nota, @totalProdutos, @horaAtual);";
                comando.Parameters.AddWithValue("numeroNf", numeroNf);
                comando.Parameters.AddWithValue("codigoFornecedor", codigoFornecedor);
                comando.Parameters.AddWithValue("nomeFornecedor", nomeFornecedor);
                comando.Parameters.AddWithValue("dataEntrada", dataEntrada);
                comando.Parameters.AddWithValue("total", total);
                comando.Parameters.AddWithValue("nota", nota);
                comando.Parameters.AddWithValue("totalProdutos", totalProdutos);
                comando.Parameters.AddWithValue("horaAtual", horaAtual);
               

                comando.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);

            }
            finally
            {
                conexao.Close();

            }
        }
        public void CarregarDataGrid( DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select numero_nf as 'NumeroNF', codigo_fornecedor as 'Cod', nome_fornecedor as 'nome', data_entrada as 'Data Atual', total as 'Total', hora_atual as 'Hora' from tb_entrada_nf;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 70;
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].Width = 250;
               




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
        public void Deletar(string localNotaNF , string localCodFornecedor)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_entrada_nf where numero_nf= @localNotaNF && codigo_fornecedor = @codigo_fornecedor;";
                comando.Parameters.AddWithValue("localNotaNF", localNotaNF);
                comando.Parameters.AddWithValue("codigo_fornecedor", localCodFornecedor);
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
        public void BuscarDadosEntrada()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "SELECT * FROM dbmercado.tb_entrada_nf where codigo_fornecedor = @codigo_fornecedor && numero_nf = @numero_nf;";
                comando.Parameters.AddWithValue("codigo_fornecedor", Singleton.instancia.codigoFornecedor.ToString());
                comando.Parameters.AddWithValue("numero_nf", Singleton.instancia.numNotaFiscal.ToString());
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome_fornecedor"] != null)
                    {
                        numeroNf = reader["numero_nf"].ToString();
                        codigoFornecedor = reader["codigo_fornecedor"].ToString();
                        nomeFornecedor = reader["nome_fornecedor"].ToString();
                        dataEntrada = reader["data_entrada"].ToString();
                        total = reader["total"].ToString();
                        nota = reader["nota"].ToString();
                        totalProdutos = reader["total_produtos"].ToString();
                        horaAtual = reader["hora_atual"].ToString();
                        numId = reader["num_id"].ToString();
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
        public void CarregarDataGridnomeFornecedor(DataGridView dataGridView, TextBox nome)
        {
            try
            {
                string strgComando = "select numero_nf as 'NumeroNF', codigo_fornecedor as 'Cod', nome_fornecedor as 'nome', data_entrada as 'Data Atual', total as 'Total', hora_atual as 'Hora' from tb_entrada_nf where nome_fornecedor like '%" + nome.Text.Trim() + "%' ";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 70;
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].Width = 250;





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
        public void CarregarDataGridNumeroNota(DataGridView dataGridView, TextBox nota)
        {
            try
            {
                string strgComando = "select numero_nf as 'NumeroNF', codigo_fornecedor as 'Cod', nome_fornecedor as 'nome', data_entrada as 'Data Atual', total as 'Total', hora_atual as 'Hora' from tb_entrada_nf where numero_nf  like '%" + nota.Text.Trim() + "%'";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 70;
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].Width = 250;





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
        public void CarregarDataGridNumeroNotanomeFornecedor(DataGridView dataGridView, TextBox nome, TextBox nota)
        {
            try
            {
                string strgComando = "select numero_nf as 'NumeroNF', codigo_fornecedor as 'Cod', nome_fornecedor as 'nome', data_entrada as 'Data Atual', total as 'Total', hora_atual as 'Hora' from tb_entrada_nf where numero_nf  like '%" + nota.Text.Trim() + "%' && nome_fornecedor like '%" + nome.Text.Trim() + "%' ";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 70;
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].Width = 250;





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



        //public void BuscarDadosIdEntrada(int x)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_entrada_nf where cododigo_fornecedor = @cododigo_fornecedor order by id desc limit 1;";
        //        comando.Parameters.AddWithValue("cododigo_fornecedor", x);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_fornecedor"] != null)
        //            {

        //                id = reader["id"].ToString();
        //                num = reader["num"].ToString();


        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }
            //}
            //public void BuscarDadosNum()
            //{
            //    try
            //    {
            //        if (conexao.State == ConnectionState.Closed)
            //        {
            //            conexao.Open();
            //        }

            //        MySqlCommand comando = conexao.CreateCommand();
            //        comando.CommandText = "select * from tb_nfe_identificacao_nota order by num desc limit 1;";

            //        MySqlDataReader reader = comando.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            if (reader["nome_fornecedor"] != null)
            //            {


            //                //num = reader["num"].ToString();


            //            }
            //        }
            //    }
            //    catch (Exception a)
            //    {
            //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {

            //        conexao.Close();
            //    }
            //}

        }
}
