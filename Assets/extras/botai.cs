using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botai : MonoBehaviour
{

    //public Transform bot;
    public CharacterController control;
    public float q1 = 0.0f;
    public float t1 = 0;
    public float t2 = 0;
    public float gravity = -10f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       control.Move(transform.up * Time.deltaTime * gravity);
       walladhesion();
        if (q1 == 1)
        {
            sensors();
        }


    }
    private void sensors()
    {
        float sensorlength = 0.25f;
        float y = 0f;
        float speed = 4f;
        float angularspeed = 50f;
        float frontsenpos = 0.05f;
        float sidesenpos = 0.05f;
        float sidesenangle = 35f;
        float offset = 1f;

        Vector3 startsenpos = this.transform.position;
        startsenpos += frontsenpos * transform.forward;
        startsenpos += offset * transform.up;
        RaycastHit hit;
        if (Physics.Raycast(startsenpos, transform.forward, out hit, sensorlength))
        {
            y = 1f;

        }

        Debug.DrawRay(startsenpos, transform.forward);

        startsenpos += sidesenpos * transform.right;
        if (Physics.Raycast(startsenpos, transform.forward, out hit, sensorlength))
        {
            y = 1f;

        }
        Debug.DrawRay(startsenpos, transform.forward);

        if (Physics.Raycast(startsenpos, Quaternion.AngleAxis(sidesenangle, transform.up) * transform.forward, out hit, sensorlength))
        {
            y = 1f;

        }
        Debug.DrawRay(startsenpos, Quaternion.AngleAxis(sidesenangle, transform.up) * transform.forward);
        startsenpos -= 2 * sidesenpos * transform.right;
        if (Physics.Raycast(startsenpos, transform.forward, out hit, sensorlength))
        {
            y = 1f;

        }
        Debug.DrawRay(startsenpos, transform.forward);
        if (Physics.Raycast(startsenpos, Quaternion.AngleAxis(-sidesenangle, transform.up) * transform.forward, out hit, sensorlength))
        {
            y = 1f;

        }
        Debug.DrawRay(startsenpos, Quaternion.AngleAxis(-sidesenangle, transform.up) * transform.forward);
        if (y == 0)
        {
            control.Move(transform.forward * speed * Time.deltaTime);
            t2 = 0;
        }
        else
        {
            transform.Rotate(transform.up * angularspeed*Time.deltaTime);
            
            t2 = 1;

        }



        /// Debug.Log(startsenpos);
        /// Debug.Log(">>");
        /// Debug.Log(transform.forward);
    }
    private void walladhesion()
    {   q1 = 0f;
        RaycastHit hit;
        float angularspeed = -100f;
        Vector3 wallsensorpos = transform.position;
        float fontsensor = 0.05f;
        float shiftback = 0.03f;
        float doublesensorlenght = 0.1f;
        float offset = 1f;
        float speed = 1f;
        wallsensorpos -= fontsensor * transform.right;
        wallsensorpos -= shiftback * transform.forward;
        wallsensorpos += offset * transform.up;
        float sensorlength = .4f;
        Debug.DrawRay(wallsensorpos, -transform.right);
        if (!(Physics.Raycast(wallsensorpos,-transform.right,out hit, sensorlength)))
        {   wallsensorpos += fontsensor * transform.right;
            wallsensorpos += fontsensor * transform.forward;
            
            if (!(Physics.Raycast(wallsensorpos, -transform.right, out hit, doublesensorlenght)))
            {
                Debug.DrawRay(wallsensorpos, -transform.right);

                control.Move(-transform.right * speed * Time.deltaTime);
                transform.Rotate(transform.up * angularspeed * Time.deltaTime);
             
            }
            else
            {
                Debug.DrawRay(wallsensorpos, -transform.right);
                transform.Rotate(transform.up * angularspeed * Time.deltaTime);
                control.Move(-transform.right * speed * Time.deltaTime);
                ///if (Physics.Raycast(wallsensorpos, -transform.forward, out hit, sensorlength))
               /// {
               //     control.Move(transform.forward * speed * Time.deltaTime);
               // }
             }

        }
        else
        {
            q1 = 1;
        }







    }





    }



