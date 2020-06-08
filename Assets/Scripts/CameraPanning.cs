using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraPanning : MonoBehaviour
{
 private enum States
 {
  Pan,
  Zoom,
  Slide
 }
 
 public Camera cam;
 public GameObject target;
 public bool isLookingAt = true;
 public bool isRotating = true;
 //Sliders
 [Range(2f, 20f)]
 public float cameraDistance = 4f;
 [Range(1f, 5f)]
 public float panSpeed = 1f;
 [Range(-50f, 50f)]
 public float yOffset;


 private void Start()
 {
  // Adjusts the camera position to add correct Y-axis offset.
  AdjustCameraOffset(cam, yOffset);
 }

 private void Update()
 {
  if (isLookingAt)
  {
   LookAt(cam, target.transform);
  }

  if (isRotating)
  {
   RotateAround(cam, target.transform);
  }
  
  SetCameraDistance(cam, target.transform, cameraDistance);
 }

 // Rotates camera to look at target.
 private void LookAt(Camera cam, Transform target)
 {
  cam.transform.LookAt(target.transform);
 }

 // Rotates around the target.
 private void RotateAround(Camera cam, Transform target)
 {
  cam.transform.Translate(Vector3.right * Time.deltaTime * panSpeed);
 }

 // Adjust camera Y-axis. Adjusting cannot be done while game is running.
 private void AdjustCameraOffset(Camera cam, float yOffset)
 {
  cam.transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y + yOffset, cam.transform.position.z);
 }

 // Set distance between camera and target.
 private void SetCameraDistance(Camera cam, Transform target, float d)
 {
  cam.transform.position =
   (cam.transform.position - target.transform.position).normalized * d + target.transform.position;
 }
}
 
 
