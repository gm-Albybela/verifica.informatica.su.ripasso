namespace verifica_informatica_su_ripasso
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] abc = { "abcdefghijklmnopqrstuvwxyz" };
        private void p(string phrase)
        {

        }
        private char decifration(char f)
        {
            if (f >= 'A' && f <= 'Z')
            {
                char decifratore = (char)(f - 3);
                if (decifratore < 'a')
                {
                    decifratore = (char)(decifratore - 3);
                }
                return decifratore;
            }
            return f;
        }

        private string decifraPhrase(string frasi)
        {
            char[] rtc = frasi.ToCharArray();

            for (int i = 0; i < rtc.Length; i++)
            {
                rtc[i] = decifration(rtc[i]);
            }
            return frasi;  
        }
        private void load()
        {
            string file = "testo.txt";


            if (File.Exists(file))
            {
                string[] a = new string[file.Length];
                int c = 0;
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string frasi = sr.ReadLine();
                        a[c] = frasi;
                        c++;
                    }
                }
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader("testodec.txt"))
            {

            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
