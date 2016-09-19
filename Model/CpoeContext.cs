using System.Data.Common;
using System.Data.Entity;

namespace Model
{
    public class CpoeContext : DbContext
    {
        public CpoeContext()
            : base("name=CPOEDBConnString")
        {
        }

        public CpoeContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <summary>
        /// 抗生素审批列表
        /// </summary>
        public DbSet<GetApproveListResponse> GetApproveListResponse { get; set; }
    }
}