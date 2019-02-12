using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
	public string levelname;

    private bool nextLevel;

	// Start is called before the first frame update
	void Start()
	{
        nextLevel = false;
	}

	// Update is called once per frame
	void Update()
	{
        if(Input.GetKeyDown (KeyCode.Space) && nextLevel == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelname);
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.CompareTag ("Player"))
		{
            nextLevel = true;
            Debug.Log("Going UP!");
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        nextLevel = false;
    }
}