using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private string selector;
    private int selectedText;
    private int selectedMenu;
    [SerializeField] private GameObject[] menuArray;
    [SerializeField] private TextMeshProUGUI[] HealingMenuText; //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] AttackMenuText;  //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] OptionsMenuText; //0 = attack, 1 = heal, 2 = skip

    private void Awake()
    {
        selector = "> ";
        selectedText = 0;
        selectedMenu = 0;
    }

    private void Update()
    {
        //Shows which text is selected. I'm very proud of this code.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedText++;
            if (selectedText > 2)
            {
                selectedText = 0;
            }
            
            if (selectedText < 0)
            {
                selectedText = 2;
            }

            #region Options menu
            if (selectedMenu == 0) //Options menu
            {
                OptionsMenuText[selectedText].text = selector + OptionsMenuText[selectedText].text;
                Debug.Log(selectedText - 1);

                if (selectedText - 1 == -1)
                {
                    OptionsMenuText[selectedText + 2].text = OptionsMenuText[selectedText + 2].text.Remove(0, 2);
                }
                else
                {
                    OptionsMenuText[selectedText - 1].text = OptionsMenuText[selectedText - 1].text.Remove(0, 2);
                }
            }
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedText--;
            if (selectedText > 2)
            {
                selectedText = 0;
            }
            
            if (selectedText < 0)
            {
                selectedText = 2;
            }

            #region Options menu
            if (selectedMenu == 0) //Options menu
            {
                OptionsMenuText[selectedText].text = selector + OptionsMenuText[selectedText].text;
                Debug.Log(selectedText - 1);

                if (selectedText + 1 == 3)
                {
                    OptionsMenuText[selectedText - 2].text = OptionsMenuText[selectedText - 2].text.Remove(0, 2);
                }
                else
                {
                    OptionsMenuText[selectedText + 1].text = OptionsMenuText[selectedText + 1].text.Remove(0, 2);
                }
            }
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedText == )
            {

            }
        }
    }
}
