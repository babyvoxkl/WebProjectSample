using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract(Name = "DemoService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DemoService
    {
        [WebInvoke(Method = "GET"
            , ResponseFormat = WebMessageFormat.Json
            , BodyStyle = WebMessageBodyStyle.Bare
            , UriTemplate = "/")]
        public List<string> GetAll()
        {
            return new List<string>() {"ab","cd", "ef", "gh", "ij", "kl", "mn", "op", "qr", "st", "uv", "wx", "yz" };
        }
    }
}
