using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class Utility
{
    public static float Distance(float a, float b)    //measured die distance zwischen 2 zahlen
    {
        return Mathf.Abs(a - b);
    }

    public static float Distance(Vector3 a, Vector3 b)  //same thing for vectors
    {
        return (a - b).magnitude;
    }

    public static bool AreSimilar(float a, float b, float tolerance)    //sind die zwei zahlen similar? 
    {
        bool result = Distance(a, b) <= tolerance ? true : false;
        return result;
    }

    public static void ChangeText(GameObject textObject, string textString)    //ändert den text. Überraschend, nicht wahr?
    {
        Text text = textObject.GetComponent<Text>();
        text.text = textString;
    }

    public static void TMPChangeText(GameObject textObject, string textString)  //ändert den text für textmeshpro
    {
        textObject.GetComponent<TextMeshProUGUI>().text = textString;
    }

    public static IEnumerator FlowText(GameObject textObject, char[] letters, float pauseBetweenLetters)    //flowing text statt alles auf einmal
    {
        Text text = textObject.GetComponent<Text>();
        text.text = null;

        foreach (char letter in letters)
        {
            text.text = text.text + letter;
            yield return new WaitForSeconds(pauseBetweenLetters);
        }
    }

    public static IEnumerator TMPFlowText(GameObject textObject, char[] letters, float pauseBetweenLetters)     //flowing text f�r TMP
    {
        TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
        text.text = null;

        foreach (char letter in letters)
        {
            text.text = text.text + letter;
            yield return new WaitForSeconds(pauseBetweenLetters);
        }
    }

    public static float Percent(float percentage, float hundredPercent)    //Gibt dir den Prozent von zwei Sachen           
    {
        return percentage / hundredPercent * 100;
    }

    public static float ExponentialfunktionNährtSichKonstante(float konstante, float x)    //Funktion nährt sich Konstante an, erreicht sie aber net. Dividier x um die Kurve langsamer zu machen
    {
        return konstante - (konstante * Mathf.Exp(-x));
    }

    public static int ArrayEnthältZahl(int[] array, int zahl)   //checkt, ob ein array ein eine zahl enth�lt, wenn nicht, wird -1 returned
    {
        for (int i = 0; i > array.Length; i++)
        {
            if (array[i] == zahl)
            {
                return i;
            }
        }

        return -1;
    }

    public static int ArrayEnthältZahl(float[] array, float zahl)   //checkt, ob ein array ein eine zahl enth�lt, wenn nicht, wird -1 returned
    {
        for (int i = 0; i > array.Length; i++)
        {
            if (array[i] == zahl)
            {
                return i;
            }
        }

        return -1;
    }

    public static bool Coinflip()
    {
        bool heads = Random.Range(0, 2) == 0 ? true : false;
        return heads;
    }       //50/50 chance dass ne true-bool rauskommt

    public static bool OneIn(int n)
    {
        bool oneIn = Random.Range(0, n) == 0 ? true : false;
        return oneIn;
    }

    public static bool OneIn(float n)
    {
        bool oneIn = Random.Range(0, n) < 1 ? true : false;
        return oneIn;
    }

    public static int RandomFromArray(object[] array)
    {
        return Random.Range(0, array.Length);
    }

    public static float NormalizeAngle(float angle)
    {
        while (true)
        {
            if (angle < 180 && angle > -180)
            {
                //...
            }
            else
            {
                angle += angle < 0f ? 360 : -360;
            }

            return angle;
        }
    }

    public static float CreateBellCurve(float minValue, float maxValue)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;

        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }

}
