using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventsObject : ScriptableObject
{
    List<GameEvent> list = new List<GameEvent>();
    public void ShotRegister(GameEvent item)
    {
        this.list.Add(item);
    }
    public void ShotUnRegister(GameEvent item)
    {
        this.list.Remove(item);
    }
    public void ShotRaise()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            this.list[i].shot.Invoke();
        }
    }
  
    public void DragRaise()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            this.list[i].endDrag.Invoke();
        }
    }
    // Eğer Sürükleme birmiş ve güvenli alnada isek 
    // atışı başlat
    public void DragRaise(bool value)
    {
        if (value)
        {
            this.ShotRaise();
        }
        for (int i = 0; i < this.list.Count; i++)
        {
            this.list[i].endDrag.Invoke();
        }
    }

}
