using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ButtonObjectPair02
{
    public Button button;
    public GameObject[] gameObjects;

    public ButtonObjectPair02(Button button, GameObject[] gameObjects)
    {
        this.button = button;
        this.gameObjects = gameObjects;
    }
}

public class Content02 : MonoBehaviour
{
    public ButtonObjectPair02[] buttonObjectPairs02;
    private Button lastClickedButton;

    void Start()
    {
        foreach (ButtonObjectPair02 pair in buttonObjectPairs02)
        {
            pair.button.onClick.AddListener(() => ToggleGameObjects(pair));
        }
    }

    void ToggleGameObjects(ButtonObjectPair02 currentPair)
    {
        if (lastClickedButton != null)
        {
            ButtonObjectPair02 lastPair = System.Array.Find(buttonObjectPairs02, pair => pair.button == lastClickedButton);
            DeactivateGameObjects(lastPair.gameObjects);
        }

        ActivateGameObjects(currentPair.gameObjects);

        lastClickedButton = currentPair.button;

        StartCoroutine(DeactivateAfterDelay(currentPair.gameObjects, 60f)); // Activate the timer
    }

    void ActivateGameObjects(GameObject[] gameObjects)
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(true);
        }
    }

    void DeactivateGameObjects(GameObject[] gameObjects)
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

    IEnumerator DeactivateAfterDelay(GameObject[] gameObjects, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified duration

        DeactivateGameObjects(gameObjects); // Deactivate after the delay
    }
}
