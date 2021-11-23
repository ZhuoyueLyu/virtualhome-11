# Python -> Unity
we can create a class for the data.
## 1. Create a class (in Unity)

```c#
public class NetworkRequest
{
    public string id;
    public string action;
    public IList<int> intParams;
    public IList<string> stringParams;
}
```

## 2. Send (in Python)
```Python
params = {'mode': mode, 'image_width': image_width, 'image_height': image_height}
```

`json.dumps` the following
```Python
{   
    'id': 'aaa',
    'action': 'bbb',
    'intParams': [id_1, id_2], # integers are fine, we don't need to do dumps
    'stringParams': [json.dumps(params)] # but whenever we have dic inside dic, we need to dumps(serialize) it again
}
```

## 3. Receive (in Unity)

```c#
NetworkRequest newRequest = JsonConvert.DeserializeObject<NetworkRequest>(message)
```
or (I've never tested this though)
```c#
NetworkRequest newRequest = JsonUtility.FromJson<NetworkRequest>(message)
```

to get, for example, `intParams`, we just need to call `networkRequest.intParams`

*I saw some people say you might be able to load the data directly into a dictionary, we never tried, though.
```c#
var data = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(message);
```

# Unity -> Python
Python has dictionary, so we just need to serialize/deserialize it.
## 1. Send (In Unity)
```c#
message = JsonConvert.SerializeObject(data)
```

## 2. Receive (In Python)
```Python
data = json.loads(message)
```
