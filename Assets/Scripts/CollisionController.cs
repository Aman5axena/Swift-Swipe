using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    // public GameController _gameController;
    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            // Panel.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
