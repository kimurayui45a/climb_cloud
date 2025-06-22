using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int coinPoint = 0;

    [SerializeField] private TextMeshProUGUI coinCount;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinCount();
    }

    public void AddCoin()
    {
        coinPoint++;
        UpdateCoinCount();
    }

    private void UpdateCoinCount()
    {
        if (coinCount != null)
        {
            coinCount.text = "Coins: " + coinPoint.ToString();
        }
    }


}
