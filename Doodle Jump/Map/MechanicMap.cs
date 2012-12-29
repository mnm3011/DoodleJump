using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{
    public static class MechanicMap
    {
        public static void DeleteObjectFromList(List<Doodler.Shot> shots, int[] Array, int num)
        {
            if ((shots != null) && (Array != null))
            {
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    shots.RemoveAt(Array[i]);
                }
            }

            }
        }
        public static void DeleteObjectFromList(List<MonsterInMap> monsters, int[] Array, int num)
        {
            if ((monsters != null) && (Array != null))
            {
                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        monsters.RemoveAt(Array[i]);
                    }
                }
            }
        }
        public static void SelectedTextureBadPanel(ObjectInMap kObjectInMap, float moveMap)
        {
            //Bad Panel
            if (kObjectInMap.Type == 2)
            {
                Texture.MapDraw.BadPanel1(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);
            }
            if (kObjectInMap.Type == 3)
            {
                kObjectInMap.CoordY -= 5;
                Texture.MapDraw.BadPanel2(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);

            }
        }
        public static void SelectedTextureStaticPanel(ObjectInMap kObjectInMap, float moveMap)
        {
            if (kObjectInMap != null)
            {
                if (kObjectInMap.Type == 0)
                {
                    Texture.MapDraw.StaticPanel(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);
                }
            }
        }
        public static void SeceltedTextureMovePanel(ObjectInMap kObjectInMap, float moveMap)
        {
            if (kObjectInMap != null)
            {
                if (kObjectInMap.Type == 1)
                {
                    if (kObjectInMap.LeftFlag == false)
                    {
                        kObjectInMap.CoordX += kObjectInMap.Type;

                        if ((kObjectInMap.CoordX + 64) == 530)
                        {
                            kObjectInMap.LeftFlag = true;
                        }
                    }

                    if (kObjectInMap.LeftFlag == true)
                    {
                        kObjectInMap.CoordX -= kObjectInMap.Type;
                        if (kObjectInMap.CoordX == 10)
                        {
                            kObjectInMap.LeftFlag = false;
                        }
                    }
                    Texture.MapDraw.MovePanel(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);
                }

                if (kObjectInMap.Type == 5)
                {
                    if (kObjectInMap.LeftFlag == false)
                    {
                        kObjectInMap.CoordX += 2;

                        if ((kObjectInMap.CoordX + 64) == 530)
                        {
                            kObjectInMap.LeftFlag = true;
                        }
                    }

                    if (kObjectInMap.LeftFlag == true)
                    {
                        kObjectInMap.CoordX -= 2;
                        if (kObjectInMap.CoordX == 10)
                        {
                            kObjectInMap.LeftFlag = false;
                        }
                    }
                    Texture.MapDraw.MovePanel(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);
                }
            }
        }

        public static void SeceltedTextureBonusJump(ObjectInMap kObjectInMap)
        {
            if (kObjectInMap != null)
            {
                if (kObjectInMap.Type == 1)
                {
                    if (kObjectInMap.LeftFlag == false)
                    {
                        kObjectInMap.CoordX += kObjectInMap.Type;
                        if ((kObjectInMap.CoordX + 31) == 512)
                        {
                            kObjectInMap.LeftFlag = true;
                        }
                    }

                    if (kObjectInMap.LeftFlag == true)
                    {
                        kObjectInMap.CoordX -= kObjectInMap.Type;
                        if (kObjectInMap.CoordX == 24)
                        {
                            kObjectInMap.LeftFlag = false;
                        }
                    }
                    // Texture.MapDraw.MovePanel(kObjectInMap.CoordX, kObjectInMap.CoordY, moveMap);
                }

                if (kObjectInMap.Type == 3)
                {
                    if (kObjectInMap.LeftFlag == false)
                    {
                        kObjectInMap.CoordX += 1;
                        if ((kObjectInMap.CoordX + 62) == 530)
                        {
                            kObjectInMap.LeftFlag = true;
                        }
                    }

                    if (kObjectInMap.LeftFlag == true)
                    {
                        kObjectInMap.CoordX -= 1;
                        if (kObjectInMap.CoordX == 12)
                        {
                            kObjectInMap.LeftFlag = false;
                        }
                    }
                }
                if (kObjectInMap.Type == 4)
                {
                    if (kObjectInMap.LeftFlag == false)
                    {
                        kObjectInMap.CoordX += 1;
                        if ((kObjectInMap.CoordX + 54) == 530)
                        {
                            kObjectInMap.LeftFlag = true;
                        }
                    }

                    if (kObjectInMap.LeftFlag == true)
                    {
                        kObjectInMap.CoordX -= 1;
                        if (kObjectInMap.CoordX == 20)
                        {
                            kObjectInMap.LeftFlag = false;
                        }
                    }
                }
            }
        }


        public static void GenerationPanel(PanelInMap kPanelInMap, float moveMap, Random rand, ref PanelInMap objRandom, List<BonusInMap> bonus)
        {
            if ((kPanelInMap != null) && (rand != null) && (objRandom != null) && (bonus != null))
            {
                //Easy
                if ((kPanelInMap.CoordY - moveMap < -10.0f) && (moveMap < 3000.0f))
                {

                    //Generation Static panel
                    kPanelInMap.CoordY = rand.Next(30 + (int)objRandom.CoordY, 95 + (int)objRandom.CoordY);
                    kPanelInMap.CoordX = rand.Next(20, 430);
                    kPanelInMap.Type = 0;
                    kPanelInMap.LeftFlag = false;

                    //Generation Bad panel
                    if (rand.Next(0, 5) == 2)
                    {
                        kPanelInMap.Type = 2;
                    }
                    else
                    {
                        objRandom = kPanelInMap;
                    }

                    //generation bonus
                    BonusInMap bufBonusInMap = null;
                    uint bufTypeBonus = (uint)rand.Next(0, 10);
                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 0))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 16, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }

                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 2))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 8, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                }

                //NORMAL
                if ((kPanelInMap.CoordY - moveMap < -10.0f) && (moveMap > 3000.0f) && (moveMap <= 10000.0f))
                {

                    //Generation Static panel
                    kPanelInMap.CoordY = rand.Next(30 + (int)objRandom.CoordY, 95 + (int)objRandom.CoordY);
                    kPanelInMap.CoordX = rand.Next(20, 430);
                    kPanelInMap.Type = (uint)rand.Next(0, 2);
                    kPanelInMap.LeftFlag = false;

                    //Generation Bad panel
                    if (rand.Next(0, 10) == 2)
                    {
                        kPanelInMap.Type = 2;
                    }
                    else
                    {
                        objRandom = kPanelInMap;
                    }

                    BonusInMap bufBonusInMap = null;


                    uint bufTypeBonus = (uint)rand.Next(0, 20);

                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 0))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 16, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 1))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 16, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 2))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 8, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 3))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 2, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 4))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 12, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }



                }
                //HARDCORE
                if ((kPanelInMap.CoordY - moveMap < -10.0f) && (moveMap > 10000.0f))
                {

                    //Generation Static panel
                    kPanelInMap.CoordY = rand.Next(30 + (int)objRandom.CoordY, 95 + (int)objRandom.CoordY);
                    kPanelInMap.CoordX = rand.Next(20, 430);
                    kPanelInMap.Type = 1;
                    kPanelInMap.LeftFlag = false;

                    //Generation Bad panel
                    objRandom = kPanelInMap;
                    if (rand.Next(0, 3) == 2)
                    {
                        kPanelInMap.Type = 5;
                        objRandom = kPanelInMap;
                    }

                    //раскидываем бонусы

                    BonusInMap bufBonusInMap = null;


                    uint bufTypeBonus = (uint)rand.Next(0, 30);

                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 0))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 16, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 1))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 16, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 0) && (bufTypeBonus == 2))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 8, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 3))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 2, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }
                    if ((kPanelInMap.Type == 1) && (bufTypeBonus == 4))
                    {
                        bufBonusInMap = new BonusInMap(kPanelInMap.CoordX + 12, kPanelInMap.CoordY + 14, bufTypeBonus, kPanelInMap.LeftFlag);
                        bonus.Add(bufBonusInMap);
                    }



                }
            }
        }

        public static void ShotInMonster(ref List<MonsterInMap> monsters, ref List<Doodler.Shot> shots, float moveMap)
        {
            int[] bufArrayMonster = new int[20];
            int[] bufArrayShot = new int[20];
            int bufCountShot = 0;
            int bufCountMonster = 0;

            foreach (Doodler.Shot k in shots)
            {
                foreach (MonsterInMap j in monsters)
                {
                    if ((k.CoordX >= j.CoordX) && (k.CoordX <= j.CoordX + 104) && (k.CoordY + moveMap >= j.CoordY) && (k.CoordY + moveMap <= j.CoordY + 64))
                    {
                        j.Armor--;
                        bufArrayShot[bufCountShot] = shots.IndexOf(k);
                        bufCountShot++;
                        if (j.Armor == 0)
                        {

                            bufArrayMonster[bufCountMonster] = monsters.IndexOf(j);
                            bufCountMonster++;
                        }
                    }
                }
            }

            for (int i = 0; i < bufCountShot; i++)
            {
                if (bufCountMonster > 0)
                {
                    monsters.RemoveAt(bufArrayMonster[i]);
                }
                shots.RemoveAt(bufArrayShot[i]);
            }

        }

    }
}
