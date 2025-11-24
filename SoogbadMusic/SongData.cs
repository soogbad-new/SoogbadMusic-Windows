namespace SoogbadMusic
{
	
	public struct SongData(string title, string artist, string album, uint year, Image? albumCover, string lyrics)
    {
        public string Title { get; set; } = title;
		public string Artist { get; set; } = artist;
		public string Album { get; set; } = album;
		public uint Year { get; set; } = year;
		public Image? AlbumCover { get; set; } = albumCover;
		public string Lyrics { get; set; } = lyrics;

        public readonly bool Contains(string key, bool advanced)
        {
			string realKey = RemoveSpecialCharacters(key.ToLower());
			if(!advanced)
				return Contains(RemoveSpecialCharacters(Artist.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Title.ToLower()), realKey);
			else
				return Contains(RemoveSpecialCharacters(Artist.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Title.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Album.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Year.ToString().ToLower()), realKey) || Contains(RemoveSpecialCharacters(Lyrics.ToLower()), realKey);
		}
		private static bool Contains(string str, string key)
        {
			for(int i = str.IndexOf(key); ; i = str.IndexOf(key, i + 1))
            {
				if(i == -1)
					break;
                else if(i == 0 || str[i - 1] == ' ')
                    return true;
			}
			return false;
		}
		private static string RemoveSpecialCharacters(string str)
        {
			string ret = "";
			foreach(char chr in str)
				if(!char.IsPunctuation(chr) && !char.IsSymbol(chr))
					ret += chr;
			ret = ret.Replace((char)10, ' ');
			ret = ret.Replace((char)13, '~');
			ret = ret.Replace("~", "");
			return ret;
        }

    }

}