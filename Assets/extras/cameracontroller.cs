using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Rigidbody cambot;
    float xRotation = 0f;
    public Transform cam;
    public float panspeed = 10;
    public float panborderthickness = 25f;
    public Vector2 panlimit;
    public float scrollspeed = 100f;
    public float angularspeed = 60f;
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    { panlimit = new Vector2(60,85);
      Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos += transform.forward * panspeed * Time.deltaTime;
            //control.Move(transform.forward * panspeed * Time.deltaTime);
            cambot.MovePosition(pos);

        }
        if (Input.GetKey("s") )
        {
            pos -= transform.forward * panspeed * Time.deltaTime;
            //control.Move(transform.forward * -panspeed * Time.deltaTime)
            cambot.MovePosition(pos);


        }
        if (Input.GetKey("d") )
        {
            pos += transform.right * panspeed * Time.deltaTime;
            //control.Move(transform.right * panspeed * Time.deltaTime);
            cambot.MovePosition(pos);

        }
        if (Input.GetKey("a") )
        {   pos-= transform.right * panspeed * Time.deltaTime;
            //control.Move(transform.right * -panspeed*Time.deltaTime );
            cambot.MovePosition(pos);

        }
        float mousex= Input.GetAxis("Mouse X") * scrollspeed * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * scrollspeed * Time.deltaTime;
        xRotation -= mousey;
        transform.Rotate(transform.up * scrollspeed * Time.deltaTime * mousex);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y += scroll * scrollspeed * Time.deltaTime;
        transform.position = pos;

    }
}
