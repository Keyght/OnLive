using UnityEngine;

namespace Buttons
{
    public class Toggle : BaseButtonPlayerPerform
    {
        [SerializeField] private Transform _cylinder;

        private bool _state;
        
        protected override void PerformAction()
        {
            Rotate();
        }

        private void Rotate()
        {
            float rotation;
            if (_state) rotation = -90;
            else rotation = 90;
            _cylinder.Rotate(0, rotation, 0);
            _state = !_state;
        }
    }
}
