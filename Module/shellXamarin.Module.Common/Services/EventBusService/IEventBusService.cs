using System;
using Prism.Events;

namespace shellXamarin.Module.Common.Services.EventBusService
{
    public interface IEventBusService
    {
        void Publish<TEventType, TPayload>(TPayload payload) where TEventType : PubSubEvent<TPayload>, new();
        void Publish<TEventType>() where TEventType : PubSubEvent, new();
        Tuple<TEventType, SubscriptionToken> Subscribe<TEventType, TPayload>(Action<TPayload> handler) where TEventType : PubSubEvent<TPayload>, new();
        Tuple<TEventType, SubscriptionToken> Subscribe<TEventType>(Action handler) where TEventType : PubSubEvent, new();
    }
}
