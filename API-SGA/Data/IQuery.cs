namespace API_SGA.Data
{
    public interface IQuery<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);
    }
}
