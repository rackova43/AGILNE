using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextureLoader : MonoBehaviour
{
    public MeshRenderer sphereRenderer; // Reference na MeshRenderer vašej gule
    private List<string> imageUrls = new List<string>(); // Zoznam URL adries obrázkov

    // Na začiatku hry stiahnite zoznam fotografií
    void Start()
    {
        StartCoroutine(DownloadImageUrls());
    }

    IEnumerator DownloadImageUrls()
    {
        string apiUrl = "https://jsonplaceholder.typicode.com/photos";
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error downloading images list: " + request.error);
        }
        else
        {
            // Spracujte JSON a uložte URL adresy obrázkov
            Photo[] photos = JsonUtility.FromJson<PhotosArray>("{\"array\":" + request.downloadHandler.text + "}").array;
            foreach (var photo in photos)
            {
                imageUrls.Add(photo.url);
            }
            // Zobrazte náhodný obrázok po stiahnutí zoznamu
            ApplyRandomTexture();
        }
    }

    public void ApplyRandomTexture()
    {
        if (imageUrls.Count > 0)
        {
            int randomIndex = Random.Range(0, imageUrls.Count);
            StartCoroutine(DownloadAndApplyTextureCoroutine(imageUrls[randomIndex]));
        }
        else
        {
            Debug.LogError("Image URLs list is empty.");
        }
    }

    IEnumerator DownloadAndApplyTextureCoroutine(string imageUrl)
    {
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return textureRequest.SendWebRequest();

        if (textureRequest.isNetworkError || textureRequest.isHttpError)
        {
            Debug.LogError("Error downloading texture: " + textureRequest.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
            sphereRenderer.material.mainTexture = texture;
        }
    }

    [System.Serializable]
    private class PhotosArray
    {
        public Photo[] array;
    }

    [System.Serializable]
    public class Photo
    {
        public int id;
        public string title;
        public string url;
        public string thumbnailUrl;
    }
}
