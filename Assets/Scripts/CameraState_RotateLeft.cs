using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_RotateLeft : CameraState_Rotate
{
    private CameraState rotateState = CameraState.Rotate_Left;
    private bool appliedDistance = false;
    private float distance = 5f;
    private float duration;
    
    public override void UpdateCamera(Camera cam, GameObject target, float c)
    {
        if (!appliedDistance)
        {
            duration = c;
            cam.transform.position = new Vector3(
                target.transform.position.x,
                target.transform.position.y + (distance/2),
                target.transform.position.z - distance);
            appliedDistance = true;
        }
        cam.transform.LookAt(target.transform);
        cam.transform.Translate(Vector3.left * Time.deltaTime * rotateSpeed);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }
    }
}
