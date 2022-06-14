using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBarrel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Gamestats>().CollectBarrel();
            gameObject.SetActive(false);
        }
    }
}
