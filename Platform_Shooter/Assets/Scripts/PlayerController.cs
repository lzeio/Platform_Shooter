using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float jumpForce,moveForce;
    [SerializeField]
    LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        Debug.Log(Grounded());
        
    }

    void PlayerInput()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-moveForce * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(moveForce * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&Grounded())
        {
       
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    bool Grounded()
    {
        bool isgrounded = Physics.CheckSphere(transform.position, 0.5f, groundMask);
        return isgrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Obstacle")
        {
            this.gameObject.SetActive(false);
        }
    }
}
