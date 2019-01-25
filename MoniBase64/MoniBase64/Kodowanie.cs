using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MoniBase64
{
    class Kodowanie
    {

        char[] tabelaZKodami = new char[64]
            {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};


        public bool Koduj(ListBox lb, string sciezka)
        {
            lb.Items.Add("Zakoduj ");
            try
            {
                FileStream fs = new System.IO.FileStream(sciezka, FileMode.Open);
                byte[] bytes = new byte[fs.Length];
                fs.Position = 0;
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();
                var wynik = new StringBuilder();

                for (int z = 0; z < bytes.Length; z += 3)
                {
                    var binary = new byte[3] { 0, 0, 0 };

                    for (int i = 0; i < 3; i++)
                    {
                        if (z + i < bytes.Length)
                        {
                            binary[i] = bytes[z + i];
                        }
                    }
                    for (var i = 0; i < 4; i++) // kolejne znaki
                    {
                        var suma = 0;
                        for (var j = 0; j < 6; j++) //bit w znaku
                        {
                            //10100
                            //000001
                            //000000

                            //10100
                            //00100
                            //00100

                            var poz = i * 6 + j; //pozycja bitu w 24
                            var wybranyByte = poz / 8; //Który byte z tych 3
                            var wybranyBit = poz % 8; //Który bit w tym bajcie
                            byte maska = (byte)(128 >> wybranyBit);
                            if ((binary[wybranyByte] & maska) > 0)
                            {
                                suma += (byte)Math.Pow(2, 5 - j);
                            }
                        }

                        wynik.Append(tabelaZKodami[suma]);
                    }


                }

                if (bytes.Length % 3 > 0)
                {
                    wynik[wynik.Length - 1] = '=';
                    if (bytes.Length % 3 == 1)
                    {
                        wynik[wynik.Length - 2] = '=';
                    }
                }




                lb.Items.Add("Wynik:");
                lb.Items.Add(wynik.ToString());
                return true;
            }
            catch (Exception ex)
            {
                lb.Items.Add("BŁĄD: " + ex);
                return false;
            }
        }
    }
}
