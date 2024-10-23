using System.IO;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/// <summary>
/// Читает xml-файл и создаёт диалог (массив node'ов)
/// </summary>
[XmlRoot("dialogue")]
public class DialogueReader
{
    [XmlElement("node")]
    public Node[] Nodes;

    [System.Serializable]
    public class Node
    {
        [XmlAttribute("npcText")]
        public string npcText;
        [XmlElement("answer")]
        public Answer[] answers;
    }
    [System.Serializable]
    public class Answer
    {
        [XmlAttribute("text")]
        public string text;
        [XmlAttribute("id")]
        public int toNode;
        [XmlAttribute("exit")]
        public bool exit;
    }
    public static DialogueReader Load(TextAsset _xml)
    { 
        XmlSerializer serializer = new XmlSerializer(typeof(DialogueReader));
        StringReader sr = new StringReader(_xml.text);
        DialogueReader dialogue = serializer.Deserialize(sr) as DialogueReader;
        return dialogue;
    }
}
