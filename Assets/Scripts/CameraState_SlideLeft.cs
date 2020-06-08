using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_SlideLeft : CameraState_Slide
{
   private CameraState slideState = CameraState.Slide_Left;
   private float distance = 3f;
   private bool appliedDistance = false;
   private float duration;
   
   public override void UpdateCamera(Camera cam, GameObject target, float c)
   {
      if (!appliedDistance)
      {
         duration = c;
         cam.transform.LookAt(target.transform);
         cam.transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y + (distance/2), 
            target.transform.position.z - distance);
         cam.transform.LookAt(target.transform);
         cam.transform.position = new Vector3(
            cam.transform.position.x + (distance),
            cam.transform.position.y,
            cam.transform.position.z);

         appliedDistance = true;
      }
    
      cam.transform.Translate(Vector3.left * Time.deltaTime * slideSpeed);
      duration -= Time.deltaTime;
      if (duration <= 0) {
         appliedDistance = false;
      }
   }
}
