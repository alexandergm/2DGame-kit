using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecretBlocks : MonoBehaviour
{
    [SerializeField] private GameObject _secretGround;
    [SerializeField] private Transform _spawnPoint2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_secretGround, _spawnPoint2.position, _spawnPoint2.rotation);
        }
    }
}