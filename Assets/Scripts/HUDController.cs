using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject firstPersonAudio;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSource doorKnockSound;
    [SerializeField] private AudioSource heartBeatSound;
    [SerializeField] private TextMeshProUGUI booksValueText;
    [SerializeField] private TextMeshProUGUI thirdTaskText;
    [SerializeField] private TextMeshProUGUI secondTaskText;
    [SerializeField] private GameObject activeFinishTrigger;

    private int totalBooks = 8;
    private int bookCount = 0;
    private bool isPaused = false;


    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void IncrementBookCount()
    {
        bookCount++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        booksValueText.text = $"Collected Books: {bookCount}/8";
    }

    public void CollectBook()
    {
        if (bookCount >= totalBooks)
        {
            StartDoorKnock();
        }
    }

    private void StartDoorKnock()
    {
        doorKnockSound.Play();
        heartBeatSound.Play();
        thirdTaskText.gameObject.SetActive(true);
        secondTaskText.gameObject.SetActive(false);
        activeFinishTrigger.SetActive(true);
    }

    public void Pause()
    {
        isPaused = false;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        firstPersonAudio.SetActive(false);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
        DisableScripts();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonAudio.SetActive(true);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
        EnableScripts();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void DisableScripts()
    {
        FirstPersonMovement firstPersonMovement = FindObjectOfType<FirstPersonMovement>();
        if (firstPersonMovement != null)
        {
            firstPersonMovement.enabled = false;
        }

        Crouch crouch = FindObjectOfType<Crouch>();
        if (crouch != null)
        {
            crouch.enabled = false;
        }

        FirstPersonLook firstPersonLook = FindObjectOfType<FirstPersonLook>();
        if (firstPersonLook != null)
        {
            firstPersonLook.enabled = false;
        }

        FlashlightToggle flashlightToggle = FindObjectOfType<FlashlightToggle>();
        if (flashlightToggle != null)
        {
            flashlightToggle.enabled = false;
        }
    }

    private void EnableScripts()
    {
        FirstPersonMovement firstPersonMovement = FindObjectOfType<FirstPersonMovement>();
        if (firstPersonMovement != null)
        {
            firstPersonMovement.enabled = true;
        }

        Crouch crouch = FindObjectOfType<Crouch>();
        if (crouch != null)
        {
            crouch.enabled = true;
        }

        FirstPersonLook firstPersonLook = FindObjectOfType<FirstPersonLook>();
        if (firstPersonLook != null)
        {
            firstPersonLook.enabled = true;
        }

        FlashlightToggle flashlightToggle = FindObjectOfType<FlashlightToggle>();
        if (flashlightToggle != null)
        {
            flashlightToggle.enabled = true;
        }
    }
}
