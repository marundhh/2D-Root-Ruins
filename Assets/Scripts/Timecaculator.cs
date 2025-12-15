using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Timecaculator : MonoBehaviour
{
    public Light2D globalLight;
    public float startValue = 1f;
    public float targetValue = 0.05f;
    public float transitionDuration = 60f; // Thời gian chuyển đổi (giây)
    private float currentTime = 0f;


   // public Animator animator;
    public static Timecaculator Instance;
    [SerializeField] public float timecount;
    [SerializeField] public int hours= 6, days = 1, month = 1, year = 2000, dayth= 2;
    [SerializeField] public string season = "Mùa Xuân";



    [SerializeField] Image image;
    [SerializeField] Sprite moring;
    [SerializeField] Sprite night;  
    [SerializeField] TMP_Text mua;
    [SerializeField] TMP_Text day;
    [SerializeField] TMP_Text gio;
    [SerializeField] TMP_Text thu;


    string Days;
    string Gio;
    string Mua;
    string Phut;
    string Thu;
    public void canvasTime()
    {
       
        Days = days.ToString()+"/"+month.ToString()+"/"+year.ToString();
        Gio = hours.ToString("00");
        Phut = timecount.ToString("00");
        Mua = season;
           
        mua.text = Mua;
        day.text = "Ngày: " + Days;
        gio.text = "Giờ: "+Gio + ":" +Phut;
        thu.text = Thu;
       
    }



    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }
    void Dayth()
    {
        switch (dayth)
        {
            case 2:
                Thu = "Thứ Hai";
                break;

            case 3:
                Thu = "Thứ Ba";
                break;
            case 4:
                Thu = "Thứ Tư";
                break;
            case 5:
                Thu = "Thứ Năm";
                break;
            case 6:
                Thu = "Thứ Sáu";
                break;
            case 7:
                Thu = "Thứ Bảy";
                break;
            case 8:
                Thu = "Chủ Nhật";
                break;
        }
    }
    void GetUp()
    {
        timecount = 0;
        hours = 6;
        days++;
    }
    public bool isnight;
    void UpdateNight()
    { 
        if(hours >= 18 && hours < 19)
        {
             float lerpValue = Mathf.Lerp(startValue, targetValue, timecount / transitionDuration);
            globalLight.intensity = lerpValue;
        }  else if(hours >= 19 && hours <= 24 ) 
        {
            globalLight.intensity = 0.05f;
        } else if(hours > 5 )
        {
            return;
        }
    }
    void UpateDay()
    {
        if (hours >=5 && hours < 6)
        {
            float lerpValue = Mathf.Lerp(targetValue, startValue, timecount / transitionDuration);
            globalLight.intensity = lerpValue;
        } else if (hours >= 6 && hours <= 18)
        {
            globalLight.intensity = 1;
        } else if(hours > 18 )
        {
            return;
        }
    }
    void Update()
    {
        Dayth();
        if (isnight)
        {
            UpdateNight();
        } else
        {
            UpateDay();
        }
        canvasTime();



        timecount = timecount + Time.deltaTime;
        if(timecount >= 60)
        {
            hours++;
            timecount = 0;
            if(hours >= 5 && hours < 18)
            {
                image.sprite = moring;
                
                isnight = false;


            } else 
            { image.sprite = night;
                isnight = true;   
            }
            if (hours >= 24) 
            {
                days++;
                dayth++;
                hours = 0;
                if(dayth == 8 )
                {
                    dayth = 2;
                }
                if(month <3 )
                {
                    season = "Mùa Xuân";
                }
                  else if(month > 3 && month < 6)
                {
                    season = "Mùa Hạ";
                } else if( month > 6 && month < 9 )
                {
                    season = "Mùa Thu";
                } else if(month <= 12 && month > 9 )
                {
                    season = "Mùa Đông";
                }
               switch (month)
                {
                    case 1: 
                        if(days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 2:

                        if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                        {
                            if (days >= 29)
                            {
                                month++;
                                days = 1;
                            }                      
                        }
                        else
                        {
                            if (days >= 28)
                            {
                                month++;
                                days = 1;
                            }
                        }
                        break;
                    case 3:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 4:
                        if (days >= 30)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 5:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 6:
                        if (days >= 30)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 7:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 8:
                        if (days >= 30)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 9:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 10:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 11:
                        if (days >= 30)
                        {
                            month++;
                            days = 1;
                        }
                        break;
                    case 12:
                        if (days >= 31)
                        {
                            month++;
                            days = 1;
                            if(month >= 12)
                            {
                                year++;
                                month = 1;                   
                            }
                        }
                        break;
                }
            }
        } 
    }
}
