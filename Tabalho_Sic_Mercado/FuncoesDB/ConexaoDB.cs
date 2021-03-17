﻿using MySql.Data.MySqlClient;

using System.Configuration;


namespace Mercado.FuncoesDB
{
    class ConexaoDB
    {
        private static readonly ConexaoDB instanciaMySql = new ConexaoDB();

        public static ConexaoDB getInstancia()
        {
            return instanciaMySql;
        }

        public MySqlConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ToString();
            return new MySqlConnection(conn);
        }


    }
}
