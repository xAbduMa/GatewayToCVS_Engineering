namespace BaseLibrary
{
    public interface IDatabaseConnectionStringProvider
    {
        string GetConnectionString();

        bool HasConnection();
    }
}
