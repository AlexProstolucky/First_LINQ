namespace First_LINQ.DataAccess
{
    internal interface Repository<T>
    {
        Task<IEnumerable<T?>> GetAllAsync();
    }
}
