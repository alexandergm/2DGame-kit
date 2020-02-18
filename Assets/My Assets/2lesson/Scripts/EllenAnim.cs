using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenAnim : MonoBehaviour
{
    private Rigidbody2D _rg;
    private Animator _anim;

    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        var speed = Mathf.Abs(_rg.velocity.magnitude);
        _anim.SetFloat("Speed", speed);


        if (Input.GetKeyDown(KeyCode.Space)) _anim.SetTrigger("Jump");
        if (Input.GetButtonDown("Fire1")) _anim.SetTrigger("Fire");
    }

}
