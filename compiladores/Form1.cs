using System.Text.RegularExpressions;

namespace compiladores
{


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
            
            char[] arr; // array de char
            int start = 1; //Começo da leitura de string
            string text = ""; // texto para o windowns forms

            if (textBox1.Text == "") // verifica se foi digitado algo na textBox
            {
                MessageBox.Show("é necessario digitar o token!");
                textBox1.Focus();
                return;
            }

            arr = textBox1.Text.ToCharArray(); // resgata o texto da textBox e transforma ele em uma Array de CHAR[]

            if (arr[0].ToString() != "=") // verifica se o texto começa com =
            {
                MessageBox.Show("Deve digitar o = no começo da equação");
                return;
            }
            
            for (int k = 0; k < arr.Length; k++) // percorre todos elementros do array char para achar uma condição
            {
                if(k == arr.Length - 1)
                {
                    continue;
                }
                if (Char.IsNumber(arr[k]) && Char.IsLetter(arr[k + 1])) // caso tenha um numero seguido por uma letra era gerar um erro
                {
                    throw new Exception("Formato errado, nao eh possivel ler numero e letra em sequencia");
                }
     
            for (int i = 1; i < arr.Length; i++) // percorre todos elementos da array Char
            {
                if (Char.IsSymbol(arr[i]) || (!Char.IsDigit(arr[i]) && !Char.IsLetter(arr[i])))// identifica quando existir um sibolo
                {
                    for (int j = start; j < i; j++) // percorre todos elementos entre simbolos
                    {
                        string String = String.Join("", arr[j]);// pega o char e o transforma em um STRING
                        text = text + String; // junta os caracteres em um texto
                    }
                 
                    if (Char.IsLetter(text[0])) // verifica se o primeiro caracter é uma letra
                    {
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Variavel"; // tipo
                        variavel[2] = "Letras"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        start = i+1;
                    }
                        
                    if (Char.IsDigit(text[0])) // verifica se o primeiro caracter é um numero
                    {
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Constante"; // tipo
                        variavel[2] = "Numero"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        start = i +1;
                    }
                        string tipo = verifySimbols(arr[i]); // insere o simbolo na tabela
                        string[] tk = new string[4000];

                        tk[0] = arr[i].ToString(); // valor
                        tk[1] = "Operador"; // tipo
                        tk[2] = tipo; // tipo

                        ListViewItem l = new ListViewItem(tk);
                        listView1.Items.Add(l);
                        start = i + 1;
                        text = "";
                }
            }
        }

        private string verifySimbols(char simbolo) // verifica qual é o simbolo
        { 
            string tipo = string.Empty;
            if(simbolo == '+')
            {
                tipo = "mais";
            }
            if(simbolo.ToString() == "-")
            {
                tipo = "menos";
            }
            if(simbolo.ToString() == "/")
            {
                tipo = "divisao";
            }
            if (simbolo.ToString() == "*")
            {
                tipo = "vezes";
            }
            if (simbolo.ToString() == "(")
            {
                tipo = "parenteses";
            }
            if (simbolo.ToString() == ")")
            {
                tipo = "parenteses";
            }
            tipo = "outros";
            return tipo;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}