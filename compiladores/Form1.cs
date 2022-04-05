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
            char[] arr;
            int start = 1;
            string text = "";

            if (textBox1.Text == "")
            {
                MessageBox.Show("� necessario digitar o token!");
                textBox1.Focus();
                return;
            }

            arr = textBox1.Text.ToCharArray();
            Array myArray = Array.CreateInstance(typeof(string), arr.Length);

            if (arr[0].ToString() != "=")
            {
                MessageBox.Show("Deve digitar o = no come�o da equa��o");
                return;
            }
            
            for (int k = 0; k < arr.Length; k++)
            {
                if(k == arr.Length - 1)
                {
                    continue;
                }
                if (Char.IsNumber(arr[k]) && Char.IsLetter(arr[k + 1]))
                {
                    throw new Exception("Formato errado, nao eh possivel ler numero e letra em sequencia");
                }
            }

            for (int i = 1; i < arr.Length; i++)
            {
                if (Char.IsSymbol(arr[i]) || (!Char.IsDigit(arr[i]) && !Char.IsLetter(arr[i])))
                {
                    for (int j = start; j < i; j++)
                    {
                        string String = String.Join("", arr[j]);
                        myArray.SetValue(String, j-1);
         
                        text = text + myArray.GetValue(j-1).ToString();
                    }
                 
                    if (Char.IsLetter(text[0]))
                    {
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Variavel"; // tipo
                        variavel[2] = "Letras"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        start = i+1;
                    }
                        
                    if (Char.IsDigit(text[0]))
                    {
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Constante"; // tipo
                        variavel[2] = "Numero"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        start = i +1;
                    }
                        string tipo = verifySimbols(arr[i]);
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

        private string verifySimbols(char simbolo)
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