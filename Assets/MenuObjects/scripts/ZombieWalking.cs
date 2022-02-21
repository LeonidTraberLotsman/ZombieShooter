using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieWalking : MonoBehaviour
{
    int pointNumber =0;
    List<GameObject> zombies= new List<GameObject>();
    public List<Transform> pointsToSpawn;
    public Transform Finish;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        PreSpawn();
    }

    void PreSpawn(){
        for(int i=0;i<100;i++){
              SpawnZombie(pointsToSpawn[pointNumber].position);
                pointNumber++;
                if(pointNumber==pointsToSpawn.ToArray().Length){
                    pointNumber=0;
                }
        }
    }
    void SpawnZombie(Vector3 point ){
        GameObject zombie = Instantiate(prefab);
        zombie.transform.position=point;
        Vector3 Changer=new Vector3(Random.Range(-3f,3f),0,Random.Range(-3f,3f));
        zombie.GetComponent<NavMeshAgent>().destination=Finish.position+Changer;
        zombies.Add(zombie);
    }
    // Update is called once per frame
    void Update()
    {
        List<GameObject> ToRemove= new List<GameObject>();
        foreach(GameObject One in zombies){
            if(Vector3.Distance(One.transform.position,Finish.position)<3){
                ToRemove.Add(One);
            }
        }

        foreach(GameObject One in ToRemove){
            
                zombies.Remove(One);
                Destroy(One);
                SpawnZombie(pointsToSpawn[pointNumber].position);
                pointNumber++;
                if(pointNumber==pointsToSpawn.ToArray().Length){
                    pointNumber=0;
                }
            
        }
    }
}
