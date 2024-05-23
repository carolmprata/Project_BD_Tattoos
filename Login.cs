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
    public partial class Login : Form
    {

        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();

        private Color originalButton3Color;
        private Color originalButtonRececionistaColor;
        private Color originalButton1Color;
        private Color originalButtonArtistaColor;
        private Color originalButton2Color;
        bool isRececionista = false;
        bool isArtista = false;
        
        String name = "";
        String id = "";



        public Login()
        {
            InitializeComponent();

            originalButton3Color = button3.BackColor;
            originalButtonRececionistaColor = button1.BackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isRececionista = true;
            isArtista = false;

            if (isRececionista && !isArtista)
            {
                button1.BackColor = Color.Green;
                button3.BackColor = originalButton3Color; 
                label3.Show();
                txtID.Show();
                label5.Show();
                button4.Show();
                txtName.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isArtista = true;
            isRececionista = false;

            if (isArtista && !isRececionista)
            {
                button3.BackColor = Color.Green;
                button1.BackColor = originalButtonRececionistaColor;
                label3.Show();
                txtID.Show();
                label5.Show();
                button4.Show();
                txtName.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = txtName.Text;
        }


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            id = txtID.Text;
        }

        private void Search_on_DB()
        {
            try
            {
                cn = bdConnection.getSGBDConnection();
                cn.Open();
                string query = "";
                if (isRececionista)
                {
                    query = @"
                SELECT Staff.*
                FROM Staff
                INNER JOIN Rececionista ON Staff.ID = Rececionista.Staff_ID
                WHERE Staff.Nome = @name AND Staff.ID = @id";
                }
                else if (isArtista)
                {
                    query = @"
                SELECT Staff.*
                FROM Staff
                INNER JOIN Artista ON Staff.ID = Artista.Staff_ID
                WHERE Staff.Nome = @name AND Staff.ID = @id";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (isRececionista)
                        {
                            Rececionista rececionista = new Rececionista();
                            rececionista.Show();
                            this.Hide();
                        }
                        else if (isArtista)
                        {
                            Artista artista = new Artista();
                            artista.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Utilizador não encontrado");
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão à base de dados: " + ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Por favor preencha todos os campos");
            }
            else
            {
                Search_on_DB();
            }
        }
    }
}
