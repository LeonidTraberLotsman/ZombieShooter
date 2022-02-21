using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    public ThingSpawner spawner;
    Rigidbody Rigid;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Rigid.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
      // Debug.Log(collision.transform);
       Rigid.useGravity=true;
       if(collision.transform.GetComponent<PlayerBodyMove>()){
           PlayerBodyMove PB=collision.transform.GetComponent<PlayerBodyMove>();
           if(PB.HP<6){
                PB.HP+=1;
                spawner.respawn();
                Destroy(this.gameObject);
           }
           
       }
    }
}
