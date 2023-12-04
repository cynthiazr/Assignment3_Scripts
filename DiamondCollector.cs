using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DiamondCollector : MonoBehaviour
{
    private int diamonds = 0;

    [SerializeField] private TMP_Text diamondsText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
                if(collision.gameObject.tag == "Diamond")
        {
            SoundManager.PlaySound("PlayerCatch");
            diamonds++;

            diamondsText.text = "Diamonds: " + diamonds;

           // Debug.Log("Diamonds: " + diamonds);

            if(diamonds == 3) {
                Destroy(collision.gameObject);
                
                // Change to the next scene
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }

            Destroy(collision.gameObject);


        }
    }
}
