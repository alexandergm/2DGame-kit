using UnityEngine;


public class GameOver : MonoBehaviour
{
    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(3);
        }
    }
}
