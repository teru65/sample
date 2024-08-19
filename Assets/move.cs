using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 3;
    public float rotateSpeed = 90;
    public float jumpPower = 6;



    float vz = 0;
    float angle = 0;
    bool pushFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;
    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {

        angle = Input.GetAxisRaw("Horizontal") * rotateSpeed;
        vz = Input.GetAxisRaw("Vertical") * speed;

        if (Input.GetKey("space") && groundFlag)
        {
            Debug.Log("a");
            if (pushFlag == false)
            {
                pushFlag = true;
                jumpFlag = true;
            }
        }
        else
        {
            pushFlag = false;
        }
    }

    void FixedUpdate()
    {
        if (vz != 0)
        {
            this.transform.Translate(0, 0, vz / 50);
        }
        if (angle != 0)
        {
            this.transform.Rotate(0, angle / 50, 0);
        }
        if (jumpFlag)
        {
            Debug.Log("b");
            jumpFlag = false;
            rbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        Debug.Log("onTriggerStay");
        groundFlag = true;
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("onTriggerExit");
        groundFlag = false;
    }

}