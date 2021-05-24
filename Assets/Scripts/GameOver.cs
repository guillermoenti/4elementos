using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Particles;
    [SerializeField] Text hehe;

    bool is_hehe;
    float timer;

    private void Start()
    {
        hehe.enabled = false;
        is_hehe = false;
        timer = 0;

        Destroy(GameManager.Instance);
        Destroy(GameObject.Find("GameManager"));
    }

    private void Update()
    {
        if (is_hehe)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                is_hehe = false;
                hehe.enabled = false;
                timer = 0;
            }
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Sike()
    {
        Instantiate(Particles, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

        is_hehe = true;
        hehe.enabled = true;
    }
}
