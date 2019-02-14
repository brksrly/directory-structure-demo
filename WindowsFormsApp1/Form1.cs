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
            if(openFolderDialogBrowser.ShowDialog() == DialogResult.OK)
            {
                pathTextBox1.Text = openFolderDialogBrowser.SelectedPath;
                ProjectNodeGraphCalculator pngc = new ProjectNodeGraphCalculator(openFolderDialogBrowser.SelectedPath);
                TreeViewGenerator tvg = new TreeViewGenerator(pngc);
                tvg.generateTreeView(treeView);
            }
        }


        //Mock of Setting a Tag in the Context Menu Strip
        //This will where inject the ProjectNode to delgate commands to
        private void contextMenuStripDirectory_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStripDirectory.Tag = "Brooks Text";
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            ContextMenuStrip tagged = (sender as ToolStripMenuItem).Owner as ContextMenuStrip;
            Console.WriteLine(tagged.Tag.ToString());
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {

        }

    }
}
