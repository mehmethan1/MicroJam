using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject AnotherGun;
    void Update()
    {
        Vector2 lookDir = AnotherGun.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (angle > -180 && angle < -90)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else if (angle > 90 && angle < 180)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }
    }
}
