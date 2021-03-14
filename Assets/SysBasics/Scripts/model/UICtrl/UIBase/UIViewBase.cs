/**
* @Author GarFey
* 20180723
*/
using UnityEngine;

namespace projectGF
{
    public abstract class UIViewBase : MonoBehaviour
    {
        abstract public void Init();
        abstract public void OnShow();
        abstract public void OnHide();
        [HideInInspector]
        public UIModelBase _model;

        public virtual void OnPushData(object[] data)
        {
        }


        void Awake()
        {
            name = name.Replace("(Clone)", "");

            _model = transform.GetComponent<UIModelBase>();
            if (_model != null)
            {
                _model._ui = this;
            }

            UICtrl.Instance._UIManager.RegisterUI(name, this);
        }

        public void Close(CloseType closeType = CloseType.DESTORY)
        {
            UICtrl.Instance.CloseUI(gameObject.name, closeType);
        }

        /// <summary>
        /// 清空显示列表
        /// </summary>
        protected void clearObjList(GameObject objParent)
        {
            int childCount = objParent.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                DestroyImmediate(objParent.transform.GetChild(0).gameObject);
            }

        }
    }
}
