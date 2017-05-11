using UnityEngine;
using System.Collections;
// 使用 UI 必須加這行
using UnityEngine.UI;

public class Ranking : MonoBehaviour {
	    // 記錄投球數與命中數
	    int tossCount;
	    int hitCount;

	    void Start () {
		        tossCount = 0;
		        hitCount = 0;
		    }
	    
	    void Update () {
		        // 產生要顯示的字串
		        string msg= "擊中/投出: " + hitCount + "/" + tossCount;
		        if(tossCount==0) msg+="(0%)";
		        else msg+="("+ hitCount*100 / tossCount + "%)";
		        // 找到名為 "HitRate" 的 child 上的 Text元作,產生的訊息置入
		        gameObject.transform.FindChild ("HitRate").GetComponent<Text>().text=msg;
		    }
	    // 丟球數加1的method
	    public void tossInc(){
		        tossCount++;
		    }
	    // 擊倒數加 1的 method 
	    public void hitInc() {
		        hitCount++;
		    }
}

