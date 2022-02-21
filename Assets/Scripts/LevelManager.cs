using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad();
    }

    public void restart(){
        Debug.Log("Restarted");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            TurnPause(true);
        }
    }
    public void Exit(){
        Debug.Log("Exit");
        Application.Quit(); 
    }
    public void ToMenu(){
        Debug.Log("Play");
        
        SceneManager.LoadScene(0, LoadSceneMode.Single);        
    }
    public void TurnPause(bool state){
        Debug.Log(state);
        float sc=1;
        if(state){
            Cursor.lockState = CursorLockMode.None;
            sc=0;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
        }
        Time.timeScale=sc;
        foreach(GameObject button in buttons){
            button.SetActive(state);
        }
        
    }
}
