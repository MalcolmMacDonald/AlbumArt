using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Newtonsoft.Json;
using System.IO;

namespace AlbumArt
{
    class AlbumList
    {
        MainForm currentForm;
        Dictionary<int, List<FullAlbum>> albumsByYear;
        Dictionary<FullArtist, List<FullAlbum>> albumsByArtist;
        string currentJson;
        public AlbumList(MainForm newForm)
        {
            currentForm = newForm;
            currentJson = File.ReadAllText("C:\\Users\\Malcolm MacDonald\\Documents\\Visual Studio 2015\\Projects\\AlbumArt\\grammyData.json");
           GrammyObject[] allObjects = JsonConvert.DeserializeObject<GrammyObject[]>(currentJson);
            allObjects = allObjects.Where(s => s.awardType != "Individual").ToArray();
            List<string> artistNames = new List<string>();
            for(int i = 0; i < allObjects.Length; i++)
            {
                if (!artistNames.Contains(allObjects[i].name))
                {
                    artistNames.Add(allObjects[i].name);
                }
            }

           

        }
    }
    struct GrammyObject
    {
        public string category;
        public int annualGrammy;
        public string awardType;
        public string name;
        public string awardFor;           
        
    }
}
