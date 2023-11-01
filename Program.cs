try
{
    Dictionary<string, DateTime> dadosPessoais = new Dictionary<string, DateTime>();
    int contadorPessoas = 0;

  
    while (contadorPessoas < 3)
    {
        Console.WriteLine("Digite o seu nome:");
        string nome = Console.ReadLine()!;
        
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome não pode ser nulo ou em branco. Tente novamente.");
            continue; // Volta a pedir o nome
        }

        DateTime? dataNascimento = null;

        while (dataNascimento == null)
        {
            Console.WriteLine("Digite a data de nascimento no formato (dd/MM/yyyy, ddMMyy ou ddMMyyyy):");
            string dataDeNascimento = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(dataDeNascimento))
            {
                Console.WriteLine("A data de nascimento não pode estar em branco. Tente novamente.");
                continue; // Volta a pedir a data de nascimento
            }

            if (DateTime.TryParseExact(dataDeNascimento, new[] { "dd/MM/yyyy", "ddMMyy", "ddMMyyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                dataNascimento = data; // Define a data de nascimento se a análise for bem-sucedida
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Tente novamente.");
            }
        }

        dadosPessoais.Add(nome, dataNascimento.Value);
         contadorPessoas++;

        DateTime dataCentenaria = dataNascimento.Value.AddYears(100);

        TimeSpan tempoRestante = dataCentenaria - DateTime.Now;

        int anosRestantes = (int)tempoRestante.TotalDays / 365;
        int diasRestantes = (int)tempoRestante.TotalDays % 365;

        Console.WriteLine($"Eu, {nome}, estarei vivo até o dia: {dataCentenaria.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Ainda tenho {anosRestantes} anos e {diasRestantes} dias de vida.");
    }
    using (StreamWriter sw = new StreamWriter("dados_pessoais.txt"))
    {
      foreach(var pessoa in dadosPessoais)
      {
        sw.WriteLine($"Nome: {pessoa.Key}, {pessoa.Value.ToString("dd/MM/yyyy")}");
      }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um Erro: {ex.Message}");
}
