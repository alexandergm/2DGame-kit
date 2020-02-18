using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{

    [SerializeField] private float _maxSpeed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private bool _isForward;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private int _extraJumpsValue;
    [SerializeField] private int _health;
    GameObject [] prefHearts;
    private int extraJumps;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;

    public void Hurt(int damage)
    {
        _health -= damage;

        var sprite = gameObject.GetComponent<SpriteRenderer>();
        

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heel(int Live)
    {

        if (_health < 3)
        {
            _health += Live;
        }
        else if (_health >= 3)
        {
            _health = _health;
        }
              
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = _extraJumpsValue;
        prefHearts = GameObject.FindGameObjectsWithTag("Heart");
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, checkRadius, whatIsGround);
        float h = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb.velocity.x) < _maxSpeed)
            {
            rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            }
        else if (Mathf.Abs(rb.velocity.x) > _maxSpeed)
        {
            var curSpeed = rb.velocity;
            curSpeed.x = Mathf.Sign(rb.velocity.x) * _maxSpeed;
            rb.velocity = curSpeed;
        }
        if (h > 0 && !_isForward) Flip();
        if (h < 0 && _isForward) Flip();

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
        }
        if (_isGrounded == true)
        {
            extraJumps = _extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0) 
        {
            rb.velocity = Vector2.up * _jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && _isGrounded == true)
            {
                 rb.velocity = Vector2.up * _jumpForce * Time.deltaTime;
            }

        if (_health == 3)
        {
            prefHearts[0].SetActive(true);
            prefHearts[1].SetActive(true);
            prefHearts[2].SetActive(true);
        }
        if (_health == 2)
        {
            prefHearts[2].SetActive(false);
          
        }
        else if (_health == 1)
        {
            prefHearts[2].SetActive(false);
            prefHearts[1].SetActive(false);
        }
        
    }

    private void Die()
        {
        prefHearts[0].SetActive(false);
        prefHearts[1].SetActive(false);
        prefHearts[2].SetActive(false);
        Destroy(gameObject);
        }


    

    void Flip()
    {
        _isForward = !_isForward;
        Vector3 curRot = transform.rotation.eulerAngles;
        curRot.y += 180;
        transform.rotation = Quaternion.Euler(curRot);
    }


}