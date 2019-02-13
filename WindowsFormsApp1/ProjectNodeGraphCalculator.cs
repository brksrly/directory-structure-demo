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

        private readonly XmlDocument SchemaDocument;
        private readonly DirectoryInfo BaseProjectDirectory;

        public ProjectNodeGraphCalculator(string baseDirectoryPath)
        {
            SchemaDocument = LoadSchemaDocument(CONFIG_FILE_PATH);
            BaseProjectDirectory = new DirectoryInfo(baseDirectoryPath);
        }

        private XmlDocument LoadSchemaDocument(string configFilePath)
        {
            XmlDocument schemaConfig = new XmlDocument();
            schemaConfig.Load(configFilePath);
            return schemaConfig;
        }

        public ProjectNode generateProjectNodeGraph()
        {

            ProjectNode rootProjectNode = new ProjectNode(null, BaseProjectDirectory.FullName);         
            rootProjectNode.SetType(BaseProjectDirectory);

            XmlElement rootSchemaElement = SchemaDocument.DocumentElement;

            ProjectNode lastSibling = null;

            foreach (XmlNode schemaNode in rootSchemaElement.ChildNodes)
            {
                ProjectNode projectNode = new ProjectNode(rootProjectNode, schemaNode.Attributes["name"].Value);
                DirectoryInfo dir = new DirectoryInfo(BaseProjectDirectory.FullName + Path.DirectorySeparatorChar + projectNode.Name);
                projectNode.SetType(dir);

                lastSibling = SetGraphRelations(rootProjectNode, lastSibling, projectNode);
                AddDescendantProjectNodes(projectNode, schemaNode, dir);
            }

            foreach (var directory in BaseProjectDirectory.GetDirectories())
            {
                if (!IsPartOfSchema(directory, rootSchemaElement))
                {
                    ProjectNode projectNode = new ProjectNode(rootProjectNode, directory.Name);
                    projectNode.SetType(ProjectNodeType.Unexpected);
                    AddDescendantProjectNodes(projectNode, null, directory);

                    lastSibling = SetGraphRelations(rootProjectNode, lastSibling, projectNode);
                }
            }

            foreach (var file in BaseProjectDirectory.GetFiles())
            {
                ProjectNode projectNode = new ProjectNode(rootProjectNode, file.Name);
                projectNode.SetType(ProjectNodeType.File);

                lastSibling = lastSibling = SetGraphRelations(rootProjectNode, lastSibling, projectNode);

            }

            return rootProjectNode;
        }

        private void AddDescendantProjectNodes(ProjectNode parent, XmlNode parentSchemaNode, DirectoryInfo parentDirectory)
        {
            ProjectNode lastSibling = null;

            if (parentSchemaNode != null)
            {
                foreach (XmlNode schemaNode in parentSchemaNode.ChildNodes)
                {
                    ProjectNode projectNode = new ProjectNode(parent, schemaNode.Attributes["name"].Value);
                    DirectoryInfo dir = new DirectoryInfo(parentDirectory.FullName + Path.DirectorySeparatorChar + projectNode.Name);
                    projectNode.SetType(dir);

                    lastSibling = SetGraphRelations(parent, lastSibling, projectNode);
                    AddDescendantProjectNodes(projectNode, schemaNode, dir);
                }
            }

            if (parentDirectory.Exists)
            {
                foreach (var directory in parentDirectory.GetDirectories())
                {
                    if (!IsPartOfSchema(directory, parentSchemaNode))
                    {
                        ProjectNode projectNode = new ProjectNode(parent, directory.Name);
                        projectNode.SetType(ProjectNodeType.Unexpected);
                        AddDescendantProjectNodes(projectNode, null, directory);

                        lastSibling = SetGraphRelations(parent, lastSibling, projectNode);
                    }
                }

                foreach (var file in parentDirectory.GetFiles())
                {
                    ProjectNode projectNode = new ProjectNode(parent, file.Name);
                    projectNode.SetType(ProjectNodeType.File);

                    lastSibling = lastSibling = SetGraphRelations(parent, lastSibling, projectNode);

                }
            }
        }

        private static ProjectNode SetGraphRelations(ProjectNode parent, ProjectNode lastSibling, ProjectNode projectNode)
        {
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
