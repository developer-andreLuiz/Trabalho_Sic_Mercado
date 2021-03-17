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
     class Usuario
    {
        public static Usuario user = new Usuario();

        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        public string nome;
        public string login;
        public string apagador;
        public string senhaCompra;
        public string habilitado;
        public int nivel;
        public string cargo;


      

      

        public void VerificarLogin()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select nome, senha, habilitado, nivel, apagador, senha_acesso, cargo from tb_funcionario where senha =@login;";
                comando.Parameters.AddWithValue("login", login);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {

                        nome = reader["nome"].ToString();
                        login = reader["senha"].ToString();
                        apagador = reader["apagador"].ToString();
                        senhaCompra = reader["senha_acesso"].ToString();
                        habilitado = reader["habilitado"].ToString();
                        nivel = int.Parse(reader["nivel"].ToString());
                        cargo = reader["cargo"].ToString();



                    }
                    else
                    {
                        MessageBox.Show("Login Não Existe");
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

        public void VerificarApagador()
        {

        }

        public void ObjVazio()
        {

            nome = string.Empty;
            login = string.Empty;
            apagador = string.Empty;
            senhaCompra = string.Empty;
            habilitado = string.Empty;
            nivel = 0;
            cargo = null;

        }

       
      

     


    }
}
