using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet03 : PlanetSC
{
    void Start()
    {
        planetID = 3;
        base.Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet3")
        {
            collisionStart = Time.time;
            otherObject = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet3")
        {
            collisionStart = -0.5f;
            otherObject = null;
        }
    }
}
