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
    private TextMeshProUGUI _replicText;
    private Button _continue;
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
            _dialogueWindow.transform.GetChild(2).gameObject.SetActive(true);
            foreach (GameObject btn in _buttons) { Destroy(btn.gameObject); }
            PrintReplic(_dialogue.Nodes[_nodeInd].npcText);
        }
        else //Иначе -> вывод на экран ответов к текущей реплике
        {
            Debug.Log("Печать ответов к текущей реплике");
            _replicText.text = "";
            _dialogueWindow.transform.GetChild(2).gameObject.SetActive(false);
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
        _replicText = _dialogueWindow.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _continue = _dialogueWindow.transform.GetChild(3).GetComponent<Button>();
        _npcName.text = NPCName;

        _replicText.text = "";
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
        Debug.Log("Метод PrintReplic запущен");
        float speed = 0.2f;
        int i = 0;

        while (i < text.Length)
        {
            _replicText.text += text[i];
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
            //Создание текста в кнопке
            btn.GetComponent<Image>().color = color;
            GameObject txt = new GameObject("txt" + i, typeof(Text));
            txt.transform.SetParent(btn.transform);
            txt.GetComponent<Text>().font = font;
            txt.GetComponent<Text>().text = arr[i].text;
            txt.GetComponent<Text>().color = Color.white;
            //Присвоение кнопке действия
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (arr[i].exit == "true")
                    EndDialogue();
                _nodeInd = arr[i].toNode;
                ToNextReplic();
            });
            btn.transform.SetParent(_dialogueWindow.transform);
            _buttons.Append(btn);
        }
    }
    private void EndDialogue()
    {
        _dialogueWindow.SetActive(false);
        _nodeInd = 0;
        _replicText.text = "";
    }

}
