using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Transform[] targets;

    public int targetIndex;

    public List<Vector3> _targets = new List<Vector3>();

    public Vector3 _target;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var element in targets)
        {
            _targets.Add(element.position);
        }
        setTarget(_targets[targetIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void setTarget(Vector3 target)
    {
        _target = target;
    }
    private void Move()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _target);

        if (distance <= 0)
        {
            targetIndex++;
            targetIndex = targetIndex % _targets.Count;
            setTarget(_targets[targetIndex]);
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, _target, (Time.deltaTime * speed) / distance);
        }
    }
}
