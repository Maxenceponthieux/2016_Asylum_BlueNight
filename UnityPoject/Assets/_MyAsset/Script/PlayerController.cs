using UnityEngine;
using System.Collections;
/// 
/// Isometric world and player's movement.
/// 
public class PlayerController : MonoBehaviour
{

    Rigidbody Rbody;
    public float playerSpeed;
    Vector3 oldPos;    

    // Use this for initialization
    void Start()
    {
        Rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float velX = Input.GetAxis("Horizontal");
        float velY = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(velX, 0.0f, velY);
        vec = Quaternion.AngleAxis(45, Vector3.up) * vec;
        oldPos = transform.position;
        vec *= playerSpeed;

        if (Rbody != null)
        {
            vec.y = Rbody.velocity.y;
            Rbody.velocity = vec;
        }
        else
            transform.Translate(vec* Time.deltaTime, Space.World);

        if (Rbody != null)
        {
            if(Rbody.velocity.magnitude > 0.5f)
            {
                Vector3 lookAt = Rbody.velocity;
                lookAt.y = 0;
                transform.LookAt(transform.position + lookAt);
            }
        }
        else
        {
            Vector3 vel = transform.position - oldPos;
            if (vel.magnitude > 0.0f)
            {
                vel = vel + transform.position;
                transform.LookAt(vel);
            }
        }       
    }
}