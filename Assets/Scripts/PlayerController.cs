using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float moveSpeed;
    public float rotateSpeed;
    public Vector2 move;
    public Vector3 rotate;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); 
    }


    void Update()
    {
        float _moveInput = Input.GetAxis("Vertical");
        this.transform.Translate(move * Time.deltaTime * moveSpeed * _moveInput);

        if(_moveInput != 0)
        {
            float _rotateInput = Input.GetAxisRaw("Horizontal");
            this.transform.Rotate(rotate * Time.deltaTime * rotateSpeed * _rotateInput);
        }
        
        
    }
}
