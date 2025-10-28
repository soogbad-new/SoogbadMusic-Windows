namespace SoogbadMusic.Resources
{

    public delegate void EmptyEventHandler();

    public static class Utility
    {

        public static string FormatTime(double seconds)
        {
            int mins = (int)(seconds / 60);
            int secs = (int)(seconds % 60);
            return mins.ToString() + ":" + (secs >= 10 ? "" : "0") + secs.ToString();
        }

        public static bool ContainsRTLCharacters(string str)
        {
            foreach(char c in str)
                if(c > 'א' && c < 'ݿ')
                    return true;
            return false;
        }

    }

}
