using System;

namespace Events
{
    public static class EventTextRockets
    {
        public static event Action<int> EventUpdateRockets;
        
        public static void OnUpdateRockets(int numberRockets)
        {
            EventUpdateRockets?.Invoke(numberRockets);
        }
    }
}