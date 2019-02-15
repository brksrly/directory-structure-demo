using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class TreeViewGenerator
    {
        private ProjectNodeGraphCalculator _pngc;
        Dictionary<ProjectNode, TreeNode> _projectTreeMap = new Dictionary<ProjectNode, TreeNode>();

        public TreeViewGenerator(ProjectNodeGraphCalculator pngc)
        {
            _pngc = pngc;
            _projectTreeMap = new Dictionary<ProjectNode, TreeNode>();
        }

        internal void generateTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();

            foreach (int lvl in _pngc._M.Keys.Reverse())
            {
                if (lvl == 0)
                    continue;
                foreach (ProjectNode node in _pngc._M[lvl])
                    GetOrCreate(node);
            }

            List<TreeNode> LvlOneNodes = _pngc._M[1].ConvertAll(new Converter<ProjectNode, TreeNode>(GetOrCreate));
            treeView.Nodes.AddRange(LvlOneNodes.ToArray());

        }

        private TreeNode GetOrCreate(ProjectNode projectNode)
        {
            if (_projectTreeMap.ContainsKey(projectNode))
                return _projectTreeMap[projectNode];

            List<TreeNode> descendants = new List<TreeNode>();
            if (projectNode.NextDescendant != null)
            {
                List<ProjectNode> children = projectNode.NextDescendant.getAllSiblings();
                descendants = children.ConvertAll(new Converter<ProjectNode, TreeNode>(GetOrCreate));
            }

            TreeNode treeNode = CreateTreeNodeWithContext(projectNode, descendants);
            _projectTreeMap.Add(projectNode, treeNode);
            return treeNode;
        }

        private TreeNode CreateTreeNodeWithContext(ProjectNode projectNode, List<TreeNode> descendants)
        {
            TreeNode treeNode = new TreeNode(projectNode.Name, descendants.ToArray());
            SetTreeNodeSyling(treeNode, projectNode);

            ContextMenuStrip cms = new ContextMenuStrip();

            cms.Tag = projectNode;
            cms.SuspendLayout();
            cms.ImageScalingSize = new System.Drawing.Size(32, 32);
            cms.Items.AddRange(CreateToolStripItems(projectNode));
            cms.Size = new System.Drawing.Size(181, 114);
            cms.ResumeLayout(false);

            treeNode.ContextMenuStrip = cms;

            return treeNode;
        }

        private void SetTreeNodeSyling(TreeNode treeNode, ProjectNode projectNode)
        {
            // Todo: There *must* be an more obvious/clear way to describe coloe
            switch (projectNode.Type)
            {
                case ProjectNodeType.Allowed:
                    treeNode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
                    break;
                case ProjectNodeType.Unexpected:
                    treeNode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
                    break;
                default:
                    break;
            }
        }

        private ToolStripItem[] CreateToolStripItems(ProjectNode projectNode)
        {
            //Todo: Filter allowable actions by ProjectNode
            //Todo: Event Handlers
            ToolStripMenuItem toolStripMenuItemOpen = new ToolStripMenuItem("Open");
            ToolStripMenuItem toolStripMenuItemDelete = new ToolStripMenuItem("Delete");
            ToolStripMenuItem toolStripMenuItemCreate = new ToolStripMenuItem("Create");
            ToolStripMenuItem toolStripMenuItemRename = new ToolStripMenuItem("Rename");
            return new ToolStripItem[] 
            {   toolStripMenuItemOpen,
                toolStripMenuItemDelete,
                toolStripMenuItemCreate,
                toolStripMenuItemRename
            };
        }
    }
}
