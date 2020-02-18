using UnityEngine;

public class NextLevel2 : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(2);
        }
    }
}
