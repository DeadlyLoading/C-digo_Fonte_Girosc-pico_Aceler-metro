using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{

    public Transform target;  // Sphere position
    public float height = 20f; //Distância vertical
    public float smooth = 5f; //Quanto maior o valor, mais suave

    private Vector3 offset; //Será usada para salvar o y fixo 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target .position;
        offset.y = height;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target) return;

        Vector3 desirePosition=target.position + offset;
        desirePosition.y = height;

        transform.position = Vector3.Lerp(transform.position, desirePosition, Time.deltaTime * smooth);
    }
}
