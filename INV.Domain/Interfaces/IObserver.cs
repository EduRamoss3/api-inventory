namespace INV.Domain.Interfaces
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
