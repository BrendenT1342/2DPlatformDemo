using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public int cigarCount = 0;
    public Text cigarText;
    

    void Start()
    {
        
    }

    void Update()
    {
        // Displays how many cigars the player collects.
        cigarText.text = "Cigars: " + cigarCount.ToString();
    }
    //When the player will collect a collectable item.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cigar"))
        {
            Destroy(collision.gameObject);
            cigarCount++;
            cigarText.text = "Cigars: " + cigarCount;
            Debug.Log("Cigar: " + cigarCount);
        }
    }
}
