using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantControl : MonoBehaviour
{
	public Sprite noPlantObj;
	public Sprite sprout;

	public Sprite apple_1;
	public Sprite apple_2;
	
	
	
	
	public float growTime = 0;
	
	//
	public Transform plotObj;
	public string watered = "n";
	

    void Start()
    {
        
    }

    void Update()
    {
		// if something has been planted, record time
		//CHANGE plant_1 placeholder
		if (GetComponent<SpriteRenderer>().sprite == sprout){
			growTime += Time.deltaTime;
		}
        
		
		// change grow time (5 sec) placeholder
		if (growTime > 5) {
			// if watered the plant within 3 sec
			if (watered == "y"){
				//apple growth phase 1
				GetComponent<SpriteRenderer>().sprite = apple_1;
			} 
			
//			else if (){
//				//apple growth phase 1
//			}
			else {
			
				// if not watered within time frame, plant dies
				growTime = 0;
				GetComponent<SpriteRenderer>().sprite = noPlantObj;
				
			}
			
		}
		
    }
	
	void OnMouseDown(){
		Debug.Log("clicked on weed");
		
		//REPLACE TOOL NAME
		if(harvestScript.currentTool == "reap"){
			//Destroy (gameObject);
			GetComponent<SpriteRenderer>().sprite = noPlantObj;
		}
		
		if((harvestScript.currentTool == "seeds") && (GetComponent<SpriteRenderer>().sprite == noPlantObj))
		{
			GetComponent<SpriteRenderer>().sprite = apple_1;
		
		}
		
		if(harvestScript.currentTool == "bucket"){
			//Destroy (gameObject);
			//when water the plants, the color changes
			plotObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
			watered = "y";
		}
	}
}
