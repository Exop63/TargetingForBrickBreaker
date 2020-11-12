using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public StartPointData startPointData;
    public GameEventsObject gameEventsObject;

    void Update()
    {
        startPointData.setStartPosition(this.transform.position);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Farenin şuanki world Konumu:" + currentPosition);
            this.startPointData.changeDirection(currentPosition);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.gameEventsObject.DragRaise(this.startPointData.canShot);
        }
    }
}
