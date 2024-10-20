using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;

    private void Awake()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            button.SetActive(true);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
