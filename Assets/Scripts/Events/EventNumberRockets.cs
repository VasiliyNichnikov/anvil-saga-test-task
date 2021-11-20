using System;

namespace Events
{
    public static class EventNumberRockets
    {
        public static event Action<bool> EventUpdateNumberRockets;

        public static void OnUpdateNumberRockets(bool subtract=false)
        {
            EventUpdateNumberRockets?.Invoke(subtract);
        }
    }
}