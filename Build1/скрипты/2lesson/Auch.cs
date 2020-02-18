using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Auch : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<MyFirstScript>();
            player.Hurt(_damage);
        }
    }
}
