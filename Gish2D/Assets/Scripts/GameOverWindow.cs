using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    private GameMaster gm;
    public Text text;

    private void Awake()
    {
        instance = this;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.Find("Retry").GetComponent<Button_UI>().ClickFunc = () => {SceneManager.LoadScene("SampleScene");};

        Hide();
    }

    public void Update()
    {
        text = gm.pointsText;
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