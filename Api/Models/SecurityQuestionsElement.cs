using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class SecurityQuestionsElement : IXMLElement
    {
        public bool HasSecurityQuestions;
        public bool ShowSecurityQuestionsDialog;

        public List<string> SecurityQuestionsKeys;

        public void Read(XElement element)
        {
            HasSecurityQuestions = element.GetBool("HasSecurityQuestions");
            ShowSecurityQuestionsDialog = element.GetBool("ShowSecurityQuestionsDialog");

            SecurityQuestionsKeys = new List<string>();

            foreach (XElement key in element.Element("SecurityQuestionsKeys").Elements("SecurityQuestionsKey"))
                SecurityQuestionsKeys.Add(key.Value);
        }
    }
}
