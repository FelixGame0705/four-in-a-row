using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Button")]
    [SerializeField] Button BtnNewGame;
    [SerializeField] Button BtnResume;
    [SerializeField] Button BtnBackToMainMenu;
    [Header("Menu Object")]
    [SerializeField] GameObject MenuPlayer; 
    void Start()
    {
        BtnNewGame.onClick.AddListener(loadMenuPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadMenuPlayer()
    {
        MenuPlayer.SetActive(true);
    }
}
