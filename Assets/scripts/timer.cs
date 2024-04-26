using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI num;

    void Start()
    {
        time = 5f;
    }
    void Update()
    {
        if (time > 0)
        {
            TimeSpan tm = TimeSpan.FromSeconds(time);
            num.text = Mathf.Round(time).ToString();
            time -= Time.deltaTime;

            if (time <= 0)
            {
                Destroy(num);
                SceneManager.LoadScene("SampleScene");
            }
        }
        else
        {
            time = 0;
        }
        
    }

}
