using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void Alice()
    {
        SceneManager.LoadScene("Alice");
    }

    public void Bob()
    {
        SceneManager.LoadScene("Bob");
    }
    public void MenuBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
