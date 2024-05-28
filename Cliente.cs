using ProjetoBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Project_BD_Tattoos.Rececionista;

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

            btnArtistas.Click += new EventHandler(BtnArtistas_Click);
            btnServicos.Click += new EventHandler(BtnServicos_Click);
            btnProdutos.Click += new EventHandler(BtnProdutos_Click);
            btnReview.Click += new EventHandler(BtnReview_Click);
            btnEnviar.Click += new EventHandler(BtnEnviar_Click);
            txtNomeArtista.TextChanged += new EventHandler(txtNomeArtista_TextChanged);
            numericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            ListBox.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);

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
            labelPreco.Hide();
            labelQuantidade.Hide();
            numericUpDown1.Hide();
            buttonAdquirir.Hide();
            textBoxPreco.Hide();

            comboBoxCategorias.Items.Clear();
            comboBoxCategorias.Items.Add("Especialista Remoção a Laser");
            comboBoxCategorias.Items.Add("Tatuador");
            comboBoxCategorias.Items.Add("Body Piercer");
            if (comboBoxCategorias.Items.Count > 0)
            {
                comboBoxCategorias.SelectedIndex = 0;
            }
        }
        private void LoadServicosCategorias()
        {
            labelPreco.Hide();
            labelQuantidade.Hide();
            numericUpDown1.Hide();
            buttonAdquirir.Hide();
            textBoxPreco.Hide();

            comboBoxCategorias.Items.Clear();
            comboBoxCategorias.Items.Add("Remoção a Laser");
            comboBoxCategorias.Items.Add("Tatuagem");
            comboBoxCategorias.Items.Add("Piercing");
            if (comboBoxCategorias.Items.Count > 0)
            {
                comboBoxCategorias.SelectedIndex = 0;
            }
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
                    ListBox.Items.Clear();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (categoria == "Tatuador")
                        {
                            ListBox.Items.Add($"{reader["Nome"]} - Especialidade: {reader["Especialidade"]}");
                        }
                        else
                        {
                            ListBox.Items.Add(reader["Nome"].ToString());
                        }
                    }
                    reader.Close();
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
                    ListBox.Items.Clear();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListBox.Items.Add($"{reader["Descricao"]}, Preço: {reader["Preco"]}");
                    }
                    reader.Close();
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
            comboBoxCategorias.Show();
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            labelPreco.Show();
            labelQuantidade.Show();
            numericUpDown1.Show();
            buttonAdquirir.Show();
            textBoxPreco.Show();
            LoadProdutos();
            HideReviewControls();
            comboBoxCategorias.Hide();
        }

        private void LoadProdutos()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome, Preco, Quantidade, Descricao FROM Produto", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                ListBox.Items.Clear();
                while (reader.Read())
                {
                    string productInfo = $"{reader["Nome"]}, Preço: {reader["Preco"]}, Descrição: {reader["Descricao"]}";
                    ListBox.Items.Add(productInfo);
                }
                reader.Close();
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
            comboBoxCategorias.Hide();
            ShowReviewControls();
            ListBox.Items.Clear();
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

            string servico = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(servico))
            {
                MessageBox.Show("Selecione um serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int servicoID = GetServicoID(nomeArtista, servico);
            if (servicoID == -1)
            {
                MessageBox.Show("Artista ou serviço não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int nextReviewID = GetNextReviewID();




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
                string query = @"
                SELECT S.ID
                FROM Servico S
                LEFT JOIN Tatuagem T ON S.ID = T.Servico_ID
                LEFT JOIN Piercing P ON S.ID = P.Servico_ID
                LEFT JOIN Remocao R ON S.ID = R.Servico_ID
                INNER JOIN Artista A ON (T.Tatuador = A.Artista_ID OR P.BodyPiercer_ID = A.Artista_ID OR R.EspecialistaRemocaoLaser = A.Artista_ID)
                INNER JOIN Staff ST ON A.Artista_ID = ST.ID
                WHERE ST.Nome = @nomeArtista";

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
            labelServico.Show();
            feedback.Show();
            givereview.Show();
            ClientName.Show();
            txtClienteID.Show();
            comboBox1.Show();
            rdoAval1.Show();
            rdoAval2.Show();
            rdoAval3.Show();
            rdoAval4.Show();
            rdoAval5.Show();
            mostrarreviews.Show();
            btnEnviar.Show();
            labelQuantidade.Hide();
            numericUpDown1.Hide();
            labelPreco.Hide();
            labelPreco.Hide();
            buttonAdquirir.Hide();
        }

        private void HideReviewControls()
        {
            txtNomeArtista.Hide();
            txtFeedback.Hide();
            labelServico.Hide();
            artistname.Hide();
            feedback.Hide();
            givereview.Hide();
            ClientName.Hide();
            txtClienteID.Hide();
            comboBox1.Hide();
            rdoAval1.Hide();
            rdoAval2.Hide();
            rdoAval3.Hide();
            rdoAval4.Hide();
            rdoAval5.Hide();
            mostrarreviews.Hide();
            btnEnviar.Hide();
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


        private void txtNomeArtista_TextChanged(object sender, EventArgs e)
        {
            LoadServicosByArtista(txtNomeArtista.Text.Trim());
        }

        private void LoadServicosByArtista(string nomeArtista)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = @"
                    SELECT S.Descricao
                    FROM Servico S
                    LEFT JOIN Tatuagem T ON S.ID = T.Servico_ID
                    LEFT JOIN Piercing P ON S.ID = P.Servico_ID
                    LEFT JOIN Remocao R ON S.ID = R.Servico_ID
                    INNER JOIN Artista A ON (T.Tatuador = A.Artista_ID OR P.BodyPiercer_ID = A.Artista_ID OR R.EspecialistaRemocaoLaser = A.Artista_ID)
                    INNER JOIN Staff ST ON A.Artista_ID = ST.ID
                    WHERE ST.Nome = @nomeArtista";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nomeArtista", nomeArtista);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox1.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    comboBox1.Items.Add(row["Descricao"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços do artista: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarreviews_Click_1(object sender, EventArgs e)
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

                ListBox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    ListBox.Items.Add($"{row["ServicoDescricao"]} - {row["ReviewDescricao"]} - {row["Avaliacao"]}");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar reviews: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (ListBox.SelectedItem != null)
            {
                string selectedProduct = ListBox.SelectedItem.ToString().Split(',')[0].Trim();

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT Preco FROM Produto WHERE Nome = @Nome", cn);
                    cmd.Parameters.AddWithValue("@Nome", selectedProduct);

                    object result = cmd.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal unitPrice))
                    {
                        int quantity = (int)numericUpDown1.Value;
                        decimal totalPrice = unitPrice * quantity;
                        textBoxPreco.Text = totalPrice.ToString("0.00") + "€";
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o preço do produto: " + ex.Message);
                }
            }
        }

        private void ButtonAdquirir_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;

            try
            {
                if (ListBox.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecione um produto.");
                    return;
                }

                string nomeOuEmail = Prompt.ShowDialog("Por favor, insira o nome ou email do cliente:", "Cliente");

                if (string.IsNullOrEmpty(nomeOuEmail))
                {
                    MessageBox.Show("Nome ou email do cliente não pode ser vazio.");
                    return;
                }

                cn = bdConnection.getSGBDConnection();
                cn.Open();

                // Start a transaction
                SqlTransaction transaction = cn.BeginTransaction();

                // Find client ID by name or email
                SqlCommand findClientCmd = new SqlCommand(
                    "SELECT ID FROM Cliente WHERE Nome = @NomeOuEmail OR Email = @NomeOuEmail", cn, transaction);
                findClientCmd.Parameters.AddWithValue("@NomeOuEmail", nomeOuEmail);

                object result = findClientCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Cliente não encontrado.");
                    cn.Close();
                    return;
                }

                int clientId = (int)result;

                // Get selected product details
                string selectedProduct = ListBox.SelectedItem.ToString().Split(',')[0].Trim();

                SqlCommand cmd = new SqlCommand("SELECT Preco FROM Produto WHERE Nome = @Nome", cn, transaction);
                cmd.Parameters.AddWithValue("@Nome", selectedProduct);

                result = cmd.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal productPrice))
                {
                    int quantity = (int)numericUpDown1.Value;
                    decimal totalPrice = productPrice * quantity;
                    textBoxPreco.Text = totalPrice.ToString("0.00") + "€";

                    // Find product ID by name
                    SqlCommand findProductCmd = new SqlCommand(
                        "SELECT ID, Quantidade FROM Produto WHERE Nome = @Nome", cn, transaction);
                    findProductCmd.Parameters.AddWithValue("@Nome", selectedProduct);

                    SqlDataReader reader = findProductCmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("Produto não encontrado.");
                        reader.Close();
                        cn.Close();
                        return;
                    }

                    int productId = (int)reader["ID"];
                    int availableQuantity = (int)reader["Quantidade"];
                    reader.Close();

                    if (availableQuantity < quantity)
                    {
                        MessageBox.Show("Quantidade insuficiente em estoque.");
                        cn.Close();
                        return;
                    }

                    int nextID = GetNextID("Pagamento");

                    DateTime newDataHora = DateTime.Now.AddMinutes(1);

                    string newMetodo = "Dinheiro";

                    decimal newValor = totalPrice;

                    int newClienteID = clientId;

                    SqlCommand insertPaymentCmd = new SqlCommand("AddPagamento", cn, transaction);
                    insertPaymentCmd.CommandType = CommandType.StoredProcedure;
                    insertPaymentCmd.Parameters.AddWithValue("@ID", nextID);
                    insertPaymentCmd.Parameters.AddWithValue("@Cliente_ID", newClienteID);
                    insertPaymentCmd.Parameters.AddWithValue("@DataHora", newDataHora);
                    insertPaymentCmd.Parameters.AddWithValue("@Valor", newValor);
                    insertPaymentCmd.Parameters.AddWithValue("@Metodo", newMetodo);

                    int paymentResult = insertPaymentCmd.ExecuteNonQuery();

                    SqlCommand updateProductCmd = new SqlCommand(
                        "UPDATE Produto SET Quantidade = Quantidade - @Quantidade WHERE ID = @ID", cn, transaction);
                    updateProductCmd.Parameters.AddWithValue("@Quantidade", quantity);
                    updateProductCmd.Parameters.AddWithValue("@ID", productId);

                    int updateResult = updateProductCmd.ExecuteNonQuery();

                    if (paymentResult > 0 && updateResult > 0)
                    {
                        // Commit the transaction
                        transaction.Commit();
                        MessageBox.Show("Produto adquirido com sucesso.");
                        
                        Prompt.ClosePrompt();
                        this.Hide();
                        Cliente cliente = new Cliente();
                        cliente.Show();
                        this.Close(); 
                        cn.Close();
                        transaction.Dispose();

                        return;
                    }
                    else
                    {
                        // Rollback the transaction if anything failed
                        transaction.Rollback();
                        MessageBox.Show("Erro ao adquirir produto.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter o preço do produto.");
                }

                cn.Close();
                return;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adquirir produto: " + ex.Message);
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }


        public int GetNextID(string tableName)
        {
            int nextID = 1;
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT MAX(ID) FROM {tableName}", cn);
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int maxID))
                {
                    nextID = maxID + 1;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter próximo ID: " + ex.Message);
            }
            return nextID;
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 700,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    Font = new System.Drawing.Font("Segoe UI", 11)
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;


                

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }

            //close the Prompt
            public static void ClosePrompt()
            {
                Form prompt = new Form();
                prompt.Close();
            }
        }

        private void Cliente_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();

        }
    }
}
