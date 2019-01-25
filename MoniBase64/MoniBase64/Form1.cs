using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MoniBase64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PrzyciskDoKodowania_Click(object sender, EventArgs e)
        {
            OpenFileDialog okienko = new OpenFileDialog();
            if (okienko.ShowDialog() == DialogResult.OK)
            {
                string sciezka = okienko.FileName;
                FileInfo F = new FileInfo(sciezka);
                if (F.Exists)
                {
                    Kodowanie k = new Kodowanie();
                    k.Koduj(listBox1, sciezka);
                }
            }
        }


    

    private void PrzyciskDoOdkodowania_Click(object sender, EventArgs e)
        {
            OpenFileDialog okienko = new OpenFileDialog();
            if (okienko.ShowDialog() == DialogResult.OK)
            {
                string sciezka = okienko.FileName;
                FileInfo F = new FileInfo(sciezka);
                if (F.Exists)
                {
                    Odkodowanie d = new Odkodowanie();
                    d.Dekoduj(listBox1, sciezka);


                }
            }
        }
    }
}
