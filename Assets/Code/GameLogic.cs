using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{
    public InputField userInput;
    public Text gameLabel;
    public int minValue;
    public int maxValue;
    public Button gameButton;
    private bool isGameWon = false;
    private int randomNum;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        if (isGameWon)
        {
            gameLabel.text = "You Won! Guess a number between " + minValue + " and " + (maxValue - 1);
            isGameWon = false;
        }
        else
        {
            gameLabel.text = "Guess a number between " + minValue + " and " + (maxValue - 1);
        }
        userInput.text = "";
        randomNum = GetRandomNumber(minValue,maxValue);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick() 
    {
        string userInputValue = userInput.text;
        if (userInputValue != "") 
        {
            int answer = int.Parse(userInputValue);
            
            if (answer == randomNum)
            {
                gameLabel.text = "Correct!";
                isGameWon = true;
                ResetGame(); 
                //gameButton.interactable = false;
                Debug.Log("Correct!");

            }
            else if (answer > randomNum)
            {
                gameLabel.text = "Try Lower!";
                Debug.Log("Try Lower!");
            }
            else
            {
                gameLabel.text = "Try Higher";
                Debug.Log("Try Higher!");
            }
        }
        else
        {
            Debug.Log("Please input some number!");
        }
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        Debug.Log("min is" + min);
        Debug.Log("max is" + max);
        return random;
    }
}
