﻿using Microsoft.AspNetCore.Mvc;
using FinalProjectTesting;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace FinalProjectTesting.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private CardGameContext _cardGameContext;
        private readonly ILogger<GameController> _logger;
        public PromptCard[] promptDB;
        public GameController(ILogger<GameController> logger, CardGameContext cardGameContext)
        {
            _logger = logger;
            _cardGameContext = cardGameContext;
        }
        
        [Route("AllPrompts")]
        [HttpGet]
        public PromptCard[] AllPrompts()
        {
            promptDB = _cardGameContext.PromptCard.ToArray();
            return promptDB;
        }
        [Route("SeeSpecificPrompt")]
        [HttpGet]
        public PromptCard SeeSpecificPrompt(int ID)
        {
            promptDB = _cardGameContext.PromptCard.ToArray();
            var promptToShow = new PromptCard();
            foreach(var currPrompt in promptDB)
            {
                if (currPrompt.ID == ID)
                {
                    promptToShow = currPrompt;
                }
            }
            return promptToShow;
        }


    }
}