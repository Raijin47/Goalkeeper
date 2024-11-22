using System;

[Serializable]
public class Data
{
    public bool IsFirstSession;
    public int AvatarID;
    public string Name;
    public int League;
    public int Score;
    public bool IsScoreChanged;

    public Data()
    {
        IsFirstSession = true;
        AvatarID = 0;
        Name = "Player";
        League = 0;
        Score = 0;
        IsScoreChanged = false;
    }
}