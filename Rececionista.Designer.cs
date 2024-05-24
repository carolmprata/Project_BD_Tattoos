namespace Project_BD_Tattoos
{
    partial class Rececionista
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DisplayContainer = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botaoServicos = new System.Windows.Forms.RadioButton();
            this.botaoPagamentos = new System.Windows.Forms.RadioButton();
            this.botaoProdutos = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.botaoClientes = new System.Windows.Forms.RadioButton();
            this.panelCargo = new System.Windows.Forms.Panel();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.panelCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bem Vindo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 36);
            this.label2.TabIndex = 6;
            // 
            // DisplayContainer
            // 
            this.DisplayContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayContainer.FormattingEnabled = true;
            this.DisplayContainer.ItemHeight = 20;
            this.DisplayContainer.Location = new System.Drawing.Point(243, 50);
            this.DisplayContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DisplayContainer.Name = "DisplayContainer";
            this.DisplayContainer.Size = new System.Drawing.Size(1021, 524);
            this.DisplayContainer.TabIndex = 213;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 236;
            // 
            // botaoServicos
            // 
            this.botaoServicos.AutoSize = true;
            this.botaoServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoServicos.Location = new System.Drawing.Point(8, 13);
            this.botaoServicos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoServicos.Name = "botaoServicos";
            this.botaoServicos.Size = new System.Drawing.Size(109, 29);
            this.botaoServicos.TabIndex = 230;
            this.botaoServicos.TabStop = true;
            this.botaoServicos.Text = "Serviços";
            this.botaoServicos.UseVisualStyleBackColor = true;
            this.botaoServicos.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // botaoPagamentos
            // 
            this.botaoPagamentos.AutoSize = true;
            this.botaoPagamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoPagamentos.Location = new System.Drawing.Point(8, 73);
            this.botaoPagamentos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoPagamentos.Name = "botaoPagamentos";
            this.botaoPagamentos.Size = new System.Drawing.Size(143, 29);
            this.botaoPagamentos.TabIndex = 3;
            this.botaoPagamentos.TabStop = true;
            this.botaoPagamentos.Text = "Pagamentos";
            this.botaoPagamentos.UseVisualStyleBackColor = true;
            this.botaoPagamentos.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // botaoProdutos
            // 
            this.botaoProdutos.AutoSize = true;
            this.botaoProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoProdutos.Location = new System.Drawing.Point(8, 103);
            this.botaoProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoProdutos.Name = "botaoProdutos";
            this.botaoProdutos.Size = new System.Drawing.Size(111, 29);
            this.botaoProdutos.TabIndex = 4;
            this.botaoProdutos.TabStop = true;
            this.botaoProdutos.Text = "Produtos";
            this.botaoProdutos.UseVisualStyleBackColor = true;
            this.botaoProdutos.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 16);
            this.label14.TabIndex = 233;
            // 
            // botaoClientes
            // 
            this.botaoClientes.AutoSize = true;
            this.botaoClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoClientes.Location = new System.Drawing.Point(8, 43);
            this.botaoClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botaoClientes.Name = "botaoClientes";
            this.botaoClientes.Size = new System.Drawing.Size(104, 29);
            this.botaoClientes.TabIndex = 1;
            this.botaoClientes.TabStop = true;
            this.botaoClientes.Text = "Clientes";
            this.botaoClientes.UseVisualStyleBackColor = true;
            this.botaoClientes.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // panelCargo
            // 
            this.panelCargo.Controls.Add(this.botaoClientes);
            this.panelCargo.Controls.Add(this.label14);
            this.panelCargo.Controls.Add(this.botaoProdutos);
            this.panelCargo.Controls.Add(this.botaoPagamentos);
            this.panelCargo.Controls.Add(this.botaoServicos);
            this.panelCargo.Location = new System.Drawing.Point(7, 50);
            this.panelCargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCargo.Name = "panelCargo";
            this.panelCargo.Size = new System.Drawing.Size(201, 159);
            this.panelCargo.TabIndex = 237;
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterar.Location = new System.Drawing.Point(33, 260);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(136, 51);
            this.buttonAlterar.TabIndex = 238;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Location = new System.Drawing.Point(33, 341);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(136, 51);
            this.buttonEliminar.TabIndex = 239;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionar.Location = new System.Drawing.Point(34, 422);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(136, 51);
            this.buttonAdicionar.TabIndex = 240;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // Rececionista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 660);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.panelCargo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DisplayContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Rececionista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rececionista";
            this.Load += new System.EventHandler(this.Rececionista_Load);
            this.panelCargo.ResumeLayout(false);
            this.panelCargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DisplayContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton botaoServicos;
        private System.Windows.Forms.RadioButton botaoPagamentos;
        private System.Windows.Forms.RadioButton botaoProdutos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton botaoClientes;
        private System.Windows.Forms.Panel panelCargo;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAdicionar;
    }
}