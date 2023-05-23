using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScorePlayer", menuName = "ScriptableObject/ScorePlayer", order = 2)]
public class ScorePlayer : ScriptableObject
{
    [SerializeField] private float[] MaxScore;

    private void OnEnable()
    {
        if(MaxScore == null)
        {
            MaxScore = new float[10];
        }
    }

    public void RegistryNewScore(float newScore)
    {
        float[] newMaxScore = new float[10];
        bool isChanged = false;
        for (int i = 0; i < 10; i++)
        {
            float safePrevious = MaxScore[i];

            if(newScore > MaxScore[i] && !isChanged)
            {
                newMaxScore[i] = newScore;
                i++;
                isChanged = true;
            }
            newMaxScore[i] = safePrevious;
        }

        MaxScore = newMaxScore;
    }
}
