namespace Project_BD_Tattoos
{
    partial class Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnServico = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnArtistas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.dataGridViewArtistas = new System.Windows.Forms.DataGridView();
            this.dataGridViewServicos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtistas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnServico
            // 
            this.btnServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServico.Location = new System.Drawing.Point(507, 15);
            this.btnServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnServico.Name = "btnServico";
            this.btnServico.Size = new System.Drawing.Size(136, 48);
            this.btnServico.TabIndex = 0;
            this.btnServico.Text = "Serviços";
            this.btnServico.UseVisualStyleBackColor = true;
            this.btnServico.Click += new System.EventHandler(this.btnServico_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(721, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Produtos";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnArtistas
            // 
            this.btnArtistas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtistas.Location = new System.Drawing.Point(297, 15);
            this.btnArtistas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnArtistas.Name = "btnArtistas";
            this.btnArtistas.Size = new System.Drawing.Size(136, 48);
            this.btnArtistas.TabIndex = 2;
            this.btnArtistas.Text = "Artistas";
            this.btnArtistas.UseVisualStyleBackColor = true;
            this.btnArtistas.Click += new System.EventHandler(this.btnArtistas_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_BD_Tattoos.Properties.Resources.BD_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(33, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(225, 98);
            this.comboBoxCategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(276, 24);
            this.comboBoxCategorias.TabIndex = 4;
            // 
            // dataGridViewArtistas
            // 
            this.dataGridViewArtistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArtistas.Location = new System.Drawing.Point(225, 132);
            this.dataGridViewArtistas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewArtistas.Name = "dataGridViewArtistas";
            this.dataGridViewArtistas.RowHeadersWidth = 51;
            this.dataGridViewArtistas.Size = new System.Drawing.Size(417, 283);
            this.dataGridViewArtistas.TabIndex = 5;
            this.dataGridViewArtistas.Visible = false;
            // 
            // dataGridViewServicos
            // 
            this.dataGridViewServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServicos.Location = new System.Drawing.Point(225, 132);
            this.dataGridViewServicos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewServicos.Name = "dataGridViewServicos";
            this.dataGridViewServicos.RowHeadersWidth = 51;
            this.dataGridViewServicos.Size = new System.Drawing.Size(713, 283);
            this.dataGridViewServicos.TabIndex = 6;
            this.dataGridViewServicos.Visible = false;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridViewServicos);
            this.Controls.Add(this.dataGridViewArtistas);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnArtistas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnServico);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtistas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServico;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnArtistas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.DataGridView dataGridViewArtistas;
        private System.Windows.Forms.DataGridView dataGridViewServicos;
    }
}