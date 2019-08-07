using System;
using VCompare.Persistence;
using Xunit;

namespace VCompare.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public VCompareDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = VCompareDbContextFactory.Create();
        }

        public void Dispose()
        {
            VCompareDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}