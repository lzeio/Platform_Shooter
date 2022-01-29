using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float jumpForce,moveForce;
    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    GameObject bulletPrefab;
    int direction = 1;

    [SerializeField]
    Text gameTask;
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
            direction = -1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(-moveForce * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(moveForce * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&Grounded())
        {
       
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
            bulletObject.transform.position = new Vector3(this.transform.position.x + direction, this.transform.position.y, this.transform.position.z);

            BulletController bullet = bulletObject.GetComponent<BulletController>();
            bullet.direction = direction;   
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

        if(other.tag=="Orb")
        {
            Time.timeScale = 0;
            gameTask.text = "Press R to Restart.";

        }
    }
}
