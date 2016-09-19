using System.Data.Common;
using System.Data.Entity;
using Model.DataModel;

namespace Model
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
            : base("name=DemoDbConnString")
        {
        }

        public DemoDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <summary>
        /// 抗生素审批列表
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}