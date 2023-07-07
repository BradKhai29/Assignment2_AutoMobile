namespace MyStoreWinApp.Utility
{
    public interface ISessionService
    {
        IDictionary<string, object> Session { get; }

        void AddSessionData<T>(string key, T value);
        void DeleteSessionData(string key);
        T GetSessionData<T>(string key);
    }

    public class SessionService : ISessionService
    {
        private static ISessionService instance;
        private static readonly object lockInstance = new object();
        public static ISessionService Instance
        {
            get
            {
                lock (lockInstance)
                {
                    return instance ??= new SessionService();
                }
            }
        }

        private SessionService() { Session = new Dictionary<string, object>(); }

        public IDictionary<string, object> Session { get; }

        public void AddSessionData<T>(string key, T value)
        {
            bool containKey = Session.ContainsKey(key);
            if (containKey) Session[key] = value;
            else Session.Add(key, value);
        }

        public void DeleteSessionData(string key)
        {
            Session.Remove(key);
        }

        public T GetSessionData<T>(string key)
        {
            if (Session.ContainsKey(key)) return (T) Session[key];

            return default;
        }
    }

    public static class SessionId
    {
        public const string LoginMember = nameof(LoginMember);
        public const string OrderCart = nameof(OrderCart);
    }
}
