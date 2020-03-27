using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rigidBody;

    public Camera camera;

    Vector2 movement;
    Vector2 mousePosition;
   

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookingDirection = rigidBody.position - mousePosition;

        float angle = Mathf.Atan2(lookingDirection.y,lookingDirection.x) * Mathf.Rad2Deg -90f;

        rigidBody.rotation = angle;
    }
}
