using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_Diagonal_TopLeft : CameraState_Diagonal
{
    private CameraState diagonalState = CameraState.Diagonal_TopLeft;
    private float distance = 3f;
    private bool appliedDistance = false;
    private float diagonalSpeed = 1f;
    private float duration;
    
    public override void UpdateCamera(Camera cam, GameObject target, float c)
    {
        if (!appliedDistance)
        {
            duration = c;
            cam.transform.position = new Vector3(
                target.transform.position.x-distance,
                target.transform.position.y,
                target.transform.position.z);
            cam.transform.LookAt(target.transform);
            cam.transform.position = new Vector3(
                cam.transform.position.x - distance,
                cam.transform.position.y - distance,
                cam.transform.position.z - distance);

            appliedDistance = true;
        }
        
        cam.transform.Translate(Vector3.up * Time.deltaTime * diagonalSpeed);
        cam.transform.Translate(Vector3.left * Time.deltaTime * diagonalSpeed);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }

        Debug.Log("duration = " + duration);
    }
}
