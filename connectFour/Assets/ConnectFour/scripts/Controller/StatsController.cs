using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public GameObject textWin;
    public GameObject textDraw;
    public GameObject textLose;
    public GameObject textGlobal;
    public GameObject ChipCellsParents;
    public GameObject textWinOnGlobal;
    public GameObject textLoseOnGlobal;
    public GameObject textDrawOnGlobal;
    public Button BtnReset;
    public Button BtnBack;
    int Total;
    // Start is called before the first frame update
    
    void Start()
    {
        if(ChipCellsParents!=null)
        ChipCellsParents.SetActive(false);
        
        BtnReset.onClick.AddListener(ResetKey);
        BtnBack.onClick.AddListener(OnBack);
    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateStatsValues();

    }

    private void UpdateStatsValues()
    {
        textWin.GetComponent<Text>().text = GameSetup.Instance.GetNumberWin().ToString();
        textDraw.GetComponent<Text>().text = GameSetup.Instance.GetNumberDraw().ToString();
        textLose.GetComponent<Text>().text = GameSetup.Instance.GetNumberLose().ToString();
        Total = GameSetup.Instance.GetNumberDraw() + GameSetup.Instance.GetNumberWin() + GameSetup.Instance.GetNumberLose();
        textGlobal.GetComponent<Text>().text = Total.ToString();
        if (Total == 0) Total = 1;
        textWinOnGlobal.GetComponent<Text>().text = (Mathf.Round((float)GameSetup.Instance.GetNumberWin() * 10000 / Total) * 0.01f).ToString();
        textLoseOnGlobal.GetComponent<Text>().text = (Mathf.Round((float)GameSetup.Instance.GetNumberLose() * 10000 / Total) * 0.01f).ToString();
        textDrawOnGlobal.GetComponent<Text>().text = (Mathf.Round((float)GameSetup.Instance.GetNumberDraw() * 10000 / Total) * 0.01f).ToString();
    }

    void ResetKey()
    {

        GameSetup.Instance.SetNumberWin(0);
        GameSetup.Instance.SetNumberDraw(0);
        GameSetup.Instance.SetNumberLose(0);
    }
    void OnBack()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        if(ChipCellsParents != null)
        ChipCellsParents.SetActive(true);
    }
    
        
    
   
}
