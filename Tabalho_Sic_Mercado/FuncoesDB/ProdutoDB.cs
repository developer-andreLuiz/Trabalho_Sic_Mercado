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
    class ProdutoDB
    {
        MySqlConnection conexao = ConexaoDB.getInstancia().getConexao();

        #region Variaveis da Classe 
        public int codigo { get; set; }
        public string codigo_barra { get; set; }
        public string nome { get; set; }
        public string nome_voz { get; set; }
        public float custo_unitario { get; set; }
        public float margem_venda { get; set; }
        public float valor_venda { get; set; }
        public float margem_promocao { get; set; }
        public float valor_promocao { get; set; }
        public string gramatura { get; set; }
        public string embalagem { get; set; }
        public float peso_produto { get; set; }
        public int iguala_produto { get; set; }
        public int iguala_fardo { get; set; }
        public string fardo { get; set; }
        public int quantidade_fardo { get; set; }
        public string img { get; set; }
        public int categoria_pai { get; set; }
        public int categoria_filho { get; set; }
        public int categoria_neto { get; set; }

        #endregion
        
        public void InserirDados(ProdutoDB produtoDB)
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_produtos (codigo_barra, nome, nome_voz, custo_unitario, margem_venda, valor_venda, margem_promocao, valor_promocao, gramatura, embalagem, peso_produto, iguala_produto, iguala_fardo, fardo, quantidade_fardo, img, id_pai, id_filho, id_neto) values (@codigo_barra, @nome, @nome_voz, @custo_unitario, @margem_venda, @valor_venda, @margem_promocao, @valor_promocao, @gramatura, @embalagem, @peso_produto, @iguala_produto, @iguala_fardo, @fardo, @quantidade_fardo, @img, @id_pai, @id_filho, @id_neto);";
                comando.Parameters.AddWithValue("codigo_barra", produtoDB.codigo_barra);
                comando.Parameters.AddWithValue("nome", produtoDB.nome);
                comando.Parameters.AddWithValue("nome_voz", produtoDB.nome_voz);
                comando.Parameters.AddWithValue("custo_unitario", produtoDB.custo_unitario);
                comando.Parameters.AddWithValue("margem_venda", produtoDB.margem_venda);
                comando.Parameters.AddWithValue("valor_venda", produtoDB.valor_venda);
                comando.Parameters.AddWithValue("margem_promocao", produtoDB.margem_promocao);
                comando.Parameters.AddWithValue("valor_promocao", produtoDB.valor_promocao);
                comando.Parameters.AddWithValue("gramatura", produtoDB.gramatura);
                comando.Parameters.AddWithValue("embalagem", produtoDB.embalagem);
                comando.Parameters.AddWithValue("peso_produto", produtoDB.peso_produto);
                comando.Parameters.AddWithValue("iguala_produto", produtoDB.iguala_produto);
                comando.Parameters.AddWithValue("iguala_fardo", produtoDB.iguala_fardo);
                comando.Parameters.AddWithValue("fardo", produtoDB.fardo);
                comando.Parameters.AddWithValue("quantidade_fardo", produtoDB.quantidade_fardo);
                comando.Parameters.AddWithValue("img", produtoDB.img);
                comando.Parameters.AddWithValue("id_pai", produtoDB.categoria_pai);
                comando.Parameters.AddWithValue("id_filho", produtoDB.categoria_filho);
                comando.Parameters.AddWithValue("id_neto", produtoDB.categoria_neto);

                if (comando.ExecuteNonQuery() <= 1)
                {
                   //MessageBox.Show("Sucesso ao Inserir");
                }
                else
                {
                    //MessageBox.Show("Erro ao Inserir");
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
        public void AlterarDados(ProdutoDB produtoDB)
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_produtos set codigo_barra = @codigo_barra, nome = @nome, nome_voz = @nome_voz, custo_unitario = @custo_unitario, margem_venda = @margem_venda, valor_venda = @valor_venda, margem_promocao = @margem_promocao,  valor_promocao = @valor_promocao, gramatura = @gramatura, embalagem = @embalagem, peso_produto = @peso_produto, iguala_produto = @iguala_produto, iguala_fardo = @iguala_fardo, fardo = @fardo, quantidade_fardo = @quantidade_fardo, img = @img, id_pai = @id_pai, id_filho = @id_filho, id_neto = @id_neto where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", produtoDB.codigo);
                comando.Parameters.AddWithValue("codigo_barra", produtoDB.codigo_barra);
                comando.Parameters.AddWithValue("nome", produtoDB.nome);
                comando.Parameters.AddWithValue("nome_voz", produtoDB.nome_voz);
                comando.Parameters.AddWithValue("custo_unitario", produtoDB.custo_unitario);
                comando.Parameters.AddWithValue("margem_venda", produtoDB.margem_venda);
                comando.Parameters.AddWithValue("valor_venda", produtoDB.valor_venda);
                comando.Parameters.AddWithValue("margem_promocao", produtoDB.margem_promocao);
                comando.Parameters.AddWithValue("valor_promocao", produtoDB.valor_promocao);
                comando.Parameters.AddWithValue("gramatura", produtoDB.gramatura);
                comando.Parameters.AddWithValue("embalagem", produtoDB.embalagem);
                comando.Parameters.AddWithValue("peso_produto", produtoDB.peso_produto);
                comando.Parameters.AddWithValue("iguala_produto", produtoDB.iguala_produto);
                comando.Parameters.AddWithValue("iguala_fardo", produtoDB.iguala_fardo);
                comando.Parameters.AddWithValue("fardo", produtoDB.fardo);
                comando.Parameters.AddWithValue("quantidade_fardo", produtoDB.quantidade_fardo);
                comando.Parameters.AddWithValue("img","https://imgapkstorage.blob.core.windows.net/produto/"+produtoDB.codigo.ToString());
                comando.Parameters.AddWithValue("id_pai", produtoDB.categoria_pai);
                comando.Parameters.AddWithValue("id_filho", produtoDB.categoria_filho);
                comando.Parameters.AddWithValue("id_neto", produtoDB.categoria_neto);

                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Atualizar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  MessageBox.Show("Erro ao Atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public ProdutoDB BuscarDados(int localCodigo)
        {
            ProdutoDB produtoDB = new ProdutoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_produtos where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", localCodigo);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["codigo"] != null)
                    {
                        produtoDB.codigo = int.Parse(reader["codigo"].ToString());
                        produtoDB.codigo_barra = reader["codigo_barra"].ToString();
                        produtoDB.nome = reader["nome"].ToString();
                        produtoDB.nome_voz = reader["nome_voz"].ToString();
                        produtoDB.custo_unitario = float.Parse(reader["custo_unitario"].ToString());
                        produtoDB.margem_venda = float.Parse(reader["margem_venda"].ToString());
                        produtoDB.valor_venda = float.Parse(reader["valor_venda"].ToString());
                        produtoDB.margem_promocao = float.Parse(reader["margem_promocao"].ToString());
                        produtoDB.valor_promocao = float.Parse(reader["valor_promocao"].ToString());
                        produtoDB.gramatura = reader["gramatura"].ToString();
                        produtoDB.embalagem = reader["embalagem"].ToString();
                        produtoDB.peso_produto = float.Parse(reader["peso_produto"].ToString());
                        produtoDB.iguala_produto = int.Parse(reader["iguala_produto"].ToString());
                        produtoDB.iguala_fardo = int.Parse(reader["iguala_fardo"].ToString());
                        produtoDB.fardo = reader["fardo"].ToString();
                        produtoDB.quantidade_fardo = int.Parse(reader["quantidade_fardo"].ToString());
                        produtoDB.img = reader["img"].ToString();
                        produtoDB.categoria_pai = int.Parse(reader["id_pai"].ToString());
                        produtoDB.categoria_filho = int.Parse(reader["id_filho"].ToString());
                        produtoDB.categoria_neto = int.Parse(reader["id_neto"].ToString());
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
            return produtoDB;
        }
        public ProdutoDB BuscarPrimeiroRegistro()
        {
            ProdutoDB produtoDB = new ProdutoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_produtos order by codigo asc limit 1;";
                comando.Parameters.AddWithValue("codigo", codigo);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["codigo"] != null)
                    {
                        produtoDB.codigo = int.Parse(reader["codigo"].ToString());
                        produtoDB.codigo_barra = reader["codigo_barra"].ToString();
                        produtoDB.nome = reader["nome"].ToString();
                        produtoDB.nome_voz = reader["nome_voz"].ToString();
                        produtoDB.custo_unitario = float.Parse(reader["custo_unitario"].ToString());
                        produtoDB.margem_venda = float.Parse(reader["margem_venda"].ToString());
                        produtoDB.valor_venda = float.Parse(reader["valor_venda"].ToString());
                        produtoDB.margem_promocao = float.Parse(reader["margem_promocao"].ToString());
                        produtoDB.valor_promocao = float.Parse(reader["valor_promocao"].ToString());
                        produtoDB.gramatura = reader["gramatura"].ToString();
                        produtoDB.embalagem = reader["embalagem"].ToString();
                        produtoDB.peso_produto = float.Parse(reader["peso_produto"].ToString());
                        produtoDB.iguala_produto = int.Parse(reader["iguala_produto"].ToString());
                        produtoDB.iguala_fardo = int.Parse(reader["iguala_fardo"].ToString());
                        produtoDB.fardo = reader["fardo"].ToString();
                        produtoDB.quantidade_fardo = int.Parse(reader["quantidade_fardo"].ToString());
                        produtoDB.img = reader["img"].ToString();
                        produtoDB.categoria_pai = int.Parse(reader["id_pai"].ToString());
                        produtoDB.categoria_filho = int.Parse(reader["id_filho"].ToString());
                        produtoDB.categoria_neto = int.Parse(reader["id_neto"].ToString());
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
            return produtoDB;
        }
        public ProdutoDB BuscarUltimoRegistro()
        {
            ProdutoDB produtoDB = new ProdutoDB();
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from tb_produtos order by codigo desc limit 1;";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["codigo"] != null)
                    {
                        produtoDB.codigo = int.Parse(reader["codigo"].ToString());
                        produtoDB.codigo_barra = reader["codigo_barra"].ToString();
                        produtoDB.nome = reader["nome"].ToString();
                        produtoDB.nome_voz = reader["nome_voz"].ToString();
                        produtoDB.custo_unitario = float.Parse(reader["custo_unitario"].ToString());
                        produtoDB.margem_venda = float.Parse(reader["margem_venda"].ToString());
                        produtoDB.valor_venda = float.Parse(reader["valor_venda"].ToString());
                        produtoDB.margem_promocao = float.Parse(reader["margem_promocao"].ToString());
                        produtoDB.valor_promocao = float.Parse(reader["valor_promocao"].ToString());
                        produtoDB.gramatura = reader["gramatura"].ToString();
                        produtoDB.embalagem = reader["embalagem"].ToString();
                        produtoDB.peso_produto = float.Parse(reader["peso_produto"].ToString());
                        produtoDB.iguala_produto = int.Parse(reader["iguala_produto"].ToString());
                        produtoDB.iguala_fardo = int.Parse(reader["iguala_fardo"].ToString());
                        produtoDB.fardo = reader["fardo"].ToString();
                        produtoDB.quantidade_fardo = int.Parse(reader["quantidade_fardo"].ToString());
                        produtoDB.img = reader["img"].ToString();
                        produtoDB.categoria_pai = int.Parse(reader["id_pai"].ToString());
                        produtoDB.categoria_filho = int.Parse(reader["id_filho"].ToString());
                        produtoDB.categoria_neto = int.Parse(reader["id_neto"].ToString());
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
            return produtoDB;
        }
        public void DeletarProduto(int localCodigo)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_produtos where codigo = @codigo;";
                comando.Parameters.AddWithValue("codigo", localCodigo);
                if (comando.ExecuteNonQuery() <= 1)
                {
                    //MessageBox.Show("Sucesso ao Deletar Categoria", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Erro ao Deletar");
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
        public void BuscarDataGridFiltroCategoriaNeto(DataGridView dataGridView, int localidneto)
        {
            try
            {
                
                string strgComando = "select nome, custo_unitario, valor_venda, iguala_produto from tb_produtos where id_neto = " + localidneto + " order by nome asc";
               
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);


                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                sqlDataAdapter.Fill(dtLista);
                dataGridView.DataSource = dtLista;
                dataGridView.Columns[0].Width = 300;
                dataGridView.Columns[1].Width = 80;
                dataGridView.Columns[2].Width = 80;
                dataGridView.Columns[3].Width = 80;
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
        public List<ProdutoDB> ListarProdutos()
        {
            List<ProdutoDB> listaFinal = new List<ProdutoDB>();
            try
            {
                string strgComando = "SELECT * FROM tb_produtos order by codigo asc;";

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
                    ProdutoDB newProduto = new ProdutoDB();

                    newProduto.codigo = int.Parse(dataRow["codigo"].ToString());
                    newProduto.codigo_barra = dataRow["codigo_barra"].ToString();
                    newProduto.nome = dataRow["nome"].ToString();
                    newProduto.nome_voz = dataRow["nome_voz"].ToString();
                    newProduto.custo_unitario = float.Parse(dataRow["custo_unitario"].ToString());
                    newProduto.margem_venda = float.Parse(dataRow["margem_venda"].ToString());
                    newProduto.valor_venda = float.Parse(dataRow["valor_venda"].ToString());
                    newProduto.margem_promocao = float.Parse(dataRow["margem_promocao"].ToString());
                    newProduto.valor_promocao = float.Parse(dataRow["valor_promocao"].ToString());
                    newProduto.gramatura = dataRow["gramatura"].ToString();
                    newProduto.embalagem = dataRow["embalagem"].ToString();
                    newProduto.peso_produto = float.Parse(dataRow["peso_produto"].ToString());
                    newProduto.iguala_produto = int.Parse(dataRow["iguala_produto"].ToString());
                    newProduto.iguala_fardo = int.Parse(dataRow["iguala_fardo"].ToString());
                    newProduto.fardo = dataRow["fardo"].ToString();
                    newProduto.quantidade_fardo = int.Parse(dataRow["quantidade_fardo"].ToString());
                    newProduto.img = dataRow["img"].ToString();
                    newProduto.categoria_pai = int.Parse(dataRow["id_pai"].ToString());
                    newProduto.categoria_filho = int.Parse(dataRow["id_filho"].ToString());
                    newProduto.categoria_neto = int.Parse(dataRow["id_neto"].ToString());

                    listaFinal.Add(newProduto);
                }

            }
            catch (Exception erro)
            {
                string a = erro.Message;
            }
            return listaFinal;
        }
      
        #region Alterar Tudo


        //#region InserirDados Código // atualizar funções banco atualizou

        //public void InserirDadosCodigo()
        //{

        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_produto_codigo ( referencia_codigo, descricao_codigo, codigo_codigo) values( @referenciaCodigo , @descricaoCodigo , @codigo);";

        //        comando.Parameters.AddWithValue("referenciaCodigo", referenciaCodigo);
        //        comando.Parameters.AddWithValue("descricaoCodigo", descricaoCodigo);
        //        comando.Parameters.AddWithValue("codigo", codigo);



        //        if (comando.ExecuteNonQuery() <= 1)
        //        {
        //            // MessageBox.Show("Sucesso ao Inserir Codigo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {

        //            // MessageBox.Show("Erro ao Inserir Codigo");
        //        }
        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }


        //}
        //public void BuscarDadosCodigo(string a)
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select count(referencia_codigo) as 'total' from tb_produto_codigo where referencia_codigo = @referencia_codigo;";
        //        comando.Parameters.AddWithValue("referencia_codigo", a);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["total"] != null)
        //            {
        //                z = int.Parse(reader["total"].ToString());

        //            }
        //            else
        //            {
        //                z = 0;
        //            }
        //        }

        //    }
        //    catch
        //    {


        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }


        //}

        //#endregion
        //#region Atualização

        //public void AlterarDadosCx()
        //{

        //    try
        //    {


        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "update tb_produtos set  referencia = @referencia, descricao = @descricao, peso_produto = @grama, nome_voz = @nome_voz, embalagem = @embalagem, numero = @quantidade, quant =@quantidadeFardo, unidade = @unidade, quantidade = @quantidadeUnidade, categoria = @categoria, subcategoria = @subCategoria, iguala = @categoriaIgualarProdutos, iguala_caixa = @fardoIgualaCxProdutos, ch_caixa = @fardoCxFechado, quantidade_fardo = @fardoQuantidade where codigo = @codigo;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("referencia", referencia);
        //        comando.Parameters.AddWithValue("descricao", descricao);
        //        comando.Parameters.AddWithValue("grama", grama);
        //        comando.Parameters.AddWithValue("nome_voz", nome_voz);
        //        comando.Parameters.AddWithValue("embalagem", embalagem);
        //        comando.Parameters.AddWithValue("quantidade", quantidade);
        //        comando.Parameters.AddWithValue("quantidadeFardo", quantidadeFardo);
        //        comando.Parameters.AddWithValue("unidade", unidade);
        //        comando.Parameters.AddWithValue("quantidadeUnidade", quantidadeUnidade);




        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("subCategoria", subCategoria);
        //        comando.Parameters.AddWithValue("categoriaIgualarProdutos", categoriaIgualarProdutos);

        //        comando.Parameters.AddWithValue("fardoIgualaCxProdutos", fardoIgualaCxProdutos);
        //        comando.Parameters.AddWithValue("fardoCxFechado", fardoCxFechado);
        //        comando.Parameters.AddWithValue("fardoQuantidade", fardoQuantidade);




        //        if (comando.ExecuteNonQuery() <= 1)
        //        {
        //            // MessageBox.Show("Sucesso ao Atualizar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            //  MessageBox.Show("Erro ao Atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }


        //}
        ////Atualiza todos os item com o mesmo iguala
        //public void AlterarDadosIguala()
        //{
        //    try
        //    {
        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();

        //        comando.CommandText = "update tb_produtos set categoria = @categoria,  subcategoria = @subCategoria, peso_produto = @grama, nome_voz = @nome_voz, embalagem = @embalagem, numero = @quantidade, margem = @margem, valor_venda = @venda, margem_promocao = @margemPromocao, valor_promocao = @valorPromocao,  = @modoMargem, quantidade_avista = @modoQuantidade where iguala = @categoriaIgualarProdutos;";
        //        comando.Parameters.AddWithValue("margem", margem);
        //        comando.Parameters.AddWithValue("venda", venda);
        //        comando.Parameters.AddWithValue("margemPromocao", margemPromocao);
        //        comando.Parameters.AddWithValue("valorPromocao", valorPromocao);
        //        comando.Parameters.AddWithValue("categoriaIgualarProdutos", categoriaIgualarProdutos);
        //        comando.Parameters.AddWithValue("modoMargem", modoMargem);
        //        comando.Parameters.AddWithValue("modoQuantidade", modoQuantidade);
        //        comando.Parameters.AddWithValue("grama", grama);
        //        comando.Parameters.AddWithValue("nome_voz", nome_voz);
        //        comando.Parameters.AddWithValue("embalagem", embalagem);
        //        comando.Parameters.AddWithValue("quantidade", quantidade);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("subCategoria", subCategoria);

        //        comando.ExecuteNonQuery();




        //    }
        //    catch (Exception a)
        //    {
        //        // MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }


        //}
        ////Atualiza o unidade na tela do fardo ---> muda fardo de açucar e automáticamente muda 1kg de açucar
        //public void AlterarDadosIgualaCxBaseFardo()
        //{
        //    try
        //    {
        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();
        //        //Buscando dados
        //        comando.CommandText = "SELECT * FROM tb_produtos where iguala_caixa = @fardoIgualaCxProdutos && ch_caixa= 'SIM'  order by custo_unitario desc ;";
        //        comando.Parameters.AddWithValue("fardoIgualaCxProdutos", fardoIgualaCxProdutos);

        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["descricao"] != null)
        //            {

        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());

        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());

        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());

        //                categoria = reader["categoria"].ToString();

        //                subCategoria = reader["subcategoria"].ToString();

        //                quantidadeFardo = int.Parse(reader["quantidade_fardo"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //            }
        //        }

        //        conexao.Close();
        //        conexao.Open();
        //        //aplicando atualização
        //        comando.CommandText = "update tb_produtos set custo_unitario = @custoUnitario, categoria = @categoria, subcategoria = @subCategoria, margem = @margem, valor_venda = @venda, margem_promocao = @margemPromocao, valor_promocao = @valorPromocao, quantidade_avista = @modoQuantidade where iguala_caixa = @fardoIgualaCxProdutos && ch_caixa ='NÃO'; ";

        //        comando.Parameters.AddWithValue("custoUnitario", custoUnitario / quantidadeFardo);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("subCategoria", subCategoria);
        //        comando.Parameters.AddWithValue("margem", margem);
        //        comando.Parameters.AddWithValue("venda", venda / quantidadeFardo);
        //        comando.Parameters.AddWithValue("margemPromocao", margemPromocao);
        //        comando.Parameters.AddWithValue("valorPromocao", valorPromocao / quantidadeFardo);
        //        comando.Parameters.AddWithValue("modoMargem", modoMargem);
        //        comando.Parameters.AddWithValue("modoQuantidade", modoQuantidade);
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {
        //        // MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }


        //}
        ////Atualiza o fardo na tela da unidade ---> muda 1k de açucar e automáticamente muda o fardo
        //public void AlterarDadosIgualaCxBaseUnidade()
        //{
        //    int igualacx = 0;
        //    try
        //    {
        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();
        //        //buscando quantidade no fardo
        //        comando.CommandText = "SELECT * FROM tb_produtos where iguala_caixa = @fardoIgualaCxProdutos && ch_caixa ='SIM'  order by custo_unitario desc limit 1;";
        //        comando.Parameters.AddWithValue("fardoIgualaCxProdutos", fardoIgualaCxProdutos);
        //        MySqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                try
        //                {
        //                    igualacx = int.Parse(reader["iguala"].ToString());
        //                }
        //                catch
        //                {
        //                    igualacx = 0;
        //                }
        //            }
        //        }

        //        custoUnitario *= fardoQuantidade;
        //        venda *= fardoQuantidade;
        //        valorPromocao *= fardoQuantidade;
        //        conexao.Close();

        //        conexao.Open();
        //        //aplicando a atualização
        //        comando.CommandText = "update tb_produtos set  custo_unitario = @custoUnitario, categoria= @categoria,  subcategoria= @subCategoria,  margem = @margem, valor_venda = @venda, margem_promocao = @margemPromocao, valor_promocao = @valorPromocao, quantidade_avista = @modoQuantidade where iguala_caixa = @fardoIgualaCxProdutos && ch_caixa ='SIM' ";
        //        comando.Parameters.AddWithValue("custoUnitario", custoUnitario);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("subCategoria", subCategoria);
        //        comando.Parameters.AddWithValue("margem", margem);
        //        comando.Parameters.AddWithValue("venda", venda);
        //        comando.Parameters.AddWithValue("margemPromocao", margemPromocao);
        //        comando.Parameters.AddWithValue("valorPromocao", valorPromocao);
        //        comando.Parameters.AddWithValue("modoMargem", modoMargem);
        //        comando.Parameters.AddWithValue("modoQuantidade", modoQuantidade);
        //        comando.ExecuteNonQuery();
        //        conexao.Close();



        //        conexao.Open();

        //        if (igualacx > 0)
        //        {
        //            comando.CommandText = "update tb_produtos set categoria = @categoria,  subcategoria = @subCategoria,  peso_produto = @grama, nome_voz = @nome_voz, embalagem = @embalagem, numero = @quantidade, margem = @margem, valor_venda = @venda, margem_promocao = @margemPromocao, valor_promocao = @valorPromocao, quantidade_avista = @modoQuantidade where iguala = @x;";
        //            comando.Parameters.AddWithValue("x", igualacx);
        //            comando.Parameters.AddWithValue("grama", grama);
        //            comando.Parameters.AddWithValue("nome_voz", nome_voz);
        //            comando.Parameters.AddWithValue("embalagem", embalagem);
        //            comando.Parameters.AddWithValue("quantidade", quantidade);

        //            comando.ExecuteNonQuery();
        //        }




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}
        //public void AlterarDadosLimpandoPromocao()
        //{
        //    try
        //    {
        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "update  tb_produtos set valor_promocao = 0.00 , margem_promocao = 0.00 where valor_promocao > 0 or margem_promocao != 0; ";
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}
        //#endregion
        //#region Consultas


        //public void BuscarDadosRef()
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where referencia = @referencia;";

        //        comando.Parameters.AddWithValue("referencia", referencia);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}
        //public void BuscarDadosRefNovo(string localReferencia)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where referencia = @referencia;";

        //        comando.Parameters.AddWithValue("referencia", localReferencia);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}



        //public void BuscarDadosCategoria(ComboBox localCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where codigo = @codigo && categoria = @categoria;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}
        //public void BuscarPrimeiroRegistroCategoria(ComboBox localCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where categoria = @categoria order by codigo asc limit 1;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}
        //public void BuscarUltimoRegistroCategoria(ComboBox localCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where categoria = @categoria order by codigo desc limit 1;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}

        //public void BuscarDadosSubCategoria(ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where codigo = @codigo && categoria = @categoria && subcategoria = @subCategoria;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("subCategoria", localSubCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}
        //public void BuscarPrimeiroRegistroSubCategoria(ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where categoria = @categoria && subcategoria = @subCategoria order by codigo asc limit 1;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("subCategoria", localSubCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}
        //public void BuscarUltimoRegistroSubCategoria(ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where categoria = @categoria && subcategoria = @subCategoria order by codigo desc limit 1;";
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("categoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("subCategoria", localSubCategoria.Text.ToUpper().Trim());
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());

        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}


        //public void BuscarDadosProdutoEntradaMercadoria(int x, DataGridView dataGridView)
        //{
        //    try
        //    {

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produtos where codigo = @codigo;";
        //        comando.Parameters.AddWithValue("codigo", x);
        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
        //        DataTable dtLista = new DataTable();


        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        MySqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            if (reader["nome_voz"] != null)
        //            {

        //                referencia = reader["referencia"].ToString();
        //                descricao = reader["descricao"].ToString();
        //                grama = reader["peso_produto"].ToString();
        //                nome_voz = reader["nome_voz"].ToString();
        //                embalagem = reader["embalagem"].ToString();
        //                quantidade = int.Parse(reader["numero"].ToString());
        //                quantidadeFardo = int.Parse(reader["quant"].ToString());
        //                unidade = int.Parse(reader["unidade"].ToString());
        //                quantidadeUnidade = int.Parse(reader["quantidade"].ToString());
        //                custoUnitario = float.Parse(reader["custo_unitario"].ToString());
        //                margem = float.Parse(reader["margem"].ToString());
        //                venda = float.Parse(reader["valor_venda"].ToString());
        //                margemPromocao = float.Parse(reader["margem_promocao"].ToString());
        //                valorPromocao = float.Parse(reader["valor_promocao"].ToString());
        //                //categoriaUltimoN = reader["iguala"].ToString();
        //                categoria = reader["categoria"].ToString();
        //                subCategoria = reader["subcategoria"].ToString();
        //                categoriaIgualarProdutos = int.Parse(reader["iguala"].ToString());
        //                modoQuantidade = int.Parse(reader["quantidade_avista"].ToString());
        //                fardoIgualaCxProdutos = int.Parse(reader["iguala_caixa"].ToString());
        //                fardoCxFechado = reader["ch_caixa"].ToString();
        //                //fardoUltimoN = reader["iguala_caixa"].ToString();
        //                fardoQuantidade = int.Parse(reader["quantidade_fardo"].ToString());
        //                ultimaEntrada = reader["ultima_entrada"].ToString();
        //                codigo = int.Parse(reader["codigo"].ToString());


        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }

        //}

        //#endregion
        //#region Esvaziar Objeto

        //public void ObjVazio()
        //{
        //    referenciaCodigo = null;
        //    referencia = null;
        //    descricao = null;
        //    grama = null;
        //    nome_voz = null;
        //    embalagem = null;
        //    quantidade = 0;
        //    quantidadeFardo = 0;
        //    unidade = 0;
        //    quantidadeUnidade = 0;
        //    custoUnitario = 0;
        //    margem = 0;
        //    venda = 0;
        //    margemPromocao = 0;
        //    valorPromocao = 0;
        //    //categoriaUltimoN = reader["iguala"].ToString();
        //    categoria = null;
        //    subCategoria = null;
        //    categoriaIgualarProdutos = 0;
        //    modoMargem = 0;
        //    modoQuantidade = 0;
        //    fardoIgualaCxProdutos = 0;
        //    fardoCxFechado = null;
        //    //fardoUltimoN = reader["iguala_caixa"].ToString();
        //    fardoQuantidade = 0;
        //    ultimaEntrada = null;

        //    vTotal = "";
        //    qtdProdComp = "";
        //    ipi = "";
        //    icms = "";
        //    xDesc = "";
        //    xOutro = "";
        //}

        //#endregion
        //#region Categoria

        //// xxxxxxxxxxxxxxxxxxx-------xxxxxxxxxxxxxxxxxxxxx //

        //public void InserirCategoria()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_produto_categoria (nome_voz) values (@nome_voz);";
        //        comando.Parameters.AddWithValue("nome_voz", newCategoria);



        //        if (comando.ExecuteNonQuery() <= 1)
        //        {
        //            //MessageBox.Show("Sucesso ao Inserir Categoria", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {

        //            // MessageBox.Show("Erro ao Inserir Categoria");
        //        }
        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        //public void DelCategoria()
        //{

        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_produto_categoria where nome_voz = @nome_voz;";
        //        comando.Parameters.AddWithValue("nome_voz", newCategoria);



        //        if (comando.ExecuteNonQuery() <= 1)
        //        {
        //            //MessageBox.Show("Sucesso ao Deletar Categoria", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {

        //            // MessageBox.Show("Erro ao Deletar");
        //        }
        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        //public void CarregarComboBoxCategoria(ComboBox cb)
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select nome from tb_produto_categoria order by nome asc;";
        //        MySqlDataReader reader = comando.ExecuteReader();
        //        DataTable table = new DataTable();
        //        table.Load(reader);
        //        //DataRow row = table.NewRow();
        //        //row["nome_voz"] = ".Buscar Categoria";


        //        //table.Rows.InsertAt(row, 0);
        //        cb.DataSource = table;
        //        // cbnome_voz.ValueMember = "codigo";
        //        cb.DisplayMember = "nome_voz";

        //        reader.Close();
        //        reader.Dispose();
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        //// xxxxxxxxxxxxxxxxxxx-------xxxxxxxxxxxxxxxxxxxxx //

        //public void InserirSubCategoria()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_produto_subcategoria (nome_voz) values (@nome_voz);";
        //        comando.Parameters.AddWithValue("nome_voz", newSubCategoria);
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        //public void DelSubCategoria()
        //{

        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_produto_subcategoria where nome_voz = @nome_voz;";
        //        comando.Parameters.AddWithValue("nome_voz", newSubCategoria);
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        //public void CarregarComboBoxSubCategoria(ComboBox cb)
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select nome_voz from tb_produto_subcategoria order by nome_voz asc;";
        //        MySqlDataReader reader = comando.ExecuteReader();
        //        DataTable table = new DataTable();
        //        table.Load(reader);

        //        cb.DataSource = table;

        //        cb.DisplayMember = "nome_voz";

        //        reader.Close();
        //        reader.Dispose();
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        //// xxxxxxxxxxxxxxxxxxx-------xxxxxxxxxxxxxxxxxxxxx //

        //#endregion
        //#region Funções de busca da tela de Pesquisa

        ////datagrid completo
        //public void CarregarDataGrid(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' from tb_produtos;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        //dataGridView.Columns[0].Width = 50;
        //        //dataGridView.Columns[1].Width = 350;
        //        //dataGridView.Columns[2].Width = 120;
        //        //dataGridView.Columns[3].Width = 80;
        //        //dataGridView.Columns[4].Width = 60;
        //        //dataGridView.Columns[5].Width = 70;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 50;
        //        //dataGridView.Columns[8].Width = 70;
        //        //dataGridView.Columns[9].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Cuidado: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////DataGrid  filtro Completo
        //public void BuscarDataGridFiltro(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' from tb_produtos where descricao  like '%" + filtro.Text.Trim() + "%'";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;
        //        dataGridView.Columns[6].Width = 50;
        //        dataGridView.Columns[7].Width = 50;
        //        dataGridView.Columns[8].Width = 70;
        //        dataGridView.Columns[9].Width = 70;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid  Completo com where categoria
        //public void CarregarDataGridWherecategoria(DataGridView dataGridView, ComboBox localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' , avista as 'Valor Avista R$' from tb_produtos where categoria = @localCategoria;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;
        //        dataGridView.Columns[6].Width = 50;
        //        dataGridView.Columns[7].Width = 50;
        //        dataGridView.Columns[8].Width = 70;
        //        dataGridView.Columns[9].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid completo  filtro + categoria
        //public void CarregarDataGridFiltroWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = " select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' , avista as 'Valor Avista R$' from tb_produtos where categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;
        //        dataGridView.Columns[6].Width = 50;
        //        dataGridView.Columns[7].Width = 50;
        //        dataGridView.Columns[8].Width = 70;
        //        dataGridView.Columns[9].Width = 70;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////datagrid  Completo com where categoria + subCategoria
        //public void CarregarDataGridWhereSubcategoria(DataGridView dataGridView, ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' , avista as 'Valor Avista R$' from tb_produtos where categoria = @localCategoria && subcategoria = @localSubCategoria;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;
        //        dataGridView.Columns[6].Width = 50;
        //        dataGridView.Columns[7].Width = 50;
        //        dataGridView.Columns[8].Width = 70;
        //        dataGridView.Columns[9].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid completo  filtro + categoria  + subCategoria
        //public void CarregarDataGridFiltroWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = " select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos', quantidade as 'Quantidade', custo_unitario as 'Custo Unitário R$' , valor_venda as 'Valor Venda R$' , valor_promocao as 'Valor Promoção R$' , avista as 'Valor Avista R$' from tb_produtos where categoria = @localCategoria && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;
        //        dataGridView.Columns[6].Width = 50;
        //        dataGridView.Columns[7].Width = 50;
        //        dataGridView.Columns[8].Width = 70;
        //        dataGridView.Columns[9].Width = 70;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}


        ////datagrid mesmo nome_voz  completo
        //public void CarregarDataGridMesmonome(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, descricao as 'Descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz categoria completo
        //public void CarregarDataGridMesmonomeWhereCategoria(DataGridView dataGridView, ComboBox localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, Descricao as 'descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where categoria = @localCategoria order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////DataGrid  filtro mesmo nome_voz completo
        //public void BuscarDataGridFiltroMesmonome(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, Descricao as 'descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo = tb_produto_codigo.codigo_codigo  where descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz categoria + filtro
        //public void CarregarDataGridFiltroMesmonomeWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, Descricao as 'descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////datagrid mesmo nome_voz categoria completo + subCategoria
        //public void CarregarDataGridMesmonomeWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, Descricao as 'descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo = tb_produto_codigo.codigo_codigo where categoria = @localCategoria && subcategoria = @localSubCategoria order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz categoria + filtro +subCategoria
        //public void CarregarDataGridFiltroMesmonomeWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo, Descricao as 'descrição Principal',referencia_codigo as 'Referência',descricao_codigo as 'Descrição Repetida' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where categoria = @localCategoria && subcategoria = @@localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 360;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}


        ////datagrid Fardo completo
        //public void CarregarDataGridFardo(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo'  from tb_produtos where iguala_caixa > 0 order by iguala_caixa desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid fardo com where categoria completo
        //public void CarregarDataGridFardoWhereCategoria(DataGridView dataGridView, ComboBox localCategiria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo' from tb_produtos where iguala_caixa > 0  && categoria = @localCategoria order by iguala_caixa desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid filtro fardo completo
        //public void BuscarDataGridFiltroFardo(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo' from tb_produtos where  descricao like '%" + filtro.Text.Trim() + "%' && iguala_caixa > 0 order by iguala_caixa desc;";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;


        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid fardo  filtro + categoria
        //public void CarregarDataGridFiltroFardoWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo' from tb_produtos where iguala_caixa > 0 && categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by iguala_caixa desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////datagrid fardo com where categoria completo + subCategoria
        //public void CarregarDataGridFardoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo' from tb_produtos where iguala_caixa > 0  && categoria = @localCategoria && subcategoria = @localSubCategoria order by iguala_caixa desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid fardo  filtro + categoria + subCategoria
        //public void CarregarDataGridFiltroFardoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala_caixa as 'Igualar Cx', quantidade_fardo as 'Quant. Fardo' from tb_produtos where iguala_caixa > 0 && categoria = @localCategoria && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by iguala_caixa desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 310;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;
        //        dataGridView.Columns[5].Width = 70;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}


        ////datagrid IgualaProduto completo
        //public void CarregarDataGridIgualaProduto(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where iguala> 0 order by iguala desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid IgualaProduto com where categoria completo
        //public void CarregarDataGridIgualaProdutoWhereCategoria(DataGridView dataGridView, ComboBox localCategiria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where iguala > 0  && categoria = @localCategoria order by iguala desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid filtro IgualaProduto completo
        //public void BuscarDataGridFiltroIgualaProduto(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where  descricao like '%" + filtro.Text.Trim() + "%' && iguala > 0 order by iguala desc;";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid IgualaProduto  filtro + categoria
        //public void CarregarDataGridFiltroIgualaProdutoWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where iguala > 0 && categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by iguala desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;


        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////datagrid IgualaProduto com where categoria completo + subCategoria
        //public void CarregarDataGridIgualaProdutoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where iguala > 0  && categoria = @localCategoria && subcategoria = @localSubCategoria order by iguala desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid IgualaProduto  filtro + categoria + subCategoria
        //public void CarregarDataGridFiltroIgualaProdutoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', categoria as 'Categoria', subcategoria as 'SubCategoria', iguala as 'Igualar Produtos' from tb_produtos where iguala > 0 && categoria = @localCategoria && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by iguala desc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 120;
        //        dataGridView.Columns[3].Width = 80;
        //        dataGridView.Columns[4].Width = 60;


        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}


        ////datagrid mesmo nome_voz + igualaProduto completo
        //public void CarregarDataGridMesmonomeIguala(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala > 0 order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;
        //        //dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz  + igualaProduto + categoria completo
        //public void CarregarDataGridMesmonomeIgualaWhereCategoria(DataGridView dataGridView, ComboBox localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala > 0 && categoria = @localCategoria order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;
        //        //dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////DataGrid  filtro  + mesmo nome_voz + igualaProduto completo
        //public void BuscarDataGridFiltroMesmonomeIguala(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala >0 && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;
        //        //dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz + categoria + filtro + igualaProduto
        //public void CarregarDataGridFiltroMesmonomeIgualaWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala > 0 && categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;
        //        //dataGridView.Columns[3].Width = 360;
        //        //dataGridView.Columns[4].Width = 70;
        //        //dataGridView.Columns[5].Width = 50;
        //        //dataGridView.Columns[6].Width = 50;
        //        //dataGridView.Columns[7].Width = 70;
        //        //dataGridView.Columns[8].Width = 70;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////datagrid mesmo nome_voz  + igualaProduto + categoria completo + subCategoria
        //public void CarregarDataGridMesmonomeIgualaWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala > 0 && categoria = @localCategoria && subcategoria = @localSubCategoria order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid mesmo nome_voz + categoria + filtro + igualaProduto + subCategoria
        //public void CarregarDataGridFiltroMesmonomeIgualaWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Codigo', descricao as 'Descrição', iguala as 'Igualar Produto' from tb_produtos inner join tb_produto_codigo on tb_produtos.codigo=tb_produto_codigo.codigo_codigo where iguala > 0 && categoria = @localCategoria && descricao && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 50;
        //        dataGridView.Columns[1].Width = 360;
        //        dataGridView.Columns[2].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}


        ////datagrid Valor Promocao completo
        //public void CarregarDataGridValorPromocao(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0 order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid ValorPromocao com where categoria completo
        //public void CarregarDataGridValorPromocaoWhereCategoria(DataGridView dataGridView, ComboBox localCategiria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0  && categoria = @localCategoria order by descricao asc ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid filtro ValorPromocao completo
        //public void BuscarDataGridFiltroValorPromocao(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0 &&  descricao like '%" + filtro.Text.Trim() + "%'  order by descricao asc";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid ValorPromocao  filtro + categoria
        //public void CarregarDataGridFiltroValorPromocaoWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0 && categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////datagrid ValorPromocao com where categoria completo + subCategoria
        //public void CarregarDataGridValorPromocaoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategiria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0  && categoria = @localCategoria && subcategoria = @localSubCategoria order by descricao asc ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid ValorPromocao  filtro + categoria  + subCategoria
        //public void CarregarDataGridFiltroValorPromocaoWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', valor_promocao as 'Valor Promoção', iguala as 'Igualar Produtos' from tb_produtos where valor_promocao > 0 && categoria = @localCategoria && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());
        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}



        ////datagrid Valor Avista com where categoria completo
        //public void CarregarDataGridValorAvistaWhereCategoria(DataGridView dataGridView, ComboBox localCategiria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', iguala as 'Igualar Produtos' from tb_produtos where categoria = @localCategoria order by descricao asc ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid filtro Valor Avista completo
        //public void BuscarDataGridFiltroValorAvista(DataGridView dataGridView, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', avista as 'Valor Avista', iguala as 'Igualar Produtos' from tb_produtos where avista > 0 &&  descricao like '%" + filtro.Text.Trim() + "%'  order by descricao asc";
        //        //conexao.Open();
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;



        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid Valor Avista  filtro + categoria
        //public void CarregarDataGridFiltroValorAvistaWhereCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', avista as 'Valor Avista', iguala as 'Igualar Produtos' from tb_produtos where avista > 0 && categoria = @localCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////datagrid Valor Avista com where categoria completo + subcategoria
        //public void CarregarDataGridValorAvistaWhereSubCategoria(DataGridView dataGridView, ComboBox localCategiria, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', avista as 'Valor Avista', iguala as 'Igualar Produtos' from tb_produtos where avista > 0  && categoria = @localCategoria && subcategoria = @localSubCategoria order by descricao asc ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategiria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        ////datagrid Valor Avista  filtro + categoria + subcategoria
        //public void CarregarDataGridFiltroValorAvistaWhereSubCategoria(DataGridView dataGridView, ComboBox localCategoria, TextBox filtro, ComboBox localSubCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo as 'Código', descricao as 'Descrição', avista as 'Valor Avista', iguala as 'Igualar Produtos' from tb_produtos where avista > 0 && categoria = @localCategoria && subcategoria = @localSubCategoria && descricao  like '%" + filtro.Text.Trim() + "%' order by descricao asc;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("localCategoria", localCategoria.Text.ToUpper().Trim());
        //        comando.Parameters.AddWithValue("localSubCategoria", localSubCategoria.Text.ToUpper().Trim());

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 350;
        //        dataGridView.Columns[2].Width = 60;
        //        dataGridView.Columns[3].Width = 60;




        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        //public void LimparDataGrid(DataGridView dataGridView)
        //{
        //    try
        //    {


        //        DataTable dtLista = new DataTable();
        //        dataGridView.DataSource = dtLista;

        //    }
        //    catch (Exception a)
        //    {
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        //#endregion
        //#region Registro
        ////tb_atualizacao_produto_codigo
        //public void InserirRegistro()
        //{

        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_atualizacao_produto (usuario, codigo_produto, data_hora, iguala, iguala_caixa, ch_caixa, numero, status) values (@usuario, @codigo_produto, @data_hora, @iguala, @iguala_caixa, @ch_caixa, @numero, @status);";
        //        // comando.Parameters.AddWithValue("usuario", Usuario.user.nome_voz);
        //        comando.Parameters.AddWithValue("usuario", "Responsavel");
        //        comando.Parameters.AddWithValue("codigo_produto", codigo);
        //        comando.Parameters.AddWithValue("data_hora", DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
        //        comando.Parameters.AddWithValue("iguala", categoriaIgualarProdutos);
        //        comando.Parameters.AddWithValue("iguala_caixa", fardoIgualaCxProdutos);
        //        comando.Parameters.AddWithValue("ch_caixa", fardoCxFechado);
        //        comando.Parameters.AddWithValue("numero", quantidade);
        //        comando.Parameters.AddWithValue("status", status);
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {

        //        //MessageBox.Show("Erro Registro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }


        //}

        //public void InserirRegistroProdutoCodigo(string r)
        //{

        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_atualizacao_produto_codigo (referencia_codigo) values (@referencia_codigo);";
        //        comando.Parameters.AddWithValue("referencia_codigo", r);
        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception a)
        //    {

        //        //MessageBox.Show("Erro Registro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }


        //}

        //#endregion
        //#region Produto_Codigo

        ////deletar dados produto codigo
        //public void DeletarDados(string localString)
        //{
        //    try
        //    {
        //        conexao.Open();
        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_produto_codigo where referencia_codigo = @referencia;";
        //        comando.Parameters.AddWithValue("referencia", localString);

        //        if (comando.ExecuteNonQuery() <= 1)
        //        {
        //            //MessageBox.Show("Sucesso ao Deletar");
        //        }
        //        else
        //        {
        //            //MessageBox.Show("Erro ao Deletar");
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show(a.Message);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////produto fornecedor
        //public void CarregarDataGridFornecedor(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select codigo_fornecedor as 'Codigo', nome_fornecedor as 'nome_voz'  from tb_produto_fornecedor where codigo_produto =" + codigo + " order by numero desc ;";


        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;

        //        dataGridView.Columns[0].Width = 60;
        //        dataGridView.Columns[1].Width = 188;





        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}

        //public void BuscarDadosRefCodigo()
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produto_codigo where referencia_codigo = @referencia_codigo;";
        //        comando.Parameters.AddWithValue("referencia_codigo", referenciaCodigo);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["referencia_codigo"] != null)
        //            {
        //                referenciaCodigo = reader["referencia_codigo"].ToString();
        //                descricaoCodigo = reader["descricao_codigo"].ToString();
        //            }
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }
        //}
        //public void BuscarDadosCodCodigo(string localReferenciaCodigo)
        //{
        //    try
        //    {
        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "select * from tb_produto_codigo where referencia_codigo = @referencia_codigo;";
        //        comando.Parameters.AddWithValue("referencia_codigo", localReferenciaCodigo);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader["referencia_codigo"] != null)
        //            {
        //                referenciaCodigo = reader["referencia_codigo"].ToString();
        //                descricaoCodigo = reader["descricao_codigo"].ToString();
        //                codigo = int.Parse(reader["codigo_codigo"].ToString());
        //            }

        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {

        //        conexao.Close();
        //    }
        //}

        //#endregion
        //#region ImprimirPreco

        //public void ImprimirDeletarUnitario(int x)
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_select_preco where numero = @x;";
        //        comando.Parameters.AddWithValue("x", x);




        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}
        //public void ImprimirDeletar(int x)
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_select_preco where codigo = @x;";
        //        comando.Parameters.AddWithValue("x", x);




        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        //public void ImprimirDeletar()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "delete from tb_select_preco;";

        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        ////XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        ////Buscar todos os valores da tabela tb_select_preco
        //public void BuscarImprimirGeral(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'nome', peso_produto as 'Grama', valor as 'Valor Normal R$', valor_promocao as 'Valor Promoção R$', valor_avista as 'Valor Avista R$', quantidade_avista as 'Quant. Avista', total_avista as 'Total Avista R$', categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////Buscar  os valores Normais da tabela tb_select_preco
        //public void BuscarImprimirValorNormal(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor as 'Valor Normal R$', categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco where valor > 0 && valor_avista  = 0;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////Buscar os valores promoção da tabela tb_select_preco
        //public void BuscarImprimirValorPromocao(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = " select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor_promocao as 'Valor Promoção R$', categoria as 'Categoria' from tb_select_preco where valor_promocao > 0;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////Buscar os valores avista da tabela tb_select_preco
        //public void BuscarImprimirValorAvista(DataGridView dataGridView)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor_avista as 'Valor Avista R$', quantidade_avista as 'Quant. Avista', total_avista as 'Total Avista R$', valor as 'Valor Normal R$',categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco where valor_avista > 0 ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        ////Buscar todos os valores da tabela tb_select_preco + categoria
        //public void BuscarImprimirGeralCategoria(DataGridView dataGridView, string localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor as 'Valor Normal R$', valor_promocao as 'Valor Promoção R$', valor_avista as 'Valor Avista R$', quantidade_avista as 'Quant. Avista', total_avista as 'Total Avista R$', categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco where categoria = @categoria ;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("categoria", localCategoria);

        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}


        ////Buscar  os valores Normais da tabela tb_select_preco + categoria
        //public void BuscarImprimirValorNormalCategoria(DataGridView dataGridView, string localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor as 'Valor Normal R$', categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco where valor > 0 && valor_avista  = 0  && categoria = @categoria;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("categoria", localCategoria);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}


        ////Buscar os valores promoção da tabela tb_select_preco + categoria
        //public void BuscarImprimirValorPromocaoCategoria(DataGridView dataGridView, string localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = " select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor_promocao as 'Valor Promoção R$', categoria as 'Categoria' from tb_select_preco where valor_promocao > 0 && categoria = @categoria;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("categoria", localCategoria);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}


        ////Buscar os valores avista da tabela tb_select_preco + categoria
        //public void BuscarImprimirValorAvistaCategoria(DataGridView dataGridView, string localCategoria)
        //{
        //    try
        //    {
        //        string strgComando = "select numero as 'ID', nome as 'Nome', peso_produto as 'Grama', valor_avista as 'Valor Avista R$', quantidade_avista as 'Quant. Avista', total_avista as 'Total Avista R$', valor as 'Valor Normal R$',categoria as 'Categoria', codigo as 'Codigo' from tb_select_preco where valor_avista > 0 &&  categoria = @categoria;";

        //        if (conexao.State == ConnectionState.Closed)
        //        {
        //            conexao.Open();
        //        }
        //        MySqlCommand comando = new MySqlCommand(strgComando, conexao);
        //        comando.Parameters.AddWithValue("categoria", localCategoria);


        //        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);

        //        DataTable dtLista = new DataTable();

        //        sqlDataAdapter.Fill(dtLista);
        //        dataGridView.DataSource = dtLista;
        //        //dataGridView.Columns[0].Width = 50;

        //    }
        //    catch (Exception a)
        //    {
        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        ////XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        ////Insere Valor Normal
        //public void InsertValorNormal()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_select_preco (nome, peso_produto, valor, valor_promocao, valor_avista, quantidade_avista, total_avista, categoria, codigo, codigo_funcionario) values (@nome, @peso_produto, @valor,0,0, 0, 0, @categoria,@codigo, @codigo_funcionario);";
        //        comando.Parameters.AddWithValue("nome", nome_voz);
        //        comando.Parameters.AddWithValue("peso_produto", grama);
        //        comando.Parameters.AddWithValue("valor", venda);
        //        //comando.Parameters.AddWithValue("valor_promocao", valorPromocao);
        //        //comando.Parameters.AddWithValue("valor_avista", modoValor);
        //        //comando.Parameters.AddWithValue("quantidade_avista", modoQuantidade);
        //        //comando.Parameters.AddWithValue("total_avista", modoQuantidade);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("codigo_funcionario", VariaveisGlobais.Singleton.instancia.codigoFuncionario);



        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}


        ////Insere Valor Promoção
        //public void InsertValorPromocao()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_select_preco (nome, peso_produto, valor, valor_promocao, valor_avista, quantidade_avista, total_avista, categoria, codigo, codigo_funcionario) values (@nome, @peso_produto, 0, @valor_promocao, 0, 0, 0, @categoria,@codigo, @codigo_funcionario);";
        //        comando.Parameters.AddWithValue("nome", nome_voz);
        //        comando.Parameters.AddWithValue("peso_produto", grama);
        //        //comando.Parameters.AddWithValue("valor", venda);
        //        comando.Parameters.AddWithValue("valor_promocao", valorPromocao);
        //        //comando.Parameters.AddWithValue("valor_avista", modoValor);
        //        //comando.Parameters.AddWithValue("quantidade_avista", modoQuantidade);
        //        //comando.Parameters.AddWithValue("total_avista", modoQuantidade);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("codigo_funcionario", VariaveisGlobais.Singleton.instancia.codigoFuncionario);



        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}


        ////Insere Valor Avista
        //public void InsertValorAvista()
        //{
        //    try
        //    {
        //        conexao.Open();

        //        MySqlCommand comando = conexao.CreateCommand();
        //        comando.CommandText = "insert into tb_select_preco (nome, peso_produto, valor, valor_promocao, valor_avista, quantidade_avista, categoria, codigo, codigo_funcionario) values (@nome, @peso_produto, @valor, 0, @valor_avista, @quantidade_avista, @total_avista, @categoria,@codigo, @codigo_funcionario);";
        //        comando.Parameters.AddWithValue("nome", nome_voz);
        //        comando.Parameters.AddWithValue("peso_produto", grama);
        //        comando.Parameters.AddWithValue("valor", venda);
        //        //comando.Parameters.AddWithValue("valor_promocao", valorPromocao);
        //        comando.Parameters.AddWithValue("quantidade_avista", modoQuantidade);
        //        comando.Parameters.AddWithValue("categoria", categoria);
        //        comando.Parameters.AddWithValue("codigo", codigo);
        //        comando.Parameters.AddWithValue("codigo_funcionario", VariaveisGlobais.Singleton.instancia.codigoFuncionario);


        //        comando.ExecuteNonQuery();


        //    }
        //    catch (Exception a)
        //    {

        //        MessageBox.Show("Erro: " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexao.Close();

        //    }
        //}

        ////XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        //#endregion


        #endregion

    }



}
