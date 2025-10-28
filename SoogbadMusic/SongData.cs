using System.Drawing;

namespace SoogbadMusic
{
	
	public struct SongData
	{

		public SongData(string title, string artist, string album, uint year, Image albumCover, string lyrics)
		{
			Title = title; Artist = artist; Album = album; Year = year; AlbumCover = albumCover; Lyrics = lyrics;
		}
		
		public string Title { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public uint Year { get; set; }
        public Image AlbumCover { get; set; }
        public string Lyrics { get; set; }

        public bool Contains(string key, bool advanced)
        {
			string realKey = RemoveSpecialCharacters(key.ToLower());
			if(!advanced)
				return Contains(RemoveSpecialCharacters(Artist.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Title.ToLower()), realKey);
			else
				return Contains(RemoveSpecialCharacters(Artist.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Title.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Album.ToLower()), realKey) || Contains(RemoveSpecialCharacters(Year.ToString().ToLower()), realKey) || Contains(RemoveSpecialCharacters(Lyrics.ToLower()), realKey);
		}
		private bool Contains(string str, string key)
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
		private string RemoveSpecialCharacters(string str)
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