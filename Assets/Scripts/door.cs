using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    AudioSource source;
    public int HP=1;
    bool Locked=false;
    // Start is called before the first frame update
    void Start()
    {
        source =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lock(){
        Debug.Log("дверь "+HP   );
        if(HP>0){
        if(Locked){
            Locked=false;
            GetComponent<Rigidbody>().isKinematic=false;
            Debug.Log("Открыли дверь");
        }else{
            Locked=true;
            GetComponent<Rigidbody>().isKinematic=true;
            Debug.Log("Закрыли дверь");
        }}
    }
    void BeDestryed(){
            Locked=false;
            GetComponent<Rigidbody>().isKinematic=false;
            source.Play();
            Debug.Log("Door destroyed");
            Destroy(GetComponent<HingeJoint>());
            transform.Rotate(new Vector3(-5,0,0),Space.Self);
           
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.transform);
        if(HP>0){
                

            if(collision.transform.GetComponent<Enemy>()){
                 HP--;
                  Debug.Log("дверь поцарапиали");
             }


             if(HP<1){
                BeDestryed();
                //GetComponent<Rigidbody>().AddForce(collision.transform.forward*40+collision.transform.up*50);
                 
            }

        }
       
    }
}
