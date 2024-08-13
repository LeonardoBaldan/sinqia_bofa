using Sinqia.Bofa.Service.Observation;
using Sinqia.Bofa.Service.Observation.Interface;

namespace Sinqia.Bofa.UnitTests
{
    public class ObservationUnitTest
    {
        [Fact]
        public void Observer_Receive_Notification()
        {
            // Arrange
            var objectToObserve = new ObjectToObserve();
            var observer = new MockObserver();

            objectToObserve.Add(observer);

            // Act
            objectToObserve.Notify("Test message");

            // Assert
            Assert.True(observer.WasNotified);
            Assert.Equal("Test message", observer.NotifiedMessage);
        }

        [Fact]
        public void Observer_Receive_NotificationNo_After_Delete()
        {
            // Arrange
            var objectToObserve = new ObjectToObserve();
            var observer = new MockObserver();

            objectToObserve.Add(observer);
            objectToObserve.Delete(observer);

            // Act
            objectToObserve.Notify("Test message");

            // Assert
            Assert.False(observer.WasNotified);
        }

        private class MockObserver : IObservation
        {
            public bool WasNotified { get; private set; }
            public string? NotifiedMessage { get; private set; }

            private string message = string.Empty;

            public void Alter(string value, out string message)
            {
                WasNotified = true;
                NotifiedMessage = message = value;
            }
        }
    }
}
