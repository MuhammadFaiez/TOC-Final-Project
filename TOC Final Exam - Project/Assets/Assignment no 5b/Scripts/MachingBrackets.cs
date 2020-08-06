using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MachingBrackets : MonoBehaviour
{
    GameObject collecttible;
    Vector3 position;
    private Text thisText;
    static string[] validandnotvalids = new string[100];
    static public System.Random rand = new System.Random();
    public static Random random = new Random();
    private static System.Random newrandom = new System.Random();


    void Start()
    {
        collecttible = GameObject.FindGameObjectWithTag("Pick Up");
        string balanced, notbalanced;
        int balancedBracketSpawned = 0;
        int notbalancedBracketSpawned = 0;

        while (balancedBracketSpawned < 12)
        {
            balanced = RandomString(rand.Next(9, 15));
            if (IsBalanced(balanced))
            {
                position = new Vector3(Random.Range(-70, 86f), 8.0f, Random.Range(36, 120));
                GameObject newobject;
                newobject = Instantiate(collecttible, position, Quaternion.identity);
                newobject.GetComponent<Ui>().nameLable.text = balanced;
                balancedBracketSpawned++;

            }
        }
        while (notbalancedBracketSpawned < 23)
        {
            notbalanced = RandomString(rand.Next(9, 15));
            if (!IsBalanced(notbalanced))
            {               
                position = new Vector3(Random.Range(-70, 86f), 8.0f, Random.Range(36, 120));
                GameObject newobject;
                newobject = Instantiate(collecttible, position, Quaternion.identity);
                newobject.GetComponent<Ui>().nameLable.text = notbalanced;
                notbalancedBracketSpawned++;

            }
        }
        collecttible.active = false;
    }

    void Update()
    {

    }
    public static string RandomString(int length)
    {
        const string chars = "(xm5)";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[newrandom.Next(s.Length)]).ToArray());
    }

    public static bool IsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
            { '<', '>' }
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            foreach (char c in input)
            {            
                if (bracketPairs.Keys.Contains(c))
                {                
                    brackets.Push(c);
                }
                else               
                    if (bracketPairs.Values.Contains(c))
                {                  
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else                    
                        return false;
                }
                else                 
                    continue;
            }
        }
        catch
        {          
            return false;
        }        
        return brackets.Count() == 0 ? true : false;
    }

}
