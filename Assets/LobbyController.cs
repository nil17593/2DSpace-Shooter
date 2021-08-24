using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button quit;
   
    private void Awake()
    {
        play.onClick.AddListener(LoadGame);
        quit = GetComponent<Button>();
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
