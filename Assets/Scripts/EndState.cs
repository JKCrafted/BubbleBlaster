using NUnit.Framework;
using TMPro;
using UnityEngine;

public class EndState : MonoBehaviour
{
    private TextMeshProUGUI ending;
    private TextMeshProUGUI score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(TextMeshProUGUI item in FindObjectsOfType<TextMeshProUGUI>())
        {
            if (item.gameObject.name.Contains("Score"))
            {
                score = item;
            }
            else if (item.gameObject.name.Contains("Ending"))
            {
                ending = item;
            }
        }

    }

    // Update is called once per frame
    void GameEnd()
    {
        
    }
}
