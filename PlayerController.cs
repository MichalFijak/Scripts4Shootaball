using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float moveSpeed = 1.0f; // to change later
    public float moveRotate = 150.0f; // to change later
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

    }

    void PlayerMove()
    {
        float rotationalInput = Input.GetAxis("Rotational");

 
        transform.Rotate(Vector3.up * moveRotate * rotationalInput*Time.deltaTime);
 
        
    }


}
