namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ContractDraft.pdf");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ProjectTimelies.docx");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("contracts", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("invoiceData");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("invoice", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Project Manage", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("issued");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("note");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Engineering", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Construction");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Dick Pics");
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mockTreeView1 = new System.Windows.Forms.TreeView();
            this.openButton = new System.Windows.Forms.Button();
            this.pathTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFolderDialogBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStripFile.SuspendLayout();
            this.contextMenuStripDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStripFile.Name = "ContractMenuStrip2";
            this.contextMenuStripFile.Size = new System.Drawing.Size(150, 40);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 36);
            this.toolStripMenuItem1.Text = "Open";
            // 
            // contextMenuStripDirectory
            // 
            this.contextMenuStripDirectory.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemCreate,
            this.toolStripMenuItemRename});
            this.contextMenuStripDirectory.Name = "contextMenuStrip1";
            this.contextMenuStripDirectory.Size = new System.Drawing.Size(177, 148);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(176, 36);
            this.toolStripMenuItemOpen.Text = "Open";
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(176, 36);
            this.toolStripMenuItemDelete.Text = "Delete";
            // 
            // toolStripMenuItemCreate
            // 
            this.toolStripMenuItemCreate.Enabled = false;
            this.toolStripMenuItemCreate.Name = "toolStripMenuItemCreate";
            this.toolStripMenuItemCreate.Size = new System.Drawing.Size(176, 36);
            this.toolStripMenuItemCreate.Text = "Create";
            // 
            // toolStripMenuItemRename
            // 
            this.toolStripMenuItemRename.Name = "toolStripMenuItemRename";
            this.toolStripMenuItemRename.Size = new System.Drawing.Size(176, 36);
            this.toolStripMenuItemRename.Text = "Rename";
            // 
            // mockTreeView1
            // 
            this.mockTreeView1.Location = new System.Drawing.Point(-1, 88);
            this.mockTreeView1.Name = "mockTreeView1";
            treeNode1.ContextMenuStrip = this.contextMenuStripFile;
            treeNode1.Name = "Node8";
            treeNode1.Text = "ContractDraft.pdf";
            treeNode2.Name = "Node9";
            treeNode2.Text = "ProjectTimelies.docx";
            treeNode3.Name = "contracts";
            treeNode3.Text = "contracts";
            treeNode4.Name = "Node10";
            treeNode4.Text = "invoiceData";
            treeNode5.Name = "Invoice";
            treeNode5.Text = "invoice";
            treeNode6.Name = "Project Manage";
            treeNode6.Text = "Project Manage";
            treeNode7.Name = "issued";
            treeNode7.Text = "issued";
            treeNode8.Name = "note";
            treeNode8.Text = "note";
            treeNode9.Name = "Engineering";
            treeNode9.Text = "Engineering";
            treeNode10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            treeNode10.Name = "Construction";
            treeNode10.Text = "Construction";
            treeNode11.ContextMenuStrip = this.contextMenuStripDirectory;
            treeNode11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            treeNode11.Name = "Dick Pics";
            treeNode11.Text = "Dick Pics";
            this.mockTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode10,
            treeNode11});
            this.mockTreeView1.Size = new System.Drawing.Size(1163, 787);
            this.mockTreeView1.TabIndex = 0;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(1021, 20);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(141, 39);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pathTextBox1
            // 
            this.pathTextBox1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pathTextBox1.Location = new System.Drawing.Point(158, 20);
            this.pathTextBox1.Name = "pathTextBox1";
            this.pathTextBox1.Size = new System.Drawing.Size(848, 31);
            this.pathTextBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Project Root:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 875);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox1);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.mockTreeView1);
            this.Name = "Form1";
            this.Text = "Project Structure Navigator";
            this.contextMenuStripFile.ResumeLayout(false);
            this.contextMenuStripDirectory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView mockTreeView1;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDirectory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreate;
        private System.Windows.Forms.TextBox pathTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRename;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog openFolderDialogBrowser;
    }
}

