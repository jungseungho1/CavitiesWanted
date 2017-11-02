using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jawJointMove : MonoBehaviour
{

    float smooth = 0.5f;
    float closeAngle = 0f;
    float openAngle = 35f;
    public bool jawClose = false;


    void Update()
    {
        if (jawClose = true)
        {
            Quaternion targetRotation = Quaternion.Euler(0, closeAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else if (jawClose = false)
        {
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }

    }
}
