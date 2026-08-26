using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet11 : PlanetSC
{
    void Start()
    {
        planetID = 11;
        base.Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet11")
        {
            collisionStart = Time.time;
            otherObject = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet11")
        {
            collisionStart = -0.5f;
            otherObject = null;
        }
    }
}
