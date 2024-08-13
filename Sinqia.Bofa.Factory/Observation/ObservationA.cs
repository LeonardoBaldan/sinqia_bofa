using Sinqia.Bofa.Service.Observation.Interface;
using System.Text;

namespace Sinqia.Bofa.Factory.Observation
{
    public class ObservationA : IObservation
    {
        #region methods

        public void Alter(string value, out string Message)
        {
            Message = $"Observation A notification : {value}";
        }

        #endregion
    }
}
