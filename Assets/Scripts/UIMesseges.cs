using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMesseges : MonoBehaviour
{
    public static UIMesseges Instance { get; private set; }

    [SerializeField]
    private Transform textMessage;
    [SerializeField]
    private float timeToRefresh = 1f;

    private List<Transform> messages;

    private float timer = 0;

    public List<string> Texts { get; private set; }

    private void Awake()
    {
        Instance = this;

        messages = new List<Transform>();
        Texts = new List<string>();
    }

    private void LateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timeToRefresh)
        {
            foreach (Transform transform in messages)
            {
                Destroy(transform.gameObject);
            }

            messages.Clear();

            int i = 0;
            foreach (string text in Texts)
            {
                Transform textObject = Instantiate(textMessage, transform);
                textObject.position += new Vector3(0, i * 60, 0);
                messages.Add(textObject);
                i++;

                Text textField = textObject.GetComponent<Text>();
                textField.text = text;
            }

            Texts.Clear();

            timer = 0;
        }
    }
}
