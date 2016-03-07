using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float interpVelocity;
    private GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 myPos = transform.position;
            myPos.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - myPos);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 1f);

        }
    }
}
