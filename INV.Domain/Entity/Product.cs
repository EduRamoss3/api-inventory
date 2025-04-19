

using INV.Domain.Interfaces;

namespace INV.Domain.Entity
{
    public sealed class Product : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Description { get;  set; }
        public int Quantity { get;  set; }
        public bool Available { get; set; } 
        public decimal Price { get;  set; }

        public  void Attach(IObserver observer)
        {
           _observers.Add(observer);    
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public void SetQuantity(int quant)
        {
            Quantity = quant;
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
