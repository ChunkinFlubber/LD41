using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Text TextGameOver;
    [SerializeField]
    GameObject PanelGameOver;

    float gameOverFadeTimer = 60.0f;
    float gameOverFadeInc;
    bool isGameOver = false;

    void Start ()
    {
		gameOverFadeInc = 1.0f / gameOverFadeTimer;
        // Set game over text's alpha to 0.
        Color c = TextGameOver.color;
        c.a = 0;
        TextGameOver.color = c;
    }
	
	void Update ()
    {
        // Check if player has died.
		if (!isGameOver
            && !Player.GetComponent<PlayerController>().GetIsAlive())
        {
            isGameOver = true;
        }
        // Fade-in game over screen.
        if (isGameOver)
        {
            // Set game over UI components to active.
            if (!PanelGameOver.activeSelf)
            {
                PanelGameOver.SetActive(true);
                Color c = TextGameOver.color;
                c.a = 1;
                TextGameOver.color = c;
            }
            // Update panel's alpha.
            if (PanelGameOver.GetComponent<Image>().color.a < 1)
            {
                Color c = PanelGameOver.GetComponent<Image>().color;
                c.a = Mathf.Min(c.a + gameOverFadeInc, 1);
                PanelGameOver.GetComponent<Image>().color = c;
            }
        }
	}
}
