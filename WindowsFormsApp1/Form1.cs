using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFolderDialogBrowser.ShowDialog() == DialogResult.OK)
            {
                pathTextBox1.Text = openFolderDialogBrowser.SelectedPath;
                ProjectNodeGraphCalculator pngc = new ProjectNodeGraphCalculator(openFolderDialogBrowser.SelectedPath);
                ProjectNode root = pngc.generateProjectNodeGraph();

                Console.WriteLine(root.Name);

            }
        }
    }
}
