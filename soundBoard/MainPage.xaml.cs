using soundBoard.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace soundBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<String> Suggestions;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);// calls all sounds from soundManager
            
            MenuItems=  new List<MenuItem>();
          
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/simpsons.png", Category = SoundCategory.Simpsons});
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/familyGuy.png", Category = SoundCategory.FamilyGuy});
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/rickAndMorty.png", Category = SoundCategory.RickAndMorty});
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/futurama.png", Category = SoundCategory.Futurama});
            // adds each sound category to each of the logos displayed on side of page
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HambergerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;// makes the  button open pane
        }//HambergerButton_Click

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SearchAutoSuggestBox.Text = "";// clears text box on click
            SoundManager.GetAllSounds(Sounds);// displays all sounds to screen
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;// hides back button
        }// BackButton_Click

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (String.IsNullOrEmpty(sender.Text)) goBack() ;// calls goBack if text box is empty
            SoundManager.GetAllSounds(Sounds);
            Suggestions = Sounds.Where(p => p.Name.StartsWith(sender.Text)).Select(p => p.Name).ToList();// take first letter in text box and searchs through names for a match to diplay to screen
            SearchAutoSuggestBox.ItemsSource = Suggestions;// displays suggestion
        }//SearchAutoSuggestBox_TextChanged

        private void goBack()
        {
            SoundManager.GetAllSounds(Sounds);// loads all sounds to screen
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;// closes back button
        }// goBack


        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SoundManager.GetSoundsByName(Sounds,sender.Text);// groups the sounds by text entered in search box
            CategoryTextBlock.Text = sender.Text;
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;// makes back button visible
            //SearchAutoSuggestBox.Text = "";
        }//SearchAutoSuggestBox_QuerySubmitted

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchAutoSuggestBox.Text = "";// clears text box
            var menuItem = (MenuItem)e.ClickedItem;

            // filter by category
            CategoryTextBlock.Text = menuItem.Category.ToString();// displys category name beside logo
            SoundManager.GetSoundsByCategory(Sounds, menuItem.Category);// groups the sounds by category
            BackButton.Visibility = Visibility.Visible;// makes back button visible 

        }//MenuItemsListView_ItemClick

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;// cast e to a sound
            MyMediaElement.Source = new Uri(this.BaseUri,sound.AudioFile);// sets path to the audio file
        }//SoundGridView_ItemClick

    }
}
