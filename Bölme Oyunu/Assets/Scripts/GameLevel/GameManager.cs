using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject karePrefab;

    [SerializeField]
    private Transform karelerPaneli;

    [SerializeField]
    private Text soruText;

    private GameObject[] karelerDizisi = new GameObject[25];

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private Sprite[] karesprites;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    AudioSource audioSource;

    public AudioClip butonSesi;


    List<int> bolumDegerleriListesi = new List<int>();

    int bolenSayi, bolunenSayi;
    int kacinciSoru;
    int dogruSonuc;
    int butonDegeri;
    bool butonaBasilsinmi;

    int kalanHak;

    KalanHakManager kalanHakManager;
    PuanManager puanManager;

    string soruZorlukSeviyesi;

    GameObject gecerliKare;

    private void Awake() {

        kalanHak = 3;

        audioSource = GetComponent<AudioSource>();
        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kalanHakManager = Object.FindObjectOfType<KalanHakManager>();
        puanManager = Object.FindObjectOfType<PuanManager>();


        kalanHakManager.kalanHakKontrolEt(kalanHak);

    }
 
    void Start()
    {
        butonaBasilsinmi = false;
        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        karelerPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kareleriOlustur();
        bolumElemanlariniTexteYazdir();
        Invoke("karelerPaneliAc", 0.3f);
        Invoke("soruPaneliAc", 0.7f);
    }

     void kareleriOlustur()
    {
        for (int i = 0; i < 25; i++) {

            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = karesprites[Random.Range(0, karesprites.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => butonaBasildi());
            karelerDizisi[i] = kare;

        }

    }

     void bolumElemanlariniTexteYazdir() {

        foreach (var kare in karelerDizisi) {

            int rastgeleDeger = Random.Range(1, 13);
            bolumDegerleriListesi.Add(rastgeleDeger);
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();

         }

    }

     void soruPaneliAc() {

        soruSor();
        butonaBasilsinmi = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.7f).SetEase(Ease.OutBack);
            
    }

     void karelerPaneliAc()
    {

        karelerPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);

    }

     void soruSor() {

        bolenSayi = Random.Range(2, 11);
        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);
        dogruSonuc = bolumDegerleriListesi[kacinciSoru];
        bolunenSayi = bolenSayi * dogruSonuc;

        if (bolunenSayi <= 40)
        {

            soruZorlukSeviyesi = "kolay";

        }
        else if (bolunenSayi > 40 && bolunenSayi <= 80)
        {

            soruZorlukSeviyesi = "orta";

        }
        else {

            soruZorlukSeviyesi = "zor";

        }
        

        soruText.text = bolunenSayi.ToString() + " : " + bolenSayi.ToString();

    }

     void butonaBasildi() {

        if (butonaBasilsinmi)
        {

            audioSource.PlayOneShot(butonSesi);
            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            sonucuKontrolEt();
        }
    }

    void sonucuKontrolEt() {

        if (butonDegeri == dogruSonuc)
        {

            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;

            
            puanManager.puaniArtir(soruZorlukSeviyesi);
            bolumDegerleriListesi.RemoveAt(kacinciSoru);

            if(bolumDegerleriListesi.Count > 0){

                soruPaneliAc();

            }
            else{

                oyunBitti();

            }

            


        }
        else {

            kalanHak--;
            kalanHakManager.kalanHakKontrolEt(kalanHak);

            if (kalanHak == 0) {
                
                oyunBitti();
                
            }
        
        }

    }

    void oyunBitti() {
        Debug.Log("Oyun Bitti");
        sonucPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);

    }

}
