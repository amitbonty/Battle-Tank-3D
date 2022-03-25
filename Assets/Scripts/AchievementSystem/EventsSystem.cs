using System;

public class EventsSystem : Singleton<EventsSystem>
{
    public Action OnBulletsFired;
}
