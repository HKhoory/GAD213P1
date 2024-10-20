using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject controls;
    [SerializeField] private float disappear;

    private void Awake()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        disappear -= Time.deltaTime;

        if (disappear < 0)
        {
            controls.SetActive(false);
        }

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
