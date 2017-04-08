using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var po = new ParallelOptions {MaxDegreeOfParallelism = 8};
            const string path = @"D:\dismc.log";

            Parallel.ForEach(File.ReadAllLines(path), po, s =>
            {
                rtbLog.BeginInvoke(new MethodInvoker(() =>
                {
                    write(s);
                }));
            });

        }

        private void write(string text)
        {
            rtbLog.AppendText(text+Environment.NewLine);
        }
    }
}
