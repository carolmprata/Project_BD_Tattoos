using ProjetoBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    public partial class MarcacaoForm : Form
    {
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        public string Rececionista_name { get; set; }

        public MarcacaoForm()
        {
            InitializeComponent();
            LoadClientNames();
        }

        private void MarcacaoForm_Load(object sender, EventArgs e)
        {
            LoadClientNames();
        }

        private void LoadClientNames()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome FROM Cliente", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection clientNames = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    clientNames.Add(reader["Nome"].ToString());
                }
                reader.Close();
                cn.Close();

                nameBar.AutoCompleteCustomSource = clientNames;
                nameBar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                nameBar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nomes dos clientes: " + ex.Message);
            }
        }

        private void ServiceType_CheckedChanged(object sender, EventArgs e)
        {
            if (btnTatuagem.Checked)
            {
                LoadAvailableServices("Tatuagem");
                LoadArtists("Tatuador");
            }
            else if (btnPiercing.Checked)
            {
                LoadAvailableServices("Piercing");
                LoadArtists("BodyPiercer");
            }
            else if (btnRemocao.Checked)
            {
                LoadAvailableServices("Remocao");
                LoadArtists("EspecialistaRemocaoLaser");
            }
        }

        private void LoadAvailableServices(string serviceType)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                SqlCommand cmd = null;

                switch (serviceType)
                {
                    case "Tatuagem":
                        cmd = new SqlCommand(
                            "SELECT T.Servico_ID AS ID, S.Descricao, S.Preco " +
                            "FROM Tatuagem T " +
                            "JOIN Servico S ON T.Servico_ID = S.ID", cn);
                        break;
                    case "Piercing":
                        cmd = new SqlCommand(
                            "SELECT P.Servico_ID AS ID, S.Descricao, S.Preco " +
                            "FROM Piercing P " +
                            "JOIN Servico S ON P.Servico_ID = S.ID", cn);
                        break;
                    case "Remocao":
                        cmd = new SqlCommand(
                            "SELECT R.Servico_ID AS ID, S.Descricao, S.Preco " +
                            "FROM Remocao R " +
                            "JOIN Servico S ON R.Servico_ID = S.ID", cn);
                        break;
                }

                if (cmd != null)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    DisplayContainer.Items.Clear();

                    while (reader.Read())
                    {
                        string serviceInfo = $"ID: {reader["ID"]}, {reader["Descricao"]}, {reader["Preco"]}€";
                        DisplayContainer.Items.Add(serviceInfo);
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

        private void LoadArtists(string artistType)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                SqlCommand cmd = null;

                switch (artistType)
                {
                    case "Tatuador":
                        cmd = new SqlCommand(
                            "SELECT A.Artista_ID, S.Nome " +
                            "FROM Tatuador A " +
                            "JOIN Artista A2 ON A.Artista_ID = A2.Artista_ID " +
                            "JOIN Staff S ON A2.Artista_ID = S.ID", cn);
                        break;
                    case "BodyPiercer":
                        cmd = new SqlCommand(
                            "SELECT A.Artista_ID, S.Nome " +
                            "FROM BodyPiercer A " +
                            "JOIN Artista A2 ON A.Artista_ID = A2.Artista_ID " +
                            "JOIN Staff S ON A2.Artista_ID = S.ID", cn);
                        break;
                    case "EspecialistaRemocaoLaser":
                        cmd = new SqlCommand(
                            "SELECT A.Artista_ID, S.Nome " +
                            "FROM EspecialistaRemocaoLaser A " +
                            "JOIN Artista A2 ON A.Artista_ID = A2.Artista_ID " +
                            "JOIN Staff S ON A2.Artista_ID = S.ID", cn);
                        break;
                }

                if (cmd != null)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    listArtist.Items.Clear();

                    while (reader.Read())
                    {
                        string artistInfo = $"{reader["Nome"]} (ID: {reader["Artista_ID"]})";
                        listArtist.Items.Add(artistInfo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameBar.Text) || listArtist.SelectedItem == null || DisplayContainer.SelectedItem == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos e selecione um serviço e um artista.");
                return;
            }

            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();

                string selectedArtist = listArtist.SelectedItem.ToString();
                string selectedService = DisplayContainer.SelectedItem.ToString();

                int artistID = int.Parse(selectedArtist.Split(new[] { "ID: " }, StringSplitOptions.None)[1].Split(')')[0].Trim());
                int serviceID = int.Parse(selectedService.Split(new[] { "ID: " }, StringSplitOptions.None)[1].Split(',')[0].Trim());
                string clientName = nameBar.Text;
                //date sem horas
                DateTime date = dateTPInicio.Value.Date;

                //time sem data



                TimeSpan time = dateTPInicio.Value.TimeOfDay;

                // Find client ID by name
                SqlCommand findClientCmd = new SqlCommand("SELECT ID FROM Cliente WHERE Nome = @Nome", cn);
                findClientCmd.Parameters.AddWithValue("@Nome", clientName);
                int clientID = (int)findClientCmd.ExecuteScalar();

                // Insert new booking
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Agendamento (ID, Data, Hora, Cliente_ID, Servico_ID, Artista_ID) VALUES (@ID, @Data, @Hora, @Cliente_ID, @Servico_ID, @Artista_ID)", cn);
                cmd.Parameters.AddWithValue("@ID", GetNextID("Agendamento"));
                cmd.Parameters.AddWithValue("@Data", date);
                cmd.Parameters.AddWithValue("@Hora", time);
                cmd.Parameters.AddWithValue("@Cliente_ID", clientID);
                cmd.Parameters.AddWithValue("@Servico_ID", serviceID);
                cmd.Parameters.AddWithValue("@Artista_ID", artistID);

                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Marcação finalizada com sucesso!");
                // Close the form
                this.Close();
                //abrir o rececionista
                Rececionista rececionistaForm = new Rececionista();
                //nome do rececionista
                
                rececionistaForm.Rececionista_name = Rececionista_name;

                rececionistaForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar a marcação: " + ex.Message);
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
                MessageBox.Show("Erro ao obter o próximo ID: " + ex.Message);
            }
            return nextID;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Handle the event if needed
        }
    }
}
