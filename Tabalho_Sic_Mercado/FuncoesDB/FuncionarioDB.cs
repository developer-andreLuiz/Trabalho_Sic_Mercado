using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Mercado.FuncoesDB
{   /// <summary>
/// Esta Classe é responsável por toda manipulação de banco de dados do Funcionário
/// </summary>
    public class FuncionarioDB
    {

        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        public int Codigo { get; set; }
        public string nome { get; set; }
        public string Senha { get; set; }
        public string Habilitado { get; set; }

        public int nivel;
        public string Cargo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Telefone1 { get; set; }

        public float compras;
        public string Observacao { get; set; }
        public string Apagador { get; set; }
        public string SenhaAcesso { get; set; }

        public float salario;
        public string DataAdmissao { get; set; }
        public string NewCargo { get; set; }

        /// <summary>
        /// insere um novo funcionario no banco de dados
        /// </summary>
        public void InserirDados()
        {

            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_funcionario (nome,compras,endereco,bairro,salario,cidade,telefone,telefone1,habilitado,cargo,observacao,senha,senha_acesso,apagador,nivel,data_admissao) values (@txtnome,@cbLimite,@txtRua,@txtBairro, @txtSalario,@txtCidade, @txtTelefone, @txtTelefone1 , @cbHabilitado,@txtCargo, @txtObservacao, @txtSenhaLogin, @txtSenhaCompra, @txtSenhaApagador, @cbNivel, @dataAdmissao);";

                comando.Parameters.AddWithValue("txtnome", nome);
                comando.Parameters.AddWithValue("cbLimite", compras);
                comando.Parameters.AddWithValue("txtRua", Endereco);
                comando.Parameters.AddWithValue("txtBairro", Bairro);
                comando.Parameters.AddWithValue("txtSalario", salario);
                comando.Parameters.AddWithValue("txtCidade", Cidade);
                comando.Parameters.AddWithValue("txtTelefone", Telefone);
                comando.Parameters.AddWithValue("txtTelefone1", Telefone1);
                comando.Parameters.AddWithValue("cbHabilitado", Habilitado);
                comando.Parameters.AddWithValue("txtCargo", Cargo);
                comando.Parameters.AddWithValue("txtObservacao", Observacao);
                comando.Parameters.AddWithValue("txtSenhaLogin", Senha);
                comando.Parameters.AddWithValue("txtSenhaCompra", SenhaAcesso);
                comando.Parameters.AddWithValue("txtSenhaApagador", Apagador);
                comando.Parameters.AddWithValue("cbNivel", nivel);
                comando.Parameters.AddWithValue("dataAdmissao", DataAdmissao);



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
        /// altera as informações de um funcionario existente
        /// </summary>
        public void AlterarDados()
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_funcionario set nome=@nome, compras = @compras, endereco= @endereco, bairro = @bairro, salario = @salario, cidade= @cidade, telefone = @telefone, telefone1 = @telefone1, habilitado= @habilitado, cargo= @cargo, observacao= @observacao, senha= @senha, senha_acesso= @SenhaAcesso, apagador = @apagador, nivel= @nivel, data_admissao = @dataAdmissao where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", Codigo);
                comando.Parameters.AddWithValue("nome", nome);
                comando.Parameters.AddWithValue("compras", compras);
                comando.Parameters.AddWithValue("endereco", Endereco);
                comando.Parameters.AddWithValue("bairro", Bairro);
                comando.Parameters.AddWithValue("salario", salario);
                comando.Parameters.AddWithValue("cidade", Cidade);
                comando.Parameters.AddWithValue("telefone", Telefone);
                comando.Parameters.AddWithValue("telefone1", Telefone1);
                comando.Parameters.AddWithValue("habilitado", Habilitado);
                comando.Parameters.AddWithValue("cargo", Cargo);
                comando.Parameters.AddWithValue("observacao", Observacao);
                comando.Parameters.AddWithValue("senha", Senha);
                comando.Parameters.AddWithValue("senhaAcesso", SenhaAcesso);
                comando.Parameters.AddWithValue("apagador", Apagador);
                comando.Parameters.AddWithValue("nivel", nivel);
                comando.Parameters.AddWithValue("dataAdmissao", DataAdmissao);


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
        /// retorna as informações de um funcionario pelo código
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
                comando.CommandText = "select * from tb_funcionario where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", Codigo);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                        compras = float.Parse(reader["compras"].ToString());
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        try
                        {
                            salario = float.Parse(reader["salario"].ToString());
                        }
                        catch
                        {
                            salario = 0;
                        }
                        
                        Cidade = reader["cidade"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Habilitado = reader["habilitado"].ToString();
                        Cargo = reader["Cargo"].ToString();
                        Senha = reader["senha"].ToString();
                        SenhaAcesso = reader["senha_acesso"].ToString();
                        Apagador = reader["apagador"].ToString();
                        nivel = int.Parse(reader["nivel"].ToString());
                        Observacao = reader["observacao"].ToString();
                        Codigo = int.Parse(reader["codigo"].ToString());
                        try
                        {
                            DataAdmissao = reader["data_admissao"].ToString();
                        }
                        catch
                        {
                            DataAdmissao = "dd/mm/aaaa";
                        }
                       
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
        /// exibe o primeiro funcionario registrado
        /// </summary>
        public void BuscaPrimeiroRegistro()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_funcionario order by codigo asc limit 1;";
                comando.Parameters.AddWithValue("codigo", Codigo);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                        compras = float.Parse(reader["compras"].ToString());
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        try
                        {
                            salario = float.Parse(reader["salario"].ToString());
                        }
                        catch
                        {
                            salario = 0;
                        }
                        Cidade = reader["cidade"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Habilitado = reader["habilitado"].ToString();
                        Cargo = reader["Cargo"].ToString();
                        Senha = reader["senha"].ToString();
                        SenhaAcesso = reader["senha_acesso"].ToString();
                        Apagador = reader["apagador"].ToString();
                        nivel = int.Parse(reader["nivel"].ToString());
                        Observacao = reader["observacao"].ToString();
                        try
                        {
                            DataAdmissao = reader["data_admissao"].ToString();
                        }
                        catch
                        {
                            DataAdmissao = "dd/mm/aaaa";
                        }

                        Codigo = int.Parse(reader["codigo"].ToString());
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
        /// exibe o ultimo funcionario registrado
        /// </summary>
        public void BuscaUltimoRegistro()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_funcionario order by codigo desc limit 1;";
                comando.Parameters.AddWithValue("codigo", Codigo);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                        compras = float.Parse(reader["compras"].ToString());
                        Endereco = reader["endereco"].ToString();
                        Bairro = reader["bairro"].ToString();
                        try
                        {
                            salario = float.Parse(reader["salario"].ToString());
                        }
                        catch
                        {
                            salario = 0;
                        }
                        Cidade = reader["cidade"].ToString();
                        Telefone = reader["telefone"].ToString();
                        Telefone1 = reader["telefone1"].ToString();
                        Habilitado = reader["habilitado"].ToString();
                        Cargo = reader["Cargo"].ToString();
                        Senha = reader["senha"].ToString();
                        SenhaAcesso = reader["senha_acesso"].ToString();
                        Apagador = reader["apagador"].ToString();
                        nivel = int.Parse(reader["nivel"].ToString());
                        Observacao = reader["observacao"].ToString();
                        try
                        {
                            DataAdmissao = reader["data_admissao"].ToString();
                        }
                        catch
                        {
                            DataAdmissao = "dd/mm/aaaa";
                        }

                        Codigo = int.Parse(reader["codigo"].ToString());
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
        /// altera todos os campos para nulo ou default
        /// </summary>
        public void ObjVazio()
        {
            nome = null;
            compras = 0;
            Endereco = null;
            Bairro = null;
            salario = 0;
            Cidade = null;
            Telefone = null;
            Telefone1 = null;
            Habilitado = null;
            Cargo = null;
            Senha = null;
            SenhaAcesso = null;
            Apagador = null;
            nivel = 1;
            Observacao = null;
            DataAdmissao = null;

        }

        /// <summary>
        /// registra o usuario, data e hora de cada alteração feita
        /// </summary>
        public void InserirRegistro()
        {

            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_atualizacao_funcionario (usuario, codigo_funcionario, data_hora) values (@usuario,@codigo_funcionario,@data_hora);";
               // comando.Parameters.AddWithValue("usuario", Usuario.user.nome);
                comando.Parameters.AddWithValue("usuario", "Teste");
                comando.Parameters.AddWithValue("codigo_funcionario", Codigo);
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
        /// Busca e exibe em grid os funcionarios pelo nome (LIKE)
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        /// <param name="filtro">parâmetro de definição de retorno</param>
        public void DataGridFuncionarioFiltro(DataGridView dataGridView, TextBox filtro)
        {
            try
            {
                string strgComando = "select * from tb_funcionario where nome  like '%" + filtro.Text.Trim() + "%'";
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
        /// Exibe código e nome dos funcionarios em grid
        /// </summary>
        /// <param name="dataGridView">componente necessário para o retorno das informações</param>
        public void CarregarDataGrid(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select codigo as 'Código', nome as 'nome', cargo as 'Cargo' from tb_funcionario;";
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

                dataGridView.Columns[0].Width = 80;
                dataGridView.Columns[1].Width = 350;
                dataGridView.Columns[2].Width = 150;




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
       
        #region Cargo
        /// <summary>
        ///Insere um novo cargo
        /// </summary>
        public void InserirCargo()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_funcionario_cargo (nome) values (@nome);";
                comando.Parameters.AddWithValue("nome", NewCargo);



                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Inserir Cargo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    //MessageBox.Show("Erro ao Inserir Cargo");
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
        /// Deleta um cargo
        /// </summary>
        public void DelCargo()
        {

            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_funcionario_cargo where nome = @nome;";
                comando.Parameters.AddWithValue("nome", NewCargo);



                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Deletar Cargo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                   // MessageBox.Show("Erro ao Deletar");
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
        /// Carrega os cargos existentes no banco de dados
        /// </summary>
        /// <param name="cb">componente necessário para o funcionamento da função</param>
        public void CarregarComboBoxCargo(ComboBox cb)
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome from tb_funcionario_cargo order by nome asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                //DataRow row = table.NewRow();
                //row["nome"] = ".Buscar Categoria";


                //table.Rows.InsertAt(row, 0);
                cb.DataSource = table;
                // cbnome.ValueMember = "codigo";
                cb.DisplayMember = "nome";

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
        #endregion

        #region Senha
        /// <summary>
        /// Verifica se existe um funcionario já registrado com o mesmo nome
        /// </summary>
        /// <param name="x">parâmetro necessário para o funcionamento da função</param>
        /// <returns>retorna true se existir um funcionario com o mesmo nome</returns>
        public bool verificarDadosnome(int x)
        {
            object teste;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select count(*) as 'registros' from tb_funcionario where nome = @nome ;";
                comando.Parameters.AddWithValue("nome", nome);
                teste = comando.ExecuteScalar();


                if ((long)teste > x)
                {
                    return true;

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
            return false;
        }
        /// <summary>
        /// Verifica se existe um funcionario já registrado com a mesma senha
        /// </summary>
        /// <param name="x">parâmetro necessário para o funcionamento da função</param>
        /// <returns>retorna true se existir um funcionario com a mesma senha</returns>
        public bool verificarDadosSenha(int x)
        {
            object teste;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select count(*) as 'registros' from tb_funcionario where senha = @senha ;";
                comando.Parameters.AddWithValue("senha", Senha);
                teste = comando.ExecuteScalar();


                if ((long)teste > x)
                {
                    return true;

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
            return false;
        }

        /// <summary>
        /// Verifica se existe um funcionario já registrado com o mesmo Apagador
        /// </summary>
        /// <param name="x">parâmetro necessário para o funcionamento da função</param>
        /// <returns>retorna true se existir um funcionario com o mesmo Apagador</returns>
        public bool verificarDadosSenhaApagador(int x)
        {
            object teste;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select count(*) as 'registros' from tb_funcionario where senha = @apagador ;";
                comando.Parameters.AddWithValue("apagador", Apagador);
                teste = comando.ExecuteScalar();

                if ((long)teste > x)
                {
                    return true;

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
            return false;
        }

        /// <summary>
        /// Verifica se existe um funcionario já registrado com a mesma senha de acesso
        /// </summary>
        /// <param name="x">parâmetro necessário para o funcionamento da função</param>
        /// <returns>retorna true se existir um funcionario com a mesma senha de acesso</returns>
        public bool verificarDadosSenhaAcesso(int x)
        {
            object teste;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select count(*) as 'registros' from tb_funcionario where senha = @senhaAcesso ;";
                comando.Parameters.AddWithValue("senhaAcesso", SenhaAcesso);
                teste = comando.ExecuteScalar();

                if ((long)teste > x)
                {
                    return true;

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
            return false;
        }

        #endregion




    }
}








   
    


