using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource aud;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";


        aud = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
       string PinnedString = other.gameObject.GetComponent<Ui>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (PalindromeString(PinnedString) == true)
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
                aud.Play();
            }
           
        }
    }


    public bool PalindromeString(string input)
    {
        bool PinnedString = true;
        for (int i = 0; i < (input.Length / 2 + 1); i++)
        {
            if (!(input[i] == input[input.Length - i - 1]))
            {
                PinnedString = false;
                break;
            }  
        }
        return PinnedString;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
       
        if (count == 1)
        {
            winText.text = "1 Palindrome Taken";
        }


        if (count == 2)
        {
            winText.text = "2 Palindrome Taken";
        }

        if (count == 3)
        {
            winText.text = "3 Palindrome Taken";
        }

        if (count == 4)
        {
            winText.text = "4 Palindrome Taken";
        }

        if (count == 5)
        {
            winText.text = "5 Palindrome Taken";
        }

        if (count == 6)
        {
            winText.text = "6 Palindrome Taken";
        }

        if (count == 7)
        {
            winText.text = "7 Palindrome Taken";
        }
        if (count == 8)
        {
            winText.text = "8 Palindrome Taken";
        }

        if (count == 9)
        {
            winText.text = "9 Palindrome Taken";
        }

        if (count == 10)
        {
            winText.text = "10 Palindrome Taken";
        }
    }
}