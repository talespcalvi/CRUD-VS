using System.Drawing.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Funcionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidarEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            return cpf.Length == 11 && long.TryParse(cpf, out _);
        }
        private void FormatarCPFTempoReal()
        {
            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "");

            if (cpf.Length > 11) cpf = cpf.Substring(0, 11);

            if (cpf.Length >= 1 && cpf.Length <= 3)
            {
                txtCpf.Text = cpf;
            }
            else if (cpf.Length > 3 && cpf.Length <= 6)
            {
                txtCpf.Text = $"{cpf.Substring(0, 3)}.{cpf.Substring(3)}";
            }
            else if (cpf.Length > 6 && cpf.Length <= 9)
            {
                txtCpf.Text = $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6)}";
            }
            else if (cpf.Length > 9)
            {
                txtCpf.Text = $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9)}";
            }

            txtCpf.SelectionStart = txtCpf.Text.Length;
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            FormatarCPFTempoReal();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCpf.Text.Equals("") &&
                    !txtEndereco.Text.Equals("") && !txtDepartamento.Text.Equals("") && !txtProjeto.Text.Equals(""))
                {
                    if (!ValidarEmail(txtEmail.Text))
                    {
                        MessageBox.Show("O email informado é inválido. Use um formato como exemplo@dominio.com.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEmail.Focus();
                        return;
                    }

                    if (!ValidarCPF(txtCpf.Text))
                    {
                        MessageBox.Show("O CPF informado é inválido. Ele deve conter 11 números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCpf.Focus();
                        return;
                    }

                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios
                    {
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        Cpf = txtCpf.Text.Replace(".", "").Replace("-", ""),
                        Endereco = txtEndereco.Text,
                        NomeDepartamento = txtDepartamento.Text,
                        NomeProjeto = txtProjeto.Text
                    };

                    if (cadFuncionarios.cadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcionário {cadFuncionarios.Nome} foi cadastrado com sucesso!");

                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtDepartamento.Clear();
                        txtProjeto.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar o funcionário.");
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente.");
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário: " + ex.Message);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Cpf = txtCpf.Text;

                    MySqlDataReader reader = cadFuncionarios.localizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            lblId.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();

                            txtDepartamento.Text = reader["departamento"] != DBNull.Value ? reader["departamento"].ToString() : "";
                            txtProjeto.Text = reader["projeto"] != DBNull.Value ? reader["projeto"].ToString() : "";
                        }
                        else
                        {
                            MessageBox.Show("Funcionário não encontrado.");
                            LimparCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado.");
                        LimparCampos();
                    }

                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF para realizar a pesquisa.");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar funcionário: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtCpf.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtDepartamento.Clear();
            txtProjeto.Clear();
            txtCpf.Focus();
            lblId.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30); 
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular); 

            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(45, 45, 45);
                    btn.ForeColor = Color.LimeGreen; 
                    btn.FlatStyle = FlatStyle.Flat; 
                    btn.FlatAppearance.BorderColor = Color.LimeGreen; 
                    btn.FlatAppearance.BorderSize = 1; 
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.FromArgb(45, 45, 45); 
                    textBox.ForeColor = Color.White; 
                    textBox.BorderStyle = BorderStyle.FixedSingle; 
                }
                else if (control is Label label)
                {
                    label.ForeColor = Color.White; 
                }
            }

            Button btnAjuda = new Button
            {
                Text = "Ajuda",
                Size = new System.Drawing.Size(100, 30),
                Location = new System.Drawing.Point(10, 10) 
            };
            btnAjuda.Click += btnAjuda_Click; 
            this.Controls.Add(btnAjuda);

            btnAjuda.Size = new System.Drawing.Size(100, 30);

            btnAjuda.Location = new System.Drawing.Point(this.ClientSize.Width - btnAjuda.Width - 10, 10);

            this.Resize += (s, ev) =>
            {
                btnAjuda.Location = new System.Drawing.Point(this.ClientSize.Width - btnAjuda.Width - 10, 10);
            };

            btnAjuda.Size = new System.Drawing.Size(btnLimpar.Width, btnLimpar.Height);

            btnAjuda.Location = new System.Drawing.Point(btnLimpar.Location.X, btnLimpar.Location.Y - btnAjuda.Height - 10);

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") &&
                    !txtNome.Text.Equals("") && !txtDepartamento.Text.Equals("") && !txtProjeto.Text.Equals(""))
                {
                    // Recupera o CPF atual do funcionário
                    string cpfAtual = null;
                    using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.Instancia.BancoServidor))
                    {
                        MysqlConexaoBanco.Open();
                        string queryCpfAtual = $"SELECT cpf FROM funcionarios WHERE id = {int.Parse(lblId.Text)}";
                        using (MySqlCommand comandoCpfAtual = new MySqlCommand(queryCpfAtual, MysqlConexaoBanco))
                        {
                            object resultadoCpf = comandoCpfAtual.ExecuteScalar();
                            if (resultadoCpf != null)
                            {
                                cpfAtual = resultadoCpf.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Verifica se o CPF foi alterado
                    string cpfFornecido = txtCpf.Text.Replace(".", "").Replace("-", "");
                    if (cpfAtual != cpfFornecido)
                    {
                        MessageBox.Show("O CPF não pode ser alterado. Operação cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpf.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtDepartamento.Clear();
                        txtProjeto.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();

                        return; 
                    }

                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios
                    {
                        Id = int.Parse(lblId.Text),
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        Endereco = txtEndereco.Text,
                        NomeDepartamento = txtDepartamento.Text,
                        NomeProjeto = txtProjeto.Text
                    };

                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show("Os dados do funcionário foram atualizados com sucesso!");

                        txtCpf.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtDepartamento.Clear();
                        txtProjeto.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar as informações do funcionário.");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Favor localizar o funcionário antes de tentar atualizar as informações.");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do funcionário: " + ex.Message);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);

                    if (cadFuncionarios.deletarFuncionario())
                    {
                        MessageBox.Show("O funcionario foi excluido com sucesso");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Nao foi possivel excluir funcionario");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual funcionario deseja excluir");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcionario" + ex.Message);
            }
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            AjudaForm ajudaForm = new AjudaForm();
            ajudaForm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
