using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantControl : MonoBehaviour
{
    public Sprite noPlantObj;
    public Sprite sprout;

    //[SerializeField] public GameObject plantedPrefab;
    //public GameObject _planted;
    
    public Sprite planted;
    // apple
    public Sprite apple_1;
    public Sprite apple_2;

    // cranberry 
    public Sprite cranberry_1;
    public Sprite cranberry_2;

    //grape
    public Sprite grape_1;
    public Sprite grape_2;

    // parsnip
    //public Sprite parsnip_1;
    [SerializeField] public GameObject parsnip1Prefab;
    public GameObject _parsnip1;
    public Sprite parsnip_2;
    
    //artichoke
    public Sprite artichoke_1;
    public Sprite artichoke_2;


    public float growTime = 0;
    //public float plant_pos_x =-7;
    //public double plant_pos_y = -2.5;
    //public float plant_pos_z = 0;
    //
    public Transform plotObj;
    public string watered = "n";


    public string currentSeed;

    void Start()
    {

    }

    void Update()
    {

       



        ///////////////////////////////////////
        // if something has been planted, record time
        
		if (GetComponent<SpriteRenderer>().sprite == planted){
			growTime += Time.deltaTime;
		}
        
       /*
        if (GetComponent<GameObject>() == plantedPrefab)
        {
            growTime += Time.deltaTime;
        }
        */

        if (growTime > 5)
        {
            _parsnip1 = Instantiate(parsnip1Prefab) as GameObject;
            _parsnip1.transform.position = new Vector3(-7, -3, 0);
      
            //GetComponent<SpriteRenderer>().sprite = parsnip_1;

            //GetComponent<plantControl>().GetComponent <SpriteRenderer>().parsnip_1.transform.scale = 

            //GetComponent<SpriteRenderer>().sprite = planted;
        }
        
        /*
        // change grow time (5 sec) placeholder
        if (growTime > 5)
        {
            // if watered the plant within 5 sec
            if (watered == "y")
            {
                //apple growth phase 1
                GetComponent<SpriteRenderer>().sprite = apple_1;
            }

            //			else if (){
            //				//apple growth phase 2
            //			}
            else
            {

                // if not watered within time frame, plant dies
                growTime = 0;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;

            }

        }
        */

    }

    void OnMouseDown()
    {


        //REPLACE TOOL NAME
        if (harvestScript.currentTool == "reap")
        {
            //Destroy (gameObject);
            GetComponent<SpriteRenderer>().sprite = noPlantObj;
        }


        if ((harvestScript.currentTool == "seeds")) //&& (GetComponent<SpriteRenderer>().sprite == noPlantObj))
        {
            GetComponent<SpriteRenderer>().sprite = planted;
            //_planted = Instantiate(plantedPrefab) as GameObject;
        }

        if (harvestScript.currentTool == "bucket")
        {
            //Destroy (gameObject);
            //when water the plants, the plot color changes
            plotObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            watered = "y";
        }
    }
}
