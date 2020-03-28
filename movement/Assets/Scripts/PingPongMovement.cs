using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public Transform ping;

    public Transform pong;

    public float speed;

    Vector3 currentTarget;

    Vector3 targetPosition;

    Vector3 _ping;
    Vector3 _pong;
    // Start is called before the first frame update
    void Start()
    {

        currentTarget = ping.position;
        _ping = ping.position;
       _pong = pong.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = Vector3.Distance(gameObject.transform.position, currentTarget);

        if(distance <= 0)
        {
            if(currentTarget == _ping)
            {
                currentTarget = _pong;
            }
            else
            {
                currentTarget = _ping;
            }
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * speed) / distance);
        }
    }
}
