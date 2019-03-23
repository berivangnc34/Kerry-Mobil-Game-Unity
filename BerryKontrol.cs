using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//text ve canvas nesneleri için(menu)gerekli

public class BerryKontrol : MonoBehaviour {
    Animator animKontrol;
    Rigidbody2D fizikOlaylari;
    float horizontal;//dikey
    Vector2 vec;
    bool ziplaKontrol = false;
    bool oyunbittikontrol = false;
    GameObject kamera;
    Vector3 kamerailkpos;
    Vector3 kamerasonpos;
    SpriteRenderer sprite;
    public Text canText;
    public Text yildizText;
    int candegeri=100;
    public GameObject bitisbalon;
    bool kazandikmi = false;
    public GameObject kazanmapanel;
    public GameObject kaybetmepanel;
    public GameObject deniz;


    


	//start metodu oyun çalışırken ilk başta bir kere çalışır
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        animKontrol = GetComponent<Animator>();//componenti getir
        fizikOlaylari = GetComponent<Rigidbody2D>();
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kamerailkpos = kamera.transform.position - transform.position;//kamera pozisyonundan karakterin pozisyonunu çıkarıp aradaki farkı kaydederiz.

        kazanmapanel.SetActive(false);//panelleri kapatıyoruz
        kaybetmepanel.SetActive(false);//panelleri kapatıyoruz


        if (PlayerPrefs.GetInt("yildizsayisi") == 0)//böyle bir deger yoksa asagıda olutur
        {
            PlayerPrefs.SetInt("yildizsayisi", 0);//başlangıc degerini verir. veritabanını oluşturur.
        }
        if (PlayerPrefs.GetInt("sonlevel") == 0)//böyle bir deger yoksa asagıda olutur
        {
            PlayerPrefs.SetInt("sonlevel", 0);//başlangıc degerini verir. veritabanını oluşturur.
        }
        if (PlayerPrefs.GetInt("sonlevel") <int.Parse(SceneManager.GetActiveScene().name))
            PlayerPrefs.SetInt("sonlevel", int.Parse(SceneManager.GetActiveScene().name));//son levelle degiştirdik varolan leveli.oyuncu kaldıgı yerden devam ediyor




    }
    void FixedUpdate()//giriş,hareket(input=klavyeden griş işlemleri). "çagırılma süresi daha ayarlı" işlemlerinde fixed update kullanılır.
    {
        if (!oyunbittikontrol)//true da içeri girer(oyunbittikontrol hala false deger degiştirilmedi
        {
            if (Input.GetKeyDown(KeyCode.Space) && !ziplaKontrol)//havada bi sefer zıplasın diye zıplakontrol oluşturduk.
            {
                ziplaKontrol = true;
                fizikOlaylari.velocity = new Vector2(fizikOlaylari.velocity.x, 12);


            }
            karakterHareket();
           
        }
        if(!kazandikmi)
        kameraKontrol();

    }
	void kameraKontrol()
    {
        kamerasonpos = kamerailkpos + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kamerasonpos, 0.03f);//nereden nereye gidecegini söyleyen fonskiyon. 0.03 sinematik
    }
	
	void Update () {
        if(!oyunbittikontrol)
        animatorVeriGüncelle();
        if (candegeri > 0)
        {
            canText.text = candegeri.ToString();
        }
        else
            canText.text = "0";

        yildizText.text = PlayerPrefs.GetInt("yildizsayisi").ToString();//yıldizsayisini texte yazar

    }
    void animatorVeriGüncelle()
    {
        animKontrol.SetFloat("yatayKuvvet", Mathf.Abs(fizikOlaylari.velocity.x));//animkontrol üzerindeki yatay kuvvet değeri karakter üzerindeki yatay kuvvet değeri ile güncellenir.
        animKontrol.SetFloat("dikeyKuvvet", fizikOlaylari.velocity.y);
        animKontrol.SetFloat("mutlakdikeykuvvet", Mathf.Abs(fizikOlaylari.velocity.y));
    }
    void OnCollisionEnter2D(Collision2D Col)//herhangi collidere temas ettigi zaman çalışır.temas ettigi nesnenin tagı(ismine)göre işlem yapılır. trigger olmayan şeyler için
    {
        if (Col.collider.tag == "taban")
        {
            ziplaKontrol = false;

        }
        if (Col.collider.tag == "yavruKerry")
        {
            kazanma();
          /*  if (SceneManager.GetActiveScene().name != "9")
            {
                SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);//sahnemizin ismini alıp bir eklersek yeni levele geçeriz. string bir ifade oldugu için başına int.parse yazarız.sring ile int toplanmaz

            }*/

           
        }
     
       
     
   }
    void kazanma()
    {
        animKontrol.SetFloat("dikeyKuvvet", 0);
        oyunbittikontrol = true;
        kazandikmi = true;
        bitisbalon.GetComponent<balonkontrol>().dikeykuvvet = 5;
        Invoke("kazanmapanelac", 2);
    }
    void kazanmapanelac()
    {
        kazanmapanel.SetActive(true);
    }
    void oyunbitti()
    {
        oyunbittikontrol = true;
        deniz.GetComponent<dalgakontrol>().dikeykuvvet=0;//denizi durdurur
        kaybetmepanel.SetActive(true);//kayberme ekranını açar
        kazandikmi = true;//kamera takibini durdurur.
        sprite.color = new Color(255, 0, 0);//karakteri kırmızı yapar.s
    }
void OnTriggerEnter2D(Collider2D Col)//trigger da collider yazmaya gerek yok
    {
        if (Col.tag=="deniz")
        {
            sprite.color = new Color(255, 0, 0);
            oyunbittikontrol = true;//denizle temasta oyun bitti
            fizikOlaylari.gravityScale = 0;//üzerimizdeki yer çekimini 0'ladık.
            GetComponent<Collider2D>().enabled = false;//üzerimizdeki collider kapanır.colider kapatma sebebi diger nesnelere temas ettginde onların içinden geçebilsin
            float dikeykuvvet = Col.GetComponent<dalgakontrol>().dikeykuvvet;//o an temas ettigin şey Col olur. onun dikey kuvvetine erişiyoruz.
            fizikOlaylari.velocity = new Vector2(0, dikeykuvvet);
            kaybetmepanel.SetActive(true);
        }
        if (Col.tag== "yildiz")
        {
            int yildizsayisi = PlayerPrefs.GetInt("yildizsayisi");
            PlayerPrefs.SetInt("yildizsayisi", yildizsayisi + 1);
            Destroy(Col.transform.gameObject, 0.2f);//temas ettigin nesneyi yok et
        }
        if (Col.tag == "ok")
        {
            sprite.color = new Color(0, 171, 255);
           // fizikOlaylari.AddForce(new Vector2(5000, 0));//saga dogru kuvvet uygular.
            if (candegeri - 20 <= 0)
            {
                candegeri = 0;
                oyunbitti();
            }
            else
            {
                candegeri -= 20;
            }
            Invoke("rengidüzelt", 2);//FONKSİYONU YARIM SANİYE SONRA ÇAGIRIR.
        }
        if (Col.tag == "bomba")
        {
            sprite.color = new Color(0, 171, 255);
            // fizikOlaylari.AddForce(new Vector2(5000, 0));//saga dogru kuvvet uygular.
            if (candegeri - 30 <= 0)
            {
                candegeri = 0;
                oyunbitti();
            }
            else
            {
                candegeri -= 30;
            }
            Invoke("rengidüzelt", 2);//FONKSİYONU YARIM SANİYE SONRA ÇAGIRIR.
        }
    }   
    void rengidüzelt()
    {
        sprite.color = new Color(255, 255, 255);
    } 
    
    void karakterHareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");//hori hazır bir metod D tuşuna basılınca 1 değerini veya sağ ok tuşuna basılınca1 değerini,
        //A tuşuna veya sol ok tuşuna basılınca -1 değerigin alır. herhangi bir giriş olmayınca 0 degerini verir.
        if(horizontal>0.1)//sağa hareket oldugunda
        {
      
         transform.localScale = new Vector3(1, 1, 1);//karakterin yönünü sağa ayarlıyoruz.

        }
        else if (horizontal < -0.1)//sola hareket oldugu zaman
        {
            transform.localScale = new Vector3(-1, 1, 1);//karakteri yönünü sola çeviriyoruz

        }
        vec = new Vector2(horizontal * 5, fizikOlaylari.velocity.y);//karaktere kuvvet veriyoruz.o an üzerinde olan y kuveetini y değerini veriyoruz ki sadece x ekseninde değişiklik olsun
        fizikOlaylari.velocity = vec;//üzerimizde bulunan kuvvete vec değerini atiyoruz.
            
    }
    
  }

