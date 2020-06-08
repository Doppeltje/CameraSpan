using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_ZoomIn : CameraState_Zoom
{
   private CameraState zoomState = CameraState.Zoom_In;
   private float distance = 10f;
   private float duration;
   private bool appliedDistance = false;
   
   public override void UpdateCamera(Camera cam, GameObject target, float c) {
      if (!appliedDistance) {
         duration = c;
         cam.transform.position = target.transform.position;
         cam.transform.position = new Vector3(
            cam.transform.position.x,
            cam.transform.position.y + (distance/2),
            cam.transform.position.z - distance);
         cam.transform.LookAt(target.transform);
                
         appliedDistance = true;
      }
      
      cam.transform.Translate(Vector3.forward * Time.deltaTime * zoomSpeed);
      duration -= Time.deltaTime;
      if (duration <= 0) {
         appliedDistance = false;
      }
   }
}
