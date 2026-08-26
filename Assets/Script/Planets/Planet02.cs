using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet02 : PlanetSC
{
    void Start()
    {
        planetID = 2;
        base.Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet2")
        {
            collisionStart = Time.time;
            otherObject = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet2")
        {
            collisionStart = -0.5f;
            otherObject = null;
        }
    }
}
