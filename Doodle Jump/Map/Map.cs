using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{
    public class Map
    {
        private List<PanelInMap> panels = new List<PanelInMap>();
        private List<MonsterInMap> monsters = new List<MonsterInMap>();
        private List<Doodler.Shot> shots = new List<Doodle_Jump.Doodler.Shot>();
        private List<BonusInMap> bonus = new List<BonusInMap>();


        Random rand = new Random();
        public float moveMap = 0.0f;

        PanelInMap objRandom = null;
        public float yBadPanel = 0.0f;


        //Первоначальная генерация карты
        public Map()
        {
            int i = 0;
            int aRandom = 48;
            panels.Add(new PanelInMap(100, aRandom, 0, false));
            while (i < 30)
            {
                uint panelID = 0;
                if (rand.Next(0, 5) == 1)
                {
                    panelID = 2;
                }
                int buf = rand.Next(aRandom + 20, (aRandom + 45));
                objRandom = new PanelInMap(rand.Next(40, 400), buf, panelID, false);
                panels.Add(objRandom);
                i++;
                aRandom = buf;

            }
            i = 0;
            while (i < 45)
            {
                monsters.Add(new MonsterInMap(rand.Next(40, 400), rand.Next(i * 100 + 100, 50000), (uint)rand.Next(1, 5), false));
                i++;
            }


            panels.Add(new PanelInMap(38, 48, 0, false));
            // bonus.Add(new BonusInMap(60, 380, 3, false));
            // monsters.Add(new MonsterInMap(100, 340, 4, false));
        }


        //функция покадровой прорисовки карты
        public void Initialization()
        {

            foreach (PanelInMap k in panels)
            {
                //Static Panel
                MechanicMap.SelectedTextureStaticPanel(k, moveMap);
                //Move Panel
                MechanicMap.SeceltedTextureMovePanel(k, moveMap);
                //
                //Выбор текстуры плохой панели, которая при прыжкке расламывается к хуям
                MechanicMap.SelectedTextureBadPanel(k, moveMap);
                //Генерация панелей
                MechanicMap.GenerationPanel(k, moveMap, rand, ref objRandom, bonus);

            }



            //рисуются бонусы
            int iBufIdBonus = -1;        //переменная для удаления бонуса
            foreach (BonusInMap k in bonus)
            {
                MechanicMap.SeceltedTextureBonusJump(k);  //механческая часть



                if ((k.Type == 0) || (k.Type == 1))
                {
                    if (k.bonusJump > 0)
                    {
                        Texture.MapDraw.Bonus1j(k.CoordX, k.CoordY, moveMap);
                        k.bonusJump--;
                    }
                    else
                    {
                        Texture.MapDraw.Bonus(k.CoordX, k.CoordY, k.Type, moveMap, k.width, k.height);     //текстура бонуса пружина
                    }
                }

                if ((k.Type == 2) || (k.Type == 3))
                {
                    if (k.bonusJump > 0)
                    {
                        Texture.MapDraw.Bonus2j(k.CoordX, k.CoordY, moveMap);     //текстура бонуса батут
                        k.bonusJump--;
                    }
                    else
                    {
                        Texture.MapDraw.Bonus(k.CoordX, k.CoordY, k.Type, moveMap, k.width, k.height);     //текстура бонуса пружина
                    }
                }

                if ((k.Type == 4))
                {
                    Texture.MapDraw.Bonus(k.CoordX, k.CoordY, k.Type, moveMap, k.width, k.height);
                }

                if (k.CoordY - moveMap < 0)
                {
                    iBufIdBonus = bonus.IndexOf(k);
                }
            }

            //рисуем каждый раз монстров
            int[] bufArrayMonster = new int[20];   //массив для удаления монстров
            int iBufCounterMonster = 0;            //счетчик
            foreach (MonsterInMap k in monsters)
            {
                //большой монстр
                if (k.Type == 1)
                {
                    if (k.LeftFlag == false)
                    {
                        k.CoordX += 0.2f;

                        if (k.CoordX >= 400)
                        {
                            k.LeftFlag = true;
                        }

                    }
                    if (k.LeftFlag == true)
                    {
                        k.CoordX -= 0.2f;

                        if (k.CoordX <= 100)
                        {
                            k.LeftFlag = false;
                        }

                    }

                }
                Texture.MapDraw.Monster(k, moveMap);
                if (k.CoordY - moveMap < -50)
                {
                    bufArrayMonster[iBufCounterMonster] = monsters.IndexOf(k);
                    iBufCounterMonster++;
                }

            }

            // рисуются пули
            int[] bufArrayShot = new int[20];   //массив для удаления пуль
            int iBufCounterShot = 0;            //счетчик

            foreach (Doodler.Shot k in shots)
            {
                k.CoordY += k.Speed;

                if (k.CoordY > MainForm.Height1)
                {
                    bufArrayShot[iBufCounterShot] = shots.IndexOf(k);
                    iBufCounterShot++;
                }

                Texture.DoodlerDraw.Shot(k.CoordX, k.CoordY);
            }

            //удаление монстра при попадании
            MechanicMap.ShotInMonster(ref monsters, ref shots, moveMap); //попадание в монстра и удаление
            MechanicMap.DeleteObjectFromList(shots, bufArrayShot, iBufCounterShot);  //удаление пули если она выходит за пределы экрана
            MechanicMap.DeleteObjectFromList(monsters, bufArrayMonster, iBufCounterMonster);
            //удаление бонуса
            if (iBufIdBonus != -1)
            {
                bonus.RemoveAt(iBufIdBonus);
            }


        }

        public float MoveMap
        {
            get { return moveMap; }
            set { moveMap = value; }
        }
        public List<PanelInMap> Panels
        {
            get { return panels; }
   
        }
        public List<MonsterInMap> Monsters
        {
            get { return monsters; }
    
        }
        public List<Doodler.Shot> Shots
        {
            get { return shots; }
  
        }
        public List<BonusInMap> Bonus
        {
            get { return bonus; }
  
        }

    }
}
