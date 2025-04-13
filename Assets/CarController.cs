using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed;

    float minSpeed = 40f;
    float maxSpeed = 70f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
