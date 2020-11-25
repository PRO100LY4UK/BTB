using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ActionScheduler : MonoBehaviour
    {
        public string activeAction;
        public string oldAction;
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if (action == null)
            {
                currentAction = null;
                oldAction = activeAction;
                activeAction = null;
                return;
            }

            if (currentAction == action) return;

            if (currentAction != null)
            {
                oldAction = currentAction.ToString();
                currentAction.Cancel();
            }

            activeAction = action.ToString();
            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            if (currentAction != null)
            {
                currentAction.Cancel();
                oldAction = activeAction;
                activeAction = null;
                currentAction = null;
            }
        }

        public void ResetCurrentAction()
            => StartAction(null);
        

        public bool IsActionRunning()
            => currentAction != null;
    }

