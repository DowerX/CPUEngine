using System.Media;
using System.Collections.Generic;


namespace CPUEngine.Engine
{
    public static class EngineAudio
    {
        static int lastKey = 0; 

        public static Dictionary<int, SoundPlayer> players = new Dictionary<int, SoundPlayer>();
        public static Dictionary<string, string> sounds = new Dictionary<string, string>();

        public static bool AddSound(string name, string path)
        {
            if (!sounds.ContainsValue(path))
            {
                sounds.Add(name, path);
                return true;
            }
            else return false;
        }

        public static int CreatePlayer()
        {
            try
            {
                players.Add(lastKey, new SoundPlayer());
                lastKey++;
                return lastKey - 1;
            }
            catch
            {
                return -1;
            }
        }

        public static bool Play(string name, int id)
        {
            try
            {
                players[id].SoundLocation = sounds[name];
                players[id].Play();
                return true;
            }
            catch
            {
                return false;
            }
                
        }

        public static bool Stop(int id)
        {
            try
            {
                players[id].Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}