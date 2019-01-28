using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MonikaWebCrawler
{
    class Program
    {
        static string CzytajLinie(NetworkStream ns)
        {

            StringBuilder sb = new StringBuilder();
            int r = 0, or = 0;
            while (r != 10 && or != 13)
            {
                or = r;
                r = ns.ReadByte();
                if (r != -1)
                {
                    sb.Append((char)r);
                    System.Console.Write((char)r);
                }
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        static string PobierzStrone(string adres)
        {
            Regex rx = new Regex(@"^(http\://)?([a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3})(/\S*)?$", RegexOptions.IgnoreCase);

            var host = rx.Match(adres).Groups[2].Value;
            var patch = rx.Match(adres).Groups[3].Value;
            if (patch == "") patch = "/";
            string polecenie = "GET " + patch + " HTTP/1.0\r\n" +
                            "Host: " + host + "\r\n" +
                            "Accept: text/html\r\n" +
                            "Cache-Control: no-cache\r\n\r\n\r\n";

            var tcp = new TcpClient();
            tcp.Connect(host, 80);
            var ns = tcp.GetStream();

            byte[] tmp = Encoding.ASCII.GetBytes(polecenie);
            ns.Write(tmp, 0, tmp.Length);
            string html;
            int dlugosc = 0;
            while ((html = CzytajLinie(ns)) != "")
            {
                if (html.StartsWith("Content-Length: "))
                {
                    dlugosc = int.Parse(html.Substring(16));
                }
            }

            byte[] dane = new byte[dlugosc];
            ns.Read(dane, 0, dlugosc);

            return System.Text.Encoding.ASCII.GetString(dane);
        }

        static bool SprawdzAdresStrony(string adresStrony)
        {
            Regex rx = new Regex(@"^(http\://)?([a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3})(/\S*)?$", RegexOptions.IgnoreCase); // regex sprawdza czy to jest http i tak dalej
            return rx.Match(adresStrony).Success;// sprawdzamy czy pasuje
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Write("zła liczba parametrów");
                return;
            }

            string adresStrony = args[0];
            int Glebokosc = int.Parse(args[1]);

           if(!SprawdzAdresStrony(adresStrony))
            {
                Console.Write("błędny adres");
                return;
            }

            List<string> strony = new List<string>();
            List<string> obrazy = new List<string>();

            var strona = PobierzStrone(adresStrony);
            var aRegex = new Regex(@"<a\s+.*href\s*=\s*""([^""]*)""", RegexOptions.IgnoreCase);
            foreach (Match match in aRegex.Matches(strona))
            {
                strony.Add(match.Groups[1].Value);
            }

            var imgRegex = new Regex(@"<img\s+.*src\s*=\s*""([^""]*)""", RegexOptions.IgnoreCase);
            foreach (Match match in imgRegex.Matches(strona))
            {
                obrazy.Add(match.Groups[1].Value);
            }

            XmlDocument xml = new XmlDocument();
            var site = xml.CreateElement("Site");
            xml.AppendChild(site);
            var page = xml.CreateAttribute("url");
            page.Value = adresStrony;
            site.Attributes.Append(page);
            foreach (var adres in strony)
            {
                if (adres.EndsWith(".html", StringComparison.OrdinalIgnoreCase) || adres.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                {
                    var element = xml.CreateElement("File");
                    var atrybut = xml.CreateAttribute("name");
                    atrybut.Value = adres;
                    element.Attributes.Append(atrybut);
                    site.AppendChild(element);
                }
                else if (adres.Contains("@"))
                {
                    var element = xml.CreateElement("Email");
                    var atrybut = xml.CreateAttribute("name");
                    atrybut.Value = adres;
                    element.Attributes.Append(atrybut);
                    site.AppendChild(element);
                }
            }

            foreach (var adres in obrazy)
            {
                var element = xml.CreateElement("IMAGE");
                var atrybut = xml.CreateAttribute("name");
                atrybut.Value = adres;
                element.Attributes.Append(atrybut);
                site.AppendChild(element);
            }

            var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            xml.Save(System.IO.Path.Combine(desktopDir, DateTime.Now.ToString("MM-DD-YY HH.mm.ss") + ".xml"));
        }
    }
}
