namespace PovarCRM.Models.Interfaces
{
    public interface ICopyable<T>
    {
        public void Copy(T other);
    }
}