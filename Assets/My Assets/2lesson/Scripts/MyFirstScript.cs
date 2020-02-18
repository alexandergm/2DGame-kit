using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public LayerMask whatIsGround;
    public float checkRadius;
    public GameObject[] prefHearts;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isForward;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private int _extraJumpsValue;
    [SerializeField] private int _health;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private Transform _groundMine;

    private int extraJumps;
    private Rigidbody2D rb;
    private Animator _anim;

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
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, checkRadius, whatIsGround);
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * _maxSpeed, rb.velocity.y);
        _anim.SetBool("IsGrounded", _isGrounded);

        // if (h != 0) transform.position += Vector3.right * h * _maxSpeed * Time.deltaTime;
        //if (Mathf.Abs(rb.velocity.x) < _maxSpeed)
        //{
        //    rb.AddForce(Vector2.right * h , ForceMode2D.Impulse);
        //}
        //else if (Mathf.Abs(rb.velocity.x) > _maxSpeed)
        //{
        //    var curSpeed = rb.velocity;
        //    curSpeed.x = Mathf.Sign(rb.velocity.x) * _maxSpeed;
        //    rb.velocity = curSpeed;
        //}

        if (h > 0 && !_isForward) Flip();
        if (h < 0 && _isForward) Flip();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(_mine, _groundMine.position, _groundMine.rotation);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
        }
        if (_isGrounded == true)
        {
            extraJumps = _extraJumpsValue;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * _jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && _isGrounded == true)
        {
            rb.velocity = Vector2.up * _jumpForce * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
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
        Application.LoadLevel(3);
    }




    void Flip()
    {
        _isForward = !_isForward;
        Vector3 curRot = transform.rotation.eulerAngles;
        curRot.y += 180;
        transform.rotation = Quaternion.Euler(curRot);
    }


}  
