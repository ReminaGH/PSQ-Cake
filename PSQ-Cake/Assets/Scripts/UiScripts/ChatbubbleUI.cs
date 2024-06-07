using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChatbubbleUI : MonoBehaviour
{

    public static ChatbubbleUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI chatBubbleTextUIGUI;
    [SerializeField] public UnityEngine.UI.Image chatBubbleBackground;

    private Coroutine clearTextCoroutine;
    private Coroutine typingCoroutine;
    private Color originalTextColor;
    private Color originalBackgroundColor;

    public float fadeDuration = 1f;
    public float typingSpeed = 0.5f;
    public float clearTextAfterSeconds = 1.5f;
    public float clearTextAfterSecondsExtra = 0.1f;
    public Transform target;    
    public Vector3 offset;


    private void Start()
    {
        originalTextColor = chatBubbleTextUIGUI.color;
        originalBackgroundColor = chatBubbleBackground.color;
    }

    private void Awake()
    {
        if (chatBubbleTextUIGUI == null)
        {
            chatBubbleTextUIGUI = GetComponentInChildren<TextMeshProUGUI>();
        }
        Instance = this;
    }

    private void LateUpdate()
    {
        // Update the position of the text
        transform.position = target.position + offset;

        // Reset the rotation to zero to prevent flipping
        transform.rotation = Quaternion.identity;
    }

    //Currently a bug with the text writer, where it eats the first letter


    public void AddText(string text)
    {

        StartCoroutine(ResetColor());

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(text));
    }
   
    private IEnumerator TypeText(string newText)
    {

        
        // Type out each character one by one
        foreach (char letter in newText.ToCharArray())
        {
            chatBubbleTextUIGUI.text += letter;
            
            yield return new WaitForSeconds(typingSpeed);
            
           
        }
        if (clearTextCoroutine != null)
        {
            StopCoroutine(clearTextCoroutine);
        }

        clearTextCoroutine = StartCoroutine(ClearTextAfterDelay());

        // Start the coroutine to clear text after the specified time
        if (clearTextCoroutine != null)
        {
            StopCoroutine(clearTextCoroutine);
        }
        clearTextCoroutine = StartCoroutine(ClearTextAfterDelay());
    }
    private IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSeconds(clearTextAfterSeconds);

        float elapsedTime = 0f;
        Color originalColor = chatBubbleTextUIGUI.color;
        Color fadeColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        Color originalPanelColor = chatBubbleBackground.color;
        Color fadePanelColor = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 0);


        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            chatBubbleTextUIGUI.color = Color.Lerp(originalColor, fadeColor, elapsedTime / fadeDuration);
            chatBubbleBackground.color = Color.Lerp(originalPanelColor, fadePanelColor, elapsedTime / fadeDuration);
            yield return null;
        }

        chatBubbleTextUIGUI.text = string.Empty;
        chatBubbleTextUIGUI.color = originalColor;
        chatBubbleBackground.color = originalPanelColor;
    }

    public IEnumerator ResetColor() {

        yield return new WaitForSeconds(clearTextAfterSecondsExtra);


        chatBubbleTextUIGUI.text = string.Empty;
        chatBubbleTextUIGUI.color = originalTextColor;
        chatBubbleBackground.color = originalBackgroundColor;
    }
}

