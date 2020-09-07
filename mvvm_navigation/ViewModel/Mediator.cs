using System;
using System.Collections.Generic;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// Mediates between view models
    /// </summary>
    public static class Mediator
    {
        private static readonly IDictionary<string, List<Action<object>>> actions =
           new Dictionary<string, List<Action<object>>>();

        public static void Subscribe(string token, Action<object> callback)
        {
            if (!actions.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                actions.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in actions[token])
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;
                if (!found)
                    actions[token].Add(callback);
            }
        }

        public static void Unsubscribe(string token, Action<object> callback)
        {
            if (actions.ContainsKey(token))
                actions[token].Remove(callback);
        }

        public static void Notify(string token, object args = null)
        {
            if (actions.ContainsKey(token))
                foreach (var callback in actions[token])
                    callback(args);
        }
    }
}