using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public float debugDrawRadius = 1.0f;
    public Color _color = Color.blue;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}
