// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class Timer : MonoBehaviour
// {
//     public Text timerText;
//     private float startTime;
//
//     private float pauseTime;
//
//     private int nextUpdate = 1;
//
//     private bool timerStopped;
//
//     private bool localActive;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         startTime = Time.time;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         // If the next update is reached
//         if (Time.time >= nextUpdate)
//         {
//             Debug.Log(Time.time + ">=" + nextUpdate);
//             // Change the next update (current second+1)
//             nextUpdate = Mathf.FloorToInt(Time.time) + 1;
//             // Call your fonction
//             UpdateEverySecond();
//         }
//         
//
//     }
//
//     // Update is called once per second
//     void UpdateEverySecond()
//     {
//         this.gameObject.GetComponent<MeshRenderer>().enabled = localActive;
//         localActive = !localActive;
//         float t = Time.time - startTime;
//         // string m = ((int) t / 60).ToString("00");
//         float s = (t % 60);
//         string data = (s % 23).ToString("00");
//
//         // timerText.text = m + ":" + s;
//         timerText.text = "2035-10-21, " + data + ":00";
//     }
//
//     public void TimerStop()
//     {
//         timerStopped = true;
//         pauseTime = Time.time;
//     }
//
//     public void TimerResume()
//     {
//         timerStopped = false;
//         float diff = Time.time - pauseTime;
//         startTime += diff;
//     }
//
//     public void TimerReset()
//     {
//         timerStopped = false;
//         startTime = Time.time;
//     }
// }