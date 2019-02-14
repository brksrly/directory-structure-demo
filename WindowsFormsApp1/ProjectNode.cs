using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public enum ProjectNodeType
    {
        Exists,
        Allowed,
        Unexpected,
        File
    }

    public class ProjectNode
    {
        public ProjectNode NextSibling { get; set; }
        public ProjectNode NextDescendant { get; set; }
        public ProjectNode Parent { get; set; }

        public ProjectNodeType Type { get; set; }
        public string Name { get; } 

        public ProjectNode(ProjectNode parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        public ProjectNode(ProjectNode parent, string name, DirectoryInfo dir)
        {
            if (dir.Exists)
                Type = ProjectNodeType.Exists;
            else
                Type = ProjectNodeType.Allowed;
        }

        public ProjectNode(ProjectNode parent, string name, ProjectNodeType type)
        {
            Type = type;
        }

        public void Open() { throw new NotImplementedException();}
        public void Delete() { throw new NotImplementedException(); }
        public void Create() { throw new NotImplementedException(); }
        public void Rename() { throw new NotImplementedException(); }

        internal void SetType(DirectoryInfo dir)
        {

        }

        internal void SetType(ProjectNodeType type)
        {
            Type = type;
        }

        internal TreeNode getTreeNode()
        {
            switch (Type)
            {
                case ProjectNodeType.Exists:
                    return new TreeNode($"[{Type.ToString()}]" + Name);
                case ProjectNodeType.Allowed:
                    return new TreeNode($"[{Type.ToString()}]" + Name);
                case ProjectNodeType.Unexpected:
                    return new TreeNode($"[{Type.ToString()}]" + Name);
                case ProjectNodeType.File:
                    return new TreeNode($"[{Type.ToString()}]" + Name);
                default:
                    return new TreeNode("???");
            } 
        }
    }
}
