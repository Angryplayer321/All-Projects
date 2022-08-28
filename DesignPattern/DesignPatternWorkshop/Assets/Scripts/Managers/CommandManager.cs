using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class CommandManager : MonoBehaviour
{
    private IEnumerator moveCoroutine;

    public static CommandManager instance;

    public static bool isUndoing = false;

    List<ICommand> executedCommands = new List<ICommand>();

    private void OnEnable()
    {
        EventManager.
            Instance.AddListener<ResetGameEvent>(ResetGameEventHandler);
    }

    private void OnDisable()
    {
        EventManager.
            Instance.RemoveListener<ResetGameEvent>(ResetGameEventHandler);
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    public void MoveObject(GameObject _movedObject, Vector3 _destinationPoint, float _speed)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = MoveObjectCoroutine(_movedObject, _destinationPoint, _speed);

        StartCoroutine(moveCoroutine);
    }

    public void AddCommandToList(ICommand command)
    {
        executedCommands.Add(command);
    }

   

    private void ResetGameEventHandler(ResetGameEvent resetEvent)
    {
        if (!isUndoing)
        {
            isUndoing = true;
            Time.timeScale = 1;
            StartCoroutine(UndoAllCommands());
        }
    }

    IEnumerator UndoAllCommands()
    {
        for (int i = executedCommands.Count - 1; i >= 0; i--)
        {
            executedCommands[i].Undo();

            yield return new WaitForSeconds(executedCommands[i].ReturnExecutionTime());
        }

        executedCommands.Clear();

        isUndoing = false;
    }

    IEnumerator MoveObjectCoroutine(GameObject _movedObject, Vector3 _destinationPoint, float _speed)
    {
        while (_movedObject.transform.position != _destinationPoint)
        {
            _movedObject.transform.position =
                Vector3.MoveTowards(_movedObject.transform.position, _destinationPoint, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
