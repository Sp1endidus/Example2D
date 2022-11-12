using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.States {
    public class StatesController : IInitializable {

        public bool IsLoaded { get; private set; }

        public void Initialize() {


            IsLoaded = true;
        }
    }
}