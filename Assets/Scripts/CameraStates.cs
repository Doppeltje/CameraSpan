using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class CameraStates
{
    protected Camera cam1;
    protected Camera cam2;
    protected GameObject target;

    protected enum CameraState
    {
      Diagonal_BottomLeft,
      Diagonal_BottomRight,
      Diagonal_TopLeft,
      Diagonal_TopRight,
      Rotate_Left,
      Rotate_Right,
      Slide_Left,
      Slide_Right,
      Zoom_In,
      Zoom_Out
    }
    
    // Update camera by giving it a new state.
    public virtual void UpdateCamera(Camera cam, GameObject target, float c) {

    }
    
    protected void CameraAction(Camera cam, Transform target, CameraState state)
    {
        switch (state)
        {
            case CameraState.Diagonal_BottomLeft:
                break;
            case CameraState.Diagonal_BottomRight:
                
                break;
            case CameraState.Diagonal_TopLeft:
                
                break;
            case CameraState.Diagonal_TopRight:
                
                break;
            case CameraState.Rotate_Left:

                break;
            case CameraState.Rotate_Right:

                break;
            case CameraState.Slide_Left:

                break;
            case CameraState.Slide_Right:

                break;
            case CameraState.Zoom_In:

                break;
            case CameraState.Zoom_Out:

                break;
        } 
    }
}
