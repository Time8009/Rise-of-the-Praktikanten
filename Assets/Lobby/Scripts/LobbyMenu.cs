using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LobbyMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject OptionsMenu;

    [SerializeField]
    private TMP_Dropdown qualityDropdown;

    private void Start()
    {
        if (OptionsMenu != null)
            OptionsMenu.SetActive(false);

        qualityDropdown.options.Clear();
        foreach (string qualityName in QualitySettings.names)
        {
            qualityDropdown.options.Add(new TMP_Dropdown.OptionData(qualityName));
        }
        int qualityLevel = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());

        QualitySettings.SetQualityLevel(qualityLevel);
        qualityDropdown.value = qualityLevel;
        qualityDropdown.RefreshShownValue();

        qualityDropdown.onValueChanged.AddListener(SetQuality);
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
