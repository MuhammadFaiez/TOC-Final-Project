using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource audio;
    private Rigidbody rigb;
    private int count;

    void Start()
    {
        rigb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";


        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        string PinnedString = other.gameObject.GetComponent<Ui>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (CheckForBalanced(PinnedString) == true)
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
                audio.Play();
            }

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        switch (count)
        {

            case 1:
                winText.text = " 1 balanced bracket picked";
              

                break;

            case 2:
                winText.text = "2 balanced brackets picked";

                break;
            case 3:
                winText.text = "3 balanced brackets picked";

                break;
            case 4:
                winText.text = "4 balanced brackets picked";

                break;
            case 5:
                winText.text = "5 balanced brackets picked";

                break;
            case 6:
                winText.text = "6 balanced brackets picked ";

                break;
            case 7:
                winText.text = "7 balanced brackets picked";

                break;
            case 8:
                winText.text = "8 balanced brackets picked";

                break;
            case 9:
                winText.text = "9 balanced brackets picked";

               break;
            case 10:
                winText.text = "10 balanced brackets picked";

                break;
            case 11:
                winText.text = "11 balanced brackets picked";

                break;
            case 12:
                winText.text = "Congratulations, you picked all the 12 balanced brackets";
                
              

                break;
        }
    }


    static public bool CheckForBalanced(string PinnedString)
    {
   
        const char LeftParenthesis = '(';
        const char RightParenthesis = ')';
        uint BracketCount = 0;

        try
        {
            checked 
            {
                for (int Index = 0; Index < PinnedString.Length; Index++)
                {
                    switch (PinnedString[Index])
                    {
                        case LeftParenthesis:
                            BracketCount++;
                            continue;
                        case RightParenthesis:
                            BracketCount--;
                            continue;
                        default:
                            continue;
                    } 

                }
            }
        }

        catch (OverflowException)
        {
            return false;
        }

        if (BracketCount == 0)
        {
            return true;
        }

        return false;

    } 



}
