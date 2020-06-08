using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_SlideRight : CameraState_Slide
{
    private float distance = 4f;
    private CameraState slideState = CameraState.Slide_Right;
    private bool appliedDistance = false;
    private float duration;
    
    public override void UpdateCamera(Camera cam, GameObject target, float c)
    {
        if (!appliedDistance)
        {
            duration = c;
            cam.transform.position = target.transform.position;
            cam.transform.position = new Vector3(
                cam.transform.position.x,
                cam.transform.position.y + (distance/2),
                cam.transform.position.z - distance);
            cam.transform.LookAt((target.transform));
            cam.transform.position = new Vector3(
                cam.transform.position.x - (distance/2),
                cam.transform.position.y,
                cam.transform.position.z);
            

            appliedDistance = true;
        }
        
        cam.transform.Translate(Vector3.right * Time.deltaTime * slideSpeed);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }
    }
}
