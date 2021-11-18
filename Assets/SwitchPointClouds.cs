using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPointClouds : MonoBehaviour
{
    private int currIdx = 3;
    private int preIdx = 0;
    private int hour = 0;
    private int data = 1;
    public Slider mySlider;
    public Text myText;
    public Toggle myToggleDoor;
    public Toggle myToggleLight;

    // // Start is called before the first frame update
    void Start()
    {
        // mySlider.onValueChanged.AddListener((v) =>
        // {
        //     // myText.text = "2025-01-01, " + v.ToString("00") + ":00";
        //     preIdx = currIdx;
        //     currIdx = (int) v;
        //     hour = (int) v;
        //     updateTheData();
        // });

        myToggleDoor.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
        myToggleLight.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
    }

    void Update()
    {
        // int oldIdxLeft = mod(idx - 1, transform.childCount);
        // int oldIdxRight = mod(idx - 1, transform.childCount);

        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     data = mod(data + 1, 32); // january has 31 days so we want to see 31
        //     preIdx = currIdx;
        //     currIdx = currIdx + 1;
        //     updateTheData();
        // }
        // else if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     data = mod(data - 1, 32); // january has 31 days so we want to see 31
        //     preIdx = currIdx;
        //     currIdx = currIdx - 1;
        //     updateTheData();
        // }


        // if (Input.GetKeyDown("a")) {
        // if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        //     transform.GetChild(idx).gameObject.SetActive(false);
        //     idx = mod(idx - 1, transform.childCount); // the mod function is to wrap around the index
        //     transform.GetChild(idx).gameObject.SetActive(true);
        //     
        // } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
        //     transform.GetChild(idx).gameObject.SetActive(false);
        //     idx = mod(idx + 1, transform.childCount); // the mod function is to wrap around the index
        //     transform.GetChild(idx).gameObject.SetActive(true);
        // }
    }

    void updateTheData()
    {
        transform.GetChild(preIdx % transform.childCount).gameObject.SetActive(false);
        transform.GetChild(currIdx % transform.childCount).gameObject.SetActive(true);
        myText.text = "2025-01-" + data.ToString("00") + ", " + hour.ToString("00") + ":00";
    }

    void ToggleValueChanged()
    {
        int boolLight = myToggleLight.isOn ? 2 : 0;
        int boolDoor = myToggleDoor.isOn ? 1 : 0;
        transform.GetChild(currIdx).gameObject.SetActive(false);
        currIdx = boolLight + boolDoor;
        transform.GetChild(currIdx).gameObject.SetActive(true);
        // m_Text.text =  "New Value : " + m_Toggle.isOn;
    }

    int mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}