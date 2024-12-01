using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Text.RegularExpressions;

namespace Funcionario
{
    internal class cadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;
        private int idDepartamento;
        private string nomeDepartamento;
        private string nomeProjeto;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        public string NomeDepartamento
        {
            get { return nomeDepartamento; }
            set { nomeDepartamento = value; }
        }
        public string NomeProjeto
        {
            get { return nomeProjeto; }
            set { nomeProjeto = value; }
        }

        public bool cadastrarFuncionarios()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.Instancia.BancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    int idDepartamento;
                    string selectDepartamento = $"SELECT id FROM departamentos WHERE nome = '{NomeDepartamento}'";
                    using (MySqlCommand comandoSelectDep = new MySqlCommand(selectDepartamento, MysqlConexaoBanco))
                    {
                        object resultadoDep = comandoSelectDep.ExecuteScalar();
                        if (resultadoDep != null)
                        {
                            idDepartamento = Convert.ToInt32(resultadoDep);
                        }
                        else
                        {
                            string insertDepartamento = $"INSERT INTO departamentos (nome) VALUES ('{NomeDepartamento}')";
                            using (MySqlCommand comandoInsertDep = new MySqlCommand(insertDepartamento, MysqlConexaoBanco))
                            {
                                comandoInsertDep.ExecuteNonQuery();
                                idDepartamento = (int)comandoInsertDep.LastInsertedId;
                            }
                        }
                    }

                    int idProjeto;
                    string selectProjeto = $"SELECT id FROM projetos WHERE nome = '{NomeProjeto}' AND id_departamento = {idDepartamento}";
                    using (MySqlCommand comandoSelectProj = new MySqlCommand(selectProjeto, MysqlConexaoBanco))
                    {
                        object resultadoProj = comandoSelectProj.ExecuteScalar();
                        if (resultadoProj != null)
                        {
                            idProjeto = Convert.ToInt32(resultadoProj);
                        }
                        else
                        {
                            string insertProjeto = $"INSERT INTO projetos (nome, id_departamento) VALUES ('{NomeProjeto}', {idDepartamento})";
                            using (MySqlCommand comandoInsertProj = new MySqlCommand(insertProjeto, MysqlConexaoBanco))
                            {
                                comandoInsertProj.ExecuteNonQuery();
                                idProjeto = (int)comandoInsertProj.LastInsertedId;
                            }
                        }
                    }

                    string insertFuncionario = $"INSERT INTO funcionarios (nome, email, cpf, endereco, id_departamento) " +
                                                $"VALUES ('{Nome}', '{Email}', '{Cpf}', '{Endereco}', {idDepartamento})";
                    using (MySqlCommand comandoInsertFunc = new MySqlCommand(insertFuncionario, MysqlConexaoBanco))
                    {
                        comandoInsertFunc.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - metodo cadastrarFuncionario: " + ex.Message);
                return false;
            }
        }

        public MySqlDataReader localizarFuncionario()
        {
            try
            {
                string cpfSemFormatacao = Cpf.Replace(".", "").Replace("-", "");

                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.Instancia.BancoServidor);
                MysqlConexaoBanco.Open();

                string select = $@"
            SELECT 
                f.id, 
                f.nome, 
                f.email, 
                f.cpf, 
                f.endereco, 
                d.nome AS departamento, 
                p.nome AS projeto 
            FROM 
                funcionarios f
            LEFT JOIN 
                departamentos d ON f.id_departamento = d.id
            LEFT JOIN 
                projetos p ON d.id = p.id_departamento
            WHERE 
                f.cpf = '{cpfSemFormatacao}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();

                return reader;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - metodo localizarFuncionario: " + ex.Message);
                return null;
            }
        }
        public bool atualizarFuncionario()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.Instancia.BancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string cpfAtual = null;
                    string queryCpfAtual = $"SELECT cpf FROM funcionarios WHERE id = {Id}";
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
                            return false;
                        }
                    }

                    if (!string.IsNullOrEmpty(Cpf) && cpfAtual != Cpf.Replace(".", "").Replace("-", ""))
                    {
                        MessageBox.Show("O CPF não pode ser alterado. Operação cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false; 
                    }

                    if (!ValidarEmail(Email))
                    {
                        MessageBox.Show("O email informado é inválido. Use um formato como exemplo@dominio.com.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    int idDepartamento;
                    string selectDepartamento = $"SELECT id FROM departamentos WHERE nome = '{NomeDepartamento}'";
                    using (MySqlCommand comandoSelectDep = new MySqlCommand(selectDepartamento, MysqlConexaoBanco))
                    {
                        object resultadoDep = comandoSelectDep.ExecuteScalar();
                        if (resultadoDep != null)
                        {
                            idDepartamento = Convert.ToInt32(resultadoDep);
                        }
                        else
                        {
                            string insertDepartamento = $"INSERT INTO departamentos (nome) VALUES ('{NomeDepartamento}')";
                            using (MySqlCommand comandoInsertDep = new MySqlCommand(insertDepartamento, MysqlConexaoBanco))
                            {
                                comandoInsertDep.ExecuteNonQuery();
                                idDepartamento = (int)comandoInsertDep.LastInsertedId;
                            }
                        }
                    }

                    int idProjeto;
                    string selectProjeto = $"SELECT id FROM projetos WHERE nome = '{NomeProjeto}' AND id_departamento = {idDepartamento}";
                    using (MySqlCommand comandoSelectProj = new MySqlCommand(selectProjeto, MysqlConexaoBanco))
                    {
                        object resultadoProj = comandoSelectProj.ExecuteScalar();
                        if (resultadoProj != null)
                        {
                            idProjeto = Convert.ToInt32(resultadoProj);
                        }
                        else
                        {
                            string insertProjeto = $"INSERT INTO projetos (nome, id_departamento) VALUES ('{NomeProjeto}', {idDepartamento})";
                            using (MySqlCommand comandoInsertProj = new MySqlCommand(insertProjeto, MysqlConexaoBanco))
                            {
                                comandoInsertProj.ExecuteNonQuery();
                                idProjeto = (int)comandoInsertProj.LastInsertedId;
                            }
                        }
                    }

                    string updateFuncionario = $@"
                        UPDATE funcionarios 
                        SET 
                            nome = '{Nome}', 
                            email = '{Email}', 
                            endereco = '{Endereco}', 
                            id_departamento = {idDepartamento} 
                        WHERE id = {Id};";

                    using (MySqlCommand comandoUpdateFunc = new MySqlCommand(updateFuncionario, MysqlConexaoBanco))
                    {
                        comandoUpdateFunc.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - metodo atualizarFuncionario: " + ex.Message);
                return false;
            }
        }

        private bool ValidarEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private bool ValidarCPF(string cpf)
        {
            return cpf.Length == 11 && long.TryParse(cpf, out _);
        }

        public bool deletarFuncionario()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.Instancia.BancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    int idDepartamento = 0;
                    string selectDepartamento = $"SELECT id_departamento FROM funcionarios WHERE id = {Id}";
                    using (MySqlCommand comandoSelectDep = new MySqlCommand(selectDepartamento, MysqlConexaoBanco))
                    {
                        object resultadoDep = comandoSelectDep.ExecuteScalar();
                        if (resultadoDep != null)
                        {
                            idDepartamento = Convert.ToInt32(resultadoDep);
                        }
                    }

                    if (idDepartamento > 0)
                    {
                        string deleteProjetos = $"DELETE FROM projetos WHERE id_departamento = {idDepartamento}";
                        using (MySqlCommand comandoDeleteProj = new MySqlCommand(deleteProjetos, MysqlConexaoBanco))
                        {
                            comandoDeleteProj.ExecuteNonQuery();
                        }
                    }

                    string deleteFuncionario = $"DELETE FROM funcionarios WHERE id = {Id}";
                    using (MySqlCommand comandoDeleteFunc = new MySqlCommand(deleteFuncionario, MysqlConexaoBanco))
                    {
                        comandoDeleteFunc.ExecuteNonQuery();
                    }

 
                    if (idDepartamento > 0)
                    {
                        string deleteDepartamento = $@"
                    DELETE FROM departamentos 
                    WHERE id = {idDepartamento} 
                    AND NOT EXISTS (
                        SELECT 1 FROM funcionarios WHERE id_departamento = {idDepartamento}
                    )";
                        using (MySqlCommand comandoDeleteDep = new MySqlCommand(deleteDepartamento, MysqlConexaoBanco))
                        {
                            comandoDeleteDep.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - metodo deletarFuncionario: " + ex.Message);
                return false;
            }
        }

    }
}
