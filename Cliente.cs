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
            btnReview.Click += new EventHandler(BtnReview_Click);
            btnEnviar.Click += new EventHandler(BtnEnviar_Click);
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
                        INNER JOIN EspecialistaRemocaoLaser E ON A.Artista_ID = E.Artista_ID
                        INNER JOIN Staff S ON A.Artista_ID = S.ID";
                        break;
                    case "Tatuador":
                        query = @"
                        SELECT S.Nome, T.Especialidade
                        FROM Artista A
                        INNER JOIN Tatuador T ON A.Artista_ID = T.Artista_ID
                        INNER JOIN Staff S ON A.Artista_ID = S.ID";
                        break;
                    case "Body Piercer":
                        query = @"
                        SELECT S.Nome
                        FROM Artista A
                        INNER JOIN BodyPiercer B ON A.Artista_ID = B.Artista_ID
                        INNER JOIN Staff S ON A.Artista_ID = S.ID";
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
                        SELECT S.Zona, S.Descricao, S.Cuidados, S.Preco, S.Duracao, T.Estilo, T.NumeroSessoes
                        FROM Servico S
                        INNER JOIN Tatuagem T ON S.ID = T.Servico_ID";
                        break;
                    case "Piercing":
                        query = @"
                        SELECT S.Zona, S.Descricao, S.Preco, S.Duracao, P.Nome, S.Cuidados
                        FROM Servico S
                        INNER JOIN Piercing P ON S.ID = P.Servico_ID
                        INNER JOIN BodyPiercer B ON P.BodyPiercer_ID = B.Artista_ID";
                        break;
                    case "Remoção a Laser":
                        query = @"
                        SELECT S.Zona, S.Preco, S.Duracao, R.NumeroSessoes, S.Descricao, S.Cuidados
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
            HideReviewControls();
        }

        private void BtnServicos_Click(object sender, EventArgs e)
        {
            LoadServicosCategorias();
            HideReviewControls();
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            LoadProdutos();
            HideReviewControls();
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
            LoadArtistNamesForAutocomplete();
        }

        private void BtnReview_Click(object sender, EventArgs e)
        {
            ShowReviewControls();
            dataGridViewArtistas.DataSource = null;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            cn = bdConnection.getSGBDConnection();
            cn.Open();

            string nomeCliente = txtClienteID.Text.Trim();
            if (string.IsNullOrEmpty(nomeCliente))
            {
                MessageBox.Show("Digite o nome do cliente para pesquisa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteID = GetClienteIDByName(nomeCliente);
            string nomeArtista = txtNomeArtista.Text.Trim();
            string descricao = txtFeedback.Text.Trim();
            int avaliacao = GetAvaliacao();

            // Determinar o tipo de serviço selecionado
            string servico = null;
            if (chkTatuagem.Checked)
            {
                servico = "Tatuagem";
            }
            else if (chkPiercing.Checked)
            {
                servico = "Piercing";
            }
            else if (chkRemocao.Checked)
            {
                servico = "Remocao";
            }

            if (string.IsNullOrEmpty(servico))
            {
                MessageBox.Show("Selecione um tipo de serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obter o ID do serviço baseado no nome do artista e tipo de serviço
            int servicoID = GetServicoID(nomeArtista, servico);
            if (servicoID == -1)
            {
                MessageBox.Show("Artista ou serviço não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obter o próximo ID para a review
            int nextReviewID = GetNextReviewID();

            // Exibir o próximo ID da review para depuração
            MessageBox.Show($"Próximo ID da review: {nextReviewID}", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Inserir review
            if (!string.IsNullOrEmpty(descricao) && avaliacao >= 1 && avaliacao <= 5)
            {
                try
                {
                    string insert = "INSERT INTO Review (ID, Cliente_ID, Servico_ID, Descricao, Avaliacao) VALUES (@id, @clienteID, @servicoID, @descricao, @avaliacao)";
                    SqlCommand command = new SqlCommand(insert, cn);

                    command.Parameters.AddWithValue("@id", nextReviewID);
                    command.Parameters.AddWithValue("@clienteID", clienteID);
                    command.Parameters.AddWithValue("@servicoID", servicoID);
                    command.Parameters.AddWithValue("@descricao", descricao);
                    command.Parameters.AddWithValue("@avaliacao", avaliacao);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Review adicionada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar review: \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }

                txtNomeArtista.Text = "";
                txtFeedback.Text = "";
                chkTatuagem.Checked = false;
                chkPiercing.Checked = false;
                chkRemocao.Checked = false;
                ResetAvaliacoes();
            }
            else
            {
                MessageBox.Show("Insira uma descrição válida e uma avaliação entre 1 e 5.");
            }
        }

        private int GetClienteIDByName(string nomeCliente)
        {
            try
            {
                string query = "SELECT ID FROM Cliente WHERE Nome = @nomeCliente";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nomeCliente", nomeCliente);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar ID do cliente: \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetAvaliacao()
        {
            if (rdoAval5.Checked) return 5;
            if (rdoAval4.Checked) return 4;
            if (rdoAval3.Checked) return 3;
            if (rdoAval2.Checked) return 2;
            if (rdoAval1.Checked) return 1;
            return 0; // No rating selected
        }

        private void ResetAvaliacoes()
        {
            rdoAval1.Checked = false;
            rdoAval2.Checked = false;
            rdoAval3.Checked = false;
            rdoAval4.Checked = false;
            rdoAval5.Checked = false;
        }

        private int GetServicoID(string nomeArtista, string servico)
        {
            try
            {
                string query = "";
                switch (servico)
                {
                    case "Tatuagem":
                        query = @"
                        SELECT S.ID
                        FROM Servico S
                        INNER JOIN Tatuagem T ON S.ID = T.Servico_ID
                        INNER JOIN Tatuador TA ON T.Tatuador = TA.Artista_ID
                        INNER JOIN Artista A ON TA.Artista_ID = A.Artista_ID
                        INNER JOIN Staff ST ON A.Artista_ID = ST.ID
                        WHERE ST.Nome = @nomeArtista";
                        break;
                    case "Piercing":
                        query = @"
                        SELECT S.ID
                        FROM Servico S
                        INNER JOIN Piercing P ON S.ID = P.Servico_ID
                        INNER JOIN BodyPiercer B ON P.BodyPiercer_ID = B.Artista_ID
                        INNER JOIN Artista A ON B.Artista_ID = A.Artista_ID
                        INNER JOIN Staff ST ON A.Artista_ID = ST.ID
                        WHERE ST.Nome = @nomeArtista";
                        break;
                    case "Remocao":
                        query = @"
                        SELECT S.ID
                        FROM Servico S
                        INNER JOIN Remocao R ON S.ID = R.Servico_ID
                        INNER JOIN EspecialistaRemocaoLaser ER ON R.EspecialistaRemocaoLaser = ER.Artista_ID
                        INNER JOIN Artista A ON ER.Artista_ID = A.Artista_ID
                        INNER JOIN Staff ST ON A.Artista_ID = ST.ID
                        WHERE ST.Nome = @nomeArtista";
                        break;
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nomeArtista", nomeArtista);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter ID do serviço: \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetNextReviewID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Review";
                SqlCommand cmd = new SqlCommand(query, cn);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter o próximo ID da review: \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        private void ShowReviewControls()
        {
            txtNomeArtista.Show();
            txtFeedback.Show();
            artistname.Show();
            feedback.Show();
            givereview.Show();
            ClientName.Show();
            txtClienteID.Show();
            chkPiercing.Show();
            chkRemocao.Show();
            chkTatuagem.Show();
            rdoAval1.Show();
            rdoAval2.Show();
            rdoAval3.Show();
            rdoAval4.Show();
            rdoAval5.Show();
            mostrarreviews.Show();
            btnEnviar.Show();
        }

        private void HideReviewControls()
        {
            txtNomeArtista.Hide();
            txtFeedback.Hide();
            artistname.Hide();
            feedback.Hide();
            givereview.Hide();
            ClientName.Hide();
            txtClienteID.Hide();
            chkPiercing.Hide();
            chkRemocao.Hide();
            chkTatuagem.Hide();
            rdoAval1.Hide();
            rdoAval2.Hide();
            rdoAval3.Hide();
            rdoAval4.Hide();
            rdoAval5.Hide();
            mostrarreviews.Hide();
            btnEnviar.Hide();
        }

        private void BtnSearchCliente_Click(object sender, EventArgs e)
        {
            string nomeCliente = txtClienteID.Text.Trim();
            if (string.IsNullOrEmpty(nomeCliente))
            {
                MessageBox.Show("Digite o nome do cliente para pesquisa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteID = GetClienteIDByName(nomeCliente);
            if (clienteID != -1)
            {
                MessageBox.Show($"Cliente encontrado! ID: {clienteID}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadArtistNamesForAutocomplete()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = "SELECT S.Nome FROM Artista A INNER JOIN Staff S ON A.Artista_ID = S.ID";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();

                AutoCompleteStringCollection artistNames = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    artistNames.Add(reader["Nome"].ToString());
                }

                cn.Close();

                // Configure o txtNomeArtista para usar a coleção de autocomplete
                txtNomeArtista.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNomeArtista.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNomeArtista.AutoCompleteCustomSource = artistNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nomes dos artistas para autocomplete: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarreviews_Click(object sender, EventArgs e)
        {
            try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    HideReviewControls();

                    string query = @"
                    SELECT S.Descricao AS ServicoDescricao, R.Descricao AS ReviewDescricao, R.Avaliacao
                    FROM Review R
                    INNER JOIN Cliente C ON R.Cliente_ID = C.ID
                    INNER JOIN Servico S ON R.Servico_ID = S.ID";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewArtistas.DataSource = dataTable;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar reviews: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


    }
}
