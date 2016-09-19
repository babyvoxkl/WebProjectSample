using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Common;
using log4net;
using Model;
using Service.Interface;

namespace Service
{
    [AspNetCompatibilityRequirements(RequirementsMode =
       AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]

    public class KssApproveService : IKssApproveService
    {
        private static readonly ILog Logs = LogHelper.GetInstance();

        public List<string> GetApproveListService()
        {
            return new List<string>() {"11", "22", "33", "44", "55", "66", "77", "88", "99"};
        }
    }
}
