using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Exop.Targeter
{
    [RequireComponent(typeof(LineRenderer))]
    public class DrawLine : MonoBehaviour
    {
        // a pointer for collision point
        [Header("Reflection point sprite")]
        public GameObject reflectionPoint;
        public StartPointData startPointData;
        private LineRenderer lineRenderer;

        private RaycastHit2D hit2D;
        private GameObject reflectionIndicator;

        private void Awake()
        {
            if (lineRenderer == null)
            {
                this.lineRenderer = this.GetComponent<LineRenderer>();
            }
        }
        public void setPositions()
        {

            // check can draw line 
            this.hit2D = Physics2D.CircleCast(this.startPointData.startPosition, .4f, this.startPointData.direction, 20);
            // Debug.Log("Positon changeing hit2D:" + this.hit2D);
            if (hit2D)
            {
                // two position for line renderer
                Vector3[] positions = new Vector3[2];

                positions[0] = startPointData.startPosition;
                positions[1] = hit2D.centroid;

                lineRenderer.SetPositions(positions);

                this.ShowLine();
                this.showIndicator();
            }
        }


        private void showIndicator()
        {
            if (reflectionPoint)
            {
                if (this.reflectionIndicator == null)
                {
                    this.reflectionIndicator = Instantiate<GameObject>(reflectionPoint);
                    this.reflectionIndicator.name = "Indicator";
                }
            }
            else return;

            this.reflectionIndicator.SetActive(this.startPointData.canShot);
            this.reflectionIndicator.transform.position = this.lineRenderer.GetPosition(1);

        }
        // Show line
        public void ShowLine()
        {
            this.lineRenderer.enabled = this.startPointData.canShot;

        }
        // Hide line
        public void Hide()
        {
            // Debug.Log("Hide Line");
            this.lineRenderer.enabled = false;
            if (this.reflectionIndicator)
            {
                this.reflectionIndicator.SetActive(false);
            }
        }
    }
}