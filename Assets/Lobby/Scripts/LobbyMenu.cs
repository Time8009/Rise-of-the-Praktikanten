using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class LobbyMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject OptionsMenu;

    [SerializeField]
    private TMP_Dropdown QualityDropdown;

    [SerializeField]
    private TMP_Text VersionText;

    [SerializeField]
    private Slider MouseSensitivitySlider;

    private void Start()
    {
        if (OptionsMenu != null)
            OptionsMenu.SetActive(false);

        VersionText.text = "Version: " + Application.version;

        QualityDropdown.options.Clear();
        foreach (string qualityName in QualitySettings.names)
        {
            QualityDropdown.options.Add(new TMP_Dropdown.OptionData(qualityName));
        }
        int qualityLevel = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());

        QualitySettings.SetQualityLevel(qualityLevel);
        QualityDropdown.value = qualityLevel;
        QualityDropdown.RefreshShownValue();

        QualityDropdown.onValueChanged.RemoveAllListeners();
        QualityDropdown.onValueChanged.AddListener(SetQuality);

        float MouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 1);
        MouseSensitivitySlider.value = MouseSensitivity;
        MouseSensitivitySlider.onValueChanged.RemoveAllListeners();
        MouseSensitivitySlider.onValueChanged.AddListener(MouseSensitivitySliderChanged);
    }

    private void MouseSensitivitySliderChanged(float value)
    {
        PlayerPrefs.SetFloat("mouseSensitivity", value);
        PlayerPrefs.Save();
    }    

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void Options()
    {
        if (OptionsMenu != null)
            OptionsMenu.SetActive(!OptionsMenu.activeSelf);
    }

    public void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
        PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel());
        PlayerPrefs.Save();
    }


}
