using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.EpisodeViewModels;

namespace Podcast.ADMIN.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        public async Task<IActionResult> Index()
        {
            var episodeList = await _episodeService.GetListAsync(include: x=>x.Include(y=>y.Speaker!).Include(z=>z.Topic!));

            return View(episodeList);
        }

        public async Task<IActionResult> Create()
        {
            var createModel = await _episodeService.GetEpisodeCreateViewModelAsync(new EpisodeCreateViewModel() { CoverFile = null!, Title = null!, Description=null!, MusicFile = null! });

            return View(createModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EpisodeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _episodeService.GetEpisodeCreateViewModelAsync(model);

                return View(model);
            }

            await _episodeService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var model = await _episodeService.GetEpisodeUpdateViewModelAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EpisodeUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var updateModel = await _episodeService.GetEpisodeUpdateViewModelAsync(model.Id);
                return View(updateModel);
            }
            var result = await _episodeService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
