namespace INV.Data.Interfaces
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
