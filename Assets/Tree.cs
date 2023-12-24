using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canChop = true;
    private AudioSource audioSource;
    public AudioClip chopSound;
    public AudioClip choppedDownSound;
    public float chopCooldown = 1f; // Adjust the cooldown time as needed
    public float treeFelledCooldown = 5f;
    public GameObject logs; 

    private float raycastDistance = 200f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryChopTree(float chopSuccessProbability){
        if(!canChop){
            return;
        }

        canChop = false;
        audioSource.PlayOneShot(chopSound);

        if (Random.value < chopSuccessProbability)
        {
            ChopTree();
        }
        else{
            ChopTreeFail();
        }
        
    }

    IEnumerator ChopCooldown(float chopCooldown)
    {
        yield return new WaitForSeconds(chopCooldown);
        canChop = true; // Allow chopping again after the cooldown
    }

    void ChopTree(){
        audioSource.PlayOneShot(choppedDownSound);
        RaycastHit hit;
        float spawnPointX = Random.Range(-2f,2f);
        float spawnPointZ = Random.Range(-2f,2f);
        Vector3 raycastPoint = new Vector3(transform.position.x + spawnPointX, transform.position.y + 5f, transform.position.z + spawnPointZ);
        if(Physics.Raycast(raycastPoint, Vector3.down, out hit, raycastDistance)){
            Instantiate(logs, hit.point, Quaternion.identity);
        }
        else{
            Debug.LogError("Raycast did not hit any terrain to find spawn point!");
        }
        
        StartCoroutine(ChopCooldown(treeFelledCooldown));
    }

    void ChopTreeFail(){
         StartCoroutine(ChopCooldown(chopCooldown));
    }
}
