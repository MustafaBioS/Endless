using UnityEngine;

public class TextScript : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI countDownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Coins: " + Player.coins.ToString();
        countDownText.text = Player.countDown.ToString();

        if (countDownText.text == "0")
        {
            countDownText.gameObject.SetActive(false);
        }
    }
}
