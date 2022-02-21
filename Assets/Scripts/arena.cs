using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arena : MonoBehaviour
{
    public int WavesCounter; 
    public Text YDT;
    public List<Enemy> zombies;
    public List<spawner> spawners;
    public spawner BossSpawner;
    // Start is called before the first frame update


    IEnumerator MultiWave(){
        for(int i=0;i<WavesCounter;i++){
            yield return Wave();
        
            yield return new WaitForSeconds(1);
            while(zombies.ToArray().Length>0){
                yield return null;
            }
            Debug.Log("Волна кончилась"+zombies.ToArray().Length);
        }




        //Boss Battle
        BossSpawner.StartSpawning(1);
        yield return new WaitForSeconds(1);
        YDT.text="Босс батл";
        yield return new WaitForSeconds(3);
        YDT.text="";
        while(zombies.ToArray().Length>0){
                yield return null;
            }
        yield return new WaitForSeconds(1);    
        YDT.text="Вы победили!";

    }

    public IEnumerator Wave()
    {
        for(int i=0;i<spawners.ToArray().Length;i++){
            spawners[i].StartSpawning(2);
        }
        yield return null;

        
    }

    
    void Start()
    {
        BossSpawner.arena=this;
         for(int i=0;i<spawners.ToArray().Length;i++){
            spawners[i].arena=this;
        }


        StartCoroutine(MultiWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
