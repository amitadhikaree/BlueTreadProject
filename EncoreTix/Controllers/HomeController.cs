using EncoreTix.Models;
using EncoreTIX.Models;
using EncoreTIX.Services;
using EncoreTIX.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json;

namespace EncoreTix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITicketMaster _ticketMasterService;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, ITicketMaster ticketMasterService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _ticketMasterService = ticketMasterService;
        }


        public async Task<IActionResult> Index()
        {
            var attractions = await _ticketMasterService.GetAttractionsByKeyword("PHISH");
            return View(attractions);
        }


        [HttpPost]
        public async Task<IActionResult> SearchAttraction(string searchKeyword)
        {
            if (!String.IsNullOrEmpty(searchKeyword))
            {
                var attractions = await _ticketMasterService.GetAttractionsByKeyword(searchKeyword);
                return View("Index", attractions); 
            }
            return View("Index", new List<Attraction>());
        }



        [HttpPost]
        public async Task<IActionResult> SubmitAttraction(string selectedAttractionId)
        {
            var attractionDetails = await _ticketMasterService.GetAttractionDetails(selectedAttractionId);
            var attractionEvents =  await _ticketMasterService.GetEventsByAttractionId(selectedAttractionId);
            var attractionViewModel = new AttractionDetail { 
                Attraction = attractionDetails,
                AttractionEvents = attractionEvents
            };
            return View("AttractionDetails", attractionViewModel);
        }


    }
}
