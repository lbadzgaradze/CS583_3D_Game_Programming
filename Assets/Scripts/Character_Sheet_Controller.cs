// created by Levan Badzgaradze for CS583

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_Sheet_Controller : MonoBehaviour
{
    public UI_Controller_Script ui_controller;
    public GameObject Game_Manager;

    public InputField inputfield_name;
    public InputField input_alignment;

    public TMPro.TMP_Dropdown Dropdown_Race;
    public TMPro.TMP_Dropdown Dropdown_Class;

    public Button back_button;
    public Button strength_button;
    public Button dexterity_button;
    public Button constitution_button;
    public Button intelligence_button;
    public Button wisdom_button;
    public Button charisma_button;
    public Button json_button;
    public Button json_copy;

    public TMPro.TMP_Text score_strength;
    public TMPro.TMP_Text score_dexterity;
    public TMPro.TMP_Text score_constitution;
    public TMPro.TMP_Text score_intelligence;
    public TMPro.TMP_Text score_wisdom;
    public TMPro.TMP_Text score_charisma;
    public TMPro.TMP_Text ability_output_text;

    public TMPro.TMP_Text json_text;

    public void Awake()
    {
        //referencing UI_Controller_Script
        Game_Manager = GameObject.Find("Game_Manager");
        ui_controller = Game_Manager.GetComponent<UI_Controller_Script>();

        back_button = GameObject.Find("back_button").GetComponent<Button>();
        back_button.onClick.AddListener(ui_controller.back_button);

        //reading name and alignment from the inputfield
        input_alignment = GameObject.Find("input_alignment").GetComponent<InputField>();
        input_alignment.onEndEdit.AddListener(delegate { ui_controller.read_alignment(input_alignment); });
        inputfield_name = GameObject.Find("inputfield_name").GetComponent<InputField>();
        inputfield_name.onEndEdit.AddListener(delegate { ui_controller.read_char_name(inputfield_name); });

        //reading race and class from dropdowns
        Dropdown_Race = GameObject.Find("Dropdown_Race").GetComponent<TMPro.TMP_Dropdown>();
        Dropdown_Race.onValueChanged.AddListener(delegate { ui_controller.race_selected(Dropdown_Race); });
        Dropdown_Class = GameObject.Find("Dropdown_Class").GetComponent<TMPro.TMP_Dropdown>();
        Dropdown_Class.onValueChanged.AddListener(delegate { ui_controller.class_selected(Dropdown_Class); });

        //referencing ability buttons
        strength_button = GameObject.Find("strength_button").GetComponent<Button>();
        dexterity_button = GameObject.Find("dexterity_button").GetComponent<Button>();
        constitution_button = GameObject.Find("constitution_button").GetComponent<Button>();
        intelligence_button = GameObject.Find("intelligence_button").GetComponent<Button>();
        wisdom_button = GameObject.Find("wisdom_button").GetComponent<Button>();
        charisma_button = GameObject.Find("charisma_button").GetComponent<Button>();

        //referencing output Gameobjects
        score_strength = GameObject.Find("score_strength").GetComponent<TMPro.TMP_Text>();
        score_dexterity = GameObject.Find("score_dexterity").GetComponent<TMPro.TMP_Text>();
        score_constitution = GameObject.Find("score_constitution").GetComponent<TMPro.TMP_Text>();
        score_intelligence = GameObject.Find("score_intelligence").GetComponent<TMPro.TMP_Text>();
        score_wisdom = GameObject.Find("score_wisdom").GetComponent<TMPro.TMP_Text>();
        score_charisma = GameObject.Find("score_charisma").GetComponent<TMPro.TMP_Text>();

        //adding listener functions to roll buttons
        strength_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(strength_button, score_strength, 's'); });
        dexterity_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(dexterity_button, score_dexterity, 'd'); });
        constitution_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(constitution_button, score_constitution, 'c'); });
        intelligence_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(intelligence_button, score_intelligence, 'i'); });
        wisdom_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(wisdom_button, score_wisdom, 'w'); });
        charisma_button.onClick.AddListener(delegate { ui_controller.ability_button_clicked(charisma_button, score_charisma, 'm'); }); //I use m to flag "charisma"

        //referencing output button and text area
        json_button = GameObject.Find("json_button").GetComponent<Button>();
        json_text = GameObject.Find("json_text").GetComponent<TMPro.TMP_Text>(); //inputfield was used so grader would be able to copy/paste JSON output 

        //adding listener function to the output button
        json_button.onClick.AddListener(delegate { ui_controller.json_button_clicked(json_text); });


        json_copy = GameObject.Find("json_copy").GetComponent<Button>();
        json_copy.onClick.AddListener(delegate { ui_controller.copy_json(json_text); });
    }



}
