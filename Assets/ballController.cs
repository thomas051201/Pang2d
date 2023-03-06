using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    float _size =0, _life =0 ;
    float MAX_SIZE;
    PhysicsMaterial2D myPhysicMaterial;

    // Start is called before the first frame update
    void Start()
    {
        int rdn = Random.Range(0, 2);
        float rndForceX = (rdn == 0) ? -60 : 60;
        myPhysicMaterial = new PhysicsMaterial2D
        {
            bounciness = 1.0f,
            friction = 0.0f
        };
        gameObject.GetComponent<CircleCollider2D>().sharedMaterial = myPhysicMaterial; //permet les rebond  
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(rndForceX, 20f, 0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(float size, string name)
    {
        _size = size;
        _life = (_size + 1) * 20f;
        int rdn = Random.Range(0, 2);
        float rndForceX = (rdn == 0) ? -600 : 600;

        gameObject.transform.localScale *= (_size / MAX_SIZE);

        myPhysicMaterial = new PhysicsMaterial2D
        {
            bounciness = 1.0f,
            friction = 0.0f
        };
        gameObject.GetComponent<CircleCollider2D>().sharedMaterial = myPhysicMaterial; //permet les rebond
    }
}
