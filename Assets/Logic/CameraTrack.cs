using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour {
    public Transform target;
    void Update() {
        transform.position = Vector3.Lerp(transform.position, target.position, .1f);
    }
}
