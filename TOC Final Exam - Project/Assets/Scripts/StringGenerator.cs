using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StringGenerator : MonoBehaviour
{

   
    private Text SText;
    int j = 0;
    int RP = 0;
    string GeneratedString = "";

    void Start() 
    {
        SText = GetComponent<Text>();
    }


    public void CreateRandomString(int decider) 
    {

        string randomString = ""; 
       
     
        string[] characters = new string[] { "x", "m", "5" };
        int stringLength = Random.Range(9, 15);
        for (int i = 0; i <= stringLength; i++) 
        {
            randomString = randomString + characters[Random.Range(0, characters.Length)];

        }

       



        if (decider == 2) 
                          
        {

            var value = randomString; 
            var firstHalfLength = (int)(value.Length / 2); 
            var secondHalfLength = value.Length - firstHalfLength; 
            var splitPhone = new[]  
            {
                    value.Substring(0, firstHalfLength),
                     
                         value.Substring(firstHalfLength, secondHalfLength)
            };


            string FirstHalfofRandomS = splitPhone[0];

            string reverse = "";
            int Length = 0;

            Length = FirstHalfofRandomS.Length - 1;
            while (Length >= 0) 
            {
                reverse = reverse + FirstHalfofRandomS[Length]; 
                Length--; 
            }
            
            GeneratedString = FirstHalfofRandomS + reverse; 
        }
        else
        {
            GeneratedString = randomString;
        }

        SText.text =  GeneratedString ; 


    }

    void Update()
    {


        RP = Random.Range(1, 4);
        if (j == 0)
        { 
            CreateRandomString(RP); 
            j = 1;      
        }
    }




}