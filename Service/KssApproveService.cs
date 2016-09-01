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

        public GetApproveListResponse GetApproveListService(GetApproveListRequest request)
        {
            GetApproveListResponse response = new GetApproveListResponse()
            {
                Apply = new List<KssApply>()
            };

            response.Apply.Add(new KssApply()
            {
                ApplyNo = "T1"
            });

            return response;
        }
    }
}
