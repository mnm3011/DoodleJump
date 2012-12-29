using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Doodle_Jump.Utility
{
    public class Sound
    {

        private bool offSound = false;

        private SoundPlayer eSound1 = new SoundPlayer(@"..\..\..\sound\sfx_0.wav");
        private SoundPlayer eSound2 = new SoundPlayer(@"..\..\..\sound\sfx_1.wav");
        private SoundPlayer eSound3 = new SoundPlayer(@"..\..\..\sound\sfx_2.wav");
        private SoundPlayer eSound4 = new SoundPlayer(@"..\..\..\sound\sfx_3.wav");
        private SoundPlayer eSound5 = new SoundPlayer(@"..\..\..\sound\sfx_4.wav");
        private SoundPlayer eSound6 = new SoundPlayer(@"..\..\..\sound\sfx_5.wav");
        private SoundPlayer eSound7 = new SoundPlayer(@"..\..\..\sound\sfx_6.wav");
        private SoundPlayer eSound8 = new SoundPlayer(@"..\..\..\sound\sfx_7.wav");
        private SoundPlayer eSound9 = new SoundPlayer(@"..\..\..\sound\sfx_8.wav");


        public bool OffSound
        {
            get { return offSound; }
            set { offSound = value; }
        }

        public SoundPlayer ESound1
        {
            get { return eSound1; }
        }
        public SoundPlayer ESound2
        {
            get { return eSound2; }
        }
        public SoundPlayer ESound3
        {
            get { return eSound3; }
        }
        public SoundPlayer ESound4
        {
            get { return eSound4; }
        }
        public SoundPlayer ESound5
        {
            get { return eSound5; }
        }
        public SoundPlayer ESound6
        {
            get { return eSound6; }
        }

        public SoundPlayer ESound7
        {
            get { return eSound7; }
        }

        public SoundPlayer ESound8
        {
            get { return eSound8; }
        }

        public SoundPlayer ESound9
        {
            get { return eSound9; }
        }
    }

}
