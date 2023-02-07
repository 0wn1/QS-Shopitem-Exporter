using System.Xml;

namespace ReadXMLFile
{
    internal class xmlTextReader : XmlTextReader
    {
        private object value;

        public xmlTextReader(object value)
        {
            this.value = value;
        }
    }
}