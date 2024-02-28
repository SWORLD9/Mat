using System.Collections;
using TMPro;
using UnityEngine;
public class Platforms : MonoBehaviour
{
    [SerializeField] private int Time_Respawn_Platforms;

    [SerializeField] private GameObject[] _platforms_;

    [SerializeField] private GameObject WallBack; // Стена в старте игры

    [SerializeField] private int[] Numbers_Platforms;  // числа на платформах

    public TMP_Text text; // таймер

    public TMP_Text challenge;  // Текст задачи

    private int answer; // ответ уравнения

    private int sec;  // время

    private int _answerPlatform; // Правильная платформа

    private PlatformsClass[] platformsClass = new PlatformsClass[12];

    private bool respawn_platforms; // перезарядка платформ



    void Start()
    {
        sec = Time_Respawn_Platforms;

        StartCoroutine(Time());


        for (int i = 0; i < 12; i++) // Записываем всю информацию Платформ в класс

        {
            platformsClass[i] = new PlatformsClass(_platforms_[i], i, Numbers_Platforms[i]);

        }

        answer = platformsClass[_answerPlatform].answer;
    }


    void FixedUpdate()
    {

        text.text = sec.ToString();

        challenge.text = answer.ToString();
    }


    private IEnumerator Time() // отсчёт времени
    {
        yield return new WaitForSeconds(1);
        sec--;
        Check_Time();
    }


    private void Check_Time()
    {
        if (respawn_platforms && sec == 0) // возвращает платформы
        {
            sec = Time_Respawn_Platforms; respawn_platforms = false;

            WallBack.SetActive(false); // выключаю стену

            for (int i = 0; i < _platforms_.Length; i++)
            {

                _platforms_[i].SetActive(true);

            }



            _answerPlatform = Random.Range(0, 11);

            answer = platformsClass[_answerPlatform].answer;



        }
        else if (!respawn_platforms && sec == 0) // прячет все платформы кроме загаданной 
        {
            sec = 3; respawn_platforms = true;

            WallBack.SetActive(true); // включаю стену


            for (int i = 0; i < _platforms_.Length; i++)
            {
                if (i != _answerPlatform)
                {
                    _platforms_[i].SetActive(false);
                }
            }




        }

        StartCoroutine(Time());
    }





    public class PlatformsClass
    {
        public GameObject Platform;
        public int number;
        public int answer;

        public PlatformsClass(GameObject platform, int Number, int Answer)
        {
            Platform = platform;
            number = Number;
            answer = Answer;
        }




    }
}
