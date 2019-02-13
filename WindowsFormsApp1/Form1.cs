﻿using System;
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
        private static string CONFIG_FILE = "../../config/ProjectDirectorySchema.xml";
        private static XmlDocument schemaConfig;
        public Form1()
        {
            InitializeComponent();
            loadProjectDirectoryStructure(CONFIG_FILE);
        }

        private void loadProjectDirectoryStructure(string CONFIG_FILE)
        {
            schemaConfig = new XmlDocument();
            schemaConfig.Load(@CONFIG_FILE);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFolderDialogBrowser.ShowDialog() == DialogResult.OK)
            {
                pathTextBox1.Text = openFolderDialogBrowser.SelectedPath;
                populateTreeList(openFolderDialogBrowser.SelectedPath);
            }
        }

        private void populateTreeList(string path)
        {
            mockTreeView1.Nodes.Clear();

            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(path);
            XmlElement rootSchemaInfo = schemaConfig.DocumentElement;

            // Valid exists/not exists loop
            foreach (XmlNode currSchemaChild in rootSchemaInfo.ChildNodes)
            {
                String schemaPath = currSchemaChild.Attributes["name"].Value;
                DirectoryInfo currDirctoryChild = new DirectoryInfo(rootDirectoryInfo.FullName + Path.DirectorySeparatorChar + schemaPath);
                mockTreeView1.Nodes.Add(CreateDirectoryNode(currDirctoryChild, currSchemaChild));
            }

            // Invalid Loop
            foreach (var directory in rootDirectoryInfo.GetDirectories())
            {
                if (!isPartOfSchema(directory, rootSchemaInfo))
                    mockTreeView1.Nodes.Add(CreateDirectoryNode(directory, null));
            }

        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo, XmlNode schemaInfo)
        {
            TreeNode directoryNode = getCurrentTreeNode(directoryInfo, schemaInfo);
            // Valid exists/not exists loop
            if (schemaInfo != null)
            {
                foreach (XmlNode schemaChild in schemaInfo.ChildNodes)
                {
                    String schemaPath = schemaChild.Attributes["name"].Value;
                    DirectoryInfo currDirctoryChild = new DirectoryInfo(directoryInfo.FullName + Path.DirectorySeparatorChar + schemaPath);
                    directoryNode.Nodes.Add(CreateDirectoryNode(currDirctoryChild, schemaChild));
                }
            }
            // Invalid Loop
            if (directoryInfo.Exists)
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    if (!isPartOfSchema(directory, schemaInfo))
                        directoryNode.Nodes.Add(CreateDirectoryNode(directory, null));
                }
                foreach (var file in directoryInfo.GetFiles())
                    directoryNode.Nodes.Add(new TreeNode("[File]" + file.Name));
            }
            return directoryNode;

        }

        private bool isPartOfSchema(DirectoryInfo directory, XmlNode schemaInfo)
        {
            if (schemaInfo == null)
                return false;
            foreach (XmlNode schemaChild in schemaInfo.ChildNodes)
                if (schemaChild.Attributes["name"].Value == directory.Name)
                    return true;
            return false;
        }

        private TreeNode getCurrentTreeNode(DirectoryInfo directoryInfo, XmlNode schemaInfo)
        {
            if (schemaInfo != null && directoryInfo.Exists)
                return new TreeNode("[Exists and Valid]" + directoryInfo.Name);
            else if (schemaInfo == null && directoryInfo.Exists)
                return new TreeNode("[Exists but Invalid]" + directoryInfo.Name);
            else if (schemaInfo != null && !directoryInfo.Exists)
                return new TreeNode("[DNE]" + schemaInfo.Attributes["name"].Value);
            else
                throw new InvalidDataException("Unknown state");
        }
    }
}