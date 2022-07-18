using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;

    private Rigidbody2D rb;

	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
