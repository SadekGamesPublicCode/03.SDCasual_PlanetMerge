using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet08 : PlanetSC
{

    void Start()
    {
        base.Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet8")
        {
            collisionStart = Time.time;
            otherObject = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet8")
        {
            collisionStart = -0.5f;
            otherObject = null;
        }
    }
}
