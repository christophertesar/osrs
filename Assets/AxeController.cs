using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public AudioClip chopSound;
    public AudioClip choppedDownSound;
    public float chopCooldown = 1f; // Adjust the cooldown time as needed
    public float chopSuccessProbability = 0.2f;

    private bool canChop = true;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // void Update()
    // {
    //     if (canChop)
    //     {
    //         StartChop();
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        if (canChop && other.CompareTag("Tree"))
        {
            StartChop(other.gameObject);
            //ChopTree(other.gameObject);
        }
    }

    void TryChopTree(GameObject tree)
    {
        // Check if the chop is successful based on the probability
        if (Random.value < chopSuccessProbability)
        {
            audioSource.PlayOneShot(choppedDownSound);
            ChopTree(tree);
        }
        else
        {
            //Debug.Log("Chop unsuccessful!");
        }
    }

    void StartChop(GameObject tree)
    {
        canChop = false;
        audioSource.PlayOneShot(chopSound);
        TryChopTree(tree);
        // Start a coroutine to handle the cooldown
        StartCoroutine(ChopCooldown());
    }

    void ChopTree(GameObject tree)
    {
        // Implement tree chopping logic here
        //tree.SetActive(false);
    }

    // Coroutine for the cooldown
    IEnumerator ChopCooldown()
    {
        yield return new WaitForSeconds(chopCooldown);
        canChop = true; // Allow chopping again after the cooldown
    }
}
