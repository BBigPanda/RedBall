using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;
    [SerializeField] private GameLevelsConfig _levelsConfig;

    public GameLevelsConfig LevelsConfig => _levelsConfig;

    private void Awake()                                
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
            
    
    
}