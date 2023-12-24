using System.Collections;
using System.Collections.Generic;
//using System.Collections.IDictionary;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int INVENTORY_SIZE = 28;
    private Item[] itemSlots = new Item[28];
    private GameObject[] objectSlots = new GameObject[28];
    private IDictionary<string, int> itemLookup = new Dictionary<string, int>();

    // Offset off the ground when item spawns from inventory.
    private Vector3 itemSpawnOffset = new Vector3(0,1,0);

    private int itemCount;
    void Start()
    {
        this.itemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(GameObject ob){
        Item item = ob.GetComponent<Item>();
        if(itemCount == INVENTORY_SIZE){
            return;
        }
        if(itemLookup.ContainsKey(item.itemName)){
            if (itemSlots[itemLookup[item.itemName]].stackable){
                itemSlots[itemLookup[item.itemName]].count += item.count;
                return;
            }
        }
        for(int i = 0; i < INVENTORY_SIZE; i++){
            if(itemSlots[i] == null){
                itemSlots[i] = item;
                objectSlots[i] = ob;
                Image image = gameObject.GetComponentsInChildren<Image>()[i+1];
                image.sprite = item.icon;
                break;
            }
        }
        itemCount++;
    }

    public void Remove(int i){
        RaycastHit hit;
        if(itemSlots[i] != null){
            itemLookup.Remove(itemSlots[i].itemName);
            itemSlots[i] = null;
            if(Physics.Raycast(transform.position, Vector3.down, out hit, 200.0f)){
                objectSlots[i].transform.position = hit.point + itemSpawnOffset;
                Debug.Log("down");
            }
            else if(Physics.Raycast(transform.position, Vector3.up, out hit, 200.0f)) {
                objectSlots[i].transform.position = hit.point + itemSpawnOffset;
                Debug.Log("up");
            }
            else{
                //TODO: This is buggy because raycast up does not work on terrain so we just spawn items way higher if the menu is below ground.
                 objectSlots[i].transform.position = transform.position + itemSpawnOffset * 3;
                 Debug.Log("other");
            }
            
            objectSlots[i].SetActive(true);
            objectSlots[i] = null;
            Image image = gameObject.GetComponentsInChildren<Image>()[i+1];
            image.sprite = null;
        }
    }
}

