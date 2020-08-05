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
        /*******************************************************************
         * The easiest way to check for balanced bracketing is to start    *
         * counting left to right adding one for each opening bracket, '(' *
         * and subtracting 1 for every closing bracket, ')'.  At the end   *
         * the sum total should be zero and at no time should the count    *
         * fall below zero.                                                *
         *                                                                 *
         * Implementation:  The bracket counting variable is an unsigned   *
         * integer and we trap an overflow exception.  This happens if the *
         * unsigned variable ever goes negative.  This allows us to abort  *
         * at the very first imbalance rather than wasting time checking   *
         * the rest of the characters in the string.                       *
         *                                                                 *
         * At the end all we have to do is check to see if the count       *
         * is equal to zero for a "balanced" result.                       *
         *                                                                 *
         *******************************************************************/
        const char LeftParenthesis = '(';
        const char RightParenthesis = ')';
        uint BracketCount = 0;

        try
        {
            checked  // Turns on overflow checking.
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
                    }  // end of switch()

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

    }  // end of CheckForBalancedBracketing()



}
