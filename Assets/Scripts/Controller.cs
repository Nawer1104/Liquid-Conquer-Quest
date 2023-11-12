using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Controller : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;

    [SerializeField] List<GameObject> swipeUpGameObjects;
    [SerializeField] List<GameObject> swipeDownGameObjects;
    [SerializeField] List<GameObject> swipeLeftGameObjects;
    [SerializeField] List<GameObject> swipeRightGameObjects;

    bool isSwipeLeft = false;
    bool isSwipeRight = false;
    bool isSwipeUp = false;
    bool isSwipeDown = false;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        switch(swipe)
        {
            case "Left":
                if (isSwipeLeft) return;
                foreach (GameObject g in swipeLeftGameObjects)
                {
                    g.SetActive(true);
                    g.GetComponent<Animator>().SetTrigger("Show");
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(g);
                    GameManager.Instance.CheckLevelUp();
                }
                isSwipeLeft = true;
                break;
            case "Right":
                if (isSwipeRight) return;
                foreach (GameObject g in swipeRightGameObjects)
                {
                    g.SetActive(true);
                    g.GetComponent<Animator>().SetTrigger("Show");
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(g);
                    GameManager.Instance.CheckLevelUp();
                }
                isSwipeRight = true;
                break;
            case "Up":
                if (isSwipeUp) return;
                foreach (GameObject g in swipeUpGameObjects)
                {
                    g.SetActive(true);
                    g.GetComponent<Animator>().SetTrigger("Show");
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(g);
                    GameManager.Instance.CheckLevelUp();
                }
                isSwipeUp = true;
                break;
            case "Down":
                if (isSwipeDown) return;
                foreach (GameObject g in swipeDownGameObjects)
                {
                    g.SetActive(true);
                    g.GetComponent<Animator>().SetTrigger("Show");
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(g);
                    GameManager.Instance.CheckLevelUp();
                }
                isSwipeDown = true;
                break;
        }
    }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
