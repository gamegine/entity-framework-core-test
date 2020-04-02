using Microsoft.EntityFrameworkCore;

namespace entity_framework_core_test.Data
{
    public class TestBddContext : DbContext
    {
        /// <summary>
        /// default contructor
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public TestBddContext(DbContextOptions<TestBddContext> options) : base(options)
        {
        }
        /// <summary>
        /// constructor used by mock
        /// </summary>
        public TestBddContext() : base()
        {
        }
        public virtual DbSet<Models.A> A { get; set; }
    }
}
