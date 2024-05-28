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
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marcação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do Cliente";
            // 
            // nameBar
            // 
            this.nameBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.nameBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBar.Location = new System.Drawing.Point(163, 64);
            this.nameBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameBar.Name = "nameBar";
            this.nameBar.Size = new System.Drawing.Size(301, 29);
            this.nameBar.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tipo de Serviço";
            // 
            // btnRemocao
            // 
            this.btnRemocao.AutoSize = true;
            this.btnRemocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemocao.Location = new System.Drawing.Point(163, 180);
            this.btnRemocao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemocao.Name = "btnRemocao";
            this.btnRemocao.Size = new System.Drawing.Size(110, 28);
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
            this.btnPiercing.Location = new System.Drawing.Point(163, 150);
            this.btnPiercing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPiercing.Name = "btnPiercing";
            this.btnPiercing.Size = new System.Drawing.Size(97, 28);
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
            this.btnTatuagem.Location = new System.Drawing.Point(163, 119);
            this.btnTatuagem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTatuagem.Name = "btnTatuagem";
            this.btnTatuagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTatuagem.Size = new System.Drawing.Size(113, 28);
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
            this.label4.Location = new System.Drawing.Point(531, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Data";
            // 
            // dateTPInicio
            // 
            this.dateTPInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTPInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTPInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPInicio.Location = new System.Drawing.Point(578, 63);
            this.dateTPInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTPInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTPInicio.Name = "dateTPInicio";
            this.dateTPInicio.Size = new System.Drawing.Size(215, 29);
            this.dateTPInicio.TabIndex = 21;
            this.dateTPInicio.Value = new System.DateTime(2024, 5, 29, 10, 0, 0, 0);
            // 
            // DisplayContainer
            // 
            this.DisplayContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayContainer.FormattingEnabled = true;
            this.DisplayContainer.ItemHeight = 17;
            this.DisplayContainer.Location = new System.Drawing.Point(289, 119);
            this.DisplayContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DisplayContainer.Name = "DisplayContainer";
            this.DisplayContainer.Size = new System.Drawing.Size(504, 157);
            this.DisplayContainer.TabIndex = 214;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(795, 490);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFinalizar.Size = new System.Drawing.Size(122, 57);
            this.btnFinalizar.TabIndex = 215;
            this.btnFinalizar.Text = "Finalizar Marcação";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 216;
            this.label5.Text = "Artista";
            // 
            // listArtist
            // 
            this.listArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listArtist.FormattingEnabled = true;
            this.listArtist.ItemHeight = 17;
            this.listArtist.Location = new System.Drawing.Point(289, 313);
            this.listArtist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listArtist.Name = "listArtist";
            this.listArtist.Size = new System.Drawing.Size(504, 157);
            this.listArtist.TabIndex = 217;
            // 
            // MarcacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 607);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
