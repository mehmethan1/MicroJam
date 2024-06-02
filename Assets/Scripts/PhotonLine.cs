using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLine : MonoBehaviour
{
    LineRenderer rend;
    EdgeCollider2D col;

    public List<Vector2> linePoints = new List<Vector2>();
    private void Start()
    {
        rend = FindObjectOfType<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        linePoints[0] = rend.GetPosition(0);
        linePoints[1] = rend.GetPosition(1);
        col.SetPoints(linePoints);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy Öldü");
        }
    }
}
