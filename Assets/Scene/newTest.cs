using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class newTest : MonoBehaviour
{

    // public GUISkin skin;
    public int incrementalCount = 5;

    //leaderboard strings
    private string leaderboard = "Your unique leaderboard id";
    //achievement strings
    private string achievement = "Your unique achievement id";
    private string incremental = "Your unique achievement id";

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();
        login();
    }



    public void login()
    {
        //Share Status

            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
    


    public void Achievement()
    {
        //Achievement

        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(achievement, 100.0f, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
    }



    public void IncrementalAchievement()
    {

            if (Social.localUser.authenticated)
            {
                ((PlayGamesPlatform)Social.Active).IncrementAchievement(incremental, 5, (bool success) =>
                {
                    //The achievement unlocked successfully
                });
            }


    }


    public void theLeaderboard()
    {
        //Leaderboard

            if (Social.localUser.authenticated)
            {
                Social.ReportScore(5000, leaderboard, (bool success) =>
                {
                    if (success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
                    }
                    else
                    {
                        //Debug.Log("Login failed for some reason");
                    }
                });
            }

    }



    public void showLeaderboard()
    {

            Social.ShowLeaderboardUI();
        



    }


    public void showSpecificLeaderboard()
    {

            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);

    }



    public void showAchievments()
    {
        //Show Achievments

            Social.ShowAchievementsUI();


    }


    public void signOut()
    {

            ((PlayGamesPlatform)Social.Active).SignOut();
        }



}

