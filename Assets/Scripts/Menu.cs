using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text[] missionDescription, missionRewad, missionProgress;
    public GameObject[] rewardButton;
    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        SetMission();
        UpdateCoins(GameManager.gm.coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void StartRun()
    {
        GameManager.gm.StartRun();
    }

    public void SetMission()
    {
        for (int i = 0; i < 2; i++)
        {
            MissionBase mission = GameManager.gm.GetMission(i);
            missionDescription[i].text = mission.GetMissionDescription();
            missionRewad[i].text = "Compensation: " + mission.reward;
            missionProgress[i].text = mission.progress + mission.currentProgress + " / " + mission.max;
            if (mission.GetMissionComplete())
            {
                rewardButton[i].SetActive(true);
            }
        }

        GameManager.gm.Save();
    }

    public void GetReward(int missionIndex)
    {
        GameManager.gm.coins += GameManager.gm.GetMission(missionIndex).reward;
        UpdateCoins(GameManager.gm.coins);
        rewardButton[missionIndex].SetActive(false);
        GameManager.gm.GenerateMission(missionIndex);
    }
}
