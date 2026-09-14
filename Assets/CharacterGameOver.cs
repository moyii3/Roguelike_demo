using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}
