using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed, jumpSpeed;
    public Text countText, winText;

    private float jump;

    private int count;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetButton("Jump"))
        {
            jump = 1.0f;
        }
        else
        {
            jump = 0.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, jump*jumpSpeed, moveVertical);

        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
            
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count == 18)
        {
            winText.text = "You Win!";
        }
    }
    
}