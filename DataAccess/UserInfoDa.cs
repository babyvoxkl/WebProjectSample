using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;
using Model.DataModel;

namespace DataAccess
{
    public class UserInfoDa
    {
        private readonly DbAccess _dbAccess;
        public UserInfoDa()
        {
            _dbAccess = new DbAccess(new DemoDbContext());
        }

        public void AddUserInfo(UserInfo userInfo)
        {
            _dbAccess.AddOrUpdateEntity(userInfo,null);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            _dbAccess.AddOrUpdateEntity(userInfo,null);
        }

        public void DeleteUserInfo(int id)
        {
            _dbAccess.DeleteEntity<UserInfo>(delegate(DbSet<UserInfo> set)
            {
                return set.FirstOrDefault(user => user.Id == id);
            }, null);
        }

        public UserInfo GetUserInfo(int id)
        {
            return _dbAccess.GetEntity(delegate(DbSet<UserInfo> set)
            {
                return set.FirstOrDefault(user => user.Id == id);
            }, null);
        }

        public List<UserInfo> GetUserInfoList()
        {
            return _dbAccess.GetEntityList(delegate(DbSet<UserInfo> set) { return set.Where(user=> true).ToList(); }, null);
        } 

    }
}
