using UnityEngine;

public class followPositionAndRoataion : MonoBehaviour
{
    [Header("Axis For Follow Position")]
    public bool x = true;
    public bool y = true, z = true;

    [Header("Position Offsets")]
    [Range(-20,20)]
    public float xOfsset;
    [Range(-20, 20)]
    public float yOfsset;
    [Range(-20, 20)]
    public float zOfsset;

    [Header("Follow Properties")]
    public bool followPosition = true;
    public bool followRotation = true;
    public Transform objectToFollow;
    public bool lerpPos;
    public bool lerpRot;
    [Range(0, 20)]
    public float lerpSpeedPos, lerpSpeedRot;

    Transform rotationPlaceHolder;

    void Update()
    {
        if (followPosition)
        {
            if (lerpPos)
            {
                float xpos = objectToFollow.position.x + xOfsset;
                float ypos = objectToFollow.position.y + yOfsset;
                float zpos = objectToFollow.position.z + zOfsset;

                xpos = (x ? xpos : transform.position.x);
                ypos = (y ? ypos : transform.position.y);
                zpos = (z ? zpos : transform.position.z);

                Vector3 pos = new Vector3(xpos, ypos, zpos);
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * lerpSpeedPos);
            }

            else
            {
                float xpos = objectToFollow.position.x + xOfsset;
                float ypos = objectToFollow.position.y + yOfsset;
                float zpos = objectToFollow.position.z + zOfsset;

                xpos = (x ? xpos : transform.position.x);
                ypos = (y ? ypos : transform.position.y);
                zpos = (z ? zpos : transform.position.z);

                Vector3 pos = new Vector3(xpos, ypos, zpos);
                transform.position = pos;
            }
        }

        if (followRotation)
        {
            if (lerpRot)
            {
                if (rotationPlaceHolder == null)
                    rotationPlaceHolder = new GameObject().GetComponent<Transform>();

                rotationPlaceHolder.position = transform.position;
                rotationPlaceHolder.rotation = objectToFollow.rotation;

                transform.rotation = Quaternion.Lerp(transform.rotation, rotationPlaceHolder.rotation, Time.deltaTime * lerpSpeedRot);
            }

            else
            {
                transform.rotation = objectToFollow.rotation;
            }
        }
    }
}
