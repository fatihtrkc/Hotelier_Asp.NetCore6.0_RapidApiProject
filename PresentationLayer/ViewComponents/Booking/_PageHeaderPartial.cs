﻿using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Booking
{
    public class _PageHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
