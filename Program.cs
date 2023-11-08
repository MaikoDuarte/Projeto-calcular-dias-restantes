    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CalcularTempoVida manipulador = new CalcularTempoVida();
                manipulador.CapturarDadosPessoais();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um Erro: {ex.Message}");
            }
        }
    }