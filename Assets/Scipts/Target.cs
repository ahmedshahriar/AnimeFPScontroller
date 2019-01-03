using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public float health = 0f;
    public GameObject destroyedVersion;


    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("hello"+ gameObject +" "+health);
        if (health<=0)
        {
            Die();
        }

    }
    public void Die()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
