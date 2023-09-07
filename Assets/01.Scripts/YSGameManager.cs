using UnityEngine;

public class YSGameManager : MonoBehaviour
{
    public static YSGameManager Instance;

    [SerializeField] private Material _material;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is processing");
        }

        Instance = this;
    }
}
