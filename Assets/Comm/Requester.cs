using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;

public class Requester : RunAbleThread
{
    // private Sonify sonify = GameObject.FindObjectOfType<Sonify> ();
    private SwitchPointCloudsNew controller = GameObject.FindObjectOfType<SwitchPointCloudsNew>();
    private string sendMessage = "S";
    private string receiveMessage;
    private bool locked = false;

    // protected override void Run()
    // {
    //     while (Running)
    //     {
    //         ForceDotNet.Force();
    //         using (RequestSocket client = new RequestSocket())
    //         {
    //             // client.Connect("tcp://127.0.0.1:123");
    //             client.Connect("tcp://localhost:5555");
    //             for (int i = 0; i < 10 && Running; i++)
    //             {
    //                 client.SendFrame(sendMessage);
    //                 sendMessage = "S";
    //                 receiveMessage = client.ReceiveFrameString();
    //                 // Debug.Log("N--");
    //                 // Debug.Log(sendMessage);
    //                 // Debug.Log(receiveMessage);
    //                 // if (receiveMessage == "received") {
    //                 //     unlockRequester();
    //                 // if (!Controller.isWaiting) {
    //                 //     // sonify.MappingSound(receiveMessage);
    //                 //     controller.UpdateConnections(receiveMessage);
    //                 // }
    //                 controller.UpdateChunks(receiveMessage);
    //             }
    //         }
    //
    //         NetMQConfig.Cleanup();
    //     }
    // }


    protected override void Run()
    {
        while (Running)
        {
            ForceDotNet.Force(); // this line is needed to prevent unity freeze after one use, not sure why yet
            using (RequestSocket client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5556");

                for (int i = 0; i < 10 && Running; i++)
                {
                    Debug.Log("Sending Hello");
                    client.SendFrame(sendMessage);
                    sendMessage = "S";
                    // ReceiveFrameString() blocks the thread until you receive the string, but TryReceiveFrameString()
                    // do not block the thread, you can try commenting one and see what the other does, try to reason why
                    // unity freezes when you use ReceiveFrameString() and play and stop the scene without running the server
//                string message = client.ReceiveFrameString();
//                Debug.Log("Received: " + message);
                    string message = null;
                    bool gotMessage = false;
                    while (Running)
                    {
                        gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
                        if (gotMessage) break;
                    }

                    if (gotMessage)
                    {
                        Debug.Log("Received " + message);
                        controller.UpdateChunks(message);
                    }
                }
            }

            NetMQConfig.Cleanup(); // this line is needed to prevent unity freeze after one use, not sure why yet
        }
    }

    public void SetMessage(string msg)
    {
        if (msg != sendMessage)
        {
            sendMessage = msg;
        }
    }

    public string GetMessage()
    {
        return receiveMessage;
    }

// public void lockRequester(){
//     locked = true;
// }
// public void unlockRequester(){
//     locked = false;
// }
}