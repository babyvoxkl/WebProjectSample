using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public class GetApproveListDa
    {
        private readonly DbAccess _dbAccess;

        public GetApproveListDa()
        {
            _dbAccess = new DbAccess(new CpoeContext());
        }

        public List<KssApply> GetApproveList(string doctorCode, string doctorRole, string examineStatus,
            DateTime startDate, DateTime endDate, string deptName, string adminNo, int approveStatus)
        {
            StringBuilder sbSql = new StringBuilder();
            ArrayList parameters = new ArrayList();

            sbSql.Append(
                "SELECT DISTINCT ka.ApplyID AS ApplyNo,ka.AdmitNo AS PaientNo,ka.PatientsName AS PaientName,ka.BedNo AS PaientBedNo,(CASE WHEN ka.[Status] = 0 THEN '待审批' WHEN ka.[Status] = 1 THEN '通过' WHEN ka.[Status] = 2 THEN '未通过' END) AS ApplyState,(SELECT Name FROM [HISDB.Ward] WHERE Code = ka.WardCode) AS PaientAreaName,ka.WardCode AS PaientAreaCode,ka.ApplyItemCode AS SpecialDrugCode,ka.ApplyItemName AS SpecialDrugName,ka.ApplyTime,m.OrderID AS DrugNo,ka.ApplyUserName AS ApplyOperate,ka.ExamineTime AS ExamineTime,ka.ExpertNo AS ExpertNo,ka.ExpertName AS ExpertName,ka.Detail,CASE m.NeedKSSApprove WHEN 3 THEN '围术预防' ELSE '治疗' END AS KssPurpose ");
            sbSql.Append("FROM KSS_ApplyList AS ka ");
            sbSql.Append("INNER JOIN OrdersMain AS m ON ka.ApplyOrderCode = m.OrderID ");
            sbSql.Append("INNER JOIN MasterData..EmployeeInfo AS ei ON ka.ApplyUserCode = ei.Emp_Code COLLATE SQL_Latin1_General_CP1_CI_AS OR ka.ApplyUserCode = ei.HISCode COLLATE SQL_Latin1_General_CP1_CI_AS");
            sbSql.Append("INNER JOIN MasterData..EmployeeInfo_OrgList AS eo ON ei.Emp_Code = eo.Emp_Code COLLATE SQL_Latin1_General_CP1_CI_AS WHERE ");

            if (examineStatus == "0")
            {
                sbSql.Append("m.NeedKSSApprove > 1 AND ka.Status = 0 ");
            }
            else if (examineStatus == "1")
            {
                sbSql.Append("m.NeedKSSApprove <> 1 AND ka.Status > 0 ");
                if (approveStatus != -1)
                {
                    sbSql.Append("AND  ka.Status = @ApproveStatus");
                    parameters.Add(new SqlParameter("@ApproveStatus", approveStatus));
                }
            }
            else if (examineStatus == "2")
            {
                sbSql.Append("m.NeedKSSApprove = 1 AND ka.Status = 1 ");
            }

            sbSql.Append("AND (ka.ApplyTime BETWEEN @StartTime AND @EndTime) ");
            parameters.Add(new SqlParameter("@StartTime", startDate));
            parameters.Add(new SqlParameter("@EndTime", endDate));

            if (doctorRole != "A1" && doctorRole != "A2")
            {
                sbSql.Append("AND eo.OrgCode IN (SELECT OrgCode COLLATE SQL_Latin1_General_CP1_CI_AS FROM EmployeeInfo_OrgList WHERE Emp_Code = @DoctorCode) ");
                parameters.Add(new SqlParameter("@DoctorCode", doctorCode));

            }

            if (!string.IsNullOrWhiteSpace(deptName))
            {
                sbSql.Append("AND eo.OrgName LIKE '%'+ @DeptName +'%' ");
                parameters.Add(new SqlParameter("@DeptName", deptName));
            }

            if (!string.IsNullOrWhiteSpace(adminNo))
            {
                sbSql.Append("AND ka.AdmitNo  LIKE @AdminNo+'%' ");
                parameters.Add(new SqlParameter("@AdminNo", adminNo));
            }


            List<KssApply> kssApplieList = _dbAccess.GetEntityListBySql<KssApply>(sbSql.ToString(), null, parameters.ToArray());

            return kssApplieList;
        }
    }
}
