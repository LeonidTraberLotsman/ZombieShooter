using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    AudioSource source;
 
    public ParticleSystem GunEffect;
    public int Ammo=60;
    int CurAmmo=30;
    private Camera _camera;
    public Text AmmoIndicator;
    public Text AllAmmoIndicator;
    // Start is called before the first frame update
    void Start()
    {
        source =GetComponent<AudioSource>();
       _camera = GetComponent<Camera>();  
       AmmoIndicator.text=CurAmmo.ToString();
       AllAmmoIndicator.text="/"+Ammo.ToString();
    }
    public void Show(){
        AmmoIndicator.text=CurAmmo.ToString();
       AllAmmoIndicator.text="/"+Ammo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&(Ammo>0)&&(CurAmmo<30)){
            int AmmoToReload=(30-CurAmmo);
            if(Ammo<AmmoToReload){
                AmmoToReload=Ammo;
            }
            Ammo=Ammo-AmmoToReload;
            CurAmmo=CurAmmo+AmmoToReload;
            AllAmmoIndicator.text="/"+Ammo.ToString();
            AmmoIndicator.text=CurAmmo.ToString();
        }
        if (Input.GetKeyDown(KeyCode.E)){
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
               
                if(hit.transform.GetComponent<door>()){
                    hit.transform.GetComponent<door>().Lock();
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(CurAmmo>0){
            CurAmmo--;
            GunEffect.Play();
            source.Play();
            AmmoIndicator.text=CurAmmo.ToString();
            
            if(CurAmmo==0){
                StartCoroutine(NoAmmoEfffect());
            }
            
            
            
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform);
                if(hit.transform.GetComponent<Enemy>()){
                    hit.transform.GetComponent<Enemy>().gotshot();
                }
            }
            }
        }
   }

IEnumerator NoAmmoEfffect(){
    yield return null;
    while(CurAmmo<1){
        yield return new WaitForSeconds(0.6f);
        AmmoIndicator.color= new Color(255,255,255,255);
        yield return new WaitForSeconds(0.6f);
        AmmoIndicator.color= new Color(0,0,0,255);
    }
}



private void OnGUI()
{
    int size = 12;
    float posX = _camera.pixelWidth / 2 - size / 4;
    float poxY = _camera.pixelHeight / 2 - size / 2;
    GUI.Label(new Rect(posX, poxY, size*100, size*100), "+");
}  
}
