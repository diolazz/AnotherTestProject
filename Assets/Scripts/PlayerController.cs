using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    private float cameraLengthRay = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
	{
        MovePosition();
        LookAt();
	}

    public void MovePosition()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
    }

    public void LookAt()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
