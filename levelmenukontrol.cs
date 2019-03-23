using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmenukontrol : MonoBehaviour {

	
	void Start () {
		
	}
    public void anamenudonus()
    {
        SceneManager.LoadScene(0);//anamenu
    }
    public void leveltekrarla()
    {
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name));
    }
    public void birsonrakilevel()
    {
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
