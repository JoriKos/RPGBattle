using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //TODO: AI, select party member, unityevent heal/damage

    [SerializeField] private UnityEvent heal;
    private string selector;
    private int selectedText;
    private int selectedMenu;
    [SerializeField] private GameObject[] menuArray; //0 = options, 1 = attack, 2 = healing
    [SerializeField] private TextMeshProUGUI[] HealingMenuText; //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] AttackMenuText;  //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] OptionsMenuText; //0 = attack, 1 = heal, 2 = skip

    private void Awake()
    {
        selector = "> ";
        selectedText = 0;
        selectedMenu = 0;

        for (int i = 1; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(false);
        }

    }

    private void Update()
    {
        //Shows which text is selected. I'm very proud of this code.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedText++;

            #region Options menu
            if (selectedMenu == 0)
            {
                if (selectedText > 2)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 2;
                }

                OptionsMenuText[selectedText].text = selector + OptionsMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
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

            #region Attack menu
            if (selectedMenu == 1)
            {
                if (selectedText > 1)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 1;
                }

                AttackMenuText[selectedText].text = selector + AttackMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
                if (selectedText - 1 == -1)
                {
                    AttackMenuText[selectedText + 1].text = AttackMenuText[selectedText + 1].text.Remove(0, 2);
                }
                else
                {
                    AttackMenuText[selectedText - 1].text = AttackMenuText[selectedText - 1].text.Remove(0, 2);
                }
            }
            #endregion

            #region Heal menu
            if (selectedMenu == 2)
            {

                if (selectedText > 1)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 1;
                }

                HealingMenuText[selectedText].text = selector + HealingMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
                if (selectedText - 1 == -1)
                {
                    HealingMenuText[selectedText + 1].text = HealingMenuText[selectedText + 1].text.Remove(0, 2);
                }
                else
                {
                    HealingMenuText[selectedText - 1].text = HealingMenuText[selectedText - 1].text.Remove(0, 2);
                }
            }
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedText--;

            #region Options menu
            if (selectedMenu == 0)
            {
                if (selectedText > 2)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 2;
                }

                OptionsMenuText[selectedText].text = selector + OptionsMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
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

            #region Attack menu
            if (selectedMenu == 1)
            {
                if (selectedText > 1)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 1;
                }

                AttackMenuText[selectedText].text = selector + AttackMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
                if (selectedText + 1 == 2)
                {
                    AttackMenuText[selectedText - 1].text = AttackMenuText[selectedText - 1].text.Remove(0, 2);
                }
                else
                {
                    AttackMenuText[selectedText + 1].text = AttackMenuText[selectedText + 1].text.Remove(0, 2);
                }
            }
            #endregion

            #region Heal menu
            if (selectedMenu == 2)
            {
                if (selectedText > 1)
                {
                    selectedText = 0;
                }

                if (selectedText < 0)
                {
                    selectedText = 1;
                }

                HealingMenuText[selectedText].text = selector + HealingMenuText[selectedText].text; //Adds "> " to newly-selected menu text

                //Removes previously selected menu text's selection indicator
                if (selectedText + 1 == 2)
                {
                    HealingMenuText[selectedText - 1].text = HealingMenuText[selectedText - 1].text.Remove(0, 2);
                }
                else
                {
                    HealingMenuText[selectedText + 1].text = HealingMenuText[selectedText + 1].text.Remove(0, 2);
                }
            }
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedText == 0 && selectedMenu < 1) //Attack
            {
                selectedText = 0;
                menuArray[1].SetActive(true);
                selectedMenu = 1;
                AttackMenuText[0].text = selector + "Focused attack";
                AttackMenuText[1].text = "Wide attack";
            }
            
            if (selectedText == 1 && selectedMenu < 1) //Heal
            {
                selectedText = 0;
                menuArray[2].SetActive(true);
                selectedMenu = 2;
                HealingMenuText[0].text = selector + "Focused heal";
                HealingMenuText[1].text = "Wide heal";
            }

            if (selectedMenu == 1)
            {
                if (selectedText == 1)
                {
                    
                }
            }
            
            if (selectedMenu == 2)
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (selectedMenu > 0)
            {
                if (selectedMenu == 1)
                {
                    menuArray[1].SetActive(false);
                    selectedMenu = 0;
                    selectedText = 0;
                }
                
                if (selectedMenu == 2)
                {
                    menuArray[2].SetActive(false);
                    selectedMenu = 0;
                    selectedText = 1;
                }
            }
        }
    }
}
