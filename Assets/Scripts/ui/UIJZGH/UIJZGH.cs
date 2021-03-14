using projectGF;
using UnityEngine.UI;

public class UIJZGH : UIViewBase
{
    public UIUserInfoModel Model
    {
        get { return _model as UIUserInfoModel; }
    }
    public Button CloseBtn;
    public Button fwghBtn;
    public Button dlghBtn;
    public Button lhdghBtn;
    public Button snghBtn;
    public Button jjghBtn;

    public Text InfoText;

    private string info1 = "西竹一路上都不说话，车子驶进别墅区时，她似乎有些不安，而当车子最终停下，两个面带笑容的中年夫妻急急迎上来时，这不安终于变成了现实。\n" +
"西竹哇的一声大哭起来：“秦放，你是要把我卖了吗？”\n" +
"这小屁孩的神脑补，秦放真是啼笑皆非，他先下了车，打开门抱出西竹，西竹两只小胳膊死抱住他的脖子不放手，哭的肝肠寸断的：“秦放啊，你卖了我，我再也不喜欢你了，我这辈子都不会喜欢你了……”\n" +
"西竹小朋友这电视剧，确实也看的太多了，不过小孩子就是小孩子，嘴上说着不喜欢他了，手上还是搂的死紧的，生怕有人把她抱开了去。\n" +
"秦放又是心疼又是好笑，搂着她软语宽慰，又抱歉似的冲着两夫妻笑了笑。\n" +
"邢太太很理解的笑笑：“小孩子，认生，正常的。来，来，屋里坐。”\n" +
"又忍不住夸西竹：“西西长的真好看啊。”\n" +
"西竹抽抽噎噎的：“好看也不关你的事啊。”\n" +
"邢先生没忍住笑：“小丫头这张嘴……”\n" +
"一边说一边看邢太太：“有你受的啊。”\n" +
"　　……\n" +
"邢先生邢太太夫妇，是秦放为西竹找的新的养父母。\n" +
"这对夫妇他是认识的，之前生意上的合作伙伴，几次往来，极其愉快，对他们的家世、背景、素养都信得过，更重要的是，邢太太极其喜欢女孩，可惜连生两个，都是儿子，一年多前，和秦放闲聊时，就表达过想领养一个女孩的意愿。\n"+
　"　——“连家里头那两个儿子，都整天催我，妈妈，什么时候把小妹妹领回来啊。”\n"+
"所以，一说到领养，秦放头一个就想到邢氏夫妻了。\n"+
"他低下头，亲了亲西竹的脸：“西西你看，多漂亮的房子，树底下还有秋千呢，西西不开心的时候，可以去荡秋千啊。”\n"+
"好说歹说，终于哄的她抬起了头，抽抽嗒嗒地打量门前树下的秋千架。\n"+
"小丫头终于哭的没那么厉害了，邢太太又惊又喜，小心翼翼地问她：“西西，想看看你的房间吗？”\n"+
"原本，依着礼数，客人远道而来，总得坐下寒暄喝茶的，不过现在，西西为大，大家伙一窝蜂地，先上楼看房间了。\n"+
"一开门，连秦放都叹为观止了。\n"+
"这布置的水晶宫一样的女孩儿房间，说是住了个公主也不为过吧，粉色四壁，轻纱帷幔，水晶珠串成的帘子，复古宫廷式的镜子，起居的地方还真矗立了个小小城堡，阳台上各色的芭比娃娃排成了行，衣橱间拉开，那一件件珠光宝气的女孩儿衣裙……邢太太这女儿的梦，做了不止一年两年吧。\n"+
　　"西西脸蛋上还挂着泪珠子，但已经不哭了，眨巴着眼睛左看右看的，邢太太问她：“西西，房间好看吗？”\n"+
　　"西西下巴搁在秦放肩膀上，手指都要含到嘴里去了：“好看。”\n"+
　　"秦放在心里叹气：死土豪，就是这样拼命砸钱赢得无知的少女心的。";
    private string info2 = "数据 2";
    private string info3 = "数据 3";
    private string info4 = "数据 4";
    private string info5 = "数据 5";

    public override void Init()
    {
        CloseBtn.onClick.AddListener(OncloseBtnClick);
        fwghBtn.onClick.AddListener(OnfwghBtnClick);
        dlghBtn.onClick.AddListener(OndlghBtnClick);
        lhdghBtn.onClick.AddListener(OnlhdghBtnClick);
        snghBtn.onClick.AddListener(OnsnghBtnClick);
        jjghBtn.onClick.AddListener(OnjjghBtnClick);



    }

    private void OnfwghBtnClick()
    {
        InfoText.text = info1+ info1+ info1+ info1;
    }

    private void OndlghBtnClick()
    {
        InfoText.text = info2;
    }

    private void OnlhdghBtnClick()
    {
        InfoText.text = info3;
    }

    private void OnsnghBtnClick()
    {
        InfoText.text = info4;
    }

    private void OnjjghBtnClick()
    {
        InfoText.text = info5;
    }

    private void OncloseBtnClick()
    {
        this.Close();
    }

    public override void OnShow()
    {

    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
