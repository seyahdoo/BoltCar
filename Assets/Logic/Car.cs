using UnityEngine;

public class Car : MonoBehaviour {
    public Transform[] wheels;
    public Rigidbody body;
    public RaycastHit[] hits = new RaycastHit[10];
    public LayerMask mask;
    private float maxSuspensionDistance = 1f;
    
    private void FixedUpdate() {
        for (var i = 0; i < wheels.Length; i++) {
            var wheel = wheels[i];
            var hitCount = Physics.RaycastNonAlloc(wheel.position, -wheel.up, hits, 10, mask);
            if (hitCount > 0) {
                var distance = hits[0].distance;
                if (distance > maxSuspensionDistance) {
                    
                }
                
                body.AddForceAtPosition(Input.GetAxis("Vertical") * 5f * wheel.forward, wheel.position, ForceMode.Force);
                var force = wheel.right * (Vector3.Dot(wheel.right, body.velocity) * -4);
                body.AddForceAtPosition(force, wheel.position, ForceMode.Force);
            }
            
            
            
        }
    }
    private void Update() {
        for (var i = 0; i < 2; i++) {
            var wheel = wheels[i];
            wheel.eulerAngles = Input.GetAxis("Horizontal") * 45f * Vector3.up;
        }
    }
}
    