using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    //private Text scoreText;
    private static GameOverWindow instance;

    //public Text text;

    private void Awake()
    {
        //scoreText = transform.Find("scoreText").GetComponent<Text>();
        instance = this;

        transform.Find("Retry").GetComponent<Button_UI>().ClickFunc = () => {
            SceneManager.LoadScene("SampleScene");
        };

        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }
}

//            SceneManager.LoadScene("SampleScene"); rad 54