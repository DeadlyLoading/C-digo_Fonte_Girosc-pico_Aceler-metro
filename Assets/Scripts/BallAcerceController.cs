using UnityEngine;

public class BallAcerceController : MonoBehaviour
{

    public float speed = 12f;
    public float deadZone = 0.03f;
    public bool autoCalibrateOnStart = true;

    Rigidbody rb;
    Vector2 calib;  //XY Axy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (autoCalibrateOnStart) calib = ReadTiltXY();

    }

    Vector2 ReadTiltXY()
    {
        Vector3 accelaration = Input.acceleration;

        return new Vector2(accelaration.x, accelaration.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalibrateNow() => calib = ReadTiltXY();

     void FixedUpdate()
    {
        Vector2 tilt = ReadTiltXY().normalized - calib;

            if(tilt.magnitude < deadZone)
            {
            tilt = Vector2.zero;
            }
        Vector3 force = new Vector3(0f, tilt.x, tilt.y) * speed;

        rb.AddForce(force, ForceMode.Acceleration);
    }
}
