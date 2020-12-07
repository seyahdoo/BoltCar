using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    public Car car;
    public readonly HashSet<Collider> contacts = new HashSet<Collider>();
    private void OnCollisionEnter(Collision other) {
        car.WheelCollisionEnter(this, other);
    }
    private void OnCollisionExit(Collision other) {
        car.WheelCollisionExit(this, other);
    }
}
