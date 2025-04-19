

using INV.Data.Interfaces;

namespace INV.Data.Observer
{
    internal class Subject : ISubject
    {
        public int States { get; set; } = -0;
        public List<IObserver> _observers = new List<IObserver>();  

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
