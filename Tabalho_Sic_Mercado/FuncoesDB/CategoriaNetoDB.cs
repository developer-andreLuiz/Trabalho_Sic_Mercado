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
    class CategoriaNetoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();
    
        #region Variaveis
        public int id_neto { get; set; }
        public int id_pai { get; set; }
        public int id_filho { get; set; }
        public string nomeNeto { get; set; }
        public string img { get; set; }
        public int ordem { get; set; }
        #endregion

        public CategoriaNetoDB BuscarPrimeiro()
        {
            CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_neto order by id_neto asc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_neto"] != null)
                    {
                        categoriaNetoDB.id_neto = int.Parse(reader["id_neto"].ToString());
                        categoriaNetoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaNetoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaNetoDB.nomeNeto = reader["nome_neto"].ToString();
                        categoriaNetoDB.img = reader["img"].ToString();
                        categoriaNetoDB.ordem = int.Parse(reader["ordem"].ToString());
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
            return categoriaNetoDB;
        }
        public CategoriaNetoDB BuscarUltimo()
        {
            CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_neto order by id_neto desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_neto"] != null)
                    {
                        categoriaNetoDB.id_neto = int.Parse(reader["id_neto"].ToString());
                        categoriaNetoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaNetoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaNetoDB.nomeNeto = reader["nome_neto"].ToString();
                        categoriaNetoDB.img = reader["img"].ToString();
                        categoriaNetoDB.ordem = int.Parse(reader["ordem"].ToString());
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





            return categoriaNetoDB;
        }
        public CategoriaNetoDB BuscarMaiorOrdem(int localidai, int localidFilho)
        {
            CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_neto where id_pai = "+ localidai +" && id_filho = "+localidFilho +" order by ordem desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_neto"] != null)
                    {
                        categoriaNetoDB.id_neto = int.Parse(reader["id_neto"].ToString());
                        categoriaNetoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaNetoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaNetoDB.nomeNeto = reader["nome_neto"].ToString();
                        categoriaNetoDB.img = reader["img"].ToString();
                        categoriaNetoDB.ordem = int.Parse(reader["ordem"].ToString());
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





            return categoriaNetoDB;
        }
        public CategoriaNetoDB Buscar(int localId, int localidPai, int localidFilho)
        {
            CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_neto where id_neto = @id_neto && id_pai = " + localidPai + " && id_filho = " + localidFilho + ";";
                comando.Parameters.AddWithValue("id_neto", localId);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_neto"] != null)
                    {
                        categoriaNetoDB.id_neto = int.Parse(reader["id_neto"].ToString());
                        categoriaNetoDB.id_pai = int.Parse(reader["id_pai"].ToString());
                        categoriaNetoDB.id_filho = int.Parse(reader["id_filho"].ToString());
                        categoriaNetoDB.nomeNeto = reader["nome_neto"].ToString();
                        categoriaNetoDB.img = reader["img"].ToString();
                        categoriaNetoDB.ordem = int.Parse(reader["ordem"].ToString());
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





            return categoriaNetoDB;
        }
        public int BuscarID(string localnome, int localidpai,int localidfilho)
        {
            int b = 0;
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_categoria_neto where nome_neto = @nome_neto && id_pai = @id_pai && id_filho = @id_filho;";
                comando.Parameters.AddWithValue("nome_neto", localnome);
                comando.Parameters.AddWithValue("id_pai", localidpai);
                comando.Parameters.AddWithValue("id_filho", localidfilho);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome_neto"] != null)
                    {
                        b = int.Parse(reader["id_neto"].ToString());

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
        public List<CategoriaNetoDB> ListarCategoriaNeto()
        {
            List<CategoriaNetoDB> listaFinal = new List<CategoriaNetoDB>();
            try
            {
                string strgComando = "SELECT * FROM tb_categoria_neto order by id_neto asc;";

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
                    CategoriaNetoDB newCategoriaNetoDB = new CategoriaNetoDB();
                    newCategoriaNetoDB.id_pai = int.Parse(dataRow["id_pai"].ToString());
                    newCategoriaNetoDB.id_filho = int.Parse(dataRow["id_filho"].ToString());
                    newCategoriaNetoDB.id_neto = int.Parse(dataRow["id_neto"].ToString());
                    newCategoriaNetoDB.nomeNeto = dataRow["nome_neto"].ToString();
                    newCategoriaNetoDB.img = dataRow["img"].ToString();
                    newCategoriaNetoDB.ordem = int.Parse(dataRow["ordem"].ToString());

                    listaFinal.Add(newCategoriaNetoDB);
                }

            }
            catch (Exception erro)
            {
                string a = erro.Message;
            }
            return listaFinal;
        }
        public void Inserir(CategoriaNetoDB categoriaNetoDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_categoria_neto (id_pai, id_filho, nome_neto, img, ordem) values (@id_pai, @id_filho, @nome_neto, @img, @ordem);";
                comando.Parameters.AddWithValue("id_pai", categoriaNetoDB.id_pai);
                comando.Parameters.AddWithValue("id_filho", categoriaNetoDB.id_filho);
                comando.Parameters.AddWithValue("nome_neto", categoriaNetoDB.nomeNeto);
                comando.Parameters.AddWithValue("img", categoriaNetoDB.img);
                comando.Parameters.AddWithValue("ordem", categoriaNetoDB.ordem);

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
        public void Atualizar(CategoriaNetoDB categoriaNetoDB)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_categoria_neto set id_pai = @id_pai, id_filho = @id_filho, nome_neto = @nome_neto, img = @img, ordem = @ordem where id_neto = @id_neto;";
                comando.Parameters.AddWithValue("id_pai", categoriaNetoDB.id_pai);
                comando.Parameters.AddWithValue("id_filho", categoriaNetoDB.id_filho);
                comando.Parameters.AddWithValue("nome_neto", categoriaNetoDB.nomeNeto);
                comando.Parameters.AddWithValue("img", "https://imgapkstorage.blob.core.windows.net/categorianeto/" + categoriaNetoDB.id_neto.ToString());
                comando.Parameters.AddWithValue("ordem", categoriaNetoDB.ordem);
                comando.Parameters.AddWithValue("id_neto", categoriaNetoDB.id_neto);

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
                comando.CommandText = "delete from tb_categoria_neto where id = @id;";
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
                string strgComando = "select * from tb_categoria_neto;";
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
        public void CarregarComboBoxNeto(ComboBox cb)
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome_neto from tb_categoria_neto order by nome_neto asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                //DataRow row = table.NewRow();
                //row["nome"] = ".Buscar Categoria";
                //table.Rows.InsertAt(row, 0);
                cb.DataSource = table;
                // cbnome.ValueMember = "codigo";
                cb.DisplayMember = "nome_neto";
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
        public void CarregarComboBoxNetoFiltro(ComboBox cb, int idfilho,int idpai)
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome_neto from tb_categoria_neto where id_filho = "+idfilho+" && id_pai= "+idpai+" order by nome_neto asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                cb.DataSource = table;
                cb.DisplayMember = "nome_neto";
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
