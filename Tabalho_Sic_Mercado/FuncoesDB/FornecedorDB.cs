using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace Mercado.FuncoesDB
{   /// <summary>
/// Esta Classe é responsável por toda manipulação de banco de dados do Fornecedor
/// </summary>
    class FornecedorDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        public int codigo;
        public string nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Telefone1 { get; set; }
        public string Representante { get; set; }
        public string CnpjCpf { get; set; }
        public string Observacao { get; set; }
        public string Registro { get; set; }
        public string Nota { get; set; }
        public string nomeCodigo { get; set; }
        public string CnpjCodigo { get; set; }

        /// <summary>
        /// Registra os dados de cada alteração de informações feita em fornecedores (log)
        /// </summary>
        public void InserirRegistro()
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

             MySqlCommand comando = conexao.CreateCommand();
             comando.CommandText = "insert into tb_atualizacao_fornecedor (usuario, codigo_fornecedor, data_hora) values (@usuario,@codigo_fornecedor,@data_hora);";
             comando.Parameters.AddWithValue("usuario", "Teste");
             comando.Parameters.AddWithValue("usuario", Usuario.user.nome);
             comando.Parameters.AddWithValue("codigo_fornecedor", codigo);
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

        /// <summary>
        /// Valida e insere informações de um novo fornecedor no banco de dados
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
                comando.CommandText = "insert into tb_fornecedor (nome,endereco,bairro,cidade,estado,cep,telefone,telefone1,representante,cnpj_cpf,observacao,registro,nota) values(@nome,@endereco,@bairro,@cidade,@estado,@cep,@telefone,@telefone1,@representante,@cnpjCpf,@observacao,@registro,@nota);";
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("endereco", Endereco);
                comando.Parameters.AddWithValue("bairro", Bairro);
                comando.Parameters.AddWithValue("cidade", Cidade);
                comando.Parameters.AddWithValue("estado", Estado);
                comando.Parameters.AddWithValue("cep", Cep);
                comando.Parameters.AddWithValue("telefone", Telefone);
                comando.Parameters.AddWithValue("telefone1", Telefone1);
                comando.Parameters.AddWithValue("representante", Representante);
                comando.Parameters.AddWithValue("cnpjCpf", CnpjCpf);
                comando.Parameters.AddWithValue("observacao", Observacao);
                comando.Parameters.AddWithValue("registro", Registro);
                comando.Parameters.AddWithValue("nota", Nota);
               
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
        /// Cadastra um novo código de funcionário
        /// </summary>
        public void InserirDadosCodigo()
        {

            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_fornecedor_codigo (nome_codigo, cnpj_codigo, codigo_codigo) values(@nomeCodigo, @cnpjCodigo, @codigo);";
                comando.Parameters.AddWithValue("nomeCodigo", nomeCodigo);
                comando.Parameters.AddWithValue("cnpjCodigo", CnpjCodigo);
                comando.Parameters.AddWithValue("@codigo", @codigo);


                if (comando.ExecuteNonQuery() <= 1)
                {
                    MessageBox.Show("Sucesso ao Inserir Codigo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao Inserir Codigo");
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
        /// Altera as informações de um fornecedor já registrado
        /// </summary>
        public void AlterarDados()
        {

            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_fornecedor set nome = @nome, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, telefone = @telefone, telefone1 = @telefone1, representante = @representante, cnpj_cpf =@cnpjCpf, observacao = @observacao, registro = @registro , nota = @nota  where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("endereco", Endereco);
                comando.Parameters.AddWithValue("bairro", Bairro);
                comando.Parameters.AddWithValue("cidade", Cidade);
                comando.Parameters.AddWithValue("estado", Estado);
                comando.Parameters.AddWithValue("cep", Cep);
                comando.Parameters.AddWithValue("telefone", Telefone);
                comando.Parameters.AddWithValue("telefone1", Telefone1);
                comando.Parameters.AddWithValue("representante", Representante);
                comando.Parameters.AddWithValue("cnpjCpf", CnpjCpf);
                comando.Parameters.AddWithValue("observacao", Observacao);
                comando.Parameters.AddWithValue("registro", Registro);
                comando.Parameters.AddWithValue("nota", Nota);

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
                MessageBox.Show("Erro alterar : " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }


        }
        /// <summary>
        /// retorna e exibe os dados de todos os fornecedores ordenados pelo código
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
                comando.CommandText = "select * from tb_fornecedor where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo",codigo);

                MySqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                        
                        nome = reader["nome"].ToString();
                        CnpjCpf = reader["cnpj_cpf"].ToString();
                        Registro = reader["registro"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Estado = reader["estado"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Representante = reader["representante"].ToString();
                        Observacao = reader["observacao"].ToString();
                        Nota = reader["nota"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                    }
                }
            }
            catch (Exception a)
            {
              MessageBox.Show("Erro buscar: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
              conexao.Close();
            }

        }

        /// <summary>
        /// Verifia se o fornecedor já existe pelo cnpj/cpf
        /// </summary>
        /// <param name="variavel">define o resultado da pesquisa</param>
        public void VerificarCadastroFornecedor(string variavel)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "SELECT * FROM tb_fornecedor WHERE cnpj_cpf like '%" + variavel +"%';";
                

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                     
                        CnpjCpf = reader["cnpj_cpf"].ToString();
                        Registro = reader["registro"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Estado = reader["estado"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Representante = reader["representante"].ToString();
                        Observacao = reader["observacao"].ToString();
                        Nota = reader["nota"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro buscar: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Estado = null;
            Cep = null;
            Telefone = null;
            Telefone1 = null;
            Representante = null;
            CnpjCpf = null;
            Observacao = null;
            Registro = null;
            Nota = null;
        }

        /// <summary>
        /// Retorna o primeiro fornecedor
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
                comando.CommandText = "select * from tb_fornecedor order by codigo asc limit 1;";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                       
                        nome = reader["nome"].ToString();
                        CnpjCpf = reader["cnpj_cpf"].ToString();
                        Registro = reader["registro"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Estado = reader["estado"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Representante = reader["representante"].ToString();
                        Observacao = reader["observacao"].ToString();
                        Nota = reader["nota"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro buscar: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Retorna o último fornecedor
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
                comando.CommandText = "select * from tb_fornecedor order by codigo desc limit 1;";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                      
                        nome = reader["nome"].ToString();
                        CnpjCpf = reader["cnpj_cpf"].ToString();
                        Registro = reader["registro"].ToString();
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        Cidade = reader["cidade"].ToString();
                        Estado = reader["estado"].ToString();
                        Cep = reader["cep"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Representante = reader["representante"].ToString();
                        Observacao = reader["observacao"].ToString();
                        Nota = reader["nota"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro buscar: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca pelo nome e exibe os fornecedores em grid 
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        /// <param name="filtro">define o resultado da pesquisa</param>
        public void BuscarDadosDataGridFiltro(DataGridView dataGridView, TextBox filtro)
        {
            try
            {
                string strgComando = "select * from tb_fornecedor where nome  like '%" + filtro.Text.Trim() + "%'";
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
        /// Exibe nome e código dos fornecedores em grid
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select codigo as 'Codigo', nome as 'nome' from tb_fornecedor;";

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
                dataGridView.Columns[1].Width = 500;



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
        //datagrid mesmo nome  completo
        public void CarregarDataGridMesmonome(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select codigo, nome as 'nome Principal', cnpj_codigo as 'Cnpj Código',nome_codigo as 'nome Repetido' from tb_fornecedor inner join tb_fornecedor_codigo on tb_fornecedor.codigo=tb_fornecedor_codigo.codigo_codigo order by nome asc;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;

                dataGridView.Columns[0].Width = 80;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 80;
                dataGridView.Columns[3].Width = 200;
                




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

        //deletar dados produto codigo
        public void DeletarDados(string localString)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_fornecedor_codigo where cnpj_codigo = @cnpj_codigo;";
                comando.Parameters.AddWithValue("cnpj_codigo", localString);

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
        public void InserirRegistroFornecedorCodigo(string r)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_atualizacao_fornecedor_codigo (cpf_codigo) values (@cpf_codigo);";
                comando.Parameters.AddWithValue("cpf_codigo", r);
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
        /// <summary>
        /// Verifica se já existe o fornecedor pelo código
        /// </summary>
        /// <param name="variavel">define o resultado da pesquisa</param>
        public void VerificarCadastroFornecedorCodigo(string variavel)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "SELECT * FROM tb_fornecedor_codigo WHERE codigo like '%" + variavel + "%';";
                

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                        CnpjCpf = reader["cnpj"].ToString();
                        codigo = int.Parse(reader["codigo"].ToString());
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro buscar: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

        }



    }
}
