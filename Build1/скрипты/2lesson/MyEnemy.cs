using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage = 1;

    public void Hurt(int damage)
    {
        _health -= damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<MyFirstScript>();
            player.Hurt(_damage);
        }
    }

        private void Die()
    {
        Destroy(gameObject);
    }

}
