﻿#if UNITYMVVMTOOLKIT_UNITASK_SUPPORT

namespace UnityMvvmToolkit.UniTask
{
    using Core;
    using System;
    using Interfaces;
    using System.Runtime.CompilerServices;

    public abstract class BaseAsyncCommand : BaseCommand, IBaseAsyncCommand
    {
        private bool _isRunning;

        protected BaseAsyncCommand(Func<bool> canExecute) : base(canExecute)
        {
        }

        public bool DisableOnExecution { get; set; }

        public virtual bool IsRunning
        {
            get => _isRunning;
            protected set
            {
                _isRunning = value;
                RaiseCanExecuteChanged();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool CanExecute()
        {
            if (DisableOnExecution == false)
            {
                return base.CanExecute();
            }

            return IsRunning == false && base.CanExecute();
        }
    }
}

#endif