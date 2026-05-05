namespace ConnectionsLibrary
{
    public interface IDatabaseConnectionStringProvider
    {
        string GetConnectionString();

        bool HasConnection();
    }
}
