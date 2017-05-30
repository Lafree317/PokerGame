/*
 * 
 *      Title:翻牌游戏
 * 
 *      Description:Unity学习项目
 * 
 *      Date:2017年5月30日10:19:44
 * 
 *      Version:1
 * 
 *      Modify Recoder:
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokerController : MonoBehaviour {
    #region 牌控件
    // 定义20个牌控件
    public Button btn0_0;                                   // 0 行 0 列
    public Button btn0_1;
    public Button btn0_2;
    public Button btn0_3;
    public Button btn0_4;

    public Button btn1_0;                                   // 1 行 0 列
    public Button btn1_1;
    public Button btn1_2;
    public Button btn1_3;
    public Button btn1_4;

    public Button btn2_0;                                   // 2 行 0 列
    public Button btn2_1;
    public Button btn2_2;
    public Button btn2_3;
    public Button btn2_4;

    public Button btn3_0;                                   // 3 行 0 列
    public Button btn3_1;
    public Button btn3_2;
    public Button btn3_3;
    public Button btn3_4;
    #endregion
    private int[,] _CardsArray = new int[4, 5];             // 4行5列存放游戏内部数字牌
    private int _IntFirstNumCard;                           // 第一张数字牌
    private int _IntSecondNumCard;                          // 第二章数字牌
    private Button _BtnFirstNumCard;                        // 第一个牌控件;
    private Button _BtnSecondNumCard;                       // 第二个牌控件
    private bool _BoolIsFirstClick = true;                  // 是否为第一次点击牌面
    // Use this for initialization
    void Start () {
        // 初始化二维数组,准备游戏相关后台数据
        StartPrepareGameData();

        // 使用"携程"技术,2秒进行轮询检测
        StartCoroutine(JudgePoker(1));
        
	}

    // 使用"携程"技术,2秒进行轮询检测
    IEnumerator JudgePoker(int time) {
        while (true) {
            print("2秒");
            JudgePokerEquals(_BtnFirstNumCard, _BtnSecondNumCard, _IntFirstNumCard, _IntSecondNumCard);
            // 等待制定秒数
            yield return new WaitForSeconds(time);
        }
    }

    /// <summary>
    /// 判断两张排数相同
    /// 功能:
    ///     如果两张牌相同,则变成灰色.
    ///     如果不相同,牌再反转回去
    /// </summary>
    /// <param name="btn1"></param>
    /// <param name="btn2"></param>
    /// <param name="numberCard1"></param>
    /// <param name="numberCard2"></param>
    private void JudgePokerEquals(Button btn1,Button btn2,int numberCard1,int numberCard2) {
        if (btn1 == null || btn2 == null) {
            return;
        }
        if (numberCard1 == numberCard2) {
            // 两张牌相同
            GaryCard(btn1,numberCard1);
            GaryCard(btn2, numberCard1);
            _BtnFirstNumCard = null;
            _BtnSecondNumCard = null;
            _IntFirstNumCard = -1;
            _IntSecondNumCard = -2;
        } else {
            string bgImgName = "Image/CardBG";
            ChangeBtnImageWithImageName(btn1, bgImgName);
            ChangeBtnImageWithImageName(btn2, bgImgName);
            // 两张牌不同
        }
    }

    // 初始化二维数组,准备游戏相关后台数据,对每个数组下表,随机添加数值
    // 添加初始背景图
    private void StartPrepareGameData() {
        // 遍历二位数组
        for (int i = 0; i < 4; i++) {                  // 行
            for (int j = 0; j < 5; j++) {              // 列
                _CardsArray[i,j] = GetRandom(1,5);
                print(_CardsArray[i, j]);
            }
        }


        #region 初始化按钮图片
        // 赋值卡背图片
        btn0_0.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG",typeof(Sprite)) as Sprite;
        btn0_1.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn0_2.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn0_3.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn0_4.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;

        btn1_0.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn1_1.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn1_2.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn1_3.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn1_4.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;

        btn2_0.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn2_1.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn2_2.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn2_3.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn2_4.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;

        btn3_0.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn3_1.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn3_2.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn3_3.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        btn3_4.GetComponent<Image>().overrideSprite = Resources.Load("Image/CardBG", typeof(Sprite)) as Sprite;
        #endregion
    }

    // 随机数
    private int GetRandom(int min,int max) {
        int result = Random.Range(min, max);
        return result;
    }
    #region 玩家"牌面:"的点击相应

    // 第一行
    public void ClickButton0_0() {
        ProcessUserCLick(btn0_0,0, 0);
    }
    public void ClickButton0_1() {
        ProcessUserCLick(btn0_1,0, 1);
    }
    public void ClickButton0_2() {
        ProcessUserCLick(btn0_2,0, 2);
    }
    public void ClickButton0_3() {
        ProcessUserCLick(btn0_3,0, 3);
    }
    public void ClickButton0_4() {
        ProcessUserCLick(btn0_4,0, 4);
    }

    // 第二行
    public void ClickButton1_0() {
        ProcessUserCLick(btn1_0,1, 0);
    }
    public void ClickButton1_1() {
        ProcessUserCLick(btn1_1, 1, 1);
    }
    public void ClickButton1_2() {
        ProcessUserCLick(btn1_2, 1, 2);
    }
    public void ClickButton1_3() {
        ProcessUserCLick(btn1_3, 1, 3);
    }
    public void ClickButton1_4() {
        ProcessUserCLick(btn1_4, 1, 4);
    }

    // 第三行
    public void ClickButton2_0() {
        ProcessUserCLick(btn2_0, 2, 0);
    }
    public void ClickButton2_1() {
        ProcessUserCLick(btn2_1, 2, 1);
    }
    public void ClickButton2_2() {
        ProcessUserCLick(btn2_2, 2, 2);
    }
    public void ClickButton2_3() {
        ProcessUserCLick(btn2_3, 2, 3);
    }
    public void ClickButton2_4() {
        ProcessUserCLick(btn2_4, 2, 4);
    }


    // 第四行
    public void ClickButton3_0() {
        ProcessUserCLick(btn3_0, 3, 0);
    }
    public void ClickButton3_1() {
        ProcessUserCLick(btn3_1, 3, 1);
    }
    public void ClickButton3_2() {
        ProcessUserCLick(btn3_2, 3, 2);
    }
    public void ClickButton3_3() {
        ProcessUserCLick(btn3_3, 3, 3);
    }
    public void ClickButton3_4() {
        ProcessUserCLick(btn3_4, 3, 4);
    }
    #endregion

    /// <summary>
    /// 处理牌点击事件
    /// </summary>
    /// <param name="btn">点击的按钮</param>
    /// <param name="rowsNumber">行</param>
    /// <param name="columsNumber">列</param>
    private void ProcessUserCLick(Button btn,int rowsNumber,int columsNumber) {
        
        
        if (_BoolIsFirstClick == true) {
            // 点击第一张牌
            _BoolIsFirstClick = false;
            _IntFirstNumCard = _CardsArray[rowsNumber, columsNumber];
            _BtnFirstNumCard = btn;
            DisplayPokerCardByNumber(_BtnFirstNumCard, _IntFirstNumCard);
            // 显示对应的额图形牌
        } else {
            _BoolIsFirstClick = true;
            // 点击第二张牌
            _IntSecondNumCard = _CardsArray[rowsNumber, columsNumber];
            _BtnSecondNumCard = btn;
            
            DisplayPokerCardByNumber(_BtnSecondNumCard, _IntSecondNumCard);
            
        }
    }


    /// <summary>
    /// 动态给btn添加图片牌
    /// </summary>
    /// <param name="btn">被操作的按钮</param>
    /// <param name="numberCard">数字牌</param>
    private void DisplayPokerCardByNumber(Button btn,int numberCard) {
        string cardName = "Card/" + numberCard.ToString();
        ChangeBtnImageWithImageName(btn, cardName);
        
    }
    // 灰色按钮图片
    private void GaryCard(Button btn, int numberCard) {
        string cardName = "Card/" + numberCard.ToString() + "H";
        ChangeBtnImageWithImageName(btn, cardName);
    }
    private void ChangeBtnImageWithImageName(Button btn,string imageName) {
        btn.GetComponent<Image>().overrideSprite = Resources.Load(imageName, typeof(Sprite)) as Sprite;
    }

    

    
}
