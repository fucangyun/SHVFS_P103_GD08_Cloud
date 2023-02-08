using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float mouseX;
    private float mouseY;
    [SerializeField]
    private float m_moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rb.velocity = transform.TransformVector(new Vector3((m_moveSpeed * Input.GetAxis("Horizontal")), rb.velocity.y, (m_moveSpeed * Input.GetAxis("Vertical"))));
    }
}
