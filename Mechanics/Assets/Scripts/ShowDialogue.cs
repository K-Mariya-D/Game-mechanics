using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialogue : MonoBehaviour
{
    public TextAsset FileName;
    public string NPCName;
    public GameObject _dialogueWindow; //Canvas
    public Font font; //Шрифт текста

    private Dialogue _dialogue;
    private Transform _panel;
    private Button _continue;
    private TextMeshProUGUI _npcName;
    private int _nodeInd;
    private void Start()
    {
        _dialogue = Dialogue.Load(FileName);
    }
    /// <summary>
    /// Переход к выбору ответов по нажатию кнопки _continue
    /// </summary>
    private void Continue()
    {
        //Очистка панели от реплики npc (если она есть)
        if (_panel.childCount > 0)
        {
            Text currentReplic = _panel.GetChild(0).GetComponent<Text>();
            currentReplic.transform.parent = null;
            Destroy(currentReplic.gameObject); 
        }
        PrintAnswers();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartDialogue();
    }

    /// <summary>
    /// Запускает диалог
    /// </summary>
    private void StartDialogue()
    {
        _dialogueWindow.SetActive(true);
        _npcName = _dialogueWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _panel = _dialogueWindow.transform.GetChild(2).GetComponent<Transform>();
        _continue = _dialogueWindow.transform.GetChild(3).GetComponent<Button>();
        _npcName.text = NPCName;
        _nodeInd = 0;

        _continue.onClick.RemoveAllListeners();
        _continue.onClick.AddListener(Continue);
        StartCoroutine(PrintReplic(_dialogue.Nodes[_nodeInd].npcText));
    }
    /// <summary>
    /// Печатет конкретную реплику побуквенно 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator PrintReplic(string text)
    {
        Debug.Log("Метод PrintReplic запущен");
        float speed = 0.02f;
        int i = 0;

        CreateText(_panel,"NpcReplic", "");
        Text replic = _panel.GetChild(0).GetComponent<Text>();
        while (i < text.Length)
        {
            replic.text += text[i];
            i++;
            yield return new WaitForSeconds(speed);
        }
        Debug.Log("Метод PrintReplic завершён");
    }
    /// <summary>
    /// Выводит на экран варианты ответов к реплике npc
    /// </summary>
    private void PrintAnswers()
    {
        _continue.gameObject.SetActive(false);
        _npcName.gameObject.SetActive(false);

        Dialogue.Node currentNode = _dialogue.Nodes[_nodeInd];
        Dialogue.Answer[] currentAnswers = currentNode.answers;

        int j = 0;

        for (int i = 0; i < currentAnswers.Length; i++)
        {
            GameObject btn =  CreateButton(i.ToString(), currentAnswers[i].text);
            Debug.Log(i);
            j = i; 
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(j);
                if (currentAnswers[j].exit == "true")  //Используется другая переменная, так как если брать i будет использоваться её значение в последний момент (нажатие), а не текущая итерация цикла
                    EndDialogue();
                else
                {
                    Debug.Log(currentAnswers[j].toNode);
                    _nodeInd = currentAnswers[j].toNode;
                    PrintNode();
                }
            });
        }
    }
    /// <summary>
    /// Выводит на экран реплику npc
    /// </summary>
    private void PrintNode()
    {
        Debug.Log("метод PrintNode запущен!");
        _continue.gameObject.SetActive(true);
        _npcName.gameObject.SetActive(true);

        int count = _panel.childCount;
        //Если на панеле есть кнопки удаляем их  
        while (count > 0)
        {
            GameObject btn = _panel.GetChild(0).gameObject;
            btn.transform.parent = null;
            Destroy(btn);
            Debug.Log("Кнопка " + count + " удалена");
            count--;
        }
        Debug.Log("метод PrintNode закончен!");
        StartCoroutine(PrintReplic(_dialogue.Nodes[_nodeInd].npcText));
    }
    private void EndDialogue()
    {
        _dialogueWindow.SetActive(false);
    }
    /// <summary>
    /// Создание кнопки внутри панели 
    /// </summary>
    /// <param name="elemName"></param>
    /// <param name="text"></param>
    private GameObject CreateButton(string elemName, string text)
    {
        //Создание кнопки
        GameObject btn = new GameObject("btn" + elemName, typeof(Image), typeof(Button));
        Color color = btn.GetComponent<Image>().color;
        color.a = 0;
        btn.GetComponent<Image>().color = color;
        btn.transform.SetParent(_panel.GetComponent<VerticalLayoutGroup>().transform);
        //Настройка положения кнопки на панеле
        RectTransform btnRect = btn.GetComponent<RectTransform>();
        btnRect.SetParent(_panel);
        btnRect.localScale = Vector2.one;

        //Создание текста в кнопке
        CreateText(btn.transform, elemName, text);

        return btn;
    }
    /// <summary>
    /// Создание текста внутри поданного объекта 
    /// </summary>
    /// <param name="elemName"></param>
    /// <param name="text"></param>
    private void CreateText(Transform parent, string elemName, string text)
    {
        Debug.Log("Метод CreateText запущен");
        Debug.Log(text);
        //Создание текста 
        GameObject txt = new GameObject("txt" + elemName, typeof(Text));
        txt.transform.SetParent(parent);
        txt.GetComponent<Text>().font = font;
        txt.GetComponent<Text>().text = text;
        txt.GetComponent<Text>().color = Color.white;
        txt.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        RectTransform rt = txt.GetComponent<RectTransform>();
        //Настройка позиции текста
        rt.SetParent(parent);
        rt.localScale = Vector2.one;
        rt.localPosition = Vector2.zero;
    }
}
