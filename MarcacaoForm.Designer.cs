using System.Windows.Forms;

namespace Project_BD_Tattoos
{
    partial class MarcacaoForm
    {
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemocao = new System.Windows.Forms.RadioButton();
            this.btnPiercing = new System.Windows.Forms.RadioButton();
            this.btnTatuagem = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTPInicio = new System.Windows.Forms.DateTimePicker();
            this.DisplayContainer = new System.Windows.Forms.ListBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listArtist = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marcação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do Cliente";
            // 
            // nameBar
            // 
            this.nameBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.nameBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBar.Location = new System.Drawing.Point(217, 79);
            this.nameBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameBar.Name = "nameBar";
            this.nameBar.Size = new System.Drawing.Size(400, 34);
            this.nameBar.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tipo de Serviço";
            // 
            // btnRemocao
            // 
            this.btnRemocao.AutoSize = true;
            this.btnRemocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemocao.Location = new System.Drawing.Point(217, 221);
            this.btnRemocao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemocao.Name = "btnRemocao";
            this.btnRemocao.Size = new System.Drawing.Size(138, 33);
            this.btnRemocao.TabIndex = 18;
            this.btnRemocao.TabStop = true;
            this.btnRemocao.Text = "Remoção";
            this.btnRemocao.UseVisualStyleBackColor = true;
            this.btnRemocao.CheckedChanged += new System.EventHandler(this.ServiceType_CheckedChanged);
            // 
            // btnPiercing
            // 
            this.btnPiercing.AutoSize = true;
            this.btnPiercing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiercing.Location = new System.Drawing.Point(217, 184);
            this.btnPiercing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPiercing.Name = "btnPiercing";
            this.btnPiercing.Size = new System.Drawing.Size(123, 33);
            this.btnPiercing.TabIndex = 17;
            this.btnPiercing.TabStop = true;
            this.btnPiercing.Text = "Piercing";
            this.btnPiercing.UseVisualStyleBackColor = true;
            this.btnPiercing.CheckedChanged += new System.EventHandler(this.ServiceType_CheckedChanged);
            // 
            // btnTatuagem
            // 
            this.btnTatuagem.AutoSize = true;
            this.btnTatuagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatuagem.Location = new System.Drawing.Point(217, 147);
            this.btnTatuagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTatuagem.Name = "btnTatuagem";
            this.btnTatuagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTatuagem.Size = new System.Drawing.Size(143, 33);
            this.btnTatuagem.TabIndex = 16;
            this.btnTatuagem.TabStop = true;
            this.btnTatuagem.Text = "Tatuagem";
            this.btnTatuagem.UseVisualStyleBackColor = true;
            this.btnTatuagem.CheckedChanged += new System.EventHandler(this.ServiceType_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(708, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Data";
            // 
            // dateTPInicio
            // 
            this.dateTPInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTPInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPInicio.Location = new System.Drawing.Point(771, 77);
            this.dateTPInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPInicio.Name = "dateTPInicio";
            this.dateTPInicio.Size = new System.Drawing.Size(319, 34);
            this.dateTPInicio.TabIndex = 21;
            // 
            // DisplayContainer
            // 
            this.DisplayContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayContainer.FormattingEnabled = true;
            this.DisplayContainer.ItemHeight = 20;
            this.DisplayContainer.Location = new System.Drawing.Point(385, 147);
            this.DisplayContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisplayContainer.Name = "DisplayContainer";
            this.DisplayContainer.Size = new System.Drawing.Size(670, 204);
            this.DisplayContainer.TabIndex = 214;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(1060, 603);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFinalizar.Size = new System.Drawing.Size(163, 70);
            this.btnFinalizar.TabIndex = 215;
            this.btnFinalizar.Text = "Finalizar Marcação";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 216;
            this.label5.Text = "Artista";
            // 
            // listArtist
            // 
            this.listArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listArtist.FormattingEnabled = true;
            this.listArtist.ItemHeight = 20;
            this.listArtist.Location = new System.Drawing.Point(183, 385);
            this.listArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listArtist.Name = "listArtist";
            this.listArtist.Size = new System.Drawing.Size(670, 204);
            this.listArtist.TabIndex = 217;
            // 
            // MarcacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 747);
            this.Controls.Add(this.listArtist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.DisplayContainer);
            this.Controls.Add(this.dateTPInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemocao);
            this.Controls.Add(this.btnPiercing);
            this.Controls.Add(this.btnTatuagem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MarcacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcação";
            this.Load += new System.EventHandler(this.MarcacaoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton btnRemocao;
        private System.Windows.Forms.RadioButton btnPiercing;
        private System.Windows.Forms.RadioButton btnTatuagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTPInicio;
        private ListBox DisplayContainer;
        private Button btnFinalizar;
        private Label label5;
        private ListBox listArtist;
    }
}
