using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBodyMove : MonoBehaviour
{
    public int HP =2;

    public Shooter Shooter;
    public GameObject restartButton;
    public PlayerMove playermove;
    public Text HPIndicator;
    public Text YDT;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 200f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool Playable=true;

    // Start is called before the first frame update
    void Start()
    {
        YDT.text=" ";
        restartButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y<-200){
            BeingDead();
        }


        HPIndicator.text=HP.ToString();

        if(Playable){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = 0;
        float z = 0;
        //if (isGrounded)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*Time.deltaTime*speed);

        //Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        }
       
    }





     public void GotAttacked(Vector3 side){
                HP--;
                if(HP<1){
                    Debug.Log("Ты умер");
                    BeingDead();
                }
                controller.Move(side);

        }

    void BeingDead(){
        YDT.text="Вы умерли";
        playermove.Playable=Playable=false;
        Cursor.lockState = CursorLockMode.None;
        restartButton.SetActive(true);

    }
}
