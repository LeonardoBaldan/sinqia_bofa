using Sinqia.Bofa.Service.Observation.Interface;

namespace Sinqia.Bofa.Factory.Observation
{
    public class ObservationB : IObservation
    {
        #region methods

        public void Alter(string value, out string Message)
        {
            Message = $"Observation B notification : {value}";
        }

        #endregion
    }
}
