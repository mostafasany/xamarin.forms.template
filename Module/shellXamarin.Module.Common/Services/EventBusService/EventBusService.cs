using System;
using Prism.Events;

namespace shellXamarin.Module.Common.Services.EventBusService
{
    public class EventBusService : IEventBusService
    {
        private readonly IEventAggregator _eventAggregator;
        public EventBusService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Publish<TEventType, TPayload>(TPayload payload) where TEventType : PubSubEvent<TPayload>, new()
        {
            TEventType pubEvent = _eventAggregator.GetEvent<TEventType>();
            pubEvent.Publish(payload);
        }

        public void Publish<TEventType>() where TEventType : PubSubEvent, new()
        {
            TEventType pubEvent = _eventAggregator.GetEvent<TEventType>();
            pubEvent.Publish();
        }

        public Tuple<TEventType, SubscriptionToken> Subscribe<TEventType>(Action handler) where TEventType : PubSubEvent, new()
        {
            TEventType pubEvent = _eventAggregator.GetEvent<TEventType>();
            SubscriptionToken subscriptionToken = pubEvent.Subscribe(handler);
            return new Tuple<TEventType, SubscriptionToken>(pubEvent, subscriptionToken);
        }

        public Tuple<TEventType, SubscriptionToken> Subscribe<TEventType, TPayload>(Action<TPayload> handler) where TEventType : PubSubEvent<TPayload>, new()
        {
            TEventType pubEvent = _eventAggregator.GetEvent<TEventType>();
            SubscriptionToken subscriptionToken = pubEvent.Subscribe(handler);
            return new Tuple<TEventType, SubscriptionToken>(pubEvent, subscriptionToken);
        }
    }
}
