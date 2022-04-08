using ETCP.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace ETCP.EntityFrameworkCore
{
    public class ConnectionStringAttribute : ConnectionStringNameAttribute
    {
        private static readonly string db = AppSettings.EnableDb;

        public ConnectionStringAttribute(string name = "") : base(db)
        {
            Name = string.IsNullOrEmpty(name) ? db : name;
        }

        public new string Name { get; }
    }
}
