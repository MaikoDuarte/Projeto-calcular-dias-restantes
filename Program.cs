Console.WriteLine("Digite o seu nome:");
string nome = Console.ReadLine();

DateTime? dataNascimento = null; 

while (dataNascimento == null)
{
  Console.WriteLine("Digite a data de nascimento no formato (dd/MM/yyyy, ddMMyy ou ddMMyyyy):");
  string dataDeNascimento = Console.ReadLine();

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

DateTime dataCentenaria = dataNascimento.Value.AddYears(100);

TimeSpan tempoRestante = dataCentenaria - DateTime.Now;

int anosRestantes = (int)tempoRestante.TotalDays / 365;
int diasRestantes = (int)tempoRestante.TotalDays % 365;

Console.WriteLine($"Eu, {nome}, estarei vivo até o dia: {dataCentenaria.ToString("dd/MM/yyyy")}");
Console.WriteLine($"Ainda tenho {anosRestantes} anos e {diasRestantes} dias de vida.");



