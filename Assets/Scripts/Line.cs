    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer rend;
    EdgeCollider2D col;
    public int rendnumber;

    public List<Vector2> linePoints = new List<Vector2>();
    void Start()
    {
        rend = FindObjectOfType<LineRenderer>();
    }

    void Update()
    {
        rend.SetPosition(rendnumber, transform.position);
    }
}