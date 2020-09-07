using System;

namespace mvvm_navigation.ViewModel
{
    public interface IMediator
    {
        void Notify(string token, object args = null);
        void Subscribe(string token, Action<object> callback);
        void Unsubscribe(string token, Action<object> callback);
    }
}