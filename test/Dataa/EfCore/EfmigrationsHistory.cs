using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class EfmigrationsHistory
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
