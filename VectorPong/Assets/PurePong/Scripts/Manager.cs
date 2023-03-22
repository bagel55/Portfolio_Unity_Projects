using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //Create objects for the boundries
    public static Prect lowerwall;
    public static Prect upperwall;
    public static Prect centerLine;
    private Color wallColor = new Color(0, 1, 1, 1);
    private Color centerLineColor = new Color(1, 0, 1, 0.5f);
    //Used for paddle AI later
    public static Vector2 ballLocation;
    //Used for GUI.Box
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;
    //Set the initial ball speed
    public static float initBallSpeed = 1;
    //Create a list of all prects that need to have collison detection
    public static List<Prect> colliderPrects = new List<Prect>();
    //used for scoring
    public static int leftScore;
    public static int rightScore;
    private Rect leftScoreText;
    private Rect rightScoreText;
    void Start() 
    {
        upperwall = new Prect("Upper Wall", 0, 0, Screen.width, 10, true, "WALL");
        lowerwall = new Prect("Lower Wall", 0, Screen.height - 10, Screen.width, 10, true, "WALL");
        centerLine = new Prect("Center Wall", Screen.width / 2, 0, 5, Screen.height, false, "CTRLINE");
        //add to colliderPrects the objects that require collision work
        colliderPrects.Add(upperwall);
        colliderPrects.Add(lowerwall);
        leftScore = 0;
        rightScore = 0;
        leftScoreText = new Rect(20, 20, 20, 20);
        rightScoreText = new Rect(Screen.width - 30, 20, 20, 20);
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            foreach(Prect p in colliderPrects)
            {
                Debug.Log(p.name);
            }
        }
    }
    public static void GUIDrawRect(Rect position, Color color)
    {
        if(_staticRectStyle == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }
        if(_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
            _staticRectStyle.fontSize = 16;
        }
        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position, GUIContent.none, _staticRectStyle);
    }
    public static void GUIDrawRect(Rect position, Color color, string text)
    {
        if (_staticRectStyle == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }
        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
            _staticRectStyle.fontSize = 72;
        }
        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position, text, _staticRectStyle);
    }
    private void OnGUI()
    {
        GUIDrawRect(centerLine.rect, centerLineColor);
        GUIDrawRect(upperwall.rect, wallColor);
        GUIDrawRect(lowerwall.rect, wallColor);
        GUIDrawRect(leftScoreText, wallColor, leftScore.ToString());
        GUIDrawRect(rightScoreText, wallColor, rightScore.ToString());
    }
}
