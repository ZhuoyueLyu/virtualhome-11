using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SwitchPointCloudsNew : MonoBehaviour
{
    public Toggle myToggle1;
    public Toggle myToggle2;
    public Toggle myToggle3;
    public Toggle myToggle4;
    public Toggle myToggle5;
    public Toggle myToggle6;
    public Toggle myToggle7;
    public Toggle myToggle8;
    public Toggle myToggle9;
    public Toggle myToggle10;
    private Client client;
    private int[] ChunkIds;
    private bool needUpdate = false;

    // // Start is called before the first frame update
    void Start()
    {
        client = GameObject.FindObjectOfType<Client>();
        myToggle1.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle2.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle3.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle4.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle5.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle6.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle7.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle8.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle9.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggle10.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
    }

    void Update()
    {
        if (needUpdate)
        {
            foreach (float id in ChunkIds)
            {
                var relativePath = "Assets/ply-common/" + (id).ToString() + ".ply";
                Debug.Log(relativePath);
                AssetDatabase.ImportAsset(relativePath);
            }

            needUpdate = false;
        }
    }

    void ToggleValueChanged()
    {
        int myToggle1IsOn = myToggle1.isOn ? 1 : 0;
        int myToggle2IsOn = myToggle2.isOn ? 1 : 0;
        int myToggle3IsOn = myToggle3.isOn ? 1 : 0;
        int myToggle4IsOn = myToggle4.isOn ? 1 : 0;
        int myToggle5IsOn = myToggle5.isOn ? 1 : 0;
        int myToggle6IsOn = myToggle6.isOn ? 1 : 0;
        int myToggle7IsOn = myToggle7.isOn ? 1 : 0;
        int myToggle8IsOn = myToggle8.isOn ? 1 : 0;
        int myToggle9IsOn = myToggle9.isOn ? 1 : 0;
        int myToggle10IsOn = myToggle10.isOn ? 1 : 0;

        Debug.Log("We are sending Message!");
        client.requester.SetMessage(
            myToggle1IsOn.ToString() + "," + myToggle2IsOn.ToString() + "," +
            myToggle3IsOn.ToString() + "," + myToggle4IsOn.ToString() + "," +
            myToggle5IsOn.ToString() + "," + myToggle6IsOn.ToString() + "," +
            myToggle7IsOn.ToString() + "," + myToggle8IsOn.ToString() + "," +
            myToggle9IsOn.ToString() + "," + myToggle10IsOn.ToString());
    }

    // int mod(int x, int m)
    // {
    //     int r = x % m;
    //     return r < 0 ? r + m : r;
    // }

    public void UpdateChunks(string infoString)
    {
        Debug.Log(infoString);
        if (infoString != "Nothing")
        {
            needUpdate = true;
            ChunkIds = System.Array.ConvertAll(infoString.Split('_'), int.Parse);
            Debug.Log("We are updating chunks!");
        }
    }
}