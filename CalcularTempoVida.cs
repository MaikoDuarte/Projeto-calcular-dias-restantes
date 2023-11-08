    public class CalcularTempoVida
    {
        private List<Pessoa> pessoas = new List<Pessoa>();

        public void CapturarDadosPessoais()
        {
            int contadorPessoas = 0;

            while (contadorPessoas < 3)
            {
                Console.WriteLine("Digite o seu nome:");
                string nome = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new Exception("O nome não pode ser nulo ou em branco.");
                }

                DateTime dataNascimento = CapturarDataNascimento();

                pessoas.Add(new Pessoa { Nome = nome, DataNascimento = dataNascimento });
                contadorPessoas++;

                ExibirInformacoesVida(nome, dataNascimento);
            }

            EscreverArquivoTexto();
        }

        private DateTime CapturarDataNascimento()
        {
            DateTime? dataNascimento = null;

            while (dataNascimento == null)
            {
                Console.WriteLine("Digite a data de nascimento no formato (dd/MM/yyyy, ddMMyy ou ddMMyyyy):");
                string dataDeNascimento = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(dataDeNascimento))
                {
                    Console.WriteLine("A data de nascimento não pode estar em branco. Tente novamente.");
                    continue;
                }

                if (DateTime.TryParseExact(dataDeNascimento, new[] { "dd/MM/yyyy", "ddMMyy", "ddMMyyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    dataNascimento = data;
                }
                else
                {
                    Console.WriteLine("Formato de data inválido. Tente novamente.");
                }
            }

            return dataNascimento.Value;
        }

        private void ExibirInformacoesVida(string nome, DateTime dataNascimento)
        {
            DateTime dataCentenaria = dataNascimento.AddYears(100);
            TimeSpan tempoRestante = dataCentenaria - DateTime.Now;

            int anosRestantes = (int)tempoRestante.TotalDays / 365;
            int diasRestantes = (int)tempoRestante.TotalDays % 365;

            Console.WriteLine($"Eu, {nome}, estarei vivo(a) até o dia: {dataCentenaria.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ainda tenho {anosRestantes} anos e {diasRestantes} dias de vida.");
        }

        private void EscreverArquivoTexto()
        {
            using (StreamWriter sw = new StreamWriter("dados_pessoais.txt"))
            {
                foreach (var pessoa in pessoas)
                {
                    sw.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }