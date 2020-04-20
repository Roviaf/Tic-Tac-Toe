using UnityEngine;
using UnityEngine.UI;

public class ConceptArt : MonoBehaviour
{
    public GameObject conceptArt;
    public GameObject[] conceptArtImage;
    int currentImage = 0;

    public void ResetCurrentConceptArt()
    {
        for (int i = 0; i < conceptArtImage.Length; i++)
        {
            conceptArtImage[i].SetActive(false);
        }
        conceptArtImage[0].SetActive(true);
    }

    private void Update()
    {
        if (conceptArt.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(currentImage >= 0 && currentImage + 1 < conceptArtImage.Length){currentImage++;}
                conceptArtImage[currentImage].SetActive(true);
                conceptArtImage[currentImage-1].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(currentImage >= 1 && currentImage <= conceptArtImage.Length)currentImage--;
                conceptArtImage[currentImage].SetActive(true);
                conceptArtImage[currentImage+1].SetActive(false);
            }
        }
    }
}