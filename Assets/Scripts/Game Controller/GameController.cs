using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    [Header("SCRIPTS")]
    [SerializeField] SeekhInfo seekhInfo;
    [SerializeField] SeekhMovement seekhMovement;
    [SerializeField] SliderMovement sliderMovement;
    [SerializeField] CameraFollow cameraFollow;

    [Header("END EMOJIS")]
    [SerializeField] Transform neutralEmoji;
    [SerializeField] Transform sadEmoji;
    [SerializeField] Transform happyEmoji;
    [SerializeField] Transform sickEmoji;

    [Header("UI")]
    //[SerializeField] GameObject currentLevelItemsUI;
    [SerializeField] List<GameObject> itemCounterUI;
    [SerializeField] TMP_Text levelCounter;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject levelOne;
    [SerializeField] GameObject levelTwo;
    [SerializeField] GameObject levelThree;
    [SerializeField] GameObject levelFour;
    [SerializeField] GameObject levelFive;

    [Header("Sounds")]
    //[SerializeField] AudioSource BackgroundMusic;
    //[SerializeField] AudioClip BGMusic;
    [Header("Mute Button")]
    [SerializeField] AudioSource MuteSound;
    [SerializeField] AudioClip MuteButton;
    [Header("unMute Button")]
    [SerializeField] AudioSource unMuteSound;
    [SerializeField] AudioClip unMuteButton;
    [Header("Settings Button")]
    [SerializeField] AudioSource SettingsSound;
    [SerializeField] AudioClip SettingsButton;
    [Header("Next Button")]
    [SerializeField] AudioSource NextSound;
    [SerializeField] AudioClip NextButton;
    [Header("Retry Button")]
    [SerializeField] AudioSource RetrySound;
    [SerializeField] AudioClip RetryButton;

    float timeForShowScreen = 6f;

    // For Settings Button
    bool isMuted;

    Touch touch;
    bool sliderIsMoving = false;
    bool sliderMovementFlag = true;

    // CAN BE "Burnt" "Raw" "Cooked" "Smoke"
    String stateOfFood = null;

    //[SerializeField] enum listOfItems { Cheese, Chicken, Donut, EclairChocolate, Muffin, Mushroom, Onion, Pepper, Pineapple, Salad, Sausage, Shrimp, SweetPepper, Tomato };

    [Header("TYPE FROM ABOVE LIST")]
    [Header("Cheese, Chicken, Donut, EclairChocolate, Muffin, Mushroom, Onion, Pepper, Pineapple, Salad, Sausage, Shrimp, SweetPepper, Tomato")]
    [SerializeField] List<String> itemsInLevel;

    private void Start()
    {
        levelCounter.text = SceneManager.GetActiveScene().name.ToString();

        //foreach(Transform child in currentLevelItemsUI.transform)
        //{
        //    itemCounterUI.Add(child.gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (seekhMovement.getIsFinalAnimation() && sliderMovementFlag)
        {
            sliderMovementFlag = false;
            sliderMovement.setEnabled(true);
            sliderIsMoving = true;
            Invoke("sliderTimer", 3f);
        }

        if (Input.touchCount > 0 && sliderIsMoving)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                CancelInvoke();
                sliderIsMoving = false;
                stateOfFood = sliderMovement.getCookState();
                StartCoroutine(seekhMovement.finalRotate());
                Invoke("hideSlider", 1f);
            }
        }
 
    }

    //IS BEING CALLED FROM HIDESLIDER FUNCTION
    public void checkWin()
    {
        List<GameObject> itemsOnSeekh = seekhInfo.getItemsOnSeekh();

        if(itemsOnSeekh.Capacity == 0)
        {
            Debug.Log("SEEKH EMPTY");
            showSad();
            Invoke("showLoseScreen", timeForShowScreen);
            return;
        }

        for(int i = 0; i < itemsOnSeekh.Capacity; i++)
        {
            for(int j = 0; j < itemsInLevel.Capacity; j++)
            {
                if (itemsOnSeekh[i].name.StartsWith(itemsInLevel[j]))
                {
                    seekhInfo.enableEndingParticleEffect(stateOfFood);
                    if (stateOfFood.Equals("Cooked"))
                    {
                        Debug.Log("COOKED");
                        showHappy();
                        Invoke("showWinScreen", timeForShowScreen);
                    }
                    else if (stateOfFood.Equals("Raw"))
                    {
                        Debug.Log("RAW");
                        showSick();
                        Invoke("showLoseScreen", timeForShowScreen);
                    }
                    else if (stateOfFood.Equals("Smoke"))
                    {
                        Debug.Log("SMOKED");
                        showHappy();
                        Invoke("showWinScreen", timeForShowScreen);
                    }
                    else if (stateOfFood.Equals("Burnt"))
                    {
                        Debug.Log("BURNT");
                        showSick();
                        Invoke("showLoseScreen", timeForShowScreen);
                    }
                    return;
                }
            }
        }

        seekhInfo.enableEndingParticleEffect(stateOfFood);
        Debug.Log("END CASE");
        showSad();
        Invoke("showLoseScreen", timeForShowScreen);
    }

    void sliderTimer()
    {
        sliderIsMoving = false;
        StartCoroutine(seekhMovement.finalRotate());
        stateOfFood = "Burnt";
        Invoke("hideSlider", 1f);
    }

    void hideSlider()
    {
        sliderMovement.setEnabled(false);
        Invoke("checkWin", 2f);
    } 

    void showHappy()
    {
        neutralEmoji.gameObject.SetActive(false);
        happyEmoji.gameObject.SetActive(true);
    }

    void showSad()
    {
        neutralEmoji.gameObject.SetActive(false);
        sadEmoji.gameObject.SetActive(true);
    }

    void showSick()
    {
        neutralEmoji.gameObject.SetActive(false);
        sickEmoji.gameObject.SetActive(true);
    }

    void showLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    void showWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void nextLevel()
    {
        NextSound.clip = NextButton;
        NextSound.PlayOneShot(NextSound.clip);
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneLoader.loadLevel2();
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            SceneLoader.loadLevel3();
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            SceneLoader.loadLevel4();
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            SceneLoader.loadLevel5();
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            SceneLoader.loadLevel1();
        }
    }

    public void restartLevel()
    {
        RetrySound.clip = RetryButton;
        RetrySound.PlayOneShot(RetrySound.clip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void hideStartScreen()
    {
        startScreen.SetActive(false);
        levelObjectives();
    }

    public void levelObjectives()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            levelOne.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            levelTwo.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            levelThree.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            levelFour.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            levelFive.SetActive(true);
        }
    }
    
    public void Mute()
    {
        MuteSound.clip = MuteButton;
        MuteSound.PlayOneShot(MuteSound.clip);
        AudioListener.volume = 0f;
    }
    public void unMute()
    {
        unMuteSound.clip = unMuteButton;
        unMuteSound.PlayOneShot(unMuteSound.clip);
        AudioListener.volume = 1f;
    }

    public void Settings()
    {
        SettingsSound.clip = SettingsButton;
        SettingsSound.PlayOneShot(SettingsSound.clip);
    }

    public void checkIfItemAddedIsRequired(GameObject item)
    {
        foreach(String food in itemsInLevel)
        {
            if (food.StartsWith(item.name))
            {
                foreach(GameObject counter in itemCounterUI)
                {
                    if (food.Equals(counter.name))
                    {
                        TMP_Text text = counter.GetComponentInChildren<TMP_Text>();
                        int currCount = int.Parse(text.text);
                        text.text = currCount++.ToString();
                    }
                }
            }
        }
    }

    public void checkIfItemRemovedIsRequired(GameObject item)
    {
        foreach (String food in itemsInLevel)
        {
            if (food.StartsWith(item.name))
            {
                foreach (GameObject counter in itemCounterUI)
                {
                    if (food.Equals(counter.name))
                    {
                        TMP_Text text = counter.GetComponentInChildren<TMP_Text>();
                        int currCount = int.Parse(text.text);
                        text.text = currCount--.ToString();
                    }
                }
            }
        }
    }
}
