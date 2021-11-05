using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class AbilityEvent : UnityEvent<int>
{
}

public class UIManager : MonoBehaviour
{
    private string selector;
    private int selectedMenu, selectedUser, selectedText, selectedPlayer, selectedEnemy;
    private bool hasSelectedCharacter, isSelectingEnemy, isPlayerTurn;
    //Turn into arrays
    [SerializeField] private AbilityEvent wizardHeal1; //focused
    [SerializeField] private UnityEvent wizardHeal2; //wide
    [SerializeField] private AbilityEvent wizardAttack1; //focused
    [SerializeField] private UnityEvent wizardAttack2; //wide
    [SerializeField] private AbilityEvent knightHeal1; //focused
    [SerializeField] private UnityEvent knightHeal2; //wide
    [SerializeField] private AbilityEvent knightAttack1; //focused
    [SerializeField] private UnityEvent knightAttack2; //wide
    [SerializeField] private Character character;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject[] menuArray; //0 = options, 1 = attack, 2 = healing
    [SerializeField] private TextMeshProUGUI[] HealingMenuText; //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] AttackMenuText;  //0 = focused, 1 = wide
    [SerializeField] private TextMeshProUGUI[] OptionsMenuText; //0 = attack, 1 = heal, 2 = skip

    private void Awake()
    {
        character = this.GetComponent<Character>();
        selector = "> ";
        selectedText = 0;
        selectedMenu = 0;
        selectedUser = 0;

        for (int i = 1; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(false);
        }

        hasSelectedCharacter = false;
        isPlayerTurn = true;
        MoveArrow(0, true);
    }

    private void Update()
    {
        if (isPlayerTurn)
        {
            //Shows which text/player is selected.
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isSelectingEnemy)
                {
                    selectedUser++;
                    if (selectedUser > 1)
                    {
                        selectedUser = 0;
                    }

                    if (selectedUser < 0)
                    {
                        selectedUser = 1;
                    }
                    MoveArrow(selectedUser, false);
                }

                if (!hasSelectedCharacter && !isSelectingEnemy)
                {
                    selectedUser++;
                    if (selectedUser > 1)
                    {
                        selectedUser = 0;
                    }

                    if (selectedUser < 0)
                    {
                        selectedUser = 1;
                    }
                    MoveArrow(selectedUser, true);
                }

                if (hasSelectedCharacter && !isSelectingEnemy)
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

            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isSelectingEnemy)
                {
                    selectedUser--;

                    if (selectedUser > 1)
                    {
                        selectedUser = 0;
                    }

                    if (selectedUser < 0)
                    {
                        selectedUser = 1;
                    }
                    MoveArrow(selectedUser, false);
                }

                if (!hasSelectedCharacter && !isSelectingEnemy)
                {
                    selectedUser--;
                    if (selectedUser > 1)
                    {
                        selectedUser = 0;
                    }

                    if (selectedUser < 0)
                    {
                        selectedUser = 1;
                    }
                    MoveArrow(selectedUser, true);
                }

                if (hasSelectedCharacter && !isSelectingEnemy)
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

                        if  (selectedText < 0)
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
            }

            if (Input.GetKeyDown(KeyCode.Return)) //Enter
            {
                if (isSelectingEnemy)
                {
                    if (selectedMenu == 1 && selectedText == 0)
                    {
                        if (selectedPlayer == 0) //Wizard
                        {
                            menuArray[1].SetActive(false);
                            wizardAttack1.Invoke(selectedUser);
                        }

                        if (selectedPlayer == 1) //Knight
                        {
                            menuArray[1].SetActive(false);
                            knightAttack1.Invoke(selectedUser);
                        }
                    }

                    if (selectedMenu == 2 && selectedText == 0)
                    {
                        if (selectedPlayer == 0) //Wizard
                        {
                            menuArray[2].SetActive(false);
                            wizardHeal1.Invoke(selectedUser);
                        }

                        if (selectedPlayer == 1) //Knight
                        {
                            menuArray[2].SetActive(false);
                            knightHeal1.Invoke(selectedUser);
                        }
                    }
                    isSelectingEnemy = false;
                    hasSelectedCharacter = false;
                    isPlayerTurn = false;
                }

                if (hasSelectedCharacter && !isSelectingEnemy)
                {
                    #region Attack menu 
                    if (selectedMenu == 1)
                    {
                        if (selectedUser == 0)
                        {
                            if (selectedText == 0) //attack, focused, wizard
                            {
                                selectedUser = 0;
                                menuArray[1].SetActive(false);
                                selectedText = 0;
                                selectedMenu = 0;
                                isSelectingEnemy = true;
                            }

                            if (selectedText == 1) //attack, wide, wizard
                            {
                                menuArray[1].SetActive(false);
                                wizardAttack2.Invoke();
                                isPlayerTurn = false;
                            }
                        }

                        if (selectedUser == 1)
                        {
                            if (selectedText == 0) //attack, focused, knight
                            {
                                selectedUser = 0;
                                menuArray[1].SetActive(false);
                                selectedText = 0;
                                selectedMenu = 0;
                                isSelectingEnemy = true;
                            }

                            if (selectedText == 1) //attack, wide, knight
                            {
                                menuArray[1].SetActive(false);
                                knightAttack2.Invoke();
                                isPlayerTurn = false;
                            }
                        }
                    }
                    #endregion
                    #region Heal menu
                    if (selectedMenu == 2) //Heal
                    {
                        if (selectedUser == 0) //heal, focused, wizard
                        {
                            if (selectedText == 0) //heal, focused, wizard
                            {
                                selectedUser = 0;
                                selectedText = 0;
                                selectedMenu = 0;
                                isSelectingEnemy = true;
                            }

                            if (selectedText == 1) //heal, wide, wizard
                            {
                                menuArray[2].SetActive(false);
                                wizardHeal2.Invoke();
                            }
                        }

                        if (selectedUser == 1) //heal, wide, 
                        {
                            if (selectedText == 0) //heal, focused, knight
                            {
                                selectedUser = 0;
                                selectedText = 0;
                                selectedMenu = 0;
                                isSelectingEnemy = true;
                            }

                            if (selectedText == 1) //heal, wide, knight
                            {
                                selectedUser = 0;
                                selectedText = 0;
                                selectedMenu = 0;
                                menuArray[2].SetActive(false);
                                knightHeal2.Invoke();
                            }
                        }
                    }
                    #endregion
                    #region Text handler
                    if (selectedText == 0 && selectedMenu < 1) //Attack menu opened
                {
                    selectedText = 0;
                    menuArray[1].SetActive(true);
                    selectedMenu = 1;
                    AttackMenuText[0].text = selector + "Focused attack";
                    AttackMenuText[1].text = "Wide attack";

                }

                if (selectedText == 1 && selectedMenu < 1) //Heal menu opened
                {
                    selectedText = 0;
                    menuArray[2].SetActive(true);
                    selectedMenu = 2;
                    HealingMenuText[0].text = selector + "Focused heal";
                    HealingMenuText[1].text = "Wide heal";
                }
                    #endregion
                }

                if (!hasSelectedCharacter)
                {
                    selectedPlayer = selectedUser;
                    hasSelectedCharacter = true;
                }

            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (hasSelectedCharacter)
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
    }
    
    private void MoveArrow(int index, bool isPlayer)
    {
        if (isPlayer)
        {
            arrow.transform.position = new Vector3(character.GetPlayerAtIndex(index).transform.position.x, character.GetPlayerAtIndex(index).transform.position.y + 1, character.GetPlayerAtIndex(index).transform.position.z);
        }
        if (!isPlayer)
        {
            arrow.transform.position = new Vector3(character.GetEnemyAtIndex(index).transform.position.x, character.GetEnemyAtIndex(index).transform.position.y + 1, character.GetEnemyAtIndex(index).transform.position.z);
        }
    }

    public bool GetPlayerTurnStatus()
    {
        return isPlayerTurn;
    }

    public void SetPlayerTurnStatus(bool setTrue)
    {
        if (setTrue)
        {
            MoveArrow(0, true);
            selectedText = 0;
            selectedMenu = 0;
            selectedUser = 0;
            hasSelectedCharacter = false;
            isPlayerTurn = true;
        }

        if (!setTrue)
        {
            isPlayerTurn = false;
        }
    }
}
