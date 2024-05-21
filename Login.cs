using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rececionista rececionista = new Rececionista();
            rececionista.Show();
            this.Hide();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Artista artista = new Artista();
            artista.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Hide();
        }
    }
}
