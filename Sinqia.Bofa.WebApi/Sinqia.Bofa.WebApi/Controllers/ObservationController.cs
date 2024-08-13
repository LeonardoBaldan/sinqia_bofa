using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Factory.Observation;
using Sinqia.Bofa.Service.Observation;
using Sinqia.Bofa.Service.Observation.Interface;
using Sinqia.Bofa.Service.Validation;
using Sinqia.Bofa.Service.Validation.Interface;
using Sinqia.Bofa.WebApi.Models;

namespace Sinqia.Bofa.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObservationController : ControllerBase
    {
        public ObservationController() { }

        [HttpGet(Name = "Notify")]
        public IActionResult Notify(string obj)
        {
            IObjectToObserve objectToObserve = new ObjectToObserve();

            IObservation observerA = new ObservationA();
            IObservation observerB = new ObservationB();

            objectToObserve.Add(observerA);
            objectToObserve.Add(observerB);
            objectToObserve.Notify("Object to Observe changed");

            switch (obj) 
            {
                case "A":
                    objectToObserve.Delete(observerA);
                    objectToObserve.Notify("The state of object A changed");
                    return Ok(objectToObserve.Message);

                case "B":
                    objectToObserve.Delete(observerB);
                    objectToObserve.Notify("The state of object B changed");
                    return Ok(objectToObserve.Message);
            }
            return BadRequest("No object state to change");
        }
    }
}
