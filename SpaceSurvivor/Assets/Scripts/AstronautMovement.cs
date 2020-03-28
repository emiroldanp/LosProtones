using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
	public static AstronautMovement instance;


	public float moveSpeed;
	private Vector2 moveInput;

    private float health;

    private float oxygen;

    public int maxHealthValue = 500;

    public int maxOxygenValue = 400;

    public Rigidbody2D rigidBody;
    public Camera camera;
    Vector2 mousePosition;

    public Transform gunArm;

    public RectTransform healthBar;
    public RectTransform oxygenBar;


    public Animator anim;

    bool isRunning = false;

    public HUDManager hud;

    private float minXHealth;

    private float maxXHealth;



    private float minXOxygen;
    private float maxXOxygen;

  

    






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

        

        maxXHealth = healthBar.position.x;
        minXHealth = healthBar.position.x - healthBar.rect.width;
        health = maxHealthValue;

        minXOxygen = oxygenBar.position.x - oxygenBar.rect.width;
        maxXOxygen = oxygenBar.position.x;

        oxygen = maxOxygenValue;

        


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag.Equals("Object"))
        {
            hud.showMessagePanel("Press F to pick up");
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.tag.Equals("Object"))
        {
            hud.hideMessagePanel();
        }
        */
    }


    private float HUDValue(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


    public void updateHealth()
    {
        if(health<= maxHealthValue)
        {
            float currentX = HUDValue(health, 0, maxHealthValue, minXHealth, maxXHealth);

            

            healthBar.position = new Vector3(currentX, healthBar.position.y);
        }
       



    }

    public void updateOxygen()
    {
        if(oxygen<= maxOxygenValue)
        {
            float currentX = HUDValue(oxygen, 0, maxOxygenValue, minXOxygen, maxXOxygen);

            

            oxygenBar.position = new Vector3(currentX, healthBar.position.y);
        }
        



    }

    public void increaseHealth(int amount)
    {
        health += amount;

        updateHealth();
    }


    public void decreaseHealth(int amount)
    {
        health -= amount;
        updateHealth();
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void increaseOxygen(int amount)
    {
        oxygen += amount;

        updateOxygen();
    }

    public void decreaseOxygen(int amount)
    {
        oxygen -= amount;
        updateOxygen();

        if (oxygen <= 0)
        {
            Destroy(gameObject);
        }
    }
}
