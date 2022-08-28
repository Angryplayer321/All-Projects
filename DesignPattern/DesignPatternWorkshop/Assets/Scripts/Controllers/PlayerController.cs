using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !CommandManager.isUndoing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit) && !QuestManager.gameHasStoped)
            {

                MoveCommand command = new MoveCommand(gameObject, transform.position, hit.point, playerSpeed);

                command.Execute();

                CommandManager.instance.AddCommandToList(command);
            }

        }
    }


}
