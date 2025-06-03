using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<int> number = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

        number.Add(1);
        number.Add(3);
        number.Add(2);
        number.Add(4);
        number.Add(0);
        number.Sort();
        foreach (var item in number)
        {
            System.Console.WriteLine(item);
        }

    }



    // Update is called once per frame
    void Update()
    {

        var result = sorten(number[2], number[4]);
    }


    static int sorten(int x, int y)
    {
        return x.CompareTo(y);

    }
}
