using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public arena arena;
    public float speed;
    bool Alive=true;
    public int HP = 2;
    public GameObject player;
    NavMeshAgent agent;
    void Start(){
        agent=GetComponent<NavMeshAgent>();
        GetComponent<Rigidbody>().isKinematic=true;
        
        agent.speed=speed;
        StartCoroutine(BeingZombie());
    }
    void Update(){
         
        
        }

    IEnumerator BeingZombie(){
        while (true){
            if(Alive){
                agent.destination=player.transform.position;
                if(Vector3.Distance(transform.position,player.transform.position)<3)
                {
                    yield return Byte();
                }
            }
            yield return null;

        }
    }
    IEnumerator Byte(){
        player.GetComponent<PlayerBodyMove>().GotAttacked(transform.forward*2);
        agent.speed=0;
        yield return new WaitForSeconds(2f);
        agent.speed=speed;

    }
   public void gotshot()//сработает, если в него попали.
   {
       Debug.Log("gotshot");
       if(HP>0){
           HP--;
       }else{
       GetComponent<Rigidbody>().useGravity=true;
       GetComponent<Rigidbody>().isKinematic=false;
       agent.enabled=false;
       Alive=false;
       
       if(arena!=null){
           arena.zombies.Remove(this);
       }
       transform.Rotate(new Vector3(-50,0,0),Space.Self);
       }
   }
}
