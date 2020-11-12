
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StartPointData : ScriptableObject
{
    public Vector2 startPosition;
    public Vector2 mousePosition;
    public Vector2 direction;
    /** Nişan alma ileminin başarılı veya başarısız olduğunu bildirir.
    */
    public bool canShot = false;
    [SerializeField]
    private float canShotRange = 1f;
    public float dot = 0;

    private List<StartPointGameEvent> list = new List<StartPointGameEvent>();

    public void changeDirection(Vector2 endPosition)
    {
        this.mousePosition = endPosition;
        direction = (endPosition - startPosition);
        direction.Normalize();
        // direction = startPosition + direction;
        // Debug.DrawLine(this.startPosition, startPosition + direction, Color.red, 1);
        // eğer beilrtilen açıya ulaşılırsa çizgi çizecek
        this.calculateRadius();
    }

    private void calculateRadius()
    {
        // farenin konumunun başlangıç noktasına olan dikliği
        this.dot = Vector2.Dot(-this.direction, Vector2.right);
        // Debug.Log("açı:" + dot);
        // Debug.Log("açı:" + dot + "canShotRange:" + this.canShotRange);
        this.canShot = this.canShotRange >= Math.Abs(this.dot) && this.mousePosition.y > startPosition.y;
        // Debug.Log("Dot:" + this.dot);
        if (canShot)
        {
            this.Raise();
        }
    }

    internal void UnregisterListener(StartPointGameEvent startPointGameEvent)
    {
        this.list.Remove(startPointGameEvent);
    }

    internal void RegisterListener(StartPointGameEvent startPointGameEvent)
    {
        this.list.Add(startPointGameEvent);

    }
    public void Raise()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            this.list[i].OnEventRaised();
        }
    }
    public void setStartPosition(Vector2 value)
    {
        this.startPosition = value;
    }
}
