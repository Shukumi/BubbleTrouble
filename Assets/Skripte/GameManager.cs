using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D BallRigid;
    public float kraft = 20.0f;
    private Vector3 velocity;
   //  Rigidbody2D BallRigid;
    void Start()
    {
      //  BallRigid = Ball.GetComponent<Rigidbody2D>();
        BallRigid.AddForce(transform.right * kraft);
    }

    // Update is called once per frame
    
    void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile(BallRigid, collision.contacts[0].normal);
        print("LUL");
    }


    private void ReflectProjectile(Rigidbody2D rb, Vector3 reflectVector)
    {
        velocity = Vector3.Reflect(velocity, reflectVector);
        print("LUXD");
        rb.velocity = velocity;
    }

    
    void Update()
    {
        
    }
}
