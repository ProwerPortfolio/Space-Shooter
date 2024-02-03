// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Спавнер кораблей ботов.
    /// </summary>
    public class AISpawner : EntitySpawner
    {
        #region Parameters

        /// <summary>
        /// Область патрулирования.
        /// </summary>
        [SerializeField] private AIPointPatrol patrolPoint;

        /// <summary>
        /// Набор точек для патрулирования.
        /// </summary>
        [SerializeField] private Transform[] patrolControlPoints;

        /// <summary>
        /// Идентификатор команды.
        /// </summary>
        [SerializeField] private int teamId;

        #endregion

        #region API

        protected override void SpawnEntities()
        {
            for (int i = 0; i < spawnsCount; i++)
            {
                int index = Random.Range(0, entityPrefabs.Length);

                GameObject entity = Instantiate(entityPrefabs[index].gameObject);

                if (entity.GetComponent<AIController>() != null)
                {
                    AIController aI = entity.GetComponent<AIController>();

                    SpaceShip ship = aI.GetComponent<SpaceShip>();

                    Destructible destructible = ship.GetComponent<Destructible>();

                    aI.patrolPoint = patrolPoint;

                    aI.patrolControlPoints = patrolControlPoints;

                    ship.iD = Random.Range(0, 100000);

                    destructible.teamId = teamId;
                }

                entity.transform.position = area.GetRandomInsideZone();
            }
        }

        #region Unity API



        #endregion

        #region Public API



        #endregion

        #endregion
    }
}