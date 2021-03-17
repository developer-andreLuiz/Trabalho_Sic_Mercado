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
    class NfEProdutosDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region variaveis

        public object auto;
        public object id;
        public object cnpj;
        public object item;
        public object cod_fornecedor;
        public object cod_produto;
        public object c_prod;
        public object x_prod;
        public object c_ean;
        public object ncm;
        public object cfop;
        public object u_com;
        public object qtd_prod_compra;
        public object v_un_com;
        public object v_prod;
        public object c_ean_trib;
        public object u_trib;
        public object q_trib;
        public object v_un_trib;
        public object v_desc;
        public object v_outro;
        public object v_frete;
        public object v_seg;
        public object icms_orig;
        public object icms_cst;
        public object icms_csosn;
        public object icms_p_cred_sn;
        public object icms_v_cred_icmssn;
        public object icms_mod_bc;
        public object icms_p_red_bc;
        public object icms_v_bc;
        public object icms_p_icms;
        public object icms_v_icms;
        public object icms_mod_bcst;
        public object icms_p_mvast;
        public object icms_p_red_bcst;
        public object icms_v_bcst;
        public object icms_p_icmsst;
        public object icms_v_icmsst;
        public object icms_mot_desI_cms;
        public object icms_v_bcs_tret;
        public object icms_v_icmss_tret;
        public object ipi_cl_enq;
        public object ipi_cnpj_prod;
        public object ipi_c_selo;
        public object ipi_q_selo;
        public object ipi_c_enq;
        public object ipi_cst;
        public object ipi_v_bc;
        public object ipi_p_ipi;
        public object ipi_q_unid;
        public object ipi_v_unid;
        public object ipi_v_ipi;
        public object ii_v_bc;
        public object ii_v_desp_adu;
        public object ii_v_ii;
        public object ii_v_iof;
        public object pis_cst;
        public object pis_v_bc;
        public object pis_p_pis;
        public object pis_v_pis;
        public object pis_q_bc_prod;
        public object pis_v_aliq_prod;
        public object cofins_cst;
        public object cofins_v_bc;
        public object cofins_p_cofins;
        public object cofins_v_cofins;
        public object cofins_q_bc_prod;
        public object cofins_v_aliq_prod;
        public object issqn_v_bc;
        public object v_aliq;
        public object v_issqn;
        public object c_mun_fg;
        public object c_list_serv;
        public object c_sit_trib;
        public object codigo;
        public object bipado;
        public object iguala_nota;
        public int totalLinhasMySql;


        #endregion


        /// <summary>
        /// Exibe dados da tabela tb_nfeprodutos no DataGrid
        /// </summary>
        /// <param name="dataGridView"></param>
        public void CarregarDataGridMySql(DataGridView dataGridView)
        {
            try
            {
                string strgComando = "select * from tb_nfeprodutos order by auto asc;";

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
        /// Reseta e deleta os dados na tabela tb_nfeprodutos
        /// </summary>
        public void TruncateTable()
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_nfeprodutos;";
                comando.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                //  MessageBox.Show(a.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        /// <summary>
        /// Retorna Total de linhas tb_nfeprodutos
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
                comando.CommandText = "select count(auto) as total FROM tb_nfeprodutos; ";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    totalLinhasMySql = int.Parse(reader["total"].ToString());
                }


            }
            catch (Exception a)
            {
                // MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                conexao.Close();
            }
        }

        /// <summary>
        /// Insere novos dados na tabela tb_nfeprodutos
        /// </summary>
        public void InserirDados()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_nfeprodutos (id,cnpj,item,cod_fornecedor,cod_produto,c_prod,x_prod,c_ean,ncm,cfop,u_com,qtd_prod_compra,v_un_com,v_prod,c_ean_trib,u_trib,q_trib,v_un_trib,v_desc,v_outro,v_frete,v_seg,icms_orig,icms_cst,icms_csosn,icms_p_cred_sn,icms_v_cred_icmssn,icms_mod_bc,icms_p_red_bc,icms_v_bc,icms_p_icms,icms_v_icms,icms_mod_bcst,icms_p_mvast,icms_p_red_bcst,icms_v_bcst,icms_p_icmsst,icms_v_icmsst,icms_mot_desI_cms,icms_v_bcs_tret,icms_v_icmss_tret,ipi_cl_enq,ipi_cnpj_prod,ipi_c_selo,ipi_q_selo,ipi_c_enq,ipi_cst,ipi_v_bc,ipi_p_ipi,ipi_q_unid,ipi_v_unid,ipi_v_ipi,ii_v_bc,ii_v_desp_adu,ii_v_ii,ii_v_iof,pis_cst,pis_v_bc,pis_p_pis,pis_v_pis,pis_q_bc_prod,pis_v_aliq_prod,cofins_cst,cofins_v_bc,cofins_p_cofins,cofins_v_cofins,cofins_q_bc_prod,cofins_v_aliq_prod,issqn_v_bc,v_aliq,v_issqn,c_mun_fg,c_list_serv,c_sit_trib,codigo,bipado,iguala_nota) values (@id,@cnpj,@item,@cod_fornecedor,@cod_produto,@c_prod,@x_prod,@c_ean,@ncm,@cfop,@u_com,@qtd_prod_compra,@v_un_com,@v_prod,@c_ean_trib,@u_trib,@q_trib,@v_un_trib,@v_desc,@v_outro,@v_frete,@v_seg,@icms_orig,@icms_cst,@icms_csosn,@icms_p_cred_sn,@icms_v_cred_icmssn,@icms_mod_bc,@icms_p_red_bc,@icms_v_bc,@icms_p_icms,@icms_v_icms,@icms_mod_bcst,@icms_p_mvast,@icms_p_red_bcst,@icms_v_bcst,@icms_p_icmsst,@icms_v_icmsst,@icms_mot_desI_cms,@icms_v_bcs_tret,@icms_v_icmss_tret,@ipi_cl_enq,@ipi_cnpj_prod,@ipi_c_selo,@ipi_q_selo,@ipi_c_enq,@ipi_cst,@ipi_v_bc,@ipi_p_ipi,@ipi_q_unid,@ipi_v_unid,@ipi_v_ipi,@ii_v_bc,@ii_v_desp_adu,@ii_v_ii,@ii_v_iof,@pis_cst,@pis_v_bc,@pis_p_pis,@pis_v_pis,@pis_q_bc_prod,@pis_v_aliq_prod,@cofins_cst,@cofins_v_bc,@cofins_p_cofins,@cofins_v_cofins,@cofins_q_bc_prod,@cofins_v_aliq_prod,@issqn_v_bc,@v_aliq,@v_issqn,@c_mun_fg,@c_list_serv,@c_sit_trib,@codigo,@bipado,@iguala_nota);";

                //comando.Parameters.AddWithValue("auto", auto);
                comando.Parameters.AddWithValue("id", Singleton.instancia.notaGlobal.NFe.infNFe.Id);
                comando.Parameters.AddWithValue("cnpj", 0);
                comando.Parameters.AddWithValue("item", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.qCom);
                comando.Parameters.AddWithValue("cod_fornecedor", Singleton.instancia.codFornecedor_nfe_produto);
                comando.Parameters.AddWithValue("cod_produto", Singleton.instancia.codProd_nfe_produto);
                comando.Parameters.AddWithValue("c_prod", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cProd);
                comando.Parameters.AddWithValue("x_prod", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.xProd);
                comando.Parameters.AddWithValue("c_ean", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEAN);
                comando.Parameters.AddWithValue("ncm", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.NCM);
                comando.Parameters.AddWithValue("cfop", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.CFOP);
                comando.Parameters.AddWithValue("u_com", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.uCom);
                comando.Parameters.AddWithValue("qtd_prod_compra", qtd_prod_compra);
                comando.Parameters.AddWithValue("v_un_com", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.vUnCom);
                comando.Parameters.AddWithValue("v_prod", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.vProd);
                comando.Parameters.AddWithValue("c_ean_trib", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.cEANTrib);
                comando.Parameters.AddWithValue("u_trib", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.uTrib);
                comando.Parameters.AddWithValue("q_trib", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.qTrib);
                comando.Parameters.AddWithValue("v_un_trib", Singleton.instancia.notaGlobal.NFe.infNFe.det[Singleton.instancia.matriz].prod.vUnTrib);
                comando.Parameters.AddWithValue("v_desc", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vDesc);
                comando.Parameters.AddWithValue("v_outro", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vOutro);
                comando.Parameters.AddWithValue("v_frete", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vFrete);
                comando.Parameters.AddWithValue("v_seg", Singleton.instancia.notaGlobal.NFe.infNFe.total.ICMSTot.vSeg);
                comando.Parameters.AddWithValue("icms_orig", "");
                comando.Parameters.AddWithValue("icms_cst", "");
                comando.Parameters.AddWithValue("icms_csosn", "");
                comando.Parameters.AddWithValue("icms_p_cred_sn", "");
                comando.Parameters.AddWithValue("icms_v_cred_icmssn", "");
                comando.Parameters.AddWithValue("icms_mod_bc", "");
                comando.Parameters.AddWithValue("icms_p_red_bc", icms_p_red_bc);
                comando.Parameters.AddWithValue("icms_v_bc", "");
                comando.Parameters.AddWithValue("icms_p_icms", "");
                comando.Parameters.AddWithValue("icms_v_icms", "");
                comando.Parameters.AddWithValue("icms_mod_bcst", "");
                comando.Parameters.AddWithValue("icms_p_mvast", "");
                comando.Parameters.AddWithValue("icms_p_red_bcst", "");
                comando.Parameters.AddWithValue("icms_v_bcst", "");
                comando.Parameters.AddWithValue("icms_p_icmsst", "");
                comando.Parameters.AddWithValue("icms_v_icmsst", "");
                comando.Parameters.AddWithValue("icms_mot_desI_cms", 0);
                comando.Parameters.AddWithValue("icms_v_bcs_tret", 0);
                comando.Parameters.AddWithValue("icms_v_icmss_tret", 0);
                comando.Parameters.AddWithValue("ipi_cl_enq", "");
                comando.Parameters.AddWithValue("ipi_cnpj_prod", "");
                comando.Parameters.AddWithValue("ipi_c_selo", "");
                comando.Parameters.AddWithValue("ipi_q_selo", "");
                comando.Parameters.AddWithValue("ipi_c_enq", 999);
                comando.Parameters.AddWithValue("ipi_cst", "");
                comando.Parameters.AddWithValue("ipi_v_bc", "");
                comando.Parameters.AddWithValue("ipi_p_ipi", "");
                comando.Parameters.AddWithValue("ipi_q_unid", "");
                comando.Parameters.AddWithValue("ipi_v_unid", "");
                comando.Parameters.AddWithValue("ipi_v_ipi", "");
                comando.Parameters.AddWithValue("ii_v_bc", "");
                comando.Parameters.AddWithValue("ii_v_desp_adu", "");
                comando.Parameters.AddWithValue("ii_v_ii", "");
                comando.Parameters.AddWithValue("ii_v_iof", "");
                comando.Parameters.AddWithValue("pis_cst", "");
                comando.Parameters.AddWithValue("pis_v_bc", "");
                comando.Parameters.AddWithValue("pis_p_pis", "");
                comando.Parameters.AddWithValue("pis_v_pis", "");
                comando.Parameters.AddWithValue("pis_q_bc_prod", "");
                comando.Parameters.AddWithValue("pis_v_aliq_prod", "");
                comando.Parameters.AddWithValue("cofins_cst", "");
                comando.Parameters.AddWithValue("cofins_v_bc", "");
                comando.Parameters.AddWithValue("cofins_p_cofins", "");
                comando.Parameters.AddWithValue("cofins_v_cofins", "");
                comando.Parameters.AddWithValue("cofins_q_bc_prod", "");
                comando.Parameters.AddWithValue("cofins_v_aliq_prod", "");
                comando.Parameters.AddWithValue("issqn_v_bc", "");
                comando.Parameters.AddWithValue("v_aliq", "");
                comando.Parameters.AddWithValue("v_issqn", "");
                comando.Parameters.AddWithValue("c_mun_fg", "");
                comando.Parameters.AddWithValue("c_list_serv", "");
                comando.Parameters.AddWithValue("c_sit_trib", "");
                comando.Parameters.AddWithValue("codigo", Singleton.instancia.codProd_nfe_produto);
                comando.Parameters.AddWithValue("bipado", "False");
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
        /// Insere novos dados na tabela tb_nfeprodutos
        /// </summary>
        public void InserirDadosManual()
        {
            try
            {
                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_nfeprodutos (id, cod_fornecedor,qtd_prod_compra,v_prod,codigo) values (@id,@cod_fornecedor,@qtd_prod_compra,@v_prod,@codigo);";

                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("cod_fornecedor", cod_fornecedor);
                comando.Parameters.AddWithValue("qtd_prod_compra", qtd_prod_compra);
                comando.Parameters.AddWithValue("v_prod", v_prod);
                comando.Parameters.AddWithValue("codigo", codigo);


                comando.ExecuteNonQuery();

            }
            catch (Exception a)
            {

                // MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }


        }

        public void Deletar(string localId, string localcod_fornecedor, string localCodigo)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_nfeprodutos where id = @localId && cod_fornecedor = @cod_fornecedor && codigo = @localCodigo;";
                comando.Parameters.AddWithValue("localId", localId);
                comando.Parameters.AddWithValue("cod_fornecedor", localcod_fornecedor);
                comando.Parameters.AddWithValue("localCodigo", localCodigo);
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

        public void ObjVazio()
        {
            codigo = null;
        }


        public void DeletarTbNfeProdutos(string localId, string localCodigoFornecedor)
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_nfeprodutos where cod_fornecedor = @localCodigoFornecedor &&  id = @localId;";
                comando.Parameters.AddWithValue("localId", localId);
                comando.Parameters.AddWithValue("localCodigoFornecedor", localCodigoFornecedor);
               
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
    }
}
