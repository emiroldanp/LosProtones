using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;

    Vector3 targetPosition;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, targetPosition);
        gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, (Time.deltaTime * speed) / distance);
    }
}
