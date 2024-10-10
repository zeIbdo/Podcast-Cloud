namespace Podcast.BLL.ViewModels.EpisodeViewModels
{
    public class EpisodeDetailViewModel
    {
        public required EpisodeViewModel MainViewModel { get; set; }
        public required List<EpisodeViewModel> Episodes { get; set; }//
    }
}
