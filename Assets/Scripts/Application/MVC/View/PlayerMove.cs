using UnityEngine;
using System.Collections;

/// <summary>
/// 控制角色移动
/// </summary>
public class PlayerMove : Views
{
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed = 20f;

    /// <summary>
    /// Character Controller
    /// </summary>
    private CharacterController m_CharacterController;

    /// <summary>
    /// 输入方向
    /// </summary>
    private InputDirection m_InputDirecrion = InputDirection.Null;

    /// <summary>
    /// 动作输入
    /// </summary>
    private bool m_ActionInput = false;

    /// <summary>
    /// 鼠标位置
    /// </summary>
    private Vector3 m_MousePosition;

    /// <summary>
    /// 类名称标记
    /// </summary>
    public override string Name
    {
        get { return Consts.V_PlayerMove; }
    }

    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    public override void HandleEvent(string eventName, object data)
    {
        
    }

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    /// <summary>
    /// 更新动作
    /// </summary>
    IEnumerator UpdateAction()
    {
        while (true)
        {
            m_CharacterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);
            GetInputDirection();
            yield return 0;
        }
    }

    /// <summary>
    /// 获取输入方向
    /// </summary>
    private void GetInputDirection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_ActionInput = true;
            m_MousePosition = Input.mousePosition;
        }

        if(Input.GetMouseButton(0) && m_ActionInput)
        {
            Vector3 direction = Input.mousePosition - m_MousePosition;
            if(direction.magnitude > 20)
            {
                if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if(direction.x > 0)
                    {
                        m_InputDirecrion = InputDirection.Right;
                    }
                    else
                    {
                        m_InputDirecrion = InputDirection.Left;
                    }
                }
                else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                {
                    if(direction.y > 0)
                    {
                        m_InputDirecrion = InputDirection.Up;
                    }
                    else
                    {
                        m_InputDirecrion = InputDirection.Down;
                    }
                }

                m_ActionInput = false;
                Debug.Log(m_InputDirecrion.ToString());
            }
        }
    }
}
