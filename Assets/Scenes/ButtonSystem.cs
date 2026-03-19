using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ButtonSystem : MonoBehaviour
{
    [Header("Thresholds (Seconds)")]
    [SerializeField] private float doubleTapThreshold = 0.25f;
    [SerializeField] private float longPressThreshold = 0.5f;

    private CancellationTokenSource cancelToken;
    private bool isPressed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressed = true;
            HandleInput();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressed = false;
        }
    }

    private async void HandleInput()
    {
        cancelToken?.Cancel();
        cancelToken = new CancellationTokenSource();
        var token = cancelToken.Token;

        try
        {
            Task longPressTask = Task.Delay(TimeSpan.FromSeconds(longPressThreshold), token);

            while (isPressed && !longPressTask.IsCompleted)
            {
                await Task.Yield();
            }

            if (isPressed && longPressTask.IsCompleted)
            {
                Debug.Log("B (Long Press)");
                return;
            }

            float timer = 0;
            bool secondTapDetected = false;

            while (timer < doubleTapThreshold)
            {
                timer += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    secondTapDetected = true;

                    break;
                }
                await Task.Yield();
            }

            if (secondTapDetected)
            {
                Debug.Log("C (Double Tap)");
            }
            else
            {
                Debug.Log("A (Short Tap)");
            }
        }
        catch (OperationCanceledException) { }

    }

}