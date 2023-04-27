using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceTraveled;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    public void ShowGameOverScreen()
    {
        gameMusic.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        distanceTraveled.text = Mathf.Ceil(player.distanceTraveled) + " Coins: " + player.collectedCoins;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}