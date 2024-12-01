using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace Funcionario
{
    public class ConexaoBanco
    {
        private static ConexaoBanco _instancia;
        private static readonly object _lock = new object();

        public string BancoServidor { get; private set; }

        private ConexaoBanco()
        {
            // Carrega as variáveis do arquivo .env
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.env");
            DotNetEnv.Env.Load(envPath);

            // Obtém os valores das variáveis de ambiente
            string servidor = Environment.GetEnvironmentVariable("DB_SERVIDOR") ?? "localhost";
            string bancoDados = Environment.GetEnvironmentVariable("DB_BANCO") ?? "dbFuncionarios";
            string usuario = Environment.GetEnvironmentVariable("DB_USUARIO") ?? "root";
            string senha = Environment.GetEnvironmentVariable("DB_SENHA") ?? "123456";

            BancoServidor = $"server={servidor}; user id={usuario}; database={bancoDados}; password={senha}";
        }

        public static ConexaoBanco Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new ConexaoBanco();
                        }
                    }
                }
                return _instancia;
            }
        }
    }
}
