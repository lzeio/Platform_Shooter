using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int direction = 1;

    public float bulletForce;

    public float lifeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(bulletForce * direction*Time.deltaTime, 0, 0);

        lifeTime -= Time.deltaTime;
        if(lifeTime<=0)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Obstacle")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
