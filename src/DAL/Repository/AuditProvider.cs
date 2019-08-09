using Audit.SqlServer.Providers;
using ViewModel.Enumerations;

namespace DAL.Repository
{
    public class AuditProvider : SqlDataProvider
    {
        public AuditProvider()
        {
            ConnectionString = ConfigurationEnum.BaseConnAudit;
            Schema = "dbo";
            TableName = "Event";
            IdColumnName = "EventId";
            JsonColumnName = "Data";
            LastUpdatedDateColumnName = "LastUpdatedDate";
        }
    }
}
