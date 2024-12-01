using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionario
{
    public partial class AjudaForm : Form
    {
        public AjudaForm()
        {
            

            // Configuração da tela de ajuda
            this.Text = "Ajuda";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;

            // Adicionando um Label para o texto de ajuda
            Label lblAjuda = new Label
            {
                Text = "Bem-vindo à ajuda!\n\n" +
                       "Aqui estão algumas instruções para usar o sistema:\n" +
                       "1. Para adicionar um funcionário, preencha os campos e clique em 'Cadastrar'.\n" +
                       "2. Para localizar um funcionário, insira o CPF no campo correspondente e clique em 'Pesquisar'.\n" +
                       "3. Para atualizar informações, pesquise um funcionario, edite os dados e clique em 'Atualizar'.\n" +
                       "4. Para excluir um funcionário, insira o CPF e clique em 'Deletar'.",
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                Padding = new Padding(10)
            };

            this.Controls.Add(lblAjuda);
        }
    }
}
