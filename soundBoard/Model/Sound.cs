using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soundBoard.Model
{
     public class Sound
     {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        //getters & setters

        public Sound(String name, SoundCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = String.Format("/Assets/Audio/{0}/{1}.wav", category,name);// reads in audio files for each category and then name
            ImageFile = String.Format("/Assets/Images/{0}/{1}.png", category, name);// reads in image files for each category and then name
        }// Sound constructor

    }// Sound

    public enum SoundCategory
    {
        Simpsons,
        FamilyGuy,
        RickAndMorty,// enums for binding images to audio files
        Futurama,
    }// SoundCategory

}// soundBoard.Model
