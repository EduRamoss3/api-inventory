

namespace INV.Data.Results
{
    public sealed class ResultServices
    {
        public bool HasError { get; set; }  
        public string Message { get; set; }
        public object _Entity { get; set; }
    }
}
