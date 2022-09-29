using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void Switch()
    {
        SceneManager.LoadScene(sceneName);
    }
}
