using Sinqia.Bofa.Service.Observation.Interface;

namespace Sinqia.Bofa.Service.Observation
{
    public class ObjectToObserve : IObjectToObserve
    {
        #region attributes

        private readonly IList<IObservation> _observers = new List<IObservation>();
        public string? Message { get; set; }

        #endregion

        #region methods

        public void Add(IObservation observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }
        public void Delete(IObservation observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string value)
        {
            string message = string.Empty;
            foreach(var item in _observers)
                item.Alter(value, out message);

            Message = message;
        }

        #endregion
    }
}
