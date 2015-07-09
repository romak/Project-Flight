using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{

    public static bool debug = true;

    public static GameStatus gameStatus;

    #region Options
    public static float sfxVolume = 1.0f;
    public static bool sfxMute = false;
    public static float musicVolume = 0.5f;
    public static bool musicMute = false;
    public static int renderQuality = 2; // QualityLevel.Simple;
    #endregion

    #region Lives
    public static int lives = 5;
    #endregion

    public static int score = 0;

    public struct CameraPosition
    {
        public float rotationX, offsetY, offsetZ;
        public CameraPosition(float rotationX, float offsetY, float offsetZ)
        {
            this.rotationX = rotationX;
            this.offsetY = offsetY;
            this.offsetZ = offsetZ;
        }

    };

    public enum GameStatus
    {
        Play,
        Pause,
        GameOver,
        Crashing
    };

    public enum CameraViews
    {
        Regular,
        Top
    };

    public static CameraViews curCameraView = CameraViews.Regular;

    public enum AirPlanes
    {
        SpaceAirPlane,
        Kukuruznik
    };


    public struct AirPlane
    {
        public string name;
        public float speed;
        public float turnForce;
        public float rotateForce;

        public AirPlane(string name, float speed, float turnSpeed, float rotateSpeed)
        {
            this.name = name;
            this.speed = speed;
            this.turnForce = turnSpeed;
            this.rotateForce = rotateSpeed;
        }

    };

}
