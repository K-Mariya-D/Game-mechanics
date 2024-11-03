using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт навешивается на NPS
/// </summary>
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

    bool IsPrinting;
    private int _nodeInd;
    private int _replicInd; //Текущий символ репики (для разделения на текста на несколько частей)
    private const int _maxReplicLength = 350; //Максимальное число символов реплики на экране
    private void Start()
    {
        _dialogue = Dialogue.Load(FileName);
    }
    /// <summary>
    /// Переход к выбору ответов по нажатию кнопки _continue
    /// </summary>
    private void Continue()
    {
        Text currentReplic = _panel.GetChild(0).GetComponent<Text>();
        Debug.Log("0: " + _replicInd + "-" + _dialogue.Nodes[_nodeInd].npcText.Length);
        //Если реплика печатаетя - пропускаем анимацию, если не печатется и не вся реплика дописана - переход к следующейчасти реплики. Иначе переходим к ответам
        if (IsPrinting)
        {
            StopAllCoroutines();

            //Попытка переставлять _replicInd в правильную позицию (чтобы потом можно было дописать реплику, если была написана не вся)
            int i = _dialogue.Nodes[_nodeInd].npcText.Length - 1;
            char[] chars = new char[] { '!', '.', '?' };
            Debug.Log(_dialogue.Nodes[_nodeInd].npcText[..i].LastIndexOfAny(chars));

            while (_dialogue.Nodes[_nodeInd].npcText[..i].LastIndexOfAny(chars) > _maxReplicLength)
            {
                i = _dialogue.Nodes[_nodeInd].npcText[..i].LastIndexOfAny(chars);
            }

            currentReplic.text = _dialogue.Nodes[_nodeInd].npcText[..(i + 1)];
            _replicInd = i;
            IsPrinting = false;
            Debug.Log("1: " + _replicInd + "-" + _dialogue.Nodes[_nodeInd].npcText.Length);
        }
        else if (_replicInd < _dialogue.Nodes[_nodeInd].npcText.Length - 1)
        {
            currentReplic.transform.parent = null;
            Destroy(currentReplic.gameObject);

            Debug.Log("2: " + _replicInd);
            StartCoroutine(PrintReplic(_dialogue.Nodes[_nodeInd].npcText[(_replicInd + 1)..]));
        }
        else
        {
            _replicInd = 0;

            currentReplic.transform.parent = null;
            Destroy(currentReplic.gameObject);

            PrintAnswers();
        }
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
        _replicInd = 0;
        IsPrinting = false;

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
        IsPrinting = true;
        float speed = 0.01f;
        int i = 0;

        CreateText(_panel,"NpcReplic", "");
        Text replic = _panel.GetChild(0).GetComponent<Text>();

        char[] chars = new char[] { '!', '.', '?' };
        while (i < text.Length && !(text[i].Equals(chars) && (text.IndexOfAny(chars, i+1) > _maxReplicLength)))
        {
            replic.text += text[i];
            i++;
            _replicInd++;
            yield return new WaitForSeconds(speed);
        }
        IsPrinting = false;
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

        for (int i = 0; i < currentAnswers.Length; i++)
        {
            GameObject btn =  CreateButton(i.ToString(), currentAnswers[i].text);

            int index = i;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(index);
                if (currentAnswers[index].exit == "true")  //Используется другая переменная, так как если брать i будет использоваться её значение в последний момент (нажатие), а не текущая итерация цикла
                    EndDialogue();
                else
                {
                    _nodeInd = currentAnswers[index].toNode;
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
