using UnityEngine;
public class Car : MonoBehaviour {
    public Wheel[] wheels;
    public Transform[] wheelTransforms;
    public Collider[] colliders;
    public Rigidbody body;
    public RaycastHit[] hits = new RaycastHit[10];
    public LayerMask mask;
    public float maxSuspensionDistance = .5f;
    public float forwardForce = 5f;
    public float sidewaysForce = 4f;
    private void FixedUpdate() {
        for (var i = 0; i < wheelTransforms.Length; i++) {
            var wheelTransform = wheelTransforms[i];
            var wheel = wheels[i];
            var collider = colliders[i];
            var e = wheel.contacts.GetEnumerator();
            while (e.MoveNext()) {
                var contactingCollider = e.Current;
                var point = contactingCollider.ClosestPoint(wheelTransform.position);
                var normal = wheelTransform.position - point;
                var forceVector = Vector3.Cross(normal, wheel.transform.up);
                forceVector = forceVector.normalized * (Input.GetAxis("Vertical") * forwardForce);
                body.AddForceAtPosition(forceVector, point, ForceMode.VelocityChange);
                Debug.DrawRay(point, forceVector, Color.cyan, 1f);
                var force = wheelTransform.up * (Vector3.Dot(wheelTransform.up, body.velocity) * -sidewaysForce);
                body.AddForceAtPosition(force, point, ForceMode.VelocityChange);
                Debug.DrawRay(point, force, Color.red, 1f);
            }
            e.Dispose();
        }
    }
    private void Update() {
        for (var i = 0; i < 2; i++) {
            var wheelTransform = wheelTransforms[i];
            wheelTransform.localEulerAngles = new Vector3(0, Input.GetAxis("Horizontal") * 30f, 90);
        }
    }
    public void WheelCollisionEnter(Wheel wheel, Collision other) {
        for (int i = 0; i < other.contactCount; i++) {
            var contact = other.contacts[i];
            wheel.contacts.Add(contact.otherCollider);
        }
    }
    public void WheelCollisionExit(Wheel wheel, Collision other) {
        wheel.contacts.Remove(other.collider);
    }
}
    