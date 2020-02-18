using UnityEngine;

public class MyStairs : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 4;

    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _maxSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_maxSpeed);
            }
            else 
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
