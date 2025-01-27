using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float followSpeed,rotateSpeed;
    public bool pause;

    Transform rotationPlaceHolder;

    void Start()
    {
        offset = transform.position - target.position;
        rotationPlaceHolder = new GameObject().transform;
        rotationPlaceHolder.name = "rotationPlaceHolder";
    }

    void Update()
    {
        if (!pause)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
            rotationPlaceHolder.position = transform.position;
            rotationPlaceHolder.LookAt(target);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationPlaceHolder.rotation, rotateSpeed * Time.deltaTime);
        }
    }

    public void setOffset()
    {
        offset = transform.position - target.position;
    }
}
