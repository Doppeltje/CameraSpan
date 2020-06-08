using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraState_Diagonal_BottomLeft : CameraState_Diagonal
{
    private CameraState diagonalState = CameraState.Diagonal_BottomLeft;
    private float distance = 3f;
    private bool appliedDistance = false;
    private float diagonalSpeed = 1f;
    private float duration;

    public override void UpdateCamera(Camera cam, GameObject target, float c)
    {
        if (!appliedDistance)
        {
            duration = c;
            cam.transform.position = target.transform.position;
            cam.transform.position = new Vector3(
                cam.transform.position.x,
                cam.transform.position.y,
                cam.transform.position.z - distance);
            cam.transform.LookAt(target.transform);
            cam.transform.position = new Vector3(
                cam.transform.position.x + distance,
                target.transform.position.y + distance,
                cam.transform.position.z - distance);

            appliedDistance = true;
        }
        
        cam.transform.Translate(Vector3.down * Time.deltaTime * diagonalSpeed);
        cam.transform.Translate(Vector3.left * Time.deltaTime * diagonalSpeed);

        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            appliedDistance = false;
        }
    }
}
