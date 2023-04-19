using System.Collections.Generic;
using Untitled_Project.DrawHelpers;
using Untitled_Project.GameObject;
using Untitled_Project.LevelCreation;
using Untitled_Project.Player;
using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Misc;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.GameObject.Blocks;

namespace Untitled_Project
{
    internal class LevelGameState : IGameState
    {
        // Collision manager
        private CollisionManager collisionManager = new();
        
        // All of the GameObjects in their lists, including the player
        private static List<AbstractBlock> terrainGameObjects = new();
        private static List<AbstractBlock> terrainToBeRemoved = new();
        private static List<AbstractEnemy> enemyGameObjects = new();
        private static List<AbstractProjectile> playerProjectileGameObjects = new();
        private static List<AbstractProjectile> enemyProjectileGameObjects = new();
        private static List<AbstractProjectile> projectilesToBeRemoved = new();
        private static List<AbstractEnemy> enemiesToBeRemoved = new();
        private static PlayerCharacter player = new(GameMain.Instance.TargetWidth / 2, 650);

        public LevelGameState(string xmlFilePath)
        {
            var gameObjects = LevelLoader.Load(xmlFilePath);
            terrainGameObjects = gameObjects.Item1;
            enemyGameObjects = gameObjects.Item2;
        }
        public void Draw()
        {
            DrawHelperBackground.DrawBackground(GameMain.Instance.WoodTilingSpritesheet);

            terrainGameObjects.ForEach(x => x.Draw());
            enemyGameObjects.ForEach(x => x.Draw());
            playerProjectileGameObjects.ForEach(x => x.Draw());
            enemyProjectileGameObjects.ForEach(x => x.Draw());
            player.Draw();
        }

        public int Update()
        {
            // update all objects in the game
            terrainGameObjects.ForEach( x => x.Update());
            enemyGameObjects.ForEach( x => x.Update());
            playerProjectileGameObjects.ForEach( x => x.Update());
            enemyProjectileGameObjects.ForEach( x => x.Update());
            player.Update();

            // check for collisions and resolve them
            collisionManager.CollisionCheck(terrainGameObjects, enemyGameObjects, playerProjectileGameObjects, enemyProjectileGameObjects, player);
            
            // remove any entities that were killed
            if(projectilesToBeRemoved.Count > 0 || enemiesToBeRemoved.Count > 0 || terrainToBeRemoved.Count > 0)
                RemoveKilledEntities();

            // check if player won
            if (enemyGameObjects.Count == 0)
                return 1;
            return 0;
        }

        public static void SpawnPlayerProjectile(AbstractProjectile proj)
        {
            playerProjectileGameObjects.Add(proj);
        }

        public static void SpawnEnemyProjectile(AbstractProjectile proj)
        {
            enemyProjectileGameObjects.Add(proj);
        }

        public static void KillEnemy(AbstractEnemy enemy)
        {
            if(!enemiesToBeRemoved.Contains(enemy))
                enemiesToBeRemoved.Add(enemy);
        }

        public static void KillProjectile(AbstractProjectile proj)
        {
            if(!projectilesToBeRemoved.Contains(proj))
                projectilesToBeRemoved.Add(proj);
        }

        public static void KillTerrain(AbstractBlock block)
        {
            if(!terrainToBeRemoved.Contains(block)) 
                terrainToBeRemoved.Add(block);
        }

        private static void RemoveKilledEntities()
        {
            foreach(AbstractProjectile proj in projectilesToBeRemoved)
            {
                if (proj.origin == 0)
                    playerProjectileGameObjects.Remove(proj);
                else
                    enemyProjectileGameObjects.Remove(proj);
            }

            enemiesToBeRemoved.ForEach(x => enemyGameObjects.Remove(x));
            terrainToBeRemoved.ForEach(x => terrainGameObjects.Remove(x));

            projectilesToBeRemoved.Clear();
            enemiesToBeRemoved.Clear();
            terrainToBeRemoved.Clear();
        }

        public static void Reset()
        {
            terrainGameObjects.Clear();
            enemyGameObjects.Clear();
            playerProjectileGameObjects.Clear();
            enemyProjectileGameObjects.Clear();
        }
    }
}
