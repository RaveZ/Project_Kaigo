using UnityEngine;


namespace Z.CharacterDefense.Runtime
{
    public class DefenseHandler : MonoBehaviour
    {
        private IDefenseInput _defenseInput = null;

        public void Init(IDefenseInput defInput)
        {
            _defenseInput = defInput;
        }

        public void HandleUpdate()
        {//handle parry timer

        }

    }

}
