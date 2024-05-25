using ProjetoBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    public partial class Cliente : Form
    {
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        public Cliente()
        {
            InitializeComponent();
            comboBoxCategorias.SelectedIndexChanged += new EventHandler(comboBoxCategorias_SelectedIndexChanged);

            // Adicionar eventos para os botões
            btnArtistas.Click += new EventHandler(BtnArtistas_Click);
            btnServicos.Click += new EventHandler(BtnServicos_Click);
            btnProdutos.Click += new EventHandler(BtnProdutos_Click);
        }

        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelecionado = comboBoxCategorias.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(itemSelecionado))
            {
                if (itemSelecionado == "Especialista Remoção a Laser" || itemSelecionado == "Tatuador" || itemSelecionado == "Body Piercer")
                {
                    LoadArtistasByCategory(itemSelecionado);
                }
                else
                {
                    LoadServicosByCategory(itemSelecionado);
                }
            }
        }

        private void LoadArtistaCategorias()
        {
            comboBoxCategorias.Items.Clear();
            comboBoxCategorias.Items.Add("Especialista Remoção a Laser");
            comboBoxCategorias.Items.Add("Tatuador");
            comboBoxCategorias.Items.Add("Body Piercer");
        }

        private void LoadServicosCategorias()
        {
            comboBoxCategorias.Items.Clear();
            comboBoxCategorias.Items.Add("Remoção a Laser");
            comboBoxCategorias.Items.Add("Tatuagem");
            comboBoxCategorias.Items.Add("Piercing");
        }

        private void LoadArtistasByCategory(string categoria)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = "";

                switch (categoria)
                {
                    case "Especialista Remoção a Laser":
                        query = @"
                    SELECT S.Nome
                    FROM Artista A
                    INNER JOIN EspecialistaRemocaoLaser E ON A.Staff_ID = E.Artista_ID
                    INNER JOIN Staff S ON A.Staff_ID = S.ID";
                        break;
                    case "Tatuador":
                        query = @"
                    SELECT S.Nome, T.Especialidade
                    FROM Artista A
                    INNER JOIN Tatuador T ON A.Staff_ID = T.Artista_ID
                    INNER JOIN Staff S ON A.Staff_ID = S.ID";
                        break;
                    case "Body Piercer":
                        query = @"
                    SELECT S.Nome
                    FROM Artista A
                    INNER JOIN BodyPiercer B ON A.Staff_ID = B.Artista_ID
                    INNER JOIN Staff S ON A.Staff_ID = S.ID";
                        break;
                }

                if (!string.IsNullOrEmpty(query))
                {
                    dataGridViewArtistas.Show();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewArtistas.DataSource = dataTable;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar artistas: " + ex.Message);
            }
        }

        private void LoadServicosByCategory(string categoria)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = "";

                switch (categoria)
                {
                    case "Tatuagem":
                        query = @"
                SELECT S.ID, S.Zona, S.Descricao, S.Cuidados, S.Preco, S.Duracao, T.Estilo, T.NumeroSessoes
                FROM Servico S
                INNER JOIN Tatuagem T ON S.ID = T.Servico_ID";
                        break;
                    case "Piercing":
                        query = @"
                SELECT S.ID, S.Zona, S.Descricao, S.Cuidados, S.Preco, S.Duracao, P.Nome, B.Nome AS BodyPiercer
                FROM Servico S
                INNER JOIN Piercing P ON S.ID = P.Servico_ID
                INNER JOIN BodyPiercer B ON P.BodyPiercer_ID = B.Artista_ID";
                        break;
                    case "Remocao":
                        query = @"
                SELECT S.ID, S.Zona, S.Descricao, S.Cuidados, S.Preco, S.Duracao, R.NumeroSessoes, E.Nome AS EspecialistaRemocaoLaser
                FROM Servico S
                INNER JOIN Remocao R ON S.ID = R.Servico_ID
                INNER JOIN EspecialistaRemocaoLaser E ON R.EspecialistaRemocaoLaser = E.Artista_ID";
                        break;
                }

                if (!string.IsNullOrEmpty(query))
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewArtistas.DataSource = dataTable;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços: " + ex.Message);
            }
        }


        private void BtnArtistas_Click(object sender, EventArgs e)
        {
            LoadArtistaCategorias();
        }

        private void BtnServicos_Click(object sender, EventArgs e)
        {
            LoadServicosCategorias();
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            LoadProdutos();
        }

        private void LoadProdutos()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome, Preco, Quantidade, Descricao FROM Produto", cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewArtistas.DataSource = dataTable;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            // Carregar categorias iniciais ou qualquer configuração inicial necessária
        }
    }
}
