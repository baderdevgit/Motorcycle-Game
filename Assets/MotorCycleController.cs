using UnityEngine;

public class MotorCycleController : MonoBehaviour
{
    [SerializeField]
    GameObject motorcycle;

    public float maxSpeed = 20f;
    public float smoothTime = 0.3f; // lower is snappier, higher is more floaty

    private float currentSpeed = 0f;
    private float velocity = 0f; // required by SmoothDamp

    public float leanAngle = 45f;
    public float leanSmoothTime = 0.3f;

    private float currentLean = 0f;
    private float leanVelocity = 0f;

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal"); // A/D keys
        float targetSpeed = input * maxSpeed;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref velocity, smoothTime);

        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime, Space.World);

        // Leaning: target lean is based on input
        float targetLean = -input * leanAngle; // negative input (left) = lean left (-45)
        currentLean = Mathf.SmoothDamp(currentLean, targetLean, ref leanVelocity, leanSmoothTime);

        // Apply rotation around Z axis
        motorcycle.transform.localRotation = Quaternion.Euler(0f, 0f, currentLean);
    }
}
