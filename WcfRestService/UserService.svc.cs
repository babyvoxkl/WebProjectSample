using System;
using System.ServiceModel.Web;
using System.Web;
using BizLogic;
using Model.DataModel;
using Model.ServiceModel;

namespace WcfRstService
{
    public class UserService : IUserService
    {
        public void AddUserInfo(UserInfo userInfo)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            if (ctx != null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                try
                {
                    UserInfoBl bl = new UserInfoBl();
                    bl.AddUserInfo(userInfo);
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                    ctx.OutgoingResponse.StatusDescription = ex.Message;
                }
            }
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            if (ctx != null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                try
                {
                    UserInfoBl bl = new UserInfoBl();
                    bl.AddUserInfo(userInfo);
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Accepted;
                }
                catch (Exception ex)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                    ctx.OutgoingResponse.StatusDescription = ex.Message;
                }
            }
        }

        public void DeleteUserInfo(string id)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            if (ctx != null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                try
                {
                    int intId;
                    if (int.TryParse(id,out intId))
                    {
                        UserInfoBl bl = new UserInfoBl();
                        bl.DeleteUserInfo(intId);
                    
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Accepted;
                    }
                    else
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                        ctx.OutgoingResponse.StatusDescription = "用户ID不是数字";
                    }
                }
                catch (Exception ex)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                    ctx.OutgoingResponse.StatusDescription = ex.Message;
                }
            }
        }

        public GetUserInfoResult GetUserInfoById(string id)
        {
            GetUserInfoResult result = new GetUserInfoResult();
            try
            {
                int intId;
                if (int.TryParse(id, out intId))
                {
                    UserInfoBl bl = new UserInfoBl();
                    result.UserInfo = bl.GetUserInfo(intId);
                    result.ErrorCode = 1;
                    result.ErrorMessage = "用户获取成功";
                }
                else
                {
                    result.ErrorCode = 0;
                    result.ErrorMessage = "用户ID不是数字";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public GetUserInfoListResult GetUserInfoList()
        {
            GetUserInfoListResult result = new GetUserInfoListResult();

            try
            {
                UserInfoBl bl = new UserInfoBl();
                result.UserInfoList = bl.GetUserinfoList();
                result.ErrorCode = 1;
                result.ErrorMessage = "用户列表获取成功";
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
