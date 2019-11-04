using Prism.Events;

namespace shellXamarin.Module.Common.Events
{
    public class LoginEvent : PubSubEvent<UserLoginEvent>
    {
    }

    public class UserLoginEvent
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
