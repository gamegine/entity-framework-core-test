using Microsoft.EntityFrameworkCore;

namespace entity_framework_core_test.Data
{
    public class TestBddContext : DbContext
    {
        public TestBddContext(DbContextOptions<TestBddContext> options) : base(options)
        {
        }

        public virtual DbSet<Models.A> A { get; set; }
    }
}
