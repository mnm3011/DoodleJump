using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace Doodle_Jump.Doodler
{
    public static class MechanicDoodler
    {

        /// <summary>
        /// Фукнция, которая проверяет прыгает ли игрок на монстра
        /// </summary>
        /// <param name="keyFlag"></param>
        /// <param name="doodlerY"></param>
        /// <param name="doodlerX"></param>
        /// <param name="doodlerWidth"></param>
        /// <param name="i"></param>
        /// <param name="gravity"></param>
        /// <param name="JUMP_H"></param>
        /// <param name="accelY"></param>
        /// <param name="indexDeleteMonster"></param>
        /// <param name="k"></param>
        /// <param name="map"></param>
        /// <param name="jumpFlag"></param>
        /// <param name="accelX"></param>
        public static void MechanicJumpOn(Doodler doodle, ref int indexDeleteMonster, Map.MonsterInMap kMosterInMap, Map.Map map)
        {
            if ((doodle != null) && (kMosterInMap != null) && (map != null))
            {
                if (doodle.KeyRightOrLeft == true)
                {
                    if (((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) && (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) &&
                        (doodle.DoodlerX >= kMosterInMap.CoordX) && (doodle.DoodlerX <= kMosterInMap.CoordX + kMosterInMap.Width)) || ((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) && (doodle.DoodlerX + doodle.DoodlerWidth - 25 >= kMosterInMap.CoordX) &&
                        (doodle.DoodlerX + doodle.DoodlerWidth - 25 <= kMosterInMap.CoordX + kMosterInMap.Width)) || ((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) && (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) >= kMosterInMap.CoordX) &&
                        (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) <= kMosterInMap.CoordX + kMosterInMap.Width)))
                    {
                        if (kMosterInMap.Type == 4)
                        {
                            MainForm.DurkaFlag = true;
                            MainForm.DurkaXY = kMosterInMap;

                        }
                        else
                        {
                            doodle.JumpFlag = false;
                            doodle.AccelX = 0.0f;
                            doodle.ICurrentJumpHeight = 0.0f;
                            doodle.Gravity = 0.0f;
                            doodle.JUMP_H = 500.0f;
                            doodle.AccelY = 8.0f;
                            indexDeleteMonster = map.Monsters.IndexOf(kMosterInMap);
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound9.Play();
                        }
                    }
                }

                if (doodle.KeyRightOrLeft == false)
                {
                    if (((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) && (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) &&
                        (doodle.DoodlerX + 25 >= kMosterInMap.CoordX) && (doodle.DoodlerX + 25 <= kMosterInMap.CoordX + kMosterInMap.Width)) || ((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) && (doodle.DoodlerX + doodle.DoodlerWidth - 25 >= kMosterInMap.CoordX) &&
                        (doodle.DoodlerX + doodle.DoodlerWidth - 25 <= kMosterInMap.CoordX + kMosterInMap.Width)) || ((doodle.DoodlerY >= kMosterInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kMosterInMap.CoordY + kMosterInMap.Height - map.MoveMap) && (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) >= kMosterInMap.CoordX) &&
                        (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) <= kMosterInMap.CoordX + kMosterInMap.Width)))
                    {
                        if (kMosterInMap.Type == 4)
                        {
                            MainForm.DurkaFlag = true;
                            MainForm.DurkaXY = kMosterInMap;

                        }
                        else
                        {
                            doodle.JumpFlag = false;
                            doodle.AccelX = 0.0f;
                            doodle.ICurrentJumpHeight = 0.0f;
                            doodle.Gravity = 0.0f;
                            doodle.JUMP_H = 500.0f;
                            doodle.AccelY = 8.0f;
                            indexDeleteMonster = map.Monsters.IndexOf(kMosterInMap);
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound9.Play();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Фукнция, которая проверяет прыгает ли игрок на панель
        /// </summary>
        /// <param name="keyFlag"></param>
        /// <param name="doodlerY"></param>
        /// <param name="doodlerX"></param>
        /// <param name="doodlerWidth"></param>
        /// <param name="i"></param>
        /// <param name="gravity"></param>
        /// <param name="JUMP_H"></param>
        /// <param name="accelY"></param>
        /// <param name="k"></param>
        /// <param name="map"></param>
        /// <param name="jumpFlag"></param>
        /// <param name="accelX"></param>
        public static void MechanicJumpOn(Doodler doodle, Map.ObjectInMap kObjectInMap, Map.Map map)
        {
            if ((doodle != null) && (kObjectInMap != null) && (map != null))
            {
                if (doodle.KeyRightOrLeft == false)
                {
                    if (((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) && (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) &&
                        (doodle.DoodlerX >= kObjectInMap.CoordX) && (doodle.DoodlerX <= kObjectInMap.CoordX + 64)) || ((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) && (doodle.DoodlerX + doodle.DoodlerWidth - 30 >= kObjectInMap.CoordX) &&
                        (doodle.DoodlerX + doodle.DoodlerWidth - 30 <= kObjectInMap.CoordX + 64)) || ((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) && (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) >= kObjectInMap.CoordX) &&
                        (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) <= kObjectInMap.CoordX + 64)))
                    {
                        if (kObjectInMap.Type == 2)
                        {

                            kObjectInMap.Type = 3;
                            map.yBadPanel = map.moveMap;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound3.Play();

                        }
                        else
                        {
                            if (kObjectInMap.Type == 3)
                            {

                            }
                            else
                            {
                                doodle.JumpFlag = false;
                                doodle.AccelX = 0.0f;
                                doodle.ICurrentJumpHeight = 0.0f;
                                doodle.Gravity = 0.0f;
                                doodle.JUMP_H = 190.0f;
                                doodle.AccelY = 5.0f;
                                if (MainForm.Sounds.OffSound == false)
                                    MainForm.Sounds.ESound1.Play();
                            }
                        }

                    }
                }

                if (doodle.KeyRightOrLeft == true)
                {
                    if (((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) && (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) &&
                        (doodle.DoodlerX + 30 >= kObjectInMap.CoordX) && (doodle.DoodlerX + 30 <= kObjectInMap.CoordX + 64)) || ((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) && (doodle.DoodlerX + doodle.DoodlerWidth >= kObjectInMap.CoordX) &&
                        (doodle.DoodlerX + doodle.DoodlerWidth <= kObjectInMap.CoordX + 64)) || ((doodle.DoodlerY >= kObjectInMap.CoordY - map.MoveMap) &&
                        (doodle.DoodlerY <= kObjectInMap.CoordY + 16 - map.MoveMap) && (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) >= kObjectInMap.CoordX) &&
                        (doodle.DoodlerX + (doodle.DoodlerWidth / 2.0) <= kObjectInMap.CoordX + 64)))
                    {
                        if (kObjectInMap.Type == 2)
                        {

                            kObjectInMap.Type = 3;
                            map.yBadPanel = map.moveMap;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound3.Play();

                        }
                        else
                        {
                            if (kObjectInMap.Type == 3)
                            {

                            }
                            else
                            {
                                doodle.JumpFlag = false;
                                doodle.AccelX = 0.0f;
                                doodle.ICurrentJumpHeight = 0.0f;
                                doodle.Gravity = 0.0f;
                                doodle.JUMP_H = 190.0f;
                                doodle.AccelY = 5.0f;
                                if (MainForm.Sounds.OffSound == false)
                                    MainForm.Sounds.ESound1.Play();
                            }
                        }

                    }
                }
            }
        }
        /// <summary>
        /// Фукнция, которая проверяет прыгает ли игрок на бонус
        /// и в зависимости от этого увеличивает характеристику
        /// </summary>
        /// <param name="keyFlag"></param>
        /// <param name="doodlerY"></param>
        /// <param name="doodlerX"></param>
        /// <param name="doodlerWidth"></param>
        /// <param name="i"></param>
        /// <param name="gravity"></param>
        /// <param name="JUMP_H"></param>
        /// <param name="accelY"></param>
        /// <param name="k"></param>
        /// <param name="map"></param>
        /// <param name="jumpFlag"></param>
        /// <param name="accelX"></param>
        public static void MechanicJumpOn(Doodler doodle, Map.BonusInMap kBonusInMap, Map.Map map, ref int indexDeleteBonus)
        {
            if ((doodle != null) && (kBonusInMap != null) && (map != null))
            {
                float bufDoodleHeight = 7.0f;
                if (kBonusInMap.Type == 4)
                {
                    bufDoodleHeight = 56.0f;
                }

                if (doodle.KeyRightOrLeft == false)
                {
                    if (IntersectionRectangles(kBonusInMap.CoordX, kBonusInMap.CoordY, kBonusInMap.width, kBonusInMap.height, doodle.DoodlerX, doodle.DoodlerY, doodle.DoodlerWidth - 25, bufDoodleHeight, map.MoveMap))
                    {
                        doodle.JumpFlag = false;
                        doodle.AccelX = 0.0f;
                        doodle.ICurrentJumpHeight = 0.0f;
                        doodle.Gravity = 0.0f;
                        doodle.AccelY = 6.0f;
                        if ((kBonusInMap.Type == 0) || (kBonusInMap.Type == 1))
                        {
                            doodle.JUMP_H = 500.0f;
                            doodle.AccelY = 8.0f;
                            kBonusInMap.bonusJump = 10;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound6.Play();
                        }
                        if ((kBonusInMap.Type == 2) || (kBonusInMap.Type == 3))
                        {
                            doodle.JUMP_H = 600.0f;
                            doodle.AccelY = 8.0f;
                            kBonusInMap.bonusJump = 10;

                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound5.Play();
                        }

                        if ((kBonusInMap.Type == 4))
                        {
                            doodle.JUMP_H = 2000.0f;
                            doodle.AccelY = 0.0f;
                            doodle.GyroFlag = true;
                            doodle.Godlike = true;
                            indexDeleteBonus = -2;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound7.Play();
                        }
                    }
                }

                if (doodle.KeyRightOrLeft == true)
                {
                    if (IntersectionRectangles(kBonusInMap.CoordX, kBonusInMap.CoordY, kBonusInMap.width, kBonusInMap.height, doodle.DoodlerX + 25, doodle.DoodlerY, doodle.DoodlerWidth - 25, bufDoodleHeight, map.MoveMap))
                    {
                        doodle.JumpFlag = false;
                        doodle.AccelX = 0.0f;
                        doodle.ICurrentJumpHeight = 0.0f;
                        doodle.Gravity = 0.0f;
                        doodle.AccelY = 6.0f;
                        if ((kBonusInMap.Type == 0) || (kBonusInMap.Type == 1))
                        {
                            doodle.JUMP_H = 500.0f;
                            doodle.AccelY = 8.0f;
                            kBonusInMap.bonusJump = 10;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound6.Play();
                        }
                        if ((kBonusInMap.Type == 2) || (kBonusInMap.Type == 3))
                        {
                            doodle.JUMP_H = 600.0f;
                            doodle.AccelY = 8.0f;
                            kBonusInMap.bonusJump = 10;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound5.Play();
                        }
                        if ((kBonusInMap.Type == 4))
                        {
                            doodle.JUMP_H = 2000.0f;
                            doodle.AccelY = 0.0f;
                            doodle.GyroFlag = true;
                            doodle.Godlike = true;
                            indexDeleteBonus = -2;
                            if (MainForm.Sounds.OffSound == false)
                                MainForm.Sounds.ESound7.Play();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Функция, которая возвращает истину, если игрок прыгнул под монстра
        /// Используется для вызова GameOver
        /// </summary>
        /// <param name="keyFlag"></param>
        /// <param name="doodlerY"></param>
        /// <param name="doodlerX"></param>
        /// <param name="doodlerWidth"></param>
        /// <param name="k"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static bool MechanicJumpInMonster(Doodler doodle, Map.MonsterInMap kMonsterInMap, Map.Map map)
        {
            if ((doodle != null) && (kMonsterInMap != null) && (map != null))
            {
                if (doodle.KeyRightOrLeft == true)
                {
                    if (IntersectionRectangles(kMonsterInMap.CoordX + 20.0f, kMonsterInMap.CoordY + 20.0f, kMonsterInMap.Width - 20.0f, kMonsterInMap.Height - 20.0f, doodle.DoodlerX, doodle.DoodlerY, doodle.DoodlerWidth - 25, doodle.DoodlerWidth, map.MoveMap))
                    {


                        return true;
                    }
                }

                if (doodle.KeyRightOrLeft == false)
                {
                    if (IntersectionRectangles(kMonsterInMap.CoordX + 20.0f, kMonsterInMap.CoordY + 20.0f, kMonsterInMap.Width - 20.0f, kMonsterInMap.Height - 20.0f, doodle.DoodlerX + 25, doodle.DoodlerY, doodle.DoodlerWidth - 25, doodle.DoodlerWidth, map.MoveMap))
                    {

                        return true;

                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Doodler jump on object
        /// </summary>
        /// <param name="map"></param>
        /// <param name="doodle"></param>
        public static void DoodlerJump(Map.Map map, Doodler doodle)
        {
            if ((doodle != null) && (map != null))
            {
                if (doodle.JumpFlag == true)
                {
                    if (doodle.Gravity < 6.5f)
                    {
                        doodle.Gravity += 0.25f;
                    }
                    doodle.DoodlerY -= doodle.Gravity;
                    foreach (Doodle_Jump.Map.PanelInMap k in map.Panels)
                    {
                        MechanicDoodler.MechanicJumpOn(doodle, k, map);
                    }

                    int indexDeleteMonster = 0;
                    foreach (Map.MonsterInMap k in map.Monsters)
                    {

                        MechanicJumpOn(doodle, ref indexDeleteMonster, k, map);


                    }

                    if (indexDeleteMonster != 0)
                    {
                        map.Monsters.RemoveAt(indexDeleteMonster);
                    }

                    int indexDeleteBonus = -1;
                    foreach (Map.BonusInMap k in map.Bonus)
                    {
                        MechanicDoodler.MechanicJumpOn(doodle, k, map, ref indexDeleteBonus);
                        if (indexDeleteBonus == -2)
                        {
                            indexDeleteBonus = map.Bonus.IndexOf(k);
                        }
                    }
                    if (indexDeleteBonus != -1)
                    {
                        map.Bonus.RemoveAt(indexDeleteBonus);
                    }
                }



                if ((doodle.JumpFlag == false) && (doodle.ICurrentJumpHeight < doodle.JUMP_H))
                {
                    if ((doodle.ICurrentJumpHeight > 100.0f) && (doodle.JUMP_H == 190.0f))
                    {
                        doodle.AccelY -= 0.13f;
                    }
                    if ((doodle.ICurrentJumpHeight > 390.0f) && (doodle.JUMP_H == 500.0f))
                    {
                        doodle.AccelY -= 0.25f;
                    }
                    //---------------Батут
                    if ((doodle.ICurrentJumpHeight > 450.0f) && (doodle.JUMP_H == 600.0f))
                    {
                        doodle.AccelY -= 0.20f;
                    }
                    //--------------------
                    //---------------Вертушка
                    if ((doodle.ICurrentJumpHeight < 300.0f) && (doodle.JUMP_H == 2000.0f))
                    {
                        doodle.AccelY += 0.2f;
                    }
                    if ((doodle.ICurrentJumpHeight > 1700.0f) && (doodle.JUMP_H == 2000.0f))
                    {
                        doodle.AccelY -= 0.2f;
                    }


                    //-------------------------

                    if (doodle.DoodlerY > 300.0f)
                    {

                        map.MoveMap += doodle.AccelY;

                    }
                    else
                    {

                        doodle.DoodlerY += doodle.AccelY;
                    }

                    //если мы прыгнули под монстра
                    int indexDeleteMonster = -1;
                    foreach (Map.MonsterInMap k in map.Monsters)
                    {


                        if (MechanicDoodler.MechanicJumpInMonster(doodle, k, map))
                        {
                            if (k.Type == 4)
                            {
                                MainForm.DurkaFlag = true;
                                MainForm.DurkaXY = k;
                            }
                            else
                            {
                                if (doodle.Godlike == false)
                                {
                                    MainForm.menu = 2;
                                }
                                if (doodle.Godlike == true)
                                    indexDeleteMonster = map.Monsters.IndexOf(k);
                            }
                        }
                    }

                    if (indexDeleteMonster != -1)
                    {
                        map.Monsters.RemoveAt(indexDeleteMonster);
                    }

                    doodle.ICurrentJumpHeight += doodle.AccelY;
                    if (doodle.DoodlerY < 0)
                    {
                        MainForm.menu = 2;
                    }
                }

                if (doodle.ICurrentJumpHeight >= doodle.JUMP_H)
                {
                    doodle.JumpFlag = true;
                    doodle.AccelY = 5.0f;
                    doodle.GyroFlag = false;
                    doodle.Godlike = false;
                }
                if (doodle.DoodlerY < 0)
                {
                    MainForm.menu = 2;
                }

                if ((doodle.ICurrentJumpHeight < 100) && (doodle.KeyRightOrLeft == false))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[5]);

                }

                if ((doodle.ICurrentJumpHeight < 100) && (doodle.KeyRightOrLeft == true))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, MainForm.MGlTextureObject[4]);

                }
            }
        }

        /// <summary>
        /// Проверка пересечения прямоугольников
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="width1"></param>
        /// <param name="heght1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width2"></param>
        /// <param name="heght2"></param>
        /// <param name="moveMap"></param>
        /// <returns></returns>
        public static bool IntersectionRectangles(float x1, float y1, float width1, float heght1, float x2, float y2, float width2, float heght2, float moveMap)
        {
            if ((x1 < x2 + width2) && (x1 + width1 > x2)
                   && (y1 - moveMap < y2 + heght2) && (y1 + heght1 - moveMap > y2))
            {
                return true;
            }
            else
                return false;

        }

    }
}
