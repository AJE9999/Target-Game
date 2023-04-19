using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Untitled_Project.GameObject;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.GameObject.Misc;

namespace Untitled_Project.LevelCreation
{
    public static class LevelLoader
    {
        public static Tuple<List<AbstractBlock>, List<AbstractEnemy>> Load(string xmlFilePath)
        {
            List<AbstractBlock> objList = new List<AbstractBlock>();
            List<AbstractEnemy> enemyList = new List<AbstractEnemy>();
            XmlReader reader = XmlReader.Create(xmlFilePath);

            // Go to STRUCTS section of XML, and read in structs
            reader.ReadToFollowing("STRUCTS");
            objList.AddRange(ReadStructs(reader.ReadSubtree()));

            // Go to OBJECTS section of XML, and read in blocks
            reader.ReadToFollowing("BLOCKS");
            objList.AddRange(ReadBlocks(reader.ReadSubtree()));

            // Go to ENEMIES section of XML, and read in enemies
            reader.ReadToFollowing("ENEMIES");
            enemyList.AddRange(ReadEnemies(reader.ReadSubtree()));

            return Tuple.Create(objList, enemyList);
        }

        private static List<AbstractBlock> ReadStructs(XmlReader reader)
        {
            List<AbstractBlock> objList = new List<AbstractBlock>();

            while(reader.ReadToFollowing("STRUCT"))
            {
                string structType = reader.GetAttribute(0);

                switch(structType)
                {
                    case "Border":
                        for (int i = 0; i < (GameMain.Instance.TargetWidth / 32); i++) {
                            objList.Add(new WallBlock(i * 32, 0));
                            objList.Add(new WallBlock(i * 32, GameMain.Instance.TargetHeight - 32));
                        }
                        for(int i = 1; i < (GameMain.Instance.TargetHeight / 32); i++)
                        {
                            objList.Add(new WallBlock(0, i * 32));
                            objList.Add(new WallBlock(GameMain.Instance.TargetWidth - 32, i * 32));
                        }
                        break;
                    case "Lines":
                        /*The ranges are INCLUSIVE, so x1 = 0 and x2 = 0 would write one line, x1 = 0 and x2 = 31 writes 32 lines*/
                        reader.ReadToFollowing("BLOCKTYPE");
                        string blockType = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("X1");
                        int x1 = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("X2");
                        int x2 = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("Y1");
                        int y1 = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("Y2");
                        int y2 = reader.ReadElementContentAsInt();

                        for(int i = x1; i <= x2; i++)
                        {
                            for(int j = y1; j <= y2; j++)
                            {
                                objList.Add(BlockCreator.createBlock(blockType, i * 32, j * 32));
                            }
                        }


                        break;
                    default:
                        break;
                }
            }

            return objList;
        }
        private static List<AbstractBlock> ReadBlocks(XmlReader reader)
        {
            List<AbstractBlock> blockList = new List<AbstractBlock>();

            while(reader.ReadToFollowing("BLOCK"))
            {
                reader.ReadToFollowing("BLOCKTYPE");
                string blockType = reader.ReadElementContentAsString();
                reader.ReadToFollowing("X");
                int x = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("Y");
                int y = reader.ReadElementContentAsInt();
                
                blockList.Add(BlockCreator.createBlock(blockType, x, y));
            }

            return blockList;
        }
    
        private static List<AbstractEnemy> ReadEnemies(XmlReader reader)
        {
            List<AbstractEnemy> enemyList = new List<AbstractEnemy>();

            while (reader.ReadToFollowing("ENEMY"))
            {
                reader.ReadToFollowing("TYPE");
                string type = reader.ReadElementContentAsString();
                reader.ReadToFollowing("X");
                int x = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("Y");
                int y = reader.ReadElementContentAsInt();

                enemyList.Add(EnemyCreator.createEnemy(type, x, y));
            }

            return enemyList;
        }
    }
}
