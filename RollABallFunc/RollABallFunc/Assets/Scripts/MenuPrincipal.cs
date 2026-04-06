using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject settingsPanel;
    public AudioSource musicSource;
    public Slider volumeSlider;

    public Toggle fullscreenToggle;
    public TMP_Dropdown qualityDropdown;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        float volumenGuardado = PlayerPrefs.GetFloat("volumenMenu", 1f);
        if (musicSource != null)
            musicSource.volume = volumenGuardado;
        if (volumeSlider != null)
            volumeSlider.value = volumenGuardado;

        bool fullscreenGuardado = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        Screen.fullScreen = fullscreenGuardado;
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = fullscreenGuardado;

        int calidadGuardada = PlayerPrefs.GetInt("qualityLevel", QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(calidadGuardada);
        if (qualityDropdown != null)
            qualityDropdown.value = calidadGuardada;
        if (qualityDropdown != null)
            qualityDropdown.RefreshShownValue();
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("El jugador ha salido del juego...");
        Application.Quit();
    }

    public void AbrirSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CerrarSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void CambiarVolumen(float valor)
    {
        if (musicSource != null)
            musicSource.volume = valor;

        PlayerPrefs.SetFloat("volumenMenu", valor);
        PlayerPrefs.Save();
    }

    public void CambiarFullscreen(bool activar)
    {
        Screen.fullScreen = activar;
        PlayerPrefs.SetInt("fullscreen", activar ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void CambiarCalidad(int indice)
    {
        QualitySettings.SetQualityLevel(indice);
        PlayerPrefs.SetInt("qualityLevel", indice);
        PlayerPrefs.Save();
    }
}