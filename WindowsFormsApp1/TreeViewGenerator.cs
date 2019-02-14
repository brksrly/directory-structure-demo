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
                {
                    List<ProjectNode> children = null;
                    if (node.NextDescendant != null)
                    {
                        children = node.NextDescendant.getAllSiblings();
                        List<TreeNode> descendants = children.ConvertAll(new Converter<ProjectNode, TreeNode>(getTreeNodeFromProjectNode));
                        TreeNode t = new TreeNode(node.Name, descendants.ToArray());
                        _projectTreeMap.Add(node, t);
                    }
                    else
                    {
                        TreeNode t = new TreeNode(node.Name);
                        _projectTreeMap.Add(node, t);
                    }
                }
            }
            List<TreeNode> LvlOneNodes =_pngc._M[1].ConvertAll(new Converter<ProjectNode, TreeNode>(getTreeNodeFromProjectNode));
            treeView.Nodes.AddRange(LvlOneNodes.ToArray());
 
        }

        private TreeNode getTreeNodeFromProjectNode(ProjectNode input)
        {
            return _projectTreeMap[input];
        }
    }
}
