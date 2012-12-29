using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;


namespace Doodle_Jump.Doodler
{
    [Serializable]
    public class Score
    {
        private string name;
        private uint uscore;

        public Score(string _name, uint _score)
        {
            name = _name;
            uscore = _score;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public uint uScore
        {
            get { return uscore; }
            set { uscore = value; }
        }

        public static void WritingFile(Map.Map map)
        {
            if (map != null)
            {
                FileStream fs = new FileStream("score", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();

                foreach (Doodle_Jump.Doodler.Score k in MainForm.Scores)
                {
                    if (MainForm.Scores != null)
                    {
                        if (k.uScore < map.MoveMap)
                        {
                            k.uScore = (uint)map.MoveMap;
                            k.Name = MainForm.DoodlerName;

                            break;
                        }
                    }
                }


                bf.Serialize(fs, MainForm.Scores);
                fs.Dispose();
                fs.Close();
                
            }
        }

        public static void ReadingFile()
        {

            FileStream fs = new FileStream("score", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();


            MainForm.Scores = (List<Doodle_Jump.Doodler.Score>)bf.Deserialize(fs);

            if (MainForm.Scores.Count < 10)
            {
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
                MainForm.Scores.Add(new Score("Doodler", 0));
            }
            fs.Dispose();
            fs.Close();
            
            uint z = 380;
            Gl.glColor4ub(105, 52, 20, 255);
            foreach (Doodle_Jump.Doodler.Score k in MainForm.Scores)
            {

                Texture.Texture.PrintText2DPoint(195, z, k.Name);
                Texture.Texture.PrintText2DPoint(305, z, k.uScore.ToString());
                z -= 20;
            }
        }
    }
}
