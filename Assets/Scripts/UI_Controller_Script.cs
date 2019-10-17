//Levan Badzgaradze for CS583

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class UI_Controller_Script : MonoBehaviour
{
    public DnD_player character;
    public GameObject Game_Manager;

    public Button generate_char_button;
    public Button quit_button;

    string char_name, alignment, char_race, char_class;
    int strength, dexterity, constitution, intelligence, wisdom, charisma;

    public void json_button_clicked(TMPro.TMP_Text output)
    {
        character = new DnD_player(this.char_name, this.char_race, this.char_class, this.alignment, this.strength, this.dexterity,
            this.constitution, this.intelligence, this.wisdom, this.charisma);
        output.SetText(character.json_output());
    }

    public void ability_button_clicked(Button button, TMPro.TMP_Text score_output, char flag)
    {
        List<int> rolls = new List<int>(5);
        for (int i = 0; i < 5; i++)
        {
            rolls.Add(Random.Range(1, 7));
        }
        rolls.Sort();

        int ability_score = rolls[rolls.Count - 1] + rolls[rolls.Count - 2] + rolls[rolls.Count - 3];

        switch (flag)
        {
            case 's':
                this.strength = ability_score;
                break;
            case 'd':
                this.dexterity = ability_score;
                break;
            case 'c':
                this.constitution = ability_score;
                break;
            case 'i':
                this.intelligence = ability_score;
                break;
            case 'w':
                this.wisdom = ability_score;
                break;
            case 'm': //m is a flag for charisma
                this.charisma = ability_score;
                break;
            default:
                break;
        }

        score_output.SetText(ability_score.ToString());
        button.interactable = false;
        //button.transform.gameObject.SetActive(false);

    }

    public void back_button()
    {
        Destroy(Game_Manager);
        SceneManager.LoadScene(0);
    }

    public void Awake()
    {
        Game_Manager = GameObject.Find("Game_Manager");
        generate_char_button = GameObject.Find("Generate_Char_Button").GetComponent<Button>();
        generate_char_button.onClick.AddListener(generate_char_button_clicked);
        quit_button = GameObject.Find("Quit_Button").GetComponent<Button>();
        quit_button.onClick.AddListener(quit_game);
    }
    public void generate_char_button_clicked()
    {
        SceneManager.LoadScene(1);
    }

    public void read_char_name(InputField input_name)
    {
        this.char_name = input_name.text;
    }

    public void read_alignment(InputField input_alignment)
    {
        this.alignment = input_alignment.text;
    }

    public void race_selected(TMPro.TMP_Dropdown Dropdown_Race)
    {
        string selected_race = Dropdown_Race.options[Dropdown_Race.value].text;
        this.char_race = selected_race.Equals("Select Race") ? "" : selected_race;

    }

    public void class_selected(TMPro.TMP_Dropdown Dropdown_Class)
    {
        string selected_class = Dropdown_Class.options[Dropdown_Class.value].text;
        this.char_class = selected_class.Equals("Select Class") ? "" : selected_class;
    }

    public void copy_json(TMPro.TMP_Text json_text)
    {
        //CopyToClipboard(json_text.text);
        GUIUtility.systemCopyBuffer = json_text.text;
    }

    //public static void CopyToClipboard(string toCopy)
    //{
    //    TextEditor editor = new TextEditor();
    //    editor.text = toCopy;
    //    editor.SelectAll();
    //    editor.Copy();
    //}


    //public static string Clipboard
    //{
    //    get { return GUIUtility.systemCopyBuffer; }
    //    set { GUIUtility.systemCopyBuffer = value; }
    //}

    public void quit_game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = (false);
#else
        Application.Quit();
#endif
    }
}
