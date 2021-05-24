using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    const int maxLives = 3;
    public int lives;
    public int level = 0;

    public bool changeLevel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        changeLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0 && changeLevel)
        {
            changeLevel = false;
            SceneManager.LoadScene("GameOver");
        }
        if (level == 1 && changeLevel)
        {
            changeLevel = false;
            SceneManager.LoadScene("Level2");
        }
        if(level == 2 && changeLevel)
        {
            changeLevel = false;
            SceneManager.LoadScene("Level3");
        }
        if (level == 3 && changeLevel)
        {
            changeLevel = false;
            SceneManager.LoadScene("WinScene");
        }        
    }

    public void GetHit()
    {
        lives--;
    }

    public void GetHealed()
    {
        if(lives < maxLives)
        {
            lives++;
        }
    }
}
