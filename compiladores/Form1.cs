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
            int acc = 1;
            string text = "";

            if (textBox1.Text == "")
            {
                MessageBox.Show("é necessario digitar o token!");
                textBox1.Focus();
                return;
            }

            arr = textBox1.Text.ToCharArray();

            if (arr[0].ToString() != "=")
            {
                MessageBox.Show("Deve digitar o = no começo da equação");
                return;
            }

            char[] numero = new char[100], letra = new char[100], simbolo = new char[100];
            char[] valor = new char[200];
            int valorDigito = 0;

            for (int k = 0; k < arr.Length; k++)
            {
                if (Char.IsNumber(arr[k]) && Char.IsLetter(arr[k + 1]))
                {
                    throw new Exception("Formato errado, nao eh possivel ler numero e letra em sequencia");
                }
            }
            for (int i = 1; i < arr.Length; i++)
            {

                if (Char.IsSymbol(arr[i]) || (!Char.IsDigit(arr[i]) && !Char.IsLetter(arr[i])))
                {
                    for (int j = i -1; j >= acc; j--)
                    {
                        letra[j] = arr[j];
                        string String = String.Join("", letra[j]);
                        // transformar os caracteres novamente em uma string
                        // a string está vindo do ultimo ao primeiro [4],[3],[2],...
                        //atribuir a variavel text;
                        String result = "";
                        result = result + String;


                        valorDigito++;
                    }

                    // vai ler a variavel text e ver qual o primeiro digito, caso letra  variavel caso numero constante
                    if (Char.IsLetter(text[0]))
                    {
                                              
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Variavel"; // tipo
                        variavel[2] = "Operador"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        acc = i;
                    }
                        
                    if (Char.IsDigit(text[0]))
                    {
                        string[] variavel = new string[4000];

                        variavel[0] = text; // token
                        variavel[1] = "Variavel"; // tipo
                        variavel[2] = "Operador"; // valor

                        ListViewItem v = new ListViewItem(variavel);
                        listView1.Items.Add(v);
                        acc = i;
                    }
                        string[] tk = new string[4000];

                        tk[0] = arr[i].ToString(); // valor
                        tk[1] = "Operador"; // tipo
                        tk[2] = "Operador"; // tipo

                        ListViewItem l = new ListViewItem(tk);
                        listView1.Items.Add(l);
                        acc = i;
                }

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}