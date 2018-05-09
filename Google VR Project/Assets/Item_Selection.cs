using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Item_Selection : MonoBehaviour {

    enum itemName {Banana, Book, Lego, SoccerBall, Hammer, WiiController, COUNT };

    int select = -1;

    public GameObject messageObject;

    public string selectedItem = "Banana"; 
    //public itemName selected = itemName.Banana;

    public void Reset()
    {
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        for (int i = 0; i < numSibs; i++)
        {
            GameObject sib = transform.parent.GetChild(i).gameObject;
            //sib.transform.localPosition = startingPosition;
            sib.SetActive(i == sibIdx);
        }
    }

    public void moveScene()
    {
        SceneManager.LoadScene(1);
    }

    public void objectSelected()
    {
        Debug.Log("Myself: " + gameObject.name);
        Debug.Log("Selected: " + selectedItem);


        if (gameObject.name == selectedItem)
        {
            Debug.Log("Choosing new item");
            // Pick a random sibling, move them somewhere random, activate them,
            // deactivate ourself.
            int sibIdx = transform.GetSiblingIndex();
            int numSibs = transform.parent.childCount;
            sibIdx = (sibIdx + UnityEngine.Random.Range(1, numSibs)) % numSibs;
            GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;
            randomSib.GetComponent<Item_Selection>().selectedItem = randomSib.name;
            Debug.Log("Random Sib: " + randomSib.name);
            selectedItem = randomSib.name;

            Text textObject = messageObject.GetComponent<Text>();

            textObject.text = randomSib.name;
            
        }
        // Move to random new location ±100º horzontal.
        /*
        Vector3 direction = Quaternion.Euler(
            0,
            UnityEngine.Random.Range(-90, 90),
            0) * Vector3.forward;
        */
        // New location between 1.5m and 3.5m.
        //float distance = 2 * UnityEngine.Random.value + 1.5f;
        //Vector3 newPos = direction * distance;
        // Limit vertical position to be fully in the room.
        //newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
        //randomSib.transform.localPosition = newPos;

        //randomSib.SetActive(true);
        //gameObject.SetActive(false);
        //SetGazedAt(false);
    }

    /*
    public void selectBanana()
    {
        Debug.Log("Click on Banana");
        checkSelected(itemName.Banana);
        
    }

    private void checkSelected(itemName selObject)
    {
        //throw new NotImplementedException();
        if (selected == selObject)
        {
            Debug.Log("Found Correct Object");
            resetItem();
        }

    }

    public void resetItem()
    {
        selected = (itemName)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(itemName)).Length));

        Debug.Log("New Object: " + selected);
    }
    */

    // Use this for initialization
    void Start () {
        //messageObject.text = "Thingy";
        messageObject = GameObject.Find("ObjectToSelectText");
        //messageObject = transform.parent.Find("ObjectMessage/ObjectToSelectText");  
        Debug.Log(messageObject.name);
        //Debug.Log("Object: " + selected);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
