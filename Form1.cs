using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace ShortCurtSO
{
    public partial class Janela : Form
    {


        Process process = null;

        public Janela()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        void console(String cmd)
        {

            var aux = "";
            var output = "";
            var index = 1;

            List<string> commands = new List<string>(cmd.Split('#'));
           
            foreach (string x in commands)
            {
                aux += x + "&&";
            }

            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/k" + aux + "pause";
            process.Start();

            foreach (string y in commands)
            {
                output += "Command (" + index + ") ->" + y + "\n";
                index++;
            }

            MessageBox.Show("Commands executed >> \n" + output);

            output += "Date: " + DateTime.Now.ToShortDateString() 
                  + "  Hours: " + DateTime.Now.ToShortTimeString();

             EscreveArquivo(output);
        }
           

        private void EscreveArquivo(String text)
        {
            var strPathFile = @"C:\\Users\\" + Environment.UserName + "\\Desktop\\LogShortCurt.txt";


            StreamWriter writer;

            writer = File.AppendText(strPathFile);


            writer.WriteLine(text);

            writer.WriteLine("By user: " + Environment.UserName);

            writer.WriteLine("----------------------------- \n");

            writer.Close();

                            
            MessageBox.Show("Recorded in the log, path: " + strPathFile);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") || textBox1.Text.Contains("Ex")) {
                MessageBox.Show("O campo acima deve ser preenchido");
                return;
            }

            console(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (process != null)
            {
                process.Kill(); 
                MessageBox.Show("Process died with sucess! hehe");
            }
            else
                MessageBox.Show("Dont have process to kill :(");        
        }
    }
}
