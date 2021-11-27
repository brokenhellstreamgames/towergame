using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform ShootPosition;

    public List<LineRenderer> Lines;
    
    // Start is called before the first frame update
    void Start()
    {
        Lines = new List<LineRenderer>();
        for(int i=0; i<3; i++)
        {
            GameObject lrObj = new GameObject();
            LineRenderer lineRenderer = lrObj.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Standard"));
            lineRenderer.positionCount = 0;
            lineRenderer.widthMultiplier = 0.1f;
            lineRenderer.transform.SetParent(transform);
            lineRenderer.gameObject.SetActive(false);
            Lines.Add(lineRenderer);
        }
    }

    public void LookTarget(Entity target)
    {
        ShootPosition.LookAt(target.transform);
    }

    public void Launch(List<Entity> targets)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            Entity e = targets[i];
            LineRenderer lr = Lines[i];
            lr.positionCount = 100;
            for (int j = 0; j < lr.positionCount; j++)
            {
                Vector3 p = DOCurve.CubicBezier.GetPointOnSegment(transform.position, transform.parent.position,
                    e.TargetManager.transform.position, e.transform.position, j*1f/lr.positionCount);
                lr.SetPosition(j, p);
            }
            lr.gameObject.SetActive(true);
        }
    }

    public void Erase()
    {
        foreach (LineRenderer line in Lines)
        {
            line.positionCount = 0;
            line.gameObject.SetActive(false);
        }
    }
}
