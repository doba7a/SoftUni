namespace Exercise.Services
{
    using Exercise.Data;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly ExerciseContext context;

        public DatabaseInitializerService(ExerciseContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();
        }
    }
}
