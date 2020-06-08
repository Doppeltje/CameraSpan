using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_ZoomOut : CameraState_Zoom
{
    private CameraState zoomState = CameraState.Zoom_Out;
    private float distance = 3f;
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
            cam.transform.LookAt(target.transform);
                
            appliedDistance = true;
        }
        
        cam.transform.Translate(Vector3.back * Time.deltaTime * zoomSpeed);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }

        Debug.Log("duration = " + duration);
    }
}
