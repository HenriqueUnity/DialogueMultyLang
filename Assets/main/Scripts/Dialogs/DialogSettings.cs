using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="New Dialogue",menuName ="NewDialogue/Dialogue")]
public class DialogSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentences;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}
[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor: Editor
{
    public override void OnInspectorGUI()
    {
       DrawDefaultInspector();
        DialogSettings ds =  (DialogSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentences;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentences != "")
            {
                ds.dialogues.Add(s);
                ds.speakerSprite = null;
                ds.sentences = "";
            }
        }
    }
}

#endif