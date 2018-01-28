using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionRenderer : MonoBehaviour {

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    public void SetPositions(Vector3 startPos, Vector3 endPos)
    {
        this.SetStartPos(startPos);
        this.SetEndPos(endPos);
    }

    public void SetStartPos(Vector3 startPos)
    {
        lineRenderer.SetPosition(0, startPos);
    }

    public void SetEndPos(Vector3 endPos)
    {
        lineRenderer.SetPosition(1, endPos);
    }

    public void SetColor(Color color)
    {
        this.SetColors(color, color);
    }

    public void SetColors(Color startColor, Color endColor)
    {
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }
}
