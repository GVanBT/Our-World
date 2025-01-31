using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpSystem : MonoBehaviour
{
    private int Collectible = 0;

    public TextMeshProUGUI CollectibleText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Collectible")
        {
            Collectible++;
            CollectibleText.text = "Burgers collected: " + Collectible.ToString();
            Debug.Log(Collectible);
            Destroy(other.gameObject);
        }
    }
}
