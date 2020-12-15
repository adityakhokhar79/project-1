using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
   
    public Rigidbody bot;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w")) 
        {
            bot.AddForce(0,0,1000*Time.deltaTime);

        }
        if (Input.GetKey("a"))
        {
            bot.AddForce(  -1000*Time.deltaTime,0,0);

        }
        if (Input.GetKey("d"))
        {
            bot.AddForce(1000 * Time.deltaTime,0,0);
        }
        if (Input.GetKey("s"))
        {
            bot.AddForce(0,0,-1000 * Time.deltaTime);

        }
    }
}
