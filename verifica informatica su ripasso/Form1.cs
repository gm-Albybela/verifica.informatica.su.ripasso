namespace verifica_informatica_su_ripasso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] a;          // tutte le parole lette dal file
        string[] decifrate;  // solo le parole decifrate (posizioni pari)

        // decifra una lettera: 3 posizioni indietro
        private char decifration(char f)
        {
            char d = (char)(f - 3);
            if (d < 'A')
            {
                d = (char)(d + 26);   // A -> X, B -> Y, C -> Z
            }
            return d;
        }

        // BOTTONE 1: legge il file e memorizza le parole nell'array
        private void button1_Click(object sender, EventArgs e)
        {
            string file = "testo.txt";

            if (File.Exists(file))
            {
                a = File.ReadAllLines(file);
                MessageBox.Show("File caricato: " + a.Length + " parole");
            }
            else
            {
                MessageBox.Show("File non trovato");
            }
        }

        // BOTTONE 2: decifra le parole in posizione pari e le mostra nella ListBox
        private void button2_Click(object sender, EventArgs e)
        {
            if (a == null)
            {
                MessageBox.Show("Prima carica il file");
                return;
            }

            listBox1.Items.Clear();
            decifrate = new string[a.Length / 2];

            // posizioni pari (2ª, 4ª, ...) = indici 1, 3, 5, ...
            for (int i = 1; i < a.Length; i += 2)
            {
                string parola = "";

                // decifro una lettera alla volta
                for (int j = 0; j < a[i].Length; j++)
                {
                    parola += decifration(a[i][j]);
                }

                decifrate[i / 2] = parola;
                listBox1.Items.Add(parola);
            }
        }

        // BOTTONE 3: salva le parole decifrate nel nuovo file
        private void button3_Click(object sender, EventArgs e)
        {
            if (decifrate == null)
            {
                MessageBox.Show("Prima decifra le parole");
                return;
            }

            using (StreamWriter sw = new StreamWriter("testodec.txt"))
            {
                for (int i = 0; i < decifrate.Length; i++)
                {
                    sw.WriteLine(decifrate[i]);
                }
            }

            MessageBox.Show("File salvato");
        }
    }
}
