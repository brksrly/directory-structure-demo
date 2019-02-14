using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    class ProjectNodeGraphCalculator
    {
        private static string CONFIG_FILE_PATH = "../../config/ProjectDirectorySchema.xml";

        private readonly XmlDocument _SchemaDocument;
        private readonly DirectoryInfo _Dir;

        private ProjectNode _R;
        private XmlElement _Sch;

        public ProjectNodeGraphCalculator(string baseDirectoryPath)
        {
            _SchemaDocument = LoadSchemaDocument(CONFIG_FILE_PATH);
            _Dir = new DirectoryInfo(baseDirectoryPath);
        }

        private XmlDocument LoadSchemaDocument(string configFilePath)
        {
            XmlDocument schemaConfig = new XmlDocument();
            schemaConfig.Load(configFilePath);
            return schemaConfig;
        }

        public void generateProjectNodeGraph()
        {
            _R = new ProjectNode(null, _Dir.FullName, ProjectNodeType.Exists);         
            _Sch = _SchemaDocument.DocumentElement;

            ProjectNode last = null;   

            foreach (XmlNode schemaNode in _Sch.ChildNodes)
            {
                string name = schemaNode.Attributes["name"].Value;
                DirectoryInfo dir = new DirectoryInfo(_R.Name + Path.DirectorySeparatorChar + name);
                ProjectNode projectNode = new ProjectNode(_R, name, dir);
                last = SetGraphRelations(_R, last, projectNode);
                AddDescendantProjectNodes(projectNode, schemaNode, dir);
            }

            foreach (var dir in _Dir.GetDirectories())
            {
                if (!IsPartOfSchema(dir, _Sch))
                {
                    ProjectNode projectNode = new ProjectNode(_R, dir.Name, ProjectNodeType.Unexpected);
                    last = SetGraphRelations(_R, last, projectNode);
                    AddDescendantProjectNodes(projectNode, null, dir);

                }
            }

            foreach (var file in _Dir.GetFiles())
            {
                ProjectNode projectNode = new ProjectNode(_R, file.Name,ProjectNodeType.File);
                last = SetGraphRelations(_R, last, projectNode);
            }
        }


        private void AddDescendantProjectNodes(ProjectNode parent, XmlNode parentSchemaNode, DirectoryInfo parentDirectory)
        {
            ProjectNode last = null;

            if (parentSchemaNode != null)
            {
                ///assert(parent.Type == ProjectNodeType.Unexpected);
                foreach (XmlNode schemaNode in parentSchemaNode.ChildNodes)
                {
                    string name = schemaNode.Attributes["name"].Value;
                    DirectoryInfo dir = new DirectoryInfo(parentDirectory.FullName + Path.DirectorySeparatorChar + name);
                    ProjectNode projectNode = new ProjectNode(parent, name, dir);
                    last = SetGraphRelations(parent, last, projectNode);
                    AddDescendantProjectNodes(projectNode, schemaNode, dir);
                }
            }

            if (parentDirectory.Exists)
            {
                foreach (var dir in parentDirectory.GetDirectories())
                {
                    if (!IsPartOfSchema(dir, parentSchemaNode))
                    {
                        ProjectNode projectNode = new ProjectNode(parent, dir.Name, ProjectNodeType.Unexpected);
                        last = SetGraphRelations(parent, last, projectNode);
                        AddDescendantProjectNodes(projectNode, null, dir);
                    }
                }

                foreach (var file in parentDirectory.GetFiles())
                {
                    ProjectNode projectNode = new ProjectNode(parent, file.Name, ProjectNodeType.File);
                    last = SetGraphRelations(parent, last, projectNode);

                }
            }
        }

        private static ProjectNode SetGraphRelations(ProjectNode parent, ProjectNode lastSibling, ProjectNode projectNode)
        {
            //We can actually get parent from project node
            if (parent.NextDescendant == null)
                parent.NextDescendant = projectNode;

            if (lastSibling != null)
                lastSibling.NextSibling = projectNode;

            return projectNode;
        }

        private bool IsPartOfSchema(DirectoryInfo directory, XmlNode schemaInfo)
        {
            if (schemaInfo == null)
                return false;
            foreach (XmlNode schemaChild in schemaInfo.ChildNodes)
                if (schemaChild.Attributes["name"].Value == directory.Name)
                    return true;
            return false;
        }
    }
}
