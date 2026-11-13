using UnityEngine;

public class PlayerMovemnt3D : MonoBehaviour
{

    public float movespeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * movespeed * Time.fixedDeltaTime);
    }

}