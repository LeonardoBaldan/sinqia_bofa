using System.Text;

namespace Sinqia.Bofa.Service.Singleton
{
    public class SingletonService
    {
        #region atributes

        private static SingletonService? _instance;
        private static readonly object _lock = new object();

        #endregion

        #region methods

        public IList<SingletonService> CreateInstanceOfSingleton()
        {
            IList<SingletonService> instances = new List<SingletonService>();

            var primaryInstance = Instance;
            var secondaryInstance = Instance;

            instances.Add(primaryInstance);
            instances.Add(secondaryInstance);

            return instances;
        }

        #endregion

        #region properties

        public static SingletonService Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new SingletonService();
                    }
                }
                return _instance;
            }
        }

        #endregion
    }
}
