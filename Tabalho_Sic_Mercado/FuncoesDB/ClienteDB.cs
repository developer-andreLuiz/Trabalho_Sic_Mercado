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
/// <summary>
/// Esta Classe é responsável por toda manipulação de banco de dados do Cliente
/// </summary>
    public class ClienteDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis
        public int codigo { get; set; }
        public string nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Telefone1 { get; set; }
        public string Cpf { get; set; }
        public string PontoReferencia { get; set; }
        public string Cor { get; set; }
        public string Lado { get; set; }
        public string Posicao { get; set; }
        public string RuaEntrada { get; set; }
        public string DataNascimento { get; set; }
        #endregion

        /// <summary>
        /// Valida e insere informações de um novo cliente no banco de dados
        /// </summary>
        public void InserirDados()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_cliente ( nome, endereco, bairro, cidade, estado, cep, telefone, telefone1, cnpj_cpf, ponto_referencia, cor, lado, posicao, rua_entrada, data_nascimento ) values (@nome,@endereco,@bairro,@cidade,@estado,@cep,@telefone,@telefone1,@cpf,@pontoReferencia,@cor,@lado,@posicao,@ruaEntrada,@dataNascimento);";

                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("endereco", Endereco);
                comando.Parameters.AddWithValue("bairro", Bairro);
                comando.Parameters.AddWithValue("cidade", Cidade);
                comando.Parameters.AddWithValue("estado", Estado);
                comando.Parameters.AddWithValue("cep", Cep);
                comando.Parameters.AddWithValue("telefone", Telefone);
                comando.Parameters.AddWithValue("telefone1", Telefone1);
                comando.Parameters.AddWithValue("cpf", Cpf);
                comando.Parameters.AddWithValue("pontoReferencia", PontoReferencia);
                comando.Parameters.AddWithValue("cor", Cor);
                comando.Parameters.AddWithValue("lado", Lado);
                comando.Parameters.AddWithValue("posicao", Posicao);
                comando.Parameters.AddWithValue("ruaEntrada", RuaEntrada);
                comando.Parameters.AddWithValue("dataNascimento", DataNascimento);

                    if (comando.ExecuteNonQuery() <= 1)
                    {
                        MessageBox.Show("Sucesso ao Inserir", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
       
        /// <summary>
        /// Altera as informações de um cliente já registrado
        /// </summary>
        public void AlterarDados()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                    comando.CommandText = "update tb_cliente set nome= @nome, endereco= @endereco, bairro= @bairro, cidade= @cidade, estado= @estado, cep= @cep, telefone= @telefone, telefone1= @telefone1, cnpj_cpf= @cpf, ponto_referencia = @pontoReferencia, cor = @cor, lado = @lado, posicao= @posicao, rua_entrada= @ruaEntrada, data_nascimento= @dataNascimento where codigo = @codigo;";
                    comando.Parameters.AddWithValue("codigo", codigo);
                    comando.Parameters.AddWithValue("nome", nome);
                    comando.Parameters.AddWithValue("endereco", Endereco);
                    comando.Parameters.AddWithValue("bairro", Bairro);
                    comando.Parameters.AddWithValue("cidade", Cidade);
                    comando.Parameters.AddWithValue("estado", Estado);
                    comando.Parameters.AddWithValue("cep", Cep);
                    comando.Parameters.AddWithValue("telefone", Telefone);
                    comando.Parameters.AddWithValue("telefone1", Telefone1);
                    comando.Parameters.AddWithValue("cpf", Cpf);
                    comando.Parameters.AddWithValue("pontoReferencia", PontoReferencia);
                    comando.Parameters.AddWithValue("cor", Cor);
                    comando.Parameters.AddWithValue("lado", Lado);
                    comando.Parameters.AddWithValue("posicao", Posicao);
                    comando.Parameters.AddWithValue("ruaEntrada", RuaEntrada);
                    comando.Parameters.AddWithValue("dataNascimento", DataNascimento);

                            
                  if (comando.ExecuteNonQuery() <= 1)
                  {
                    MessageBox.Show("Sucesso ao Atualizar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      
        /// <summary>
        /// retorna e exibe os dados de todos os clientes ordenados pelo código
        /// </summary>
        public void BuscarDados()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_cliente where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo",codigo);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                        
                        nome = reader["nome"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Cpf = reader["cnpj_cpf"].ToString();
                        PontoReferencia = reader["ponto_referencia"].ToString();
                        Cor = reader["cor"].ToString();
                        Lado = reader["lado"].ToString();
                        Posicao = reader["posicao"].ToString();
                        RuaEntrada = reader["rua_entrada"].ToString();
                        DataNascimento = reader["data_nascimento"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                        Estado = reader["estado"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("id Invalido");
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
       
        /// <summary>
        /// Desativa todos os campos
        /// </summary>
        public void ObjVazio()
        {
           
            nome = null;
            Endereco = null;
            Bairro = null;
            Cidade = null;
            Cep = null;
            Telefone = null;
            Telefone1 = null;
            Cpf = null;
            PontoReferencia = null;
            Cor = null;
            Lado = null;
            Posicao = null;
            RuaEntrada = null;
            DataNascimento = null;
        }
      
        /// <summary>
        /// busca o primeiro cliente existente pelo código
        /// </summary>
        public void BuscarPrimeiroRegistro()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_cliente  order by codigo asc limit 1;";
                comando.Parameters.AddWithValue("codigo", codigo);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                        
                        nome = reader["nome"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Cpf = reader["cnpj_cpf"].ToString();
                        PontoReferencia = reader["ponto_referencia"].ToString();
                        Cor = reader["cor"].ToString();
                        Lado = reader["lado"].ToString();
                        Posicao = reader["posicao"].ToString();
                        RuaEntrada = reader["rua_entrada"].ToString();
                        DataNascimento = reader["data_nascimento"].ToString();
                        Estado = reader["estado"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());

                    }
                    else
                    {
                        MessageBox.Show("id Invalido");
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
      
        /// <summary>
        /// busca o último cliente existente pelo código
        /// </summary>
        public void BuscarUltimoRegistro()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_cliente  order by codigo desc limit 1;";
                comando.Parameters.AddWithValue("codigo", codigo);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                       
                        nome = reader["nome"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Cpf = reader["cnpj_cpf"].ToString();
                        PontoReferencia = reader["ponto_referencia"].ToString();
                        Cor = reader["cor"].ToString();
                        Lado = reader["lado"].ToString();
                        Posicao = reader["posicao"].ToString();
                        RuaEntrada = reader["rua_entrada"].ToString();
                        DataNascimento = reader["data_nascimento"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                        Estado = reader["estado"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("id Invalido");
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
       
        /// <summary>
        /// Busca e exibe em Grid os clientes pelo endereço (LIKE)
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        /// <param name="filtro">parâmetro de definição de retorno</param>
        public void BuscarDataGridFiltro(DataGridView dataGridView, TextBox filtro)
        {
            try
            {
                string strgComando = "select codigo as'Cod' ,endereco as 'Endereço', bairro as 'Bairro', nome as 'nome',telefone as 'Telefone' from tb_cliente where endereco  like '%" + filtro.Text.Trim() + "%'";
                
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 35;
                dataGridView.Columns[1].Width = 390;
                dataGridView.Columns[2].Width = 100;
                dataGridView.Columns[3].Width = 120;
                dataGridView.Columns[4].Width = 120;


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
        /// Exibe código, endereço, bairro, nome e telefone de todos os clientes
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select codigo as'Cod' ,endereco as 'Endereço', bairro as 'Bairro', nome as 'nome',telefone as 'Telefone' from tb_cliente;";
                
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 35;
                dataGridView.Columns[1].Width = 390;
                dataGridView.Columns[2].Width = 100;
                dataGridView.Columns[3].Width = 120;
                dataGridView.Columns[4].Width = 120;


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
        /// salva as informações da ação de cadastro (log)
        /// </summary>
        public void InserirRegistro()
        {

            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_atualizacao_cliente (usuario, codigo_cliente, data_hora) values (@usuario,@codigo_cliente,@data_hora);";
                //comando.Parameters.AddWithValue("usuario", Usuario.user.nome);
                comando.Parameters.AddWithValue("usuario","Teste");
                comando.Parameters.AddWithValue("codigo_cliente",codigo );
                comando.Parameters.AddWithValue("data_hora", DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
                comando.ExecuteNonQuery();
 
            }
            catch (Exception a)
            {

                MessageBox.Show("Erro Registro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }


        }


    }
}
