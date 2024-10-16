﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.EpisodeViewModels;

public class EpisodeUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public IFormFile? CoverFile { get; set; }
    public string? CoverUrl { get; set; }
    public IFormFile? MusicFile { get; set; }
    public string? MusicUrl { get; set; }
    public int ViewCount { get; set; }
    public int DownloadCount { get; set; }
    public int LikeCount { get; set; }
    public int DurationInMinute { get; set; }
    public int SpeakerId { get; set; }
    //public int? NewSpeakerId { get; set; }
    public List<SelectListItem>? Speakers { get; set; }
    public int TopicId { get; set; }
    //public int? NewTopicId { get; set; }
    public List<SelectListItem>? Topics { get; set; }
}
