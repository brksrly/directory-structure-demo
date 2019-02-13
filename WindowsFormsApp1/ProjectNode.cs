using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Open() { throw new NotImplementedException();}
        public void Delete() { throw new NotImplementedException(); }
        public void Create() { throw new NotImplementedException(); }
        public void Rename() { throw new NotImplementedException(); }

        internal void SetType(DirectoryInfo rootDirectoryInfo)
        {
            if (rootDirectoryInfo.Exists)
                Type = ProjectNodeType.Exists;
            else
                Type = ProjectNodeType.Allowed;
        }

        internal void SetType(ProjectNodeType type)
        {
            Type = type;
        }
    }
}
