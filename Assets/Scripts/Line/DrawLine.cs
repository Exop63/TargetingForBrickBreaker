using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour
{
    // a pointer for collision point
    public GameObject reflectionPoint;
    public StartPointData startPointData;
    public LineRenderer lineRenderer;

    private RaycastHit2D hit2D;
    private GameObject reflectionIndicator;

    public void setPositions()
    {

        // check can draw line 
        this.hit2D = Physics2D.CircleCast(this.startPointData.startPosition, .4f, this.startPointData.direction, 20);
        // Debug.Log("Positon changeing hit2D:" + this.hit2D);
        if (hit2D)
        {

            if (this.reflectionIndicator == null)
            {
                this.reflectionIndicator = Instantiate<GameObject>(reflectionPoint);
                this.reflectionIndicator.name = "Indicator";
            }
            // two position for line renderer
            Vector3[] positions = new Vector3[2];
            positions[0] = startPointData.startPosition;
            positions[1] = hit2D.centroid;

            lineRenderer.SetPositions(positions);

            this.showIndicator(positions[1]);
            this.Show();
        }
    }


    private void showIndicator(Vector2 position)
    {
        this.reflectionIndicator.gameObject.SetActive(true);
        this.reflectionIndicator.transform.position = position;

    }
    // Show line
    public void Show()
    {
        if (this.reflectionIndicator)
        {
            this.lineRenderer.enabled = this.startPointData.canShot;
            this.reflectionIndicator.SetActive(this.startPointData.canShot);
        }
    }
    // Hide line
    public void Hide()
    {
        // Debug.Log("Hide Line");
        if (this.reflectionIndicator)
        {
            this.lineRenderer.enabled = false;
            this.reflectionIndicator.SetActive(false);
        }
    }
    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(startPointData.startPosition, this.startPointData.startPosition + startPointData.direction * 5);
    }
}
