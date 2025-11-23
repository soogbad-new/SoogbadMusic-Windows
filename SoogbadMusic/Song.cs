namespace SoogbadMusic
{
	
	public sealed class Song
	{
		
		public Song(string path)
		{
			Path = path;
            Refresh();
        }
        public void Refresh()
        {
            if(!File.Exists(Path))
                return;
            using(TagLib.File file = TagLib.File.Create(Path))
            {
                Duration = file.Properties.Duration.TotalSeconds;
                Image image = null;
                if(file.Tag.Pictures.Length > 0)
                    image = Image.FromStream(new MemoryStream(file.Tag.Pictures[0].Data.Data));
                string artist;
                if(file.Tag.AlbumArtists.Length == 0)
                    artist = "";
                else
                {
                    artist = file.Tag.FirstAlbumArtist;
                    if(file.Tag.AlbumArtists.Length > 1)
                        for(int i = 1; i < file.Tag.AlbumArtists.Length; i++)
                            artist += "/" + file.Tag.AlbumArtists[i];
                }
                Data = new SongData(file.Tag.Title == null ? "" : file.Tag.Title, artist, file.Tag.Album == null ? "" : file.Tag.Album, file.Tag.Year, image, file.Tag.Lyrics == null ? "" : file.Tag.Lyrics);
            }
        }


        public string Path { get; private set; }
		public double Duration { get; private set; }
		public SongData Data { get; private set; }

    }


    public class SongComparer : IComparer<Song>
    {
        public int Compare(Song a, Song b)
        {
            int artist = a.Data.Artist.CompareTo(b.Data.Artist);
            if(artist != 0)
                return artist;
            int year = a.Data.Year.CompareTo(b.Data.Year);
            if(year != 0)
                return year;
            int album = a.Data.Album.CompareTo(b.Data.Album);
            if(album != 0)
                return album;
            int title = a.Data.Title.CompareTo(b.Data.Title);
            if(title != 0)
                return title;
            return a.Path.CompareTo(b.Path);
        }
    }

}