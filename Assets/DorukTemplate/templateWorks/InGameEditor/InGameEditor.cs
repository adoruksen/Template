using DG.Tweening;
using UnityEngine;
using UnityEditor;
using Managers;
using TMPro;

public class InGameEditor : MonoBehaviour
{
    [System.Serializable]
    private struct FPSColor
    {
        public Color Color;
        public int MinimumFPS;
    }

    [Header("FPS")]
    [SerializeField] private FPSColor[] fpsColors;
    private TextMeshProUGUI _fpsText;
    private readonly string[] fpsLabels =
    {
            "FPS = 00", "FPS = 01", "FPS = 02", "FPS = 03", "FPS = 04", "FPS = 05", "FPS = 06", "FPS = 07", "FPS = 08", "FPS = 09",
            "FPS = 10", "FPS = 11", "FPS = 12", "FPS = 13", "FPS = 14", "FPS = 15", "FPS = 16", "FPS = 17", "FPS = 18", "FPS = 19",
            "FPS = 20", "FPS = 21", "FPS = 22", "FPS = 23", "FPS = 24", "FPS = 25", "FPS = 26", "FPS = 27", "FPS = 28", "FPS = 29",
            "FPS = 30", "FPS = 31", "FPS = 32", "FPS = 33", "FPS = 34", "FPS = 35", "FPS = 36", "FPS = 37", "FPS = 38", "FPS = 39",
            "FPS = 40", "FPS = 41", "FPS = 42", "FPS = 43", "FPS = 44", "FPS = 45", "FPS = 46", "FPS = 47", "FPS = 48", "FPS = 49",
            "FPS = 50", "FPS = 51", "FPS = 52", "FPS = 53", "FPS = 54", "FPS = 55", "FPS = 56", "FPS = 57", "FPS = 58", "FPS = 59",
            "FPS = 60", "FPS = 61", "FPS = 62", "FPS = 63", "FPS = 64", "FPS = 65", "FPS = 66", "FPS = 67", "FPS = 68", "FPS = 69",
            "FPS = 70", "FPS = 71", "FPS = 72", "FPS = 73", "FPS = 74", "FPS = 75", "FPS = 76", "FPS = 77", "FPS = 78", "FPS = 79",
            "FPS = 80", "FPS = 81", "FPS = 82", "FPS = 83", "FPS = 84", "FPS = 85", "FPS = 86", "FPS = 87", "FPS = 88", "FPS = 89",
            "FPS = 90", "FPS = 91", "FPS = 92", "FPS = 93", "FPS = 94", "FPS = 95", "FPS = 96", "FPS = 97", "FPS = 98", "FPS = 99"
    };
    private readonly int[] fpsBuffer = new int[60];
    private int fpsBufferIndex = 0;

    [Space(10)]
    [Header("GUI")]
    private bool _consoleOpen;
    [SerializeField] private GUISkin _skin;
    private Vector2 _position = new Vector2(-Screen.width, 0f);

    private void Awake()
    {
        _fpsText = GetComponent<TextMeshProUGUI>();
    }

    private void OnGUI()
    {
        GUI.skin = _skin;
        if (GUI.Button(new Rect(new Vector2(0f, 0f), new Vector2(64f, 64f)), _consoleOpen ? "<" : ">"))
        {
            if (_consoleOpen)
            {
                CloseConsole();
            }
            else
            {
                OpenConsole();
            }
        }

        if (GUI.Button(new Rect(_position + new Vector2(64f, 64f), new Vector2(200f, 64f)), "RESET"))
        {
            GameManager.instance.RestartLevel();
        }

        if(GUI.Button(new Rect(_position + new Vector2(264f,64f), new Vector2(200f, 64f)), "SKIP LEVEL"))
        {
            GameManager.instance.SkipLevel();
        }
    }

    private void Update()
    {
        FPSDisplayer();        
    }

    private void OpenConsole()
    {
        _consoleOpen = true;
        DOTween.To(() => _position, x => _position = x, new Vector2(0f, 0f), .3f);
    }

    private void CloseConsole()
    {
        _consoleOpen = false;
        DOTween.To(() => _position, x => _position = x, new Vector2(-Screen.width, 0f), .3f);
    }

    private void FPSDisplayer()
    {
        if (_consoleOpen)
        {
            fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);

            if (fpsBufferIndex >= fpsBuffer.Length)
                fpsBufferIndex = 0;

            int averageFPS = 0;
            for (int i = 0; i < fpsBuffer.Length; i++)
            {
                int fps = fpsBuffer[i];
                averageFPS += fps;
            }

            averageFPS = (int)((float)averageFPS / fpsBuffer.Length);

            _fpsText.text = fpsLabels[Mathf.Clamp(averageFPS, 0, 99)];
            for (int i = fpsColors.Length - 1; i >= 0; i--)
            {
                if (averageFPS >= fpsColors[i].MinimumFPS)
                {
                    _fpsText.color = fpsColors[i].Color;
                    break;
                }
            }
        }
        else
        {
            _fpsText.text = "";
        }
    }
}
