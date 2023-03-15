using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Target;
    public Vector3 offset= new Vector3(0,5,0);

    private void LateUpdate()
    {
        transform.LookAt(Target.transform);
        transform.position += offset;
    }

    //fixedupdate
    //update
    //lateupdate

}
