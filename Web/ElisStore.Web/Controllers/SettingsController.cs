namespace ElisStore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ElisStore.Data.Common.Repositories;
    using ElisStore.Data.Models;
    using ElisStore.Services.Data;
    using ElisStore.Services.Messaging;
    using ElisStore.Web.ViewModels.Settings;

    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : Controller
    {
        private readonly ISettingsService settingsService;

        private readonly IDeletableEntityRepository<Setting> repository;
        private readonly IEmailSender emailSender;

        public SettingsController(ISettingsService settingsService, IDeletableEntityRepository<Setting> repository, IEmailSender emailSender)
        {
            this.settingsService = settingsService;
            this.repository = repository;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var settings = this.settingsService.GetAll<SettingViewModel>();
            var model = new SettingsListViewModel { Settings = settings };
            return this.View(model);
        }

        public async Task<IActionResult> InsertSetting()
        {
            await this.emailSender.SendEmailAsync("pesho@elis", "paco", "plamentrakiiski2@abv.bg", "test", "NONE");

            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
