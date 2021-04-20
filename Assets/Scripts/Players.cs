using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    [SerializeField] //private and not given to other classes but avilable in inspector panel in unity
    private float moveForce = 10f;


    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk"; //animation tab preference

    private bool isGrounded = true;

    private string Ground_Tag = "Ground";    //"Ground" is the tag we give as tag in inspector of ground objects

    private string ENEMY_TAG = "Enemy"; 


    private void Awake(){
        myBody = GetComponent<Rigidbody2D>(); //instead of this line of code we can make Rigidbody 2D publid or use "[SerializeField]
                                                // and drag the item(Here player) having the rigid body component to the inspector tab
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame... Every frame it will be called
    void Update()       
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        
    }

    //  It is not called for every frame, its only called for fixed number of updates (ie "Fixed Timestamp" under Time in Project Settings)
    private void FixedUpdate(){
        PlayerJump();
    }
    void PlayerMoveKeyboard(){

        movementX = Input.GetAxisRaw("Horizontal"); //give -1 or +1 depending upon (<- or ->) or (A or D)
        Debug.Log("move X vale is: " + movementX);

        transform.position += new Vector3(movementX, 0f , 0f)* moveForce * Time.deltaTime; //Time.deltaTime is time between each frame (very low number)
        //Debug.Log("Time.detlaTome"+ Time.deltaTime + "moveForce" + moveForce);
    }

    void AnimatePlayer(){

        if(movementX>0){
            //We go right
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;       //To flip the player
        }
        else if (movementX < 0){
            //we go left
            anim.SetBool(WALK_ANIMATION,true);      //in the animator tab we created these... and we use Bool cuz we used "Bool" for walk
            sr.flipX = true;
        }
        else {
            anim.SetBool(WALK_ANIMATION,false);
        }
        
    }

    void PlayerJump() {
        if(Input.GetButtonDown("Jump")&& isGrounded){    //"Jump" is pre-defined in unity for the keys or controller buttons used to jump 
                                                        // GetButton -> called 2 times when space bar is down and up, GetButtonDown-> called when button is down and GetButtonUp-> called when space bar is released
            isGrounded= false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);       //ForceMode2D.Impluse just pushed the player up
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){ //its used to detect collision between 2 objects and 'collision' is the 2nd object

    if (collision.gameObject.CompareTag(Ground_Tag)){       
            isGrounded=true;
    }

    if(collision.gameObject.CompareTag(ENEMY_TAG)){

        Destroy(gameObject);
    }

    }

    //Just another way to detect collision using isTrigger.. Now because isTrigger is enabled Ghost will pass throught enemies
    private void OnTriggerEnter2D(Collider2D collision){    // For Ghosts, we check isTriggered right in Capsulebosy2D, This is another way to check for collision

        if(collision.CompareTag(ENEMY_TAG)){     //for Collider2d we can call CompareTag directly unlike Collision2d as above
            Destroy(gameObject);
        }
    }

}
