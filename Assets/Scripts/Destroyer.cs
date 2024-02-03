// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    public class Destroyer : MonoBehaviour
    {
        #region Parameters



        #endregion

        #region API



        #region Unity API

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destructible destructible = collision?.transform.root.GetComponent<Destructible>();

            if (destructible == null) return;

            destructible.ApplyDamage(100);
        }

        #endregion

        #region Public API



        #endregion

        #endregion
    }
}