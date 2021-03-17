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
    class PanfletoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();
        public string nome;
        public string valor;
        public string codigo;


        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select * from tb_panfleto_item;";

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
                dataGridView.Columns[1].Width = 295;
                dataGridView.Columns[2].Width = 60;
                dataGridView.Columns[3].Width = 60;
               
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

        public void Inserir()
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_panfleto_item (nome,valor,codigo) values (@nome,@valor,@codigo);";
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("valor", valor);
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                //MessageBox.Show("Erro Registro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }
        }

        public void Deletar(int x)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_panfleto_item where id = @id;";
                comando.Parameters.AddWithValue("id", x);

                comando.ExecuteNonQuery();
               
            }
            catch (Exception a)
            {
                //MessageBox.Show(a.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Truncate()
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_panfleto_item;";
                comando.ExecuteNonQuery();


            }
            catch (Exception a)
            {
               // MessageBox.Show(a.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void ObjVazio()
        {
            nome = null;
            valor = null;
            codigo = "0";
        }
        
    }
}
