using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace TopDownShooter
{
    public class AbstractScriptableManager<T> : AbstractScriptableManagerBase where T: AbstractScriptableManager<T>
    {
        public static T Instance;
        protected CompositeDisposable compositeDisposable;

        public override void Initialize()
        {
            base.Initialize();
            Instance = this as T;
            compositeDisposable = new CompositeDisposable();
        }

        public override void Destroy()
        {
            compositeDisposable.Dispose();
            base.Destroy();
        }
    }

}
