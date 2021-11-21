using System;

namespace Events
{
    public static class EventsMouse
    {
        public static event Action EventChangeMousePosition;

        public static void OnChangeMousePosition()
        {
            EventChangeMousePosition?.Invoke();
        }
    }
}