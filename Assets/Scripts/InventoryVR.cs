// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    public float distance = 0.5F;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.3F;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }
        if (UIActive)
        {
            //Inventory.transform.position = Anchor.transform.position;
            Vector3 targetPosition = Anchor.transform.TransformPoint(new Vector3(0, 0, distance));
            Inventory.transform.position = Vector3.SmoothDamp(Inventory.transform.position, targetPosition, ref velocity, smoothTime);
            Vector3 lookAtPos = new Vector3(Anchor.transform.position.x, transform.position.y, Anchor.transform.position.z);
            Inventory.transform.LookAt(lookAtPos);
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x, Anchor.transform.eulerAngles.y, 0);
        }
    }
}