/***********************************
* @Author GarFey
* UIPanel深度排序
* 工具类
*
*************************************/

using UnityEngine;
using System.Collections.Generic;

namespace projectGF
{
    public static class UIPanelDepthOrder
    {
        private static int curMaxUIDepth = 0;
        /// <summary>
        /// UI界面最大层深
        /// </summary>
        //private const int maxDepth = 500;
        /// <summary>
        /// 界面间的深度间距
        /// </summary>
        private const int depthInterval = 10;
        /// <summary>
        /// 当前UI界面到达深度
        /// </summary>
        public static int CurMaxUiDepth
        {
            get { return curMaxUIDepth; }
        }

        /// <summary>
        /// 加入panelDep 计算
        /// </summary>
        public static void OpenChildPanelDep(UIOpenInfo uiData)
        {
            OrderChildPanel(uiData, curMaxUIDepth, false);
            /*if (curMaxUIDepth >= maxDepth)
            {
                resourceAllPannelDepth();
            }*/
            resourceAllPannelDepth();
        }

        /// <summary>
        /// 退出panelDep 计算
        /// </summary>
        public static void CloseChildPanelDep(UIOpenInfo uiData)
        {
            OrderChildPanel(uiData, curMaxUIDepth, true);
            resourceAllPannelDepth();
        }

        /// <summary>
        /// 获取当前所有显示界面的最高 或 最低层级
        /// </summary>
        /// <param name="isGetMax"> 是否拿最高层级 </param>
        private static int getAllPanelMaxDepth(bool isGetMax = true)
        {
            int mDep = 0;
            List<UIOpenInfo> openList = UICtrl.Instance.UIOpenList;
            UIOpenInfo tmpOpenInfo;
            List<Canvas> tmpPanels = new List<Canvas>();
            List<int> panelDeps = new List<int>();

            for (int i = 0; i < openList.Count; i++)
            {
                tmpOpenInfo = openList[i];
                if (tmpOpenInfo.UIObj != null)
                {
                    tmpPanels = GetChildPanelList(tmpOpenInfo.UIObj.transform);
                    if (tmpPanels == null || tmpPanels.Count <= 0)
                    {
                        return mDep;
                    }
                    for (int j = 0; j < tmpPanels.Count; j++)
                    {
                        panelDeps.Add(tmpPanels[i].sortingOrder);
                    }
                }
            }

            panelDeps.Sort((x, y) =>
            {
                return x.CompareTo(y);
            });
            if (isGetMax)
            {
                mDep = panelDeps[tmpPanels.Count - 1];
            }
            else
            {
                mDep = panelDeps[0];
            }
            return mDep;
        }

        /// <summary>
        /// 重置当前所有界面层级  归一
        /// </summary>
        private static void resourceAllPannelDepth()
        {
            int startDepth = 0;
            curMaxUIDepth = 0;
            List<UIOpenInfo> openList = UICtrl.Instance.UIOpenList;
            UIOpenInfo tmpOpenInfo;
            List<Canvas> tmpPanels = new List<Canvas>();
            for (int i = 0; i < openList.Count; i++)
            {
                tmpOpenInfo = openList[i];
                if (tmpOpenInfo.UIObj != null)
                {
                    tmpPanels = GetChildPanelList(tmpOpenInfo.UIObj.transform);
                    if (tmpPanels == null || tmpPanels.Count <= 0)
                    {
                        continue;
                    }
                    curMaxUIDepth += 10;
                    startDepth = curMaxUIDepth;
                    
                    for (int j = 0; j < tmpPanels.Count; j++)
                    {
                        tmpPanels[j].sortingOrder = startDepth + (j + 1);
                    }
                    curMaxUIDepth = startDepth + tmpPanels.Count;
                }
            }
        }

        /// <summary>
        /// 获取当前最上级界面 最高 panelDepth
        /// </summary>
        /// <param name="IsBlack"> 是否需要带黑背景 true 是需要黑片 </param>
        /// <returns></returns>
        private static int GetUpPanelMaxDepth(bool IsBlack = false)
        {
            int maxDep = 0;
            GameObject tmpPanel = UICtrl.Instance.UIStackPeekGet(IsBlack);
            if (tmpPanel == null)
            {
                return maxDep;
            }

            List<Canvas> tmpPanels = GetChildPanelList(tmpPanel.transform);
            if (tmpPanels == null || tmpPanels.Count <= 0)
            {
                return maxDep;
            }

            tmpPanels.Sort((x, y) =>
            {
                return x.sortingOrder.CompareTo(y.sortingOrder);
            });
            maxDep = tmpPanels[tmpPanels.Count - 1].sortingOrder;
            return maxDep;
        }

        /// <summary>
        /// 获取当前最上级界面 最低 panelDepth
        /// </summary>
        /// <param name="IsBlack"> 是否需要带黑背景 true 是需要黑片 </param>
        /// <returns></returns>
        private static int GetUpPanelMinDepth(bool IsBlack = false)
        {
            int minDep = 0;
            GameObject tmpPanel = UICtrl.Instance.UIStackPeekGet(IsBlack);
            if (tmpPanel == null)
            {
                return minDep;
            }

            List<Canvas> tmpPanels = GetChildPanelList(tmpPanel.transform);
            if (tmpPanels == null || tmpPanels.Count <= 0)
            {
                return minDep;
            }

            tmpPanels.Sort((x, y) =>
            {
                return x.sortingOrder.CompareTo(y.sortingOrder);
            });
            minDep = tmpPanels[0].sortingOrder;
            return minDep;
        }

        /// <summary>
        /// 给指定的Transform下的panel排序
        /// 该panel的depth会记录 curMaxUIDepth 累加或递减
        /// *** 默认 每个界面是有panel且都需要遮罩  《目前需求 》
        /// </summary>
        /// <param name="transf">指定的Trans</param>
        /// <param name="startDepth">开始深度</param>
        /// <param name="isOut">是退出(true)还是加入(false)</param>
        private static void OrderChildPanel(UIOpenInfo data, int startDepth, bool isOut)
        {
            List<Canvas> panels = GetChildPanelList(data.UIObj.transform);
            if (panels == null || panels.Count <= 0)
            {
                return;
            }

            if (isOut)
            {
                startDepth -= depthInterval;
                curMaxUIDepth = startDepth - panels.Count;

                curMaxUIDepth = GetUpPanelMaxDepth();
            }
            else
            {
                startDepth += depthInterval;
                   
                panels.Sort((x, y) =>
                {
                    return x.sortingOrder.CompareTo(y.sortingOrder);
                });

                for (int i = 0; i < panels.Count; ++i)
                {
                    panels[i].sortingOrder = startDepth + (i + 1);
                }
                curMaxUIDepth = startDepth + panels.Count;
            }
        }

        /// <summary>
        /// 获取显示Transform下的panel列表
        /// </summary>
        private static List<Canvas> GetChildPanelList(Transform transf)
        {
            List<Canvas> uiPanelList = new List<Canvas>();
            Transform t = transf.Find("Canvas");
            if (t == null)
            {
                return uiPanelList;
            }
            Canvas panel = t.GetComponent<Canvas>();
            if (panel != null)
            {
                uiPanelList.Add(panel);
            }

            // 递归查找该目录下 所有需要排层级的Canvas
            for (int i = 0; i < transf.childCount; ++i)
            {
                List<Canvas> tempList = GetChildPanelList(transf.GetChild(i));
                if (tempList != null && tempList.Count > 0)
                {
                    uiPanelList.AddRange(tempList);
                }
            }
            return uiPanelList;
        }
    }
}
