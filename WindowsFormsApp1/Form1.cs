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
                pngc.generateProjectNodeGraph();

                treeView.Nodes.Clear();

            }
        }

        private TreeNode getTreeViewNode(ProjectNode node)
        {
            TreeNode treeNode = node.getTreeNode();
    
            if (node.NextDescendant != null)
                treeNode.Nodes.Add(getTreeViewNode(node.NextDescendant));
            if (node.NextSibling != null)
                treeNode.Nodes.Insert(0, getTreeViewNode(node.NextSibling));

            return treeNode;
        }
    }
}
