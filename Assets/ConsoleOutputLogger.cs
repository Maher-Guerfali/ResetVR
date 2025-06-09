using UnityEngine;
using UnityEngine.UI;

public class ConsoleOutputLogger : MonoBehaviour
{
    public Text consoleText;
    private string logText;

    void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logText += logString + "\n";
        UpdateConsoleText();
    }

    void UpdateConsoleText()
    {
        consoleText.text = logText;
    }
}
