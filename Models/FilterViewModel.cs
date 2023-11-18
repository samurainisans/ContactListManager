using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVC_Web_App.Models
{
    public class FilterViewModel
    {
        public string SelectedName { get; set; } // Фильтр по имени
        public string SelectedEmail { get; set; } // Фильтр по электронной почте

        // Дополнительные фильтры можно добавить по необходимости

    }
}
