using UnityEngine;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 6f;
    [SerializeField] private float _exploseArea = 1f;
    [SerializeField] private bool _isForward;
    [SerializeField] private int _force = 50;
    [SerializeField] private int _health = 15;
    [SerializeField] private int _damage = 1;
    [SerializeField] private LayerMask _mask;
    public float seeDistance = 2f;
    public float speed = 6f;
    public Transform target;

    private Collider2D _isDetected;
    private ContactFilter2D _contactFilter;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        _contactFilter = new ContactFilter2D();
        _contactFilter.layerMask = _mask;
        _contactFilter.useLayerMask = true;
    }
    private void FixedUpdate()
    {
        _isDetected = Physics2D.OverlapCircle(transform.position, _detectionRadius, _mask);
        if (_isDetected) Explose();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            Vector3 delta = target.position - transform.position;
            delta.Normalize();
            float moveSpeed = speed * Time.deltaTime;
            transform.position = transform.position + (delta * moveSpeed);
        }

        else
        {
        }

        if (gameObject.transform.position.x < target.transform.position.x && !_isForward) Flip();
        if (gameObject.transform.position.x > target.transform.position.x && _isForward) Flip();

        void Flip()
        {
            _isForward = !_isForward;
            Vector3 curRot = transform.rotation.eulerAngles;
            curRot.y += 180;
            transform.rotation = Quaternion.Euler(curRot);
        }

    }
    public void Hurt(int damage)
    {
        _health -= damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Application.LoadLevel(4);
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

            var script = e.gameObject.GetComponent<MyFirstScript>();
            script.Hurt(_damage);
        }
    }



}

