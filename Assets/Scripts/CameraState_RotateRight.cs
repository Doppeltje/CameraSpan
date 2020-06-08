using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_RotateRight : CameraState_Rotate
{
    private CameraState rotateState = CameraState.Rotate_Right;
    private bool appliedDistance = false;
    private float distance = 5f;
    private float duration;
    public override void UpdateCamera(Camera cam, GameObject target, float c)
    {
        if (!appliedDistance)
        {
            duration = c;
            cam.transform.position = target.transform.position;
            cam.transform.position = new Vector3(
                cam.transform.position.x,
                cam.transform.position.y + (distance/3),
                cam.transform.position.z - distance);

            appliedDistance = true;
        }
        cam.transform.LookAt(target.transform);
        cam.transform.Translate(Vector3.right * Time.deltaTime * rotateSpeed);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }
    }
}
