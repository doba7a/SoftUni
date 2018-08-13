namespace Exercise.Data
{
    using Microsoft.EntityFrameworkCore;

    using Exercise.Data.EntityConfig;
    using Exercise.Models;

    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions options)
            : base(options)
        {
        }

        public ExerciseContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}
