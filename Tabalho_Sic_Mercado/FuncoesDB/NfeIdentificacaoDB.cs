using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.VariaveisGlobais;

namespace Mercado.FuncoesDB
{
    class NfeIdentificacaoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis 
        public object id;
        public object cnpj;
        public object cod_fornecedor;
        public object nome_fornecedor;
        public object c_uf;
        public object c_nf;
        public object nat_op;
        public object ind_pad;
        public object new_mod;
        public object serie;
        public object n_nf;
        public object ind_pres;
        public object ind_final;
        public object id_dest;
        public object dh_cont;
        public object d_emi;
        public object d_sai_ent;
        public object h_sai_ent;
        public object tp_nf;
        public object c_mun_fg;
        public object dh_saient;
        public object tp_imp;
        public object tp_emis;
        public object d_hemi;
        public object c_dv;
        public object tp_amb;
        public object fin_nfe;
        public object proc_emi;
        public object ver_proc;
        public object v_bc;
        public object v_icms;
        public object v_bcst;
        public object v_st;
        public object v_prod;
        public object v_frete;
        public object v_seg;
        public object v_desc;
        public object v_ii;
        public object x_just;
        public object v_ipi;
        public object v_pis;
        public object v_confis;
        public object v_outro;
        public object v_nf;
        public object v_tot_trib;
        public object iss_qn_tot_v_serv;
        public object iss_qn_tot_v_bc;
        public object iss_qn_tot_v_iss;
        public object iss_qn_tot_v_pis;
        public object iss_qn_tot_v_cofins;
        public object fat_n_fat;
        public object fat_v_orig;
        public object fat_v_desc;
        public object fat_v_liq;
        public object num;
        public object confer;
        public object nota_br;
        public object iguala_nota;

        public int totalLinhasMySql;
        #endregion


        /// <summary>
        /// Insere novos dados na tabela tb_nfe_identificacao_nota
        /// </summary>
        public void InserirDados()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_nfe_identificacao_nota (id,cnpj,cod_fornecedor,nome_fornecedor,c_uf,c_nf,nat_op,ind_pad,new_mod,serie,n_nf,ind_pres,ind_final,id_dest,dh_cont,d_emi,d_sai_ent,h_sai_ent,tp_nf,c_mun_fg,dh_saient,tp_imp,tp_emis,d_hemi,c_dv,tp_amb,fin_nfe,proc_emi,ver_proc,v_bc,v_icms,v_bcst,v_st,v_prod,v_frete,v_seg,v_desc,v_ii,x_just,v_ipi,v_pis,v_confis,v_outro,v_nf,v_tot_trib,iss_qn_tot_v_serv,iss_qn_tot_v_bc,iss_qn_tot_v_iss,iss_qn_tot_v_pis,iss_qn_tot_v_cofins,fat_n_fat,fat_v_orig,fat_v_desc,fat_v_liq,confer,nota_br,iguala_nota) values (@id,@cnpj,@cod_fornecedor,@nome_fornecedor,@c_uf,@c_nf,@nat_op,@ind_pad,@new_mod,@serie,@n_nf,@ind_pres,@ind_final,@id_dest,@dh_cont,@d_emi,@d_sai_ent,@h_sai_ent,@tp_nf,@c_mun_fg,@dh_saient,@tp_imp,@tp_emis,@d_hemi,@c_dv,@tp_amb,@fin_nfe,@proc_emi,@ver_proc,@v_bc,@v_icms,@v_bcst,@v_st,@v_prod,@v_frete,@v_seg,@v_desc,@v_ii,@x_just,@v_ipi,@v_pis,@v_confis,@v_outro,@v_nf,@v_tot_trib,@iss_qn_tot_v_serv,@iss_qn_tot_v_bc,@iss_qn_tot_v_iss,@iss_qn_tot_v_pis,@iss_qn_tot_v_cofins,@fat_n_fat,@fat_v_orig,@fat_v_desc,@fat_v_liq,@confer,@nota_br,@iguala_nota);";

                comando.Parameters.AddWithValue("id", Singleton.instancia.notaGlobal.NFe.infNFe.Id);
                comando.Parameters.AddWithValue("cnpj", Singleton.instancia.notaGlobal.NFe.infNFe.emit.CNPJ);
                comando.Parameters.AddWithValue("cod_fornecedor", Singleton.instancia.codFornecedor_nfe_produto);
                comando.Parameters.AddWithValue("nome_fornecedor", Singleton.instancia.nomeFornecedor_nfe_produto);
                comando.Parameters.AddWithValue("c_uf", Singleton.instancia.notaGlobal.NFe.infNFe.ide.cUF);
                comando.Parameters.AddWithValue("c_nf", Singleton.instancia.notaGlobal.NFe.infNFe.ide.cNF);
                comando.Parameters.AddWithValue("nat_op", Singleton.instancia.notaGlobal.NFe.infNFe.ide.natOp);
                comando.Parameters.AddWithValue("ind_pad", 0);
                comando.Parameters.AddWithValue("new_mod", Singleton.instancia.notaGlobal.NFe.infNFe.ide.mod);
                comando.Parameters.AddWithValue("serie", Singleton.instancia.notaGlobal.NFe.infNFe.ide.serie);
                comando.Parameters.AddWithValue("n_nf", Singleton.instancia.notaGlobal.NFe.infNFe.ide.nNF);
                comando.Parameters.AddWithValue("ind_pres", Singleton.instancia.notaGlobal.NFe.infNFe.ide.indPres);
                comando.Parameters.AddWithValue("ind_final", Singleton.instancia.notaGlobal.NFe.infNFe.ide.indFinal);
                comando.Parameters.AddWithValue("id_dest", Singleton.instancia.notaGlobal.NFe.infNFe.dest.indIEDest);
                comando.Parameters.AddWithValue("dh_cont", "");
                comando.Parameters.AddWithValue("d_emi", Singleton.instancia.notaGlobal.NFe.infNFe.ide.dhEmi);
                comando.Parameters.AddWithValue("d_sai_ent", "");
                comando.Parameters.AddWithValue("h_sai_ent", "");
                comando.Parameters.AddWithValue("tp_nf", Singleton.instancia.notaGlobal.NFe.infNFe.ide.tpNF);
                comando.Parameters.AddWithValue("c_mun_fg", Singleton.instancia.notaGlobal.NFe.infNFe.ide.cMunFG);
                comando.Parameters.AddWithValue("dh_saient", "");
                comando.Parameters.AddWithValue("tp_imp", Singleton.instancia.notaGlobal.NFe.infNFe.ide.tpImp);
                comando.Parameters.AddWithValue("tp_emis", Singleton.instancia.notaGlobal.NFe.infNFe.ide.tpEmis);
                comando.Parameters.AddWithValue("d_hemi", Singleton.instancia.notaGlobal.NFe.infNFe.ide.dhEmi);
                comando.Parameters.AddWithValue("c_dv", Singleton.instancia.notaGlobal.NFe.infNFe.ide.cDV);
                comando.Parameters.AddWithValue("tp_amb", Singleton.instancia.notaGlobal.NFe.infNFe.ide.tpAmb);
                comando.Parameters.AddWithValue("fin_nfe", Singleton.instancia.notaGlobal.NFe.infNFe.ide.finNFe);
                comando.Parameters.AddWithValue("proc_emi", Singleton.instancia.notaGlobal.NFe.infNFe.ide.procEmi);
                comando.Parameters.AddWithValue("ver_proc", Singleton.instancia.notaGlobal.NFe.infNFe.ide.verProc);
                comando.Parameters.AddWithValue("v_bc", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vBC);
                comando.Parameters.AddWithValue("v_icms", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vICMS);
                comando.Parameters.AddWithValue("v_bcst", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vBCST);
                comando.Parameters.AddWithValue("v_st", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vST);
                comando.Parameters.AddWithValue("v_prod", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vProd);
                comando.Parameters.AddWithValue("v_frete", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vFrete);
                comando.Parameters.AddWithValue("v_seg", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vSeg);
                comando.Parameters.AddWithValue("v_desc", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vDesc);
                comando.Parameters.AddWithValue("v_ii", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vII);
                comando.Parameters.AddWithValue("x_just", "");
                comando.Parameters.AddWithValue("v_ipi", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vIPI);
                comando.Parameters.AddWithValue("v_pis", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vPIS);
                comando.Parameters.AddWithValue("v_confis", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vCOFINS);
                comando.Parameters.AddWithValue("v_outro", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vOutro);
                comando.Parameters.AddWithValue("v_nf", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vNF);
                comando.Parameters.AddWithValue("v_tot_trib", "");
                comando.Parameters.AddWithValue("iss_qn_tot_v_serv", iss_qn_tot_v_serv);
                comando.Parameters.AddWithValue("iss_qn_tot_v_bc", iss_qn_tot_v_bc);
                comando.Parameters.AddWithValue("iss_qn_tot_v_iss", iss_qn_tot_v_iss);
                comando.Parameters.AddWithValue("iss_qn_tot_v_pis", iss_qn_tot_v_pis);
                comando.Parameters.AddWithValue("iss_qn_tot_v_cofins", iss_qn_tot_v_cofins);
                comando.Parameters.AddWithValue("fat_n_fat", Singleton.instancia.notaGlobal.NFe.infNFe.cobr.fat.nFat);
                comando.Parameters.AddWithValue("fat_v_orig", Singleton.instancia.notaGlobal.NFe.infNFe.cobr.fat.vOrig);
                comando.Parameters.AddWithValue("fat_v_desc", "");
                comando.Parameters.AddWithValue("fat_v_liq", Singleton.instancia.notaGlobal.NFe.infNFe.cobr.fat.vLiq);
                //comando.Parameters.AddWithValue("num", num);
                comando.Parameters.AddWithValue("confer", "Não");
                comando.Parameters.AddWithValue("nota_br", "Não");
                comando.Parameters.AddWithValue("iguala_nota", 0);


                comando.ExecuteNonQuery();

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
        /// Exibe dados da tabela tb_nfe_identificacao_nota no DataGrid
        /// </summary>
        /// <param name="dataGridView"></param>
        public void CarregarDataGridMySql(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select * from tb_nfe_identificacao_nota order by num asc;";

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
                //  MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

        }

        /// <summary>
        /// Reseta e deleta os dados na tabela tb_nfe_identificacao_nota
        /// </summary>
        public void TruncateTable()
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_nfe_identificacao_nota;";
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

        /// <summary>
        /// Retorna Total de linhas tb_nfe_identificacao_nota
        /// </summary>
        public void TotalLinhasMySql()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select count(num) as total FROM tb_nfe_identificacao_nota; ";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    totalLinhasMySql = int.Parse(reader["total"].ToString());
                }


            }
            catch (Exception a)
            {
                //MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                conexao.Close();
            }
        }



        public void Deletar(string localNumeroNF, string localCodFornecedor)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_nfe_identificacao_nota where n_nf = @localNumeroNF && cod_fornecedor= @localCodFornecedor;";
                comando.Parameters.AddWithValue("localNumeroNF", localNumeroNF);
                comando.Parameters.AddWithValue("localCodFornecedor", localCodFornecedor);
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


        public void BuscarID(string localCodFornecedor, string localNumeroNF)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_nfe_identificacao_nota where cod_fornecedor = @localCodFornecedor && n_nf = @localNumeroNF;";
                comando.Parameters.AddWithValue("localNumeroNF", localNumeroNF);
                comando.Parameters.AddWithValue("localCodFornecedor", localCodFornecedor);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["cod_fornecedor"] != null)
                    {

                        id = reader["id"].ToString();
                        cod_fornecedor = reader["cod_fornecedor"].ToString();

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


        public void BuscarChave(string localCodFornecedor, string localId)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_nfe_identificacao_nota where cod_fornecedor = @localCodFornecedor && id = @id;";
                comando.Parameters.AddWithValue("id", localId);
                comando.Parameters.AddWithValue("localCodFornecedor", localCodFornecedor);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["id"] != null)
                    {

                        id = reader["id"].ToString();
                        cod_fornecedor = reader["cod_fornecedor"].ToString();

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




        public void BuscarDadosId(int x)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_nfe_identificacao_nota where cod_fornecedor = @cod_fornecedor order by id desc limit 1;";
                comando.Parameters.AddWithValue("cod_fornecedor", x);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome_fornecedor"] != null)
                    {

                        id = reader["id"].ToString();
                        num = reader["num"].ToString();


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
        public void BuscarDadosNum()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_nfe_identificacao_nota order by num desc limit 1;";
               
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["nome_fornecedor"] != null)
                    {

                      
                        num = reader["num"].ToString();


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

    }
}
