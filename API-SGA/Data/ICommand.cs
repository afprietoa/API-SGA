namespace API_SGA.Data
{
    public interface ICommand<T>
    {
        public Task Post(T obj);

        public Task Put(T obj);

        public Task Delete(T obj);
    }
}
