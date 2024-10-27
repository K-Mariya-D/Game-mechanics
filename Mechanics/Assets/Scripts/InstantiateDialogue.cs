using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDialogue : MonoBehaviour
{
    public TextAsset FileName;
    public string NPCName;
    public GameObject _dialogueWindow; //Canvas
    public Font font; //Шрифт текста в кнопках

    private Dialogue _dialogue;
    [SerializeField]
    private Transform _panel;
    private Button _continue;
    private GameObject replic;
    private TextMeshProUGUI _npcName;
    private int _nodeInd;
    private bool _WasAnsw;
    private GameObject[] _buttons;
    private void Start()
    { 
        _dialogue = Dialogue.Load(FileName);
        _nodeInd = 0;
        _WasAnsw = false;
        
    }
    /// <summary>
    /// Переход к новой реплике по нажатию
    /// </summary>
    private void ToNextReplic()
    {
        Debug.Log("Метод ToNextReplic запущен");
        //Если ответы на текущую реплику уже были -> переход к следующей реплеке
        if (_WasAnsw)
        {
            Debug.Log("Печать следующей реплики");
            _WasAnsw = false;
            foreach (GameObject btn in _buttons) { Destroy(btn.gameObject); }
            PrintReplic(_dialogue.Nodes[_nodeInd].npcText);
        }
        else //Иначе -> вывод на экран ответов к текущей реплике
        {
            Debug.Log("Печать ответов к текущей реплике");
            Destroy(replic.gameObject);
            _WasAnsw = true;
            CreateAnswers(_dialogue.Nodes[_nodeInd].answers);
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

        _continue.onClick.RemoveAllListeners();
        _continue.onClick.AddListener(ToNextReplic);

        Dialogue.Node curentNode = _dialogue.Nodes[_nodeInd];
        StartCoroutine(PrintReplic(curentNode.npcText));

    }
    /// <summary>
    /// Печатет конкретную реплику
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator PrintReplic(string text)
    {
        replic = new GameObject("replic", typeof(TextMeshProUGUI));
        replic.GetComponent<TextMeshProUGUI>().text = "";
        replic.transform.SetParent(_panel);

        Debug.Log("Метод PrintReplic запущен");
        float speed = 0.2f;
        int i = 0;

        while (i < text.Length)
        {
            replic.GetComponent<TextMeshProUGUI>().text += text[i];
            i++;
            yield return new WaitForSeconds(speed);
        }
        Debug.Log("Метод PrintReplic завершён");
    }
    /// <summary>
    /// Создаёт кнопки с ответами
    /// </summary>
    /// <param name="arr"></param>
    private void CreateAnswers(Dialogue.Answer[] arr)
    {
        Debug.Log("Метод CreateAnswers запущен");
        _buttons = new GameObject[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            //Создание кнопки
            GameObject btn = new GameObject("btn" + i, typeof(Image), typeof(Button));
            Color color = btn.GetComponent<Image>().color;
            color.a = 0;
            btn.GetComponent<Image>().color = color;
            btn.transform.SetParent(_panel.GetComponent<VerticalLayoutGroup>().transform);
            //Настройка положения кнопки на панеле
            RectTransform btnRect = btn.GetComponent<RectTransform>();
            btnRect.SetParent(_panel);
            btnRect.localScale = Vector2.one;

            //Создание текста в кнопке
            GameObject txt = new GameObject("txt" + i, typeof(Text));
            txt.transform.SetParent(btn.transform);
            txt.GetComponent<Text>().font = font;
            txt.GetComponent<Text>().text = arr[i].text;
            txt.GetComponent<Text>().color = Color.white;
            txt.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            RectTransform rt = txt.GetComponent<RectTransform>();
            //Настройка позиции текста в кнопке
            rt.SetParent(btnRect);
            rt.localScale = Vector2.one;
            rt.localPosition = Vector2.zero;

            //Присвоение кнопке действия
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (arr[i].exit == "true")
                    EndDialogue();
                _nodeInd = arr[i].toNode;
                ToNextReplic();
            });
            
            _buttons.Append(btn);
        }
    }
    private void EndDialogue()
    {
        _dialogueWindow.SetActive(false);
        _nodeInd = 0;
    }

}
