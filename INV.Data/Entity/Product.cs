

using INV.Data.Interfaces;

namespace INV.Data.Entity
{
    public sealed class Product : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public int Id { get; set; }
        public string? Name { get; private set; }    
        public string? Description { get; private set; }
        public int Quantity { get; private set; } = 0;
        public bool Available { get; set; } 
        public decimal Price { get; private set; }

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
