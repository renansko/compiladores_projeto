namespace compiladores
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public class TabelaLexica
        {
            public string Chave;
            public string Valor;
            public TabelaLexica(string chave, string valor)
            {
                Chave = chave;
                Valor = valor;
            }
        }

        public class leitorLexico
        {
            static void Leitor(string[] args)
            {
                string token;
                char[] arr;
                char[] tabela = new char[Array.MaxLength];
                int indexOfStart;

                token = Console.ReadLine(); // usuario escreveu text
                arr = token.ToCharArray();

                indexOfStart = -1;
                for (int t = 0; t < token.Length; t++)
                {
                    if (arr[t].ToString() == "=")
                    {
                        indexOfStart = t;
                    }

                }
                if (indexOfStart == -1)
                {
                    Console.WriteLine("deve se digitar ao menos um = para comecar o programa");
                    Environment.Exit(0);
                }

                for (int i = 0; i < token.Length; i++)
                {
                    if (Char.IsNumber(arr[i]) && Char.IsLetter(arr[i + 1]))
                    {
                        throw new Exception("Formato errado, nao eh possivel ler numero e letra em sequencia");
                    }

                    if (Char.IsNumber(arr[i]) || Char.IsLetter(arr[i]))
                    {
                        if (Char.IsLetter(arr[i]) && Char.IsLetter(arr[i]))
                        {
                            // variavel
                            new TabelaLexica(arr[i].ToString() + arr[i + 1].ToString(), "Constante");
                            continue;
                        }
                        // constante
                        new TabelaLexica(arr[i].ToString() + arr[i + 1].ToString(), "Variavel");
                        continue;
                    }
                    // operador 
                    new TabelaLexica(arr[i].ToString(), "Operador");
                }
                TabelaLexica obj = new TabelaLexica(string.Empty, string.Empty);

                Console.WriteLine("Propriedade            oque eh                 valor");
                foreach (var tab in obj.GetType().GetProperties())
                {
                    Console.WriteLine(tab.Name);
                }


            }



        }

    }
}