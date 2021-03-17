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
    class OcorrenciaDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();
        #region Variaveis de Classe

        public int id;
        public string responsavel;
        public string dataRegistro;
        public int codigoFuncionario;
        public string nomeFuncionario;
        public string cargoFuncionario;
        public string tipoOcorrencia;
        public string dataOcorrencia;
        public string observacao;
        public int mes;
        public int ano;
        #endregion


        #region Tipo de Ocorrencia

        public void CarregarComboBoxOcorrencia(ComboBox tipoOcorrencia)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome from tb_tipo_ocorrencia order by nome asc;";
                MySqlDataReader reader = comando.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                tipoOcorrencia.DataSource = table;
                tipoOcorrencia.DisplayMember = "nome";
                reader.Close();
                reader.Dispose();
            }
            catch (Exception a)
            {
            }
            finally
            {
                conexao.Close();
            }
        }
        public void AddTipoOcorrencia(string ocorrencia)
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_tipo_ocorrencia (nome) values (@nome);";
                comando.Parameters.AddWithValue("nome", ocorrencia.Trim().ToUpper());
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
        public void DeletarTipoOcorrencia(string ocorrencia)
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_tipo_ocorrencia where nome = @nome;";
                comando.Parameters.AddWithValue("nome", ocorrencia.Trim().ToUpper());
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

        #endregion

        public void CarregarDados(int x)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_registro_ocorrencia where id = @id;";
                comando.Parameters.AddWithValue("id", x);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome_funcionario"] != null)
                    {
                        id = int.Parse(reader["id"].ToString());
                        responsavel = reader["responsavel"].ToString();
                        dataRegistro = reader["data_registro"].ToString();
                        codigoFuncionario = int.Parse(reader["codigo_funcionario"].ToString());
                        nomeFuncionario = reader["nome_funcionario"].ToString();
                        cargoFuncionario = reader["cargo_funcionario"].ToString();
                        tipoOcorrencia = reader["tipo_ocorrencia"].ToString();
                        dataOcorrencia = reader["data_ocorrencia"].ToString();
                        observacao = reader["observacao"].ToString();

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

        public void InserirDados()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_registro_ocorrencia (responsavel, data_registro, codigo_funcionario, nome_funcionario, cargo_funcionario, tipo_ocorrencia, data_ocorrencia, observacao, mes, ano) values (@responsavel, @dataRegistro, @codigoFuncionario, @nomeFuncionario, @cargoFuncionario, @tipo_ocorrencia, @dataOcorrencia, @observacao, @mes, @ano);";
                comando.Parameters.AddWithValue("responsavel", responsavel);
                comando.Parameters.AddWithValue("@dataRegistro", dataRegistro);
                comando.Parameters.AddWithValue("@codigoFuncionario", @codigoFuncionario);
                comando.Parameters.AddWithValue("@nomeFuncionario", @nomeFuncionario);
                comando.Parameters.AddWithValue("@cargoFuncionario", @cargoFuncionario);
                comando.Parameters.AddWithValue("@dataOcorrencia", @dataOcorrencia);
                comando.Parameters.AddWithValue("@tipo_ocorrencia", tipoOcorrencia);
                comando.Parameters.AddWithValue("@observacao", @observacao);
                comando.Parameters.AddWithValue("@mes", @mes);
                comando.Parameters.AddWithValue("@ano", @ano);

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
        public void ObjVazio()
        {
            responsavel = null;
            dataRegistro = null;
            codigoFuncionario = 0;
            nomeFuncionario = null;
            cargoFuncionario = null;
            tipoOcorrencia = null;
            dataOcorrencia = null;
            observacao = null;
            mes = 0;
            ano = 0;
        }

        //completo
        public void CarregarDataGridCompleto(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {
                
            }
            finally
            {
                conexao.Close();
            }
        }


        //cod+Mes+Ano
        public void CarregarDataGridFiltroCodMesAno(DataGridView dataGridView, Label lblCodigo, ComboBox cbMes, ComboBox cbAno)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && mes = @mes && ano = @ano;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario",lblCodigo.Text);
                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("ano", cbAno.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod
        public void CarregarDataGridFiltroCod(DataGridView dataGridView,Label lblCodigo)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario=@codigo_funcionario;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario",lblCodigo.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod+Mes
        public void CarregarDataGridFiltroCodMes(DataGridView dataGridView, Label lblCodigo,ComboBox cbMes)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && mes = @mes;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);
                comando.Parameters.AddWithValue("mes", cbMes.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod+Ano
        public void CarregarDataGridFiltroCodAno(DataGridView dataGridView, Label lblCodigo, ComboBox cbAno)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && ano = @ano;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);
               
                comando.Parameters.AddWithValue("ano", cbAno.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }


        //Mes+Ano
        public void CarregarDataGridFiltroMesAno(DataGridView dataGridView, ComboBox cbMes, ComboBox cbAno)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where  mes = @mes && ano = @ano;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
               
                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("ano", cbAno.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //Ano
        public void CarregarDataGridFiltroAno(DataGridView dataGridView, ComboBox cbAno)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where ano = @ano;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);

               
                comando.Parameters.AddWithValue("ano", cbAno.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //Mes
        public void CarregarDataGridFiltroMes(DataGridView dataGridView, ComboBox cbMes)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where  mes = @mes;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);

                comando.Parameters.AddWithValue("mes", cbMes.Text);
               

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        
        //cod+Mes+Ano+Ocorrencia
        public void CarregarDataGridFiltroCodMesAnoOcorrencia(DataGridView dataGridView, Label lblCodigo, ComboBox cbMes, ComboBox cbAno, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && mes = @mes && ano = @ano && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);
                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("ano", cbAno.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod+Ocorrencia
        public void CarregarDataGridFiltroCodOcorrencia(DataGridView dataGridView, Label lblCodigo, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod+Mes+Ocorrencia
        public void CarregarDataGridFiltroCodMesOcorrencia(DataGridView dataGridView, Label lblCodigo, ComboBox cbMes, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && mes = @mes && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);
                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //cod+Ano+Ocorrencia
        public void CarregarDataGridFiltroCodAnoOcorrencia(DataGridView dataGridView, Label lblCodigo, ComboBox cbAno, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where codigo_funcionario = @codigo_funcionario && ano = @ano && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                comando.Parameters.AddWithValue("codigo_funcionario", lblCodigo.Text);

                comando.Parameters.AddWithValue("ano", cbAno.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }


        //Mes+Ano+Ocorrencia
        public void CarregarDataGridFiltroMesAnoOcorrencia(DataGridView dataGridView, ComboBox cbMes, ComboBox cbAno, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where  mes = @mes && ano = @ano && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);

                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("ano", cbAno.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //Ano+Ocorrencia
        public void CarregarDataGridFiltroAnoOcorrencia(DataGridView dataGridView, ComboBox cbAno, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where ano = @ano && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                comando.Parameters.AddWithValue("ano", cbAno.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //Mes+Ocorrencia
        public void CarregarDataGridFiltroMesOcorrencia(DataGridView dataGridView, ComboBox cbMes, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where  mes = @mes && tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);

                comando.Parameters.AddWithValue("mes", cbMes.Text);
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }

        //Ocorrencia
        public void CarregarDataGridFiltroOcorrencia(DataGridView dataGridView, ComboBox cbOcorrencia)
        {
            try
            {
                string strgComando = "SELECT id, nome_funcionario as 'Funcionário',codigo_funcionario as 'cod', cargo_funcionario as 'Cargo', tipo_ocorrencia as 'Ocorrência', observacao as 'Observação', data_ocorrencia as 'Data Ocorrência', responsavel as 'Responsável', data_registro as 'Data Registro' FROM tb_registro_ocorrencia where  tipo_ocorrencia = @tipo_ocorrencia;";

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);

                
                comando.Parameters.AddWithValue("tipo_ocorrencia", cbOcorrencia.Text);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[2].Width = 30;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].Width = 100;
                dataGridView.Columns[5].Width = 250;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 120;
                dataGridView.Columns[8].Width = 150;


            }
            catch (Exception a)
            {

            }
            finally
            {
                conexao.Close();
            }
        }










    }
}
