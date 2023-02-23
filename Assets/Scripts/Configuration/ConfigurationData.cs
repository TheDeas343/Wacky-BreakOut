using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    static StreamReader input;
    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 45;
    float ballImpulseForce = 2000;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int ballsPerGame = 5;
    int redPoitns = 50;
    int yellowPoints= 100;
    int orangePoints= 150;
    int greenPoints= 200;
    int bluePoints= 250;
    int purplePoints= 300;

    public float PaddleMoveUnitsPerSecond { get => paddleMoveUnitsPerSecond;  }
    public float BallImpulseForce { get => ballImpulseForce;  }
    public float BallLifeSeconds { get => ballLifeSeconds; }
    public float MinSpawnSeconds { get => minSpawnSeconds; }
    public float MaxSpawnSeconds { get => maxSpawnSeconds; }
    public int BallsPerGame { get => ballsPerGame; }
    public int RedPoitns { get => redPoitns; }
    public int YellowPoints { get => yellowPoints; }
    public int OrangePoints { get => orangePoints; }
    public int GreenPoints { get => greenPoints; }
    public int BluePoints { get => bluePoints; }
    public int PurplePoints { get => purplePoints; }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>


    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>


    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            GetInputs(input);
        } catch { }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
    }

    void GetInputs(StreamReader input)
    {
        string name = input.ReadLine();
        string values = input.ReadLine();

        string[] csvalues = values.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(csvalues[0]);
        ballImpulseForce = float.Parse(csvalues[1]);
        ballLifeSeconds = float.Parse(csvalues[2]);
        minSpawnSeconds = float.Parse(csvalues[3]);
        maxSpawnSeconds = float.Parse(csvalues[4]);
        ballsPerGame = int.Parse(csvalues[5]);
        redPoitns = int.Parse(csvalues[5]);
        yellowPoints = int.Parse(csvalues[6]);
        orangePoints = int.Parse(csvalues[7]);
        yellowPoints = int.Parse(csvalues[8]);
        yellowPoints = int.Parse(csvalues[9]);
        yellowPoints = int.Parse(csvalues[10]);
    }

    #endregion
}
