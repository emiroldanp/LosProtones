using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
	public static AstronautMovement instance;


	public float moveSpeed;
	private Vector2 moveInput;

    public Rigidbody2D rigidBody;
    public Camera camera;
    Vector2 mousePosition;

    public Transform gunArm;


    public Animator anim;

    bool isRunning = false;




    public GameObject bulletToFire;
    public Transform firePoint;



    private void Awake(){

    	instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        anim = GetComponent<Animator> ();

       
    }

    // Update is called once per frame
    void Update()
    {

    	moveInput.x = Input.GetAxisRaw("Horizontal");

    	moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();


        rigidBody.velocity = moveInput * moveSpeed;

        //mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);



        Vector3 mousePos = Input.mousePosition;

        Vector3 screenPoint = camera.WorldToScreenPoint(transform.localPosition);


        if (mousePos.x < screenPoint.x){

            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f,-1f,1f);

        } else{

            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;




        } 



        //rotate gun arm

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x)* Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0,0,angle);


        if(Input.GetMouseButtonDown(0)){

            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);



        }




        if(moveInput != Vector2.zero){

            anim.SetBool("isRunning",true);

        } else {

            anim.SetBool("isRunning",false);
        }
        
    }
}
