using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml.Serialization;

/// <summary>
/// This class is responsible for the handling of the high score.
/// </summary>
public class HighscoreController : MonoBehaviour
{

    public Text LBLScoreOutput = null;
    public HighscoreData highScoreData = null;
    public Text txtHighscore = null;

    private int score = 0;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        LoadHighscore();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        score = GetScore();
        if (LBLScoreOutput != null)
        {
            LBLScoreOutput.text = score.ToString();
        }
    }

    /// <summary>
    /// Calculates the actual score by the position of the object owner (game object)
    /// </summary>
    /// <returns>the score</returns>
    public int GetScore()
    {
        float z = gameObject.transform.position.z;
        float scoreMultiplicator = Mathf.Pow(2, Mathf.Floor(z / 1000));

        return Mathf.RoundToInt(scoreMultiplicator * z);
    }

    /// <summary>
    /// This function should be called when the player dies
    /// </summary>
    public void OnPlayerDies()
    {
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        playerController.playerCrashed();
        if (highScoreData.IsHighestScore(score))
        {
            highScoreData.SetHighscore(score);
            SaveHighscore();
        }
    }

    public void BeforeGameExits()
    {
        if (highScoreData.IsHighestScore(score))
        {
            highScoreData.SetHighscore(score);
        }

        SaveHighscore();
    }

    /// <summary>
    /// This function should be called, if the highscore has to be displayed in the txtHighscore
    /// </summary>
    public void OnShowHighscore()
    {
        if (txtHighscore != null)
        {
            if (highScoreData.IsHighestScore(score))
            {
                highScoreData.SetHighscore(score);
                SaveHighscore();
            }

            txtHighscore.text = highScoreData.GetScore().ToString();
        }
    }

    public void SaveHighscore()
    {
        string serialized = Serialize(highScoreData);

        StreamWriter file = File.CreateText(Application.persistentDataPath + "/highscore.xml");
        file.Write(serialized);
        file.Close();
    }

    public void LoadHighscore()
    {
        if (File.Exists(Application.persistentDataPath + "/highscore.xml"))
        {
            highScoreData = DeSerialize<HighscoreData>(File.ReadAllText(Application.persistentDataPath + "/highscore.xml"));
        }
    }

    public static string Serialize(object obj)
    {
        StringBuilder xml = new StringBuilder();

        XmlSerializer serializer = new XmlSerializer(obj.GetType());

        using (TextWriter textWriter = new StringWriter(xml))
        {
            serializer.Serialize(textWriter, obj);
        }

        return xml.ToString();
    }

    public static T DeSerialize<T>(string xml)
    {
        T obj = default(T);

        XmlSerializer deserializer = new XmlSerializer(typeof(T));

        using (TextReader textReader = new StringReader(xml))
        {
            obj = (T)deserializer.Deserialize(textReader);
        }

        return obj;
    }
}
