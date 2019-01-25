using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MoniBase64
{
    class Odkodowanie
    {

        char[] tabelaZKodami = new char[64]
    {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};


        public bool Dekoduj(ListBox lb, string sciezka)
        {
            lb.Items.Add("Odkoduj");

            try
            {
                List<bool> bl2 = new List<bool>();
                string[] st = File.ReadAllLines(sciezka);

                string s = "";
                for (int i = 0; i < st.Length; i++)
                {
                    s += st[i];
                }




                //https://mattomatti.com/pl/a35am
                var wynik = new StringBuilder();
                var numerBitu = 0;
                var aktualnyBajt = 0;
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '=')
                    {
                        break;
                    }
                    byte val = (byte)Array.IndexOf(tabelaZKodami, s[i]); //Pozycja w tabeli kodów
                    for (int j = 0; j < 6; j++)
                    {
                        if (((32 >> j) & val) > 0)
                        {
                            aktualnyBajt += 128 >> numerBitu;
                        }

                        if (numerBitu == 7)
                        {
                            wynik.Append((char)aktualnyBajt);
                            aktualnyBajt = 0;
                            numerBitu = 0;
                        }
                        else
                        {
                            numerBitu++;
                        }
                    }
                }






                lb.Items.Add("Odkodowano ");
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
