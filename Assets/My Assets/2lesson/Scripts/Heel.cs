using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heel : MonoBehaviour
{
    private int Live = 1;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<MyFirstScript>();
            player.Heel(Live);
            Die();
        }
    }
        private void Die()
        {
           Destroy(gameObject);
        }
    

}
