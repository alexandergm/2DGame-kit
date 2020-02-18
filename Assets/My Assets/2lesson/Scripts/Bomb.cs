using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _exploseArea;
    [SerializeField] private int _damage;
    [SerializeField] private int _force;
    [SerializeField] private LayerMask _mask;


    private Collider2D _isDetected;
    private ContactFilter2D _contactFilter;



    void Start()
    {
        _contactFilter = new ContactFilter2D();
        _contactFilter.layerMask = _mask;
        _contactFilter.useLayerMask = true;
    }

    private void FixedUpdate()
    {
        _isDetected = Physics2D.OverlapCircle(transform.position, _detectionRadius, _mask);
        if (_isDetected) Explose();
    }

    private void Explose()
    {
        List<Collider2D> result = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, _exploseArea, _contactFilter, result);

        foreach (Collider2D e in result)
        {
            Vector3 dir = e.transform.position - transform.position;
            var forceDir = dir.normalized;

            var rg = e.gameObject.GetComponent<Rigidbody2D>();
            rg.AddForce(forceDir * _force, ForceMode2D.Impulse);

            var script = e.gameObject.GetComponent<EnemyWalk>();
            script.Hurt(_damage);
        }
        Destroy(gameObject);
    }



}