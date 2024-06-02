using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0;
    public TextMeshProUGUI killCounterText;
    public int killThreshold = 30;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        enemyKillCount++;

        if (enemyKillCount >= killThreshold)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
