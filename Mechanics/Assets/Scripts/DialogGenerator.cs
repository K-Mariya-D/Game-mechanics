using System.Collections;
using System.IO;
using System.Net.Http.Headers;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogGenerator : MonoBehaviour
{
    /// <summary>
    /// Имя генерируемого файла
    /// </summary>
    public string FileName = "NewDialoge";
    /// <summary>
    /// Массив для реплик NPS
    /// </summary>
    public DialogueNode[] Nodes;

    /// <summary>
    /// Класс реплики NPS: Текст и возможные ответы на неё
    /// </summary>
    [System.Serializable]
    public class DialogueNode
    {
        public string npcText;
        public PlayerAnswer[] playerAnswer;
    }

    /// <summary>
    /// Класс ответа игрока на реплику: Текст, к какой реплике перейти после, конечный ли ответ
    /// </summary>
    [System.Serializable]
    public class PlayerAnswer
    {
        public string text;
        public int toNode;
        public bool exit;
    }
    /// <summary>
    /// Генератор диалога
    /// </summary>
    public void Generate()
    {
        string path = Application.dataPath + "/Dialogues/" + FileName + ".xml";
        
        XmlNode userNode;
        XmlElement element;

        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("dialogue");
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = FileName;
        rootNode.Attributes.Append(attribute);
        xmlDoc.AppendChild(rootNode);

        for (int j = 0; j < Nodes.Length; j++)
        {
            userNode = xmlDoc.CreateElement("node");
            attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = j.ToString();
            userNode.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("npcText");
            attribute.Value = Nodes[j].npcText;
            userNode.Attributes.Append(attribute);

            for (int i = 0; i < Nodes[j].playerAnswer.Length; i++)
            {
                element = xmlDoc.CreateElement("answer");
                element.SetAttribute("text", Nodes[j].playerAnswer[i].text);
                if (Nodes[j].playerAnswer[i].toNode > 0) element.SetAttribute("toNode", Nodes[j].playerAnswer[i].toNode.ToString());
                if (Nodes[j].playerAnswer[i].exit) element.SetAttribute("exit", Nodes[j].playerAnswer[i].exit.ToString());
                userNode.AppendChild(element);
            }

            rootNode.AppendChild(userNode);
        }

        xmlDoc.Save(path);
        Debug.Log(this + " Создан XML файл диалога [ " + FileName + " ] по адресу: " + path);
    }
}
