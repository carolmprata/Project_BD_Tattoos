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
    public partial class Cliente : Form
    {

        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        public Cliente()
        {
            InitializeComponent();
            comboBoxCategorias.SelectedIndexChanged += new EventHandler(comboBoxCategorias_SelectedIndexChanged);

        }

        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelecionado = comboBoxCategorias.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(itemSelecionado))
            {
                if (itemSelecionado == "EspecialistaRemocaoLaser" || itemSelecionado == "Tatuador" || itemSelecionado == "BodyPiercer")
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

        private void LoadServicosByCategory(string zona)
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = "SELECT Zona, Descricao, Cuidados, Preco, Duracao FROM Servico";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Zona", zona);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewServicos.DataSource = dataTable;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços: " + ex.Message);
            }
        }

        private void btnArtistas_Click_1(object sender, EventArgs e)
        {
            dataGridViewArtistas.Show();
            dataGridViewServicos.Hide();
            LoadArtistaCategorias();
        }

        private void btnServico_Click_1(object sender, EventArgs e)
        {
            dataGridViewArtistas.Hide();
            dataGridViewServicos.Show();
            LoadServicosCategorias();
        }
    }
}
