using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public InputField NickName, PlayerScore;
    public string nickname;

    private void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(NickName.text, int.Parse(PlayerScore.text), nickname, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
