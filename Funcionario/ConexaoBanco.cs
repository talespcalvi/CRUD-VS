using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionario
{
    public class ConexaoBanco
    {
        private const string servidor = "localhost";
        private const string bancoDados = "dbFuncionarios";
        private const string usuario = "root";
        private const string senha = "123456";

        private static ConexaoBanco _instancia;
        private static readonly object _lock = new object();

        public string BancoServidor { get; private set; }

        private ConexaoBanco()
        {
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
