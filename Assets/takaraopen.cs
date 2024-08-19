using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takaraopen : MonoBehaviour
{
    public int openflag = 0;
    float rotatex;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        openflag = 1;
    }



    void Update()
    {
        if (openflag == 1)
        {
            rotatex += 0.5f;
            transform.rotation = Quaternion.Euler(rotatex, 0.0f, -90.0f);
            if (rotatex > 90)
            {
                enabled = false;
            }
        }
    }





}
