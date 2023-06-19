using DamageNumbersPro;
using UnityEngine;

namespace Battle.Scripts
{
    public class UnitDamageText : MonoBehaviour
    {
        public DamageNumber dmgTakenTxt;
        public bool useText;
        public void Init(UnitHitpoints hp)
        {
            hp.OnDamaged += SpawnText;
        }

        void SpawnText(float dmg)
        {
            if(!useText)return;
            dmgTakenTxt.Spawn(transform.position + Vector3.up * 5, dmg);
        }
    }
}