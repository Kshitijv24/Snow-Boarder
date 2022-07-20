using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;

    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canMove == true)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControlls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }
}
