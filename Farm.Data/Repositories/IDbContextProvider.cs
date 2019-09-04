namespace Farm.Data.Repositories
{
    public interface IDbContextProvider<TDbContext>where TDbContext : MainContext
    {
        TDbContext DbContext { get; }
    }
}