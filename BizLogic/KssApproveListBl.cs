using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace BizLogic
{
    public class KssApproveListBl
    {
        private readonly GetApproveListDa _dataAccess;

        public KssApproveListBl()
        {
            _dataAccess = new GetApproveListDa();
        }

        public GetApproveListResponse GetApproveList(GetApproveListRequest request)
        {
            DateTime startDate;
            DateTime endDate;
            int approveStatus;
            GetApproveListResponse response = new GetApproveListResponse();

            if (!DateTime.TryParse(request.StartTime,out startDate))
            {
                response.ResultCode = -1;
                response.ResultMessage = "开始时间格式错误！";
            }

            if (!DateTime.TryParse(request.EndTime, out endDate))
            {
                response.ResultCode = -1;
                response.ResultMessage = "结束时间格式错误！";
            }

            if (!int.TryParse(request.ApproveStatus,out approveStatus))
            {
                response.ResultCode = -1;
                response.ResultMessage = "审批状态条件错误！";
            }

            response.Apply = _dataAccess.GetApproveList(request.DoctorCode, request.DoctorRole,
                request.ExamineStatus, startDate, endDate, request.DeptName, request.AdminNo, approveStatus);
            response.TotalRow = response.Apply.Count;
            response.ResultCode = 0;
            response.ResultMessage = "查询成功";
            return response;
        }
    }
}
