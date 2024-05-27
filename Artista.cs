using ProjetoBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    public partial class Artista : Form
    {
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        public string Artista_name { get; set; }
        public string Artista_id { get; set; } 

        public Artista()
        {
            InitializeComponent();
        }

        private void Artista_Load(object sender, EventArgs e)
        {
            bemvindoartista.Text = "Bem-vindo " + Artista_name + "!";
        }

        private void LoadArtistaReviews()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Hide();
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                string query = @"
                SELECT ServicoDescricao, ReviewDescricao, Avaliacao
                FROM vw_ArtistaReviews
                WHERE Artista_ID = @ArtistaID";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ArtistaID", Artista_id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                listBox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {

                    listBox.Items.Add($"Serviço: {row["ServicoDescricao"]}");
                    listBox.Items.Add($"Review: {row["ReviewDescricao"]}");
                    listBox.Items.Add($"Avaliação: {row["Avaliacao"]} ★");

                    listBox.Items.Add ("");




                }

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar reviews: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




        private void btnReview_Click(object sender, EventArgs e)
        {
            LoadArtistaReviews();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Show();


            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                string query = @"
        SELECT 
            A.ID,
            A.Data,
            A.Hora,
            C.Nome AS NomeCliente,
            S.Descricao AS ServicoDescricao
        FROM Agendamento A
        INNER JOIN Cliente C ON A.Cliente_ID = C.ID
        INNER JOIN Servico S ON A.Servico_ID = S.ID
        WHERE A.Artista_ID = @ArtistaID";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ArtistaID", Artista_id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int agendamentoID = (int)row["ID"];
                    DateTime data = Convert.ToDateTime(row["Data"]);
                    TimeSpan hora = (TimeSpan)row["Hora"];

                    // Create a panel to hold appointment details and delete button
                    Panel panel = new Panel();
                    panel.Size = new Size(flowLayoutPanel1.Width - 6, 90);
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    // Create label for appointment details
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = $"Data: {data.ToShortDateString()} \n - Hora: {hora} \n - Cliente: {row["NomeCliente"]} \n - Serviço: {row["ServicoDescricao"]}";
                    label.Location = new Point(5, 5);

                    // Create delete button
                    Button deleteButton = new Button();
                    deleteButton.Text = "Remover";
                    deleteButton.Tag = agendamentoID;
                    deleteButton.Size = new Size(100, 30);
                    deleteButton.Location = new Point(panel.Width - 105, 20);
                    deleteButton.Click += new EventHandler(DeleteButton_Click);

                    // Add label and button to panel
                    panel.Controls.Add(label);
                    panel.Controls.Add(deleteButton);

                    // Add panel to flowLayoutPanel
                    flowLayoutPanel1.Controls.Add(panel);
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar agendamentos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;
            int agendamentoID = (int)deleteButton.Tag;

            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                string query = "DELETE FROM Agendamento WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ID", agendamentoID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Marcação removida com sucesso!");
                    button1_Click(sender, e); // Refresh the list
                }
                else
                {
                    MessageBox.Show("Falha ao remover a marcação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover a marcação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma marcação para remover.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                // Obter o ID da marcação selecionada
                string selectedText = listBox.SelectedItem.ToString();
                int startIndex = selectedText.IndexOf("ID: ") + 4;
                int endIndex = selectedText.IndexOf(" ", startIndex);
                int id = int.Parse(selectedText.Substring(startIndex, endIndex - startIndex));

                string query = "DELETE FROM Agendamento WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ID", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Marcação removida com sucesso!");
                    button1_Click(sender, e); // Atualizar a lista de marcações
                }
                else
                {
                    MessageBox.Show("Falha ao remover a marcação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover a marcação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
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

