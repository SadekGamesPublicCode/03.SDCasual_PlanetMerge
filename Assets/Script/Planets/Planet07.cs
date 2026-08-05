using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet07 : PlanetSC
{

    void Start()
    {
        base.Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet7")
        {
            collisionStart = Time.time;
            otherObject = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet7")
        {
            collisionStart = -0.5f;
            otherObject = null;
        }
    }
}
