using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenukontrol : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
   public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
    public void startbuton()
    {
        if (PlayerPrefs.GetInt("sonlevel") == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("sonlevel"));
        }
    }

}
