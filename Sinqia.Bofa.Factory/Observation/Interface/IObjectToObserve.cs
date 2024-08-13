namespace Sinqia.Bofa.Service.Observation.Interface
{
    public interface IObjectToObserve
    {
        void Add(IObservation observer);
        void Delete(IObservation observer);
        void Notify(string value);

        string? Message { get; set; }
    }
}
