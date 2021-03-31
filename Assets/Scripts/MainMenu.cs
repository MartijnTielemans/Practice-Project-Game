using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public AudioSource clickSound;

    public void LoadScene()
    {
        clickSound.Play();
        SceneManager.LoadScene(sceneToLoad);
    }

    public IEnumerator Exit()
    {
        clickSound.Play();
        yield return new WaitForSeconds(1);

        Application.Quit();
    }
}
