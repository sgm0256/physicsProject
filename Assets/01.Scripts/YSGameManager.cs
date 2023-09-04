using UnityEngine;

public class YSGameManager : MonoBehaviour
{
    public static YSGameManager Instance;

    public bool IsUnderS;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is processing");
        }

        Instance = this;
    }
}
