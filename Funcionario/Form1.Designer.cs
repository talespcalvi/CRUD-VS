namespace Funcionario
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtCpf = new TextBox();
            txtEndereco = new TextBox();
            btnCadastrar = new Button();
            btnPesquisar = new Button();
            label5 = new Label();
            lblId = new Label();
            btnLimpar = new Button();
            btnAtualizar = new Button();
            btnDeletar = new Button();
            txtProjeto = new TextBox();
            txtDepartamento = new TextBox();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AccessibleRole = AccessibleRole.Sound;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold);
            label1.Location = new Point(27, 108);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold);
            label2.Location = new Point(27, 150);
            label2.Name = "label2";
            label2.Size = new Size(57, 19);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold);
            label3.Location = new Point(27, 193);
            label3.Name = "label3";
            label3.Size = new Size(48, 19);
            label3.TabIndex = 3;
            label3.Text = "CPF:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold);
            label4.Location = new Point(27, 236);
            label4.Name = "label4";
            label4.Size = new Size(89, 19);
            label4.TabIndex = 4;
            label4.Text = "Endereco:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Arial", 12F);
            txtNome.Location = new Point(170, 108);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(544, 26);
            txtNome.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 12F);
            txtEmail.Location = new Point(170, 147);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(544, 26);
            txtEmail.TabIndex = 2;
            // 
            // txtCpf
            // 
            txtCpf.Font = new Font("Arial", 12F);
            txtCpf.Location = new Point(170, 190);
            txtCpf.MaxLength = 14;
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(544, 26);
            txtCpf.TabIndex = 3;
            txtCpf.TextChanged += txtCpf_TextChanged;
            // 
            // txtEndereco
            // 
            txtEndereco.Font = new Font("Arial", 12F);
            txtEndereco.Location = new Point(170, 233);
            txtEndereco.MaxLength = 200;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(544, 26);
            txtEndereco.TabIndex = 4;
            txtEndereco.TextChanged += txtEndereco_TextChanged;
            // 
            // btnCadastrar
            // 
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.Location = new Point(30, 395);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(141, 41);
            btnCadastrar.TabIndex = 7;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPesquisar.Location = new Point(210, 395);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(141, 41);
            btnPesquisar.TabIndex = 8;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(30, 38);
            label5.Name = "label5";
            label5.Size = new Size(124, 21);
            label5.TabIndex = 7;
            label5.Text = "Funcionario Id:";
            label5.Click += label5_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblId.Location = new Point(160, 38);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 21);
            lblId.TabIndex = 8;
            // 
            // btnLimpar
            // 
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpar.Location = new Point(616, 53);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(98, 29);
            btnLimpar.TabIndex = 9;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAtualizar.Location = new Point(397, 395);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(141, 41);
            btnAtualizar.TabIndex = 9;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.FlatStyle = FlatStyle.Flat;
            btnDeletar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeletar.Location = new Point(573, 395);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(141, 41);
            btnDeletar.TabIndex = 10;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += button1_Click_1;
            // 
            // txtProjeto
            // 
            txtProjeto.Font = new Font("Arial", 12F);
            txtProjeto.Location = new Point(170, 321);
            txtProjeto.MaxLength = 200;
            txtProjeto.Name = "txtProjeto";
            txtProjeto.Size = new Size(544, 26);
            txtProjeto.TabIndex = 6;
            // 
            // txtDepartamento
            // 
            txtDepartamento.Font = new Font("Arial", 12F);
            txtDepartamento.Location = new Point(170, 278);
            txtDepartamento.MaxLength = 11;
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(544, 26);
            txtDepartamento.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Bold);
            label6.Location = new Point(30, 325);
            label6.Name = "label6";
            label6.Size = new Size(79, 19);
            label6.TabIndex = 15;
            label6.Text = "Projetos:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Bold);
            label7.Location = new Point(27, 278);
            label7.Name = "label7";
            label7.Size = new Size(123, 19);
            label7.TabIndex = 13;
            label7.Text = "Departamento:";
            label7.Click += label7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 462);
            Controls.Add(txtProjeto);
            Controls.Add(txtDepartamento);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(btnDeletar);
            Controls.Add(btnAtualizar);
            Controls.Add(btnLimpar);
            Controls.Add(lblId);
            Controls.Add(label5);
            Controls.Add(btnPesquisar);
            Controls.Add(btnCadastrar);
            Controls.Add(txtEndereco);
            Controls.Add(txtCpf);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Funcionarios";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtCpf;
        private TextBox txtEndereco;
        private Button btnCadastrar;
        private Button btnPesquisar;
        private Label label5;
        private Label lblId;
        private Button btnLimpar;
        private Button btnAtualizar;
        private Button btnDeletar;
        private TextBox txtProjeto;
        private TextBox txtDepartamento;
        private Label label6;
        private Label label7;
    }
}
