using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAmmo : MonoBehaviour
{
     float _speedAmmo = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speedAmmo * Time.deltaTime);

        if(transform.position.y > 5.5f)
        {
            Destroy(gameObject);
            //Destroy(GetComponent<Rigidbody>());
        }

    }
}
