using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Particles;

    public void OnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Sike()
    {
        Particles.GetComponent<ParticleSystem>().Play();
    }
}
