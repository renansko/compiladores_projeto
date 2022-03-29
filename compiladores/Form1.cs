namespace compiladores
{

    public class TabelaLexica
    {
        public string Digito;
        public string Valor;
        public TabelaLexica(string chave, string valor)
        {
            Digito = Digito;
            Valor = valor;
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indexOfStart;
            char[] arr;
            int acc = 0;

            if (textBox1.Text == "")
            {
                MessageBox.Show("é necessario digitar o token!");
                textBox1.Focus();
                return;
            }

            arr = textBox1.Text.ToCharArray();
            indexOfStart = -1;
            for (int t = 0; t < textBox1.Text.Length; t++)
            {
                if (arr[t].ToString() == "=")
                {
                    indexOfStart = t;
                }

            }
            if (indexOfStart == -1)
            {
                MessageBox.Show("deve se digitar = para comecar o programa");
                return;
            }

            int[] numero = new int[2], letra = new int[2], simbolo = new int[2];
            char[] valor = new char[2];
            string[] varialvel, constante, operador;

            for(int i = indexOfStart; i < arr.Length; i++)
            {

                if (acc == 2)
                {
                    acc = 0;
                }
                valor[acc] = arr[i];
                
                if (Char.IsNumber(arr[i]))
                {
                    numero[acc] = 1;
                }
                if(Char.IsLetter(arr[i]))
                {
                    letra[acc] = 1;    
                }
                if(Char.IsSymbol(arr[1]))
                {
                    simbolo[acc] = 1;
                }
                if(numero[0] == 1 && letra[1] == 1)
                {
                    throw new Exception("Formato errado, nao eh possivel ler numero e letra em sequencia");
                }
                if (numero[0] == 1 && numero[1] == 1)
                {
                    varialvel = valor[0] + valor[1];
                   // dois numeros -> variavel
                }
                if (letra[0] == 1 && numero[1] == 1)
                {
                    constante = valor[0] + valor[1];
                    // letra seguida por um numero -> constante
                }
                if (simbolo[0] == 1 || simbolo[1] == 1)
                {
                    operador = $"{valor[0]}{valor[1]}";
                    // simbolo -> operador
                    acc = 0;
                }

            }
            string[] tk = new string[int.MaxValue];

            for (int r = 0; r < indexOfStart - arr.Length; r++) { 
            tk[0] = textBox1.Text; // valor
            tk[1] = textBox1.Text; // tipo

            }

            ListViewItem l = new ListViewItem(tk);
            listView1.Items.Add(l);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}