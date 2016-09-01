using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Model;

namespace Service
{
    [AspNetCompatibilityRequirements(RequirementsMode =
       AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]

    public class KssApproveService : IKssApproveService
    {
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
