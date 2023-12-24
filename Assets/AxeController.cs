using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public float chopSuccessProbability;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            TryChopTree(other.gameObject);
        }
    }

    void TryChopTree(GameObject tree)
    {
        // Check if the chop is successful based on the probability
        Debug.Log(tree.GetComponent<Tree>());
        Tree treeController = tree.GetComponent<Tree>();
        treeController.TryChopTree(0.2f);
    }
}
