using ProjetoBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    public partial class Rececionista : Form
    {
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        public string Rececionista_name { get; set; }
        public string Rececionista_id { get; set; }

        public Rececionista()
        {
            InitializeComponent();
        }

        private void Rececionista_Load(object sender, EventArgs e)
        {
            label2.Text = "Bem Vindo, " + Rececionista_name + "!";
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (botaoClientes.Checked)
            {
                LoadClientes();
            }
            else if (botaoServicos.Checked)
            {
                LoadServicos();
            }
            else if (botaoPagamentos.Checked)
            {
                LoadPagamentos();
            }
            else if (botaoProdutos.Checked)
            {
                LoadProdutos();
            }
        }

        private void LoadClientes()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                DisplayContainer.Items.Clear();
                while (reader.Read())
                {
                    string clienteInfo = $"ID: {reader["ID"]}, Nome: {reader["Nome"]}, Morada: {reader["Morada"]}, Email: {reader["Email"]}, DataNascimento: {reader["DataNascimento"]}, Telefone: {reader["Telefone"]}, Genero: {reader["Genero"]}, RegistoSaude: {reader["RegistoSaude"]}";
                    DisplayContainer.Items.Add(clienteInfo);
                }
                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message);
            }
        }

        private void LoadServicos()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Servico", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                DisplayContainer.Items.Clear();
                while (reader.Read())
                {
                    string servicoInfo = $"ID: {reader["ID"]}, Zona: {reader["Zona"]}, Descricao: {reader["Descricao"]}, Cuidados: {reader["Cuidados"]}, Preco: {reader["Preco"]}, Duracao: {reader["Duracao"]}";
                    DisplayContainer.Items.Add(servicoInfo);
                }
                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }

        private void LoadPagamentos()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pagamento", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                DisplayContainer.Items.Clear();
                while (reader.Read())
                {
                    string pagamentoInfo = $"ID: {reader["ID"]}, Cliente_ID: {reader["Cliente_ID"]}, DataHora: {reader["DataHora"]}, Valor: {reader["Valor"]}, Metodo: {reader["Metodo"]}";
                    DisplayContainer.Items.Add(pagamentoInfo);
                }
                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message);
            }
        }

        private void LoadProdutos()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Produto", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                DisplayContainer.Items.Clear();
                while (reader.Read())
                {
                    string produtoInfo = $"ID: {reader["ID"]}, Nome: {reader["Nome"]}, Preco: {reader["Preco"]}, Quantidade: {reader["Quantidade"]}, Descricao: {reader["Descricao"]}";
                    DisplayContainer.Items.Add(produtoInfo);
                }
                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (DisplayContainer.SelectedItem != null)
            {
                string selectedItem = DisplayContainer.SelectedItem.ToString();
                string id = selectedItem.Split(',')[0].Split(':')[1].Trim();

                string newName = Prompt.ShowDialog("Enter new name", "Alterar");

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Cliente SET Nome = @Nome WHERE ID = @ID", cn);
                    cmd.Parameters.AddWithValue("@Nome", newName);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating item: " + ex.Message);
                }

                LoadCurrentItems();
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (botaoClientes.Checked)
            {
                string newName = Prompt.ShowDialog("Enter name", "Adicionar Cliente");
                string newMorada = Prompt.ShowDialog("Enter address", "Adicionar Cliente");
                string newEmail = Prompt.ShowDialog("Enter email", "Adicionar Cliente");
                string newDataNascimento = Prompt.ShowDialog("Enter birthdate (YYYY-MM-DD)", "Adicionar Cliente");
                string newTelefone = Prompt.ShowDialog("Enter phone number", "Adicionar Cliente");
                string newGenero = Prompt.ShowDialog("Enter gender", "Adicionar Cliente");
                string newRegistoSaude = Prompt.ShowDialog("Enter health record", "Adicionar Cliente");

                int nextID = GetNextID("Cliente");

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AddCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", nextID);
                    cmd.Parameters.AddWithValue("@Nome", newName);
                    cmd.Parameters.AddWithValue("@Morada", newMorada);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@DataNascimento", newDataNascimento);
                    cmd.Parameters.AddWithValue("@Telefone", newTelefone);
                    cmd.Parameters.AddWithValue("@Genero", newGenero);
                    cmd.Parameters.AddWithValue("@RegistoSaude", newRegistoSaude);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Cliente added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding Cliente: " + ex.Message);
                }

                LoadClientes();
            }
            else if (botaoServicos.Checked)
            {
                string newZona = Prompt.ShowDialog("Enter zone", "Adicionar Serviço");
                string newDescricao = Prompt.ShowDialog("Enter description", "Adicionar Serviço");
                string newCuidados = Prompt.ShowDialog("Enter care instructions", "Adicionar Serviço");
                string newPreco = Prompt.ShowDialog("Enter price", "Adicionar Serviço");
                string newDuracao = Prompt.ShowDialog("Enter duration (HH:MM:SS)", "Adicionar Serviço");

                int nextID = GetNextID("Servico");

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AddServico", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", nextID);
                    cmd.Parameters.AddWithValue("@Zona", newZona);
                    cmd.Parameters.AddWithValue("@Descricao", newDescricao);
                    cmd.Parameters.AddWithValue("@Cuidados", newCuidados);
                    cmd.Parameters.AddWithValue("@Preco", newPreco);
                    cmd.Parameters.AddWithValue("@Duracao", newDuracao);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Serviço added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding Serviço: " + ex.Message);
                }

                LoadServicos();
            }
            else if (botaoPagamentos.Checked)
            {
                string newClienteID = Prompt.ShowDialog("Enter client ID", "Adicionar Pagamento");
                string newDataHora = Prompt.ShowDialog("Enter date and time (YYYY-MM-DD HH:MM:SS)", "Adicionar Pagamento");
                string newValor = Prompt.ShowDialog("Enter amount", "Adicionar Pagamento");
                string newMetodo = Prompt.ShowDialog("Enter payment method", "Adicionar Pagamento");

                int nextID = GetNextID("Pagamento");

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AddPagamento", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", nextID);
                    cmd.Parameters.AddWithValue("@Cliente_ID", newClienteID);
                    cmd.Parameters.AddWithValue("@DataHora", newDataHora);
                    cmd.Parameters.AddWithValue("@Valor", newValor);
                    cmd.Parameters.AddWithValue("@Metodo", newMetodo);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Pagamento added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding Pagamento: " + ex.Message);
                }

                LoadPagamentos();
            }
            else if (botaoProdutos.Checked)
            {
                string newNome = Prompt.ShowDialog("Enter product name", "Adicionar Produto");
                string newPreco = Prompt.ShowDialog("Enter price", "Adicionar Produto");
                string newQuantidade = Prompt.ShowDialog("Enter quantity", "Adicionar Produto");
                string newDescricao = Prompt.ShowDialog("Enter description", "Adicionar Produto");

                int nextID = GetNextID("Produto");

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AddProduto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", nextID);
                    cmd.Parameters.AddWithValue("@Nome", newNome);
                    cmd.Parameters.AddWithValue("@Preco", newPreco);
                    cmd.Parameters.AddWithValue("@Quantidade", newQuantidade);
                    cmd.Parameters.AddWithValue("@Descricao", newDescricao);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Produto added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding Produto: " + ex.Message);
                }

                LoadProdutos();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (DisplayContainer.SelectedItem != null)
            {
                string selectedItem = DisplayContainer.SelectedItem.ToString();
                string id = selectedItem.Split(',')[0].Split(':')[1].Trim();

                string tableName = "";

                if (botaoClientes.Checked)
                {
                    tableName = "Cliente";
                }
                else if (botaoServicos.Checked)
                {
                    tableName = "Servico";
                }
                else if (botaoPagamentos.Checked)
                {
                    tableName = "Pagamento";
                }
                else if (botaoProdutos.Checked)
                {
                    tableName = "Produto";
                }

                try
                {
                    cn = bdConnection.getSGBDConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand($"DELETE FROM {tableName} WHERE ID = @ID", cn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message);
                }

                LoadCurrentItems();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private int GetNextID(string tableName)
        {
            int nextID = 1;
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT MAX(ID) FROM {tableName}", cn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    nextID = Convert.ToInt32(result) + 1;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving next ID: " + ex.Message);
            }
            return nextID;
        }

        private void LoadCurrentItems()
        {
            if (botaoClientes.Checked)
            {
                LoadClientes();
            }
            else if (botaoServicos.Checked)
            {
                LoadServicos();
            }
            else if (botaoPagamentos.Checked)
            {
                LoadPagamentos();
            }
            else if (botaoProdutos.Checked)
            {
                LoadProdutos();
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
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
        }
    }
}
