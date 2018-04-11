using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soundBoard.Model
{
    public class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();
            allSounds.ForEach(p => sounds.Add(p));
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory soundCategory)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(p => p.Category == soundCategory).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }

        public static void GetSoundsByName(ObservableCollection<Sound> sounds, String name)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(p => p.Name == name).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }


        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            
            //============================================
            // simpsons sounds
            sounds.Add(new Sound("homer", SoundCategory.Simpsons));
            sounds.Add(new Sound("homer2", SoundCategory.Simpsons));
            sounds.Add(new Sound("homer3", SoundCategory.Simpsons));
            
            sounds.Add(new Sound("moe", SoundCategory.Simpsons));
            sounds.Add(new Sound("moe2", SoundCategory.Simpsons));

            sounds.Add(new Sound("wiggum", SoundCategory.Simpsons));
            sounds.Add(new Sound("wiggum2", SoundCategory.Simpsons));
            sounds.Add(new Sound("wiggum3", SoundCategory.Simpsons));


            //=============================
            // familyGuy sounds
            sounds.Add(new Sound("peter", SoundCategory.FamilyGuy));
            sounds.Add(new Sound("stewie", SoundCategory.FamilyGuy));
            sounds.Add(new Sound("quagmire", SoundCategory.FamilyGuy));
            sounds.Add(new Sound("herbert", SoundCategory.FamilyGuy));

            //=============================
            // rick and morty sounds
            sounds.Add(new Sound("rick", SoundCategory.RickAndMorty));
            sounds.Add(new Sound("morty", SoundCategory.RickAndMorty));
            sounds.Add(new Sound("pickleRick", SoundCategory.RickAndMorty));
            sounds.Add(new Sound("jerry", SoundCategory.RickAndMorty));
            sounds.Add(new Sound("cromulon", SoundCategory.RickAndMorty));

            //=============================
            // futurama sounds
            sounds.Add(new Sound("bender", SoundCategory.Futurama));
            sounds.Add(new Sound("fry", SoundCategory.Futurama));
            sounds.Add(new Sound("zapp", SoundCategory.Futurama));
            sounds.Add(new Sound("zoidberg", SoundCategory.Futurama));

            return sounds;
        }


    }
}
