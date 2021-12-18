using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrePlayGameController_2 : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] Image ImgOnePlayerTitle;
    [SerializeField] Image ImgTwoPlayerTitle;

    [Header("Playr Group")]
    [SerializeField] InputField IpfPlayr1;
    [SerializeField] InputField IpfPlayr2;
    [SerializeField] Image ImgPlayr1_Chip;
    [SerializeField] Image ImgPlayr2_Chip;

    [Header("Color Group")]
    [SerializeField] Button BtnArrow;
    [SerializeField] Image ImgOnePlayer_Chip;
    [SerializeField] Image ImgTwoPlayer_Chip;

    [Header("First Move Group")]
    [SerializeField] Button BtnPlayr1_Chip;
    [SerializeField] Button BtnPlayr2_Chip;
    [SerializeField] Button BtnChipSelect;
    [SerializeField] Image ImgSelector;

    [Header("Difficulty Group")]
    [SerializeField] Slider SldLevelDifficulty; 

    [SerializeField] LayConfig config;
    // Start is called before the first frame update
    void Start()
    {
        SetTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetTitle()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            ImgOnePlayerTitle.gameObject.SetActive(true);
            ImgTwoPlayerTitle.gameObject.SetActive(false);
        }
        else
        {
            ImgOnePlayerTitle.gameObject.SetActive(false);
            ImgTwoPlayerTitle.gameObject.SetActive(true);
        }
    }
  
    private void SetColorChip()// Set Color for Chip in PrePlayrMenu
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            SetColorPlayrChipOfOnePlayerMode();
        }
        else if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.TWO_PLAY)
        {
            SetColorPlayrChipOfTwoPlayerMode();
        }
    }

    private void SetColorPlayrChipOfOnePlayerMode()
    {
        if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN)
        {
            UpdateColorPlayrChip(config.spr_Lay_Green, config.spr_Lay_Orange, config.spr_Lay_Random_Single_Player);
        }
        else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
        {
            UpdateColorPlayrChip(config.spr_Lay_Orange, config.spr_Lay_Green, config.spr_Lay_Random_Single_Player);
        }
    }
    private void SetColorPlayrChipOfTwoPlayerMode()
    {
        if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
        {
            UpdateColorPlayrChip(config.spr_Lay_Orange, config.spr_Lay_Yellow, config.spr_Lay_Random_Two_Player);
        }
        else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
        {
            UpdateColorPlayrChip(config.spr_Lay_Yellow, config.spr_Lay_Orange, config.spr_Lay_Random_Two_Player);
        }
    }

    private void UpdateColorPlayrChip(Sprite SprPlayr1_Chip,Sprite SprPlayr2_Chip,Sprite SprRandom_Chip)
    {
        if(GameSetup.Instance.GetCurrentColorSelected()==GameSetup.COLOR_SELECT.GREEN && GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            ImgPlayr1_Chip.sprite = SprPlayr1_Chip;
            ImgPlayr2_Chip.sprite = SprPlayr2_Chip;
            ImgOnePlayer_Chip.sprite = SprPlayr1_Chip;
            ImgTwoPlayer_Chip.sprite = SprPlayr2_Chip;
            BtnPlayr1_Chip.GetComponent<Image>().sprite = SprPlayr1_Chip;
            BtnPlayr2_Chip.GetComponent<Image>().sprite = SprPlayr2_Chip;
            BtnChipSelect.GetComponent<Image>().sprite = SprRandom_Chip;
        }
        
    }
}
