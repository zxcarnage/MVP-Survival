using System;
using UniRx;
using UnityEngine.InputSystem;

namespace Extensions.UniRX
{
    public static class UniRxExtension
    {
        public static IObservable<InputAction.CallbackContext> ToObservable(this InputAction action) =>
            Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h
            );
    }
}