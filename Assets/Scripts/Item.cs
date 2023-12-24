using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour{

    public string itemName = "null";

    public int count = 0;

    public bool stackable = false;

    public Sprite icon;

    public InventoryManager inventory;

    void Start(){

    }

    void Update(){

    }

    void Awake(){
        inventory = GameObject.FindObjectsOfType<InventoryManager>(true)[0];
        Debug.Log(inventory);
    }

    public void AddToInventory(){
        Debug.Log(inventory.GetComponent<InventoryManager>());
        inventory.Add(gameObject);
    }
}