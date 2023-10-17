using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    /*public RawImage imageDisplay;
    public string imageUrl = "https://source.unsplash.com/random";

    private void Start()
    {
        // Start the image loading process
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Display the downloaded image in the RawImage component
            imageDisplay.texture = texture;
        }
    }*/

    public List<RawImage> imageDisplays;
    public string apiUrl = "YOUR_API_ENDPOINT_HERE";

    private void Start()
    {
        // Start the image loading process for each RawImage in the list
        for (int i = 0; i < imageDisplays.Count; i++)
        {
            StartCoroutine(LoadImage(i));
        }
    }

    private IEnumerator LoadImage(int index)
    {
        if (index < 0 || index >= imageDisplays.Count)
        {
            Debug.LogError("Invalid index: " + index);
            yield break;
        }

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(apiUrl);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error loading image: " + www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Display the downloaded image in the RawImage component
            if (index < imageDisplays.Count)
            {
                imageDisplays[index].texture = texture;
            }
        }
    }

}
