using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public arena arena;
    public GameObject Zombieprefab; 
    public int HowMuch;
    public GameObject player;
    
    public void StartSpawning(int Z){
        StartCoroutine(Spawn(Z));
        
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(int N){
        for(int i =0;i<N;i++){
            //yield return new WaitForSeconds(3f);
            GameObject Zombie = Instantiate(Zombieprefab);
            if (arena!=null){
                Zombie.GetComponent<Enemy>().arena=arena;
                arena.zombies.Add(Zombie.GetComponent<Enemy>());
            }
            Zombie.transform.position=transform.position;
            Zombie.GetComponent<Enemy>().player=player;
        }
        yield return new WaitForSeconds(3f);

    }
}
