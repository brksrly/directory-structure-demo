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
        public int Lvl { get; }

        public ProjectNodeType Type { get; set; }
        public string Name { get; }


        public ProjectNode(ProjectNode parent, string name, DirectoryInfo dir)
        {
            if (dir.Exists)
                Type = ProjectNodeType.Exists;
            else
                Type = ProjectNodeType.Allowed;

            Name = name;
            if (parent == null)
                Lvl = 0;
            else
                Lvl = parent.Lvl + 1;
        }

        public ProjectNode(ProjectNode parent, string name, ProjectNodeType type)
        {
            Type = type;
            //todo Code Duplication. How the eff do base constructors work in C#?
            Name = name;
            if (parent == null)
                Lvl = 0;
            else
                Lvl = parent.Lvl + 1;
        }

        public List<ProjectNode> getAllSiblings()
        {
            // Special Case for root node
            if (Parent == null)
                return new List<ProjectNode>() { this };

            List<ProjectNode> result = new List<ProjectNode>();
            ProjectNode sibling = Parent.NextDescendant;
            while (sibling !=null)
            {
                result.Add(sibling);
                sibling = sibling.NextSibling;
            }
            return result;

        }

        // Hooks to write the actual functionality
        public void Open() { throw new NotImplementedException();}
        public void Delete() { throw new NotImplementedException(); }
        public void Create() { throw new NotImplementedException(); }
        public void Rename() { throw new NotImplementedException(); }

        internal void SetType(ProjectNodeType type)
        {
            Type = type;
        }
    }
}
