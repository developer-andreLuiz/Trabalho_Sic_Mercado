using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mercado.FuncoesDB
{
    class NFePesqProdutoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();


        public object codigo;
        public object referencia;
        public object codigo_fornecedor;
        public object descricao;
        public object controle;

        public void BuscarDadosPesqProd(string codfornecedorvariavel , string codigovariavel)
        {
          
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "SELECT* FROM tb_nfe_pesquisa_produto where codigo_fornecedor = '"+codfornecedorvariavel+"' and codigo = '"+codigovariavel+"';";
              
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["referencia"] != null)
                    {
                        referencia = reader["referencia"].ToString();
                        descricao = reader["descricao"].ToString();
                        codigo_fornecedor = reader["codigo_forncedor"].ToString();
                        codigo = reader["codigo"].ToString();
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

        public void ObjVazio()
        {
            codigo=null;
            referencia = null;
            codigo_fornecedor = null;
            descricao = null;
            controle = null;
         }


        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select id as 'Id', codigo as 'Código', descricao as 'Descrição' from tb_nfe_pesquisa_produto;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 140;
                dataGridView.Columns[2].Width = 370;
               




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
        public void CarregarDataGridFiltroFornecedor(DataGridView dataGridView , int codFornec)
        {
            try
            {
                string strgComando = "select id as 'Id', codigo as 'Código', descricao as 'Descrição' from tb_nfe_pesquisa_produto where  codigo_fornecedor =" + codFornec+";";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 140;
                dataGridView.Columns[2].Width = 370;





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
        public void CarregarDataGridFiltroDescricao(DataGridView dataGridView, TextBox filtro)
        {
            try
            {
                string strgComando = "select id as 'Id', codigo as 'Código', descricao as 'Descrição' from tb_nfe_pesquisa_produto where descricao  like '%" + filtro.Text.Trim() + "%'";
                //conexao.Open();
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 140;
                dataGridView.Columns[2].Width = 370;



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
        public void CarregarDataGridFiltroDescricaoFornecedor(DataGridView dataGridView, TextBox filtro, int codFornec)
        {
            try
            {
                string strgComando = "select id as 'Id', codigo as 'Código', descricao as 'Descrição' from tb_nfe_pesquisa_produto where codigo_fornecedor =" + codFornec +" && descricao  like '%" + filtro.Text.Trim() + "%'";
                //conexao.Open();
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 140;
                dataGridView.Columns[2].Width = 370;



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

        public void DeletarDados(string localString)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_nfe_pesquisa_produto where id = @referencia;";
                comando.Parameters.AddWithValue("referencia", localString);

                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Deletar");
                }
                else
                {
                    //MessageBox.Show("Erro ao Deletar");
                }
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

        public void BuscarDadosPesqProdUltimo()
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "  SELECT* FROM tb_nfe_pesquisa_produto order by controle desc limit 1;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["referencia"] != null)
                    {
                        referencia = reader["referencia"].ToString();
                        descricao = reader["descricao"].ToString();
                        codigo_fornecedor = reader["codigo_forncedor"].ToString();
                        codigo = reader["codigo"].ToString();
                        controle = reader["controle"].ToString();
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

        public void InserirDadosPesqProd()
        {

            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_nfe_pesquisa_produto (controle, codigo, descricao, referencia, codigo_fornecedor) values(@controle, @codigo, @descricao, @referencia, @codigo_fornecedor);";

                comando.Parameters.AddWithValue("controle", controle);
                //comando.Parameters.AddWithValue("codigo", codigo);
                //comando.Parameters.AddWithValue("descricao", descricao);
                //comando.Parameters.AddWithValue("referencia", referencia);
                //comando.Parameters.AddWithValue("codigo_fornecedor", codigo_fornecedor);

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
    }
}
