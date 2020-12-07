using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour {
    public Transform target;
    void LateUpdate() {
        transform.position = Vector3.Slerp(transform.position, target.position, .1f);
    }
}
