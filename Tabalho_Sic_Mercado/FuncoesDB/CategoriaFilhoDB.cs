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
    class CategoriaFilhoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis
        public int id_filho { get; set; }
        public int id_pai { get; set; }
        public string nomeFilho { get; set; }
        public string img { get; set; }
        public int ordem { get; set; }
        #endregion

        public CategoriaFilhoDB BuscarPrimeiro()
        {
            CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_filho order by id_filho asc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_filho"] != null)
                    {
                        categoriaFilhoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaFilhoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaFilhoDB.nomeFilho = reader["nome_filho"].ToString();
                        categoriaFilhoDB.img = reader["img"].ToString();
                        categoriaFilhoDB.ordem = int.Parse(reader["ordem"].ToString());
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
            return categoriaFilhoDB;
        }
        public CategoriaFilhoDB BuscarUltimo()
        {
            CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_filho order by id_filho desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_filho"] != null)
                    {
                        categoriaFilhoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaFilhoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaFilhoDB.nomeFilho = reader["nome_filho"].ToString();
                        categoriaFilhoDB.img = reader["img"].ToString();
                        categoriaFilhoDB.ordem = int.Parse(reader["ordem"].ToString());
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
            return categoriaFilhoDB;
        }
        public CategoriaFilhoDB BuscarMaiorOrdem(int localidPai)
        {
            CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_filho where id_pai ="+ localidPai + " order by ordem desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_filho"] != null)
                    {
                        categoriaFilhoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaFilhoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaFilhoDB.nomeFilho = reader["nome_filho"].ToString();
                        categoriaFilhoDB.img = reader["img"].ToString();
                        categoriaFilhoDB.ordem = int.Parse(reader["ordem"].ToString());
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
            return categoriaFilhoDB;
        }
        public CategoriaFilhoDB Buscar(int localId, int localidPai)
        {
            CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_filho where id_filho = @id_filho && id_pai =" + localidPai + " ;";
                comando.Parameters.AddWithValue("id_filho", localId);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_filho"] != null)
                    {
                        categoriaFilhoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaFilhoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaFilhoDB.nomeFilho = reader["nome_filho"].ToString();
                        categoriaFilhoDB.img = reader["img"].ToString();
                        categoriaFilhoDB.ordem = int.Parse(reader["ordem"].ToString());
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
            return categoriaFilhoDB;
        }
        public int BuscarID(string localnome,int localidpai)
        {
            int b = 0;
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_filho where nome_filho = @nome_filho && id_pai= @id_pai;";
                comando.Parameters.AddWithValue("nome_filho", localnome);
                comando.Parameters.AddWithValue("id_pai", localidpai);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_filho"] != null)
                    {
                        b = int.Parse(reader["id_filho"].ToString());

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
        public List<CategoriaFilhoDB> ListarCategoriaFilho()
        {
            List<CategoriaFilhoDB> listaFinal = new List<CategoriaFilhoDB>();
            try
            {
                string strgComando = "SELECT * FROM tb_categoria_filho order by id_filho asc;";

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
                    CategoriaFilhoDB newCategoriaFilhoDB = new CategoriaFilhoDB();
                    newCategoriaFilhoDB.id_pai = int.Parse(dataRow["id_pai"].ToString());
                    newCategoriaFilhoDB.id_filho = int.Parse(dataRow["id_filho"].ToString());
                    newCategoriaFilhoDB.nomeFilho = dataRow["nome_filho"].ToString();
                    newCategoriaFilhoDB.img = dataRow["img"].ToString();
                    newCategoriaFilhoDB.ordem = int.Parse(dataRow["ordem"].ToString());

                    listaFinal.Add(newCategoriaFilhoDB);
                }

            }
            catch (Exception erro)
            {
                string a = erro.Message;
            }
            return listaFinal;
        }
        public void Inserir(CategoriaFilhoDB categoriaFilhoDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_categoria_filho (id_pai, nome_filho, img, ordem) values (@id_pai, @nome_filho, @img, @ordem);";
                comando.Parameters.AddWithValue("id_pai", categoriaFilhoDB.id_pai);
                comando.Parameters.AddWithValue("nome_filho", categoriaFilhoDB.nomeFilho);
                comando.Parameters.AddWithValue("img", categoriaFilhoDB.img);
                comando.Parameters.AddWithValue("ordem", categoriaFilhoDB.ordem);

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
        public void Atualizar(CategoriaFilhoDB categoriaFilhoDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_categoria_filho set id_pai = @id_pai, nome_filho = @nome_filho, img = @img, ordem = @ordem where id_filho = @id_filho;";
                comando.Parameters.AddWithValue("id_pai", categoriaFilhoDB.id_pai);
                comando.Parameters.AddWithValue("nome_filho", categoriaFilhoDB.nomeFilho);
                comando.Parameters.AddWithValue("img", "https://imgapkstorage.blob.core.windows.net/categoriafilho/" + categoriaFilhoDB.id_filho.ToString());
                comando.Parameters.AddWithValue("ordem", categoriaFilhoDB.ordem);
                comando.Parameters.AddWithValue("id_filho", categoriaFilhoDB.id_filho);

                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Atualizar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao Atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                comando.CommandText = "delete from tb_categoria_filho where id = @id;";
                comando.Parameters.AddWithValue("id", localId);
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
                string strgComando = "select * from tb_categoria_filho;";
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
        public void CarregarComboBoxFilho(ComboBox cb)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome_filho from tb_categoria_filho order by nome_filho asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                //DataRow row = table.NewRow();
                //row["nome"] = ".Buscar Categoria";
                //table.Rows.InsertAt(row, 0);
                cb.DataSource = table;
                // cbnome.ValueMember = "codigo";
                cb.DisplayMember = "nome_filho";
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
        public void CarregarComboBoxFilhoFiltro(ComboBox cb,int idpai)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome_filho from tb_categoria_filho where id_pai = "+idpai+" order by nome_filho asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                cb.DataSource = table;
                cb.DisplayMember = "nome_filho";
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
