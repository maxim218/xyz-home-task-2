using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private GameObject prefabBase = null;
    [SerializeField] private GameObject prefabCorner = null;
    [SerializeField] private GameObject prefabPerson = null;

    private const int StartX = -205;
    private const int StartY = 7;
    
    private void CreateGridElement(int i, int j, string content) {
        int index = i * 10 + j;
        char type = content[index];

        Vector3 position = new Vector3(StartX + j, StartY - i, 20);

        switch (type) {
            // simple block
            case '1': {
                GameObject obj = Instantiate(prefabBase) as GameObject;
                obj.transform.position = position;
                return;
            }
            // hero
            case '9': {
                GameObject obj = Instantiate(prefabPerson) as GameObject;
                obj.transform.position = position;
                return;
            }
            // corner element
            case '2': {
                GameObject obj = Instantiate(prefabCorner) as GameObject;
                obj.transform.position = position;
                obj.transform.Rotate(0, 0, 180);
                return;
            }
            // corner element
            case '3': {
                GameObject obj = Instantiate(prefabCorner) as GameObject;
                obj.transform.position = position;
                obj.transform.Rotate(0, 0, 90);
                return;
            }
            // corner element
            case '4': {
                GameObject obj = Instantiate(prefabCorner) as GameObject;
                obj.transform.position = position;
                obj.transform.Rotate(0, 0, -90);
                return;
            }
            // corner element
            case '5': {
                GameObject obj = Instantiate(prefabCorner) as GameObject;
                obj.transform.position = position;
                obj.transform.Rotate(0, 0, 0);
                return;
            }
        }
    }
    
    private void Start() {
        // load resource
        const string path = "level";
        TextAsset asset = Resources.Load<TextAsset>(path);
        string content = asset.text;
        
        
        // delete chars
        string bufferString = "";
        foreach (char charElement in content) {
            try {
                int value = int.Parse(charElement + "");
                bufferString += value;
            } catch {
                const string msg = "Empty char";
                Debug.Log(msg);
            }
        }

        // create grid of level
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                CreateGridElement(i, j, bufferString);
            }
        }
    }
}
