using UnityEngine;

public class MyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _lifeTime = 4;
    [SerializeField] private int _damage = 1;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        //GetComponent<Rigidbody2D>().AddForce(transform.right * _speed, ForceMode2D.Impulse);
    }

    public void SetDamage(int damage)
    {
        //_damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += CalculateSpeed(_speed);
    }

    private Vector3 CalculateSpeed(float dir)
    {
        return transform.right * Time.deltaTime * dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }

        if (!collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
}
