using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject textObject;
    public string level;
    public Button button;

    // Use this for initialization
    void Start()
    {
        Text title = textObject.GetComponent<Text>();
        title.font.material.mainTexture.filterMode = FilterMode.Point;
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        //Application.LoadLevel(level);
        SceneManager.LoadScene(level);
    }
}