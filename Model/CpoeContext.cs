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


    }
}