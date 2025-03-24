using MarsRoverViewer.Core;
using MarsRoverViewer.Models;
using MarsRoverViewer.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MarsRoverViewer.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<string> Rovers { get; } = new() { "Curiosity", "Opportunity", "Spirit" };
        public ObservableCollection<Photo> Photos { get; set; } = new();


        private string _selectedRover = "Curiosity";
        public string SelectedRover
        {
            get => _selectedRover;
            set { _selectedRover = value; OnPropertyChanged(); }
        }


        private DateTime _selectedDate = DateTime.Now.AddDays(-1);
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged(); }
        }


        public MainViewModel()
        {
            LoadPhotosCommand = new RelayCommand(async () => await LoadPhotosAsync());
        }


        public ICommand LoadPhotosCommand { get; }
        private async Task LoadPhotosAsync()
        {
            var service = new NasaApiService();
            var result = await service.GetPhotosAsync(SelectedRover, SelectedDate);

            Photos.Clear();

            foreach (var photo in result)
            {
                Photos.Add(photo);
            }
        }
    }
}
