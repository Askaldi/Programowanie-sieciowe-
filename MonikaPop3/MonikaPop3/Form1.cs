using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace MonikaPop3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = ConfigurationManager.AppSettings["Server"];
            user = ConfigurationManager.AppSettings["User"];
            pass = ConfigurationManager.AppSettings["Password"];

        }

        string server, user, pass;
        NetworkStream ns;


        private bool popsend(string com, out string msg)
        {
            Debug.WriteLine(com);
            byte[] tmp = Encoding.ASCII.GetBytes(com + "\r\n");
            ns.Write(tmp, 0, tmp.Length);
            string r = (new StreamReader(ns)).ReadLine();
            Debug.WriteLine(r);
            if (r.StartsWith("+OK"))
            {
                msg = r.Substring(3).Trim();
                return true;
            }
            else
            {
                msg = r;
                return false;
            }
        }

        int lastCount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            string msg;
            var tcp = new TcpClient();
            tcp.Connect(server, 110);
            ns = tcp.GetStream();
            Debug.WriteLine((new StreamReader(ns)).ReadLine());
            if (!popsend("USER " + user, out msg))
                throw new Exception("Error Connection");

            if (!popsend("PASS " + pass, out msg))
                throw new Exception("Wrong Password or User");
            if (popsend("STAT", out msg))
            {
                msg = msg.Substring(0, msg.IndexOf(' '));
                var count = int.Parse(msg);
                if (lastCount < count)
                {
                    MessageBox.Show("Dostalas " + (count - lastCount) + " wiadomosci.");
                    lastCount = count;
                }
            }

        }
    }
}
