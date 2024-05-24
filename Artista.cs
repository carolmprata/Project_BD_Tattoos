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


    public partial class Artista : Form
    {
        public string Artista_name { get; set; }
        public string Artista_id { get; set; }
        public Artista()
        {
            InitializeComponent();
        }

        private void Artista_Load(object sender, EventArgs e)
        {

        }
    }
}
