using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Resp());
    }
    public void respawn(){
        StartCoroutine(Resp());
    }

    IEnumerator Resp(){
        yield return new WaitForSeconds(seconds);
        GameObject One = Instantiate(prefab);
        One.transform.position=transform.position;
        if(One.GetComponent<AidKit>()){
            
            One.GetComponent<AidKit>().spawner=this;
        }
        if(One.GetComponent<AmmoBag>()){
            
            One.GetComponent<AmmoBag>().spawner=this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
