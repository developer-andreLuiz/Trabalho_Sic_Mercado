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
    class CategoriaPaiDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();
       
        #region Variaveis
        public int id_pai { get; set; }
        public string nomePai { get; set; }
        public string img { get; set; }
        public int ordem { get; set; }
        #endregion

        public CategoriaPaiDB BuscarPrimeiro()
        {
            CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_pai order by id_pai asc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_pai"] != null)
                    {
                        categoriaPaiDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaPaiDB.nomePai = reader["nome_pai"].ToString();
                        categoriaPaiDB.img = reader["img"].ToString();
                        categoriaPaiDB.ordem = int.Parse(reader["ordem"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Dados não encontrados");
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





            return categoriaPaiDB;
        }
        public CategoriaPaiDB BuscarUltimo()
        {
            CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_pai order by id_pai desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_pai"] != null)
                    {
                        categoriaPaiDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaPaiDB.nomePai = reader["nome_pai"].ToString();
                        categoriaPaiDB.img = reader["img"].ToString();
                        categoriaPaiDB.ordem = int.Parse(reader["ordem"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Dados não encontrados");
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





            return categoriaPaiDB;
        }
        public CategoriaPaiDB BuscarMaiorOrdem()
        {
            CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_pai order by ordem desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_pai"] != null)
                    {
                        categoriaPaiDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaPaiDB.nomePai = reader["nome_pai"].ToString();
                        categoriaPaiDB.img = reader["img"].ToString();
                        categoriaPaiDB.ordem = int.Parse(reader["ordem"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Dados não encontrados");
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





            return categoriaPaiDB;
        }
        public CategoriaPaiDB Buscar(int localId)
        {
            CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_pai where id_pai = @id_pai;";
                comando.Parameters.AddWithValue("id_pai", localId);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_pai"] != null)
                    {
                        categoriaPaiDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaPaiDB.nomePai = reader["nome_pai"].ToString();
                        categoriaPaiDB.img = reader["img"].ToString();
                        categoriaPaiDB.ordem = int.Parse(reader["ordem"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Dados não encontrados");
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





            return categoriaPaiDB;
        }
        public int BuscarID(string localnome)
        {
            int b=0;
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_pai where nome_pai = @nome_pai;";
                comando.Parameters.AddWithValue("nome_pai", localnome);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_pai"] != null)
                    {
                        b = int.Parse(reader["id_pai"].ToString());
                      
                    }
                    else
                    {
                        MessageBox.Show("Dados não encontrados");
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

            return b;
        }
        public List<CategoriaPaiDB> ListarCategoriaPai()
        {
            List<CategoriaPaiDB> listaFinal = new List<CategoriaPaiDB>();
            try
            {
                string strgComando = "SELECT * FROM tb_categoria_pai order by id_pai asc;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);


                foreach (DataRow dataRow in dtLista.Rows)
                {
                    CategoriaPaiDB newCategoriaPaiDB = new CategoriaPaiDB();
                    newCategoriaPaiDB.id_pai = int.Parse(dataRow["id_pai"].ToString());
                    newCategoriaPaiDB.nomePai = dataRow["nome_pai"].ToString();
                    newCategoriaPaiDB.img = dataRow["img"].ToString();
                    newCategoriaPaiDB.ordem = int.Parse(dataRow["ordem"].ToString());

                    listaFinal.Add(newCategoriaPaiDB);
                }

            }
            catch (Exception erro)
            {
                string a = erro.Message;
            }
            return listaFinal;
        }
        public void Inserir(CategoriaPaiDB categoriaPaiDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_categoria_pai (nome_pai, img, ordem) values (@nome_pai, @img, @ordem);";
                comando.Parameters.AddWithValue("nome_pai", categoriaPaiDB.nomePai);
                comando.Parameters.AddWithValue("img", categoriaPaiDB.img);
                comando.Parameters.AddWithValue("ordem", categoriaPaiDB.ordem);

                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Inserir", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao Inserir");
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
        public void Atualizar(CategoriaPaiDB categoriaPaiDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_categoria_pai set nome_pai = @nome_pai, img = @img, ordem = @ordem where id_pai = @id_pai;";
                comando.Parameters.AddWithValue("nome_pai", categoriaPaiDB.nomePai);
                comando.Parameters.AddWithValue("img", "https://imgapkstorage.blob.core.windows.net/categoriapai/" + categoriaPaiDB.id_pai);
                comando.Parameters.AddWithValue("ordem", categoriaPaiDB.ordem);
                comando.Parameters.AddWithValue("id_pai", categoriaPaiDB.id_pai);

                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Atualizar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void Deletar(int localId)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_categoria_pai where id_pai = @id_pai;";
                comando.Parameters.AddWithValue("id_pai", localId);
                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Deletar Categoria", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao Deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void CarregarGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select * from tb_categoria_pai;";
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                //dataGridView.Columns[0].Width = 35;
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
        public void CarregarComboBoxPai(ComboBox cb)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome_pai from tb_categoria_pai order by nome_pai asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                cb.DataSource = table;
                cb.DisplayMember = "nome_pai";
                reader.Close();
                reader.Dispose();
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
