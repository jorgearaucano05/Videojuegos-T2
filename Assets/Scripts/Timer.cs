using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int minutes;

    private int m, s;
    [SerializeField]
    private int seconds;
    [SerializeField]
    private Text timerText;

    private ScoreController scoreController;
    void Start()
    {
        scoreController = gameObject.GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTimer()
    {
        m = minutes;
        s = seconds;
        writeTimer(m,s);
        Invoke("updateTimer",1f);

    }

    public void stopTimer()
    {
        
    }

    private void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if(m==0)
            {
                
            }
            else
            {
                m--;
                s = 59;
            }
        }
        writeTimer(m,s);
        Invoke("updateTimer",1f);
    }

    private void writeTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.text=m.ToString()+":0"+s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }
    
    
}
