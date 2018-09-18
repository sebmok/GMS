using System.Data.Entity;

namespace MultitenantServer2016.CORE
{
    public class MultiTenantContextInitializer :
  CreateDatabaseIfNotExists<MultiTenantContext>
    {
        protected override void Seed(MultiTenantContext context)
        {

        }
    }
}