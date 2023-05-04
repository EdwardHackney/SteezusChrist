using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    private Animator animator;

    private bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        } else
        {
            running = false;
        }

        animator.SetBool("Running", running);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float dx = transform.position.x - Camera.main.transform.position.x;
        float dz = transform.position.z - Camera.main.transform.position.z;

        Vector3 forwardMove = new Vector3(dx, 0.0f, dz).normalized * vertical;
        Vector3 rightMove = new Vector3(dz, 0.0f, -dx).normalized * horizontal;

        Vector3 move = forwardMove + rightMove;

        float runBoost = running ? 2.0f : 1.0f;

        move = move.normalized * maxSpeed * runBoost * Time.deltaTime;

        Vector3 worldMove = transform.TransformVector(move);

        transform.position += move;

        transform.LookAt(transform.position + move);

        animator.SetFloat("Speed", move.magnitude);
    }
}
